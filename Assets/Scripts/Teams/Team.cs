using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Teams
{
    public class Team
    {
        public IEnumerable<Tank> Tanks => _tanks;
        public Color TeamColor { get;  }

        private readonly List<Tank> _tanks;

        public Team(Color teamColor)
        {
            TeamColor = teamColor;
            _tanks = new List<Tank>();
        }

        public void AddTank(Tank tank)
        {
            _tanks.Add(tank);
        }
    }
}
