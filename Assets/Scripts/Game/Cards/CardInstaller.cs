using UnityEngine;
using Zenject;

namespace Game.Cards
{
    public class CardInstaller : MonoInstaller<CardInstaller>
    {
        [SerializeField] private CardSpriteStorage spriteStorage;
        
        [SerializeField] private CardView prefab;
        [SerializeField] private Transform root;
        
        public override void InstallBindings()
        {
            Container
                .BindInterfacesTo<CardSpriteStorage>()
                .FromInstance(spriteStorage)
                .AsSingle();
            
            Container
                .BindInterfacesTo<CardViewFactory>()
                .AsSingle()
                .WithArguments(prefab, root);
        }
    }
}