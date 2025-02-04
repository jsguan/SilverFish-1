using HREngine.Bots;

namespace SilverFish.cards._04Expansion._002AT
{
	class Sim_AT_023 : SimTemplate //* Void Crusher
	{
		//Inspire: Destroy a random minion for each player.

		public override void onInspire(Playfield p, Minion m, bool own)
        {
			if (m.own == own)
			{
                Minion found = p.searchRandomMinion(p.enemyMinions, searchmode.searchLowestHP);
                if (found != null)
                {
                    p.minionGetDestroyed(found);
                }
				found = p.searchRandomMinion(p.ownMinions, searchmode.searchHighHPLowAttack);
                if (found != null)
                {
                    p.minionGetDestroyed(found);
                }
            }
        }
	}
}