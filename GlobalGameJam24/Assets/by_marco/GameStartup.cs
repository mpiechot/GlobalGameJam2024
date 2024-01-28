using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartup : MonoBehaviour
{
    [SerializeField]
    private GGJAudioPlayer? audioPlayer;

    [SerializeField]
    private King king;

    [SerializeField]
    private Jester jester;

    // Start is called before the first frame update
    void Start()
    {
        if(audioPlayer != null)
        {
            GameContext.Instance.AudioPlayer = audioPlayer;
        }
        if (jester != null)
        {
            GameContext.Instance.Jester = jester;
        }
        if (king != null)
        {
            GameContext.Instance.King = king;
        }
    }
}
