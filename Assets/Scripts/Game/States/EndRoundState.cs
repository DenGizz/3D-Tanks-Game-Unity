using Assets.Scripts.Infrasctucture.Core;
using Assets.Scripts.Infrasctucture.Gameplay.Services;
using Assets.Scripts.Infrasctucture.Ui;
using Assets.Scripts.StateMachines;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

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

        Tank m_RoundWinner;
        Tank m_GameWinner;

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


            // Get a message based on the scores and whether or not there is a game winner and display it.
            string message = EndMessage(m_RoundWinner, m_GameWinner);
            _uiProvider.MessagesUi.Text = message;

           _coroutineRunner.StartCoroutine(WaitDelay());
        }

        public void Exit()
        {
  
        }


        private void DisableTankControl()
        {
            foreach (Tank tank in _tanksProvider.Tanks)
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

        private string EndMessage(Tank m_RoundWinner, Tank m_GameWinner)
        {
            // By default when a round ends there are no winners so the default end message is a draw.
            string message = "DRAW!";

            // If there is a winner then change the message to reflect that.
            if (m_RoundWinner != null)
                message = GetColoredPlayerText(m_RoundWinner) + " WINS THE ROUND!";

            // Add some line breaks after the initial message.
            message += "\n\n\n\n";

            foreach (Tank tank in _tanksProvider.Tanks)
                message += GetColoredPlayerText(tank) + ": " + _roundObserver.GetNumberOfRoundWins(tank) + " WINS\n";

            // If there is a game winner, change the entire message to reflect that.
            if (m_GameWinner != null)
                message = GetColoredPlayerText(m_GameWinner) + " WINS THE GAME!";

            return message;
        }

        private string GetColoredPlayerText(Tank tank)
        {
            return "<color=#" + ColorUtility.ToHtmlStringRGB(tank.PlayerColor) + ">PLAYER " + tank.PlayerNumber + "</color>";
        }

        private Tank GetGameWinner()
        {
            return _tanksProvider.Tanks.FirstOrDefault(t => _roundObserver.GetNumberOfRoundWins(t) == _staticDataService.BattleSessionConfig.NumRoundsToWin);
        }
    }
}
