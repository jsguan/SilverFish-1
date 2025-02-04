using HREngine.Bots;

namespace SilverFish.cards._03Adventure._001NAX
{
	class Sim_NAX12_02 : SimTemplate //* Decimate
	{
		// Hero Power: Change the Health of all minions to 1.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            foreach (Minion m in p.ownMinions)
            {
                p.minionSetLifetoX(m, 1);
            }
            foreach (Minion m in p.enemyMinions)
            {
                p.minionSetLifetoX(m, 1);
            }
		}
	}
}