using Assets.Scripts.Domain;
using Assets.Scripts.Features;

namespace Assets.Scripts.Infrasctucture.Gameplay.Providers
{
    public interface ITankDisplayDataProvider
    {
        public void AddDisplayData(ITank tank, TankDisplayData displayData);
        public TankDisplayData GetDisplayData(ITank tank);
    }
}
