using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    public UnityEvent OnDragged;
    public UnityEvent<bool> OnDropped;

    private void OnMouseDown()
    {
        mouseDragStartPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        spriteDragStartPosition = transform.position;
        OnDragged?.Invoke();
    }

    private void OnMouseDrag()
    {
        transform.position = spriteDragStartPosition + (Camera.main.ScreenToWorldPoint(Input.mousePosition) - mouseDragStartPosition);
    }

    private void OnMouseUp()
    {
        Collider2D dropCollider = Physics2D.OverlapBox(transform.position, Vector2.one * 0.01f, 0, dropLayer);
        Droppable drop = dropCollider != null ? dropCollider.GetComponent<Droppable>() : null;
        bool dropSuccess = drop != null && drop.Drop(_cardData);
        if(drop && dropSuccess) 
        {
            OnSuccessfulDrop?.Invoke();
        }

        OnDropped?.Invoke(dropSuccess);

        transform.position = spriteDragStartPosition;
    }
}