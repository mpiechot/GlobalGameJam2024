using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    private Vector3 spriteDragStartPosition;
    private Vector3 initialMousePosition;
    private Vector3 initialGameObjectPosition;

    public UnityEvent OnSuccessfulDrop;
    public UnityEvent OnDragged;
    public UnityEvent<bool> OnDropped;

    private void OnMouseDown()
    {
        spriteDragStartPosition = transform.position;
        initialMousePosition = Input.mousePosition;
        initialGameObjectPosition = transform.position;
        OnDragged?.Invoke();
    }

    private void OnMouseDrag()
    {
        // Idk, this only works when we set the z position..
        Vector3 offset = new(0, 0, Camera.main.ScreenToWorldPoint(initialMousePosition).z);
        Vector3 targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - offset;
        transform.position = targetPosition;
    }

    private void OnMouseUp()
    {
        // Reset position
        transform.position = spriteDragStartPosition;

        Collider2D col = Physics2D.OverlapBoxAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.one * 2.5f, 0, dropLayer)
            .OrderBy(collider => Vector2.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition), collider.bounds.center))
            .FirstOrDefault(collider => collider.GetComponent<Droppable>());

        if (!col)
        {
            OnDropped?.Invoke(false);
        }
        else
        {
            Droppable drop = col.GetComponent<Droppable>();
            bool dropSuccess = drop != null && drop.Drop(_cardData);
            if (dropSuccess)
            {
                OnSuccessfulDrop?.Invoke();
            }
            OnDropped?.Invoke(dropSuccess);
        }
    }
}