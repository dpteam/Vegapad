using System;

namespace Win32Types
{
	internal struct NMHEADER
	{
		internal NMHDR hdr;

		internal int iItem;

		internal int iButton;

		internal IntPtr pItem;
	}
}
