using Assets.Scripts.Domain;
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
