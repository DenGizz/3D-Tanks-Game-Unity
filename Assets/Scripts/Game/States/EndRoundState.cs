using Assets.Scripts.Infrasctucture.Core;
using Assets.Scripts.Infrasctucture.Gameplay.Services;
using Assets.Scripts.Infrasctucture.Ui;
using Assets.Scripts.StateMachines;
using Assets.Scripts.Tank;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrasctucture.Gameplay.States
{
    public class EndRoundState : IState
    {
        private readonly StateMachine _stateMachine;
        private readonly IUiProvider _uiProvider;
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly WaitForSeconds _waitDelay;
        private readonly ITanksProvider _tanksProvider;
        private readonly IStaticDataService _staticDataService;
        private readonly IRoundObserver _roundObserver;

        ITank m_RoundWinner;
        ITank m_GameWinner;

        public EndRoundState(StateMachine stateMachine, IUiProvider uiProvider, ICoroutineRunner coroutineRunner, ITanksProvider tanksProvider, IStaticDataService staticDataService, IRoundObserver roundObserver)
        {
            _stateMachine = stateMachine;
            _uiProvider = uiProvider;
            _coroutineRunner = coroutineRunner;
            _waitDelay = new WaitForSeconds(3f);
            _tanksProvider = tanksProvider;
            _staticDataService = staticDataService;
            _roundObserver = roundObserver;
        }

        public void Enter()
        {
            // Stop tanks from moving.
            DisableTankControl();

            // See if there is a winner now the round is over.
            m_RoundWinner = _roundObserver.RoundWinner;
            m_GameWinner = GetGameWinner();

            if(m_GameWinner != null)
                _uiProvider.MessagesUi.ShowGameWinnerText(m_GameWinner);
            else
                _uiProvider.MessagesUi.ShowRoundWinnerText(m_RoundWinner);

            _coroutineRunner.StartCoroutine(WaitDelay());
        }

        public void Exit()
        {
  
        }


        private void DisableTankControl()
        {
            foreach (ITank tank in _tanksProvider.Tanks)
                tank.DisableControl();
        }

        private IEnumerator WaitDelay()
        {             
            yield return _waitDelay;

            if(_roundObserver.GetNumberOfRoundWins(m_RoundWinner) >= _staticDataService.BattleSessionConfig.NumRoundsToWin)     
                _stateMachine.EnterState<EndGameState>();
            else
                _stateMachine.EnterState<StartRoundState>();
        }

        private ITank GetGameWinner()
        {
            return _tanksProvider.Tanks.FirstOrDefault(t => _roundObserver.GetNumberOfRoundWins(t) == _staticDataService.BattleSessionConfig.NumRoundsToWin);
        }
    }
}
