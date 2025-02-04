using HREngine.Bots;

namespace SilverFish.cards._04Expansion._005UNG
{
	class Sim_UNG_087 : SimTemplate //* Bittertide Hydra
	{
		//Whenever this minion takes damage, deal 3 damage to your hero.

        public override void onMinionGotDmgTrigger(Playfield p, Minion m, int anzOwnMinionsGotDmg, int anzEnemyMinionsGotDmg, int anzOwnHeroGotDmg, int anzEnemyHeroGotDmg)
        {
            if (m.anzGotDmg > 0)
            {
                m.anzGotDmg = 0;
				p.minionGetDamageOrHeal(m.own ? p.ownHero : p.enemyHero, 3);
            }
        }
	}
}