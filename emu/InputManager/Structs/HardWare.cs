namespace emu.InputManager.Structs
{
    using System.Runtime.InteropServices;

    public static class HardWare
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct HARDWAREINPUT
        {
            public uint uMsg;
            public ushort wParamL;
            public ushort wParamH;
        }

    }

}

