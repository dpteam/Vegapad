using System;

namespace Win32Types
{
	internal delegate IntPtr OfnHookProc(IntPtr hWnd, ushort msg, int wParam, int lParam);
}
