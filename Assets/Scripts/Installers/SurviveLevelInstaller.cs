using DefaultNamespace;
using UnityEngine;
using Zenject;

public class SurviveLevelInstaller : MonoInstaller
{
    [SerializeField] private GemsManager _gemsManager;
    
    public override void InstallBindings()
    {
        BindGemsManager();
    }

    private void BindGemsManager()
    {
        Container
            .Bind<GemsManager>()
            .FromInstance(_gemsManager);
    }
}