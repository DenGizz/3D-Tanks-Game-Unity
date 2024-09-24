using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Domain
{
    public interface IShootable
    {
        public event Action OnFiered;
        public event Action OnStartCharge;

        float MinLaunchForce { get; }
        float MaxLaunchForce { get; }
        float MaxChargeTime { get; }
        float CurrentLaunchForce { get; }
    }
}
