using HREngine.Bots;

namespace SilverFish.cards._03Adventure._003LOE
{
	class Sim_LOE_046 : SimTemplate //* Huge Toad
	{
		//Deathrattle: Deal 1 damage to a random enemy.
		
        public override void onDeathrattle(Playfield p, Minion m)
        {
            Minion target = null;

            if (m.own)
            {
                target = p.getEnemyCharTargetForRandomSingleDamage(1);
            }
            else
            {
                target = p.searchRandomMinion(p.ownMinions, searchmode.searchLowestHP); //(pessimistic)
                if (target == null) target = p.ownHero;
            }
			p.minionGetDamageOrHeal(target, 1);
        }
    }
}