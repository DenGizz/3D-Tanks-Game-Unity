using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Infrasctucture.Gameplay.Services
{
    public interface IBattleSessionObserver
    {
        event Action<Tank> RoundWin;
        event Action<Tank> GameWin;

        int GetNumberOfRoundWins(Tank tank);
        int PerformedRounds { get; }

        void StartObserve();
        void StopObserve();
        void Reset();
    }
}
