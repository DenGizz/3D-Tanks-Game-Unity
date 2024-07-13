using System;
using UnityEngine;

namespace Assets.Scripts.Domain
{
    public interface ITank
    {
        bool IsAlive { get; }
        Vector3 Position { get; }

        event Action<ITank> OnDeath;

        void Revive();
        void SetPosition(Vector3 position);
        void SetRotation(Quaternion rotation);
        void EnableControl();
        void DisableControl();
    }
}
