namespace emu.InputManager.Models.HardwareInfo;

using System.Runtime.InteropServices;
using Shapes;

[StructLayout(LayoutKind.Sequential)]
public struct MONITORINFO
{
    public int cbSize;
    public Rect rcMonitor;
    public Rect rcWork;
    public uint dwFlags;
}