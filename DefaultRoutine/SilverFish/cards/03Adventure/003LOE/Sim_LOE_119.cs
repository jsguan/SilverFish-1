using HREngine.Bots;

namespace SilverFish.cards._03Adventure._003LOE
{
    class Sim_LOE_119 : SimTemplate //* Animated Armor
	{
		//Your hero can only take 1 damage at a time.
		
        public override void onAuraStarts(Playfield p, Minion own)
		{
            if (own.own) p.anzOwnAnimatedArmor++;
            else p.anzEnemyAnimatedArmor++;
		}

        public override void onAuraEnds(Playfield p, Minion m)
        {
            if (m.own) p.anzOwnAnimatedArmor--;
            else p.anzEnemyAnimatedArmor--;
        }
	}
}