using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveObject : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform m_DraggingPlane;

    // delegate
    public delegate void StartDrag();
    public event StartDrag onStartDrag;
    public delegate void EndDrag();
    public event EndDrag onEndDrag;
    // ---------
    public bool CanMove = true;

    public void OnBeginDrag(PointerEventData eventData)
    {
        onStartDrag?.Invoke();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (CanMove)
        {
            SetDraggedPosition(eventData);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        onEndDrag?.Invoke();
    }
    private void SetDraggedPosition(PointerEventData data)
    {
        if (data.pointerEnter != null && data.pointerEnter.transform as RectTransform != null)
            m_DraggingPlane = data.pointerEnter.transform as RectTransform;

        Vector3 globalMousePos;
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(m_DraggingPlane, data.position, data.pressEventCamera, out globalMousePos))
        {
            transform.position = globalMousePos;
        }
    }

  
}
