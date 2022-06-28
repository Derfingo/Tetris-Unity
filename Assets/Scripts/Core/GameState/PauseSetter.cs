using System.Collections.Generic;

namespace Core
{
    public class PauseSetter : IPause
    {
        private readonly List<IPause> _handlers = new List<IPause>();

        public bool IsPaused { get; private set; }

        public void Register(IPause handler)
        {
            _handlers.Add(handler);
        }

        public void UnRegister(IPause handler)
        {
            _handlers.Remove(handler);
        }

        public void SetPause(bool isPaused)
        {
            IsPaused = isPaused;
            foreach (var handler in _handlers)
            {
                handler.SetPause(isPaused);
            }
        }
    }
}
