using Assets.Scripts.Configs;
using Assets.Scripts.Features.InputSources;

namespace Assets.Scripts.Infrasctucture.Gameplay.Factories
{
    public interface IInputSourceFactory
    {
        IInputSource CreateLocalInputSource(LocalDeviceInputSchemeConfig config);
    }
}
