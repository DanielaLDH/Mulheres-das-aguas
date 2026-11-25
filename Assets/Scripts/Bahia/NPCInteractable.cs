
using UnityEngine;

public class NPCInteractable : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log($"Interagindo com NPC: {gameObject.name}");
    }
}
