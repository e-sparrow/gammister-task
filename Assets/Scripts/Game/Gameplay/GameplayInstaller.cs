using Zenject;

namespace Game.Gameplay
{
    public class GameplayInstaller : MonoInstaller<GameplayInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesTo<GameplayPresenter>()
                .AsSingle()
                .NonLazy();
        }
    }
}