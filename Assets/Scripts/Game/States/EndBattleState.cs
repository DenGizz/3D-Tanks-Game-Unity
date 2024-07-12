using Assets.Scripts.Infrasctucture.Core;
using Assets.Scripts.Infrasctucture.Gameplay.Services;
using Assets.Scripts.Infrasctucture.Ui;
using Assets.Scripts.StateMachines;
using Assets.Scripts.Tank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void Exit()
        {

        }

        private void DisableTankControl()
        {
            _battleProvider.CurrentBattle.Tank1.DisableControl();
            _battleProvider.CurrentBattle.Tank2.DisableControl();
        }
    }
}
