using System;

namespace Win32Types
{
	internal struct OFNOTIFY
	{
		public NMHDR hdr;

		public IntPtr OpenFileName;

		public IntPtr fileNameShareViolation;
	}
}
