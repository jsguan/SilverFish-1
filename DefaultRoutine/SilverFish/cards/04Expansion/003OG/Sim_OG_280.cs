using HREngine.Bots;

namespace SilverFish.cards._04Expansion._003OG
{
    class Sim_OG_280 : SimTemplate //* C'Thun
    {
        //Battlecry: Deal damage equal to this minion's Attack randomly split among all enemies.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            int times = p.anzOgOwnCThunAngrBonus + 6 - own.Attack;
            if (times < 1) times = own.Attack;
            else times += own.Attack;
            p.allCharsOfASideGetRandomDamage(!own.own, times);
            p.allMinionOfASideGetDamage(!own.own, 1);
        }
    }
}