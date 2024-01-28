using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    [SerializeField]
    private int _gameSceneIdx = 1;

    private bool _gameLoading;

    public void StartGame()
    {
        if (!_gameLoading)
        {
            _gameLoading = true;
            SceneManager.LoadScene(_gameSceneIdx, LoadSceneMode.Single);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartGame();
        }
    }
}
