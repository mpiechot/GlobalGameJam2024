using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static OutroEventHandler;

public class OutroAudioHandler : MonoBehaviour
{
    public void TriggerGameOverAudio(GameOverState gameOverState)
    {
        switch(gameOverState)
        {
            case GameOverState.Failure:
                GameContext.Instance.AudioPlayer.RequestBGMusic(8); // -> When Music is in the game, uncomment
                GameContext.Instance.AudioPlayer.RequestSFX(SFXType.Cry); // -> When SoundEffects are in the game, uncomment
                break;
            case GameOverState.Sadness:
                GameContext.Instance.AudioPlayer.RequestBGMusic(8);//  -> When Music is in the game, uncomment
                GameContext.Instance.AudioPlayer.RequestSFX(SFXType.Grumbling);//  -> When SoundEffects are in the game, uncomment
                break;
            case GameOverState.Laughter:
                GameContext.Instance.AudioPlayer.RequestBGMusic(8); // -> When Music is in the game, uncomment
                GameContext.Instance.AudioPlayer.RequestSFX(SFXType.Laugh); // -> When SoundEffects are in the game, uncomment
                break;
            default: break;
        }
    }

}
