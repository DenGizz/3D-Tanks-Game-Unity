using Assets.Scripts.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Infrasctucture
{
    public class UiFactory : IUiFactory
    {
        private readonly IAssetsProvider _assetsProvider;

        public UiFactory(IAssetsProvider assetsProvider)
        {
            _assetsProvider = assetsProvider;
        }

        public MessagesUi CreateMessagesUi()
        {
            var messagesUiPrefab = _assetsProvider.GetMessagesUiPrefab();
            return UnityEngine.Object.Instantiate(messagesUiPrefab).GetComponent<MessagesUi>();
        }
    }
}
