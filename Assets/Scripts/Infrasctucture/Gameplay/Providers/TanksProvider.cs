using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Infrasctucture
{
    public class TanksProvider : ITanksProvider
    {
        public IEnumerable<Tank> Tanks => _tanks;

        private readonly List<Tank> _tanks = new List<Tank>();  

        public void AddTank(Tank tank)
        {
            _tanks.Add(tank);
        }
    }
}
