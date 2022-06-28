using System;
using UnityEngine;

namespace Core
{
    public class FigureControl
    {
        public event Action OnLand;

        private readonly IInput _input;
        private readonly GameArea _gameArea;
        private readonly ScreenInfo _screenInfo;
        private Figure _currentFigure;

        public FigureControl(IInput input, GameArea gameArea, ScreenInfo screenInfo)
        {
            _input = input;
            _gameArea = gameArea;
            _screenInfo = screenInfo;

            _input.UpMove += RotateFigure;
            _input.DownMove += DropFigure;
            _input.HorizontalMove += MoveHorizontal;
        }

        private void RotateFigure()
        {
            if (_gameArea.CheckValidPosition(-1, -1) && _gameArea.CheckValidPosition(1, 1))
            {
                _currentFigure.Rotate();
            }

            if (!_gameArea.CheckValidPosition(-1, 0))
            {
                _currentFigure.Move(0, 1);
                _currentFigure.Rotate();
            }

            if (!_gameArea.CheckValidPosition(1, 0))
            {
                _currentFigure.Move(0, -1);
                _currentFigure.Rotate();
            }
        }

        private void MoveHorizontal(Vector2 position)
        {
            int direction = position.x > _screenInfo.HalfScreenWidth ? 1 : -1;

            if (_gameArea.CheckValidPosition(direction, 0))
            {
                _currentFigure.Move(0, direction);
            }
        }

        private void MoveDown()
        {
            if (_gameArea.CheckValidPosition(0, -1))
            {
                _currentFigure.Move(-1, 0);
            }
            else
            {
                OnLand?.Invoke();
            }
        }

        private void DropFigure()
        {
            while (true)
            {
                if (_gameArea.CheckValidPosition(0, -1))
                {
                    _currentFigure.Move(-1, 0);
                }
                else
                {
                    OnLand?.Invoke();
                    break;
                }
            }
        }

        public void GetFigure(Figure figure)
        {
            _currentFigure = figure;
        }

        public void UpdatePass()
        {
            MoveDown();
        }
    }
}