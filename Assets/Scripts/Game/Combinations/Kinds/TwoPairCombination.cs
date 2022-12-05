using System.Collections.Generic;
using System.Linq;
using Game.Cards.Interfaces;
using Game.Combinations.Enums;

namespace Game.Combinations.Kinds
{
    public class TwoPairCombination : CombinationBase
    {
        public override bool Check(IEnumerable<ICard> hand, out IEnumerable<ICard> result)
        {
            result = hand
                .GroupBy(card => card.Rank)
                .Where(group => group.Count() >= 2)
                .SelectMany(value => value);

            var isExist = result.Count() == 4;
            return isExist;
        }

        public override ECombinationType Type => ECombinationType.TwoPair;
    }
}