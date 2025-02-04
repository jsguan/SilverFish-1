using HREngine.Bots;

namespace SilverFish.cards._04Expansion._006ICC
{
    class Sim_ICC_913: SimTemplate //* Tainted Zealot
    {
        // Divine Shield. Spell Damage + 1.

        public override void onAuraStarts(Playfield p, Minion own)
        {
            if (own.own) p.spellpower++;
            else p.enemyspellpower++;
        }

        public override void onAuraEnds(Playfield p, Minion m)
        {
            if (m.own) p.spellpower--;
            else p.enemyspellpower--;
        }
    }
}