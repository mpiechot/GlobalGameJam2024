using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameOverCheck : MonoBehaviour
{

    public UnityEvent OnGameOver;

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Exited");
        OnGameOver?.Invoke();
    }

}
