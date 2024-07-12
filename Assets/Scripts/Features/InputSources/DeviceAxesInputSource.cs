using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Features.InputSources
{
    public class DeviceAxesInputSource : IInputSource
    {
        private readonly string _movementAxisName;
        private readonly string _turnAxisName;

        private readonly string _fireButtonName;

        private DeviceAxesInputSource() { }

        public DeviceAxesInputSource(string movementAxisName, string turnAxisName, string fireButtonName)
        {
            _movementAxisName = movementAxisName;
            _turnAxisName = turnAxisName;
            _fireButtonName = fireButtonName;
        }

        public float MovementInputValue => Input.GetAxis(_movementAxisName);
        public float TurnInputValue => Input.GetAxis(_turnAxisName);

        public bool GetFireButtonDown => Input.GetButtonDown(_fireButtonName);
        public bool GetFireButtonUp => Input.GetButtonUp(_fireButtonName);
        public bool GetFireButton => Input.GetButton(_fireButtonName);
    }
}
