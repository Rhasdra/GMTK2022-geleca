using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    Transform position;

    [SerializeField] float bigScale = 1.1f;
    Vector3 initialScale;
    Vector3 initialPosition;
    Vector3 cursorPosition;

    private float startPosX;
    private float startPosY;

    private void Awake() {
        initialScale = transform.localScale;        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        transform.localScale = new Vector3 (initialScale.x * bigScale, initialScale.y * bigScale, initialScale.z);
        initialPosition = transform.position;

        Vector3 mousePos;
        mousePos = eventData.position;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        startPosX = mousePos.x - this.transform.position.x;
        startPosY = mousePos.y - this.transform.position.y;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 mousePos;
        mousePos = eventData.position;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        transform.position = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, 0);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        transform.localScale = initialScale;
    }
}
