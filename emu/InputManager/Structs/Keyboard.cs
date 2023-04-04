namespace emu.InputManager.Structs
{
    using System;
    using System.Runtime.InteropServices;

    public static class KeyBoard
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct KEYBDINPUT
        {
            public ushort wVk;
            public ushort wScan;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

    }

}

