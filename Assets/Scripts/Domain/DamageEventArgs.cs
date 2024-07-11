using System;

public class DamageEventArgs : EventArgs
{
    public float DamageTaken { get; }

    public DamageEventArgs(float damageTaken)
    {
        DamageTaken = damageTaken;
    }
}