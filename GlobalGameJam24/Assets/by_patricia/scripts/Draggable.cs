using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    // requires event system in scene
    // requires collider on object
    // requires rigidbody on object

    private bool isDragged;
    private Vector3 mouseDragStartPosition;
    private Vector3 spriteDragStartPosition;
    private Droppable droppable;

    private void OnMouseDown()
    {
        isDragged = true;
        mouseDragStartPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        spriteDragStartPosition = transform.localPosition;
    }

    private void OnMouseDrag()
    {
        if (isDragged)
        {
            transform.localPosition = spriteDragStartPosition + (Camera.main.ScreenToWorldPoint(Input.mousePosition) - mouseDragStartPosition);
        }
    }

    private void OnMouseUp()
    {
        isDragged = false;

        if (droppable != null)
        {
            transform.position = droppable.transform.position;
        }
        else
        {
            transform.position = spriteDragStartPosition;
        }

        droppable = null;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Droppable droppable = collider.GetComponent<Droppable>();

        if (droppable != null && droppable.draggable == null)
        {
            droppable.draggable = this;
            this.droppable = droppable;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        Droppable droppable = collider.GetComponent<Droppable>();

        if (droppable != null && this.droppable == droppable)
        {
            this.droppable = null;
        }
    }
}
