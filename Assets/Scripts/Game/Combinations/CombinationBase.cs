using System.Collections.Generic;
using Game.Cards.Interfaces;
using Game.Combinations.Enums;
using Game.Combinations.Interfaces;

namespace Game.Combinations
{
    public abstract class CombinationBase : ICombination
    {
        public abstract bool Check(IEnumerable<ICard> hand, out IEnumerable<ICard> result);

        public abstract ECombinationType Type
        {
            get;
        }
    }
}