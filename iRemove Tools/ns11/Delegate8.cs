using System;
using System.Runtime.InteropServices;
using ns4;

namespace ns11
{
	// Token: 0x02000075 RID: 117
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal sealed class Delegate8 : MulticastDelegate
	{
		// Token: 0x0600042D RID: 1069
		public extern Delegate8(object @object, IntPtr method);

		// Token: 0x0600042E RID: 1070
		public extern void Invoke(ref Struct6 callback_info);

		// Token: 0x0600042F RID: 1071
		public extern IAsyncResult BeginInvoke(ref Struct6 callback_info, AsyncCallback callback, object @object);

		// Token: 0x06000430 RID: 1072
		public extern void EndInvoke(ref Struct6 callback_info, IAsyncResult result);
	}
}
