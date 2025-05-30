using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ns10
{
	// Token: 0x02000071 RID: 113
	public class GClass29
	{
		// Token: 0x06000411 RID: 1041 RVA: 0x0000D9EA File Offset: 0x0000BBEA
		public GClass29()
		{
		}

		// Token: 0x06000412 RID: 1042 RVA: 0x0000DB3A File Offset: 0x0000BD3A
		public GClass29(IntPtr handle)
		{
			this.intptr_0 = handle;
		}

		// Token: 0x06000413 RID: 1043 RVA: 0x00027EDC File Offset: 0x000260DC
		public int method_0()
		{
			return GClass28.CFGetTypeID(this.intptr_0);
		}

		// Token: 0x06000414 RID: 1044 RVA: 0x00027EF8 File Offset: 0x000260F8
		public string method_1()
		{
			return new GClass35(GClass28.CFCopyDescription(this.intptr_0)).ToString();
		}

		// Token: 0x06000415 RID: 1045 RVA: 0x00027F1C File Offset: 0x0002611C
		private unsafe string method_2()
		{
			string result;
			if (!(this.intptr_0 == IntPtr.Zero))
			{
				int num = GClass28.CFStringGetLength(this.intptr_0);
				IntPtr intPtr = GClass28.CFStringGetCharactersPtr(this.intptr_0);
				IntPtr intPtr2 = IntPtr.Zero;
				if (intPtr == IntPtr.Zero)
				{
					GStruct5 range = new GStruct5(0, num);
					intPtr2 = Marshal.AllocCoTaskMem(num * 2);
					GClass28.CFStringGetCharacters(this.intptr_0, range, intPtr2);
					intPtr = intPtr2;
				}
				string text = new string((char*)((void*)intPtr), 0, num);
				if (intPtr2 != IntPtr.Zero)
				{
					Marshal.FreeCoTaskMem(intPtr2);
				}
				result = text;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000416 RID: 1046 RVA: 0x00027FB4 File Offset: 0x000261B4
		private string method_3()
		{
			IntPtr intPtr = Marshal.AllocCoTaskMem(GClass28.CFNumberGetByteSize(this.intptr_0));
			string result;
			if (!GClass28.CFNumberGetValue(this.intptr_0, GClass28.CFNumberGetType(this.intptr_0), intPtr))
			{
				result = string.Empty;
			}
			else
			{
				int num = (int)GClass28.CFNumberGetType(this.intptr_0);
				switch (num)
				{
				case 1:
					result = Marshal.ReadInt16(intPtr).ToString();
					break;
				case 2:
					result = Marshal.ReadInt16(intPtr).ToString();
					break;
				case 3:
					result = Marshal.ReadInt32(intPtr).ToString();
					break;
				case 4:
					result = Marshal.ReadInt64(intPtr).ToString();
					break;
				default:
					result = Enum.GetName(typeof(GClass33.GEnum7), num) + " is not supported yet!";
					break;
				}
			}
			return result;
		}

		// Token: 0x06000417 RID: 1047 RVA: 0x0002809C File Offset: 0x0002629C
		private string method_4()
		{
			return GClass28.CFBooleanGetValue(this.intptr_0).ToString();
		}

		// Token: 0x06000418 RID: 1048 RVA: 0x000280C0 File Offset: 0x000262C0
		private string method_5()
		{
			GClass31 gclass = new GClass31(this.intptr_0);
			return Convert.ToBase64String(gclass.method_9());
		}

		// Token: 0x06000419 RID: 1049 RVA: 0x000280E8 File Offset: 0x000262E8
		private string method_6()
		{
			return Encoding.UTF8.GetString(new GClass31(GClass28.CFPropertyListCreateXMLData(IntPtr.Zero, this.intptr_0)).method_9());
		}

		// Token: 0x0600041A RID: 1050 RVA: 0x0002811C File Offset: 0x0002631C
		public override string ToString()
		{
			int num = GClass28.CFGetTypeID(this.intptr_0);
			int num2 = num;
			string result;
			if (num2 != 7)
			{
				switch (num2)
				{
				case 17:
					return this.method_6();
				case 18:
					return this.method_6();
				case 19:
					return this.method_5();
				case 21:
					return this.method_4();
				case 22:
					return this.method_3();
				}
				result = null;
			}
			else
			{
				result = this.method_2();
			}
			return result;
		}

		// Token: 0x0600041B RID: 1051 RVA: 0x00027C08 File Offset: 0x00025E08
		public static IntPtr smethod_0(GClass29 value)
		{
			return value.intptr_0;
		}

		// Token: 0x0600041C RID: 1052 RVA: 0x00028198 File Offset: 0x00026398
		public static GClass29 smethod_1(IntPtr value)
		{
			return new GClass29(value);
		}

		// Token: 0x040003A6 RID: 934
		internal const int int_0 = 18;

		// Token: 0x040003A7 RID: 935
		internal const int int_1 = 21;

		// Token: 0x040003A8 RID: 936
		internal const int int_2 = 19;

		// Token: 0x040003A9 RID: 937
		internal const int int_3 = 22;

		// Token: 0x040003AA RID: 938
		internal const int int_4 = 17;

		// Token: 0x040003AB RID: 939
		internal const int int_5 = 7;

		// Token: 0x040003AC RID: 940
		internal IntPtr intptr_0;
	}
}
