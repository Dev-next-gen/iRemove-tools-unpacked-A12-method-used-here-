using System;

namespace ns10
{
	// Token: 0x02000070 RID: 112
	public sealed class GClass35 : GClass29
	{
		// Token: 0x06000408 RID: 1032 RVA: 0x0000DAF6 File Offset: 0x0000BCF6
		public GClass35()
		{
		}

		// Token: 0x06000409 RID: 1033 RVA: 0x0000DB26 File Offset: 0x0000BD26
		public GClass35(string str)
		{
			this.intptr_0 = GClass28.__CFStringMakeConstantString(str);
		}

		// Token: 0x0600040A RID: 1034 RVA: 0x0000DAFE File Offset: 0x0000BCFE
		public GClass35(IntPtr myHandle) : base(myHandle)
		{
		}

		// Token: 0x0600040B RID: 1035 RVA: 0x00027E90 File Offset: 0x00026090
		public bool method_7()
		{
			return GClass28.CFGetTypeID(this.intptr_0) == 7;
		}

		// Token: 0x0600040C RID: 1036 RVA: 0x00027EAC File Offset: 0x000260AC
		public static GClass35 smethod_2(IntPtr value)
		{
			return new GClass35(value);
		}

		// Token: 0x0600040D RID: 1037 RVA: 0x00027C08 File Offset: 0x00025E08
		public static IntPtr smethod_3(GClass35 value)
		{
			return value.intptr_0;
		}

		// Token: 0x0600040E RID: 1038 RVA: 0x00027D24 File Offset: 0x00025F24
		public static string smethod_4(GClass35 value)
		{
			return value.ToString();
		}

		// Token: 0x0600040F RID: 1039 RVA: 0x00027EC4 File Offset: 0x000260C4
		public static GClass35 smethod_5(string value)
		{
			return new GClass35(value);
		}
	}
}
