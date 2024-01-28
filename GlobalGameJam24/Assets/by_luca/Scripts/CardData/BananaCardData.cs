using UnityEngine;

[CreateAssetMenu(fileName = "BananaCardData", menuName = "GGJ24/Card Data/Banana")]
public class BananaCardData : CardData
{
    public BananaCardData()
    {
        executeAction = (ctx, jester) => {
            jester.Slip();
            ctx.AudioPlayer.RequestSFX(SFXType.Flip1);
        };
    }
}