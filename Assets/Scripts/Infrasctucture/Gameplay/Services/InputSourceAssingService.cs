using Assets.Scripts.Infrasctucture.Gameplay.Providers;
using Assets.Scripts.Tank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Infrasctucture.Gameplay.Services
{
    public class InputSourceAssingService : IInputSourceServiceAssing
    {
        private readonly ITanksGameObjectsRegistry _tanksGameObjectsRegistry;

        public InputSourceAssingService(ITanksGameObjectsRegistry tanksGameObjectsRegistry)
        {
            _tanksGameObjectsRegistry = tanksGameObjectsRegistry;
        }

        public void AssignInputSource(ITank tank, IInputSource inputSource)
        {
            GameObject tankGameObject = _tanksGameObjectsRegistry.GetTankGameObject(tank);
            tankGameObject.GetComponent<TankMoveControllerBehaviour>().SetInputSource(inputSource);
        }
    }
}
