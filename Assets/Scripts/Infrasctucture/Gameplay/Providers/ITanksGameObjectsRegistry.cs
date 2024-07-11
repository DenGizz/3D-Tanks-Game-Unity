using Assets.Scripts.Tank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Infrasctucture.Gameplay.Providers
{
    public interface ITanksGameObjectsRegistry
    {
        void RegisterGameObject(ITank tank, GameObject gameObject);
        void UnregisterGameObject(ITank tank);
        GameObject GetTankGameObject(ITank tank);
    }
}
