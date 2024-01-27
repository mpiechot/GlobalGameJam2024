using System;
using UnityEngine;

public class Troete : ItemBase
{
    protected override void Execute(Jester jester)
    {
        jester.ChangeDirectionByDegrees(new Vector3(0,0,270));
        jester.Troete();
        GameContext.AudioPlayer.RequestSFX(SFXType.Troete);
    }
}

