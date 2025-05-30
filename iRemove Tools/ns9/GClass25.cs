using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.VisualBasic;

namespace ns9
{
	// Token: 0x0200005C RID: 92
	public class GClass25
	{
		// Token: 0x0600031E RID: 798 RVA: 0x00026890 File Offset: 0x00024A90
		static GClass25()
		{
			GClass25.kCFStreamPropertyDataWritten = GClass25.smethod_1("kCFStreamPropertyDataWritten");
			GClass25.kCFTypeDictionaryKeyCallBacks = GClass25.smethod_2("kCFTypeDictionaryKeyCallBacks");
			GClass25.kCFTypeDictionaryValueCallBacks = GClass25.smethod_2("kCFTypeDictionaryValueCallBacks");
			GClass25.kCFTypeArrayCallBacks = GClass25.smethod_2("kCFTypeArrayCallBacks");
			GClass25.kCFBooleanFalse = GClass24.smethod_0(false);
			GClass25.kCFBooleanTrue = GClass24.smethod_0(true);
		}

		// Token: 0x0600031F RID: 799 RVA: 0x00026938 File Offset: 0x00024B38
		internal static IntPtr smethod_0()
		{
			if (GClass25.kCFStreamPropertyDataWritten == IntPtr.Zero)
			{
				IntPtr moduleHandle = GClass25.GetModuleHandle("CoreFoundation.dll");
				if (moduleHandle == IntPtr.Zero)
				{
					GClass25.kCFStreamPropertyDataWritten = Marshal.ReadIntPtr(GClass25.kCFStreamPropertyDataWritten, 0);
				}
				else
				{
					GClass25.kCFStreamPropertyDataWritten = GClass25.GetProcAddress(moduleHandle, "kCFStreamPropertyDataWritten");
				}
			}
			return GClass25.kCFStreamPropertyDataWritten;
		}

		// Token: 0x06000320 RID: 800 RVA: 0x00026998 File Offset: 0x00024B98
		internal static IntPtr smethod_1(string enmName)
		{
			IntPtr ptr = IntPtr.Zero;
			IntPtr moduleHandle = GClass25.GetModuleHandle("CoreFoundation.dll");
			if (moduleHandle != IntPtr.Zero)
			{
				ptr = GClass25.GetProcAddress(moduleHandle, enmName);
			}
			return Marshal.ReadIntPtr(ptr, 0);
		}

		// Token: 0x06000321 RID: 801 RVA: 0x00026998 File Offset: 0x00024B98
		public static IntPtr smethod_2(string constName)
		{
			IntPtr ptr = IntPtr.Zero;
			IntPtr moduleHandle = GClass25.GetModuleHandle("CoreFoundation.dll");
			if (moduleHandle != IntPtr.Zero)
			{
				ptr = GClass25.GetProcAddress(moduleHandle, constName);
			}
			return Marshal.ReadIntPtr(ptr, 0);
		}

		// Token: 0x06000322 RID: 802 RVA: 0x000269D4 File Offset: 0x00024BD4
		public static string smethod_3(IntPtr propertyList)
		{
			string result = string.Empty;
			try
			{
				IntPtr intPtr = GClass25.CFWriteStreamCreateWithAllocatedBuffers(IntPtr.Zero, IntPtr.Zero);
				if (!(intPtr != IntPtr.Zero) || !GClass25.CFWriteStreamOpen(intPtr))
				{
					return result;
				}
				IntPtr zero = IntPtr.Zero;
				if (GClass25.CFPropertyListWriteToStream(propertyList, intPtr, Enum6.const_2, ref zero) > 0)
				{
					IntPtr propertyName = GClass25.kCFStreamPropertyDataWritten;
					IntPtr intPtr2 = GClass25.CFWriteStreamCopyProperty(intPtr, propertyName);
					if (GClass25.CFDataGetLength(intPtr2) > 0)
					{
						byte[] bytes = GClass25.smethod_18(intPtr2);
						result = Encoding.UTF8.GetString(bytes).Replace("\0", string.Empty);
					}
					GClass25.CFRelease(intPtr2);
				}
				GClass25.CFWriteStreamClose(intPtr);
			}
			catch
			{
			}
			return result;
		}

		// Token: 0x06000323 RID: 803 RVA: 0x00026A98 File Offset: 0x00024C98
		public static string smethod_4(object objPlist)
		{
			string result = string.Empty;
			try
			{
				IntPtr propertyList = GClass25.smethod_7(objPlist);
				IntPtr intPtr = GClass25.CFWriteStreamCreateWithAllocatedBuffers(IntPtr.Zero, IntPtr.Zero);
				if (!(intPtr != IntPtr.Zero) || !GClass25.CFWriteStreamOpen(intPtr))
				{
					return result;
				}
				IntPtr zero = IntPtr.Zero;
				if (GClass25.CFPropertyListWriteToStream(propertyList, intPtr, Enum6.const_2, ref zero) > 0)
				{
					IntPtr propertyName = GClass25.kCFStreamPropertyDataWritten;
					IntPtr intPtr2 = GClass25.CFWriteStreamCopyProperty(intPtr, propertyName);
					if (GClass25.CFDataGetLength(intPtr2) > 0)
					{
						byte[] bytes = GClass25.smethod_18(intPtr2);
						result = Encoding.UTF8.GetString(bytes).Replace("\0", string.Empty);
					}
					GClass25.CFRelease(intPtr2);
				}
				GClass25.CFWriteStreamClose(intPtr);
			}
			catch
			{
			}
			return result;
		}

