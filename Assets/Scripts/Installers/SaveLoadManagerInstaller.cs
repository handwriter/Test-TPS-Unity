using DefaultNamespace;
using Zenject;

namespace Installers
{
    public class SaveLoadManagerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindSaveLoadManager();
        }

        private void BindSaveLoadManager()
        {
            Container
                .Bind<ISaveLoadManager>()
                .To<SaveLoadManager>()
                .AsSingle()
                .NonLazy();
        }
    }
}