using UnityEngine;
using UnityEngine.Tilemaps;

namespace Core
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class GridView : MonoBehaviour
    {
        [SerializeField] private Tilemap _cells;
        [SerializeField] private Tilemap _figures;

        private GameGrid _grid;
        private SpriteRenderer _render;
        private Tilemap _tilemap;
        public Tilemap TileGrid => _tilemap;


        public void Initialize(GameGrid grid)
        {
            _render = GetComponent<SpriteRenderer>();
            _tilemap = GetComponentInChildren<Tilemap>();
            _grid = grid;

            _render.drawMode = SpriteDrawMode.Tiled;
            _render.size = new Vector2Int(10, 24);
        }

        private void ClearRow(int r)
        {
            for (int c = 0; c < _grid.Columns; c++)
            {
                _figures.SetTile(new Vector3Int(c, r, 0), null);
            }
        }

        private bool IsRowFull(int r)
        {
            for (int c = 0; c < _grid.Columns; c++)
            {
                if (_figures.GetTile(new Vector3Int(c, r, 0)) == null)
                {
                    return false;
                }
            }

            return true;
        }

        private void MoveRowDown(int r, int numCleared)
        {
            for (int c = 0; c < _grid.Columns; c++)
            {
                var tile = _figures.GetTile(new Vector3Int(c, r, 0));
                _figures.SetTile(new Vector3Int(c, r - numCleared, 0), tile);
                _figures.SetTile(new Vector3Int(c, r, 0), null);
            }
        }

        public void SetBlocks(Position[] positions, Figure figure)
        {
            for (int i = 0; i < positions.Length; i++)
            {
                Vector3Int tilePosition = new Vector3Int(positions[i].Column, positions[i].Row, 0);
                _figures.SetTile(tilePosition, figure.GetTile());
            }
        }

        public void ClearFullRows()
        {
            int cleared = 0;

            for (int r = 0; r < _grid.Rows; r++)
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
        }

        public void ClearGrid()
        {
            for (int r = 0; r < _grid.Rows; r++)
            {
                for (int c = 0; c < _grid.Columns; c++)
                {
                    var tilePosition = new Vector3Int(c, r, 0);

                    if (_figures.HasTile(tilePosition))
                    {
                        _figures.SetTile(tilePosition, null);
                    }
                }
            }
        }
    }
}
