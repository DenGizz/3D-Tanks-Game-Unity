using System;
using UnityEngine;

namespace Assets.Scripts.Domain
{
    public interface ITank : ITransformable
    {
        bool IsAlive { get; }

        event Action<ITank> OnDeath;

        void Revive();
        void EnableControl();
        void DisableControl();
    }
}
