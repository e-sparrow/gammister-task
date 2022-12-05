using System.Collections.Generic;
using System.Linq;
using Game.Cards.Interfaces;
using Game.Combinations.Enums;

namespace Game.Combinations.Kinds
{
    public class FlushCombination : CombinationBase
    {
        public override bool Check(IEnumerable<ICard> hand, out IEnumerable<ICard> result)
        {
            result = hand
                .GroupBy(card => card.Suit)
                .FirstOrDefault(group => group.Count() >= 5);

            var isExist = result != default;
            return isExist;
        }

        public override ECombinationType Type => ECombinationType.Flush;
    }
}