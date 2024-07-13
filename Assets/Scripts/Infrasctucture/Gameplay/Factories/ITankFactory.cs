using Assets.Scripts.Tank;
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
        ITank CreateTank(Vector3 position,Quaternion rotation, Color color);
    }
}
