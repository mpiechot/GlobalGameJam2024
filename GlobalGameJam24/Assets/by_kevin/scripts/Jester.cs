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
    private AnimationClip jesterWalk;

    [SerializeField]
    private float cellDistance;

    public void ChangeDirection(Vector3 direction)
    {
        MovementSwitch?.Invoke(direction);
    }

    public void ChangeDirectionByDegrees(Vector3 degrees)
    {
        Vector3 newDirection = Quaternion.Euler(degrees.x, degrees.y, degrees.z) * GetComponent<JesterMovement>().MovementDir;
        MovementSwitch?.Invoke(newDirection);
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

    }

    public void Slip()
    {

    }

    public void Konfetti()
    {

    }

    public void Troete()
    {

    }

    private enum JesterAction
    {
        Flip,
        Slip,
        Konfetti,
        Troete,
        Haufen,
    }
}
