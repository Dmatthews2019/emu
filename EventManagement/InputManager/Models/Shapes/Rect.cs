namespace EventManagement.InputManager.Models.Shapes;

using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]
internal struct Rect
{
    public int left;
    public int top;
    public int right;
    public int bottom;
}