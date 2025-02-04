using HREngine.Bots;

namespace SilverFish.cards._04Expansion._002AT
{
	class Sim_AT_083 : SimTemplate //* Dragonhawk Rider
	{
		//Inspire: Gain Windfury this turn.

		public override void onInspire(Playfield p, Minion m, bool own)
        {
			if (m.own == own)
			{
				m.gotInspire = true;
				p.minionGetWindfurry(m);
			}
        }
		
		public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (triggerEffectMinion.own == turnEndOfOwner)
            {
                if (triggerEffectMinion.gotInspire)
                {
                    triggerEffectMinion.windfury = false;
                    triggerEffectMinion.gotInspire = false;
                }
            }
        }
	}
}