using HREngine.Bots;

namespace SilverFish.cards._04Expansion._002AT
{
	class Sim_AT_081 : SimTemplate //* Eadric the Pure
	{
		//Battlecry: Change all enemy minions' attack to 1.
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
			if (own.own)
			{
				foreach (Minion m in p.enemyMinions)
				{
					p.minionSetAngrToX(m, 1);
				}
			}
			else
			{
				foreach (Minion m in p.ownMinions)
				{
					p.minionSetAngrToX(m, 1);
				}
			}				
		}
	}
}