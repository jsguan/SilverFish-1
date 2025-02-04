using HREngine.Bots;

namespace SilverFish.cards._04Expansion._002AT
{
	class Sim_AT_094 : SimTemplate //* Flame Juggler
	{
		//Deal 1 damage to a random enemy.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own)
            {
                target = p.getEnemyCharTargetForRandomSingleDamage(1);
            }
            else
            {
                target = p.searchRandomMinion(p.ownMinions, searchmode.searchHighestAttack); //damage the Highest (pessimistic)
                if (target == null) target = p.ownHero;
            }
            p.minionGetDamageOrHeal(target, 1);
        }
    }
}