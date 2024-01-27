using UnityEngine;

[CreateAssetMenu(fileName = "HonkCardData", menuName = "GGJ24/Card Data/Honk")]
public class HonkCardData : CardData
{
    public HonkCardData()
    {
        executeAction = (ctx, jester) => {
            //ctx.Jester.ChangeDirectionByDegrees(new Vector3(0,0,270));
        };
    }
}
