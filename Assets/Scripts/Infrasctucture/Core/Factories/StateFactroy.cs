using Assets.Scripts.Features.StateMachines;
using Zenject;

namespace Assets.Scripts.Infrasctucture.Core.Factories
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