		// Token: 0x06000324 RID: 804
		[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern IntPtr GetModuleHandle(string lpModuleName);

		// Token: 0x06000325 RID: 805
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

		// Token: 0x06000326 RID: 806
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		internal static extern IntPtr __CFStringMakeConstantString(string cStr);

		// Token: 0x06000327 RID: 807
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr CFAbsoluteTimeGetGregorianDate(ref double at, ref IntPtr tz);

		// Token: 0x06000328 RID: 808
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		private static extern int CFArrayGetCount(IntPtr sourceRef);

		// Token: 0x06000329 RID: 809
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		private static extern uint CFArrayGetTypeID();

		// Token: 0x0600032A RID: 810
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		private static extern void CFArrayGetValues(IntPtr sourceRef, Struct8 range, IntPtr values);

		// Token: 0x0600032B RID: 811
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		private static extern uint CFBooleanGetTypeID();

		// Token: 0x0600032C RID: 812
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		internal static extern IntPtr CFDateCreate(IntPtr intptr_2, double double_0);

		// Token: 0x0600032D RID: 813
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		internal static extern IntPtr CFDataCreate(IntPtr intptr_2, IntPtr intptr_3, int int_1);

		// Token: 0x0600032E RID: 814
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		private static extern bool CFBooleanGetValue(IntPtr sourceRef);

		// Token: 0x0600032F RID: 815
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		private static extern void CFDataAppendBytes(IntPtr theData, IntPtr pointer, uint length);

		// Token: 0x06000330 RID: 816
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr CFDataCreateMutable(IntPtr allocator, uint capacity);

		// Token: 0x06000331 RID: 817
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		internal static extern IntPtr CFDataGetBytePtr(IntPtr sourceRef);

		// Token: 0x06000332 RID: 818
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		private static extern void CFDataGetBytes(IntPtr theData, Struct8 range, byte[] buffer);

		// Token: 0x06000333 RID: 819
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		internal static extern int CFDataGetLength(IntPtr sourceRef);

		// Token: 0x06000334 RID: 820
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		private static extern uint CFDataGetTypeID();

		// Token: 0x06000335 RID: 821
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		private static extern double CFDateGetAbsoluteTime(IntPtr sourceRef);

		// Token: 0x06000336 RID: 822
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		private static extern uint CFDateGetTypeID();

		// Token: 0x06000337 RID: 823
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
		internal static extern void CFDictionaryAddValue(IntPtr theDict, IntPtr keys, IntPtr values);

		// Token: 0x06000338 RID: 824
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
		internal static extern IntPtr CFDictionaryCreate(IntPtr allocator, ref IntPtr keys, ref IntPtr values, int numValues, IntPtr CFDictionaryKeyCallBacks, IntPtr CFDictionaryValueCallBacks);

		// Token: 0x06000339 RID: 825
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		internal static extern IntPtr CFDictionaryCreateMutable(IntPtr allocator, int capacity, IntPtr CFDictionaryKeyCallBacks, IntPtr CFDictionaryValueCallBacks);

		// Token: 0x0600033A RID: 826 RVA: 0x00026B64 File Offset: 0x00024D64
		public static IntPtr smethod_5(Dictionary<object, object> sourceDict)
		{
			IntPtr result;
			if (sourceDict == null)
			{
				result = IntPtr.Zero;
			}
			else
			{
				IntPtr intPtr = IntPtr.Zero;
				try
				{
					intPtr = GClass25.CFDictionaryCreateMutable(GClass25.intptr_0, sourceDict.Count, GClass25.kCFTypeDictionaryKeyCallBacks, GClass25.kCFTypeDictionaryValueCallBacks);
					foreach (KeyValuePair<object, object> keyValuePair in sourceDict)
					{
						IntPtr intPtr2 = GClass25.smethod_7(keyValuePair.Key);
						IntPtr intPtr3 = GClass25.smethod_7(keyValuePair.Value);
						if (intPtr2 != IntPtr.Zero && intPtr3 != IntPtr.Zero)
						{
							GClass25.CFDictionaryAddValue(intPtr, intPtr2, intPtr3);
						}
					}
				}
				catch
				{
				}
				result = intPtr;
			}
			return result;
		}

		// Token: 0x0600033B RID: 827
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		internal static extern IntPtr CFWriteStreamCreateWithAllocatedBuffers(IntPtr intptr_2, IntPtr intptr_3);

		// Token: 0x0600033C RID: 828
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		internal static extern int CFPropertyListWriteToStream(IntPtr propertyList, IntPtr stream, Enum6 format, ref IntPtr errorString);

		// Token: 0x0600033D RID: 829
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		internal static extern bool CFWriteStreamOpen(IntPtr intptr_2);

		// Token: 0x0600033E RID: 830
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr CFNumberCreate(IntPtr intptr_2, GEnum5 enum20_0, IntPtr intptr_3);

		// Token: 0x0600033F RID: 831
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr CFNumberCreate_Int16(IntPtr number, GEnum5 theType, ref short valuePtr);

		// Token: 0x06000340 RID: 832
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "CFNumberCreate")]
		public static extern IntPtr CFNumberCreate_1(IntPtr number, GEnum5 theType, ref int valuePtr);

