using BitMedia.TestProject.Service;
using UnityEngine;

namespace BitMedia.TestProject.Core
{
    public class ApplicationManager : MonoBehaviour
    {
        [SerializeField] private ReferenceProvider _referenceProvider;

        private GameManager _gameManager;

        private void Start()
        {
            _gameManager = new GameManager(_referenceProvider);
            _gameManager.StartGame();
        }
    }
}
