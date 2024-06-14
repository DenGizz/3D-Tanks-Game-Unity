﻿using Assets.Scripts.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;

namespace Assets.Scripts.Infrasctucture
{
    public class UiFactory : IUiFactory
    {
        private readonly IAssetsProvider _assetsProvider;
        private readonly IInstantiator _instantiator;

        public UiFactory(IAssetsProvider assetsProvider, IInstantiator instantiator)
        {
            _assetsProvider = assetsProvider;
            _instantiator = instantiator;
        }

        public MessagesUi CreateMessagesUi()
        {
            var messagesUiPrefab = _assetsProvider.GetMessagesUiPrefab();
            return _instantiator.InstantiatePrefab(messagesUiPrefab).GetComponent<MessagesUi>();
        }
    }
}
