using Assets.Scripts.Game;
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

public class GameBootstrapper : MonoBehaviour
{
    private Game _game;

    [Inject]
    private void Construct(Game game)
    {
        _game = game;
    }

    private void Start()
    {
        _game.Start();
    }
}