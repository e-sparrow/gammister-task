using Game.Combinations.Enums;

namespace Game.Deals.Interfaces
{
    public interface IDealConfiguration
    {
        float GetCombinationMultiplier(ECombinationType type);
    }
}