using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Domain
{
    public interface IShell : ITransformable
    {
        void Lunch(Vector3 direction, float force);
    }
}
