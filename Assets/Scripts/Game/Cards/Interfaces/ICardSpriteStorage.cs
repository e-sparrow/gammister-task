using UnityEngine;

namespace Game.Cards.Interfaces
{
    public interface ICardSpriteStorage
    {
        Sprite GetSprite(ICard card);
    }
}