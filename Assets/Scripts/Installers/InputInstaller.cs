using UnityEngine;
using Zenject;

public class InputInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindInputManager();
    }

    private void BindInputManager()
    {
        Debug.Log("BIND");
        Container
            .Bind<IInputManager>()
            .To<DesktopInputManager>()
            .AsSingle()
            .NonLazy();
    }
}