using HREngine.Bots;

namespace SilverFish.cards._03Adventure._001NAX
{
	class Sim_NAX2_05H : SimTemplate //* Worshipper
	{
		// Your hero has +3 Attack on your turn.

        public override void onAuraStarts(Playfield p, Minion own)
		{
            p.minionGetBuffed(own.own ? p.ownHero : p.enemyHero, 3, 0);
		}

        public override void onAuraEnds(Playfield p, Minion own)
        {
            p.minionGetBuffed(own.own ? p.ownHero : p.enemyHero, -3, 0);
        }
	}
}