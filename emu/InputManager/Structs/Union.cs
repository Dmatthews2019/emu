namespace emu.InputManager.Structs
{
    using System.Runtime.InteropServices;

    public static class Union
    {
        [StructLayout(LayoutKind.Explicit)]
        public struct InputUnion
        {
            [FieldOffset(0)]
            public Mouse.MOUSEINPUT mi;

            [FieldOffset(0)]
            public KeyBoard.KEYBDINPUT ki;

            [FieldOffset(0)]
            public HardWare.HARDWAREINPUT hi;
        }
    }

}

