using System.Collections.Generic;
using Game.Cards.Interfaces;
using Game.Combinations.Enums;

namespace Game.Combinations.Interfaces
{
    public interface ICombinationProvider
    {
        bool Check(IEnumerable<ICard> hand, out ECombinationType type, out IEnumerable<ICard> combination);
    }
}