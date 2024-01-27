using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GGJBGMusicPlayer : MonoBehaviour
{

    [SerializeField] private AudioClip[] bgMusicClips;

    private AudioSource[] bgMusicSources;
    int initialMusic = 0;
    int activePlayer = 0;

    private Coroutine fadeTrackRoutine;

    private void Awake()
    {
        bgMusicSources = GetComponents<AudioSource>();
    }

    private void Start()
    {
        bgMusicSources[activePlayer].clip = bgMusicClips[initialMusic];
        bgMusicSources[activePlayer].volume = 1;
        bgMusicSources[activePlayer].Play();
    }

    public void SetNextTrack(int trackNumber, bool fade)
    {
        if (fade) FadeNextTrack(trackNumber);
        else NoFadeNextTrack(trackNumber);
    }

    private void NoFadeNextTrack(int trackNumber)
    {
        bgMusicSources[activePlayer].Stop();
        bgMusicSources[activePlayer].clip = bgMusicClips[trackNumber];
        bgMusicSources[activePlayer].volume = 1;
        bgMusicSources[activePlayer].Play();
    }

    private void FadeNextTrack(int trackNumber)
    {
        if(fadeTrackRoutine != null)
        {
            bgMusicSources[(activePlayer + 1) % bgMusicSources.Length].Stop(); // Stop next track if it hasn't been loaded properly
            StopCoroutine(fadeTrackRoutine);
        }
        fadeTrackRoutine = StartCoroutine(NextTrack(trackNumber));
    }

    private IEnumerator NextTrack(int trackNumber)
    {
        int nextPlayer = (activePlayer + 1) % bgMusicSources.Length;

        bgMusicSources[activePlayer].volume = 1f;
        bgMusicSources[nextPlayer].volume = 0f;
        
        bgMusicSources[nextPlayer].clip = bgMusicClips[trackNumber];
        bgMusicSources[nextPlayer].Play();

        int steps = 30; 
        for (int step = 0; step < steps; step++)
        {
            bgMusicSources[activePlayer].volume -= 1.0f / steps;
            bgMusicSources[nextPlayer].volume += 1.0f / steps;
            yield return new WaitForSeconds(0.03f);
        }
        bgMusicSources[activePlayer].volume = 0f;
        bgMusicSources[activePlayer].Stop();
        bgMusicSources[nextPlayer].volume = 1f;
        activePlayer = nextPlayer;
        yield return null;
    }

}
