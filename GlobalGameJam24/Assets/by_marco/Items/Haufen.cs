using System;
using UnityEngine;

public class Haufen : ItemBase
{
    protected override void Execute(Jester jester)
    {
        jester.ChangeDirectionByDegrees(new Vector3(0,0,180));
        jester.Flip();
        GameContext.AudioPlayer.RequestSFX(SFXType.fuerKaka3);
    }
}

