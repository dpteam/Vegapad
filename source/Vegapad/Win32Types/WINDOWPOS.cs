using System;

namespace Win32Types
{
	internal struct WINDOWPOS
	{
		public override string ToString()
		{
			object[] array = new object[9];
			array[0] = this.x;
			array[1] = ":";
			array[2] = this.y;
			array[3] = ":";
			array[4] = this.cx;
			array[5] = ":";
			array[6] = this.cy;
			array[7] = ":";
			int num = 8;
			SWP_Flags swp_Flags = (SWP_Flags)this.flags;
			array[num] = swp_Flags.ToString();
			return string.Concat(array);
		}

		public IntPtr hwnd;

		public IntPtr hwndAfter;

		public int x;

		public int y;

		public int cx;

		public int cy;

		public uint flags;
	}
}
