#nullable enable

using UnityEngine;

public abstract class ItemBase : MonoBehaviour
{
    protected int points;

    protected GameContext GameContext { get; private set; }

    protected abstract bool Execute(Jester jester);

    private void Start()
    {
        GameContext = GameContext.Instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        #region Early Exit + generate jester variable
        if (!collision.gameObject.transform.parent || !collision.gameObject.transform.parent.TryGetComponent<Jester>(out var jester)) return;
        #endregion
        
        if (points < 0)
        {
            GameContext.King.SubtractPoints(points);
        }
        else if(points > 0) 
        {
            GameContext.King.AddPoints(points);
        }

        if(Execute(jester))
            jester.transform.position = transform.position + jester.transform.position - collision.bounds.center; 
        // Don't do anything after here, Execute resets the state and will alter invisible fields. -.-
    }
}
