using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Infrasctucture.Core
{
    public interface ICoroutineRunner
    {
        void StartCoroutine(IEnumerator routine);
        void StopCoroutine(IEnumerator routine);

        void Initialize();
    }
}
