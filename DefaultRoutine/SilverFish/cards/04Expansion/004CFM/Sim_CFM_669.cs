using HREngine.Bots;

namespace SilverFish.cards._04Expansion._004CFM
{
	class Sim_CFM_669 : SimTemplate //* Burgly Bully
	{
		// Whenever your opponent casts a spell, add a Coin to your hand.

        public override void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool wasOwnCard, Minion triggerEffectMinion)
        {
            if (hc.card.type == CardDB.cardtype.SPELL && wasOwnCard != triggerEffectMinion.own)
            {
                p.drawACard(CardDB.cardName.thecoin, triggerEffectMinion.own);
            }
        }
    }
}