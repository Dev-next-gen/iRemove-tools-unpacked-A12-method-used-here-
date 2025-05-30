using System;
using System.Runtime.InteropServices;

namespace ns10
{
	// Token: 0x0200006B RID: 107
	public class GClass28
	{
		// Token: 0x060003D3 RID: 979
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr CFArrayCreate(IntPtr allocator, IntPtr[] keys, int numValues, IntPtr callbacks);

		// Token: 0x060003D4 RID: 980
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int CFArrayGetCount(IntPtr theArray);

		// Token: 0x060003D5 RID: 981
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr CFArrayGetValueAtIndex(IntPtr theArray, int index);

		// Token: 0x060003D6 RID: 982
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool CFBooleanGetValue(IntPtr theBoolean);

		// Token: 0x060003D7 RID: 983
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int CFDataGetLength(IntPtr theData);

		// Token: 0x060003D8 RID: 984
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr CFDataGetBytePtr(IntPtr theData);

		// Token: 0x060003D9 RID: 985
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void CFDataGetBytes(IntPtr theData, GStruct5 range, IntPtr buffer);

		// Token: 0x060003DA RID: 986
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr CFDataCreate(IntPtr theAllocator, IntPtr bytes, int bytelength);

		// Token: 0x060003DB RID: 987
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr CFDictionaryGetValue(IntPtr theDict, IntPtr key);

		// Token: 0x060003DC RID: 988
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int CFDictionaryGetCount(IntPtr theDict);

		// Token: 0x060003DD RID: 989
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr CFDictionaryGetKeysAndValues(IntPtr theDict, IntPtr[] keys, IntPtr[] values);

		// Token: 0x060003DE RID: 990
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr CFDictionaryCreate(IntPtr allocator, IntPtr[] keys, IntPtr[] values, int numValues, ref GClass32.GStruct3 kcall, ref GClass32.GStruct4 vcall);

		// Token: 0x060003DF RID: 991
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		public unsafe static extern IntPtr CFNumberCreate(IntPtr theAllocator, GClass33.GEnum7 theType, int* valuePtr);

		// Token: 0x060003E0 RID: 992
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool CFNumberGetValue(IntPtr theNumber, IntPtr pint, IntPtr valuePtr);

		// Token: 0x060003E1 RID: 993
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr CFNumberGetType(IntPtr theNumber);

		// Token: 0x060003E2 RID: 994
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int CFNumberGetByteSize(IntPtr theNumber);

		// Token: 0x060003E3 RID: 995
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool CFPropertyListIsValid(IntPtr theList, IntPtr theFormat);

		// Token: 0x060003E4 RID: 996
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr CFPropertyListCreateXMLData(IntPtr theAllocator, IntPtr theList);

		// Token: 0x060003E5 RID: 997
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr CFPropertyListCreateWithData(IntPtr theAllocator, IntPtr theData, int options, int format, IntPtr errorString);

		// Token: 0x060003E6 RID: 998
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr CFPropertyListCreateFromStream(IntPtr allocator, IntPtr stream, int length, int options, int format, IntPtr errorString);

		// Token: 0x060003E7 RID: 999
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int CFPropertyListWriteToStream(IntPtr propertyList, IntPtr stream, int format, IntPtr errorString);

		// Token: 0x060003E8 RID: 1000
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "CFPropertyListIsValid")]
		public static extern bool CFPropertyListIsValid_1(IntPtr plist, int format);

		// Token: 0x060003E9 RID: 1001
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr __CFStringMakeConstantString(string cstring);

		// Token: 0x060003EA RID: 1002
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int CFStringGetLength(IntPtr handle);

		// Token: 0x060003EB RID: 1003
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr CFStringGetCharactersPtr(IntPtr handle);

		// Token: 0x060003EC RID: 1004
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr CFStringGetCharacters(IntPtr handle, GStruct5 range, IntPtr buffer);

		// Token: 0x060003ED RID: 1005
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr CFReadStreamCreateWithFile(IntPtr alloc, IntPtr fileURL);

		// Token: 0x060003EE RID: 1006
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool CFReadStreamOpen(IntPtr stream);

		// Token: 0x060003EF RID: 1007
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void CFReadStreamClose(IntPtr stream);

		// Token: 0x060003F0 RID: 1008
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int CFGetTypeID(IntPtr typeRef);

		// Token: 0x060003F1 RID: 1009
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr CFCopyDescription(IntPtr typeRef);

		// Token: 0x060003F2 RID: 1010
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr CFCopyTypeIDDescription(int typeID);

		// Token: 0x060003F3 RID: 1011
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr CFURLCreateWithFileSystemPath(IntPtr allocator, IntPtr filePath, int pathStyle, bool isDirectory);

		// Token: 0x060003F4 RID: 1012
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr CFWriteStreamCreateWithFile(IntPtr allocator, IntPtr fileURL);

		// Token: 0x060003F5 RID: 1013
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool CFWriteStreamOpen(IntPtr stream);

		// Token: 0x060003F6 RID: 1014
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void CFWriteStreamClose(IntPtr stream);
	}
}
