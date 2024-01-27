#nullable enable

using UnityEngine;

public abstract class ItemBase : MonoBehaviour
{
    [SerializeField]
    private int points;

    [SerializeField]
    private GameContext? gameContext;

    protected GameContext GameContext => gameContext != null ? gameContext : throw new SerializedFieldNotAssignedException();

    protected abstract void Execute(Jester jester);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("BAM");
        if (collision.gameObject.TryGetComponent<CollisionDetector>(out var detector))
        {
            Debug.Log("Executed");
            Execute(detector.Jester);
            if(points < 0)
            {
                GameContext.King.SubtractPoints(points);
            }
            else
            {
                GameContext.King.AddPoints(points);
            }
            
        }
    }
}
