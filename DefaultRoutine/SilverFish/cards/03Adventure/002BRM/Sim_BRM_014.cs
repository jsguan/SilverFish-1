using HREngine.Bots;

namespace SilverFish.cards._03Adventure._002BRM
{
    class Sim_BRM_014 : SimTemplate //* Core Rager
    {
        // Battlecry: If your hand is empty, gain +3/+3.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            int cardsCount = (m.own) ? p.owncards.Count : p.enemyAnzCards;
            if (cardsCount <= 0)
            {
                p.minionGetBuffed(m, 3, 3);
            }
        }
    }
}