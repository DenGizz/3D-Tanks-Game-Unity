using System.Linq;
using Assets.Scripts.Configs;
using Assets.Scripts.Domain;
using Assets.Scripts.Features.StateMachines;
using Assets.Scripts.Infrasctucture.Core;
using Assets.Scripts.Infrasctucture.Core.Services;
using Assets.Scripts.Infrasctucture.Core.Services.CoroutineRunners;
using Assets.Scripts.Infrasctucture.Gameplay.Providers;
using Assets.Scripts.Infrasctucture.Ui;
using UnityEngine;

namespace Assets.Scripts.Game.States
{
    public class PrepareNewRoundState : IState
    {
        private readonly StateMachine _stateMachine;
        private readonly IBattleProvider _battleProvider;
        private readonly ICameraControlProvider _cameraControlProvider;
        private readonly IUiProvider _uiProvider;
        private readonly ILevelSpawnPointsProvider _levelSpawnPointsProvider;
        private readonly IStaticDataService _staticDataService;
        private readonly ICoroutineRunner _coroutineRunner;

        private Battle _battle;

        public PrepareNewRoundState(StateMachine stateMachine, 
            IBattleProvider battleProvider, 
            ICameraControlProvider cameraControlProvider, IUiProvider uiProvider,
            ILevelSpawnPointsProvider levelSpawnPointsProvider, IStaticDataService staticDataService, 
            ICoroutineRunner coroutineRunner)
        {
            _stateMachine = stateMachine;
            _battleProvider = battleProvider;
            _cameraControlProvider = cameraControlProvider;
            _uiProvider = uiProvider;
            _levelSpawnPointsProvider = levelSpawnPointsProvider;
            _staticDataService = staticDataService;
            _coroutineRunner = coroutineRunner;
        }

        public void Enter()
        {
            _battle = _battleProvider.CurrentBattle;

            _battle.StartNewRound();

            ResetAllTanks();
            DisableTankControl();

            _cameraControlProvider.CameraControl.SetTargets(new ITank[] { _battle.Tank1, _battle.Tank2 });
            _cameraControlProvider.CameraControl.SetToStartPositionAndSize();
            _uiProvider.MessagesUi.ShowRoundStartText(_battleProvider.CurrentBattle.CurrentRound);

            BattleRulesConfig battleRulesConfig = _staticDataService.BattleSessionConfig;

            _coroutineRunner.DoAfterDelay(
                () => _stateMachine.EnterState<PerformRoundState>(), battleRulesConfig.StartDelay);
        }

        private void ResetAllTanks()
        {
            ResetTank(_battle.Tank1,_levelSpawnPointsProvider.SpawnPoints.ElementAt(0));
            ResetTank(_battle.Tank2, _levelSpawnPointsProvider.SpawnPoints.ElementAt(1));
        }

        private void ResetTank(ITank tank, Transform spawnPoint)
        {
            tank.Position = spawnPoint.position;
            tank.Rotation = spawnPoint.rotation;
            tank.Revive();
        }

        private void DisableTankControl()
        {
            _battle.Tank1.DisableControl();
            _battle.Tank2.DisableControl();
        }
    }
}
