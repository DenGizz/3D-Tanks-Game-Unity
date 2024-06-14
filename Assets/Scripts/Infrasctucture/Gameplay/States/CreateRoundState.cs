﻿using Assets.Scripts.Infrasctucture.Gameplay.Providers;
using Assets.Scripts.StateMachines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Infrasctucture.Gameplay.States
{
    public class CreateRoundState : IState
    {
        private readonly StateMachine _gameplayStateMachine;
        private readonly ITanksProvider _tanksProvider;
        private readonly ITankFactory _tankFactory;
        private readonly ILevelSpawnPointsProvider _levelSpawnPointsProvider;

        public CreateRoundState(StateMachine gameplayStateMachine, ITanksProvider tanksProvider, ITankFactory tankFactory, ILevelSpawnPointsProvider levelSpawnPointsProvider)
        {
            _gameplayStateMachine = gameplayStateMachine;
            _tanksProvider = tanksProvider;
            _tankFactory = tankFactory;
            _levelSpawnPointsProvider = levelSpawnPointsProvider;
        }

        public void Enter()
        {
            Transform[] spawnPoints = _levelSpawnPointsProvider.SpawnPoints.ToArray();

            Tank tank1 = _tankFactory.CreateTank(spawnPoints[1], Color.blue, 1);
            Tank tank2 = _tankFactory.CreateTank(spawnPoints[0], Color.red, 2);

            _tanksProvider.AddTank(tank1);
            _tanksProvider.AddTank(tank2);

            _gameplayStateMachine.EnterState<RoundStartingState>();
        }

        public void Exit()
        {

        }
    }
}
