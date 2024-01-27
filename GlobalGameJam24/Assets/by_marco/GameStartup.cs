using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartup : MonoBehaviour
{
    [SerializeField]
    private GGJAudioPlayer audioPlayer;

    [SerializeField]
    private GameContext gameContext;

    // Start is called before the first frame update
    void Start()
    {
        SerializedFieldNotAssignedException.ThrowIfNull(audioPlayer, nameof(audioPlayer));
        SerializedFieldNotAssignedException.ThrowIfNull(gameContext, nameof(gameContext));

        gameContext.AudioPlayer = audioPlayer;
    }
}
