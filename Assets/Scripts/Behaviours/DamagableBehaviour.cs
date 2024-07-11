using Assets.Scripts.Infrasctucture;
using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class DamagableBehaviour : MonoBehaviour, IDamagable
{
    public float MaxHealthPoints { get; private set; } = 100f;          
    public bool IsAlive => _isAlive;

    public event Action OnDeath;
    public event EventHandler<DamageEventArgs> OnDamaged;

    public float HealthPoints { get; private set; }  
    private bool _isAlive;

    private void Awake()
    {
        HealthPoints = MaxHealthPoints;
    }

    public void Revive()
    {
        HealthPoints = MaxHealthPoints;
        _isAlive = true;
    }
    
    public void TakeDamage(float amount)
    {
        // Adjust the tank's current health, update the UI based on the new health and check whether or not the tank is dead.
        HealthPoints -= amount;

        OnDamaged?.Invoke(this, new DamageEventArgs(amount));

        if (HealthPoints <=0f && _isAlive)
            Death();
    }

    private void Death()
    {
        _isAlive = false;
        gameObject.SetActive(false);

        OnDeath?.Invoke();
    }
}