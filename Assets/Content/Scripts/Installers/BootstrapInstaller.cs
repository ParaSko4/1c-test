using TestProject.InputSystem;
using Zenject;

namespace TestProject.Installers
{
    public class BootstrapInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindInputHandler();
        }

        private void BindInputHandler()
        {
            Container.BindInterfacesAndSelfTo<PlayerInputHandler>().FromNew()
                .AsSingle()
                .NonLazy();
        }
    }
}