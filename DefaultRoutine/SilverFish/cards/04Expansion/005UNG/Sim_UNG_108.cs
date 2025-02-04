using HREngine.Bots;

namespace SilverFish.cards._04Expansion._005UNG
{
	class Sim_UNG_108 : SimTemplate //* Earthen Scales
	{
		//Give a friendly minion +1/+1, then gain Armor equal to its Attack.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetBuffed(target, 1, 1);
            p.minionGetArmor(ownplay ? p.ownHero : p.enemyHero, target.Attack);
        }
    }
}
