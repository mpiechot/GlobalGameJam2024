using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutroEventHandler : MonoBehaviour
{

    [SerializeField] private GameOverContextSprite[] gameOverContextSprites;
    [SerializeField] private OutroAudioHandler outroAudioHandler;

    public enum GameOverState
    {
        Failure,
        Sadness,
        Laughter
    }

    public void HandleGameOver(GameOverState gameOverState)
    {
        foreach (var sprite in gameOverContextSprites)
        {
            sprite.HandleGameOver(gameOverState);
        }
        outroAudioHandler.TriggerGameOverAudio(gameOverState);
    }

    public void TestHandleGameOver(int gameOverState)
    {
        foreach (var sprite in gameOverContextSprites)
        {
            sprite.HandleGameOver((GameOverState)gameOverState);
        }
        outroAudioHandler.TriggerGameOverAudio((GameOverState)gameOverState);
    }

}
