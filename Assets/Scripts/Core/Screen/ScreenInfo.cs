using UnityEngine;

namespace Core
{
    public class ScreenInfo
    {
        private readonly int _halfScreenWidth;
        public int HalfScreenWidth => _halfScreenWidth;
        public ScreenInfo()
        {
            _halfScreenWidth = Screen.width / 2;
        }
    }
}
