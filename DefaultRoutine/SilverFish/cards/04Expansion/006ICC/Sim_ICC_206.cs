using HREngine.Bots;

namespace SilverFish.cards._04Expansion._006ICC
{
    class Sim_ICC_206: SimTemplate //* Treachery
    {
        // Choose a friendly minion. Your opponent gains control of it.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetControlled(target, !ownplay, false);
        }
    }
}