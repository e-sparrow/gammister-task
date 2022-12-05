using System.Collections.Generic;
using System.Linq;
using Game.Cards.Interfaces;
using Game.Combinations.Enums;
using Game.Combinations.Interfaces;

namespace Game.Combinations.Kinds
{
    public class StraightFlushCombination : CombinationBase
    {
        public StraightFlushCombination(ICombination flush, ICombination straight)
        {
            _flush = flush;
            _straight = straight;
        }

        private readonly ICombination _flush;
        private readonly ICombination _straight;
        
        public override bool Check(IEnumerable<ICard> hand, out IEnumerable<ICard> result)
        {
            result = null;
            
            var isFlush = _flush.Check(hand, out var flush);
            var isStraight = _straight.Check(hand, out var straight);

            if (!isFlush || !isStraight) 
                return false;
            
            var isOverlaps = flush.All(value => straight.Contains(value));

            var isExist = isOverlaps;
            if (isExist)
            {
                result = flush;
            }

            return isExist;
        }

        public override ECombinationType Type => ECombinationType.StraightFlush;
    }
}