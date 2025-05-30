using System;

namespace ns10
{
	// Token: 0x0200006C RID: 108
	public class GClass33 : GClass29
	{
		// Token: 0x060003F9 RID: 1017 RVA: 0x0000DAF6 File Offset: 0x0000BCF6
		public GClass33()
		{
		}

		// Token: 0x060003FA RID: 1018 RVA: 0x0000DAFE File Offset: 0x0000BCFE
		public GClass33(IntPtr Number) : base(Number)
		{
		}

		// Token: 0x060003FB RID: 1019 RVA: 0x00027D70 File Offset: 0x00025F70
		public unsafe GClass33(int Number)
		{
			int* valuePtr = &Number;
			this.intptr_0 = GClass28.CFNumberCreate(IntPtr.Zero, GClass33.GEnum7.const_8, valuePtr);
		}

		// Token: 0x0200006D RID: 109
		public enum GEnum7
		{
			// Token: 0x04000393 RID: 915
			const_0 = 1,
			// Token: 0x04000394 RID: 916
			const_1,
			// Token: 0x04000395 RID: 917
			const_2,
			// Token: 0x04000396 RID: 918
			const_3,
			// Token: 0x04000397 RID: 919
			const_4,
			// Token: 0x04000398 RID: 920
			const_5,
			// Token: 0x04000399 RID: 921
			const_6,
			// Token: 0x0400039A RID: 922
			const_7,
			// Token: 0x0400039B RID: 923
			const_8,
			// Token: 0x0400039C RID: 924
			const_9,
			// Token: 0x0400039D RID: 925
			const_10,
			// Token: 0x0400039E RID: 926
			const_11,
			// Token: 0x0400039F RID: 927
			const_12,
			// Token: 0x040003A0 RID: 928
			const_13,
			// Token: 0x040003A1 RID: 929
			const_14,
			// Token: 0x040003A2 RID: 930
			const_15,
			// Token: 0x040003A3 RID: 931
			const_16 = 16
		}
	}
}
