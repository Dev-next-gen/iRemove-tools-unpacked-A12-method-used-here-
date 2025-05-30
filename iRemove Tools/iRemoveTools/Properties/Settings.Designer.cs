using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace iRemoveTools.Properties
{
	// Token: 0x02000014 RID: 20
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.7.0.0")]
	[CompilerGenerated]
	internal sealed partial class Settings : ApplicationSettingsBase
	{
		// Token: 0x17000021 RID: 33
		// (get) Token: 0x060000E6 RID: 230 RVA: 0x0001BDC0 File Offset: 0x00019FC0
		public static Settings Default
		{
			get
			{
				return Settings.defaultInstance;
			}
		}

		// Token: 0x040000BC RID: 188
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
	}
}
