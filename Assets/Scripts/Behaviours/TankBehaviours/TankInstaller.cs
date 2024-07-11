using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TankInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IDamagable>().FromComponentInHierarchy().AsSingle();
    }
}
