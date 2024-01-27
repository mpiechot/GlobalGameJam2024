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
        #region Early Exit + generate jester variable
        if (!collision.gameObject.transform.parent || !collision.gameObject.transform.parent.TryGetComponent<Jester>(out var jester)) return;
        #endregion

        Debug.Log("BAM");
        Debug.Log("Executed");
        Execute(jester);
        if (points < 0)
        {
            GameContext.King.SubtractPoints(points);
        }
        else
        {
            GameContext.King.AddPoints(points);
        }
    }
}
