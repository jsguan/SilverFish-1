using System.Collections.Generic;
using HREngine.Bots;

namespace SilverFish.cards._04Expansion._005UNG
{
	class Sim_UNG_089 : SimTemplate //* Gentle Megasaur
	{
		//Battlecry: Adapt your Murlocs.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            List<Minion> temp = (own.own) ? p.ownMinions : p.enemyMinions;
			bool first = true;
			int bestAdapt = 0;
            foreach (Minion m in temp)
            {
                if ((TAG_RACE)m.handcard.card.race == TAG_RACE.MURLOC)
				{
					if (first )
					{
						bestAdapt = p.getBestAdapt(m);
						first = false;
					}
					else
					{
						switch (bestAdapt)
						{
                            case 1: p.minionGetBuffed(m, 1, 1); break;
                            case 2: p.minionGetBuffed(m, 3, 0); break;
							case 3 : p.minionGetBuffed(m, 0, 3); break;
							case 4 : m.taunt = true; break;
							case 5 : m.divineshild = true; break;
							case 6 : m.poisonous = true; break;
						}
					}
				}
            }
        }
    }
}