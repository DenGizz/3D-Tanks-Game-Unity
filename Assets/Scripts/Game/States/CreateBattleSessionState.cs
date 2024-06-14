﻿using Assets.Scripts.Infrasctucture.Gameplay.Providers;
using Assets.Scripts.Infrasctucture.Gameplay.Services;
using Assets.Scripts.StateMachines;
using Assets.Scripts.Tank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Infrasctucture.Gameplay.States
{
    public class CreateBattleSessionState : IState
    {
        private readonly StateMachine _gameplayStateMachine;
        private readonly ITanksProvider _tanksProvider;
        private readonly ITankFactory _tankFactory;
        private readonly ILevelSpawnPointsProvider _levelSpawnPointsProvider;
        private readonly IRoundObserver _roundObserver;

        public CreateBattleSessionState(StateMachine gameplayStateMachine, ITanksProvider tanksProvider, 
            ITankFactory tankFactory, ILevelSpawnPointsProvider levelSpawnPointsProvider, IRoundObserver roundObserver)
        {
            _gameplayStateMachine = gameplayStateMachine;
            _tanksProvider = tanksProvider;
            _tankFactory = tankFactory;
            _levelSpawnPointsProvider = levelSpawnPointsProvider;
            _roundObserver = roundObserver;
        }

        public void Enter()
        {
            Transform[] spawnPoints = _levelSpawnPointsProvider.SpawnPoints.ToArray();

            ITank tank1 = _tankFactory.CreateTank(spawnPoints[0].position, spawnPoints[0].rotation, Color.red, 2);
            ITank tank2 = _tankFactory.CreateTank(spawnPoints[1].position, spawnPoints[1].rotation, Color.blue, 1);

            _tanksProvider.AddTank(tank1);
            _tanksProvider.AddTank(tank2);

            _roundObserver.SetTanksToObserve(_tanksProvider.Tanks);
            _gameplayStateMachine.EnterState<StartRoundState>();
        }

        public void Exit()
        {

        }
    }
}
