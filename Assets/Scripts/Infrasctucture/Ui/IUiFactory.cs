using Assets.Scripts.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UI;

namespace Assets.Scripts.Infrasctucture
{
    public interface IUiFactory
    {
        MessagesUi CreateMessagesUi();
    }
}
