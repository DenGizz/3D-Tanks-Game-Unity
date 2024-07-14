using System;
using Assets.Scripts.Domain;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Behaviours
{
    public class DamagableBehaviour : MonoBehaviour, IDamagable, IInitializable
    {
        public float MaxHealth { get; private set; } = 100f;          
        public bool IsAlive => _isAlive;

        public event Action<IDamagable> OnDeath;
        public event EventHandler<DamageEventArgs> OnDamaged;
        public event Action<float> OnHealed;

        public float Health { get; private set; }  
        private bool _isAlive;

        [Inject]
        public void Initialize()
        {
            Health = MaxHealth;
            _isAlive = true;
        }

        public void Revive()
        {
            Health = MaxHealth;
            OnHealed?.Invoke(Health);
            _isAlive = true;
        }
    
        public void TakeDamage(float amount)
        {
            // Adjust the tank's current health, update the UI based on the new health and check whether or not the tank is dead.
            Health -= amount;

            OnDamaged?.Invoke(this, new DamageEventArgs(amount));

            if (Health <=0f && _isAlive)
                Death();
        }

        private void Death()
        {
            _isAlive = false;
            gameObject.SetActive(false);

            OnDeath?.Invoke(this);
        }
    }
}