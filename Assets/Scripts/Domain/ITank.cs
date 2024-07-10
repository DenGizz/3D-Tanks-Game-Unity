using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Tank
{
    public interface ITank
    {
        Color PlayerColor { get;  }
        int PlayerNumber { get; }
        bool IsAlive { get; }
        Vector3 Position { get; }

        void Revive();
        void SetPosition(Vector3 position);
        void SetRotation(Quaternion rotation);
        void EnableControl();
        void DisableControl();
    }
}
