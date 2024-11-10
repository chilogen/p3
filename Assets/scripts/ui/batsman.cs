using TMPro;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class Batsman : MonoBehaviour, IPointerClickHandler
{

    private Vector2 _aimPoint = Vector2.zero;
    private Image _pointImage;
    private RectTransform _selfTransform;
    
    public static Batsman Instance;
    public Image pointPrefab;

    private void Awake()
    {
        Instance = this;
        _selfTransform = GetComponent<RectTransform>();
        
        _pointImage = Instantiate(pointPrefab, _selfTransform);
        _pointImage.rectTransform.localScale = _selfTransform.localScale * 0.15f;
        _pointImage.rectTransform.anchoredPosition = new Vector2(0,0);
    }

    //the origin point at the center and range [-0.5, 0.5]
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
            Vector2 localCursor;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                _selfTransform,
                eventData.position,
                eventData.pressEventCamera,
                out localCursor);

            _pointImage.rectTransform.anchoredPosition = localCursor;

            this._aimPoint.x = localCursor.x / _selfTransform.rect.width;
            this._aimPoint.y = localCursor.y / _selfTransform.rect.height;
        }
    }
}