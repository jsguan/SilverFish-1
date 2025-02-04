using HREngine.Bots;

namespace SilverFish.cards._04Expansion._005UNG
{
	class Sim_UNG_914 : SimTemplate //* Raptor Hatchling
	{
		//Deathrattle: Shuffle a 4/3 Raptor into your deck.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            if (m.own) p.ownDeckSize++;
            else p.enemyDeckSize++;
        }
    }
}