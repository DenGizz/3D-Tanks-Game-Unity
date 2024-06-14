using Assets.Scripts.Features;
using Assets.Scripts.Infrasctucture.Core;
using Assets.Scripts.Infrasctucture.Gameplay.Providers;
using Assets.Scripts.Infrasctucture.Gameplay.Services;
using Assets.Scripts.Infrasctucture.Ui;
using Assets.Scripts.StateMachines;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Infrasctucture.Gameplay.States
{
    public class StartRoundState : IState
    {
        private readonly StateMachine _stateMachine;
        private readonly IRoundObserver _battleSessionObserver;
        private readonly ITanksProvider _tanksProvider;
        private readonly ICameraControlProvider _cameraControlProvider;
        private readonly IUiProvider _uiProvider;
        private readonly IStaticDataService _staticDataService;
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly IRoundObserver _roundObserver;
        private readonly WaitForSeconds _waitStartDelay;
        private readonly ILevelSpawnPointsProvider _levelSpawnPointsProvider;


        public StartRoundState(StateMachine stateMachine, IRoundObserver battleSessionObserver, ITanksProvider tanksProvider, 
            ICameraControlProvider cameraControlProvider, IUiProvider uiProvider, IStaticDataService staticDataService,
            ICoroutineRunner coroutineRunner, IRoundObserver roundObserver,
            ILevelSpawnPointsProvider levelSpawnPointsProvider)
        {
            _stateMachine = stateMachine;
            _battleSessionObserver = battleSessionObserver;
            _tanksProvider = tanksProvider;
            _cameraControlProvider = cameraControlProvider;
            _uiProvider = uiProvider;
            _staticDataService = staticDataService;
            _coroutineRunner = coroutineRunner;
            _roundObserver = roundObserver;
            _waitStartDelay = new WaitForSeconds(_staticDataService.BattleSessionConfig.StartDelay);
            _levelSpawnPointsProvider = levelSpawnPointsProvider;
        }

        public void Enter()
        {
            ResetAllTanks();
            DisableTankControl();

            _cameraControlProvider.CameraControl.m_Targets = _tanksProvider.Tanks.ToArray();
            _roundObserver.StartObserve();
            _cameraControlProvider.CameraControl.SetStartPositionAndSize();
            _uiProvider.MessagesUi.ShowRoundStartText(_battleSessionObserver.PerformedRounds);
            _coroutineRunner.StartCoroutine(StartRound());
        }

        public void Exit()
        {

        }

        private IEnumerator StartRound()
        {
            yield return _waitStartDelay;
            _stateMachine.EnterState<PerformRoundState>();
        }

        private void ResetAllTanks()
        {
            int i = 0;
            foreach (TankBehaviour tank in _tanksProvider.Tanks)
            {
                Transform spawnPoint = _levelSpawnPointsProvider.SpawnPoints.ElementAt(i);
                tank.SetPosition(spawnPoint.position);
                tank.SetRotation(spawnPoint.rotation);

                tank.Revive();
                i++;
            }
        }

        private void DisableTankControl()
        {
            foreach (TankBehaviour tank in _tanksProvider.Tanks)
                tank.DisableControl();
        }
    }
}
