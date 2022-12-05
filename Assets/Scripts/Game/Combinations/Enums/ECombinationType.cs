namespace Game.Combinations.Enums
{
    public enum ECombinationType : byte
    {
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
    }
}