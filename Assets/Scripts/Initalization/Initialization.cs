using Core;
using UnityEngine;
using UnityEngine.UI;
using View;

namespace Init
{
    public class Initialization : MonoBehaviour
    {
        [Header("UI")]
        [SerializeField] private StartMenu _startMenu;
        [SerializeField] private PauseMenu _pauseMenu;
        [SerializeField] private GameOverMenu _gameOverMenu;
        [SerializeField] private Button _pauseButton;
        [SerializeField] private Presenter _presenter;
        [SerializeField] private Score _score;
        [Space]
        [Header("Logic")]
        [SerializeField] private GameLoop _gameLoop;
        [SerializeField] private SafeAreaSetter _safeAreaSetter;
        [SerializeField] private GridView _gridView;
        [SerializeField] private FigureSpawn _figureSpawn;
        [SerializeField] private FigurePool _figurePool;

        private PauseSetter _pauseSetter;
        private GameArea _gameArea;
        private GameState _gameState;
        private FigureControl _figureControl;
        private TouchInput _touchInput;
        private ScreenInfo _screenInfo;
        private PlayerStatus _playerStatus;
        private SaveSystem _saveSystem;

        private void Awake()
        {
            Application.targetFrameRate = 60;
            Compose();
        }

        private void Compose()
        {
            _touchInput = new TouchInput();
            _screenInfo = new ScreenInfo();
            _saveSystem = new SaveSystem();
            _figurePool.Init();
            _figureSpawn.Initialize(_figurePool);
            _gameArea = new GameArea(_gridView, _figureSpawn);
            _figureControl = new FigureControl(_touchInput, _gameArea, _screenInfo);
            _gameLoop.Initialize(_figureControl, _touchInput, _playerStatus);
            _pauseSetter = new PauseSetter();
            _pauseSetter.Register(_gameLoop);
            _presenter = new Presenter(_startMenu, _pauseMenu, _gameOverMenu, _pauseButton, _score);
            _playerStatus = new PlayerStatus(_saveSystem);
            _gameState = new GameState(_playerStatus, _figureControl, _figureSpawn, _gameArea, _presenter, _pauseSetter);
        }
    }
}