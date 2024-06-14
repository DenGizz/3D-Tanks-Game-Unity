using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Infrasctucture.Core
{
    public class CoroutineRunner : ICoroutineRunner
    {
        private GameObject _coroutineRunnerGameObject;
        private CoroutineRunnerBehaviour _coroutineRunnerBehaviour;

        public void StartCoroutine(IEnumerator routine)
        {
            _coroutineRunnerBehaviour.StartCoroutine(routine);
        }

        public void StopCoroutine(IEnumerator routine)
        {
            _coroutineRunnerBehaviour.StopCoroutine(routine);
        }

        public void Initialize()
        {
            _coroutineRunnerGameObject = new GameObject("CoroutineRunner");
            _coroutineRunnerBehaviour = _coroutineRunnerGameObject.AddComponent<CoroutineRunnerBehaviour>();
            MonoBehaviour.DontDestroyOnLoad(_coroutineRunnerGameObject);
        }
    }
}
