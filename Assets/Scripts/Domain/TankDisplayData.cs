using Assets.Scripts.Tank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Domain
{
    public class TankDisplayData
    {
        public string Name { get; }
        public Color Color { get; }

        public TankDisplayData(string name, Color color)
        {
            Name = name;
            Color = color;
        }
    }
}
