using HREngine.Bots;

namespace SilverFish.cards._04Expansion._003OG
{
	class Sim_OG_314 : SimTemplate //* Blood to Ichor
	{
		//Deal 1 damage to a minion. If it survives, summon a 2/2 Slime.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.OG_249a);
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int dmg = (ownplay) ? p.getSpellDamageDamage(1) : p.getEnemySpellDamageDamage(1);
            if (target.HealthPoints > dmg || target.immune || target.divineshild)
            {
				int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
				p.CallKid(kid, pos, ownplay);
            }
            p.minionGetDamageOrHeal(target, dmg);
		}
	}
}