using System.Collections.Generic;
using System.Linq;
using Game.Cards.Enums;
using Game.Cards.Interfaces;
using Game.Combinations.Enums;

namespace Game.Combinations.Kinds
{
    public class JacksOrBetterCombination : CombinationBase
    {
        public override bool Check(IEnumerable<ICard> hand, out IEnumerable<ICard> result)
        {
            result = null;
            
            var isExist = hand.All(card => (byte) card.Rank >= 11 || card.Rank == ECardRank.Ace);
            if (isExist)
            {
                result = hand;
            }
            
            return isExist;
        }

        public override ECombinationType Type => ECombinationType.JacksOrBetter;
    }
}