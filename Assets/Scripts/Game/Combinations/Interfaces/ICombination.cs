using System.Collections.Generic;
using Game.Cards.Interfaces;
using Game.Combinations.Enums;

namespace Game.Combinations.Interfaces
{
    public interface ICombination
    {
        bool Check(IEnumerable<ICard> hand, out IEnumerable<ICard> result);

        ECombinationType Type
        {
            get;
        }
    }
}