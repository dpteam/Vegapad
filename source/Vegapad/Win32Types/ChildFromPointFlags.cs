using System;

namespace Win32Types
{
	[Flags]
	internal enum ChildFromPointFlags
	{
		None = 0,
		CWP_SKIPINVISIBLE = 1,
		CWP_SKIPDISABLED = 2,
		CWP_SKIPTRANSPARENT = 4
	}
}
