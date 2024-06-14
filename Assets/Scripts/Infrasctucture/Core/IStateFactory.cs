using Assets.Scripts.StateMachines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Infrasctucture.Gameplay.Factories
{
    public interface IStateFactory
    {
        TState CreateState<TState>(StateMachine stateMachine) where TState : IState;
    }
}
