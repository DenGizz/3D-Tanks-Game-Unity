using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Infrasctucture
{
    public interface ITanksProvider
    {
        IEnumerable<TankBehaviour> Tanks { get; }
        void AddTank(TankBehaviour tank);
    }
}
