using Assets.Scripts.Features;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Infrasctucture.Gameplay.Providers
{
    public class LevelSpawnPointsProvider : ILevelSpawnPointsProvider
    {
        public IEnumerable<Transform> SpawnPoints => _spawnPoints;

        private Transform[] _spawnPoints;

        public void Initialize()
        {
            _spawnPoints = 
                GameObject.FindObjectsByType<SpawnPoint>(FindObjectsInactive.Exclude, FindObjectsSortMode.InstanceID)
                .Select(sp => sp.transform).ToArray();
        }
    }
}
