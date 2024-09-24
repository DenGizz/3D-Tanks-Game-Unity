using Assets.Scripts.Domain;
using UnityEngine;

namespace Assets.Scripts.Infrasctucture.Gameplay.Factories
{
    public interface ITankFactory 
    {
        ITank CreateTank(Vector3 position,Quaternion rotation);
    }
}
