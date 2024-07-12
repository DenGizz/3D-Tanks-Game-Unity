using Assets.Scripts.Infrasctucture.Gameplay.Factories;
using Assets.Scripts.Infrasctucture.Gameplay.GameplayStateMachine.States;
using Assets.Scripts.Infrasctucture.Gameplay.States;
using Assets.Scripts.StateMachines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            _stateMachine.AddState(_stateFactory.CreateState<StartGameState>(_stateMachine));
            _stateMachine.AddState(_stateFactory.CreateState<CreateBattleSessionState>(_stateMachine));
            _stateMachine.AddState(_stateFactory.CreateState<PrepareNewRoundState>(_stateMachine));
            _stateMachine.AddState(_stateFactory.CreateState<PerformRoundState>(_stateMachine));
            _stateMachine.AddState(_stateFactory.CreateState<EndRoundState>(_stateMachine));
            _stateMachine.AddState(_stateFactory.CreateState<EndGameState>(_stateMachine));

            
        }

        public void Start()
        {
            _stateMachine.EnterState<StartGameState>();
        }
    }
}
