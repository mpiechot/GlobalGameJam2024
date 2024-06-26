using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GGJAudioPlayer : MonoBehaviour
{

    private GGJBGMusicPlayer bgmPlayer;
    private GGJSFXPlayer sfxPlayer;

    private void Start()
    {
        bgmPlayer = GetComponentInChildren<GGJBGMusicPlayer>();
        sfxPlayer = GetComponentInChildren<GGJSFXPlayer>();
        DontDestroyOnLoad(this);
    }

    public void StopBGMusic()
    {
        bgmPlayer.Stop();
    }
    public void RequestBGMusic(int bgMusicId)
    {
        bgmPlayer.SetNextTrack(bgMusicId, true);
    }

    public void RequestSFX(SFXType sfx)
    {
        sfxPlayer.RequestSFX((int)sfx);
    }

    public void StopSFX(SFXType sfx)
    {
        sfxPlayer.StopSFX((int)sfx);
    }

}
