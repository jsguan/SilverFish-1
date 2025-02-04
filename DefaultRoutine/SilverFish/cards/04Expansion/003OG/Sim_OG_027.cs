using System.Collections.Generic;
using HREngine.Bots;

namespace SilverFish.cards._04Expansion._003OG
{
	class Sim_OG_027 : SimTemplate //* Evolve
	{
		//Transform your minions into random minions that cost (1) more.
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{            
            List<Minion> temp = (ownplay) ? p.ownMinions : p.enemyMinions;
            foreach (Minion m in temp )
            {
                
                
                p.minionTransform(m, p.getRandomCardForManaMinion(m.handcard.card.cost + 1));
            }
		}
	}
}