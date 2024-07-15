using Assets.Scripts.Features.StateMachines;
using Assets.Scripts.Infrasctucture.Core;
using Assets.Scripts.Infrasctucture.Ui;
using Assets.Scripts.Infrasctucture.Gameplay.Providers;

namespace Assets.Scripts.Game.States
{
    public class EndBattleState : IState
    {
        private readonly IBattleProvider _battleProvider;
        private readonly IUiProvider _uiProvider;
        private readonly ICoroutineRunner _coroutineRunner;

        public void Enter()
        {
            DisableTankControl();
            _uiProvider.MessagesUi.ShowRoundWinnerText(_battleProvider.CurrentBattle.BattleWinner);
        }

        private void DisableTankControl()
        {
            _battleProvider.CurrentBattle.Tank1.DisableControl();
            _battleProvider.CurrentBattle.Tank2.DisableControl();
        }
    }
}
