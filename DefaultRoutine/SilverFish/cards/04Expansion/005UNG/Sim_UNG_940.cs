using HREngine.Bots;

namespace SilverFish.cards._04Expansion._005UNG
{
	class Sim_UNG_940 : SimTemplate //* Awaken the Makers
	{
		//Quest: Summon 7 Deathrattle minions. Reward: Amara, Warden of Hope.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (p.playactions.Count < 2) p.evaluatePenality -= 30;
        }
    }
}