using Assets.Scripts.Camera;

namespace Assets.Scripts.Infrasctucture.Gameplay.Providers
{
    public interface ICameraControlProvider
    {
        CameraControl CameraControl { get; }

        void Initialize();
    }
}
