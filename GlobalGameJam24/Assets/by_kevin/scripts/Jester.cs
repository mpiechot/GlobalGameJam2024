using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Jester : MonoBehaviour
{
    public UnityEvent<Vector3> MovementSwitch = new UnityEvent<Vector3>();

    public void ChangeDirection(Vector3 direction)
    {
        MovementSwitch?.Invoke(direction);
    }

    public void ChangeDirectionByDegrees(Vector3 degrees)
    {
        Vector3 newDirection = Quaternion.Euler(degrees.x, degrees.y, degrees.z) * GetComponent<JesterMovement>().MovementDir;
        MovementSwitch?.Invoke(newDirection);
    }
}
