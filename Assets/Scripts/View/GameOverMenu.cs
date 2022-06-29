using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class GameOverMenu : BaseMenu
    {
        [SerializeField] private Button _restartButton;
        public Button RestartButton => _restartButton;
    }
}
