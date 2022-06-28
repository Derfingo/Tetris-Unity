using UnityEngine;

namespace Core
{
    public class FigurePool : MonoBehaviour
    {
        [SerializeField] private Figure[] _figures;
        private Figure _figure;

        public void Init()
        {
        }

        public Figure GetFigure()
        {
            int i = Random.Range(0, _figures.Length);
            _figure = _figures[i];
            _figure.Initialize();
            return _figure;
        }

        public void ReturnFigure()
        {
            _figure.Deactivate();
            _figure.ResetPositions();
        }
    }
}