using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static OutroEventHandler;

public class OutroAudioHandler : MonoBehaviour
{
    [SerializeReference] private GameContext gameContext;
    public void TriggerGameOverAudio(GameOverState gameOverState)
    {
        switch(gameOverState)
        {
            case GameOverState.Failure: 
                //gameContext.AudioPlayer.RequestBGMusic(0); -> When Music is in the game, uncomment 
                //gameContext.AudioPlayer.RequestSFX(0); -> When SoundEffects are in the game, uncomment
                break;
            case GameOverState.Sadness:
                //gameContext.AudioPlayer.RequestBGMusic(1); -> When Music is in the game, uncomment 
                //gameContext.AudioPlayer.RequestSFX(1); -> When SoundEffects are in the game, uncomment
                break;
            case GameOverState.Laughter:
                //gameContext.AudioPlayer.RequestBGMusic(2); -> When Music is in the game, uncomment 
                //gameContext.AudioPlayer.RequestSFX(2); -> When SoundEffects are in the game, uncomment
                break;
            default: break;
        }
    }

}
