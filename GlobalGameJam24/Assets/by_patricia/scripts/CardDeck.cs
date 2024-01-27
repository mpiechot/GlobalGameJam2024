using System;
using System.Collections.Generic;
using UnityEngine;

public class CardDeck : MonoBehaviour
{
    public int playerCardAmount = 5;

    [SerializeField] List<Transform> slots;

    private List<Card> playerCards; // contains the player`s current cards
    
    void Start()
    {
        playerCards = new List<Card>();

        for (int i = 0; i < playerCardAmount; i++)
        {
            Card drawnCard = DrawCard();
            playerCards.Add(drawnCard);
            Debug.Log($"Drawn card: {drawnCard.type}");
        }
    }

    public Card DrawCard() // choose random card to add to player's hand
    {
        int index = UnityEngine.Random.Range(0, Enum.GetNames(typeof(CardType)).Length);

        GameObject willBeCard = new GameObject();
        Card card = willBeCard.AddComponent<Card>();
        card.type = (CardType)Enum.GetValues(typeof(CardType)).GetValue(index);
        Destroy(willBeCard);

        return card;
    }

    public void TrashCard(int index) // remove chosen card from player's hand
    {
        playerCards.RemoveAt(index);
    }
}
