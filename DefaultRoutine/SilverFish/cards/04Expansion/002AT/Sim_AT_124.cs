using HREngine.Bots;

namespace SilverFish.cards._04Expansion._002AT
{
	class Sim_AT_124 : SimTemplate //* Bolf Ramshield
	{
		//Whenever your hero takes damage, this minion takes it instead.

        public override void onAuraStarts(Playfield p, Minion own)
        {
            if (own.own)
            {
                p.anzOwnBolfRamshield++;
            }
            else
            {
                p.anzEnemyBolfRamshield++;
            }
        }

        public override void onAuraEnds(Playfield p, Minion own)
        {
            if (own.own)
            {
                p.anzOwnBolfRamshield--;
            }
            else
            {
                p.anzEnemyBolfRamshield--;
            }
        }
    }
}