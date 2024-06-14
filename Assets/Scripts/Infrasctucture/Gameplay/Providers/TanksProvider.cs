using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Infrasctucture
{
    public class TanksProvider : ITanksProvider
    {
        public IEnumerable<TankBehaviour> Tanks => _tanks;

        private readonly List<TankBehaviour> _tanks = new List<TankBehaviour>();  

        public void AddTank(TankBehaviour tank)
        {
            _tanks.Add(tank);
        }
    }
}
