
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractor : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Camera playerCamera;
    [SerializeField] private InputActionReference interactAction;

    [Header("Interaction")]
    [SerializeField, Min(0.1f)]
    private float interactionDistance = 2.5f;

    [SerializeField] private LayerMask interactionMask = ~0;

    private void OnEnable()
    {
        interactAction?.action.Enable();
    }

    private void OnDisable()
    {
        interactAction?.action.Disable();
    }

    private void Update()
    {
        if (playerCamera == null || interactAction == null)
            return;

        if (!interactAction.action.WasPressedThisFrame())
            return;

        Ray ray = playerCamera.ViewportPointToRay(
            new Vector3(0.5f, 0.5f, 0f)
        );

        if (Physics.Raycast(
            ray,
            out RaycastHit hit,
            interactionDistance,
            interactionMask,
            QueryTriggerInteraction.Ignore))
        {
            IInteractable interactable =
                hit.collider.GetComponentInParent<IInteractable>();

            interactable?.Interact();
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (playerCamera == null)
            return;

        Gizmos.color = Color.yellow;

        Gizmos.DrawRay(
            playerCamera.transform.position,
            playerCamera.transform.forward * interactionDistance
        );
    }
}
