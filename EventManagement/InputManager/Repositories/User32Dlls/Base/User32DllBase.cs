namespace EventManagement.InputManager.Repositories.User32Dlls.Base;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using EventManagement.InputManager.Models.HardwareInfo;
using EventManagement.InputManager.Models.Shapes;

internal abstract class User32DllBase
{
    [DllImport("user32.dll")]
    protected static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

    [DllImport("user32.dll")]
    protected static extern IntPtr GetForegroundWindow();

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    protected static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

    [DllImport("user32.dll")]
    protected static extern bool GetCursorPos(out Point lpPoint);

    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    protected static extern bool GetMonitorInfo(IntPtr hMonitor, ref MONITORINFO lpmi);

    [DllImport("user32.dll")]
    protected static extern IntPtr MonitorFromWindow(IntPtr hwnd, uint dwFlags);

    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    protected static extern bool GetWindowRect(IntPtr hWnd, out Rect lpRect);

    [DllImport("user32.dll")]
    protected static extern short GetAsyncKeyState(int vKey);
}