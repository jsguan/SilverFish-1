using HREngine.Bots;

namespace SilverFish.cards._04Expansion._004CFM
{
	class Sim_CFM_687 : SimTemplate //* Inkmaster Solia
	{
		// Battlecry: If your deck has no duplicates, the next spell you cast this turn costs (0).

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            if (m.own && p.prozis.noDuplicates) p.nextSpellThisTurnCost0 = true;
        }
    }
}