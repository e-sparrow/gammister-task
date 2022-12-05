using System.Collections.Generic;
using System.Linq;
using Game.Combinations.Interfaces;
using Game.Combinations.Kinds;
using Zenject;

namespace Game.Combinations
{
    public class CombinationInstaller : MonoInstaller<CombinationInstaller>
    {
        public override void InstallBindings()
        {
            /*
            None = 0,
            Pair = 1,
            TwoPair = 2,
            ThreeOfKind = 3,
            JacksOrBetter = 4,
            Straight = 5,
            Flush = 6,
            FullHouse = 7,
            FourOfKind = 8,
            StraightFlush = 9,
            RoyalFlush = 10
            */

            var pair = new PairCombination();
            var twoPair = new TwoPairCombination();
            var threeOfKind = new ThreeOfKindCombination();
            var jacks = new JacksOrBetterCombination();
            var straight = new StraightCombination();
            var flush = new FlushCombination();
            var fullHouse = new FullHouseCombination(pair, threeOfKind);
            var four = new FourOfKindCombination();
            var straightFlush = new StraightFlushCombination(flush, straight);
            var royalFlush = new RoyalFlushCombination(jacks, flush);

            var combinations = new List<ICombination>
            {
                royalFlush,
                straightFlush,
                four,
                fullHouse,
                flush,
                straight,
                jacks,
                threeOfKind,
                twoPair,
                pair
            }.AsEnumerable();

            Container
                .BindInterfacesTo<CombinationProvider>()
                .AsSingle()
                .WithArguments(combinations);
        }
    }
}