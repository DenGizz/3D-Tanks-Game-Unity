using Assets.Scripts.Infrasctucture;
using Assets.Scripts.Infrasctucture.Gameplay.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.UI
{
    public class MessagesUi : MonoBehaviour
    {
        [SerializeField] private Text _messagesUiText;

        private ITanksProvider _tanksProvider;
        private IRoundObserver _roundObserver;

        private string Text
        {
            get => _messagesUiText.text;
            set => _messagesUiText.text = value;
        }

        [Inject]
        public void Construct(ITanksProvider tanksProvider, IRoundObserver roundObserver)
        {
            _tanksProvider = tanksProvider;
            _roundObserver = roundObserver;
        }

        public void ShowRoundStartText(int roundNumber)
        {
            Text = "ROUND " + (roundNumber + 1);
        }

        public void ShowRoundWinnerText(TankBehaviour winner)
        {
            string message = GetColoredPlayerText(winner) + " WINS THE ROUND!";
            message += "\n\n\n\n";

            foreach (TankBehaviour tank in _tanksProvider.Tanks)
                message += GetColoredPlayerText(tank) + ": " + _roundObserver.GetNumberOfRoundWins(tank) + " WINS\n";

            Text = message;
        }

        public void ShowGameWinnerText(TankBehaviour winner)
        {
            string  message = GetColoredPlayerText(winner) + " WINS THE GAME!";
            Text = message;
        }

        public void ClearText()
        {
            Text = string.Empty;
        }

        private string GetColoredPlayerText(TankBehaviour tank)
        {
            return "<color=#" + ColorUtility.ToHtmlStringRGB(tank.PlayerColor) + ">PLAYER " + tank.PlayerNumber + "</color>";
        }
    }
}
