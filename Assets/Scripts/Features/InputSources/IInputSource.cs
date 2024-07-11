using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInputSource
{
    float MovementInputValue { get; }
    float TurnInputValue { get; }
}
