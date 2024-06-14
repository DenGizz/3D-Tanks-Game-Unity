using Assets.Scripts.StateMachines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;

namespace Assets.Scripts.Infrasctucture.Gameplay.Factories
{
    public class StateFactroy : IStateFactory
    {
        private readonly IInstantiator _instantiator;

        public StateFactroy(IInstantiator instantiator)
        {
            _instantiator = instantiator;
        }

        public TState CreateState<TState>(StateMachine stateMachine) where TState : IState
        {
            return _instantiator.Instantiate<TState>(new[] { stateMachine });
        }
    }
}
