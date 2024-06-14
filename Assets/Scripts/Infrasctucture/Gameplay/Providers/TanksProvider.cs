using Assets.Scripts.Tank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Infrasctucture
{
    public class TanksProvider : ITanksProvider
    {
        public IEnumerable<ITank> Tanks => _tanks;

        private readonly List<ITank> _tanks = new List<ITank>();  

        public void AddTank(ITank tank)
        {
            _tanks.Add(tank);
        }
    }
}
