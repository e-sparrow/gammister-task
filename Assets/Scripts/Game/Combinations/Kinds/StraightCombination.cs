using System.Collections.Generic;
using System.Linq;
using Game.Cards.Enums;
using Game.Cards.Interfaces;
using Game.Combinations.Enums;

namespace Game.Combinations.Kinds
{
    public class StraightCombination : CombinationBase
    {
        public override bool Check(IEnumerable<ICard> hand, out IEnumerable<ICard> result)
        {
            var cardsInOrder = hand.OrderByDescending(a => a.Rank).ToList();

            var firstIsAce = cardsInOrder.First().Rank == ECardRank.Ace;
            if (firstIsAce)
            {
                var highStraight = hand.Where(IsHighStraightCard);
                var lowStraight = hand.Where(IsLowStraightCard);

                var isHighStraight = highStraight.Count() == 4;
                var isLowStraight = lowStraight.Count() == 4;

                if (isHighStraight)
                {
                    result = highStraight;
                    return true;
                }
                else if (isLowStraight)
                {
                    result = lowStraight;
                    return true;
                }

                bool IsHighStraightCard(ICard card)
                {
                    var isHigh = card.Rank 
                        is ECardRank.King 
                        or ECardRank.Queen
                        or ECardRank.Jack
                        or ECardRank.Ten;

                    return isHigh;
                }

                bool IsLowStraightCard(ICard card)
                {
                    var isLow = card.Rank 
                        is ECardRank.Two 
                        or ECardRank.Three 
                        or ECardRank.Four 
                        or ECardRank.Five;

                    return isLow;
                }
            }
            else
            {
                var doubles = hand
                    .GroupBy(card => card.Rank)
                    .Any(group => group.Count() > 1);

                if (!doubles)
                {
                    var isStraight = hand.Max(card => card.Rank) - hand.Min(card => card.Rank) == 4;
                    if (isStraight)
                    {
                        result = hand;
                        return true;
                    }
                }
            }

            result = null;
            return false;
        }

        public override ECombinationType Type => ECombinationType.Straight;
    }
}