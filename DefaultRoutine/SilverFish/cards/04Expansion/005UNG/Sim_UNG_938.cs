using HREngine.Bots;

namespace SilverFish.cards._04Expansion._005UNG
{
	class Sim_UNG_938 : SimTemplate //* Hot Spring Guardian
	{
		//Taunt. Battlecry: Restore 3 Health.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
			if (target != null)
			{
				int heal = (own.own) ? p.getMinionHeal(3) : p.getEnemyMinionHeal(3);
				p.minionGetDamageOrHeal(target, -heal);
			}
        }
    }
}