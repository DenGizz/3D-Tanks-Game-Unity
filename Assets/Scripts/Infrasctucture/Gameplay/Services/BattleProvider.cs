using Assets.Scripts.Domain;
using Assets.Scripts.Infrasctucture.Core;
using Assets.Scripts.Tank;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrasctucture.Gameplay.Services
{
    public class BattleProvider : IBattleProvider
    {
        public Battle CurrentBattle { get; set; }
    }
}
