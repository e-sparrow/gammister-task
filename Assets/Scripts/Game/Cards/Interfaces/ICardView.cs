using System;
using UnityEngine;

namespace Game.Cards.Interfaces
{
    public interface ICardView : IDisposable
    {
        event Action OnClick;

        void SetSprite(Sprite sprite);
        void SetHighlighted(bool isHighlighted);
    }
}