		// Token: 0x06000341 RID: 833
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "CFNumberCreate")]
		public static extern IntPtr CFNumberCreate_2(IntPtr number, GEnum5 theType, ref long valuePtr);

		// Token: 0x06000342 RID: 834
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "CFNumberCreate")]
		public static extern IntPtr CFNumberCreate_3(IntPtr number, GEnum5 theType, ref float valuePtr);

		// Token: 0x06000343 RID: 835
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "CFNumberCreate")]
		public static extern IntPtr CFNumberCreate_4(IntPtr number, GEnum5 theType, ref double valuePtr);

		// Token: 0x06000344 RID: 836 RVA: 0x00026C38 File Offset: 0x00024E38
		internal static IntPtr smethod_6(object objVals)
		{
			Type type = objVals.GetType();
			IntPtr result;
			if (!(type == typeof(short)))
			{
				if (!(type == typeof(int)) && !(type == typeof(ushort)))
				{
					if (type == typeof(long) || type == typeof(uint))
					{
						long num = Convert.ToInt64(objVals);
						result = GClass25.CFNumberCreate_2(GClass25.intptr_0, GEnum5.const_3, ref num);
					}
					else if (type == typeof(float))
					{
						float num2 = Convert.ToSingle(objVals);
						result = GClass25.CFNumberCreate_3(GClass25.intptr_0, GEnum5.const_4, ref num2);
					}
					else
					{
						if (type != typeof(double))
						{
							throw new NotImplementedException();
						}
						double num3 = Convert.ToDouble(objVals);
						result = GClass25.CFNumberCreate_4(GClass25.intptr_0, GEnum5.const_5, ref num3);
					}
				}
				else
				{
					int num4 = Convert.ToInt32(objVals);
					result = GClass25.CFNumberCreate_1(GClass25.intptr_0, GEnum5.const_2, ref num4);
				}
			}
			else
			{
				short num5 = Convert.ToInt16(objVals);
				result = GClass25.CFNumberCreate_Int16(GClass25.intptr_0, GEnum5.const_1, ref num5);
			}
			return result;
		}

		// Token: 0x06000345 RID: 837 RVA: 0x00026D5C File Offset: 0x00024F5C
		public static IntPtr smethod_7(object objVal)
		{
			IntPtr result;
			if (objVal == null)
			{
				result = IntPtr.Zero;
			}
			else
			{
				IntPtr intPtr = IntPtr.Zero;
				Type type = objVal.GetType();
				try
				{
					if (type == typeof(string))
					{
						return GClass25.smethod_25((string)objVal);
					}
					if (type == typeof(short) || type == typeof(ushort) || type == typeof(int) || type == typeof(uint) || type == typeof(long) || type == typeof(double) || type == typeof(float))
					{
						return GClass25.smethod_6(objVal);
					}
					if (type == typeof(bool))
					{
						return GClass24.smethod_0(Convert.ToBoolean(objVal));
					}
					if (type == typeof(DateTime))
					{
						string date = new DateTime(2001, 1, 1, 0, 0, 0, 0).ToString();
						string date2 = Convert.ToString(objVal);
						double double_ = (double)DateAndTime.DateDiff("s", date, date2, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1);
						return GClass25.CFDateCreate(GClass25.intptr_0, double_);
					}
					if (type == typeof(byte[]))
					{
						byte[] array = objVal as byte[];
						IntPtr pointer = Marshal.UnsafeAddrOfPinnedArrayElement<byte>(array, 0);
						intPtr = GClass25.CFDataCreateMutable(GClass25.intptr_0, (uint)array.Length);
						GClass25.CFDataAppendBytes(intPtr, pointer, (uint)array.Length);
						return intPtr;
					}
					if (type == typeof(object[]))
					{
						return GClass25.smethod_10((object[])objVal);
					}
					if (type == typeof(ArrayList))
					{
						return GClass25.smethod_9(objVal as ArrayList);
					}
					if (type == typeof(List<object>))
					{
						return GClass25.smethod_8(objVal as List<object>);
					}
					if (type == typeof(Dictionary<object, object>))
					{
						intPtr = GClass25.smethod_5(objVal as Dictionary<object, object>);
					}
				}
				catch
				{
				}
				result = intPtr;
			}
			return result;
		}

		// Token: 0x06000346 RID: 838 RVA: 0x00026FA0 File Offset: 0x000251A0
		public static IntPtr smethod_8(IList<object> arrySrc)
		{
			IntPtr result;
			if (arrySrc == null)
			{
				result = IntPtr.Zero;
			}
			else
			{
				IntPtr intPtr = GClass25.CFArrayCreateMutable(GClass25.intptr_0, arrySrc.Count, GClass25.kCFTypeArrayCallBacks);
				foreach (object obj in arrySrc)
				{
					if (obj != null)
					{
						GClass25.CFArrayAppendValue(intPtr, GClass25.smethod_7(obj));
					}
				}
				result = intPtr;
			}
			return result;
		}

		// Token: 0x06000347 RID: 839 RVA: 0x00027020 File Offset: 0x00025220
		public static IntPtr smethod_9(ArrayList arrySrc)
		{
			IntPtr result;
			if (arrySrc == null)
			{
				result = IntPtr.Zero;
			}
			else
			{
				IntPtr intPtr = GClass25.CFArrayCreateMutable(GClass25.intptr_0, arrySrc.Count, GClass25.kCFTypeArrayCallBacks);
				foreach (object obj in arrySrc)
				{
					if (obj != null)
					{
						GClass25.CFArrayAppendValue(intPtr, GClass25.smethod_7(obj));
					}
				}
				result = intPtr;
			}
			return result;
		}

		// Token: 0x06000348 RID: 840
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		internal static extern IntPtr CFArrayCreateMutable(IntPtr allocator, int capacity, IntPtr callback);

		// Token: 0x06000349 RID: 841 RVA: 0x000270AC File Offset: 0x000252AC
		public static IntPtr smethod_10(object[] arrySrc)
		{
			IntPtr result;
			if (arrySrc == null)
			{
				result = IntPtr.Zero;
			}
			else
			{
				IntPtr intPtr = IntPtr.Zero;
				try
				{
					intPtr = GClass25.CFArrayCreateMutable(GClass25.intptr_0, arrySrc.Length, GClass25.kCFTypeArrayCallBacks);
					foreach (object obj in arrySrc)
					{
						if (obj != null)
						{
							GClass25.CFArrayAppendValue(intPtr, GClass25.smethod_7(obj));
						}
					}
				}
				catch
				{
				}
				result = intPtr;
			}
			return result;
		}

		// Token: 0x0600034A RID: 842
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		internal static extern IntPtr CFArrayAppendValue(IntPtr intptr_2, IntPtr intptr_3);

		// Token: 0x0600034B RID: 843
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int CFDictionaryGetCount(IntPtr sourceRef);

		// Token: 0x0600034C RID: 844
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		internal static extern void CFDictionaryGetKeysAndValues(IntPtr sourceRef, IntPtr keys, IntPtr values);

		// Token: 0x0600034D RID: 845
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		private static extern uint CFDictionaryGetTypeID();

		// Token: 0x0600034E RID: 846
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		private static extern uint CFGetTypeID(IntPtr cf);

		// Token: 0x0600034F RID: 847
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		private static extern GEnum5 CFNumberGetType(IntPtr sourceRef);

		// Token: 0x06000350 RID: 848
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		private static extern uint CFNumberGetTypeID();

		// Token: 0x06000351 RID: 849
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
		internal static extern bool CFNumberGetValue(IntPtr number, GEnum5 theType, ref float valuePtr);

		// Token: 0x06000352 RID: 850
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "CFNumberGetValue")]
		internal static extern bool CFNumberGetValue_1(IntPtr number, GEnum5 theType, ref double valuePtr);

		// Token: 0x06000353 RID: 851
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "CFNumberGetValue")]
		internal static extern bool CFNumberGetValue_2(IntPtr number, GEnum5 theType, ref int valuePtr);

		// Token: 0x06000354 RID: 852
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "CFNumberGetValue")]
		internal static extern bool CFNumberGetValue_3(IntPtr number, GEnum5 theType, ref long valuePtr);

		// Token: 0x06000355 RID: 853
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "CFNumberGetValue")]
		internal static extern bool CFNumberGetValue_4(IntPtr number, GEnum5 theType, ref float valuePtr);

		// Token: 0x06000356 RID: 854
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		internal static extern IntPtr CFPropertyListCreateFromXMLData(IntPtr allocator, IntPtr xmlData, Enum7 mutabilityOption, ref IntPtr errorString);

		// Token: 0x06000357 RID: 855
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "CFPropertyListCreateFromXMLData")]
		internal static extern IntPtr CFPropertyListCreateFromXMLData_1(IntPtr allocator, IntPtr datas, Enum7 option, ref IntPtr errorString);

		// Token: 0x06000358 RID: 856
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		internal static extern IntPtr CFPropertyListCreateXMLData(IntPtr allocator, IntPtr theData);

		// Token: 0x06000359 RID: 857
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		private static extern bool CFPropertyListIsValid(IntPtr theData, Enum6 format);

		// Token: 0x0600035A RID: 858
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		internal static extern IntPtr CFPropertyListCreateData(IntPtr allocator, IntPtr list, Enum6 format, Enum7 option, ref IntPtr errorString);

		// Token: 0x0600035B RID: 859
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "__CFStringMakeConstantString")]
		public static extern IntPtr __CFStringMakeConstantString_1(string cstring);

		// Token: 0x0600035C RID: 860
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr CFArrayCreate(IntPtr allocator, IntPtr[] keys, int numValues, IntPtr callbacks);

		// Token: 0x0600035D RID: 861
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr CFArrayGetValueAtIndex(IntPtr theArray, int index);

		// Token: 0x0600035E RID: 862
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr CFCopyDescription(IntPtr typeRef);

		// Token: 0x0600035F RID: 863
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr CFCopyTypeIDDescription(int typeID);

		// Token: 0x06000360 RID: 864
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "CFDictionaryGetKeysAndValues")]
		public static extern IntPtr CFDictionaryGetKeysAndValues_1(IntPtr theDict, IntPtr[] keys, IntPtr[] values);

		// Token: 0x06000361 RID: 865
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr CFDictionaryGetValue(IntPtr theDict, IntPtr key);

		// Token: 0x06000362 RID: 866
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void CFDictionaryRemoveValue(IntPtr theDict, IntPtr key);

		// Token: 0x06000363 RID: 867
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void CFDictionarySetValue(IntPtr theDict, IntPtr key, IntPtr value);

		// Token: 0x06000364 RID: 868
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int CFNumberGetByteSize(IntPtr theNumber);

		// Token: 0x06000365 RID: 869
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "CFNumberGetValue")]
		public static extern bool CFNumberGetValue_5(IntPtr theNumber, IntPtr pint, IntPtr valuePtr);

		// Token: 0x06000366 RID: 870
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr CFPropertyListCreateFromStream(IntPtr allocator, IntPtr stream, int length, int options, int format, IntPtr errorString);

		// Token: 0x06000367 RID: 871
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr CFPropertyListCreateWithData(IntPtr theAllocator, IntPtr theData, int options, int format, IntPtr errorString);

		// Token: 0x06000368 RID: 872
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "CFPropertyListIsValid")]
		public static extern bool CFPropertyListIsValid_1(IntPtr plist, int format);

		// Token: 0x06000369 RID: 873
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "CFPropertyListIsValid")]
		public static extern bool CFPropertyListIsValid_2(IntPtr theList, IntPtr theFormat);

		// Token: 0x0600036A RID: 874
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "CFPropertyListWriteToStream")]
		public static extern int CFPropertyListWriteToStream_1(IntPtr propertyList, IntPtr stream, int format, IntPtr errorString);

		// Token: 0x0600036B RID: 875
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void CFReadStreamClose(IntPtr stream);

		// Token: 0x0600036C RID: 876
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr CFReadStreamCreateWithFile(IntPtr alloc, IntPtr fileURL);

		// Token: 0x0600036D RID: 877
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool CFReadStreamOpen(IntPtr stream);

		// Token: 0x0600036E RID: 878
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr CFStringGetCharactersPtr(IntPtr handle);

		// Token: 0x0600036F RID: 879
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int CFStringGetLength(IntPtr handle);

		// Token: 0x06000370 RID: 880
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr CFURLCreateWithFileSystemPath(IntPtr allocator, IntPtr filePath, int pathStyle, bool isDirectory);

		// Token: 0x06000371 RID: 881
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void CFWriteStreamClose(IntPtr stream);

		// Token: 0x06000372 RID: 882
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr CFWriteStreamCreateWithFile(IntPtr allocator, IntPtr fileURL);

		// Token: 0x06000373 RID: 883 RVA: 0x00027128 File Offset: 0x00025328
		private static IntPtr smethod_11(int loc, int len)
		{
			IntPtr intPtr = Marshal.AllocHGlobal(8);
			Marshal.WriteInt32(intPtr, 0, loc);
			Marshal.WriteInt32(intPtr, 4, len);
			return intPtr;
		}

		// Token: 0x06000374 RID: 884
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void CFRelease(IntPtr cf);

		// Token: 0x06000375 RID: 885
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
		internal static extern IntPtr CFRetain(IntPtr obj);

		// Token: 0x06000376 RID: 886
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr CFStringCreateFromExternalRepresentation(IntPtr allocator, IntPtr data, GEnum6 encoding);

		// Token: 0x06000377 RID: 887
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr CFStringCreateExternalRepresentation(IntPtr allocator, IntPtr cfString, GEnum6 encoding, uint bytes);

		// Token: 0x06000378 RID: 888
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr CFStringCreateWithBytes(IntPtr allocator, byte[] data, ulong numBytes, GEnum6 encoding, bool isExternalRepresentation);

		// Token: 0x06000379 RID: 889
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
		internal static extern IntPtr CFStringGetCharacters(IntPtr handle, Struct8 range, IntPtr buffer);

		// Token: 0x0600037A RID: 890
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr CFStringCreateWithCharacters(IntPtr allocator, [MarshalAs(UnmanagedType.LPWStr)] string stingData, int strLength);

		// Token: 0x0600037B RID: 891
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr CFStringCreateWithBytesNoCopy(IntPtr allocator, byte[] data, ulong numBytes, GEnum6 encoding, bool isExternalRepresentation, IntPtr contentsDeallocator);

		// Token: 0x0600037C RID: 892
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr CFStringCreateWithCString(IntPtr allocator, string data, GEnum6 encoding);

		// Token: 0x0600037D RID: 893
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		private static extern Struct8 CFStringFind(IntPtr theString, IntPtr stringToFind, ushort compareOptions);

		// Token: 0x0600037E RID: 894
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		internal static extern int CFStringGetBytes(IntPtr theString, Struct8 range, uint encoding, byte lossByte, byte isExternalRepresentation, byte[] buffer, int maxBufLen, ref int usedBufLen);

		// Token: 0x0600037F RID: 895
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		internal static extern char CFStringGetCharacterAtIndex(IntPtr theString, int idx);

		// Token: 0x06000380 RID: 896
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		private static extern int CFStringGetMaximumSizeForEncoding(int length, uint encoding);

		// Token: 0x06000381 RID: 897
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr CFWriteStreamCopyProperty(IntPtr stream, IntPtr propertyName);

		// Token: 0x06000382 RID: 898
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		private static extern uint CFStringGetTypeID();

		// Token: 0x06000383 RID: 899 RVA: 0x00027150 File Offset: 0x00025350
		public static string smethod_12(byte[] value)
		{
			string result;
			if (value.Length > 9)
			{
				result = Encoding.UTF8.GetString(value, 9, (int)value[9]);
			}
			else
			{
				result = "";
			}
			return result;
		}

		// Token: 0x06000384 RID: 900
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr CFTimeZoneCopySystem();

		// Token: 0x06000385 RID: 901
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		private static extern bool CFURLCreateDataAndPropertiesFromResource(IntPtr allocator, IntPtr urlRef, ref IntPtr resourceData, ref IntPtr properties, IntPtr desiredProperties, ref int errorCode);

		// Token: 0x06000386 RID: 902
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "CFURLCreateWithFileSystemPath")]
		private static extern IntPtr CFURLCreateWithFileSystemPath_1(IntPtr allocator, IntPtr stringRef, Enum8 pathStyle, bool isDirectory);

		// Token: 0x06000387 RID: 903
		[DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool CFURLWriteDataAndPropertiesToResource(IntPtr urlRef, IntPtr dataToWrite, IntPtr propertiesToWrite, ref int errorCode);

		// Token: 0x06000388 RID: 904 RVA: 0x00027184 File Offset: 0x00025384
		public static object smethod_13(byte[] inBytes)
		{
			if (inBytes != null)
			{
				IntPtr intPtr = GClass25.CFDataCreateMutable(GClass25.intptr_0, (uint)inBytes.Length);
				IntPtr pointer = Marshal.UnsafeAddrOfPinnedArrayElement<byte>(inBytes, 0);
				GClass25.CFDataAppendBytes(intPtr, pointer, (uint)inBytes.Length);
				IntPtr zero = IntPtr.Zero;
				IntPtr value = GClass25.CFPropertyListCreateFromXMLData_1(GClass25.intptr_0, intPtr, Enum7.const_0, ref zero);
				if (value != IntPtr.Zero)
				{
					return GClass25.smethod_15(ref value);
				}
			}
			return null;
		}

		// Token: 0x06000389 RID: 905 RVA: 0x000271EC File Offset: 0x000253EC
		public static object smethod_14(string fileOnPC)
		{
			byte[] array = new byte[0];
			using (FileStream fileStream = new FileStream(fileOnPC, FileMode.Open))
			{
				array = new byte[fileStream.Length];
				fileStream.Read(array, 0, (int)fileStream.Length);
			}
			return GClass25.smethod_13(array);
		}

		// Token: 0x0600038A RID: 906 RVA: 0x0002724C File Offset: 0x0002544C
		public static object smethod_15(ref IntPtr srcRef)
		{
			object result;
			if (srcRef == IntPtr.Zero)
			{
				result = string.Empty;
			}
			else
			{
				uint num = GClass25.CFGetTypeID(srcRef);
				object obj = null;
				try
				{
					if (num == GClass25.CFStringGetTypeID())
					{
						obj = GClass25.smethod_22(srcRef);
					}
					else if (num == GClass25.CFArrayGetTypeID())
					{
						obj = GClass25.smethod_17(srcRef);
					}
					else if (num == GClass25.CFNumberGetTypeID())
					{
						obj = GClass25.smethod_21(srcRef);
					}
					else if (num == GClass25.CFDateGetTypeID())
					{
						obj = GClass25.smethod_19(srcRef);
					}
					else if (num == GClass25.CFBooleanGetTypeID())
					{
						obj = GClass25.CFBooleanGetValue(srcRef);
					}
					else if (num == GClass25.CFDictionaryGetTypeID())
					{
						obj = GClass25.smethod_20(srcRef);
					}
					else if (num == GClass25.CFDataGetTypeID())
					{
						obj = GClass25.smethod_18(srcRef);
					}
					else
					{
						obj = GClass25.smethod_22(srcRef);
						if (obj == null)
						{
							obj = GClass25.smethod_19(srcRef);
						}
					}
				}
				catch
				{
				}
				if (obj == null)
				{
					result = string.Empty;
				}
				else
				{
					result = obj;
				}
			}
			return result;
		}

		// Token: 0x0600038B RID: 907 RVA: 0x0002735C File Offset: 0x0002555C
		public static string smethod_16(byte[] propertyList)
		{
			try
			{
				int num = propertyList.Length;
				if (propertyList[0] == 98 && propertyList[1] == 112 && propertyList[2] == 108 && propertyList[3] == 105 && propertyList[4] == 115 && propertyList[5] == 116 && propertyList[6] == 48 && propertyList[7] == 48)
				{
					IntPtr zero = IntPtr.Zero;
					IntPtr intPtr = IntPtr.Zero;
					intPtr = GClass25.CFPropertyListCreateFromXMLData(IntPtr.Zero, intPtr, Enum7.const_0, ref zero);
					if (intPtr != IntPtr.Zero)
					{
						intPtr = GClass25.CFPropertyListCreateXMLData(IntPtr.Zero, intPtr);
						num = GClass25.CFDataGetLength(intPtr) - 1;
						propertyList = new byte[num + 1];
						Struct8 range = new Struct8(0, num);
						GClass25.CFDataGetBytes(intPtr, range, propertyList);
					}
				}
				return Encoding.UTF8.GetString(propertyList);
			}
			catch
			{
			}
			return null;
		}

		// Token: 0x0600038C RID: 908 RVA: 0x0002742C File Offset: 0x0002562C
		internal static object smethod_17(IntPtr srcRef)
		{
			object result;
			if (!(srcRef == IntPtr.Zero))
			{
				int num = GClass25.CFArrayGetCount(srcRef);
				if (num > 0)
				{
					object[] array = new object[num];
					IntPtr intPtr = Marshal.AllocCoTaskMem(num * 4 * 2);
					GClass25.CFArrayGetValues(srcRef, new Struct8(0, num), intPtr);
					for (int i = 0; i < num; i++)
					{
						IntPtr intPtr2 = Marshal.ReadIntPtr(intPtr, i * 4 * 2);
						array[i] = GClass25.smethod_15(ref intPtr2);
					}
					Marshal.FreeCoTaskMem(intPtr);
					result = array;
				}
				else
				{
					result = null;
				}
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0600038D RID: 909 RVA: 0x000274B8 File Offset: 0x000256B8
		internal static byte[] smethod_18(IntPtr srcRef)
		{
			byte[] result;
			if (!(srcRef == IntPtr.Zero))
			{
				int num = GClass25.CFDataGetLength(srcRef);
				if (num > 0)
				{
					IntPtr ptr = GClass25.CFDataGetBytePtr(srcRef);
					byte[] array = new byte[num];
					for (int i = 0; i < num; i++)
					{
						array[i] = Marshal.ReadByte(ptr, i);
					}
					result = array;
				}
				else
				{
					result = null;
				}
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0600038E RID: 910 RVA: 0x00027520 File Offset: 0x00025720
		internal static DateTime smethod_19(IntPtr srcRef)
		{
			DateTime result = DateTime.MinValue;
			if (srcRef != IntPtr.Zero)
			{
				double value = GClass25.CFDateGetAbsoluteTime(srcRef);
				result = new DateTime(2001, 1, 1, 0, 0, 0).AddSeconds(value);
			}
			return result;
		}

		// Token: 0x0600038F RID: 911 RVA: 0x00027568 File Offset: 0x00025768
		public static object smethod_20(IntPtr srcRef)
		{
			object result;
			if (!(srcRef == IntPtr.Zero))
			{
				int num = GClass25.CFDictionaryGetCount(srcRef);
				if (num > 0)
				{
					IntPtr intPtr = Marshal.AllocCoTaskMem(num * 4 * 2);
					IntPtr ptr = Marshal.AllocCoTaskMem(num * 4 * 2);
					Class5.smethod_0(srcRef, intPtr, ref ptr);
					Dictionary<object, object> dictionary = new Dictionary<object, object>();
					for (int i = 0; i < num; i++)
					{
						IntPtr intPtr2 = Marshal.ReadIntPtr(intPtr, i * 4 * 2);
						IntPtr intPtr3 = Marshal.ReadIntPtr(ptr, i * 4 * 2);
						object key = GClass25.smethod_15(ref intPtr2);
						object value = GClass25.smethod_15(ref intPtr3);
						dictionary.Add(key, value);
					}
					result = dictionary;
				}
				else
				{
					result = null;
				}
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000390 RID: 912 RVA: 0x00027614 File Offset: 0x00025814
		public static object smethod_21(IntPtr srcRef)
		{
			object result;
			if (!(srcRef == IntPtr.Zero))
			{
				object obj = null;
				switch (GClass25.CFNumberGetType(srcRef))
				{
				case GEnum5.const_0:
				case GEnum5.const_1:
				case GEnum5.const_2:
				case GEnum5.const_6:
				case GEnum5.const_7:
				case GEnum5.const_8:
				case GEnum5.const_9:
				case GEnum5.const_13:
				case GEnum5.const_14:
				{
					int num = 0;
					if (GClass25.CFNumberGetValue_2(srcRef, GEnum5.const_8, ref num))
					{
						obj = num;
					}
					return obj;
				}
				case GEnum5.const_3:
				case GEnum5.const_10:
				{
					long num2 = 0L;
					if (GClass25.CFNumberGetValue_3(srcRef, GEnum5.const_3, ref num2))
					{
						obj = num2;
					}
					break;
				}
				case GEnum5.const_4:
				case GEnum5.const_11:
				case GEnum5.const_15:
				{
					float num3 = 0f;
					if (GClass25.CFNumberGetValue(srcRef, GEnum5.const_11, ref num3))
					{
						obj = num3;
					}
					return obj;
				}
				case GEnum5.const_5:
				case GEnum5.const_12:
				{
					double num4 = 0.0;
					if (GClass25.CFNumberGetValue_1(srcRef, GEnum5.const_12, ref num4))
					{
						obj = num4;
					}
					return obj;
				}
				}
				result = obj;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000391 RID: 913 RVA: 0x0002770C File Offset: 0x0002590C
		public static string smethod_22(IntPtr srcRef)
		{
			string result;
			if (srcRef == IntPtr.Zero)
			{
				result = null;
			}
			else
			{
				result = Class6.smethod_0(srcRef);
			}
			return result;
		}

		// Token: 0x06000392 RID: 914 RVA: 0x00027734 File Offset: 0x00025934
		public static object smethod_23(string fileOnPC)
		{
			object result = null;
			try
			{
				IntPtr intPtr = IntPtr.Zero;
				int num = 0;
				using (FileStream fileStream = new FileStream(fileOnPC, FileMode.Open, FileAccess.Read))
				{
					num = (int)fileStream.Length;
					intPtr = Marshal.AllocCoTaskMem(num);
					byte[] array = new byte[num];
					fileStream.Read(array, 0, array.Length);
					Marshal.Copy(array, 0, intPtr, array.Length);
				}
				IntPtr intPtr2 = IntPtr.Zero;
				IntPtr intPtr3 = IntPtr.Zero;
				IntPtr zero = IntPtr.Zero;
				intPtr2 = GClass25.CFDataCreate(GClass25.intptr_0, intPtr, num);
				if (intPtr2 != IntPtr.Zero)
				{
					intPtr3 = GClass25.CFPropertyListCreateFromXMLData(GClass25.intptr_0, intPtr2, Enum7.const_0, ref zero);
					if (intPtr3 == IntPtr.Zero)
					{
						return null;
					}
				}
				if (intPtr2 != IntPtr.Zero)
				{
					try
					{
						GClass25.CFRelease(intPtr2);
					}
					catch
					{
					}
				}
				if (intPtr != IntPtr.Zero)
				{
					Marshal.FreeCoTaskMem(intPtr);
				}
				result = GClass25.smethod_15(ref intPtr3);
				if (intPtr3 != IntPtr.Zero)
				{
					GClass25.CFRelease(intPtr3);
				}
			}
			catch
			{
			}
			return result;
		}

		// Token: 0x06000393 RID: 915 RVA: 0x00027864 File Offset: 0x00025A64
		public static string smethod_24(string xmlText, string xmlKey)
		{
			string text = "";
			int num = Strings.InStr(xmlText, xmlKey, CompareMethod.Binary);
			if (num > 0)
			{
				int num2 = Strings.InStr(num, xmlText, "<string>", CompareMethod.Binary);
				if (num2 > num)
				{
					num2 += "<string>".Length;
					num = Strings.InStr(num2, xmlText, "</string>", CompareMethod.Binary);
					if (num > num2)
					{
						text = Strings.Mid(xmlText, num2, num - num2);
					}
				}
			}
			return text.Trim();
		}

		// Token: 0x06000394 RID: 916 RVA: 0x000278D4 File Offset: 0x00025AD4
		public static IntPtr smethod_25(string values)
		{
			IntPtr result = IntPtr.Zero;
			if (values != null)
			{
				byte[] bytes = Encoding.UTF8.GetBytes(values);
				int num = bytes.Length;
				IntPtr intPtr = GClass25.CFDataCreateMutable(IntPtr.Zero, (uint)num);
				IntPtr pointer = Marshal.UnsafeAddrOfPinnedArrayElement<byte>(bytes, 0);
				GClass25.CFDataAppendBytes(intPtr, pointer, (uint)num);
				result = GClass25.CFStringCreateFromExternalRepresentation(IntPtr.Zero, intPtr, (GEnum6)134217984);
			}
			return result;
		}

		// Token: 0x06000395 RID: 917 RVA: 0x00027934 File Offset: 0x00025B34
		public static IntPtr smethod_26(string src, Encoding encode)
		{
			IntPtr result;
			if (string.IsNullOrEmpty(src))
			{
				result = IntPtr.Zero;
			}
			else if (encode == null)
			{
				result = Marshal.StringToCoTaskMemAnsi(src);
			}
			else
			{
				int maxByteCount = encode.GetMaxByteCount(1);
				char[] array = src.ToCharArray();
				int num = encode.GetByteCount(array) + maxByteCount;
				byte[] array2 = new byte[0];
				array2 = new byte[num];
				if (encode.GetBytes(array, 0, array.Length, array2, 0) != array2.Length - maxByteCount)
				{
					throw new NotSupportedException("StringToHeap编码不支持");
				}
				IntPtr intPtr = Marshal.AllocCoTaskMem(array2.Length);
				if (intPtr == IntPtr.Zero)
				{
					throw new OutOfMemoryException();
				}
				bool flag = false;
				try
				{
					Marshal.Copy(array2, 0, intPtr, array2.Length);
					flag = true;
				}
				finally
				{
					if (!flag)
					{
						Marshal.FreeCoTaskMem(intPtr);
					}
				}
				result = intPtr;
			}
			return result;
		}

		// Token: 0x06000396 RID: 918 RVA: 0x00027A0C File Offset: 0x00025C0C
		public static bool smethod_27(IntPtr dataPtr, string fileOnPC)
		{
			bool flag = false;
			bool result;
			if (dataPtr == IntPtr.Zero)
			{
				result = false;
			}
			else
			{
				IntPtr intPtr = IntPtr.Zero;
				try
				{
					intPtr = GClass25.CFURLCreateWithFileSystemPath_1(GClass25.intptr_0, GClass25.smethod_25(fileOnPC), Enum8.const_2, false);
					if (intPtr != IntPtr.Zero)
					{
						IntPtr intPtr2 = GClass25.CFPropertyListCreateXMLData(GClass25.intptr_0, dataPtr);
						if (intPtr2 != IntPtr.Zero)
						{
							IntPtr zero = IntPtr.Zero;
							int num = -1;
							flag = GClass25.CFURLWriteDataAndPropertiesToResource(intPtr, intPtr2, zero, ref num);
							GClass25.CFRelease(intPtr2);
						}
						else
						{
							flag = false;
						}
						GClass25.CFRelease(intPtr);
						return flag;
					}
					flag = false;
				}
				catch
				{
				}
				result = flag;
			}
			return result;
		}

		// Token: 0x06000397 RID: 919 RVA: 0x00027AB4 File Offset: 0x00025CB4
		public static bool smethod_28(object dict, string fileOnPC)
		{
			return GClass25.smethod_27(GClass25.smethod_7(dict), fileOnPC);
		}

		// Token: 0x04000366 RID: 870
		public static IntPtr intptr_0 = IntPtr.Zero;

		// Token: 0x04000367 RID: 871
		public static IntPtr kCFBooleanFalse = IntPtr.Zero;

		// Token: 0x04000368 RID: 872
		public static IntPtr kCFBooleanTrue = IntPtr.Zero;

		// Token: 0x04000369 RID: 873
		public static IntPtr kCFStreamPropertyDataWritten = IntPtr.Zero;

		// Token: 0x0400036A RID: 874
		public static IntPtr kCFTypeArrayCallBacks = IntPtr.Zero;

		// Token: 0x0400036B RID: 875
		public static IntPtr kCFTypeDictionaryKeyCallBacks = IntPtr.Zero;

		// Token: 0x0400036C RID: 876
		public static IntPtr kCFTypeDictionaryValueCallBacks = IntPtr.Zero;
	}
}
