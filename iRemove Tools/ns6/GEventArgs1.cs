using System;
using ns2;
using ns7;

namespace ns6
{
	// Token: 0x0200003F RID: 63
	public class GEventArgs1 : EventArgs
	{
		// Token: 0x17000049 RID: 73
		// (get) Token: 0x060002BA RID: 698 RVA: 0x00026050 File Offset: 0x00024250
		public GClass2 GClass2_0
		{
			get
			{
				return this.gclass2_0;
			}
		}

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x060002BB RID: 699 RVA: 0x00026068 File Offset: 0x00024268
		public GEnum0 GEnum0_0
		{
			get
			{
				return this.genum0_0;
			}
		}

		// Token: 0x060002BC RID: 700 RVA: 0x0000DAAE File Offset: 0x0000BCAE
		public GEventArgs1(GClass2 deviceRecovery, GEnum0 message)
		{
			this.gclass2_0 = deviceRecovery;
			this.genum0_0 = message;
		}

		// Token: 0x040001A3 RID: 419
		private GClass2 gclass2_0;

		// Token: 0x040001A4 RID: 420
		private GEnum0 genum0_0;
	}
}
