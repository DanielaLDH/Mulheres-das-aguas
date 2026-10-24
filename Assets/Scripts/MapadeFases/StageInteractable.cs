using UnityEngine;
using UnityEngine.Events;

public sealed class StageInteractable : MonoBehaviour
{
    [SerializeField] private string stageId;
    [SerializeField] private UnityEvent onSelected;

    public string StageId => stageId;

    public void Select()
    {
        onSelected?.Invoke();
    }
}
