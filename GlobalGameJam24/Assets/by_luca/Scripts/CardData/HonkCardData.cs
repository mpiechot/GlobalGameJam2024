using UnityEngine;

[CreateAssetMenu(fileName = "HonkCardData", menuName = "GGJ24/Card Data/Honk")]
public class HonkCardData : CardData
{
    public HonkCardData()
    {
        executeAction = (ctx, jester) => {
            jester.ChangeDirectionByDegrees(new Vector3(0, 0, 270));
            jester.Troete();
            ctx.AudioPlayer.RequestSFX(SFXType.Troete);
        };
    }
}
