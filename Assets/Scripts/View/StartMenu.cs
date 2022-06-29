using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class StartMenu : BaseMenu
    {
        [SerializeField] private Button _startButton;
        public Button StartButton => _startButton;
    }
}
