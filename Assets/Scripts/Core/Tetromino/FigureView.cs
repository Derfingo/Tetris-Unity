using UnityEngine;
using UnityEngine.Tilemaps;

namespace Core
{
    public class FigureView : MonoBehaviour
    {
        [SerializeField] private Tile _tile;
        [SerializeField] private Sprite _figureIcon;
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

        public (Sprite, Color) GetSprite()
        {
            return (_figureIcon, _tile.color);
        }
    }
}
