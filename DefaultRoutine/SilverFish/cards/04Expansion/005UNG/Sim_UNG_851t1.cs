using HREngine.Bots;

namespace SilverFish.cards._04Expansion._005UNG
{
	class Sim_UNG_851t1 : SimTemplate //* Un'Goro Pack
	{
		//Add 5 Journey to Un'Goro cards to your hand.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.drawACard(CardDB.cardName.unknown, ownplay, true);
            p.drawACard(CardDB.cardName.unknown, ownplay, true);
            p.drawACard(CardDB.cardName.unknown, ownplay, true);
            p.drawACard(CardDB.cardName.unknown, ownplay, true);
            p.drawACard(CardDB.cardName.unknown, ownplay, true);
        }
    }
}