using HREngine.Bots;

namespace SilverFish.cards._03Adventure._004KAR
{
	class Sim_KAR_073 : SimTemplate //* Maelstrom Portal
	{
		//Deal 1 damage to all enemy minions. Summon a random 1-Cost minion.
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int dmg = (ownplay) ? p.getSpellDamageDamage(1) : p.getEnemySpellDamageDamage(1);
            p.allMinionOfASideGetDamage(!ownplay, dmg);
			
            int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.CallKid(p.getRandomCardForManaMinion(1), pos, ownplay);
		}
	}
}