using System.Collections.Generic;
using System.Linq;
using Game.Cards.Interfaces;
using Game.Combinations.Enums;
using Game.Combinations.Interfaces;

namespace Game.Combinations.Kinds
{
    public class FullHouseCombination : CombinationBase
    {
        public FullHouseCombination(ICombination pair, ICombination threeOfKind)
        {
            _pair = pair;
            _threeOfKind = threeOfKind;
        }

        private readonly ICombination _pair;
        private readonly ICombination _threeOfKind;
        
        public override bool Check(IEnumerable<ICard> hand, out IEnumerable<ICard> result)
        {
            result = null;
            
            var isPair = _pair.Check(hand, out var pair);
            var isThree = _threeOfKind.Check(hand, out var three);

            var isExist = isPair && isThree;
            if (isExist)
            {
                result = pair.Concat(three);
            }

            return isExist;
        }

        public override ECombinationType Type => ECombinationType.FullHouse;
    }
}