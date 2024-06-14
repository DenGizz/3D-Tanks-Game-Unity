using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class MessagesUi : MonoBehaviour
    {
        [SerializeField] private Text _messagesUiText;

        public string Text
        {
            get => _messagesUiText.text;
            set => _messagesUiText.text = value;
        }
    }
}
