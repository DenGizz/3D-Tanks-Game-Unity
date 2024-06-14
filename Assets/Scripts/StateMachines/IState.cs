﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.StateMachines
{
    public interface IState
    {
        void Enter();
        void Exit();
    }
}
