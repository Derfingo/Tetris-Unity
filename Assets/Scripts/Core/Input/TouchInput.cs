using System;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;

namespace Core
{
    public class TouchInput : IInput
    {
        public event Action UpMove;
        public event Action DownMove;
        public event Action<Vector2> HorizontalMove;

        private readonly float _minDot = 0.8f;
        private readonly float _minDistance = 30f;
        private readonly double _minDurationTime = 0.2d;
        private double _startTouchTime;

        private Vector2 _startPosition;
        private Vector2 _movedPostion;
        private Vector2 _endedPosition;

        public TouchInput()
        {
            EnhancedTouchSupport.Enable();
        }

        private void DetectTouchPosition(Touch touch)
        {
            if (touch.phase == TouchPhase.Began)
            {
                _startPosition = touch.startScreenPosition;
                _startTouchTime = touch.startTime;
            }

            if (touch.phase == TouchPhase.Moved)
            {
                _movedPostion = touch.screenPosition;
                double timeDiffrence = touch.time - _startTouchTime;
                if (timeDiffrence > _minDurationTime)
                {
                    //DetectDrag();
                }
            }

            if (touch.phase == TouchPhase.Ended)
            {
                _endedPosition = touch.screenPosition;
                double timeDifference = touch.time - _startTouchTime;
                if (timeDifference < _minDurationTime)
                {
                    DetectSwipe();
                }
            }
        }

        private void DetectPressButtons()
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                HorizontalMove?.Invoke(Vector2.left);
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                HorizontalMove?.Invoke(Vector2.right);
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                UpMove?.Invoke();
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                DownMove?.Invoke();
            }
        }

        private void DetectPress()
        {
            HorizontalMove?.Invoke(_startPosition);
        }

        private void DetectSwipe()
        {
            var distance = Vector2.Distance(_endedPosition, _startPosition);
            if (distance > _minDistance)
            {
                var difference = (_endedPosition - _startPosition).normalized;
                if (Vector2.Dot(difference, Vector2.up) > _minDot)
                {
                    UpMove?.Invoke();
                }

                if (Vector2.Dot(difference, Vector2.down) > _minDot)
                {
                    DownMove?.Invoke();
                }
            }
            else
            {
                DetectPress();
            }
        }

        private void DetectDrag()
        {
            var distance = Vector2.Distance(_movedPostion, _startPosition);
            if (distance > _minDistance)
            {
                var difference = (_movedPostion - _startPosition).normalized;

                if (Vector2.Dot(difference, Vector2.down) > _minDot)
                {
                    DownMove?.Invoke();
                }
            }
        }

        public void UpdatePass()
        {
            DetectPressButtons();

            if (Touch.activeFingers.Count == 1)
            {
                Touch activeFinger = Touch.activeFingers[0].currentTouch;
                DetectTouchPosition(activeFinger);
            }
        }
    }
}
