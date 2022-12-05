using Game.Cards.Enums;
using Game.Cards.Interfaces;

namespace Game.Cards
{
    public class Card : ICard
    {
        public Card(ECardSuit suit, ECardRank rank)
        {
            Suit = suit;
            Rank = rank;
        }

        public ECardSuit Suit
        {
            get;
        }

        public ECardRank Rank
        {
            get;
        }
    }
}