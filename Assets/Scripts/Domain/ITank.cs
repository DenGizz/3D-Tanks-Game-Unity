using Assets.Scripts.Features.InputSources;
using System;
using UnityEngine;

namespace Assets.Scripts.Domain
{
    public interface ITank : ITransformable, IDamagable
    {
        void SetInputSource(IInputSource inputSource);
        void EnableControl();
        void DisableControl();
    }
}
