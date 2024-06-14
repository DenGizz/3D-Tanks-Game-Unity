using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Infrasctucture.Gameplay.Services
{
    public interface IRoundObserver
    {
        event Action<Tank> RoundWin;
        Tank RoundWinner { get; }

        int GetNumberOfRoundWins(Tank tank);
        int PerformedRounds { get; }

        void StartObserve();
    }
}
