using System.Collections.Generic;
using HREngine.Bots;

namespace SilverFish.cards._04Expansion._005UNG
{
	class Sim_UNG_948 : SimTemplate //* Molten Reflection
	{
		//Choose a friendly minion. Summon a copy of it.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            List<Minion> temp = (ownplay) ? p.ownMinions : p.enemyMinions;
            int pos = temp.Count;
            if (pos < 7)
            {
                p.CallKid(target.handcard.card, pos, ownplay);
                temp[pos].setMinionToMinion(target);
            }
        }
    }
}