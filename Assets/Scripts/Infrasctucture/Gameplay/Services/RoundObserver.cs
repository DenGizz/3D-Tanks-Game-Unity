using Assets.Scripts.Infrasctucture.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrasctucture.Gameplay.Services
{
    public class RoundObserver : IRoundObserver
    {
        public int PerformedRounds {get; private set;}

        public TankBehaviour RoundWinner { get; private set; }

        public event Action<TankBehaviour> RoundWin;

        private readonly ITanksProvider _tanksProvider;
        private readonly ICoroutineRunner _coroutineRunner;

        private Coroutine _waitForOneTankLeftCoroutine;

        private readonly Dictionary<TankBehaviour, int> _roundWins = new Dictionary<TankBehaviour, int>();
        private bool _isObserving;

        public RoundObserver(ITanksProvider tanksProvider, ICoroutineRunner coroutineRunner)
        {
            _tanksProvider = tanksProvider;
            _coroutineRunner = coroutineRunner;
        }

        public int GetNumberOfRoundWins(TankBehaviour tank)
        {
            return _roundWins[tank];
        }

        public void Reset()
        {
            foreach (var tank in _tanksProvider.Tanks)
                _roundWins[tank] = 0;
        }

        public void StartObserve()
        {
            _isObserving = true;

            _waitForOneTankLeftCoroutine = _coroutineRunner.StartCoroutine(WainForOneTankLeftEnumerator());
        }

        IEnumerator WainForOneTankLeftEnumerator()
        {
            while (!OneTankLeft())
            {
                yield return null;
            }

            TankBehaviour winner = GetRoundWinner();
            PerformedRounds++;
            _roundWins[winner]++;
            RoundWinner = winner;
            RoundWin?.Invoke(winner);
        }

        private bool OneTankLeft()
        {
            return _tanksProvider.Tanks.Count(t => t.GameObjectInstance.activeSelf) <= 1;
        }

        private TankBehaviour GetRoundWinner()
        {
            return _tanksProvider.Tanks.FirstOrDefault(t => t.GameObjectInstance.activeSelf);
        }

        public void SetTanksToObserve(IEnumerable<TankBehaviour> tanks)
        {
            foreach (var tank in _tanksProvider.Tanks)
                _roundWins.Add(tank, 0);
        }
    }
}
