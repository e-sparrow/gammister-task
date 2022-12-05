using UnityEngine;
using Zenject;

namespace Game.Bets
{
    public class BetInstaller : MonoInstaller<BetInstaller>
    {
        [SerializeField] private BetScreen screen;
        
        public override void InstallBindings()
        {
            Container
                .BindInterfacesTo<BetService>()
                .AsSingle()
                .WithArguments(screen);
        }
    }
}