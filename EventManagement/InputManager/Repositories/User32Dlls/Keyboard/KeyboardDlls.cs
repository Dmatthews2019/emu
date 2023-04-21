using EventManagement.InputManager.Repositories.User32Dlls.Base;

namespace EventManagement.InputManager.Repositories.User32Dlls.Keyboard
{
    internal class KeyboardDlls : User32DllBase
    {
        public static new short GetAsyncKeyState(int vKey)
        {
            return User32DllBase.GetAsyncKeyState(vKey);
        }
    }
}
