using Game.Cards.Enums;

namespace Game.Cards.Interfaces
{
    public interface ICard
    {
        ECardSuit Suit
        {
            get;
        }

        ECardRank Rank
        {
            get;
        }
    }
}