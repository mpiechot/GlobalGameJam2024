using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class JesterMovement : MonoBehaviour
{
    public UnityEvent OnDirectionChange;

    [SerializeField, Tooltip("Initial direction")]
    private Vector3 movementDir = new(0, 0, 0);

    public Vector3 MovementDir
    {
        get { return movementDir; }
    }

    [SerializeField, Tooltip("Movement Speed")]
    private float movementSpeed = 1.0f;

    // Update is called once per frame
    void Update()
    {
        transform.position += Time.deltaTime * movementSpeed * movementDir;
    }

    public void ChangeDirection(Vector3 newDirection)
    {
        movementDir = newDirection;
        OnDirectionChange?.Invoke();
    }

}
