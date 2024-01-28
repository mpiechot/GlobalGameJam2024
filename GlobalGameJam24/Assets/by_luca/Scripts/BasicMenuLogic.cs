using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BasicMenuLogic : MonoBehaviour
{
    /// <summary>
    /// Menu to switch to when `GoBack` is called.
    /// </summary>
    [SerializeField]
    protected BasicMenuLogic backMenu;

    public UnityEvent OnVisible;
    public UnityEvent OnHidden;

    /// <summary>
    /// Disables the gameObject this component is attached to and activates the provided menu.
    /// </summary>
    /// <param name="menu">Menu to switch to.</param>
    public void GoToMenu(BasicMenuLogic menu)
    {
        menu.gameObject.SetActive(true);
        menu.OnVisible.Invoke();

        // Disable current Menu
        gameObject.SetActive(false);
        OnHidden.Invoke();
    }

    /// <summary>
    /// Switches to the menu set as `backMenu` unless it is `null`.
    /// </summary>
    public void GoBack()
    {
        if (backMenu != null)
        {
            GoToMenu(backMenu);
        }
        else
        {
            Debug.LogError("No menu provided to go back to, nothing will happen.");
        }
    }
}