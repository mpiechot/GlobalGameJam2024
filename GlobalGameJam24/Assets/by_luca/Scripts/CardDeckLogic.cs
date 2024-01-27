using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CardDeckLogic : MonoBehaviour
{
    [SerializeField]
    private CardData[] _cardDatas;


    public UnityEvent OnCardDrawn;

    public void Start()
    {
        if (_cardDatas.Length <= 0)
        {
            Debug.LogError("Cards array is empty!!", this);
        }
    }

    public CardData DrawCardData()
    {
        int i = Random.Range(0, _cardDatas.Length);
        OnCardDrawn.Invoke();
        return _cardDatas[i];
    }
}