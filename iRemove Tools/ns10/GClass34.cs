using System;

namespace ns10
{
	// Token: 0x0200006E RID: 110
	public class GClass34 : GClass29
	{
		// Token: 0x060003FD RID: 1021 RVA: 0x0000DAF6 File Offset: 0x0000BCF6
		public GClass34()
		{
		}

		// Token: 0x060003FE RID: 1022 RVA: 0x0000DAFE File Offset: 0x0000BCFE
		public GClass34(IntPtr PropertyList) : base(PropertyList)
		{
		}

		// Token: 0x060003FF RID: 1023 RVA: 0x00027D9C File Offset: 0x00025F9C
		public GClass34(string plistlocation)
		{
			IntPtr filePath = GClass35.smethod_3(new GClass35(plistlocation));
			IntPtr fileURL = GClass28.CFURLCreateWithFileSystemPath(IntPtr.Zero, filePath, 2, false);
			IntPtr stream = GClass28.CFReadStreamCreateWithFile(IntPtr.Zero, fileURL);
			if (!GClass28.CFReadStreamOpen(stream))
			{
				this.intptr_0 = IntPtr.Zero;
			}
			IntPtr intptr_ = GClass28.CFPropertyListCreateFromStream(IntPtr.Zero, stream, 0, 2, 0, IntPtr.Zero);
			GClass28.CFReadStreamClose(stream);
			this.intptr_0 = intptr_;
		}

		// Token: 0x06000400 RID: 1024 RVA: 0x00027E0C File Offset: 0x0002600C
		public void method_7(string path)
		{
			IntPtr filePath = GClass35.smethod_3(new GClass35(path));
			IntPtr fileURL = GClass28.CFURLCreateWithFileSystemPath(IntPtr.Zero, filePath, 2, false);
			IntPtr stream = GClass28.CFReadStreamCreateWithFile(IntPtr.Zero, fileURL);
			GClass28.CFReadStreamOpen(stream);
			GClass28.CFPropertyListWriteToStream(this.intptr_0, stream, 0, IntPtr.Zero);
			GClass28.CFReadStreamClose(stream);
		}

		// Token: 0x06000401 RID: 1025 RVA: 0x00027E60 File Offset: 0x00026060
		public static GClass34 smethod_2(IntPtr value)
		{
			return new GClass34(value);
		}

		// Token: 0x06000402 RID: 1026 RVA: 0x00027C08 File Offset: 0x00025E08
		public static IntPtr smethod_3(GClass34 value)
		{
			return value.intptr_0;
		}

		// Token: 0x06000403 RID: 1027 RVA: 0x00027D24 File Offset: 0x00025F24
		public static string smethod_4(GClass34 value)
		{
			return value.ToString();
		}

		// Token: 0x06000404 RID: 1028 RVA: 0x00027E78 File Offset: 0x00026078
		public static GClass34 smethod_5(string value)
		{
			return new GClass34(value);
		}
	}
}
