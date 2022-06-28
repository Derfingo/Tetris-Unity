using UnityEngine;

namespace Core
{
    public struct Position
    {
        public int Row { get; set; }

        public int Column { get; set; }

        public Position(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public Position(float row, float column)
        {
            Row = Mathf.FloorToInt(row);
            Column = Mathf.FloorToInt(column);
        }
    }
}
