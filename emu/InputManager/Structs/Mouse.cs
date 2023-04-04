namespace emu.InputManager.Structs
{
    using System;
    using System.Runtime.InteropServices;

    public static class Mouse
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct MOUSEINPUT
        {
            public int dx;
            public int dy;
            public uint mouseData;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

    }

}

