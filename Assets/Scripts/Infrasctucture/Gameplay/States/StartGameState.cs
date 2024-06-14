﻿using Assets.Scripts.Infrasctucture.Core;
using Assets.Scripts.Infrasctucture.Gameplay.Providers;
using Assets.Scripts.Infrasctucture.Gameplay.States;
using Assets.Scripts.Infrasctucture.Ui;
using Assets.Scripts.StateMachines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Infrasctucture.Gameplay.GameplayStateMachine.States
{
    public class StartGameState : IState
    {
        private readonly StateMachine _gameplayStateMachine;
        private readonly IUiProvider _uiProvider;
        private readonly IUiFactory _uiFactory;
        private readonly ILevelSpawnPointsProvider _levelSpawnPointsProvider;
        private readonly ICameraControlProvider _cameraControlProvider;
        private readonly ICoroutineRunner _coroutineRunner;

        public StartGameState(StateMachine gameplayStateMachine, IUiProvider uiProvider, 
            IUiFactory uiFactory, ILevelSpawnPointsProvider levelSpawnPointsProvider,
            ICameraControlProvider cameraControlProvider, ICoroutineRunner coroutineRunner)
        {
            _gameplayStateMachine = gameplayStateMachine;
            _uiProvider = uiProvider;
            _uiFactory = uiFactory;
            _levelSpawnPointsProvider = levelSpawnPointsProvider;
            _cameraControlProvider = cameraControlProvider;
            _coroutineRunner = coroutineRunner;
        }

        public void Enter()
        {
            _levelSpawnPointsProvider.Initialize();
            _cameraControlProvider.Initialize();
            _coroutineRunner.Initialize();

            _uiProvider.MessagesUi = _uiFactory.CreateMessagesUi();
            _gameplayStateMachine.EnterState<CreateRoundState>();
        }

        public void Exit()
        {

        }
    }
}
