using HREngine.Bots;

namespace SilverFish.cards._04Expansion._002AT
{
	class Sim_AT_091 : SimTemplate //* Tournament Medic
	{
		//Inspire: Restore 2 Health to your Hero.
		
		public override void onInspire(Playfield p, Minion m, bool own)
        {
			if (m.own == own)
			{
				int heal = (own) ? p.getMinionHeal(2) : p.getEnemyMinionHeal(2);
				p.minionGetDamageOrHeal(own ? p.ownHero : p.enemyHero, -heal);
			}
        }
	}
}