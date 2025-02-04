using HREngine.Bots;

namespace SilverFish.cards._03Adventure._004KAR
{
	class Sim_KAR_026 : SimTemplate //* Protect the King
	{
		//For each enemy minion, summon a 1/1 Pawn with Taunt
		
        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.KAR_026t);//Pawn

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int anz = ownplay ? p.enemyMinions.Count : p.ownMinions.Count;
            int pos = ownplay ? p.ownMinions.Count : p.enemyMinions.Count;
            
            for (int i = 0; i < anz; i++)
            {
                p.CallKid(kid, pos, ownplay);
            }
		}
	}
}