using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Infrasctucture.Gameplay.Services
{
    public interface IRoundObserver
    {
        event Action<TankBehaviour> RoundWin;
        TankBehaviour RoundWinner { get; }

        int GetNumberOfRoundWins(TankBehaviour tank);
        int PerformedRounds { get; }

        void StartObserve();
        void SetTanksToObserve(IEnumerable<TankBehaviour> tanks);
    }
}
