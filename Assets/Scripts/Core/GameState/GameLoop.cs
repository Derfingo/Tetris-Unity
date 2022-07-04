using System;
using UnityEngine;

namespace Core
{
    public class GameLoop : MonoBehaviour, IPause
    {
        [SerializeField] private AnimationCurve _timeSpeed;
        private FigureControl _figureControl;
        private TouchInput _touchInput;

        private readonly float _timeDelay = 1f;
        private float _timeStep = 0f;
        private float _elapsedTime = 0f;


        private bool _isPause;

        public void Initialize(FigureControl figureControl, TouchInput touchInput)
        {
            _figureControl = figureControl;
            _touchInput = touchInput;
        }

        private void Update()
        {
            if (_isPause)
            {
                float delta = Time.deltaTime;

                _touchInput.UpdatePass();

                _timeStep += delta;
                _elapsedTime += delta;
                double timePlaying = TimeSpan.FromSeconds(_elapsedTime).TotalSeconds;

                if (_timeStep > _timeDelay)
                {
                    _figureControl.UpdatePass();
                    _timeStep = _timeSpeed.Evaluate((float)timePlaying);
                }
            }
        }

        public void ResetTime()
        {
            _timeStep = 0f;
            _elapsedTime = 0;
        }

        public void SetPause(bool isPaused)
        {
            _isPause = isPaused;
        }
    }
}
