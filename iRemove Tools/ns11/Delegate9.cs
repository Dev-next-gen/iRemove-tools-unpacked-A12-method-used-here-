using System;
using System.Runtime.InteropServices;
using ns4;

namespace ns11
{
	// Token: 0x02000076 RID: 118
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal sealed class Delegate9 : MulticastDelegate
	{
		// Token: 0x06000432 RID: 1074
		public extern Delegate9(object @object, IntPtr method);

		// Token: 0x06000433 RID: 1075
		public extern void Invoke(ref GStruct0 callback_info);

		// Token: 0x06000434 RID: 1076
		public extern IAsyncResult BeginInvoke(ref GStruct0 callback_info, AsyncCallback callback, object @object);

		// Token: 0x06000435 RID: 1077
		public extern void EndInvoke(ref GStruct0 callback_info, IAsyncResult result);
	}
}
