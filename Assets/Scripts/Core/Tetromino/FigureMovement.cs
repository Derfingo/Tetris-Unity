using UnityEngine;

namespace Core
{
    public class FigureMovement : MonoBehaviour
    {
        public Position[] PiecePositions { get; private set; }

        private Transform[] Pieces;
        private Vector3 _initialPosition;
        private Position[] _initialPiecePositions;

        public void Initialize()
        {
            Pieces = new Transform[]
            {
                transform.GetChild(0),
                transform.GetChild(1),
                transform.GetChild(2),
                transform.GetChild(3)
            };

            PiecePositions = new Position[]
            {
                new Position(Pieces[0].position.y, Pieces[0].position.x),
                new Position(Pieces[1].position.y, Pieces[1].position.x),
                new Position(Pieces[2].position.y, Pieces[2].position.x),
                new Position(Pieces[3].position.y, Pieces[3].position.x)
            };

            _initialPosition = transform.position;
            _initialPiecePositions = PiecePositions;
        }

        public void Move(int rows, int columns)
        {
            for (int i = 0; i < PiecePositions.Length; i++)
            {
                PiecePositions[i].Row += rows;
                PiecePositions[i].Column += columns;
            }

            transform.position += new Vector3(columns, rows);
        }

        public void Rotate()
        {
            transform.Rotate(new Vector3(0, 0, -90), Space.World);

            for (int i = 0; i < PiecePositions.Length; i++)
            {
                PiecePositions[i].Row = Mathf.FloorToInt(Pieces[i].transform.position.y);
                PiecePositions[i].Column = Mathf.FloorToInt(Pieces[i].transform.position.x);
            }
        }

        public void ResetPositions()
        {
            transform.position = _initialPosition;
            PiecePositions = _initialPiecePositions;
        }
    }
}
