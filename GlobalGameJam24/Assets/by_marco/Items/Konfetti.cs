﻿using System;
using UnityEngine;

public class Konfetti : ItemBase
{
    protected override void Execute(Jester jester)
    {
        jester.ChangeDirectionByDegrees(new Vector3(0,0,90));
        GameContext.AudioPlayer.RequestSFX(SFXType.Confetti);
    }
}
