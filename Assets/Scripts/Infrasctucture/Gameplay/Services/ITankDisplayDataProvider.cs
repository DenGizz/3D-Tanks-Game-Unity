using Assets.Scripts.Domain;
using Assets.Scripts.Tank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Infrasctucture.Gameplay.Services
{
    public interface ITankDisplayDataProvider
    {
        public void AddDisplayData(ITank tank, TankDisplayData displayData);
        public TankDisplayData GetDisplayData(ITank tank);
    }
}
