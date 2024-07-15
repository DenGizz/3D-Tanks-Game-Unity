using Assets.Scripts.Configs;
using Assets.Scripts.Features.StateMachines;
using Assets.Scripts.Infrasctucture.Core;
using Assets.Scripts.Infrasctucture.Gameplay.Providers;
using Assets.Scripts.Infrasctucture.Ui;

namespace Assets.Scripts.Game.States
{
    public class EndGameState : IState
    {
        private readonly IUiProvider _uiProvider;
        private readonly IBattleProvider _battleProvider;
        private readonly IStaticDataService _staticDataService;
        private readonly ICoroutineRunner _coroutineRunner;

        public EndGameState(StateMachine s, IBattleProvider battleProvider, IUiProvider uiProvider,ICoroutineRunner coroutineRunner, IStaticDataService staticDataService)
        {
            _uiProvider = uiProvider;
            _battleProvider = battleProvider;
            _coroutineRunner = coroutineRunner;
            _staticDataService = staticDataService;
        }

        public void Enter()
        {
            BattleRulesConfig config = _staticDataService.BattleSessionConfig;
            _uiProvider.MessagesUi.ShowBattleWinnerText(_battleProvider.CurrentBattle.BattleWinner);
            _coroutineRunner.DoAfterDelay(CloseGame, config.EndDelay);
        }

        private void CloseGame()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            UnityEngine.Application.Quit();
#endif
        }
    }
}