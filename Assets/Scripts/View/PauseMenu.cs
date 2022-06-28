using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private Button _resumeButton;
        [SerializeField] private Button _restartButton;

        public Button ResumeButton => _resumeButton;
        public Button RestartButton => _restartButton;

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}
