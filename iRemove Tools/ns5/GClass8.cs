using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ns5
{
	// Token: 0x0200002F RID: 47
	public static class GClass8
	{
		// Token: 0x17000046 RID: 70
		// (get) Token: 0x06000265 RID: 613 RVA: 0x00022A38 File Offset: 0x00020C38
		public static string String_0
		{
			get
			{
				if (!GClass8.fileInfo_0.Exists)
				{
					throw new FileNotFoundException("curl-ca-bundle.crt is missing.");
				}
				return GClass8.fileInfo_0.FullName;
			}
		}

		// Token: 0x06000266 RID: 614 RVA: 0x00017E98 File Offset: 0x00016098
		public static void smethod_0()
		{
		}

		// Token: 0x06000267 RID: 615 RVA: 0x00017E98 File Offset: 0x00016098
		private static void smethod_1(string resourcePath, DirectoryInfo outputDir)
		{
		}

		// Token: 0x06000268 RID: 616
		[DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool SetDllDirectory(string lpPathName);

		// Token: 0x0400011C RID: 284
		private const string string_0 = "curl-ca-bundle.crt";

		// Token: 0x0400011D RID: 285
		private static readonly DirectoryInfo directoryInfo_0 = new DirectoryInfo(Assembly.GetEntryAssembly().Location).Parent;

		// Token: 0x0400011E RID: 286
		private static readonly FileInfo fileInfo_0 = new FileInfo(Path.Combine(GClass8.directoryInfo_0.FullName, "curl-ca-bundle.crt"));
	}
}
