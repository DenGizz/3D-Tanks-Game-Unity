using Assets.Scripts.Configs;
using Assets.Scripts.Features.InputSources;

namespace Assets.Scripts.Infrasctucture.Gameplay.Factories
{
    public class InputSourceFactory : IInputSourceFactory
    {
        public IInputSource CreateLocalInputSource(LocalDeviceInputSchemeConfig config)
        {
            return new LocalDeviceInputSource(config);
        }
    }
}
