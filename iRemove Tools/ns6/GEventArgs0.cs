using System;
using ns2;
using ns7;

namespace ns6
{
	// Token: 0x0200003D RID: 61
	public class GEventArgs0 : EventArgs
	{
		// Token: 0x060002B1 RID: 689 RVA: 0x0000DA98 File Offset: 0x0000BC98
		internal GEventArgs0(GClass2 device, GEnum0 message)
		{
			this.gclass2_0 = device;
			this.genum0_0 = message;
		}

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x060002B2 RID: 690 RVA: 0x00026020 File Offset: 0x00024220
		public GClass2 GClass2_0
		{
			get
			{
				return this.gclass2_0;
			}
		}

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x060002B3 RID: 691 RVA: 0x00026038 File Offset: 0x00024238
		public GEnum0 GEnum0_0
		{
			get
			{
				return this.genum0_0;
			}
		}

		// Token: 0x040001A1 RID: 417
		private readonly GClass2 gclass2_0;

		// Token: 0x040001A2 RID: 418
		private readonly GEnum0 genum0_0;
	}
}
