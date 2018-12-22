using System;
using System.Runtime.InteropServices;

namespace Win32Types
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	internal struct OPENFILENAME
	{
		public uint lStructSize;

		public IntPtr hwndOwner;

		public IntPtr hInstance;

		public string lpstrFilter;

		public string lpstrCustomFilter;

		public uint nMaxCustFilter;

		public int nFilterIndex;

		public string lpstrFile;

		public uint nMaxFile;

		public string lpstrFileTitle;

		public uint nMaxFileTitle;

		public string lpstrInitialDir;

		public string lpstrTitle;

		public uint Flags;

		public ushort nFileOffset;

		public ushort nFileExtension;

		public string lpstrDefExt;

		public IntPtr lCustData;

		public OfnHookProc lpfnHook;

		public string lpTemplateName;

		public IntPtr pvReserved;

		public uint dwReserved;

		public uint FlagsEx;
	}
}
