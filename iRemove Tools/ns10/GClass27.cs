using System;
using System.Runtime.InteropServices;

namespace ns10
{
	// Token: 0x0200006A RID: 106
	public class GClass27
	{
		// Token: 0x060003CE RID: 974 RVA: 0x0000D9EA File Offset: 0x0000BBEA
		public GClass27()
		{
		}

		// Token: 0x060003CF RID: 975 RVA: 0x0000DB07 File Offset: 0x0000BD07
		public GClass27(IntPtr Index)
		{
			this.intptr_0 = Index;
		}

		// Token: 0x060003D0 RID: 976 RVA: 0x00027D3C File Offset: 0x00025F3C
		public int method_0()
		{
			return Marshal.ReadInt32(this.intptr_0);
		}

		// Token: 0x060003D1 RID: 977 RVA: 0x00027D58 File Offset: 0x00025F58
		public static GClass27 smethod_0(IntPtr Index)
		{
			return new GClass27(Index);
		}

		// Token: 0x04000391 RID: 913
		internal IntPtr intptr_0;
	}
}
