using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Domain
{
    public class TankData
    {
        public float Health { get; set; }
        public float MaxHealth { get; }

        public TankData() : this(100, 100) { }

        public TankData(float health, float maxHealth)
        {
            Health = health;
            MaxHealth = maxHealth;
        }
    }
}
