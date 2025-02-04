using HREngine.Bots;

namespace SilverFish.cards._04Expansion._005UNG
{
	class Sim_UNG_021 : SimTemplate //* Steam Surger
	{
		//Battlecry: If you played an Elemental last turn add a 'Flame Geyser' to your hand.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (p.anzOwnElementalsLastTurn > 0 && own.own) p.drawACard(CardDB.cardName.flamegeyser, own.own, true);
        }
    }
}