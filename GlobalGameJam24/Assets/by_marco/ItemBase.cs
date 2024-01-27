#nullable enable

using UnityEngine;

public abstract class ItemBase : MonoBehaviour
{
    [SerializeField]
    private GameContext? gameContext;

    protected GameContext GameContext => gameContext != null ? gameContext : throw new SerializedFieldNotAssignedException();

    protected abstract void Execute(GameObject gameObject);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<GameObject>(out var player))
        {
            Execute(player);
        }
    }
}
