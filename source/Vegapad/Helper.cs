using System;
using System.Collections.Generic;

namespace Vegapad
{
	public static class Helper
	{
		public static List<int> GetIndexes(string pText, string pSearchText, bool pCaseSensitive)
		{
			List<int> Indexes = new List<int>();
			StringComparison eStringComparison = pCaseSensitive ? StringComparison.CurrentCulture : StringComparison.CurrentCultureIgnoreCase;
			int StartIndex = 0;
			for (;;)
			{
				int Index = pText.IndexOf(pSearchText, StartIndex, eStringComparison);
				if (Index == -1)
				{
					break;
				}
				Indexes.Add(Index);
				StartIndex = Index + pSearchText.Length;
			}
			return Indexes;
		}
	}
}
