using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Infrasctucture.Gameplay.Providers
{
    public class CameraControlProvider : ICameraControlProvider
    {
        public CameraControl CameraControl { get; private set; }

        public void Initialize()
        {
            CameraControl = GameObject.FindFirstObjectByType<CameraControl>();
        }
    }
}
