using HREngine.Bots;

namespace SilverFish.cards._04Expansion._005UNG
{
	class Sim_UNG_823 : SimTemplate //* Envenom Weapon
	{
		//Give your weapon Poisonous.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
			if (ownplay) p.ownWeapon.poisonous = true;
			else p.enemyWeapon.poisonous = true;
        }
    }
}