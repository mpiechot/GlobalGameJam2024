using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class MainMenuLogic : BasicMenuLogic
{
    [field: SerializeField]
    public int gameSceneIdx = 1;

    public void StartGame()
    {
        SceneManager.LoadScene(gameSceneIdx, LoadSceneMode.Single);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}