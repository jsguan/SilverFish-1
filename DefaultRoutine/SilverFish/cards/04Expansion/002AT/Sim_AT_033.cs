using HREngine.Bots;

namespace SilverFish.cards._04Expansion._002AT
{
	class Sim_AT_033 : SimTemplate //* Burgle
	{
		//Add 2 random class cards to your hand (From your opponent's class).
		
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.drawACard(CardDB.cardName.unknown, ownplay, true);
            p.drawACard(CardDB.cardName.unknown, ownplay, true);
        }
    }
}