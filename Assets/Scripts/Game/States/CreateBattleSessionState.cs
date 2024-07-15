using System.Linq;
using Assets.Scripts.Configs;
using Assets.Scripts.Domain;
using Assets.Scripts.Features;
using Assets.Scripts.Features.InputSources;
using Assets.Scripts.Features.StateMachines;
using Assets.Scripts.Infrasctucture.Core;
using Assets.Scripts.Infrasctucture.Gameplay.Factories;
using Assets.Scripts.Infrasctucture.Gameplay.Providers;
using Assets.Scripts.Infrasctucture.Gameplay.Services;
using UnityEngine;

namespace Assets.Scripts.Game.States
{
    public class CreateBattleSessionState : IState
    {
        private readonly StateMachine _gameplayStateMachine;
        private readonly ITankFactory _tankFactory;
        private readonly ILevelSpawnPointsProvider _levelSpawnPointsProvider;
        private readonly IBattleProvider _battleProvider;
        private readonly IInputSourceServiceAssing _assingInputSourceService;
        private readonly IInputSourceFactory _inputSourceFactory;
        private readonly IStaticDataService _staticDataService;
        private readonly ITankDisplayDataProvider _tankDisplayDataProvider;
        private readonly ITankColorizer _tankColorizer;

        public CreateBattleSessionState(StateMachine gameplayStateMachine,
            ITankFactory tankFactory, ILevelSpawnPointsProvider levelSpawnPointsProvider,
            IBattleProvider battleProvider, IInputSourceServiceAssing assingInputSourceService, IStaticDataService staticDataService,
            IInputSourceFactory inputSourceFactory, ITankDisplayDataProvider ankDisplayDataProvider, ITankColorizer colorizer)
        {
            _gameplayStateMachine = gameplayStateMachine;
            _tankFactory = tankFactory;
            _levelSpawnPointsProvider = levelSpawnPointsProvider;
            _battleProvider = battleProvider;
            _assingInputSourceService = assingInputSourceService;
            _inputSourceFactory = inputSourceFactory;
            _staticDataService = staticDataService;
            _tankDisplayDataProvider = ankDisplayDataProvider;
            _tankColorizer = colorizer;
        }

        public void Enter()
        {
            Transform[] spawnPoints = _levelSpawnPointsProvider.SpawnPoints.ToArray();

            ITank tank1 = _tankFactory.CreateTank(spawnPoints[0].position, spawnPoints[0].rotation);
            ITank tank2 = _tankFactory.CreateTank(spawnPoints[1].position, spawnPoints[1].rotation);

            TankDisplayData tank1DisplayData = new TankDisplayData("Player 1", Color.red);
            TankDisplayData tank2DisplayData = new TankDisplayData("Player 2", Color.blue);

            _tankDisplayDataProvider.AddDisplayData(tank1, tank1DisplayData);
            _tankDisplayDataProvider.AddDisplayData(tank2, tank2DisplayData);

            _tankColorizer.ColorizeTank(tank1, tank1DisplayData.Color);
            _tankColorizer.ColorizeTank(tank2, tank2DisplayData.Color);

            LocalInputSchemesConfig inputsConfig = _staticDataService.LocalInputSchemesConfig;

            LocalInputSchemeConfiguration tank1InputConfig = inputsConfig.LocalInputConfigurations.ElementAt(0);
            LocalInputSchemeConfiguration tank2InputConfig = inputsConfig.LocalInputConfigurations.ElementAt(1);

            IInputSource inputSource1 = _inputSourceFactory.CreateLocalInputSource(tank1InputConfig);
            IInputSource inputSource2 = _inputSourceFactory.CreateLocalInputSource(tank2InputConfig);

            _assingInputSourceService.AssignInputSource(tank1 , inputSource2);
            _assingInputSourceService.AssignInputSource(tank2, inputSource1);

            BattleRulesConfig battleRulesConfig = _staticDataService.BattleSessionConfig;

            Battle battle = new Battle(tank1,tank2, battleRulesConfig.NumRoundsToWin);

            _battleProvider.CurrentBattle = battle;

            _gameplayStateMachine.EnterState<PrepareNewRoundState>();
        }
    }
}
