using UnityEngine;

namespace Core
{
    public class GameLoop : MonoBehaviour, IPause
    {
        [SerializeField] private AnimationCurve _timeSpeed;
        private FigureControl _figureControl;
        private TouchInput _touchInput;
        private PlayerStatus _playerStatus;

        private readonly float _timeDelay = 1f;
        private float _timeStep = 0f;

        private bool _isPause;

        public void Initialize(FigureControl figureControl, TouchInput touchInput, PlayerStatus playerStatus)
        {
            _figureControl = figureControl;
            _touchInput = touchInput;
            _playerStatus = playerStatus;
        }

        private void Update()
        {
            if (_isPause)
            {
                float realTime = Time.realtimeSinceStartup;
                float delta = Time.deltaTime;

                _touchInput.UpdatePass();

                _timeStep += delta;

                if (_timeStep > _timeDelay)
                {
                    _figureControl.UpdatePass();
                    _timeStep = _timeSpeed.Evaluate(realTime);
                }
            }
        }

        public void SetPause(bool isPaused)
        {
            _isPause = isPaused;
        }
    }
}
