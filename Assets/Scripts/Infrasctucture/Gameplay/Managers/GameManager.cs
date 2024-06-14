using Assets.Scripts.Infrasctucture;
using Assets.Scripts.Infrasctucture.Core;
using Assets.Scripts.Infrasctucture.Gameplay.Factories;
using Assets.Scripts.Infrasctucture.Gameplay.GameplayStateMachine.States;
using Assets.Scripts.Infrasctucture.Gameplay.Providers;
using Assets.Scripts.Infrasctucture.Gameplay.States;
using Assets.Scripts.Infrasctucture.Ui;
using Assets.Scripts.StateMachines;
using Assets.Scripts.UI;
using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GameManager : MonoBehaviour
{
    private IStateFactory _stateFactory;

    [Inject]
    public void Construct(IStateFactory stateFactory)
    {
        _stateFactory = stateFactory;
    }


    private void Start()
    {
        StateMachine stateMachine = new StateMachine();
        stateMachine.AddState(_stateFactory.CreateState<StartGameState>(stateMachine));
        stateMachine.AddState(_stateFactory.CreateState<CreateBattleSessionState>(stateMachine));
        stateMachine.AddState(_stateFactory.CreateState<StartRoundState>(stateMachine));
        stateMachine.AddState(_stateFactory.CreateState<PerformRoundState>(stateMachine));
        stateMachine.AddState(_stateFactory.CreateState<EndRoundState>(stateMachine));
        stateMachine.AddState(_stateFactory.CreateState<EndGameState>(stateMachine));

        stateMachine.EnterState<StartGameState>();
    }
}