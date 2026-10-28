using UnityEngine;

public sealed class StageSelectionController : MonoBehaviour
{
    [SerializeField] private Camera selectionCamera;
    [SerializeField] private LayerMask selectableLayers;
    [SerializeField] private float maxDistance = 100f;

    public void TrySelect(Vector2 screenPosition)
    {
        Ray ray = selectionCamera.ScreenPointToRay(
            screenPosition
        );

        if (!Physics.Raycast(
                ray,
                out RaycastHit hit,
                maxDistance,
                selectableLayers))
        {
            return;
        }

        StageInteractable stage =
            hit.collider.GetComponentInParent<
                StageInteractable>();

        if (stage != null)
            stage.Select();
    }
}
