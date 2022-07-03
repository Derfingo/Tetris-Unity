using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class InfoMenu : MonoBehaviour
    {
        [SerializeField] private Button _pauseButton;
        [SerializeField] private Image _nextFigureSprite;

        public Button PauseButton => _pauseButton;

        public void UpdateNextFigure((Sprite, Color) tuple)
        {
            _nextFigureSprite.sprite = tuple.Item1;
            _nextFigureSprite.color = tuple.Item2;
        }
    }
}
