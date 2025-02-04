using HREngine.Bots;

namespace SilverFish.cards._03Adventure._001NAX
{
	class Sim_NAX6_02 : SimTemplate //* Necrotic Aura
	{
		//Hero Power: Deal 3 damage to the enemy hero.
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getHeroPowerDamage(3) : p.getEnemyHeroPowerDamage(3);
            p.minionGetDamageOrHeal(ownplay ? p.enemyHero : p.ownHero, dmg);
		}
	}
}