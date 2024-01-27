using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    // requires event system in scene
    // requires collider on object
    // requires rigidbody on object

    [SerializeField]
    private SpriteRenderer _visuals;

    [SerializeField]
    private CardData _cardData;
    public CardData CardData
    {
        get => _cardData;
        set
        {
            _cardData = value;

            if (_cardData != null && _visuals != null)
            {
                _visuals.sprite = _cardData.sprite;
            }
        }
    }

    private bool isPlaced = false;
    private Vector3 mouseDragStartPosition;
    private Vector3 spriteDragStartPosition;
    private Droppable currDroppable;

    private void OnMouseDown()
    {
        if (!isPlaced)
        {
            mouseDragStartPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            spriteDragStartPosition = transform.position;
        }
    }

    private void OnMouseDrag()
    {
        if (!isPlaced)
        {
            transform.position = spriteDragStartPosition + (Camera.main.ScreenToWorldPoint(Input.mousePosition) - mouseDragStartPosition);
        }
    }

    private void OnMouseUp()
    {
        if (!isPlaced)
        {
            if (currDroppable != null && !currDroppable.occupied)
            {
                transform.position = currDroppable.transform.position;
                isPlaced = true;

                currDroppable.occupied = true;
            }
            else
            {
                transform.position = spriteDragStartPosition;
            }
            currDroppable = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Droppable droppable = collider.GetComponent<Droppable>();
        if (droppable != null)
        {
            currDroppable = droppable;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (currDroppable == collider.GetComponent<Droppable>())
        {
            currDroppable = null;
        }
    }
}
