using System.Linq;
using Assets.Scripts.Configs;
using Assets.Scripts.Domain;
using Assets.Scripts.Features.StateMachines;
using Assets.Scripts.Infrasctucture.Core;
using Assets.Scripts.Infrasctucture.Gameplay.Providers;
using Assets.Scripts.Infrasctucture.Ui;

namespace Assets.Scripts.Game.States
{
    public class EndRoundState : IState
    {
        private readonly StateMachine _stateMachine;
        private readonly IUiProvider _uiProvider;
        private readonly IStaticDataService _staticDataService;
        private readonly IBattleProvider _battleProvider;
        private readonly ICoroutineRunner _coroutineRunner;


        private Battle _battle;

        public EndRoundState(StateMachine stateMachine, IUiProvider uiProvider, IStaticDataService staticDataService, IBattleProvider battleProvider, ICoroutineRunner coroutineRunner)
        {
            _stateMachine = stateMachine;
            _uiProvider = uiProvider;
            _staticDataService = staticDataService;
            _battleProvider = battleProvider;
            _coroutineRunner = coroutineRunner;
        }

        public void Enter()
        {
            _battle = _battleProvider.CurrentBattle;

            DisableTankControl();

            ITank roundWinner = _battle.RoundWinners.ElementAt(_battle.CurrentRound);
           _uiProvider.MessagesUi.ShowRoundWinnerText(roundWinner);

            BattleRulesConfig config = _staticDataService.BattleSessionConfig;

            _coroutineRunner.DoAfterDelay(
                () => _stateMachine.EnterState<PrepareNewRoundState>(),
                config.EndDelay);
        }

        private void DisableTankControl()
        {
            _battle.Tank1.DisableControl();
            _battle.Tank2.DisableControl();
        }
    }
}
