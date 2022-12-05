using System;
using Game.Cards.Enums;
using Game.Cards.Interfaces;
using UnityEngine;

namespace Game.Cards
{
    [Serializable]
    public class SerializableCardInfo : ICard
    {
        [field: SerializeField]
        public ECardSuit Suit
        {
            get;
            private set;
        }

        [field: SerializeField]
        public ECardRank Rank
        {
            get;
            private set;
        }
    }
}