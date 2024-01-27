using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Draggable : MonoBehaviour
{
    // requires event system in scene
    // requires collider on object
    // requires rigidbody on object

    [SerializeField]
    private LayerMask dropLayer;

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

    private Vector3 mouseDragStartPosition;
    private Vector3 spriteDragStartPosition;

    public UnityEvent OnSuccessfulDrop;

    private void OnMouseDown()
    {
        mouseDragStartPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        spriteDragStartPosition = transform.position;
    }

    private void OnMouseDrag()
    {
        transform.position = spriteDragStartPosition + (Camera.main.ScreenToWorldPoint(Input.mousePosition) - mouseDragStartPosition);
    }

    private void OnMouseUp()
    {
        Collider2D dropCollider = Physics2D.OverlapBox(transform.position, Vector2.one * 0.5f, 0, dropLayer);
        Droppable drop = dropCollider.GetComponent<Droppable>();
        if(drop && drop.Drop(_cardData)) 
        {
            OnSuccessfulDrop?.Invoke();
        }

        transform.position = spriteDragStartPosition;
    }

    //private void OnTriggerEnter2D(Collider2D collider)
    //{
    //    Droppable droppable = collider.GetComponent<Droppable>();
    //    if (droppable != null)
    //    {
    //        currDroppable = droppable;
    //    }
    //}

    //private void OnTriggerExit2D(Collider2D collider)
    //{
    //    if (currDroppable == collider.GetComponent<Droppable>())
    //    {
    //        currDroppable = null;
    //    }
    //}
}