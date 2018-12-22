using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace Vegapad.Properties
{
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0")]
	[CompilerGenerated]
	internal sealed partial class Settings : ApplicationSettingsBase
	{
		[SettingsSerializeAs(SettingsSerializeAs.Binary)]
		[UserScopedSetting]
		public MoreSettings MoreSettings
		{
			get
			{
				MoreSettings MoreSettings = (MoreSettings)this["MoreSettings"];
				if (MoreSettings == null)
				{
                    this["MoreSettings"] = MoreSettings = new MoreSettings();
                }
				return MoreSettings;
			}
			set
			{
				this["MoreSettings"] = value;
			}
		}
	}
}
