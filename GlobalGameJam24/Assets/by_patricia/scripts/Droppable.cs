using System;
using UnityEngine;

public class Droppable : ItemBase
{
    [SerializeField]
    private bool occupied = false;

    public bool Occupied { get => occupied; }

    [SerializeReference] private SpriteRenderer sr; // Spriterenderer of the item, not the tile.

    private Action<GameContext, Jester> action;

    public bool Drop(CardData droppedData)
    {
        if (occupied)
        {
            return false;
        }
        occupied = true;
        sr.sprite = droppedData.sprite;
        action = droppedData.executeAction;
        return true;
    }

    public bool Drop(Collectable lol)
    {
        if (occupied)
        {
            return false;
        }
        occupied = true;
        sr.sprite = lol.lolSprite;
        action = lol.lolExecuteAction;
        return true;
    }

    public void ResetOccupiedState()
    {
        occupied = false;
        sr.sprite = null;
        action = null;
    }

    protected override void Execute(Jester jester)
    {
        if(action == null)
        {
            return;
        }

        action.Invoke(GameContext, jester);

        Debug.Log("BÄM");

        ResetOccupiedState();
    }
}
