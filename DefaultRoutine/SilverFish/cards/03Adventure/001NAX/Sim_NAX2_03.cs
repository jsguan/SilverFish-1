using HREngine.Bots;

namespace SilverFish.cards._03Adventure._001NAX
{
	class Sim_NAX2_03 : SimTemplate //Rain of Fire
	{

//  Hero Power (Normal): Fire a missile for each card in your opponent's hand.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = 1;
			int cardCount = 0;
            if (ownplay)
            {
				cardCount = p.enemyAnzCards;
				dmg += p.ownHeroPowerExtraDamage;
                if (p.doublepriest >= 1) dmg *= (2 * p.doublepriest);
            }
            else
            {
				cardCount = p.owncards.Count;
				dmg += p.enemyHeroPowerExtraDamage;
                if (p.enemydoublepriest >= 1) dmg *= (2 * p.enemydoublepriest);
            }
						
            for (int i = 0; i < cardCount; i++)
            {
				target = (ownplay)? p.searchRandomMinion(p.enemyMinions, searchmode.searchHighAttackLowHP) : p.searchRandomMinion(p.ownMinions, searchmode.searchHighAttackLowHP);
				if (target == null) target = (ownplay) ? p.enemyHero : p.ownHero;
				p.minionGetDamageOrHeal(target, dmg);
            }
        }
	}
}