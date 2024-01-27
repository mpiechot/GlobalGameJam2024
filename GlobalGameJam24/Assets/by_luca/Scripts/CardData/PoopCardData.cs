using UnityEngine;

[CreateAssetMenu(fileName = "PoopCardData", menuName = "GGJ24/Card Data/Poop")]
public class PoopCardData : CardData
{
    public PoopCardData()
    {
        executeAction = (ctx, jester) => {
            jester.ChangeDirectionByDegrees(new Vector3(0, 0, 180));
            jester.Flip();
            ctx.AudioPlayer.RequestSFX(SFXType.fuerKaka3);
        };
    }
}
