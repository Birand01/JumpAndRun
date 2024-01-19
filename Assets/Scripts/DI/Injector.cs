using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Injector : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<GroundInteraction>().FromComponentInHierarchy().AsSingle().NonLazy();
        Container.Bind<GameEvents>().FromComponentInHierarchy().AsSingle().NonLazy();
        Container.Bind<DistanceManager>().FromComponentInHierarchy().AsSingle().NonLazy();
        
    }
}
