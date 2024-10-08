﻿using Assets.Scripts.Features.InputSources;
using Assets.Scripts.Infrasctucture.Gameplay.Providers;
using Assets.Scripts.Domain;
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
            
            foreach(IInputReader reader in tankGameObject.GetComponentsInChildren<IInputReader>())
                reader.SetInputSource(inputSource);
        }
    }
}
