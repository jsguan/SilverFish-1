using System.Collections.Generic;
using HREngine.Bots;

namespace SilverFish.cards._04Expansion._001GvG
{
    class Sim_GVG_026 : SimTemplate //Feign Death
    {

        //   Trigger all Deathrattles on your minions.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (ownplay)
            {
                p.doDeathrattles(new List<Minion>(p.ownMinions));
            }
            else
            {
                p.doDeathrattles(new List<Minion>(p.enemyMinions));
            }
        }


    }

}