using HREngine.Bots;

namespace SilverFish.cards._04Expansion._004CFM
{
	class Sim_CFM_806 : SimTemplate //* Wrathion
	{
		// Taunt. Battlecry: Draw cards until you draw one that isn't a Dragon.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            p.drawACard(CardDB.cardName.unknown, m.own);
            p.drawACard(CardDB.cardName.unknown, m.own);
        }
    }
}