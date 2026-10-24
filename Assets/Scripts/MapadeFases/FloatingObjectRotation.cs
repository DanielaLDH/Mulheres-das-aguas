
using UnityEngine;

public sealed class FloatingObjectRotation : MonoBehaviour
{
    [Header("Rotation")]
    [SerializeField]
    private Vector3 rotationSpeed =
        new Vector3(0f, 10f, 0f);

    [SerializeField] private Space rotationSpace = Space.Self;

    private void Update()
    {
        transform.Rotate(
            rotationSpeed * Time.deltaTime,
            rotationSpace
        );
    }
}
