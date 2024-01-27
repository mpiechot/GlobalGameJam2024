using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : ItemBase
{

    protected override void Execute(Jester jester)
    {
        jester.BackUp();
    }

}
