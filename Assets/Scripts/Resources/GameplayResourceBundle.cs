using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Resources
{
    [CreateAssetMenu(fileName = "GameplayResourceBundle", menuName = "Resources/GameplayResourceBundle")]
    public class GameplayResourceBundle : ScriptableObject
    {
        public GameObject TankPrefab => _tankPrefab;

        [SerializeField] private GameObject _tankPrefab;
    }
}
