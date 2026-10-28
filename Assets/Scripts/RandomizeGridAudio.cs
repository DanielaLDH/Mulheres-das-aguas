
using System.Collections.Generic;
using UnityEngine;

public class RandomizePrefabsInGrid : MonoBehaviour
{
    void Start()
    {
        List<Transform> items = new List<Transform>();

        foreach (Transform child in transform)
        {
            items.Add(child);
        }

        for (int i = 0; i < items.Count; i++)
        {
            int randomIndex = Random.Range(i, items.Count);

            Transform temp = items[i];
            items[i] = items[randomIndex];
            items[randomIndex] = temp;
        }

        for (int i = 0; i < items.Count; i++)
        {
            items[i].SetSiblingIndex(i);
        }
    }
}
