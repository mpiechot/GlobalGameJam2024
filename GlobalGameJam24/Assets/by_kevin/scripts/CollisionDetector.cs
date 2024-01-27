using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionDetector : MonoBehaviour
{

    public UnityEvent<Vector3> DirectionChange = new UnityEvent<Vector3>();
    public UnityEvent GameOverCollision = new UnityEvent();

    [SerializeField, Tooltip("Ref. to the Jester Script")]
    private Jester jester;

    public Jester Jester
    {
        get { return jester; }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.gameObject.GetComponent<ItemBase>() != null)
        {
            //collision.gameObject.GetComponent<ItemBase>().Execute(gameObject);

            /*Vector3 newDirection = collision.gameObject.GetComponent<DirectionChange>().NewDirection;
            DirectionChange?.Invoke(newDirection);*/
        }

    }



}
