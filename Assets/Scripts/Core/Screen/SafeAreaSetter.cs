using UnityEngine;

namespace Core
{
    [RequireComponent(typeof(RectTransform))]
    public class SafeAreaSetter : MonoBehaviour
    {
        [SerializeField] private Canvas _canvas;
        private RectTransform _panelSaveArea;
        private Rect _currentSaveArea;
        private ScreenOrientation _currentOrientation;

        public void Initialize()
        {
            _panelSaveArea = GetComponent<RectTransform>();

            _currentSaveArea = new Rect();
            _currentOrientation = ScreenOrientation.Portrait;
            _currentSaveArea = Screen.safeArea;

            ApplySafeArea();
        }

        private void ApplySafeArea()
        {
            Rect safeArea = Screen.safeArea;

            Vector2 anchorMin = safeArea.position;
            Vector2 anchorMax = safeArea.position + safeArea.size;

            anchorMin.x /= _canvas.pixelRect.width;
            anchorMax.y /= _canvas.pixelRect.height;

            anchorMin.x /= _canvas.pixelRect.width;
            anchorMax.y /= _canvas.pixelRect.height;

            _panelSaveArea.anchorMin = anchorMin;
            _panelSaveArea.anchorMax = anchorMax;

            _currentOrientation = Screen.orientation;
            _currentSaveArea = Screen.safeArea;
        }
    }
}
