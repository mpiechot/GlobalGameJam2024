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

    public Action<GameContext> executeAction;
}

[CreateAssetMenu(fileName = "BananaCardData", menuName = "GGJ24/Card Data/Banana")]
public class BananaCardData : CardData
{
    public BananaCardData()
    {
        executeAction = (ctx) => {
            Debug.Log("Got a context!");
        };
    }
}