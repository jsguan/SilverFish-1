using HREngine.Bots;

namespace SilverFish.cards._04Expansion._006ICC
{
    class Sim_ICC_243: SimTemplate //* Corpse Widow
    {
        // Your Deathrattle cards cost (2) less.

        public override void onAuraStarts(Playfield p, Minion own)
        {
            if (own.own) p.ownDRcardsCostMore -= 2;
            else { } //don't use
        }

        public override void onAuraEnds(Playfield p, Minion own)
        {
            if (own.own) p.ownDRcardsCostMore += 2;
            else { } //don't use
        }
    }
}