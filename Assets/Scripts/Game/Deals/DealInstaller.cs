using UnityEngine;
using Zenject;

namespace Game.Deals
{
    public class DealInstaller : MonoInstaller<DealInstaller>
    {
        [SerializeField] private DealConfiguration configuration;
        [SerializeField] private DealSettings settings;
        
        [SerializeField] private DealScreen screen;
        
        public override void InstallBindings()
        {
            Container
                .BindInterfacesTo<DealConfiguration>()
                .FromInstance(configuration)
                .AsSingle();
            
            Container
                .BindInterfacesTo<DealSettings>()
                .FromInstance(settings)
                .AsSingle();
            
            Container
                .BindInterfacesTo<DealService>()
                .AsSingle()
                .WithArguments(screen);
        }
    }
}