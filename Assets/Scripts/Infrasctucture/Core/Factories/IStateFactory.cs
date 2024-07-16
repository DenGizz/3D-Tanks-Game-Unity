using Assets.Scripts.Features.StateMachines;

namespace Assets.Scripts.Infrasctucture.Core.Factories
{
    public interface IStateFactory
    {
        TState CreateState<TState>(StateMachine stateMachine) where TState : IState;
    }
}
