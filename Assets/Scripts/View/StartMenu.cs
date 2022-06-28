using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class StartMenu : MonoBehaviour
    {
        [SerializeField] private Button _startButton;
        public Button StartButton => _startButton;

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
