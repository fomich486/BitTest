using System;
using System.Collections.Generic;
using BitMedia.TestProject.Gameplay.CharacterBehaviour;
using UnityEngine;

namespace BitMedia.TestProject.Configs
{
    [Serializable]
    public class SpawnConfig
    {
        public Vector3 SpawnPosition;
        public float SpawnFrequency;
        public List<Pool> Pools;
    }
}
