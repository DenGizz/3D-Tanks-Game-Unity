using System;
using System.Collections.Generic;

namespace Assets.Scripts.Features.StateMachines
{
    public class StateMachine
    {
        private readonly Dictionary<Type, IState> _states;
        private IState _currentState;

        public StateMachine()
        {
            _states = new Dictionary<Type, IState>();
        }

        public void AddState<TState>(TState state) where TState : IState
        {
            _states.Add(typeof(TState), state);
        }

        public void EnterState<TState>() where TState : IState
        {
            if (_currentState != null && _currentState is IExitableState exitableState)
                exitableState.Exit();

            _currentState = _states[typeof(TState)];
            _currentState.Enter();
        }
    }
}
