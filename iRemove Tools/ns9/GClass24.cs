using System;
using System.IO;
using System.Runtime.InteropServices;
using ns5;

namespace ns9
{
	// Token: 0x02000053 RID: 83
	public class GClass24
	{
		// Token: 0x060002FF RID: 767
		[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern IntPtr GetModuleHandle(string lpModuleName);

		// Token: 0x06000300 RID: 768
		[DllImport("kernel32.dll")]
		public static extern IntPtr LoadLibrary(string lpFileName);

		// Token: 0x06000301 RID: 769
		[DllImport("kernel32.dll")]
		public static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

		// Token: 0x06000302 RID: 770 RVA: 0x00026484 File Offset: 0x00024684
		public static IntPtr smethod_0(bool flag)
		{
			string lpProcName = flag ? "kCFBooleanTrue" : "kCFBooleanFalse";
			IntPtr intPtr = GClass24.GetModuleHandle("CoreFoundation.dll");
			if (intPtr == IntPtr.Zero)
			{
				string text = GClass19.smethod_2();
				if (!string.IsNullOrWhiteSpace(text))
				{
					intPtr = GClass24.LoadLibrary(Path.Combine(text, "CoreFoundation.dll"));
				}
			}
			IntPtr ptr = IntPtr.Zero;
			if (intPtr != IntPtr.Zero)
			{
				ptr = GClass24.GetProcAddress(intPtr, lpProcName);
			}
			return Marshal.ReadIntPtr(ptr, 0);
		}
	}
}
