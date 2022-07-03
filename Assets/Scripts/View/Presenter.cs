using System;
using UnityEngine;

namespace View
{
    public class Presenter : IPresenter
    {
        public event Action OnStartClick;
        public event Action OnRestartClick;
        public event Action<bool> OnPauseClick;

        private readonly StartMenu _startMenu;
        private readonly PauseMenu _pauseMenu;
        private readonly GameOverMenu _gameOverMenu;
        private readonly InfoMenu _infoMenu;
        private readonly Score _score;

        public Presenter(StartMenu startMenu, PauseMenu pauseMenu, GameOverMenu gameOverMenu, InfoMenu infoMenu, Score score)
        {
            _startMenu = startMenu;
            _pauseMenu = pauseMenu;
            _gameOverMenu = gameOverMenu;
            _infoMenu = infoMenu;
            _score = score;

            _infoMenu.PauseButton.onClick.AddListener(OnPauseButton);
            _startMenu.StartButton.onClick.AddListener(OnStartButton);
            _pauseMenu.ResumeButton.onClick.AddListener(OnResumeButton);
            _pauseMenu.RestartButton.onClick.AddListener(OnRestartButton);
            _gameOverMenu.RestartButton.onClick.AddListener(OnRestartButton);
        }

        private void OnStartButton()
        {
            _startMenu.Hide();
            OnStartClick?.Invoke();
        }

        private void OnPauseButton()
        {
            _pauseMenu.Show();
            OnPauseClick?.Invoke(false);
        }

        private void OnResumeButton()
        {
            _pauseMenu.Hide();
            OnPauseClick?.Invoke(true);
        }

        private void OnRestartButton()
        {
            _pauseMenu.Hide();
            _gameOverMenu.Hide();
            _score.ResetScore();
            OnRestartClick?.Invoke();
        }

        public void ChangeScore(int score)
        {
            _score.UpdateScoreText(score);
        }

        public void ChangeTopScore(int topScore)
        {
            _score.UpdateTopScoreText(topScore);
        }

        public void ShowStartMenu()
        {
            _startMenu.Show();
        }

        public void ShowGameOverMenu()
        {
            _gameOverMenu.Show();
        }

        public void UpdateNextFigure((Sprite, Color) tuple)
        {
            _infoMenu.UpdateNextFigure(tuple);
        }
    }
}
