using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Infrasctucture.Gameplay.Providers
{
    public interface ILevelSpawnPointsProvider
    {
        IEnumerable<Transform> SpawnPoints { get; }

        void Initialize();
    }
}
