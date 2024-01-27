public class Banana : ItemBase
{
    protected override void Execute(Jester jester)
    {
        jester.SpeedUp();
        GameContext.AudioPlayer.RequestSFX(SFXType.Flip1);
    }
}

