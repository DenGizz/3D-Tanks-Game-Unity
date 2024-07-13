using Assets.Scripts.Infrasctucture.Gameplay.Providers;
using Assets.Scripts.Tank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Infrasctucture.Gameplay.Services
{
    public class TankColorizer : ITankColorizer
    {
        private readonly ITanksGameObjectsRegistry _gameObjectsRegistry;

        public TankColorizer(ITanksGameObjectsRegistry gameObjectsRegistry)
        {
            _gameObjectsRegistry = gameObjectsRegistry;
        }

        public void ColorizeTank(ITank tank, Color color)
        {
            GameObject tankGameObject = _gameObjectsRegistry.GetTankGameObject(tank);

            MeshRenderer[] renderers = tankGameObject.GetComponentsInChildren<MeshRenderer>();

            foreach (MeshRenderer renderer in renderers)
                renderer.material.color = color;
        }
    }
}
