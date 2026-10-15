using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomizePrefabsInGrid : MonoBehaviour
{
    public GameObject[] prefabsToAdd; // Array com os 4 prefabs

    void Start()
    {
        RandomizeAndAddPrefabs();
    }

    void RandomizeAndAddPrefabs()
    {
        // Copia e embaralha a lista de prefabs
        List<GameObject> prefabsList = new List<GameObject>(prefabsToAdd);
        for (int i = 0; i < prefabsList.Count; i++)
        {
            GameObject temp = prefabsList[i];
            int randomIndex = Random.Range(i, prefabsList.Count);
            prefabsList[i] = prefabsList[randomIndex];
            prefabsList[randomIndex] = temp;
        }

        // Instancia os prefabs no grid
        foreach (GameObject prefab in prefabsList)
        {
            Instantiate(prefab, gameObject.transform);
        }
    }
}
