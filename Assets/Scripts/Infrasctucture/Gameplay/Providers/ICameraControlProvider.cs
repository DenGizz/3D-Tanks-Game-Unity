using Assets.Scripts.Features.Camera;

namespace Assets.Scripts.Infrasctucture.Gameplay.Providers
{
    public interface ICameraControlProvider
    {
        CameraControl CameraControl { get; }

        void Initialize();
    }
}
