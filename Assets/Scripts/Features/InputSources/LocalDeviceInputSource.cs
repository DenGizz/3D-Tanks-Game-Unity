using Assets.Scripts.Configs;
using UnityEngine;

namespace Assets.Scripts.Features.InputSources
{
    public class LocalDeviceInputSource : IInputSource
    {
        private readonly string _movementAxisName;
        private readonly string _turnAxisName;

        private readonly string _fireButtonName;

        private LocalDeviceInputSource() { }

        public LocalDeviceInputSource(string movementAxisName, string turnAxisName, string fireButtonName)
        {
            _movementAxisName = movementAxisName;
            _turnAxisName = turnAxisName;
            _fireButtonName = fireButtonName;
        }

        public LocalDeviceInputSource(LocalInputSchemeConfiguration config) 
            : this (config.MoveAxisName, config.TurnAxisName, config.FireButtonName) { }

        public float MovementInputValue => Input.GetAxis(_movementAxisName);
        public float TurnInputValue => Input.GetAxis(_turnAxisName);

        public bool GetFireButtonDown => Input.GetButtonDown(_fireButtonName);
        public bool GetFireButtonUp => Input.GetButtonUp(_fireButtonName);
        public bool GetFireButton => Input.GetButton(_fireButtonName);
    }
}
