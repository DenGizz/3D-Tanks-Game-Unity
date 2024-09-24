using System;

namespace Assets.Scripts.Domain
{
    public interface IDamagable
    {
        bool IsAlive { get; }
        float MaxHealth { get; }
        float Health { get; }
        void TakeDamage(float amount);
        event Action<IDamagable> OnDeath;
        event EventHandler<DamageEventArgs> OnDamaged;
        event Action<float> OnHealed;
        void Revive();
    }
}
