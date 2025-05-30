using System;
using System.Runtime.InteropServices;

namespace ns9
{
	// Token: 0x02000059 RID: 89
	internal class Class6 : IDisposable
	{
		// Token: 0x0600030D RID: 781 RVA: 0x0000DAEC File Offset: 0x0000BCEC
		internal Class6(IntPtr handle) : this(handle, false)
		{
		}

		// Token: 0x0600030E RID: 782 RVA: 0x000265E0 File Offset: 0x000247E0
		internal Class6(string str)
		{
			if (str == null)
			{
				throw new ArgumentNullException("str");
			}
			this.intptr_0 = GClass25.CFStringCreateWithCharacters(IntPtr.Zero, str, str.Length);
			this.string_0 = str;
		}

		// Token: 0x0600030F RID: 783 RVA: 0x00026624 File Offset: 0x00024824
		internal Class6(IntPtr handle, bool owns)
		{
			this.intptr_0 = handle;
			if (!owns)
			{
				GClass25.CFRetain(handle);
			}
		}

		// Token: 0x06000310 RID: 784 RVA: 0x0002664C File Offset: 0x0002484C
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x06000311 RID: 785 RVA: 0x00026668 File Offset: 0x00024868
		protected virtual void Dispose(bool disposing)
		{
			this.string_0 = null;
			if (this.intptr_0 != IntPtr.Zero)
			{
				GClass25.CFRelease(this.intptr_0);
				this.intptr_0 = IntPtr.Zero;
			}
		}

		// Token: 0x06000312 RID: 786 RVA: 0x000266A4 File Offset: 0x000248A4
		public override bool Equals(object other)
		{
			Class6 @class = other as Class6;
			return !Class6.smethod_1(@class, null) && @class.IntPtr_0 == this.intptr_0;
		}

		// Token: 0x06000313 RID: 787 RVA: 0x000266D8 File Offset: 0x000248D8
		internal unsafe static string smethod_0(IntPtr handle)
		{
			string result;
			if (handle == IntPtr.Zero)
			{
				result = null;
			}
			else
			{
				int num = GClass25.CFStringGetLength(handle);
				IntPtr intPtr = GClass25.CFStringGetCharactersPtr(handle);
				IntPtr intPtr2 = IntPtr.Zero;
				if (intPtr == IntPtr.Zero)
				{
					Struct8 range = new Struct8(0, num);
					intPtr2 = Marshal.AllocCoTaskMem(num * 2);
					GClass25.CFStringGetCharacters(handle, range, intPtr2);
					intPtr = intPtr2;
				}
				result = new string((char*)((void*)intPtr), 0, num);
			}
			return result;
		}

		// Token: 0x06000314 RID: 788 RVA: 0x00026748 File Offset: 0x00024948
		~Class6()
		{
			this.Dispose(false);
		}

		// Token: 0x06000315 RID: 789 RVA: 0x00026778 File Offset: 0x00024978
		public override int GetHashCode()
		{
			return this.intptr_0.GetHashCode();
		}

		// Token: 0x06000316 RID: 790 RVA: 0x00026794 File Offset: 0x00024994
		public static bool smethod_1(Class6 a, Class6 b)
		{
			return object.Equals(a, b);
		}

		// Token: 0x06000317 RID: 791 RVA: 0x000267A8 File Offset: 0x000249A8
		public static string smethod_2(Class6 other)
		{
			if (string.IsNullOrEmpty(other.string_0))
			{
				other.string_0 = Class6.smethod_0(other.intptr_0);
			}
			return other.string_0;
		}

		// Token: 0x06000318 RID: 792 RVA: 0x000267DC File Offset: 0x000249DC
		public static Class6 smethod_3(string s)
		{
			return new Class6(s);
		}

		// Token: 0x06000319 RID: 793 RVA: 0x000267F4 File Offset: 0x000249F4
		public static bool smethod_4(Class6 a, Class6 b)
		{
			return !object.Equals(a, b);
		}

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x0600031A RID: 794 RVA: 0x0002680C File Offset: 0x00024A0C
		public IntPtr IntPtr_0
		{
			get
			{
				return this.intptr_0;
			}
		}

		// Token: 0x1700004E RID: 78
		public char this[int p]
		{
			get
			{
				char result;
				if (this.string_0 != null)
				{
					result = this.string_0[p];
				}
				else
				{
					result = GClass25.CFStringGetCharacterAtIndex(this.intptr_0, p);
				}
				return result;
			}
		}

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x0600031C RID: 796 RVA: 0x0002685C File Offset: 0x00024A5C
		internal int Int32_0
		{
			get
			{
				int result;
				if (this.string_0 != null)
				{
					result = this.string_0.Length;
				}
				else
				{
					result = GClass25.CFStringGetLength(this.intptr_0);
				}
				return result;
			}
		}

		// Token: 0x040002D9 RID: 729
		internal IntPtr intptr_0;

		// Token: 0x040002DA RID: 730
		internal string string_0;
	}
}
