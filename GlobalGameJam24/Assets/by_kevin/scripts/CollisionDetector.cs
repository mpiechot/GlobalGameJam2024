using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionDetector : MonoBehaviour
{

    public UnityEvent<Vector3> DirectionChange = new UnityEvent<Vector3>();
    public UnityEvent GameOverCollision = new UnityEvent();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("BAM");

        //if(collision.gameObject.GetComponent<GameOver>() != null)
        if(collision.gameObject.GetComponent<DirectionChange>() != null)
        {
            Vector3 newDirection = collision.gameObject.GetComponent<DirectionChange>().NewDirection;
            DirectionChange?.Invoke(newDirection);
        }
    }



}
