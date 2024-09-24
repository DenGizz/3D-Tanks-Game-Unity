using Assets.Scripts.Features.StateMachines;
using Assets.Scripts.Infrasctucture.Core;
using Assets.Scripts.Infrasctucture.Core.Services.CoroutineRunners;
using Assets.Scripts.Infrasctucture.Gameplay.Providers;
using Assets.Scripts.Infrasctucture.Ui;

namespace Assets.Scripts.Game.States
{
    public class InitializeGameState : IState
    {
        private readonly StateMachine _gameplayStateMachine;
        private readonly IUiProvider _uiProvider;
        private readonly IUiFactory _uiFactory;
        private readonly ICoroutineRunner _coroutineRunner;

        public InitializeGameState(StateMachine gameplayStateMachine, IUiProvider uiProvider, 
            IUiFactory uiFactory,ICoroutineRunner coroutineRunner)
        {
            _gameplayStateMachine = gameplayStateMachine;
            _uiProvider = uiProvider;
            _uiFactory = uiFactory;
            _coroutineRunner = coroutineRunner;
        }

        public void Enter()
        {
            _coroutineRunner.Initialize();

            _uiProvider.MessagesUi = _uiFactory.CreateMessagesUi();
            _gameplayStateMachine.EnterState<LoadBattleFieldSceneState>();
        }
    }
}
