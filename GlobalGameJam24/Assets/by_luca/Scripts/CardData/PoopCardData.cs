using UnityEngine;

[CreateAssetMenu(fileName = "PoopCardData", menuName = "GGJ24/Card Data/Poop")]
public class PoopCardData : CardData
{
    public PoopCardData()
    {
        executeAction = (ctx, jester) => {
            //ctx.Jester.BackUp();
        };
    }
}
