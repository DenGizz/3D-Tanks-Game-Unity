﻿using Assets.Scripts.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Infrasctucture.Ui
{
    public class UiProvider : IUiProvider
    {
        public MessagesUi MessagesUi { get; set; }
    }
}
