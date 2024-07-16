using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.Domain
{
    public class Battle
    {
        public ITank Tank1 { get; }
        public ITank Tank2 { get; }

        public int CurrentRound { get; private set; }
        public int RoundsToWin { get; }

        public ITank BattleWinner { get; private set; }
        public IEnumerable<ITank> RoundWinners => _roundWinners;

        private List<ITank> _roundWinners { get; }

        public Battle(ITank tank1, ITank tank2, int roundsToWin)
        {
            Tank1 = tank1;
            Tank2 = tank2;
            CurrentRound = -1;
            RoundsToWin = roundsToWin;
            _roundWinners = new List<ITank>();
        }

        public int GetNumberOfWinnedRounds(ITank tank)
        {
            return _roundWinners.Where(t => t == tank).Count();
        }

        public void StartNewRound()
        {
            CurrentRound++;
        }

        public void EndRound(ITank roundWinner)
        {
            _roundWinners.Add(roundWinner);

            if(GetNumberOfWinnedRounds(roundWinner) >= RoundsToWin)
            {
                BattleWinner = roundWinner;
                return;
            }  
        }
    }
}
