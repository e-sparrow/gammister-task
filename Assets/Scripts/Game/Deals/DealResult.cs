using Game.Combinations.Enums;
using Game.Deals.Interfaces;

namespace Game.Deals
{
    public readonly struct DealResult : IDealResult
    {
        public DealResult(bool win = false, ECombinationType combination = ECombinationType.None, float multiplier = 0f)
        {
            Win = win;
            Combination = combination;
            Multiplier = multiplier;
        }

        public bool Win
        {
            get;
        }

        public ECombinationType Combination
        {
            get;
        }

        public float Multiplier
        {
            get;
        }
    }
}