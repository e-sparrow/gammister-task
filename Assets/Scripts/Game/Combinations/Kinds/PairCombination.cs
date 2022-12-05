using Game.Combinations.Enums;

namespace Game.Combinations.Kinds
{
    public class PairCombination : NumberOfKindCombinationBase
    {
        public PairCombination() : base(2)
        {
            
        }

        public override ECombinationType Type => ECombinationType.Pair;
    }
}