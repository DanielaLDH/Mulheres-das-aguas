
using UnityEngine;

public class CollectibleInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private string itemName = "Objeto de teste";

    private bool collected;

    public void Interact()
    {
        if (collected)
            return;

        collected = true;

        Debug.Log($"Objeto coletado: {itemName}");

        gameObject.SetActive(false);
    }
}
