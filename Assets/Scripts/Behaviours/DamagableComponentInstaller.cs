using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class DamagableComponentInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IDamagable>().FromComponentInHierarchy().AsSingle();
    }
}
