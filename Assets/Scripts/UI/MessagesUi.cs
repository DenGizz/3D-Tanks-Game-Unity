using Assets.Scripts.Infrasctucture;
using Assets.Scripts.Infrasctucture.Gameplay.Services;
using Assets.Scripts.Tank;
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

        private IBattleProvider _battleProvider;

        private string Text
        {
            get => _messagesUiText.text;
            set => _messagesUiText.text = value;
        }

        [Inject]
        public void Construct(IBattleProvider battleProvider)
        {
            _battleProvider = battleProvider;
        }

        public void ShowRoundStartText(int roundNumber)
        {
            Text = "ROUND " + (roundNumber + 1);
        }

        public void ShowRoundWinnerText(ITank winner)
        {
            string message = GetColoredPlayerText(winner) + " WINS THE ROUND!";
            message += "\n\n\n\n";

            ITank tank1 = _battleProvider.CurrentBattle.Tank1;
            ITank tank2 = _battleProvider.CurrentBattle.Tank2;
            message += GetColoredPlayerText(tank1) + ": " + _battleProvider.CurrentBattle.GetNumberOfWinnedRounds(tank1) + " WINS\n";
            message += GetColoredPlayerText(tank2) + ": " + _battleProvider.CurrentBattle.GetNumberOfWinnedRounds(tank2) + " WINS\n";

            Text = message;
        }

        public void ShowBattleWinnerText(ITank winner)
        {
            string  message = GetColoredPlayerText(winner) + " WINS THE GAME!";
            Text = message;
        }

        public void ClearText()
        {
            Text = string.Empty;
        }

        private string GetColoredPlayerText(ITank tank)
        {
            return "<color=#" + ColorUtility.ToHtmlStringRGB(tank.PlayerColor) + ">PLAYER " + tank.PlayerNumber + "</color>";
        }
    }
}
