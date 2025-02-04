using HREngine.Bots;

namespace SilverFish.cards._04Expansion._002AT
{
	class Sim_AT_013 : SimTemplate //* Power Word: Glory
	{
		//Choose a minion. Whenever it at tacks, restore 4 health to your hero.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            if (ownplay)
            {
                target.ownPowerWordGlory++;
            }
            else
            {
                target.enemyPowerWordGlory++;
            }
		}
	}
}