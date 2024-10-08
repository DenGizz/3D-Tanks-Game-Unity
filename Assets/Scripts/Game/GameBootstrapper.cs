﻿using UnityEngine;
using Zenject;

namespace Assets.Scripts.Game
{
    public class GameBootstrapper : MonoBehaviour
    {
        private Game _game;

        [Inject]
        private void Construct(Game game)
        {
            _game = game;
            DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            _game.Start();
        }
    }
}