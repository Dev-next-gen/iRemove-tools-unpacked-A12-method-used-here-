using System;

namespace ns10
{
	// Token: 0x02000061 RID: 97
	public class GClass31 : GClass29
	{
		// Token: 0x060003A1 RID: 929 RVA: 0x0000DAF6 File Offset: 0x0000BCF6
		public GClass31()
		{
		}

		// Token: 0x060003A2 RID: 930 RVA: 0x0000DAFE File Offset: 0x0000BCFE
		public GClass31(IntPtr Data) : base(Data)
		{
		}

		// Token: 0x060003A3 RID: 931 RVA: 0x00027B18 File Offset: 0x00025D18
		public unsafe GClass31(byte[] Data)
		{
			int bytelength = Data.Length;
			fixed (byte[] array = Data)
			{
				byte* value;
				if (Data != null && array.Length != 0)
				{
					value = &array[0];
				}
				else
				{
					value = null;
				}
				this.intptr_0 = GClass28.CFDataCreate(IntPtr.Zero, (IntPtr)((void*)value), bytelength);
			}
		}

		// Token: 0x060003A4 RID: 932 RVA: 0x00027B64 File Offset: 0x00025D64
		public int method_7()
		{
			return GClass28.CFDataGetLength(this.intptr_0);
		}

		// Token: 0x060003A5 RID: 933 RVA: 0x00027B80 File Offset: 0x00025D80
		public bool method_8()
		{
			return GClass28.CFGetTypeID(this.intptr_0) == 19;
		}

		// Token: 0x060003A6 RID: 934 RVA: 0x00027B9C File Offset: 0x00025D9C
		public unsafe byte[] method_9()
		{
			int num = this.method_7();
			byte[] array = new byte[num];
			byte[] array2;
			byte* value;
			if ((array2 = array) != null && array2.Length != 0)
			{
				value = &array2[0];
			}
			else
			{
				value = null;
			}
			GClass28.CFDataGetBytes(this.intptr_0, new GStruct5(0, num), (IntPtr)((void*)value));
			array2 = null;
			return array;
		}

		// Token: 0x060003A7 RID: 935 RVA: 0x00027BF0 File Offset: 0x00025DF0
		public static GClass31 smethod_2(IntPtr value)
		{
			return new GClass31(value);
		}

		// Token: 0x060003A8 RID: 936 RVA: 0x00027C08 File Offset: 0x00025E08
		public static IntPtr smethod_3(GClass31 value)
		{
			return value.intptr_0;
		}
	}
}
