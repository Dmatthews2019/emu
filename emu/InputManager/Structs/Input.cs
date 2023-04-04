namespace emu.InputManager.Structs
{
    using System.Runtime.InteropServices;

    public static class Input
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct INPUT
        {
            public int type;
            public Union.InputUnion u;
        }

    }

}

