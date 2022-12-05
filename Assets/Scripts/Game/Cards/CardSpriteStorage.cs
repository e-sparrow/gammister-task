using System;
using System.Collections.Generic;
using System.Linq;
using Game.Cards.Interfaces;
using UnityEngine;

namespace Game.Cards
{
    [CreateAssetMenu(menuName = "Storages/Card Sprites", fileName = "CardSpriteStorage")]
    public class CardSpriteStorage : ScriptableObject, ICardSpriteStorage
    {
        [SerializeField] private List<CardSprite> sprites;

        public Sprite GetSprite(ICard card)
        {
            var result = sprites
                .FirstOrDefault(IsFit)
                .Sprite;

            return result;
            
            bool IsFit(CardSprite item)
            {
                var isFitBySuit = item.Card.Suit == card.Suit;
                var isFitByRank = item.Card.Rank == card.Rank;

                var isFit = isFitBySuit && isFitByRank;
                return isFit;
            }
        }

        [Serializable]
        private struct CardSprite
        {
            [field: SerializeField]
            public SerializableCardInfo Card
            {
                get;
                private set;
            }

            [field: SerializeField]
            public Sprite Sprite
            {
                get;
                private set;
            }
        }
    }
}