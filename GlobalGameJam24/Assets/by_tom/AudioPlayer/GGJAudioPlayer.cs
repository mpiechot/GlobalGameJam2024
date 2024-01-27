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
    }

    public void RequestBGMusic(int bgMusicId)
    {
        bgmPlayer.SetNextTrack(bgMusicId, true);
    }

    public void RequestSFX(int sfxId)
    {
        sfxPlayer.RequestSFX(sfxId);
    }

}
