using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Infrasctucture.Core.Services.CoroutineRunners
{
    public class CoroutineRunner : ICoroutineRunner
    {
        private GameObject _coroutineRunnerGameObject;
        private CoroutineRunnerBehaviour _coroutineRunnerBehaviour;

        public Coroutine StartCoroutine(IEnumerator routine)
        {
            return _coroutineRunnerBehaviour.StartCoroutine(routine);
        }

        public void StopCoroutine(Coroutine routine)
        {
            _coroutineRunnerBehaviour.StopCoroutine(routine);
        }

        public void Initialize()
        {
            _coroutineRunnerGameObject = new GameObject("CoroutineRunner");
            _coroutineRunnerBehaviour = _coroutineRunnerGameObject.AddComponent<CoroutineRunnerBehaviour>();
            MonoBehaviour.DontDestroyOnLoad(_coroutineRunnerGameObject);
        }

        public void DoAfterDelay(Action action, float delay)
        {
            StartCoroutine(DoAfterDelayCoroutine(action, delay));
        }

        private IEnumerator DoAfterDelayCoroutine(Action action, float delay)
        {
            yield return new WaitForSeconds(delay);
            action.Invoke();
        }
    }
}
