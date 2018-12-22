using System;
using System.ComponentModel;
using System.Linq;

namespace Vegapad
{
	public static class HelperExtensions
	{
		public static string FormatUsingObject(this string @this, object poObject)
		{
			string sFormatted = @this;
			foreach (PropertyDescriptor oProperty in TypeDescriptor.GetProperties(poObject).Cast<PropertyDescriptor>())
			{
				sFormatted = sFormatted.Replace("{" + oProperty.Name + "}", oProperty.GetValue(poObject).ToStringOrNull());
			}
			return sFormatted;
		}

		public static string ToStringOrNull(this object @this)
		{
			if (@this == null)
			{
				return null;
			}
			return @this.ToString();
		}

		public static bool IsEmpty(this string @this)
		{
			return string.IsNullOrWhiteSpace(@this);
		}
	}
}
