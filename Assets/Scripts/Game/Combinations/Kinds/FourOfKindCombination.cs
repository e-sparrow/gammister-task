using Game.Combinations.Enums;

namespace Game.Combinations.Kinds
{
    public class FourOfKindCombination : NumberOfKindCombinationBase
    {
        public FourOfKindCombination() : base(4)
        {
            
        }

        public override ECombinationType Type => ECombinationType.FourOfKind;
    }
}