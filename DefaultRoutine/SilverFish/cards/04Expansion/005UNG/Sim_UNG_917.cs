using HREngine.Bots;

namespace SilverFish.cards._04Expansion._005UNG
{
	class Sim_UNG_917 : SimTemplate //* Dinomancy
	{
		//Your Hero Power: becomes 'Give a Beast +2/+2.'

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.setNewHeroPower(CardDB.cardIDEnum.UNG_917t1, ownplay); // Dinomancy
        }
    }
}