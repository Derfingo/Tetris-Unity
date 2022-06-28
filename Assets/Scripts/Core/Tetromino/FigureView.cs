using UnityEngine;
using UnityEngine.Tilemaps;

namespace Core
{
    public class FigureView : MonoBehaviour
    {
        [SerializeField] private Tile _tile;

        private SpriteRenderer _spriteRenderer;

        public void Initialize()
        {
            _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }

        public Tile GetTile()
        {
            _tile.color = _spriteRenderer.color;
            return _tile;
        }
    }
}
