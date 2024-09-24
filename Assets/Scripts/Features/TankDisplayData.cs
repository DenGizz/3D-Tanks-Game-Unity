using UnityEngine;

namespace Assets.Scripts.Features
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
