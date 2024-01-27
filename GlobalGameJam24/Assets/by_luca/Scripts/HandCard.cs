using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class HandCard : MonoBehaviour
{
    [SerializeField]
    private CardDeckLogic _cardDeckLogic;

    [SerializeField]
    private TMP_Text _itemTitleText;

    [SerializeField]
    private Transform draggableTransform;

    [SerializeField]
    private GameObject[] _draggablePrefabs;

    [SerializeField]
    private Draggable _draggable;


    private void Start()
    {
        if (_cardDeckLogic != null)
        {
            Display(_cardDeckLogic.DrawCardData());
        }
        else
        {
            Debug.Log($"No Card Deck logic set for '{ gameObject.name }'!", this);
        }
    }


    public void Display(CardData data)
    {
        _itemTitleText.text = data.title;

        _draggable.CardData = data;
    }

    public void Clear()
    {
        _itemTitleText.text = "";
        _draggable.CardData = null;
    }
}
