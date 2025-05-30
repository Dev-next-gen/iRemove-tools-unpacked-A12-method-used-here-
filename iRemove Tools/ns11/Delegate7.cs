using System;
using System.Runtime.InteropServices;

namespace ns11
{
	// Token: 0x02000074 RID: 116
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal sealed class Delegate7 : MulticastDelegate
	{
		// Token: 0x06000428 RID: 1064
		public extern Delegate7(object @object, IntPtr method);

		// Token: 0x06000429 RID: 1065
		public extern void Invoke(IntPtr dict);

		// Token: 0x0600042A RID: 1066
		public extern IAsyncResult BeginInvoke(IntPtr dict, AsyncCallback callback, object @object);

		// Token: 0x0600042B RID: 1067
		public extern void EndInvoke(IAsyncResult result);
	}
}
