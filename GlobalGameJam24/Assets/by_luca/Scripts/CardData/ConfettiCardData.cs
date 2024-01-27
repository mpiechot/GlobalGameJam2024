using UnityEngine;

[CreateAssetMenu(fileName = "ConfettiCardData", menuName = "GGJ24/Card Data/Confetti")]
public class ConfettiCardData : CardData
{
    public ConfettiCardData()
    {
        executeAction = (ctx, jester) => {
            //ctx.Jester.ChangeDirectionByDegrees(new Vector3(0,0,270));
        };
    }
}
