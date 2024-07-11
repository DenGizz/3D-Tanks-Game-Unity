using Assets.Scripts.Infrasctucture;
using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class TankHealth : MonoBehaviour, IInitializable
{
    public float MaxHealth { get; set; } = 100f;          
    public bool IsAlive => !m_Dead;

    public event Action OnDeath;
    public event EventHandler<DamageEventArgs> OnDamaged;

    public float CurrentHealth { get; private set; }  
    private bool m_Dead;

    [Inject]
    public void Initialize()
    {
        CurrentHealth = MaxHealth;
    }

    public void Revive()
    {
        CurrentHealth = MaxHealth;
        m_Dead = false;
    }
    
    public void TakeDamage(float amount)
    {
        // Adjust the tank's current health, update the UI based on the new health and check whether or not the tank is dead.
        CurrentHealth -= amount;

        OnDamaged?.Invoke(this, new DamageEventArgs(amount));

        if (CurrentHealth <=0f && !m_Dead)
            Death();
    }

    private void Death()
    {
        m_Dead = true;
        gameObject.SetActive(false);

        OnDeath?.Invoke();
    }
}