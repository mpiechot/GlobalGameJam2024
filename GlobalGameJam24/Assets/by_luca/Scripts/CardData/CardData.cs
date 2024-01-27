using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;


[Serializable]
public abstract class CardData : ScriptableObject
{
    public string title;
    public Sprite sprite;

    public Action<GameContext, Jester> executeAction;
}