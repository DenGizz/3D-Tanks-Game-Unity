using Assets.Scripts.Infrasctucture.Core.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrasctucture.Gameplay.Factories
{
    public class VFXFactory : IVFXFactory
    {
        private readonly IAssetsProvider _assetsProvider;
        private readonly IInstantiator _instantiator;

        public VFXFactory(IAssetsProvider assetsProvider, IInstantiator instantiator)
        {
            _assetsProvider = assetsProvider;
            _instantiator = instantiator;
        }

        public VFXBehaviour CreateShellExplosion(Vector3 position)
        {
            GameObject vfxPrefab = _assetsProvider.GetShellExplosionPrefab();
            GameObject vfx = _instantiator.InstantiatePrefab(vfxPrefab);
            vfx.transform.position = position;
            return vfx.GetComponent<VFXBehaviour>();
        }

        public VFXBehaviour CreateTankExplosion(Vector3 position)
        {
            GameObject vfxPrefab = _assetsProvider.GetTankExplosionPrefab();
            GameObject vfx = _instantiator.InstantiatePrefab(vfxPrefab);
            vfx.transform.position = position;
            return vfx.GetComponent<VFXBehaviour>();
        }
    }
}
