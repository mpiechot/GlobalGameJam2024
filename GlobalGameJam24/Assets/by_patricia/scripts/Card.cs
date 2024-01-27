using UnityEngine;

public class Card : MonoBehaviour
{
    public CardType type { get; set; }
}

public enum CardType
{
    Banana,
    Honk,
    Poop,
    Confetti
}
