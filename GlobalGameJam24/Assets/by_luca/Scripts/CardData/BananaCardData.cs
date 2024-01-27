using UnityEngine;

[CreateAssetMenu(fileName = "BananaCardData", menuName = "GGJ24/Card Data/Banana")]
public class BananaCardData : CardData
{
    public BananaCardData()
    {
        executeAction = (ctx, jester) => {
            Debug.Log("Got a context!");
        };
    }
}