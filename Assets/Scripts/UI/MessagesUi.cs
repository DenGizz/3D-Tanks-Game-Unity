﻿using Assets.Scripts.Domain;
using Assets.Scripts.Features;
using Assets.Scripts.Infrasctucture.Gameplay.Providers;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.UI
{
    public class MessagesUi : MonoBehaviour
    {
        [SerializeField] private Text _messagesUiText;

        private IBattleProvider _battleProvider;
        private ITankDisplayDataProvider _tankDisplayDataProvider;

        private string Text
        {
            get => _messagesUiText.text;
            set => _messagesUiText.text = value;
        }

        [Inject]
        public void Construct(IBattleProvider battleProvider, ITankDisplayDataProvider tankDisplayDataProvider)
        {
            _battleProvider = battleProvider;
            _tankDisplayDataProvider = tankDisplayDataProvider;
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

        public void ShowLoadingText()
        {
            Text = "Loading...";
        }

        public void ClearText()
        {
            Text = string.Empty;
        }

        private string GetColoredPlayerText(ITank tank)
        {
            TankDisplayData displayData  = _tankDisplayDataProvider.GetDisplayData(tank);

            return "<color=#" + ColorUtility.ToHtmlStringRGB(displayData.Color) + ">" + displayData.Name + "</color>";
        }
    }
}
