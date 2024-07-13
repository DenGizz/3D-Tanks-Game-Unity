using System;

namespace Assets.Scripts.Domain
{
    public interface IDamagable
    {
        bool IsAlive { get; }
        float MaxHealthPoints { get; }
        float HealthPoints { get; }
        void TakeDamage(float amount);
        event Action OnDeath;
        event EventHandler<DamageEventArgs> OnDamaged;
        event Action<float> OnHealed;
    }
}
