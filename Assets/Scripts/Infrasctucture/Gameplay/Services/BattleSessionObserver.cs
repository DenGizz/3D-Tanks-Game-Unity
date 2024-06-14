using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;

namespace Assets.Scripts.Infrasctucture.Gameplay.Services
{
    public class BattleSessionObserver : IBattleSessionObserver
    {
        public int PerformedRounds {get; private set;}

        public event Action<Tank> RoundWin;
        public event Action<Tank> GameWin;

        private readonly ITanksProvider _tanksProvider;
        private readonly Dictionary<Tank, int> _roundWins = new Dictionary<Tank, int>();
        private bool _isObserving;

        public int GetNumberOfRoundWins(Tank tank)
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

            foreach (var tank in _tanksProvider.Tanks)
                _roundWins.Add(tank, 0);
        }

        public void StopObserve()
        {
            _isObserving = false;

            _roundWins.Clear();
        }
    }
}
