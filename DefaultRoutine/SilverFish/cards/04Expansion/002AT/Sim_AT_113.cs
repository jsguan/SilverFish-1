using HREngine.Bots;

namespace SilverFish.cards._04Expansion._002AT
{
	class Sim_AT_113 : SimTemplate //* Recruiter
	{
		//Inspire: Add a 2/2 Squire to your hand.
		
		public override void onInspire(Playfield p, Minion m, bool own)
        {
			if (m.own == own)
			{				
				p.drawACard(CardDB.cardName.squire, own, true);
			}
        }
	}
}