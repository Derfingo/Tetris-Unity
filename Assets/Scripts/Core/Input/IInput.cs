using System;
using UnityEngine;

namespace Core
{
    public interface IInput
    {
        public event Action UpMove;
        public event Action DownMove;
        public event Action<Vector2> HorizontalMove;
    }
}

