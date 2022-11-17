using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

// why isnt this a IDraggable interface? idk either...
public class DragUI : IDragHandler
{
    // public void OnDrop(PointerEventData data)
    // {
    //     OnDropEvent(data);
    // }

    // For some reason the eventdata gives the pointer position
    // which i guess makes sense since it is the eventsystem 
    // that is handling the drag for the mouse not the draggable 
    // gameobject.
    // public void OnEndDrag(PointerEventData eventData)
    // {
    //     OnDropEvent(gameObject);
    // }
    
    [Inject (Id = "DragUI_GameObjectRectTransform")] readonly RectTransform _GameObjectRectTransform;
    [Inject (Id = "DragUI_Transform")] readonly Transform _Transform;
    [Inject (Id = "DragUI_ScreenCanvas")] readonly Canvas _ScreenCanvas;
    [Inject (Id = "DragUI_ScreenCanvasRectTransform")] readonly RectTransform _ScreenCanvasRectTransform;
    [Inject (Id = "MainCamera")] readonly Camera _Camera;

    /// <summary>
    /// Makes the icon draggable.
    /// </summary>
    public void OnDrag(PointerEventData eventdata)
    {
        Vector2 pos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(_ScreenCanvas.transform as RectTransform, eventdata.position, _Camera, out pos);

        Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        float width = _GameObjectRectTransform.rect.width * _GameObjectRectTransform.localScale.x;
        float height = _GameObjectRectTransform.rect.height * _GameObjectRectTransform.localScale.y;
        // Clamps the position of the dragged object to stay on the screen
        Vector2 newPos = new Vector2(
            Mathf.Clamp(pos.x, -((_ScreenCanvasRectTransform.rect.width) / 2) + (width / 2), (_ScreenCanvasRectTransform.rect.width / 2) - (width / 2)), 
            Mathf.Clamp(pos.y, -(_ScreenCanvasRectTransform.rect.height / 2) + (height / 2),  _ScreenCanvasRectTransform.rect.height / 2 - (height / 2))
        );
        _Transform.position = Vector3.Lerp(_Transform.position,_ScreenCanvas.transform.TransformPoint(newPos), Time.deltaTime * 60f);
    }
}
