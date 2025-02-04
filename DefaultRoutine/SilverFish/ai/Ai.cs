﻿using SilverFish.Helpers;

namespace HREngine.Bots
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Ai
    {

        private int maxdeep = 12;
        public int maxwide = 3000;
        //public int playaroundprob = 40;
        public int playaroundprob2 = 80;
        public int maxNumberOfThreads = 100; //don't change manually, because it changes automatically

        private bool usePenalityManager = true;
        private bool useCutingTargets = true;
        private bool dontRecalc = true;
        private bool useLethalCheck = true;
        private bool useComparison = true;
        public Playfield bestplay = new Playfield();


        public int lethalMissing = 30; //RR

        public MiniSimulator mainTurnSimulator;
 		public List<EnemyTurnSimulator> enemyTurnSim = new List<EnemyTurnSimulator>();
        public List<MiniSimulatorNextTurn> nextTurnSimulator = new List<MiniSimulatorNextTurn>();
        public List<EnemyTurnSimulator> enemySecondTurnSim = new List<EnemyTurnSimulator>();

        public string currentCalculatedBoard = "1";

        PenalityManager penman = PenalityManager.Instance;
        Settings settings = Settings.Instance;

        List<Playfield> posmoves = new List<Playfield>(7000);

        Hrtprozis hp = Hrtprozis.Instance;
        Handmanager hm = Handmanager.Instance;
        Helpfunctions help = Helpfunctions.Instance;

        public Action bestmove = null;
        public float bestmoveValue = 0;
        public Playfield nextMoveGuess = new Playfield();
        public Behavior botBase = null;

        public List<Action> bestActions = new List<Action>();

        public bool secondturnsim = false;
        //public int secondTurnAmount = 256;
        public bool playaround = false;

        private static Ai instance;

        public static Ai Instance
        {
            get
            {
                return instance ?? (instance = new Ai());
            }
        }

        private Ai()
        {
            this.nextMoveGuess = new Playfield { mana = -100 };

            this.mainTurnSimulator = new MiniSimulator(maxdeep, maxwide, 0); // 0 for unlimited
            this.mainTurnSimulator.setPrintingstuff(true);

            for (int i = 0; i < maxNumberOfThreads; i++)
            {
                this.nextTurnSimulator.Add(new MiniSimulatorNextTurn());
                this.enemyTurnSim.Add(new EnemyTurnSimulator());
                this.enemySecondTurnSim.Add(new EnemyTurnSimulator());

                this.nextTurnSimulator[i].thread = i;
                this.enemyTurnSim[i].thread = i;
                this.enemySecondTurnSim[i].thread = i;
            }
        }

        public void setMaxWide(int mw)
        {
            this.maxwide = mw;
            if (maxwide <= 100) this.maxwide = 100;
            this.mainTurnSimulator.updateParams(maxdeep, maxwide, 0);
        }

        public void setTwoTurnSimulation(bool stts, int amount)
        {
            this.mainTurnSimulator.setSecondTurnSimu(stts, amount);
            this.secondturnsim = stts;
            settings.secondTurnAmount = amount;
        }

        public void updateTwoTurnSim()
        {
            this.mainTurnSimulator.setSecondTurnSimu(settings.simulateEnemysTurn, settings.secondTurnAmount);
        }

        public void setPlayAround()
        {
            this.mainTurnSimulator.setPlayAround(settings.playaround, settings.playaroundprob, settings.playaroundprob2);
        }

        private void doallmoves(bool test, bool isLethalCheck)
        {
            LogHelper.WriteCombatLog("### do all moves in Ai start ###");
            //set maxwide to the value for the first-turn-sim.
            foreach (EnemyTurnSimulator ets in enemyTurnSim)
            {
                ets.setMaxwide(true);
            }
            foreach (EnemyTurnSimulator ets in enemySecondTurnSim)
            {
                ets.setMaxwide(true);
            }

            //if (isLethalCheck) this.posmoves[0].enemySecretList.Clear();
            this.posmoves[0].isLethalCheck = isLethalCheck;
            this.mainTurnSimulator.DoAllMoves(this.posmoves[0]);

            bestplay = this.mainTurnSimulator.bestboard;
            float bestval = this.mainTurnSimulator.bestmoveValue;

            LogHelper.WriteCombatLog("-------------------------------------");
            if (bestplay.ruleWeight != 0)
            {
                LogHelper.WriteCombatLog("ruleWeight " + bestplay.ruleWeight * -1);
            }
            if (settings.printRules > 0)
            {
                String[] rulesStr = bestplay.rulesUsed.Split('@');
                foreach (string rs in rulesStr)
                {
                    if (rs == "") continue;
                    LogHelper.WriteCombatLog("rule: " + rs);
                }
            }
            LogHelper.WriteCombatLog("value of best board " + bestval);

            this.bestActions.Clear();
            this.bestmove = null;
            ActionNormalizer an = new ActionNormalizer();
            //an.checkLostActions(bestplay, isLethalCheck);
            if (settings.adjustActions > 0)
            {
                an.adjustActions(bestplay, isLethalCheck);
            }
            LogHelper.WriteCombatLog("Best actions as following:");
            int i = 0;
            foreach (Action a in bestplay.playactions)
            {
                i++;
                this.bestActions.Add(new Action(a));
                LogHelper.WriteCombatLog($"Action{i}:");
                a.print();
            }

            if (this.bestActions.Count >= 1)
            {
                this.bestmove = this.bestActions[0];
                this.bestActions.RemoveAt(0);
            }
            this.bestmoveValue = bestval;

            if (bestmove != null && bestmove.actionType != actionEnum.endturn) // save the guessed move, so we doesnt need to recalc!
            {
                this.nextMoveGuess = new Playfield();

                this.nextMoveGuess.doAction(bestmove);
            }
            else
            {
                nextMoveGuess.mana = -100;
            }

            if (isLethalCheck)
            {
                this.lethalMissing = bestplay.enemyHero.armor + bestplay.enemyHero.HealthPoints;//RR
                LogHelper.WriteCombatLog("missing dmg to lethal " + this.lethalMissing);
            }
            LogHelper.WriteCombatLog("### do all moves in Ai end ###");
        }
        
        public void doNextCalcedMove()
        {
            LogHelper.WriteCombatLog("noRecalcNeeded!!!-----------------------------------");
            //this.bestboard.printActions();

            this.bestmove = null;
            if (this.bestActions.Count >= 1)
            {
                this.bestmove = this.bestActions[0];
                this.bestActions.RemoveAt(0);
            }
            if (this.nextMoveGuess == null) this.nextMoveGuess = new Playfield();
            else SilverFishBot.Instance.updateCThunInfo(nextMoveGuess.anzOgOwnCThunAngrBonus, nextMoveGuess.anzOgOwnCThunHpBonus, nextMoveGuess.anzOgOwnCThunTaunt);

            if (bestmove != null && bestmove.actionType != actionEnum.endturn)  // save the guessed move, so we doesnt need to recalc!
            {
                //this.nextMoveGuess = new Playfield();
                LogHelper.WriteCombatLog("nmgsim-");
                try
                {
                    this.nextMoveGuess.doAction(bestmove);
                    this.bestmove = this.nextMoveGuess.playactions[this.nextMoveGuess.playactions.Count - 1];
                }
                catch (Exception ex)
                {
                    LogHelper.WriteCombatLog("Message ---");
                    LogHelper.WriteCombatLog("Message ---" + ex.Message);
                    LogHelper.WriteCombatLog("Source ---" + ex.Source);
                    LogHelper.WriteCombatLog("StackTrace ---" + ex.StackTrace);
                    LogHelper.WriteCombatLog("TargetSite ---\n{0}" + ex.TargetSite);

                }
                LogHelper.WriteCombatLog("nmgsime-");

            }
            else
            {
                //LogHelper.WriteCombatLog("nd trn");
                nextMoveGuess.mana = -100;
                int twilightelderBonus = 0;
                foreach (Minion m in this.nextMoveGuess.ownMinions)
                {
                    if (m.name == CardDB.cardName.twilightelder && !m.silenced) twilightelderBonus++;
                }
                if (twilightelderBonus > 0)
                {
                    SilverFishBot.Instance.updateCThunInfo(nextMoveGuess.anzOgOwnCThunAngrBonus + twilightelderBonus, nextMoveGuess.anzOgOwnCThunHpBonus + twilightelderBonus, nextMoveGuess.anzOgOwnCThunTaunt);
                }
            }

        }

        public void dosomethingclever(Behavior bbase)
        {
            //return;
            //turncheck
            //help.moveMouse(950,750);
            //help.Screenshot();
            this.botBase = bbase;
            hp.updatePositions();

            posmoves.Clear();
            posmoves.Add(new Playfield());

            //do we need to recalc?
            LogHelper.WriteCombatLog("recalc-check###########");
            if (this.dontRecalc && posmoves[0].isEqual(this.nextMoveGuess, true))
            {
                doNextCalcedMove();
            }
            else
            {
                LogHelper.WriteCombatLog("Leathal-check###########");
                bestmoveValue = -1000000;
                DateTime strt = DateTime.Now;
                if (useLethalCheck)
                {
                    strt = DateTime.Now;
                    doallmoves(false, true);
                    LogHelper.WriteCombatLog("calculated " + (DateTime.Now - strt).TotalSeconds);
                }

                if (bestmoveValue < 10000)
                {
                    posmoves.Clear();
                    posmoves.Add(new Playfield());
                    LogHelper.WriteCombatLog("no lethal, do something random######");
                    strt = DateTime.Now;
                    doallmoves(false, false);
                    LogHelper.WriteCombatLog("calculated " + (DateTime.Now - strt).TotalSeconds);

                }
            }


            //LogHelper.WriteCombatLoging(true);

        }
        


        public List<double> autoTester(bool printstuff, string data = "", int mode = 0) //-mode: 0-all, 1-lethalcheck, 2-normal
        {
            List<double> retval = new List<double>();
            double calcTime = 0;
            LogHelper.WriteCombatLog("simulating board ");

            BoardTester bt = new BoardTester(data);
            if (!bt.datareaded)
            {
                return retval;
            }
            hp.printHero();
            hp.printOwnMinions();
            hp.printEnemyMinions();
            hm.printcards();
            //calculate the stuff
            posmoves.Clear();
            Playfield pMain = new Playfield();
            //pMain.ownHeroPowerCostLessOnce -= ChuckHelper.GetOwnHeroPowerCost();
            //pMain.ownHeroPowerCostLessOnce = -1;
            pMain.print = printstuff;
            posmoves.Add(pMain);

            LogHelper.WriteCombatLog("### Print current board state start ###");
            foreach (Playfield p in this.posmoves)
            {
                p.printBoard();
            }
            LogHelper.WriteCombatLog("ownminionscount " + posmoves[0].ownMinions.Count);
            LogHelper.WriteCombatLog("owncardscount " + posmoves[0].owncards.Count);

            foreach (var item in this.posmoves[0].owncards)
            {
                LogHelper.WriteCombatLog("card " + item.card.name + " is playable :" + item.canplayCard(posmoves[0], true) + " cost/mana: " + item.manacost + "/" + posmoves[0].mana);
            }
            var heroAbilityCard = posmoves[0].ownHeroAblility.card;
            LogHelper.WriteCombatLog("ability " + heroAbilityCard.name + " is playable :" + heroAbilityCard.canplayCard(posmoves[0], 2, true) + " cost/mana: "
                      + heroAbilityCard.getManaCost(posmoves[0], 2) + "/" + posmoves[0].mana);
            LogHelper.WriteCombatLog($"### Print current board state end ###{Environment.NewLine}{Environment.NewLine}");

            DateTime strt = DateTime.Now;
            // lethalcheck
            if (mode == 0 || mode == 1)
            {
                doallmoves(false, true);
                calcTime = (DateTime.Now - strt).TotalSeconds;
                LogHelper.WriteCombatLog("calculated " + calcTime);
                retval.Add(calcTime);
            }

            if (Settings.Instance.berserkIfCanFinishNextTour > 0 && bestmoveValue > 5000)
            {

            }
            else if (bestmoveValue < 10000)
            {
                // normal
                if (mode == 0 || mode == 2)
                {
                    posmoves.Clear();
                    pMain = new Playfield();
                    pMain.print = printstuff;
                    //pMain.ownHeroPowerCostLessOnce = -1;
                    posmoves.Add(pMain);
                    strt = DateTime.Now;
                    doallmoves(false, false);
                    calcTime = (DateTime.Now - strt).TotalSeconds;
                    LogHelper.WriteCombatLog("calculated " + calcTime);
                    retval.Add(calcTime);
                }
            }

            if (printstuff)
            {
                this.mainTurnSimulator.printPosmoves();
                simmulateWholeTurn();
                LogHelper.WriteCombatLog("calculated " + calcTime);
            }

            return retval;
        }

        public void simmulateWholeTurn()
        {
            LogHelper.WriteCombatLog("### simulate best board start ###");
            //this.bestboard.printActions();

            Playfield tempbestboard = new Playfield();

            tempbestboard.printBoard();

            if (bestmove != null && bestmove.actionType != actionEnum.endturn)  // save the guessed move, so we doesnt need to recalc!
            {
                bestmove.print();

                tempbestboard.doAction(bestmove);

            }
            else
            {
                tempbestboard.mana = -100;
            }
            LogHelper.WriteCombatLog("-------------");
            tempbestboard.printBoard();

            foreach (Action bestmovee in this.bestActions)
            {

                LogHelper.WriteCombatLog("stepp");


                if (bestmovee != null && bestmove.actionType != actionEnum.endturn)  // save the guessed move, so we doesnt need to recalc!
                {
                    bestmovee.print();

                    tempbestboard.doAction(bestmovee);

                }
                else
                {
                    tempbestboard.mana = -100;
                }
                LogHelper.WriteCombatLog("-------------");
                tempbestboard.printBoard();
            }

            //LogHelper.WriteCombatLog("AFTER ENEMY TURN:" );
            LogHelper.WriteCombatLog("### simulate best board end ###");
        }

        public void simmulateWholeTurnandPrint()
        {
            help.ErrorLog("###################################");
            help.ErrorLog("what would silverfish do?---------");
            help.ErrorLog("###################################");
            if (this.bestmoveValue >= 10000) help.ErrorLog("DETECTED LETHAL ###################################");
            //this.bestboard.printActions();

            Playfield tempbestboard = new Playfield();

            if (bestmove != null && bestmove.actionType != actionEnum.endturn)  // save the guessed move, so we doesnt need to recalc!
            {

                tempbestboard.doAction(bestmove);
                tempbestboard.printActionforDummies(tempbestboard.playactions[tempbestboard.playactions.Count - 1]);

                if (this.bestActions.Count == 0)
                {
                    help.ErrorLog("end turn");
                }
            }
            else
            {
                tempbestboard.mana = -100;
                help.ErrorLog("end turn");
            }


            foreach (Action bestmovee in this.bestActions)
            {

                if (bestmovee != null && bestmove.actionType != actionEnum.endturn)  // save the guessed move, so we doesnt need to recalc!
                {
                    //bestmovee.print();
                    tempbestboard.doAction(bestmovee);
                    tempbestboard.printActionforDummies(tempbestboard.playactions[tempbestboard.playactions.Count - 1]);

                }
                else
                {
                    tempbestboard.mana = -100;
                    help.ErrorLog("end turn");
                }
            }
        }

        public void updateEntitiy(int old, int newone)
        {
            LogHelper.WriteCombatLog("entityupdate! " + old + " to " + newone);
            if (this.nextMoveGuess != null)
            {
                foreach (Minion m in this.nextMoveGuess.ownMinions)
                {
                    if (m.entitiyID == old) m.entitiyID = newone;
                }
                foreach (Minion m in this.nextMoveGuess.enemyMinions)
                {
                    if (m.entitiyID == old) m.entitiyID = newone;
                }
            }
            foreach (Action a in this.bestActions)
            {
                if (a.own != null && a.own.entitiyID == old) a.own.entitiyID = newone;
                if (a.target != null && a.target.entitiyID == old) a.target.entitiyID = newone;
                if (a.card != null && a.card.entity == old) a.card.entity = newone;
            }

        }

    }


}