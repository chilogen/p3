using UnityEngine;
using UnityEngine.EventSystems;


namespace march3
{
    public class KeyboardAndMouseController: MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
    {
        
        public void OnPointerDown(PointerEventData eventData)
        {
            InputManager.SetStart(eventData.position);
        }

        public void OnDrag(PointerEventData eventData)
        {
            // Optionally handle dragging here
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            InputManager.SetEnd(eventData.position);
            InputManager.Launch();
        }
    }
}