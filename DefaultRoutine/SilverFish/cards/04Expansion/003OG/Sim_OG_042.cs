using HREngine.Bots;

namespace SilverFish.cards._04Expansion._003OG
{
	class Sim_OG_042 : SimTemplate //* Y'Shaarj, Rage Unbound
	{
		//At the end of your turn, put a minion from your deck into the battlefield.
		
        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_623); //6/6 Temple Enforcer

        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (triggerEffectMinion.own == turnEndOfOwner)
            {
				int pos = (triggerEffectMinion.own) ? p.ownMinions.Count : p.enemyMinions.Count;
                p.CallKid(kid, pos, triggerEffectMinion.own, false);
				if (triggerEffectMinion.own)p.ownDeckSize--;
                else p.enemyDeckSize--;
            }
        }
	}
}