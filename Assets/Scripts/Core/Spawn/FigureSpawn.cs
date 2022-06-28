using UnityEngine;

namespace Core
{
    public class FigureSpawn : MonoBehaviour
    {
        private FigurePool _figurePool;
        private Figure _currentFigure;
        public Figure GetFigure => _currentFigure;

        public void Initialize(FigurePool figurePool)
        {
            _figurePool = figurePool;
        }

        public void ReturnFigure()
        {
            _currentFigure.Deactivate();
            _currentFigure.ResetPositions();
        }

        public void SpawnNext()
        {
            _currentFigure = _figurePool.GetFigure();
            _currentFigure.Activate();
        }
    }
}