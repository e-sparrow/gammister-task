using System.Collections.Generic;
using Game.Cards.Interfaces;
using Game.Combinations.Enums;
using Game.Combinations.Interfaces;

namespace Game.Combinations.Kinds
{
    public class RoyalFlushCombination : CombinationBase
    {
        public RoyalFlushCombination(ICombination jacksOrBetter, ICombination flush)
        {
            _jacksOrBetter = jacksOrBetter;
            _flush = flush;
        }

        private readonly ICombination _jacksOrBetter;
        private readonly ICombination _flush;
        
        public override bool Check(IEnumerable<ICard> hand, out IEnumerable<ICard> result)
        {
            result = null;
            
            var isJacksOrBetter = _jacksOrBetter.Check(hand, out var jacksOrBetter);
            var isFlush = _flush.Check(hand, out var flush);

            var isExist = isJacksOrBetter && isFlush;
            if (isExist)
            {
                result = flush;
            }

            return isExist;
        }

        public override ECombinationType Type => ECombinationType.RoyalFlush;
    }
}