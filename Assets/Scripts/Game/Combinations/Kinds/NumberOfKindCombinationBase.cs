using System.Collections.Generic;
using System.Linq;
using Game.Cards.Interfaces;
using Game.Combinations.Enums;

namespace Game.Combinations.Kinds
{
    public abstract class NumberOfKindCombinationBase : CombinationBase
    {
        protected NumberOfKindCombinationBase(int count)
        {
            _count = count;
        }

        private readonly int _count;
        
        public override bool Check(IEnumerable<ICard> hand, out IEnumerable<ICard> result)
        {
            result = hand
                .GroupBy(card => card.Rank)
                .FirstOrDefault(group => group.Count() == _count);

            var isExist = result != default;
            return isExist;
        }
    }
}