using Assets.Scripts.Tank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Infrasctucture.Gameplay.Services
{
    public interface IRoundObserver
    {
        event Action<ITank> RoundWin;
        ITank RoundWinner { get; }

        int GetNumberOfRoundWins(ITank tank);
        int PerformedRounds { get; }

        void StartObserve();
        void SetTanksToObserve(IEnumerable<ITank> tanks);
    }
}
