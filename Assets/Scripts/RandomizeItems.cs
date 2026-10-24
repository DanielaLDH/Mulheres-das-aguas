
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomizeItems : MonoBehaviour
{
    [SerializeField] private ItemThrowDrop[] objects;
    [SerializeField] private Image[] items;

    private void Awake()
    {
        Randomize();
    }

    private void Randomize()
    {
        if (items.Length > objects.Length)
        {
            Debug.LogError("Existem mais itens do que objetos disponíveis.");
            return;
        }

        List<ItemThrowDrop> availableObjects =
            new List<ItemThrowDrop>(objects);

        foreach (Image item in items)
        {
            item.gameObject.SetActive(false);
        }

        foreach (ItemThrowDrop obj in availableObjects)
        {
            obj.dropImage = null;
        }

        // Embaralha os objetos disponíveis
        for (int i = 0; i < availableObjects.Count; i++)
        {
            int randomIndex = Random.Range(i, availableObjects.Count);

            ItemThrowDrop temp = availableObjects[i];
            availableObjects[i] = availableObjects[randomIndex];
            availableObjects[randomIndex] = temp;
        }

        // Distribui os itens
        for (int i = 0; i < items.Length; i++)
        {
            availableObjects[i].dropImage = items[i];
        }
    }
}
