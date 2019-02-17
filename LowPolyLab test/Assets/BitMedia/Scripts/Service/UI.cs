using UnityEngine.UI;
using UnityEngine;

namespace BitMedia.TestProject.Service
{
    public class UI : MonoBehaviour
    {
        public static UI Instance;
        private float _score = 0;
        [SerializeField]
        private Text _scoreText;
        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);
            AddPoints(0);
        }
        public void AddPoints(int points)
        {
            _score += points;
            _scoreText.text = _score.ToString();
        }
    }
}
