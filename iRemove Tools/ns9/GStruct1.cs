using System;

namespace ns9
{
	// Token: 0x0200005D RID: 93
	public struct GStruct1
	{
		// Token: 0x17000050 RID: 80
		// (get) Token: 0x06000399 RID: 921 RVA: 0x00027AD0 File Offset: 0x00025CD0
		public bool Boolean_0
		{
			get
			{
				return this.intptr_0 == IntPtr.Zero && this.intptr_1 == IntPtr.Zero && this.int_0 == 0 && this.int_1 == 0;
			}
		}

		// Token: 0x0400036D RID: 877
		public IntPtr intptr_0;

		// Token: 0x0400036E RID: 878
		public IntPtr intptr_1;

		// Token: 0x0400036F RID: 879
		public int int_0;

		// Token: 0x04000370 RID: 880
		public int int_1;
	}
}
