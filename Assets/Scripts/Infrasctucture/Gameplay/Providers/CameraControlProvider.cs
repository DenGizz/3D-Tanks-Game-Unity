using Assets.Scripts.Features.Camera;
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
