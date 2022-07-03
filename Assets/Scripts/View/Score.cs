using TMPro;
using UnityEngine;

namespace View
{
    public class Score : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private TextMeshProUGUI _topScoreText;

        private int _score = 0;

        public void UpdateScoreText(int score)
        {
            if (score == 0)
            {
                return;
            }

            _scoreText.SetText("{000000:0}", _score += score);
        }

        public void UpdateTopScoreText(int topScore)
        {
            _topScoreText.SetText("{000000:0}", topScore);
        }

        public void ResetScore()
        {
            _scoreText.text = "000000";
        }
    }
}
