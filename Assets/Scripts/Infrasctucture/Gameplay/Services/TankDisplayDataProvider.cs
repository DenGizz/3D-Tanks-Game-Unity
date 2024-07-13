using Assets.Scripts.Domain;
using Assets.Scripts.Tank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Infrasctucture.Gameplay.Services
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
