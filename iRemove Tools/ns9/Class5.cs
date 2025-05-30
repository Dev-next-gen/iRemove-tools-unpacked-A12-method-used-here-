using System;

namespace ns9
{
	// Token: 0x02000054 RID: 84
	internal class Class5 : IDisposable
	{
		// Token: 0x06000305 RID: 773 RVA: 0x00026504 File Offset: 0x00024704
		internal Class5(IntPtr handle, bool owns)
		{
			if (handle == IntPtr.Zero)
			{
				throw new ArgumentNullException("handle");
			}
			this.intptr_0 = handle;
			if (!owns)
			{
				GClass25.CFRetain(handle);
			}
		}

		// Token: 0x06000306 RID: 774 RVA: 0x00026544 File Offset: 0x00024744
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x06000307 RID: 775 RVA: 0x00026560 File Offset: 0x00024760
		protected virtual void Dispose(bool disposing)
		{
			if (this.intptr_0 != IntPtr.Zero)
			{
				GClass25.CFRelease(this.intptr_0);
				this.intptr_0 = IntPtr.Zero;
			}
		}

		// Token: 0x06000308 RID: 776 RVA: 0x00026598 File Offset: 0x00024798
		~Class5()
		{
			this.Dispose(false);
		}

		// Token: 0x06000309 RID: 777 RVA: 0x000265C8 File Offset: 0x000247C8
		internal static void smethod_0(IntPtr srcRef, IntPtr keys, ref IntPtr values)
		{
			GClass25.CFDictionaryGetKeysAndValues(srcRef, keys, values);
		}

		// Token: 0x040002BC RID: 700
		internal IntPtr intptr_0;
	}
}
