using System;
using System.Runtime.InteropServices;

namespace ns4
{
	// Token: 0x02000026 RID: 38
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct7
	{
		// Token: 0x0400010C RID: 268
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
		public byte[] data;
	}
}
