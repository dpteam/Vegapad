using System;
using System.Windows.Forms;

namespace Vegapad
{
	internal static class Program
	{
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Main Main = new Main();
			string CommandLine = Environment.CommandLine.Trim();
			string Filename = null;
			if (CommandLine.StartsWith("\""))
			{
				int ClosingQuoteIndex = CommandLine.IndexOf('"', 1);
				if (ClosingQuoteIndex < CommandLine.Length - 1)
				{
					Filename = CommandLine.Substring(ClosingQuoteIndex + 1).Trim();
				}
			}
			else
			{
				int FirstSpaceIndex = CommandLine.IndexOf(' ', 1);
				if (FirstSpaceIndex != -1)
				{
					Filename = CommandLine.Substring(FirstSpaceIndex + 1).Trim();
				}
			}
			if (Filename != null)
			{
				Main.Open(Filename, null);
			}
			Application.Run(Main);
		}
	}
}
