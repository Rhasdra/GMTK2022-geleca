using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class MouseManager : MonoBehaviour
{

    public UnityEvent OnMouseDown;
    public UnityEvent OnMouseUp;

    [SerializeField] Collider2D col;
    PointerEventData pointerEventData;

    private void Update() 
    {
        Hover();

        if (Input.GetMouseButtonDown(0))
        {
            MouseDown();
        }

        if (Input.GetMouseButtonUp(0))
        {
            MouseUp();
        }
    }

    private void Hover()
    {
        Vector3 pointerPosition = Input.mousePosition;

        Collider2D newCol;
        newCol = Physics2D.Raycast(pointerPosition, Vector2.right).collider;

        if(col != newCol)
        {
            col.GetComponent<IHoverable>().HoverExit();
            newCol.GetComponent<IHoverable>().HoverEnter();
            col = newCol;
        }

        Debug.Log(pointerPosition + " " + col);
    }

    private void MouseDown() 
    {
        
    }

    private void MouseUp() 
    {
        
    }

    private void MouseOverEnter(Collider2D col)
    {

    }

    private void MouseOverExit()
    {

    }

}
