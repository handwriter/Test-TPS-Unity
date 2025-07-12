using DefaultNamespace;
using Zenject;

namespace Installers
{
    public class AdsManagerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindAdsManager();
        }

        private void BindAdsManager()
        {
            Container
                .Bind<IAdsManager>()
                .To<GPAdsManager>()
                .AsSingle()
                .NonLazy();
        }
    }
}