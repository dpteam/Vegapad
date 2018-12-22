using System;
using System.Drawing.Printing;

namespace Vegapad
{
	[Serializable]
	public class MoreSettings
	{
		public PrinterSettings PrinterSettings { get; set; }

		public PageSettings PageSettings { get; set; }
	}
}
