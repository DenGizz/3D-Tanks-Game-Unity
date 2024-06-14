using Assets.Scripts.Infrasctucture.Core;
using Assets.Scripts.Tank;
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

        public ITank RoundWinner { get; private set; }

        public event Action<ITank> RoundWin;

        private readonly ITanksProvider _tanksProvider;
        private readonly ICoroutineRunner _coroutineRunner;

        private Coroutine _waitForOneTankLeftCoroutine;

        private readonly Dictionary<ITank, int> _roundWins = new Dictionary<ITank, int>();
        private bool _isObserving;

        public RoundObserver(ITanksProvider tanksProvider, ICoroutineRunner coroutineRunner)
        {
            _tanksProvider = tanksProvider;
            _coroutineRunner = coroutineRunner;
        }

        public int GetNumberOfRoundWins(ITank tank)
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

            ITank winner = GetRoundWinner();
            PerformedRounds++;
            _roundWins[winner]++;
            RoundWinner = winner;
            RoundWin?.Invoke(winner);
        }

        private bool OneTankLeft()
        {
            return _tanksProvider.Tanks.Count(t => t.GameObjectInstance.activeSelf) <= 1;
        }

        private ITank GetRoundWinner()
        {
            return _tanksProvider.Tanks.FirstOrDefault(t => t.GameObjectInstance.activeSelf);
        }

        public void SetTanksToObserve(IEnumerable<ITank> tanks)
        {
            foreach (var tank in _tanksProvider.Tanks)
                _roundWins.Add(tank, 0);
        }
    }
}
