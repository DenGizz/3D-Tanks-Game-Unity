using Assets.Scripts.Features.StateMachines;
using Assets.Scripts.Infrasctucture.Core.Services;
using Assets.Scripts.Infrasctucture.Ui;
using Assets.Scripts.Infrastructure.Core.Services;
using Assets.Scripts.Infrastructure.Gameplay.Configs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;

namespace Assets.Scripts.Game.States
{
    public class LoadBattleFieldSceneState : IState
    {
        private readonly StateMachine _stateMachine;
        private readonly ISceneLoader _sceneLoader;
        private readonly IStaticDataService _staticDataService;
        private readonly IUiProvider _uiProvider;

        public LoadBattleFieldSceneState(StateMachine stateMachine, ISceneLoader sceneLoader, IStaticDataService staticDataService, IUiProvider uiProvider)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _staticDataService = staticDataService;
            _uiProvider = uiProvider;
        }

        public void Enter()
        {
            _uiProvider.MessagesUi.ShowLoadingText();

            ScenesConfig config = _staticDataService.ScenesConfig;
            _sceneLoader.LoadSceneAsync(config.BattleFieldSceneName,
                () => _stateMachine.EnterState<InitializeBattleFieldLevelState>());
        }
    }
}
