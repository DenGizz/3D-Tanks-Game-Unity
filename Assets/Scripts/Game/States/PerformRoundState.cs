using Assets.Scripts.Domain;
using Assets.Scripts.Features.StateMachines;
using Assets.Scripts.Infrasctucture.Gameplay.Providers;
using Assets.Scripts.Infrasctucture.Ui;

namespace Assets.Scripts.Game.States
{
    public class PerformRoundState : IState, IExitableState
    {
        private readonly StateMachine _stateMachine;
        private readonly IUiProvider _uiProvider;
        private readonly IBattleProvider _battleProvider;

        Battle _battle;

        public PerformRoundState(StateMachine stateMachine, IUiProvider uiProvider, IBattleProvider battleProvider)
        {
            _stateMachine = stateMachine;
            _uiProvider = uiProvider;
            _battleProvider = battleProvider;
        }

        public void Enter()
        {
            _battle = _battleProvider.CurrentBattle;

            EnableTankControl();
            _uiProvider.MessagesUi.ClearText();

            _battle.Tank1.OnDeath += OnTankDeath;
            _battle.Tank2.OnDeath += OnTankDeath;

        }

        public void Exit()
        {
            _battle.Tank1.OnDeath -= OnTankDeath;
            _battle.Tank2.OnDeath -= OnTankDeath;
        }

        private void EnableTankControl()
        {
            _battle.Tank1.EnableControl();
            _battle.Tank2.EnableControl();
        }

        private void OnTankDeath(IDamagable deadTank)
        {
            ITank winner = null;

            if(deadTank == _battle.Tank1)
                winner = _battle.Tank2;

            if(deadTank == _battle.Tank2)
                winner = _battle.Tank1;

            _battle.EndRound(winner);

            if(_battle.BattleWinner == null)
                _stateMachine.EnterState<EndRoundState>();
            else
                _stateMachine.EnterState<EndGameState>();
        }
    }
}
