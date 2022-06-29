using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class InfoMenu : MonoBehaviour
    {
        [SerializeField] private Button _pauseButton;
        [SerializeField] private Transform _nextFigurePanel;

        public Button PauseButton => _pauseButton;
        public Transform NextFigurePanel => _nextFigurePanel;
    }
}
