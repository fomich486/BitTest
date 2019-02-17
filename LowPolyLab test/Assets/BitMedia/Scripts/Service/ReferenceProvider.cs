using BitMedia.TestProject.Configs;
using UnityEngine;

namespace BitMedia.TestProject.Service
{
    public class ReferenceProvider : MonoBehaviour
    {
        public GameConfig GameConfig
        {
            get { return _gameConfig; }
        }

        [SerializeField] private GameConfig _gameConfig;
    }
}
