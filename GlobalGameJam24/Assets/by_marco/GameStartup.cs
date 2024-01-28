using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartup : MonoBehaviour
{
    [SerializeField]
    private GGJAudioPlayer? audioPlayer;

    [SerializeField]
    private GameContext? gameContext;

    [SerializeField]
    private King king;

    [SerializeField]
    private Jester jester;

    // Start is called before the first frame update
    void Start()
    {
        if(audioPlayer != null)
        {
            gameContext.AudioPlayer = audioPlayer;
        }
        if (jester != null)
        {
            gameContext.Jester = jester;
        }
        if (king != null)
        {
            gameContext.King = king;
        }
    }
}
