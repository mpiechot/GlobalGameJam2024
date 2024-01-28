using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRestarter : MonoBehaviour
{
    [ SerializeField]
    private int _menuSceneIdx = 0;

    public void GotoMenu()
    {
        SceneManager.LoadScene(_menuSceneIdx, LoadSceneMode.Single);
    }

    public void ReloadCurrentScene()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
}
