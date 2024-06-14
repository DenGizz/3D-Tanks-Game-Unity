using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Infrasctucture
{
    public interface IAssetsProvider
    {
        BattleSessionConfig GetBattleSessionConfig();
        GameObject GetMessagesUiPrefab();
        GameObject GetTankPrefab();
    }
}
