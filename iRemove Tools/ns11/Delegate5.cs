using System;
using System.Runtime.InteropServices;
using ns4;

namespace ns11
{
	// Token: 0x02000072 RID: 114
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal sealed class Delegate5 : MulticastDelegate
	{
		// Token: 0x0600041E RID: 1054
		public extern Delegate5(object @object, IntPtr method);

		// Token: 0x0600041F RID: 1055
		public extern void Invoke(ref Struct7 callback_info);

		// Token: 0x06000420 RID: 1056
		public extern IAsyncResult BeginInvoke(ref Struct7 callback_info, AsyncCallback callback, object @object);

		// Token: 0x06000421 RID: 1057
		public extern void EndInvoke(ref Struct7 callback_info, IAsyncResult result);
	}
}
