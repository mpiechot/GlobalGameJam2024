using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CardDeckLogic : MonoBehaviour
{
    [SerializeField]
    private CardData[] _cards;


    public UnityEvent OnCardDrawn;

    public void Start()
    {
        if (_cards.Length <= 0)
        {
            Debug.LogError("Cards array is empty!!", this);
        }
    }

    public CardData DrawCardData()
    {
        int i = Random.Range(0, _cards.Length);
        OnCardDrawn.Invoke();
        return _cards[i];
    }
}
