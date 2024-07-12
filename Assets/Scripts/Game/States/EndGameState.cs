using Assets.Scripts.Infrasctucture.Core;
using Assets.Scripts.StateMachines;

namespace Assets.Scripts.Infrasctucture.Gameplay.States
{
    public class EndGameState : IState
    {
        private readonly IStaticDataService _staticDataService;
        private readonly ICoroutineRunner _coroutineRunner;

        public EndGameState(StateMachine s, ICoroutineRunner coroutineRunner, IStaticDataService staticDataService)
        {
            _coroutineRunner = coroutineRunner;
            _staticDataService = staticDataService;
        }

        public void Enter()
        {
            BattleRulesConfig config = _staticDataService.BattleSessionConfig;
            _coroutineRunner.DoAfterDelay(CloseGame, config.EndDelay);
        }

        public void Exit()
        {
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