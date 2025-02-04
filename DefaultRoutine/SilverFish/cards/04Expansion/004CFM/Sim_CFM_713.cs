using System;
using HREngine.Bots;

namespace SilverFish.cards._04Expansion._004CFM
{
	class Sim_CFM_713 : SimTemplate //* Jade Blossom
	{
		// Summon a Jade Golem. Gain an empty Mana Crystal.
        
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int place = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.CallKid(p.getNextJadeGolem(ownplay), place, ownplay, false);

            if (ownplay) p.ownMaxMana = Math.Min(10, p.ownMaxMana + 1);
            else p.enemyMaxMana = Math.Min(10, p.enemyMaxMana + 1);
        }
    }
}