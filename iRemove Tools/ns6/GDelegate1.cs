using System;

namespace ns6
{
	// Token: 0x02000040 RID: 64
	public sealed class GDelegate1 : MulticastDelegate
	{
		// Token: 0x060002BE RID: 702
		public extern GDelegate1(object @object, IntPtr method);

		// Token: 0x060002BF RID: 703
		public extern void Invoke(object sender, GEventArgs1 e);

		// Token: 0x060002C0 RID: 704
		public extern IAsyncResult BeginInvoke(object sender, GEventArgs1 args, AsyncCallback callback, object @object);

		// Token: 0x060002C1 RID: 705
		public extern void EndInvoke(IAsyncResult result);
	}
}
