using Assets.Scripts.Domain;
using Assets.Scripts.Features.InputSources;

namespace Assets.Scripts.Infrasctucture.Gameplay.Services
{
    public interface IInputSourceServiceAssing
    {
        void AssignInputSource(ITank tank, IInputSource inputSource);
    }
}
