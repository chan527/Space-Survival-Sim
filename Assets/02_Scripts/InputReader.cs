using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{
    public Vector2 MoveDirection { get; private set; }
    public Vector2 PointerPosition { get; private set; }

    public event Action OnInteractRequested;
    public event Action<Vector2> OnSelectRequested;
    public event Action<float> OnZoomRequested;
    public event Action OnEscapePressed;

    public void OnPoint(InputAction.CallbackContext context)
    {
        PointerPosition = context.ReadValue<Vector2>();
    }

    public void OnSelect(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;

        OnSelectRequested?.Invoke(PointerPosition);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (!context.performed && !context.canceled)
            return;

        MoveDirection = context.canceled ? Vector2.zero : context.ReadValue<Vector2>();
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;

        OnInteractRequested?.Invoke();
    }

    public void OnZoom(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;

        float zoomValue = context.ReadValue<float>();
        OnZoomRequested?.Invoke(zoomValue);
    }

    public void OnEscape(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;

        OnEscapePressed?.Invoke();
    }
}
