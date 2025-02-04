using HREngine.Bots;

namespace SilverFish.cards._04Expansion._002AT
{
	class Sim_AT_009 : SimTemplate //* Rhonin
	{
		//Deathrattle: Add 3 copies of Arcane Missiles to your hand.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.drawACard(CardDB.cardName.arcanemissiles, m.own, true);
            p.drawACard(CardDB.cardName.arcanemissiles, m.own, true);
            p.drawACard(CardDB.cardName.arcanemissiles, m.own, true);
        }
	}
}