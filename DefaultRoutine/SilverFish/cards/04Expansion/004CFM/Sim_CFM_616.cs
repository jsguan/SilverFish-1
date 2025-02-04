using System;
using HREngine.Bots;

namespace SilverFish.cards._04Expansion._004CFM
{
	class Sim_CFM_616 : SimTemplate //* Pilfered Power
	{
		// Gain an empty Mana Crystal for each friendly minion.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (ownplay) p.ownMaxMana = Math.Min(10, p.ownMaxMana + p.ownMinions.Count);
            else p.enemyMaxMana = Math.Min(10, p.enemyMaxMana + p.enemyMinions.Count);
        }
    }
}