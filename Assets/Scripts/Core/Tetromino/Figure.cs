using UnityEngine;
using UnityEngine.Tilemaps;

namespace Core
{
    public class Figure : MonoBehaviour
    {
        private FigureMovement _movement;
        private FigureView _view;

        public Position[] PiecePositions => _movement.PiecePositions;

        public void Initialize()
        {
            _movement = GetComponent<FigureMovement>();
            _view = GetComponent<FigureView>();
            _movement.Initialize();
            _view.Initialize();
        }

        public void Move(int rows, int columns)
        {
            _movement.Move(rows, columns);
        }

        public void Rotate()
        {
            _movement.Rotate();
        }

        public Tile GetTile()
        {
            return _view.GetTile();
        }

        public void ResetPositions()
        {
            _movement.ResetPositions();
        }

        public void Activate()
        {
            gameObject.SetActive(true);
        }

        public void Deactivate()
        {
            gameObject.SetActive(false);
        }
    }
}