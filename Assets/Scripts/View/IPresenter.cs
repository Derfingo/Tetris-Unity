using System;

namespace View
{
    public interface IPresenter
    {
        public event Action OnStartClick;
        public event Action OnRestartClick;
        public event Action<bool> OnPauseClick;

        public void ChangeScore(int score);
        public void ChangeTopScore(int topScore);
        public void ShowStartMenu();
        public void ShowGameOverMenu();
    }
}
