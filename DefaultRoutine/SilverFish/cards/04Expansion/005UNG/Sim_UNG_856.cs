using HREngine.Bots;

namespace SilverFish.cards._04Expansion._005UNG
{
	class Sim_UNG_856 : SimTemplate //* Hallucination
	{
		//Discover a card from your opponent's class.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.drawACard(CardDB.cardName.unknown, ownplay, true);
            p.drawACard(CardDB.cardName.thecoin, ownplay, true);
			p.owncarddraw--;
        }
    }
}