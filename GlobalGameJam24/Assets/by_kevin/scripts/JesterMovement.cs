using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JesterMovement : MonoBehaviour
{
    [SerializeField, Tooltip("Initial direction")]
    private Vector3 movementDir = new(0, 0, 0);

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
    }

}
