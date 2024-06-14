using Assets.Scripts.StateMachines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Infrasctucture.Gameplay.States
{
    public class CreateRoundState : IState
    {
        private readonly GameplayStateMachine _gameplayStateMachine;
        private readonly ITanksProvider _tanksProvider;
        private readonly ITankFactory _tankFactory;

        public CreateRoundState(GameplayStateMachine gameplayStateMachine, ITanksProvider tanksProvider, ITankFactory tankFactory)
        {
            _gameplayStateMachine = gameplayStateMachine;
            _tanksProvider = tanksProvider;
            _tankFactory = tankFactory;
        }

        public void Enter()
        {
            throw new NotImplementedException();
        }

        public void Exit()
        {
            throw new NotImplementedException();
        }
    }
}
