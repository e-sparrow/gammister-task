using Abstractions.Interfaces;
using UnityEngine;

namespace Abstractions
{
    public class PrefabFactory<T> : IFactory<T> 
        where T : MonoBehaviour
    {
        public PrefabFactory(T prefab, Transform root = null)
        {
            _prefab = prefab;
            _root = root;
        }

        private readonly T _prefab;
        private readonly Transform _root;

        public T Create()
        {
            var instance = Object.Instantiate(_prefab, _root);
            return instance;
        }
    }
}