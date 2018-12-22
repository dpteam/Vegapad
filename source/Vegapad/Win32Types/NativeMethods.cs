using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Win32Types
{
	internal static class NativeMethods
	{
		[DllImport("user32.dll")]
		public static extern bool IsWindow(IntPtr hwnd);

		[DllImport("user32.dll")]
		internal static extern IntPtr CreateWindowEx(uint dwExStyle, string lpClassName, string lpWindowName, uint dwStyle, int x, int y, int nWidth, int nHeight, IntPtr hWndParent, IntPtr hMenu, IntPtr hInstance, IntPtr lpParam);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern IntPtr GetParent(IntPtr hWnd);

		[DllImport("user32.dll")]
		internal static extern bool EnableWindow(IntPtr hWnd, bool bEnable);

		[DllImport("user32.dll")]
		internal static extern IntPtr GetDlgItem(IntPtr hDlg, int nIDDlgItem);

		[DllImport("user32.dll")]
		internal static extern bool SetDlgItemText(IntPtr hDlg, int nIDDlgItem, string lpString);

		[DllImport("User32.Dll")]
		public static extern int GetDlgCtrlID(IntPtr hWndCtl);

		[DllImport("user32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool GetWindowInfo(HandleRef hwnd, out WINDOWINFO pwi);

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetWindowText(HandleRef hWnd, string lpString);

		[DllImport("User32.Dll")]
		public static extern void GetClassName(HandleRef hWnd, StringBuilder param, int length);

		[DllImport("user32.Dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool EnumChildWindows(HandleRef hWndParent, NativeMethods.EnumWindowsCallBack lpEnumFunc, int lParam);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string className, string windowTitle);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string className, IntPtr windowTitle);

		[DllImport("user32.dll")]
		internal static extern IntPtr SetParent(HandleRef hWndChild, HandleRef hWndNewParent);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		internal static extern IntPtr SendMessage(HandleRef hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		internal static extern IntPtr SendMessage(HandleRef hWnd, uint Msg, IntPtr wParam, StringBuilder lParam);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int Width, int Height, SetWindowPosFlags flags);

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool GetWindowRect(HandleRef hwnd, ref RECT rect);

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool GetClientRect(HandleRef hwnd, ref RECT rect);

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool DestroyWindow(IntPtr hWnd);

		[DllImport("advapi32.dll")]
		public static extern int RegCreateKeyW([In] UIntPtr hKey, [MarshalAs(UnmanagedType.LPWStr)] [In] string lpSubKey, out IntPtr phkResult);

		[DllImport("advapi32.dll")]
		public static extern int RegOverridePredefKey([In] UIntPtr hKey, [In] IntPtr hNewHKey);

		[DllImport("advapi32.dll")]
		public static extern int RegCloseKey([In] IntPtr hKey);

		internal delegate bool EnumWindowsCallBack(IntPtr hWnd, int lParam);
	}
}
