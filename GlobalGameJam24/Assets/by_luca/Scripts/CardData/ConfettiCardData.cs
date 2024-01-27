using UnityEngine;

[CreateAssetMenu(fileName = "ConfettiCardData", menuName = "GGJ24/Card Data/Confetti")]
public class ConfettiCardData : CardData
{
    public ConfettiCardData()
    {
        executeAction = (ctx, jester) => {
            jester.ChangeDirectionByDegrees(new Vector3(0, 0, 90));
            jester.Konfetti();
            ctx.AudioPlayer.RequestSFX(SFXType.Confetti);
        };
    }
}
