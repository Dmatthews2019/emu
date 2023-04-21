namespace EventManagement.InputManager.Models.HardwareInfo;

using System.Runtime.InteropServices;
using EventManagement.InputManager.Models.Shapes;

[StructLayout(LayoutKind.Sequential)]
internal struct MONITORINFO
{
    public int cbSize;
    public Rect rcMonitor;
    public Rect rcWork;
    public uint dwFlags;
}