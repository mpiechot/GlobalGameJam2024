using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GGJSFXPlayer : MonoBehaviour
{

    [SerializeField] private AudioClip[] sfxClips;

    private AudioSource[] sfxSources;
    int sfxPlayerIndex = 0;

    private void Awake()
    {
        sfxSources = GetComponentsInChildren<AudioSource>();
    }

    public void RequestSFX(int sfxIndex)
    {
        sfxSources[sfxPlayerIndex].Stop();
        sfxSources[sfxPlayerIndex].clip = sfxClips[sfxIndex];
        sfxSources[sfxPlayerIndex].Play();
        sfxPlayerIndex = (sfxPlayerIndex + 1) % sfxSources.Length;
    }


}
