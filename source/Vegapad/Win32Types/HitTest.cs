﻿using System;

namespace Win32Types
{
	internal enum HitTest
	{
		HTERROR = -2,
		HTTRANSPARENT,
		HTNOWHERE,
		HTCLIENT,
		HTCAPTION,
		HTSYSMENU,
		HTGROWBOX,
		HTSIZE = 4,
		HTMENU,
		HTHSCROLL,
		HTVSCROLL,
		HTMINBUTTON,
		HTMAXBUTTON,
		HTLEFT,
		HTRIGHT,
		HTTOP,
		HTTOPLEFT,
		HTTOPRIGHT,
		HTBOTTOM,
		HTBOTTOMLEFT,
		HTBOTTOMRIGHT,
		HTBORDER,
		HTREDUCE = 8,
		HTZOOM,
		HTSIZEFIRST,
		HTSIZELAST = 17,
		HTOBJECT = 19,
		HTCLOSE,
		HTHELP
	}
}
