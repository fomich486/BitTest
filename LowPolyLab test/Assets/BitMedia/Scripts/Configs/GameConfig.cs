using System;
using UnityEngine;

namespace BitMedia.TestProject.Configs
{
    [Serializable]
    public class GameConfig
    {
        public SpawnConfig SpawnConfig
        {
            get { return _spawnConfig; }
        }
        public ShootConfig ShootConfig
        {
            get { return _shootConfig; }
        }

        [SerializeField] private SpawnConfig _spawnConfig;
        [SerializeField] private ShootConfig _shootConfig;
    }
}
