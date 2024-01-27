using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class MainMenuLogic : BasicMenuLogic
{
    [ SerializeField]
    private int _gameSceneIdx = 1;

    public void StartGame()
    {
        SceneManager.LoadScene(_gameSceneIdx, LoadSceneMode.Single);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}