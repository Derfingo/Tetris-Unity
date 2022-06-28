using View;

namespace Core
{
    public class GameState
    {
        private readonly PlayerStatus _playerStatus;
        private readonly FigureControl _figureControl;
        private readonly FigureSpawn _figureSpawn;
        private readonly GameArea _gameArea;
        private readonly IPresenter _presenter;
        private readonly IPause _pause;

        public GameState(PlayerStatus playerStatus, FigureControl playerControl, FigureSpawn figureSpawn, GameArea gameArea, IPresenter presenter, IPause pause)
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
            _figureSpawn.SpawnNext();
            _figureControl.GetFigure(_figureSpawn.GetFigure);
            _pause.SetPause(true);
        }

        private void RestartGame()
        {
            _figureSpawn.ReturnFigure();
            _gameArea.ClearGrid();
            _playerStatus.ResetScore();
            _presenter.ChangeTopScore(_playerStatus.BestScore);
            _figureSpawn.SpawnNext();
            _figureControl.GetFigure(_figureSpawn.GetFigure);
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
            _figureSpawn.ReturnFigure();
            if (!_gameArea.CheckEmptyRows())
            {
                GameOver();
            }
            _figureSpawn.SpawnNext();
            _figureControl.GetFigure(_figureSpawn.GetFigure);
        }
    }
}
