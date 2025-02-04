using HREngine.Bots;

namespace SilverFish.cards._04Expansion._002AT
{
	class Sim_AT_012 : SimTemplate //* Spawn of Shadows
	{
		//Inspire :Deal 4 damage to each hero.

		public override void onInspire(Playfield p, Minion m, bool own)
        {
			if (m.own == own)
			{
				p.minionGetDamageOrHeal(p.enemyHero, 4);
				p.minionGetDamageOrHeal(p.ownHero, 4);
			}
        }
	}
}