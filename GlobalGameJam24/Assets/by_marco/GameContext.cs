#nullable enable

using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameContext", menuName = "GGJ24/Game Context")]
public class GameContext : ScriptableObject
{
	[SerializeField]
	private JesterMovement? jester;

    [SerializeField]
    private GameObject? grid;

    [SerializeField]
    private King? king;

    [SerializeField]
    private List<ItemBase> itemPrefabs = new();

    public JesterMovement Jester => jester != null ? jester : throw new SerializedFieldNotAssignedException();

    public King King => king != null ? king : throw new SerializedFieldNotAssignedException();

    public GameObject Grid => grid != null ? grid : throw new SerializedFieldNotAssignedException();

    public IReadOnlyList<ItemBase> ItemPrefabs => itemPrefabs;

    public GGJAudioPlayer AudioPlayer { get; set; } = null!;
}

