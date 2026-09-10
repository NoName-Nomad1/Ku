using UnityEngine;
using UnityEngine.EventSystems;

namespace QazaqCity.UI
{
    public class MobileJoystick : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
    {
        [SerializeField] private RectTransform background;
        [SerializeField] private RectTransform handle;
        [SerializeField] private float radius = 90f;

        public Vector2 Input { get; private set; }

        public void OnPointerDown(PointerEventData eventData) => OnDrag(eventData);

        public void OnDrag(PointerEventData eventData)
        {
            if (background == null || handle == null) return;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(background, eventData.position, eventData.pressEventCamera, out var local);
            Input = Vector2.ClampMagnitude(local / radius, 1f);
            handle.anchoredPosition = Input * radius;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            Input = Vector2.zero;
            if (handle != null) handle.anchoredPosition = Vector2.zero;
        }
    }
}
