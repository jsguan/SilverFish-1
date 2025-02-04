using HREngine.Bots;

namespace SilverFish.cards._04Expansion._005UNG
{
	class Sim_UNG_952 : SimTemplate //* Spikeridged Steed
	{
		//Give a minion +2/+6 and Taunt. When it dies, summon a Stegodon.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.minionGetBuffed(target, 2, 6);
			target.stegodon++;
		}
	}
}