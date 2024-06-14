using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Infrasctucture
{
    public interface ITankFactory 
    {
        Tank CreateTank(Transform spawnPoint, Color color, int playerNumber);
    }
}
