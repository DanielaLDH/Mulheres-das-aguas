using UnityEngine;

public class MinimizeOnEsc : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
#if UNITY_STANDALONE_WIN
            MinimizeWindow();
#elif UNITY_EDITOR
            Debug.Log("Minimize would trigger here (Editor)");
#endif
        }
    }

#if UNITY_STANDALONE_WIN
    [System.Runtime.InteropServices.DllImport("user32.dll")]
    private static extern bool ShowWindow(System.IntPtr hWnd, int nCmdShow);
    [System.Runtime.InteropServices.DllImport("user32.dll")]
    private static extern System.IntPtr GetActiveWindow();
    const int SW_MINIMIZE = 6;

    private void MinimizeWindow()
    {
        System.IntPtr hWnd = GetActiveWindow();
        ShowWindow(hWnd, SW_MINIMIZE);
    }
#endif
}
