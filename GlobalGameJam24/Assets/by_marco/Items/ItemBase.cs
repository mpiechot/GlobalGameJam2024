#nullable enable

using UnityEngine;

public abstract class ItemBase : MonoBehaviour
{
    [SerializeField]
    private int points;

    protected GameContext GameContext { get; private set; }

    protected abstract void Execute(Jester jester);

    private void Start()
    {
        GameContext = GameContext.Instance;
    }

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
