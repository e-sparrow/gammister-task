using Game.Combinations.Enums;

namespace Game.Deals.Interfaces
{
    public interface IDealResult
    {
        bool Win
        {
            get;
        }

        ECombinationType Combination
        {
            get;
        }

        float Multiplier
        {
            get;
        }
    }
}