using HREngine.Bots;

namespace SilverFish.cards._03Adventure._004KAR
{
	class Sim_KAR_041 : SimTemplate //* Moat Lurker
	{
		//Battlecry: Destroy a minion. Deathrattle: Resummon it.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target != null)
            {
                p.LurkersDB.Add(own.entitiyID, new IDEnumOwner() { IDEnum = target.handcard.card.cardIDenum, own = target.own });
                p.minionGetDestroyed(target);
            }
        }
        
        public override void onDeathrattle(Playfield p, Minion m)
        {
            if (p.LurkersDB.ContainsKey(m.entitiyID))
            {
                bool own = p.LurkersDB[m.entitiyID].own;
                int pos = own ? p.ownMinions.Count : p.enemyMinions.Count;
                p.CallKid(CardDB.Instance.getCardDataFromID(p.LurkersDB[m.entitiyID].IDEnum), pos, own);
            }
        }
	}
}