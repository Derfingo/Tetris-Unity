using UnityEngine;

namespace Core
{
    public class FigureSpawner : MonoBehaviour
    {
        [SerializeField] private Figure[] _figures;

        public Figure CurrentFigure { get; private set; }
        public Figure NextFigure { get; private set; }

        public void Initialize()
        {
            NextFigure = GetRandomFigure();
        }

        private Figure GetRandomFigure()
        {
            int random = Random.Range(0, _figures.Length);
            Figure figure = _figures[random];
            return figure;
        }

        private Figure GetAnotherFigure()
        {
            Figure current = NextFigure;
            NextFigure = GetRandomFigure();
            NextFigure.Initialize();

            while (current.name == NextFigure.name)
            {
                NextFigure = GetRandomFigure();
                NextFigure.Initialize();
            }

            return current;
        }

        public Figure SpawnNext()
        {
            CurrentFigure = GetAnotherFigure();
            CurrentFigure.Initialize();
            CurrentFigure.Activate();
            return CurrentFigure;
        }

        public void ReturnFigure(Figure figure)
        {
            figure.Deactivate();
            figure.ResetPositions();
        }
    }
}