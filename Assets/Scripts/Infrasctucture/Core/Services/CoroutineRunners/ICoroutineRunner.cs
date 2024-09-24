using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Infrasctucture.Core.Services.CoroutineRunners
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator routine);
        void StopCoroutine(Coroutine routine);
        void DoAfterDelay(Action action, float delay);

        void Initialize();
    }
}
