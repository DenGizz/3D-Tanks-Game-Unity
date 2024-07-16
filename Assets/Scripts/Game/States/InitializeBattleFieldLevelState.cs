using Assets.Scripts.Features.StateMachines;
using Assets.Scripts.Infrasctucture.Gameplay.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Game.States
{
    public class InitializeBattleFieldLevelState : IState
    {
        private readonly StateMachine _stateMachine;
        private readonly ICameraControlProvider _cameraControlProvider;
        private readonly ILevelSpawnPointsProvider _levelSpawnPointsProvider;

        public InitializeBattleFieldLevelState(StateMachine stateMachine, ICameraControlProvider cameraControlProvider, ILevelSpawnPointsProvider levelSpawnPointsProvider)
        {
            _stateMachine = stateMachine;
            _cameraControlProvider = cameraControlProvider;
            _levelSpawnPointsProvider = levelSpawnPointsProvider;
        }

        public void Enter()
        {
            _cameraControlProvider.Initialize();
            _levelSpawnPointsProvider.Initialize();
            _stateMachine.EnterState<CreateBattleSessionState>();
        }
    }
}
