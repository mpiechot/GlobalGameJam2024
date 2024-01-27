using System;
using UnityEngine;
using DG.Tweening;

public class Banana : ItemBase
{



    protected override void Execute(Jester jester)
    {

        jester.SpeedUp();

    }
}

