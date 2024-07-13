using Assets.Scripts.Domain;
using UnityEngine;

namespace Assets.Scripts.Infrasctucture.Gameplay.Services
{
    public interface ITankColorizer
    {
        public void ColorizeTank(ITank tank, Color color);
    }
}
