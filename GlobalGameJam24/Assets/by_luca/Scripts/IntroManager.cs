using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    [SerializeField]
    private int _gameSceneIdx = 1;

    public void StartGame()
    {
        SceneManager.LoadScene(_gameSceneIdx, LoadSceneMode.Single);
    }
}
