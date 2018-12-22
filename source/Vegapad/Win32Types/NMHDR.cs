using System;

namespace Win32Types
{
	internal struct NMHDR
	{
		public IntPtr hwndFrom;

		public IntPtr idFrom;

		public uint code;
	}
}
