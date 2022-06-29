using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class PauseMenu : BaseMenu
    {
        [SerializeField] private Button _resumeButton;
        [SerializeField] private Button _restartButton;

        public Button ResumeButton => _resumeButton;
        public Button RestartButton => _restartButton;
    }
}
