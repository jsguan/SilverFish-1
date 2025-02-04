using HREngine.Bots;

namespace SilverFish.cards._04Expansion._002AT
{
	class Sim_AT_084 : SimTemplate //* Lance Carrier
	{
		//Battlecry: Give a friendly minion +2 Attack.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (target != null) p.minionGetBuffed(target, 2, 0);
		}
	}
}