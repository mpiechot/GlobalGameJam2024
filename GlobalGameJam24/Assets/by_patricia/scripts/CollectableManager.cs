using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableManager : MonoBehaviour
{
    [SerializeField] List<Transform> cells;
    [SerializeField] Sprite lolSprite;
    [SerializeField] int collectableRespawnTime = 10;

    private Droppable previousDrop = null;
    private Droppable currentDrop = null;

    void Start()
    {
        StartCoroutine(CallFunctionRegularly());
    }

    IEnumerator CallFunctionRegularly()
    {
        while (true)
        {
            SpawnCollectable();
            yield return new WaitForSeconds(10);
        }
    }

    public void SpawnCollectable()
    {
        if (previousDrop != null)
        {
            previousDrop.ResetOccupiedState();
        }

        int index = UnityEngine.Random.Range(0, cells.Count);

        currentDrop = cells[index].GetComponent<Droppable>();
        currentDrop.Drop(new Collectable(lolSprite, (ctx, jester) => {
            ctx.King.AddPoints(5);
        }));
        previousDrop = currentDrop;
    }
}

public class Collectable
{
    public Action<GameContext, Jester> lolExecuteAction;       
    public Sprite lolSprite { get; }

    public Collectable(Sprite lolSprite, Action<GameContext, Jester> lolExecuteAction)
    {
        this.lolSprite = lolSprite;
        this.lolExecuteAction = lolExecuteAction;
    }
}
