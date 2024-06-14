using Assets.Scripts.Infrasctucture.Core;
using Assets.Scripts.Infrasctucture.Gameplay.Services;
using Assets.Scripts.Infrasctucture.Ui;
using Assets.Scripts.StateMachines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditorInternal;

namespace Assets.Scripts.Infrasctucture.Gameplay.States
{
    public class PerformRoundState : IState
    {
        private readonly StateMachines.StateMachine _stateMachine;
        private readonly ITanksProvider _tanksProvider;
        private readonly IUiProvider _uiProvider;
        private readonly IRoundObserver _roundObserver;

        public PerformRoundState(StateMachines.StateMachine stateMachine, ITanksProvider tanksProvider, IUiProvider uiProvider, IRoundObserver roundObserver)
        {
            _stateMachine = stateMachine;
            _tanksProvider = tanksProvider;
            _uiProvider = uiProvider;
            _roundObserver = roundObserver;
        }

        public void Enter()
        {
            EnableTankControl();
            _uiProvider.MessagesUi.Text = string.Empty;
            _roundObserver.StartObserve();
            _roundObserver.RoundWin += OnRoundWin;
        }

        public void Exit()
        {
            _roundObserver.RoundWin -= OnRoundWin;
        }

        private void EnableTankControl()
        {
            foreach (Tank tank in _tanksProvider.Tanks)
                tank.EnableControl();
        }

        private void OnRoundWin(Tank tank)
        {
            _stateMachine.EnterState<EndRoundState>();
        }
    }
}
