using System.Collections;
using System.Collections.Generic;
using BitMedia.TestProject.Configs;
using BitMedia.TestProject.Gameplay.CharacterBehaviour;
using UnityEngine;

namespace BitMedia.TestProject.Gameplay
{
    public class CharacterSpawner
    {
        private Vector3 _spawnPosition;
        private float _spawnFrequency;

        private MonoBehaviour _serviceMonoBehaviour;
        private Coroutine _thisCoroutine;
        private Transform _charactersParent;
        private string[] _keys;

        public CharacterSpawner(SpawnConfig spawnConfig, MonoBehaviour serviceMonoBehaviour)
        {
            _spawnPosition = spawnConfig.SpawnPosition;
            _spawnFrequency = spawnConfig.SpawnFrequency;
            ObjectPool.Instance.FillPool(spawnConfig.Pools);
            _serviceMonoBehaviour = serviceMonoBehaviour;
            _keys = new string[ObjectPool.Instance.poolDictionary.Count];
            ObjectPool.Instance.poolDictionary.Keys.CopyTo(_keys,0);
            _charactersParent = new GameObject("SpawnedCharacters").transform;
            _charactersParent.position = Vector3.zero;
        }

        public void Activate()
        {
            _thisCoroutine = _serviceMonoBehaviour.StartCoroutine(SpawnCoroutine());
        }

        public void Deactivate()
        {
            _serviceMonoBehaviour.StopCoroutine(_thisCoroutine);
        }

        private IEnumerator SpawnCoroutine()
        {
            while (true)
            {
                // var characterClone = GameObject.Instantiate(_characterPrefab[Random.Range(0, _characterPrefab.Count)], _charactersParent);
                foreach (string tag in _keys)
                {
                    Vector3 pos = new Vector3(Random.Range(-_spawnPosition.x, _spawnPosition.x), 0f, Random.Range(-_spawnPosition.z, _spawnPosition.z));
                    var characterClone = ObjectPool.Instance.GetFromPool(tag, pos);
                    yield return new WaitForSecondsRealtime(5f);
                }
               yield return new WaitForSecondsRealtime(_spawnFrequency);
            }
        }
    }
}


