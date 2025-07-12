using GamePush;
using UnityEngine;
using Zenject;

public class InputInstaller : MonoInstaller
{
    [SerializeField] private InputConfig _config;
    [SerializeField] private bool _isDebug;
    [SerializeField] private bool _isMobile;
    public override void InstallBindings()
    {
        BindInputManager();
    }

    private void BindInputManager()
    {
        bool isMobile = GP_Device.IsMobile();
        if (_isDebug) isMobile = _isMobile;
        if (isMobile)
        {
            Container
                .Bind<IInputManager>()
                .To<MobileInputManager>()
                .AsSingle()
                .WithArguments(_config)
                .NonLazy();
            
        }
        else
        {
            Container
                .Bind<IInputManager>()
                .To<DesktopInputManager>()
                .AsSingle()
                .NonLazy();
        }
    }
}