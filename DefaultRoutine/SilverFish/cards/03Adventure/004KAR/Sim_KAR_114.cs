using HREngine.Bots;

namespace SilverFish.cards._03Adventure._004KAR
{
	class Sim_KAR_114 : SimTemplate //* Barnes
	{
		//Battlecry: Summon a 1/1 copy of a random minion in your deck.
		
        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.OG_156a); //Ooze with Taunt
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.CallKid(kid, own.zonepos, own.own);
		}
	}
}