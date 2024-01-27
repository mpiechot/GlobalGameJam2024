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
    private Transform _visuals;

    [SerializeField]
    private Draggable _draggable;

    [SerializeField]
    private HandCardScaler _handCardScaler;


    private void Start()
    {
        if (_cardDeckLogic != null)
        {
            DrawNewCard();
        }
        else
        {
            Debug.Log($"No Card Deck logic set for '{gameObject.name}'!", this);
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

    public void DrawNewCard() => Display(_cardDeckLogic.DrawCardData());

    public void GrowVisuals() => _handCardScaler?.GrowVisuals();
    public void ShrinkVisuals() => _handCardScaler?.ShrinkVisuals();
}
