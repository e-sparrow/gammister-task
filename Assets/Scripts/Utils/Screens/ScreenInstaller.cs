using UnityEngine;
using Zenject;

namespace Utils.Screens
{
    [CreateAssetMenu(menuName = "Installers/Screen", fileName = "ScreenInstaller")]
    public class ScreenInstaller : ScriptableObjectInstaller<ScreenInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesTo<ScreenService>()
                .AsSingle();
        }
    }
}