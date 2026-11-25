
using UnityEngine;

public class MouseLock : MonoBehaviour
{
    private void Start()
    {
        LockCursor();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UnlockCursor();
        }

        if (Input.GetMouseButtonDown(0) &&
            Cursor.lockState != CursorLockMode.Locked)
        {
            LockCursor();
        }
    }


    private void OnApplicationFocus(bool hasFocus)
    {
        if (!hasFocus)
            UnlockCursor();
    }

    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void OnDisable()
    {
        UnlockCursor();
    }
}
