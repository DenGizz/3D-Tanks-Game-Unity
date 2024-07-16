using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Infrasctucture.Gameplay.Factories
{
    public interface IVFXFactory
    {
        VFXBehaviour CreateTankExplosion(Vector3 position);
        VFXBehaviour CreateShellExplosion(Vector3 position);
    }
}
