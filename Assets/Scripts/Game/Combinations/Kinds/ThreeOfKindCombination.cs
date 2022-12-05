using Game.Combinations.Enums;

namespace Game.Combinations.Kinds
{
    public class ThreeOfKindCombination : NumberOfKindCombinationBase
    {
        public ThreeOfKindCombination() : base(3)
        {
            
        }
        
        public override ECombinationType Type => ECombinationType.ThreeOfKind;
    }
}