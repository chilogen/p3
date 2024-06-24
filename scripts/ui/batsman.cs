
using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Batsman : MonoBehaviour, IPointerClickHandler
{

    private Vector2 _aimPoint = Vector2.zero;
    public static Batsman Instance;

    private void Awake()
    {
        Instance = this;
    }

    public Vector2 GetAimPoint()
    {
        return this._aimPoint;
    }

    public void ResetAimPoint()
    {
        this._aimPoint = Vector2.zero;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left) // Check for left mouse button
        {
            // Get the position where the click occurred relative to the UI element
            Vector2 localCursor;
            RectTransform rectTransform = GetComponent<RectTransform>();

            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                rectTransform, 
                eventData.position,
                eventData.pressEventCamera,
                out localCursor);

            Vector2 normalizedPosition = new Vector2(
                localCursor.x / (rectTransform.rect.width / 2),
                localCursor.y / (rectTransform.rect.height / 2));

            // Now normalizedPosition contains the position within the UI element in 0-1 range
            Debug.Log("Normalized Position: " + normalizedPosition);
            this._aimPoint = normalizedPosition;
        }
    }
}