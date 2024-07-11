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

        private DeviceAxesInputSource() { }

        public DeviceAxesInputSource(string movementAxisName, string turnAxisName)
        {
            _movementAxisName = movementAxisName;
            _turnAxisName = turnAxisName;
        }

        public float MovementInputValue => Input.GetAxis(_movementAxisName);
        public float TurnInputValue => Input.GetAxis(_turnAxisName);
    }
}
