using Assets.Scripts.Tank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Infrasctucture
{
    public interface ITanksProvider
    {
        IEnumerable<ITank> Tanks { get; }
        void AddTank(ITank tank);
    }
}
