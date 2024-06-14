using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.StateMachines
{
    public class StateMachine
    {
        private readonly Dictionary<Type, IState> _states;
        private IState _currentState;

        public void AddState<TState>(TState state) where TState : IState
        {
            _states.Add(typeof(TState), state);
        }

        public void EnterState<TState>() where TState : IState
        {
            if (_currentState != null)
                _currentState.Exit();

            _currentState = _states[typeof(TState)];
            _currentState.Enter();
        }
    }
}
