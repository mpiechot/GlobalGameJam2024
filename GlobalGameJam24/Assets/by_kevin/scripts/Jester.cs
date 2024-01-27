using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Jester : MonoBehaviour
{
    public UnityEvent<Vector3> MovementSwitch = new UnityEvent<Vector3>();

    [SerializeField]
    private List<(JesterAction, Sprite)> jesterActions = new();

    [SerializeField]
    private Animator jesterWalk;

    [SerializeField]
    private float cellDistance;

    private Vector3 currentDirection = Vector3.up;

    private void Start()
    {
        MovementSwitch?.Invoke(currentDirection);
        jesterWalk.SetFloat("Horizontal", currentDirection.x);
        jesterWalk.SetFloat("Vertical", currentDirection.y);
    }

    public void ChangeDirection(Vector3 direction)
    {
        MovementSwitch?.Invoke(direction);
        jesterWalk.SetFloat("Horizontal", direction.x);
        jesterWalk.SetFloat("Vertical", direction.y);
    }

    public void ChangeDirectionByDegrees(Vector3 degrees)
    {
        Vector3 newDirection = Quaternion.Euler(degrees.x, degrees.y, degrees.z) * GetComponent<JesterMovement>().MovementDir;
        ChangeDirection(newDirection);
    }

    public void SpeedUp()
    {
        if(gameObject.GetComponent<Timer>() == null)
        {
            Timer timer = gameObject.AddComponent<Timer>();
            timer.Waittime = 1.0f;
            timer.OnTimeout += SpeedDown;
            timer.OneShot = true;
            timer.Run();
            GetComponent<JesterMovement>().SpeedModifier = 3.0f;
        }
        else
        {
            Timer timer = gameObject.GetComponent<Timer>();
            timer.UpdateWaittime(1.0f);
        }

    }

    private void SpeedDown()
    {
        GetComponent<JesterMovement>().SpeedModifier = 1.0f;
        Destroy(GetComponent<Timer>());
    }

    public void BackUp()
    {
        Debug.Log("BACKUP!");
        Vector3 currentMovement = GetComponent<JesterMovement>().MovementDir;
        transform.position -= cellDistance * currentMovement;
        MovementSwitch?.Invoke(-1 * currentMovement);
    }

    public void Flip()
    {
        jesterWalk.SetBool("Kacke", true);
    }

    public void Slip()
    {
        jesterWalk.SetBool("Slip", true);
    }

    public void Konfetti()
    {
        jesterWalk.SetBool("Konfetti", true);
    }

    public void Troete()
    {
        jesterWalk.SetBool("Troete", true);
    }

    public void Walk()
    {
        jesterWalk.SetBool("Konfetti", false);
        jesterWalk.SetBool("Troete", false);
        jesterWalk.SetBool("Slip", false);
        jesterWalk.SetBool("Kacke", false);
    }

    [Serializable]
    private enum JesterAction
    {
        Flip,
        Slip,
        Konfetti,
        Troete,
        Haufen,
    }
}
