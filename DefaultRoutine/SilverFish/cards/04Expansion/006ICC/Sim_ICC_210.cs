using System.Collections.Generic;
using HREngine.Bots;

namespace SilverFish.cards._04Expansion._006ICC
{
    class Sim_ICC_210: SimTemplate //* Shadow Ascendant
    {
        // At the end of your turn, give another random friendly minion +1/+1.

        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (triggerEffectMinion.own == turnEndOfOwner)
            {
                List<Minion> tmp = new List<Minion>(turnEndOfOwner ? p.ownMinions : p.enemyMinions);
                tmp.Sort((a, b) => a.HealthPoints.CompareTo(b.HealthPoints)); //buff the weakest
                foreach (Minion m in tmp)
                {
                    if (triggerEffectMinion.entitiyID == m.entitiyID) continue;
                    p.minionGetBuffed(m, 1, 1);
                    break;
                }
            }
        }
    }
}