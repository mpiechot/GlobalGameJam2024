using System;
using UnityEngine;
using DG.Tweening;

public class Banana : ItemBase
{
    protected override void Execute(GameObject gameObject)
    {
        //ToDo Play
        

        GameContext.Jester.ChangeDirection(Vector3.left);
    }
}

