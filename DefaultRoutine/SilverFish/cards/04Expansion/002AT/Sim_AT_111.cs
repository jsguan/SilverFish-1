using HREngine.Bots;

namespace SilverFish.cards._04Expansion._002AT
{
	class Sim_AT_111 : SimTemplate //* Refreshment Vendor
	{
		//Battlecry: Restore 4 Health to each hero.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            int heal = (own.own) ? p.getMinionHeal(4) : p.getEnemyMinionHeal(4);
            p.minionGetDamageOrHeal(p.ownHero, -heal);
            p.minionGetDamageOrHeal(p.enemyHero, -heal);
        }
    }
}