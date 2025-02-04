using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_DAL_256 : SimTemplate //* 森林的援助
	{
        //双生法术：召唤五个2/2的树人。

		CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_158t);//树人

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
			int pos =(ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
			p.CallKid(kid, pos, ownplay, false);
			p.CallKid(kid, pos, ownplay);
			p.CallKid(kid, pos, ownplay);
			p.CallKid(kid, pos, ownplay);
			p.CallKid(kid, pos, ownplay);

			p.drawACard(CardDB.cardIDEnum.DAL_256ts, ownplay);
		}
	}
}