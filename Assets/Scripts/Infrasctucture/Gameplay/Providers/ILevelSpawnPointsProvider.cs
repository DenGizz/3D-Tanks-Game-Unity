using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Infrasctucture.Gameplay.Providers
{
    public interface ILevelSpawnPointsProvider
    {
        IEnumerable<Transform> SpawnPoints { get; }

        void Initialize();
    }
}
