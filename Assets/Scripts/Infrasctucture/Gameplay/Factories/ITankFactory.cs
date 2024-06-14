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
        TankBehaviour CreateTank(Vector3 position,Quaternion rotation, Color color, int playerNumber);
    }
}
