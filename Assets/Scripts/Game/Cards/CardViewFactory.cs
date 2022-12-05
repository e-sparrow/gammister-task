using Game.Cards.Interfaces;
using UnityEngine;
using Zenject;

namespace Game.Cards
{
    public class CardViewFactory : IFactory<ICardView>
    {
        public CardViewFactory(CardView prefab, Transform transform)
        {
            _prefab = prefab;
            _transform = transform;
        }

        private readonly CardView _prefab;
        private readonly Transform _transform;
        
        public ICardView Create()
        {
            var value = Object.Instantiate(_prefab, _transform);
            return value;
        }
    }
}