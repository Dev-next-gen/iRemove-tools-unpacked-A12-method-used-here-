using System;

namespace ns6
{
	// Token: 0x0200003E RID: 62
	public sealed class GDelegate0 : MulticastDelegate
	{
		// Token: 0x060002B5 RID: 693
		public extern GDelegate0(object @object, IntPtr method);

		// Token: 0x060002B6 RID: 694
		public extern void Invoke(object sender, GEventArgs0 e);

		// Token: 0x060002B7 RID: 695
		public extern IAsyncResult BeginInvoke(object sender, GEventArgs0 args, AsyncCallback callback, object @object);

		// Token: 0x060002B8 RID: 696
		public extern void EndInvoke(IAsyncResult result);
	}
}
