using Assets.Scripts.Features.StateMachines;
using Assets.Scripts.Game.States;
using Assets.Scripts.Infrasctucture.Core;
using Assets.Scripts.Infrasctucture.Core.Factories;

namespace Assets.Scripts.Game
{
    public class Game
    {
        private readonly IStateFactory _stateFactory;
        private readonly StateMachine _stateMachine;

        public Game(IStateFactory stateFactory)
        {
            _stateFactory = stateFactory;
            _stateMachine = new StateMachine();
            _stateMachine.AddState(_stateFactory.CreateState<InitializeGameState>(_stateMachine));
            _stateMachine.AddState(_stateFactory.CreateState<LoadBattleFieldSceneState>(_stateMachine));
            _stateMachine.AddState(_stateFactory.CreateState<InitializeBattleFieldLevelState>(_stateMachine));
            _stateMachine.AddState(_stateFactory.CreateState<CreateBattleSessionState>(_stateMachine));
            _stateMachine.AddState(_stateFactory.CreateState<PrepareNewRoundState>(_stateMachine));
            _stateMachine.AddState(_stateFactory.CreateState<PerformRoundState>(_stateMachine));
            _stateMachine.AddState(_stateFactory.CreateState<EndRoundState>(_stateMachine));
            _stateMachine.AddState(_stateFactory.CreateState<EndGameState>(_stateMachine));

            
        }

        public void Start()
        {
            _stateMachine.EnterState<InitializeGameState>();
        }
    }
}
