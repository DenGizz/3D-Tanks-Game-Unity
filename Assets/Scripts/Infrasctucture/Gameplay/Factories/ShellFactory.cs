using Assets.Scripts.Domain;
using Assets.Scripts.Infrasctucture.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Infrasctucture.Core.Providers;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrasctucture.Gameplay.Factories
{
    public class ShellFactory : IShellFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly IAssetsProvider _assetsProvider;

        public ShellFactory(IInstantiator instantiator, IAssetsProvider assetsProvider)
        {
            _instantiator = instantiator;
            _assetsProvider = assetsProvider;
        }

        public IShell CreateShell(Vector3 position, Quaternion rotation)
        {
            GameObject shellPrefab = _assetsProvider.GetShellPrefab();
            GameObject shellInstance = _instantiator.InstantiatePrefab(shellPrefab);
            IShell shell = new ShellController(shellInstance);
            shell.Position = position;
            shell.Rotation = rotation;
            return shell;
        }
    }
}
