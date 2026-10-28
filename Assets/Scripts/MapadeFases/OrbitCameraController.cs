
using UnityEngine;

public sealed class OrbitCameraController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform target;
    [SerializeField] private Camera orbitCamera;

    [Header("Rotation")]
    [SerializeField] private float sensitivity = 0.15f;
    [SerializeField] private float minPitch = -85f;
    [SerializeField] private float maxPitch = 85f;
    [SerializeField] private float smoothSpeed = 12f;

    [Header("Zoom")]
    [SerializeField] private float distance = 12f;
    [SerializeField] private float minDistance = 4f;
    [SerializeField] private float maxDistance = 20f;
    [SerializeField] private float zoomSensitivity = 0.15f;

    private float yaw;
    private float pitch;
    private float targetDistance;
    private Quaternion currentRotation;
    private float currentDistance;

    private void Awake()
    {
        if (target == null || orbitCamera == null)
        {
            Debug.LogError("Missing orbit references.", this);
            enabled = false;
            return;
        }

        if (maxDistance < minDistance)
            maxDistance = minDistance;

        Vector3 direction =
            target.position - orbitCamera.transform.position;

        if (direction.sqrMagnitude > 0.001f)
        {
            Quaternion initialRotation =
                Quaternion.LookRotation(direction.normalized);

            Vector3 angles = initialRotation.eulerAngles;

            yaw = angles.y;
            pitch = Mathf.DeltaAngle(0f, angles.x);
        }

        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);

        currentRotation = Quaternion.Euler(pitch, yaw, 0f);

        targetDistance = Mathf.Clamp(
            distance, minDistance, maxDistance);

        currentDistance = targetDistance;
        ApplyOrbit();
    }

    public void Rotate(Vector2 delta)
    {
        yaw += delta.x * sensitivity;
        pitch -= delta.y * sensitivity;

        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);
    }

    // Positive values bring the camera closer.
    public void Zoom(float steps)
    {
        targetDistance *= Mathf.Exp(
            -steps * zoomSensitivity);

        targetDistance = Mathf.Clamp(
            targetDistance, minDistance, maxDistance);
    }

    private void LateUpdate()
    {
        Quaternion desiredRotation =
            Quaternion.Euler(pitch, yaw, 0f);

        float t = smoothSpeed <= 0f
            ? 1f
            : 1f - Mathf.Exp(
                -smoothSpeed * Time.unscaledDeltaTime);

        currentRotation = Quaternion.Slerp(
            currentRotation, desiredRotation, t);

        currentDistance = Mathf.Lerp(
            currentDistance, targetDistance, t);

        ApplyOrbit();
    }

    private void ApplyOrbit()
    {
        Transform cam = orbitCamera.transform;

        cam.position = target.position -
            currentRotation * Vector3.forward * currentDistance;

        cam.rotation = currentRotation;
    }
}
