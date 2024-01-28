using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static OutroEventHandler;

public class EndingTile : ItemBase
{
    [SerializeField] private UnityEvent<GameOverState> OnGameOver;
    protected override void Execute(Jester jester)
    {
        OnGameOver?.Invoke(GameContext.Instance.King.IsKingHappy ? GameOverState.Laughter : GameOverState.Sadness);
    }
}
