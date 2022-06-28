using System;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Core
{
    public class GameArea
    {
        private readonly FigureSpawn _figureSpawn;
        private GameGrid _grid;
        private GridView _gridView;

        private readonly int _rows = 24;
        private readonly int _columns = 10;
        private readonly int _minEmptyRows = 6;

        public GameArea(GridView gridView, FigureSpawn figureSpawn)
        {
            _grid = new GameGrid(_rows, _columns);
            _figureSpawn = figureSpawn;
            _gridView = gridView;
            _gridView.Initialize(_grid);
        }

        private Position[] GetPositions() => _figureSpawn.GetFigure.PiecePositions;

        private int CellDistanceToBoard(Position position)
        {
            int distance = 0;

            while (_grid.IsEmpty(position.Row + distance - 1, 0))
            {
                distance--;
            }

            return distance;
        }

        public int FigureDistanceToBoard()
        {
            int distance = _grid.Rows;

            foreach (var position in GetPositions())
            {
                distance = Math.Min(distance, CellDistanceToBoard(position));
                Debug.Log(distance);
            }

            return distance;
        }

        public bool CheckValidPosition(int x, int y)
        {
            foreach (var position in GetPositions())
            {
                if (_grid.IsEmpty(position.Row + y, position.Column + x) == false)
                {
                    return false;
                }
            }

            return true;
        }

        public bool CheckEmptyRows()
        {
            return _grid.IsRowEmpty(_grid.Rows - _minEmptyRows);
        }

        public void PlaceFigure()
        {
            for (int i = 0; i < GetPositions().Length; i++)
            {
                _grid[GetPositions()[i].Row, GetPositions()[i].Column] = 1;
            }

            _gridView.SetBlocks(GetPositions(), _figureSpawn.GetFigure);
        }

        public int ClearFullRows()
        {
            int cleared = _grid.ClearFullRows();
            _gridView.ClearFullRows();
            return cleared;
        }

        public void ClearGrid()
        {
            _grid.ClearGrid();
            _gridView.ClearGrid();
        }

        public Tilemap GetTilemap()
        {
            return _gridView.TileGrid;
        }
    }
}