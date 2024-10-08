﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Domain
{
    public interface ITransformable
    {
        Vector3 Position { get; set; }
        Quaternion Rotation { get; set; }
    }
}
