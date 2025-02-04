using HREngine.Bots;

namespace SilverFish.cards._03Adventure._001NAX
{
	class Sim_NAX11_02 : SimTemplate //* Poison Cloud
	{
		// Hero Power: Deal 1 damage to all minions. If any die, summon a slime.
		
		CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.NAX11_03);//Fallout Slime

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int dmg = (ownplay) ? p.getHeroPowerDamage(1) : p.getEnemyHeroPowerDamage(1);
			p.allMinionsGetDamage(dmg);
			
            int place = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            foreach (Minion m in p.ownMinions)
            {
				if (m.HealthPoints <= 0) p.CallKid(kid, place, ownplay);
			}
            foreach (Minion m in p.enemyMinions)
            {
				if (m.HealthPoints <= 0) p.CallKid(kid, place, ownplay);
			}
		}
	}
}