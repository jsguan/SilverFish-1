using HREngine.Bots;

namespace SilverFish.cards._03Adventure._002BRM
{
	class Sim_BRM_015 : SimTemplate //* Revenge
	{
		// Deal 1 damage to all minions. If you have 12 or less Health, deal 3 damage instead.
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
			int dmg = 1;
			int heroHealth = (ownplay) ? p.ownHero.HealthPoints : p.enemyHero.HealthPoints;
			if(heroHealth <= 12) dmg = 3;
			
            dmg = (ownplay) ? p.getSpellDamageDamage(dmg) : p.getEnemySpellDamageDamage(dmg);
            p.allMinionsGetDamage(dmg);
		}
	}
}