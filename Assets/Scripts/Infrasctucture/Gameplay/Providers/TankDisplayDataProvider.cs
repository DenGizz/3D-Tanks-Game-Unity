using System.Collections.Generic;
using Assets.Scripts.Domain;
using Assets.Scripts.Features;

namespace Assets.Scripts.Infrasctucture.Gameplay.Providers
{
    public class TankDisplayDataProvider : ITankDisplayDataProvider
    {
        private readonly Dictionary<ITank, TankDisplayData> _tankToDataMap = new();

        public void AddDisplayData(ITank tank, TankDisplayData displayData)
        {
            _tankToDataMap.Add(tank, displayData);
        }

        public TankDisplayData GetDisplayData(ITank tank)
        {
            return _tankToDataMap[tank];
        }
    }
}
