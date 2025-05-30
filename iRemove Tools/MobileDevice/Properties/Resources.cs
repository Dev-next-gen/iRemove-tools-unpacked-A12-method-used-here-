using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace MobileDevice.Properties
{
	// Token: 0x02000028 RID: 40
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
	[CompilerGenerated]
	[DebuggerNonUserCode]
	internal class Resources
	{
		// Token: 0x0600023C RID: 572 RVA: 0x0000D9EA File Offset: 0x0000BBEA
		internal Resources()
		{
		}

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x0600023D RID: 573 RVA: 0x00021C78 File Offset: 0x0001FE78
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager_0
		{
			get
			{
				if (Resources.resourceManager_0 == null)
				{
					ResourceManager resourceManager = new ResourceManager("MobileDevice.Properties.Resources", typeof(Resources).Assembly);
					Resources.resourceManager_0 = resourceManager;
				}
				return Resources.resourceManager_0;
			}
		}

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x0600023E RID: 574 RVA: 0x00021CB8 File Offset: 0x0001FEB8
		// (set) Token: 0x0600023F RID: 575 RVA: 0x00021CCC File Offset: 0x0001FECC
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo CultureInfo_0
		{
			get
			{
				return Resources.cultureInfo_0;
			}
			set
			{
				Resources.cultureInfo_0 = value;
			}
		}

		// Token: 0x0400010E RID: 270
		private static ResourceManager resourceManager_0;

		// Token: 0x0400010F RID: 271
		private static CultureInfo cultureInfo_0;
	}
}
