using Assets.Scripts.Configs;
using Assets.Scripts.Features.InputSources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Infrasctucture.Gameplay.Factories
{
    public class InputSourceFactory : IInputSourceFactory
    {
        public IInputSource CreateLocalInputSource(LocalInputSchemeConfiguration config)
        {
            return new LocalDeviceInputSource(config);
        }
    }
}
