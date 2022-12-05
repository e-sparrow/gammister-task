using System.Collections.Generic;
using Game.Cards.Interfaces;
using Game.Combinations.Enums;
using Game.Combinations.Interfaces;

namespace Game.Combinations
{
    public class CombinationProvider : ICombinationProvider
    {
        public CombinationProvider(IEnumerable<ICombination> combinations)
        {
            _combinations = combinations;
        }

        private readonly IEnumerable<ICombination> _combinations;

        public bool Check(IEnumerable<ICard> hand, out ECombinationType type, out IEnumerable<ICard> combination)
        {
            foreach (var item in _combinations)
            {
                if (item.Check(hand, out combination))
                {
                    type = item.Type;
                    return true;
                }
            }

            type = ECombinationType.None;
            combination = null;
            
            return false;
        }
    }
}