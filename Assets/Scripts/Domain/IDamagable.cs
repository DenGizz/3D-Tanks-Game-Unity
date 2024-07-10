using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable
{
    bool IsAlive { get; }
    float HealthPoints { get; }
    void TakeDamage(float amount);
    event Action OnDeath;
}
