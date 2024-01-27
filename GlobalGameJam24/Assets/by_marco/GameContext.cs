#nullable enable

using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameContext", menuName = "GGJ24/Game Context")]
public class GameContext : ScriptableObject
{
	[SerializeField]
	private GameObject? playerPrefab;

    [SerializeField]
    private GameObject? grid;

    [SerializeField]
    private GameObject? king;

    [SerializeField]
    private List<ItemBase> itemPrefabs = new();

    public GameObject PlayerPrefab => playerPrefab != null ? playerPrefab : throw new SerializedFieldNotAssignedException();

    public GameObject King => king != null ? king : throw new SerializedFieldNotAssignedException();

    public GameObject Grid => grid != null ? grid : throw new SerializedFieldNotAssignedException();

    public IReadOnlyList<ItemBase> ItemPrefabs => itemPrefabs;
}

