namespace Core
{
    public class GameGrid
    {
        public int Rows { get; private set; }
        public int Columns { get; private set; }

        private readonly int[,] _grid;

        public int this[int r, int c]
        {
            get => _grid[r, c];
            set => _grid[r, c] = value;
        }

        public GameGrid(int rows, int colums)
        {
            Rows = rows;
            Columns = colums;
            _grid = new int[rows, colums];
        }

        private void ClearRow(int r)
        {
            for (int c = 0; c < Columns; c++)
            {
                _grid[r, c] = 0;
            }
        }

        private bool IsInside(int r, int c)
        {
            return r >= 0 && r < Rows && c >= 0 && c < Columns;
        }

        public bool IsEmpty(int r, int c)
        {
            return IsInside(r, c) && _grid[r, c] == 0;
        }

        private void MoveRowDown(int r, int numCleared)
        {
            for (int c = 0; c < Columns; c++)
            {
                _grid[r - numCleared, c] = _grid[r, c];
                _grid[r, c] = 0;
            }
        }

        public int ClearFullRows()
        {
            int cleared = 0;

            for (int r = 0; r < Rows; r++)
            {
                if (IsRowFull(r))
                {
                    ClearRow(r);
                    cleared++;
                }
                else if (cleared > 0)
                {
                    MoveRowDown(r, cleared);
                }
            }

            return cleared;
        }

        public bool IsRowFull(int r)
        {
            for (int c = 0; c < Columns; c++)
            {
                if (_grid[r, c] == 0)
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsRowEmpty(int r)
        {
            for (int c = 0; c < Columns; c++)
            {
                if (_grid[r, c] != 0)
                {
                    return false;
                }
            }

            return true;
        }

        public void ClearGrid()
        {
            for (int r = 0; r < Rows; r++)
            {
                for (int c = 0; c < Columns; c++)
                {
                    if (!IsEmpty(r, c))
                    {
                        _grid[r, c] = 0;
                    }
                }
            }
        }
    }
}