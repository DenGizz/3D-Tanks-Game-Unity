using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Infrasctucture.Gameplay.Providers
{
    public interface ICameraControlProvider
    {
        CameraControl CameraControl { get; }

        void Initialize();
    }
}
