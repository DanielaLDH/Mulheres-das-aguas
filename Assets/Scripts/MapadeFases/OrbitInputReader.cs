
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public sealed class OrbitInputReader : MonoBehaviour
{
    [SerializeField] private OrbitCameraController orbit;
    [SerializeField] private StageSelectionController selection;

    [Header("Interaction")]
    [SerializeField] private float dragThreshold = 12f;
    [SerializeField] private float scrollScale = 0.01f;
    [SerializeField] private float pinchScale = 0.01f;

    private bool tracking;
    private bool dragging;
    private bool trackingTouch;
    private bool pinching;

    private Vector2 startPosition;
    private Vector2 previousPosition;
    private float previousPinchDistance;

    private void Update()
    {
        if (orbit == null || selection == null)
            return;

        Touchscreen screen = Touchscreen.current;

        if (screen != null)
        {
            var first = screen.touches[0];
            var second = screen.touches[1];

            bool firstActive =
                first.press.isPressed ||
                first.press.wasReleasedThisFrame;

            bool secondActive = second.press.isPressed;

            if (first.press.isPressed && secondActive)
            {
                float distance = Vector2.Distance(
                    first.position.ReadValue(),
                    second.position.ReadValue());

                if (!pinching)
                {
                    pinching = true;
                    previousPinchDistance = distance;
                    tracking = false;
                }
                else
                {
                    float delta =
                        distance - previousPinchDistance;

                    orbit.Zoom(delta * pinchScale);
                    previousPinchDistance = distance;
                }

                return;
            }

            if (pinching)
            {
                if (!first.press.isPressed &&
                    !second.press.isPressed)
                {
                    pinching = false;
                    trackingTouch = false;
                }

                return;
            }

            if (firstActive)
            {
                if (first.press.wasPressedThisFrame)
                    trackingTouch = true;

                if (trackingTouch)
                {
                    ProcessPointer(
                        first.position.ReadValue(),
                        first.press.wasPressedThisFrame,
                        first.press.isPressed,
                        first.press.wasReleasedThisFrame);
                }

                if (first.press.wasReleasedThisFrame)
                    trackingTouch = false;

                return;
            }
        }

        if (trackingTouch)
            return;

        Mouse mouse = Mouse.current;
        if (mouse == null)
            return;

        if (mouse.scroll.ReadValue().y != 0f)
        {
            orbit.Zoom(
                mouse.scroll.ReadValue().y * scrollScale);
        }

        ProcessPointer(
            mouse.position.ReadValue(),
            mouse.leftButton.wasPressedThisFrame,
            mouse.leftButton.isPressed,
            mouse.leftButton.wasReleasedThisFrame);
    }

    private void ProcessPointer(
        Vector2 position,
        bool pressed,
        bool held,
        bool released)
    {
        if (pressed)
        {
            tracking = !IsOverUI(position);
            dragging = false;
            startPosition = position;
            previousPosition = position;
        }

        if (!tracking)
            return;

        if (held)
        {
            Vector2 total = position - startPosition;

            if (!dragging &&
                total.sqrMagnitude >=
                dragThreshold * dragThreshold)
            {
                dragging = true;
            }

            if (dragging)
            {
                orbit.Rotate(
                    position - previousPosition);
            }
        }

        if (released)
        {
            if (!dragging && !IsOverUI(position))
                selection.TrySelect(position);

            tracking = false;
            dragging = false;
        }

        previousPosition = position;
    }

    private bool IsOverUI(Vector2 position)
    {
        EventSystem system = EventSystem.current;

        if (system == null)
            return false;

        PointerEventData data =
            new PointerEventData(system)
            {
                position = position
            };

        List<RaycastResult> results =
            new List<RaycastResult>();

        system.RaycastAll(data, results);
        return results.Count > 0;
    }
}
