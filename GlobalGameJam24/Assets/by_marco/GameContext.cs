#nullable enable

using System.Collections.Generic;
using UnityEngine;

public class GameContext : MonoBehaviour
{
    private static GameContext? instance = null;

    public static GameContext Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("GameContext").AddComponent<GameContext>();
                DontDestroyOnLoad(instance.gameObject);
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public Jester Jester { get; set; } = null!;

    public GameObject Grid { get; set; } = null!;
   
    public King King { get; set; } = null!;

    public GGJAudioPlayer AudioPlayer { get; set; } = null!;
}