using System;

namespace Assets.Scripts.Domain
{
    public class DamageEventArgs : EventArgs
    {
        public float DamageTaken { get; }

        public DamageEventArgs(float damageTaken)
        {
            DamageTaken = damageTaken;
        }
    }
}