using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace Vegapad.Properties
{
	internal sealed partial class Settings : ApplicationSettingsBase
	{
		public static Settings Default
		{
			get
			{
				return Settings.defaultInstance;
			}
		}

		[DefaultSettingValue("Lucida Console, 9.75pt")]
		[UserScopedSetting]
		[DebuggerNonUserCode]
		public Font CurrentFont
		{
			get
			{
				return (Font)this["CurrentFont"];
			}
			set
			{
				this["CurrentFont"] = value;
			}
		}

		[DefaultSettingValue("False")]
		[UserScopedSetting]
		[DebuggerNonUserCode]
		public bool IsStatusBarVisible
		{
			get
			{
				return (bool)this["IsStatusBarVisible"];
			}
			set
			{
				this["IsStatusBarVisible"] = value;
			}
		}

		[DefaultSettingValue("0, 0, 0, 0")]
		[UserScopedSetting]
		[DebuggerNonUserCode]
		public Rectangle WindowPosition
		{
			get
			{
				return (Rectangle)this["WindowPosition"];
			}
			set
			{
				this["WindowPosition"] = value;
			}
		}

		[DefaultSettingValue("&f")]
		[UserScopedSetting]
		[DebuggerNonUserCode]
		public string Header
		{
			get
			{
				return (string)this["Header"];
			}
			set
			{
				this["Header"] = value;
			}
		}

		[DefaultSettingValue("Page &p")]
		[UserScopedSetting]
		[DebuggerNonUserCode]
		public string Footer
		{
			get
			{
				return (string)this["Footer"];
			}
			set
			{
				this["Footer"] = value;
			}
		}

		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
	}
}
