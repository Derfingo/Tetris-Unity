using View;

namespace Core
{
    public class GameState
    {
        private readonly PlayerStatus _playerStatus;
        private readonly FigureControl _figureControl;
        private readonly FigureSpawner _figureSpawn;
        private readonly GameArea _gameArea;
        private readonly IPresenter _presenter;
        private readonly IPause _pause;

        private Figure _currentFigure;

        public GameState(PlayerStatus playerStatus, FigureControl playerControl, FigureSpawner figureSpawn, GameArea gameArea, IPresenter presenter, IPause pause)
        {
            _playerStatus = playerStatus;
            _figureControl = playerControl;
            _figureSpawn = figureSpawn;
            _gameArea = gameArea;

            _presenter = presenter;
            _pause = pause;

            _figureControl.OnLand += UpdateFigure;
            _presenter.OnStartClick += StartGame;
            _presenter.OnRestartClick += RestartGame;
            _presenter.OnPauseClick += PauseGame;

            InitialState();
        }

        private void InitialState()
        {
            _presenter.ShowStartMenu();
            _presenter.ChangeTopScore(_playerStatus.BestScore);
            _pause.SetPause(false);
        }

        private void StartGame()
        {
            _currentFigure = _figureSpawn.SpawnNext();
            _figureControl.GetFigure(_currentFigure);
            _presenter.UpdateNextFigure(_figureSpawn.NextFigure.GetSprite());
            _pause.SetPause(true);
        }

        private void RestartGame()
        {
            _gameArea.ClearGrid();
            _playerStatus.ResetScore();
            _presenter.ChangeTopScore(_playerStatus.BestScore);
            _figureSpawn.ReturnFigure(_currentFigure);
            _currentFigure = _figureSpawn.SpawnNext();
            _figureControl.GetFigure(_currentFigure);
            _presenter.UpdateNextFigure(_figureSpawn.NextFigure.GetSprite());
            _pause.SetPause(true);
        }

        private void PauseGame(bool isPaused)
        {
            _pause.SetPause(isPaused);
        }

        private void GameOver()
        {
            _playerStatus.SaveData();
            _playerStatus.ResetScore();
            _presenter.ShowGameOverMenu();
            _pause.SetPause(false);
        }

        private void UpdateFigure()
        {
            _gameArea.PlaceFigure();
            int score = _gameArea.ClearFullRows();
            _playerStatus.AddScore(score);
            _presenter.ChangeScore(_playerStatus.Score);
            _figureSpawn.ReturnFigure(_currentFigure);
            if (!_gameArea.CheckEmptyRows())
            {
                GameOver();
            }
            _currentFigure = _figureSpawn.SpawnNext();
            _figureControl.GetFigure(_currentFigure);
            _presenter.UpdateNextFigure(_figureSpawn.NextFigure.GetSprite());
        }
    }
}
