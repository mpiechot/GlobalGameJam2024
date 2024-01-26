using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionChange : MonoBehaviour
{
    [SerializeField, Tooltip("Direction in which the Jester moves after collision")]
    private Vector3 newDirection = new Vector3(0, 0, 0);

    public Vector3 NewDirection
    {
        get { return newDirection; }
    }

}
