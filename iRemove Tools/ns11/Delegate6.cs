using System;
using System.Runtime.InteropServices;

namespace ns11
{
	// Token: 0x02000073 RID: 115
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal sealed class Delegate6 : MulticastDelegate
	{
		// Token: 0x06000423 RID: 1059
		public extern Delegate6(object @object, IntPtr method);

		// Token: 0x06000424 RID: 1060
		public extern void Invoke(IntPtr str, IntPtr user);

		// Token: 0x06000425 RID: 1061
		public extern IAsyncResult BeginInvoke(IntPtr str, IntPtr user, AsyncCallback callback, object @object);

		// Token: 0x06000426 RID: 1062
		public extern void EndInvoke(IAsyncResult result);
	}
}
