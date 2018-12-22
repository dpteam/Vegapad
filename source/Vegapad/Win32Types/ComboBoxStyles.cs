﻿using System;

namespace Win32Types
{
	internal enum ComboBoxStyles : uint
	{
		None,
		CBS_SIMPLE,
		CBS_DROPDOWN,
		CBS_DROPDOWNLIST,
		CBS_OWNERDRAWFIXED = 16u,
		CBS_OWNERDRAWVARIABLE = 32u,
		CBS_AUTOHSCROLL = 64u,
		CBS_OEMCONVERT = 128u,
		CBS_SORT = 256u,
		CBS_HASSTRINGS = 512u,
		CBS_NOINTEGRALHEIGHT = 1024u,
		CBS_DISABLENOSCROLL = 2048u,
		CBS_UPPERCASE = 8192u,
		CBS_LOWERCASE = 16384u
	}
}
