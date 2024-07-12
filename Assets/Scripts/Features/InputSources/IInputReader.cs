using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Features.InputSources
{
    public interface IInputReader
    {
        void SetInputSource(IInputSource inputSource);
    }
}
