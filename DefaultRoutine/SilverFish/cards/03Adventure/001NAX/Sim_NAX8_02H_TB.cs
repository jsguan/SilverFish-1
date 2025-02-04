using System;
using HREngine.Bots;

namespace SilverFish.cards._03Adventure._001NAX
{
	class Sim_NAX8_02H_TB : SimTemplate //* Harvest heroic
	{

//    Hero PowerDraw a card. Gain a Mana Crystal.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.drawACard(CardDB.cardName.unknown, ownplay);
			
			p.mana = Math.Min(10, p.mana++);
			if (ownplay)
			{
				p.ownMaxMana = Math.Min(10, p.ownMaxMana++);
			}
			else
			{
				p.enemyMaxMana = Math.Min(10, p.enemyMaxMana++);
			}
        }
	}
}