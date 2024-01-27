using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class HandCard : MonoBehaviour
{
    [SerializeField]
    public TMP_Text itemTitleText;

    [SerializeField]
    private Transform draggableTransform;

    [SerializeField]
    private GameObject[] _draggablePrefabs;


    public void Display(CardData data)
    {
        itemTitleText.text = data.title;

        GameObject toInstantiate = FindDragablePrefab(data.title);
        GameObject draggableGo = Instantiate(toInstantiate, draggableTransform);
        if (draggableGo.transform.TryGetComponent(out Draggable draggable))
        {
            draggable.SetSprite(data.sprite);
        }
        else
        {
            Debug.LogError($"Prefab '{ data.title }' did not have a Draggable component", this);
        }
    }

    public void Clear()
    {
        itemTitleText.text = "";
    }

    // Make sure the prefab has the same name as in the card data (otherwise it wont work:P)
    public GameObject FindDragablePrefab(string draggableTitle) => _draggablePrefabs.First(x => x.name == draggableTitle);
}
