using System;
using System.Runtime.InteropServices;

namespace ns10
{
	// Token: 0x02000062 RID: 98
	public class GClass32 : GClass29
	{
		// Token: 0x060003AA RID: 938 RVA: 0x0000DAF6 File Offset: 0x0000BCF6
		public GClass32()
		{
		}

		// Token: 0x060003AB RID: 939 RVA: 0x0000DAFE File Offset: 0x0000BCFE
		public GClass32(IntPtr dictionary) : base(dictionary)
		{
		}

		// Token: 0x060003AC RID: 940 RVA: 0x00027C20 File Offset: 0x00025E20
		public GClass32(string[] keys, IntPtr[] values)
		{
			IntPtr[] array = new IntPtr[keys.Length];
			for (int i = 0; i < keys.Length; i++)
			{
				array[i] = GClass35.smethod_3(new GClass35(keys[i]));
			}
			GClass32.GStruct3 gstruct = default(GClass32.GStruct3);
			GClass32.GStruct4 gstruct2 = default(GClass32.GStruct4);
			this.intptr_0 = GClass28.CFDictionaryCreate(IntPtr.Zero, array, values, keys.Length, ref gstruct, ref gstruct2);
		}

		// Token: 0x060003AD RID: 941 RVA: 0x00027C88 File Offset: 0x00025E88
		public GClass29 method_7(string value)
		{
			GClass29 result;
			try
			{
				IntPtr handle = GClass28.CFDictionaryGetValue(this.intptr_0, GClass35.smethod_3(new GClass35(value)));
				result = new GClass29(handle);
			}
			catch (AccessViolationException)
			{
				result = new GClass29(IntPtr.Zero);
			}
			catch (Exception)
			{
				result = new GClass29(IntPtr.Zero);
			}
			return result;
		}

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x060003AE RID: 942 RVA: 0x00027CF0 File Offset: 0x00025EF0
		public int Int32_0
		{
			get
			{
				return GClass28.CFDictionaryGetCount(this.intptr_0);
			}
		}

		// Token: 0x060003AF RID: 943 RVA: 0x00027D0C File Offset: 0x00025F0C
		public static GClass32 smethod_2(IntPtr value)
		{
			return new GClass32(value);
		}

		// Token: 0x060003B0 RID: 944 RVA: 0x00027C08 File Offset: 0x00025E08
		public static IntPtr smethod_3(GClass32 value)
		{
			return value.intptr_0;
		}

		// Token: 0x060003B1 RID: 945 RVA: 0x00027D24 File Offset: 0x00025F24
		public static string smethod_4(GClass32 value)
		{
			return value.ToString();
		}

		// Token: 0x02000063 RID: 99
		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		public struct GStruct3
		{
			// Token: 0x04000386 RID: 902
			private int int_0;

			// Token: 0x04000387 RID: 903
			private GClass32.Delegate0 delegate0_0;

			// Token: 0x04000388 RID: 904
			private GClass32.Delegate1 delegate1_0;

			// Token: 0x04000389 RID: 905
			private GClass32.Delegate2 delegate2_0;

			// Token: 0x0400038A RID: 906
			private GClass32.Delegate3 delegate3_0;

			// Token: 0x0400038B RID: 907
			private GClass32.Delegate4 delegate4_0;
		}

		// Token: 0x02000064 RID: 100
		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		public struct GStruct4
		{
			// Token: 0x0400038C RID: 908
			private int int_0;

			// Token: 0x0400038D RID: 909
			private GClass32.Delegate0 delegate0_0;

			// Token: 0x0400038E RID: 910
			private GClass32.Delegate1 delegate1_0;

			// Token: 0x0400038F RID: 911
			private GClass32.Delegate2 delegate2_0;

			// Token: 0x04000390 RID: 912
			private GClass32.Delegate3 delegate3_0;
		}

		// Token: 0x02000065 RID: 101
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal sealed class Delegate0 : MulticastDelegate
		{
			// Token: 0x060003B5 RID: 949
			public extern Delegate0(object @object, IntPtr method);

			// Token: 0x060003B6 RID: 950
			public extern IntPtr Invoke(IntPtr allocator, IntPtr value);

			// Token: 0x060003B7 RID: 951
			public extern IAsyncResult BeginInvoke(IntPtr allocator, IntPtr value, AsyncCallback callback, object @object);

			// Token: 0x060003B8 RID: 952
			public extern IntPtr EndInvoke(IAsyncResult result);
		}

		// Token: 0x02000066 RID: 102
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal sealed class Delegate1 : MulticastDelegate
		{
			// Token: 0x060003BA RID: 954
			public extern Delegate1(object @object, IntPtr method);

			// Token: 0x060003BB RID: 955
			public extern void Invoke(IntPtr allocator, IntPtr value);

			// Token: 0x060003BC RID: 956
			public extern IAsyncResult BeginInvoke(IntPtr allocator, IntPtr value, AsyncCallback callback, object @object);

			// Token: 0x060003BD RID: 957
			public extern void EndInvoke(IAsyncResult result);
		}

		// Token: 0x02000067 RID: 103
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal sealed class Delegate2 : MulticastDelegate
		{
			// Token: 0x060003BF RID: 959
			public extern Delegate2(object @object, IntPtr method);

			// Token: 0x060003C0 RID: 960
			public extern IntPtr Invoke(IntPtr value);

			// Token: 0x060003C1 RID: 961
			public extern IAsyncResult BeginInvoke(IntPtr value, AsyncCallback callback, object @object);

			// Token: 0x060003C2 RID: 962
			public extern IntPtr EndInvoke(IAsyncResult result);
		}

		// Token: 0x02000068 RID: 104
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal sealed class Delegate3 : MulticastDelegate
		{
			// Token: 0x060003C4 RID: 964
			public extern Delegate3(object @object, IntPtr method);

			// Token: 0x060003C5 RID: 965
			public extern IntPtr Invoke(IntPtr value1, IntPtr value2);

			// Token: 0x060003C6 RID: 966
			public extern IAsyncResult BeginInvoke(IntPtr value1, IntPtr value2, AsyncCallback callback, object @object);

			// Token: 0x060003C7 RID: 967
			public extern IntPtr EndInvoke(IAsyncResult result);
		}

		// Token: 0x02000069 RID: 105
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal sealed class Delegate4 : MulticastDelegate
		{
			// Token: 0x060003C9 RID: 969
			public extern Delegate4(object @object, IntPtr method);

			// Token: 0x060003CA RID: 970
			public extern IntPtr Invoke(IntPtr value);

			// Token: 0x060003CB RID: 971
			public extern IAsyncResult BeginInvoke(IntPtr value, AsyncCallback callback, object @object);

			// Token: 0x060003CC RID: 972
			public extern IntPtr EndInvoke(IAsyncResult result);
		}
	}
}
