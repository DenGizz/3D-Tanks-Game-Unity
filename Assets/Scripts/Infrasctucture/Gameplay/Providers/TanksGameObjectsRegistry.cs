﻿using Assets.Scripts.Tank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Infrasctucture.Gameplay.Providers
{
    public class TanksGameObjectsRegistry : ITanksGameObjectsRegistry
    {
        private readonly Dictionary<ITank, GameObject> _tankGameObjectMap = new();

        public GameObject GetTankGameObject(ITank tank)
        {
            return _tankGameObjectMap[tank];
        }

        public void RegisterGameObject(ITank tank, GameObject gameObject)
        {
            _tankGameObjectMap.Add(tank, gameObject);
        }

        public void UnregisterGameObject(ITank tank)
        {
            _tankGameObjectMap.Remove(tank);
        }
    }
}
