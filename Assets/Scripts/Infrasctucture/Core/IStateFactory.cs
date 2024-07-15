using Assets.Scripts.Features.StateMachines;

namespace Assets.Scripts.Infrasctucture.Core
{
    public interface IStateFactory
    {
        TState CreateState<TState>(StateMachine stateMachine) where TState : IState;
    }
}
