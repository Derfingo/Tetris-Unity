using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class GameOverMenu : MonoBehaviour
    {
        [SerializeField] private Button _restartButton;

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
