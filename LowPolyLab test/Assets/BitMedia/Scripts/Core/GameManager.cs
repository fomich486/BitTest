using System;
using System.Collections.Generic;
using BitMedia.TestProject.Configs;
using BitMedia.TestProject.Gameplay;
using BitMedia.TestProject.Service;
using UnityEngine;

namespace BitMedia.TestProject.Core
{
    public class GameManager
    {
        public event Action GameStarted;
        public event Action GameFinished;

        private CharacterSpawner _characterSpawner;
        private MachineGun _machineGun;
        

        public GameManager(ReferenceProvider referenceProvider)
        {
            InitializeCharacterSpawner(referenceProvider.GameConfig.SpawnConfig, referenceProvider);
            InitializeMachineGun(referenceProvider.GameConfig.ShootConfig);
        }

        public void StartGame()
        {
            _characterSpawner.Activate();

            GameStarted?.Invoke();
        }

        public void EndGame()
        {
            _characterSpawner.Deactivate();

            GameFinished?.Invoke();
        }

        private void InitializeCharacterSpawner(SpawnConfig spawnConfig, MonoBehaviour serviceMonoBehaviour)
        {
            _characterSpawner = new CharacterSpawner(spawnConfig, serviceMonoBehaviour);
        }

        private void InitializeMachineGun(ShootConfig shootConfig)
        {
            _machineGun = new MachineGun(shootConfig);

        }
    }
}
