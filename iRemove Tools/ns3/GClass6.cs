using System;

namespace ns3
{
	// Token: 0x02000023 RID: 35
	public static class GClass6
	{
		// Token: 0x06000209 RID: 521 RVA: 0x00021594 File Offset: 0x0001F794
		public static bool smethod_0(string s)
		{
			bool flag;
			return bool.TryParse(s, out flag) && flag;
		}

		// Token: 0x0600020A RID: 522 RVA: 0x000215B0 File Offset: 0x0001F7B0
		public static bool[] smethod_1(string[] s)
		{
			return Array.ConvertAll<string, bool>(s, new Converter<string, bool>(GClass6.smethod_0));
		}

		// Token: 0x0600020B RID: 523 RVA: 0x000215D4 File Offset: 0x0001F7D4
		public static byte smethod_2(string s)
		{
			byte b;
			return byte.TryParse(s, out b) ? b : 0;
		}

		// Token: 0x0600020C RID: 524 RVA: 0x000215F4 File Offset: 0x0001F7F4
		public static byte[] smethod_3(string[] s)
		{
			return Array.ConvertAll<string, byte>(s, new Converter<string, byte>(GClass6.smethod_2));
		}

		// Token: 0x0600020D RID: 525 RVA: 0x00021618 File Offset: 0x0001F818
		public static sbyte smethod_4(string s)
		{
			sbyte b;
			return sbyte.TryParse(s, out b) ? b : 0;
		}

		// Token: 0x0600020E RID: 526 RVA: 0x00021638 File Offset: 0x0001F838
		public static sbyte[] smethod_5(string[] s)
		{
			return Array.ConvertAll<string, sbyte>(s, new Converter<string, sbyte>(GClass6.smethod_4));
		}

		// Token: 0x0600020F RID: 527 RVA: 0x0002165C File Offset: 0x0001F85C
		public static short smethod_6(string s)
		{
			return GClass6.smethod_7(s, 0);
		}

		// Token: 0x06000210 RID: 528 RVA: 0x00021674 File Offset: 0x0001F874
		public static short smethod_7(string s, short defaultValue)
		{
			short num;
			return short.TryParse(s, out num) ? num : defaultValue;
		}

		// Token: 0x06000211 RID: 529 RVA: 0x00021694 File Offset: 0x0001F894
		public static short[] smethod_8(string[] s)
		{
			return Array.ConvertAll<string, short>(s, new Converter<string, short>(GClass6.smethod_6));
		}

		// Token: 0x06000212 RID: 530 RVA: 0x000216B8 File Offset: 0x0001F8B8
		public static ushort smethod_9(string s)
		{
			return GClass6.smethod_10(s, 0);
		}

		// Token: 0x06000213 RID: 531 RVA: 0x000216D0 File Offset: 0x0001F8D0
		public static ushort smethod_10(string s, ushort defaultValue)
		{
			ushort num;
			return ushort.TryParse(s, out num) ? num : defaultValue;
		}

		// Token: 0x06000214 RID: 532 RVA: 0x000216F0 File Offset: 0x0001F8F0
		public static ushort[] smethod_11(string[] s)
		{
			return Array.ConvertAll<string, ushort>(s, new Converter<string, ushort>(GClass6.smethod_9));
		}

		// Token: 0x06000215 RID: 533 RVA: 0x00021714 File Offset: 0x0001F914
		public static int smethod_12(string s)
		{
			return GClass6.smethod_13(s, 0);
		}

		// Token: 0x06000216 RID: 534 RVA: 0x0002172C File Offset: 0x0001F92C
		public static int smethod_13(string s, int defaultValue)
		{
			int num;
			return int.TryParse(s, out num) ? num : defaultValue;
		}

		// Token: 0x06000217 RID: 535 RVA: 0x0002174C File Offset: 0x0001F94C
		public static int[] smethod_14(string[] s)
		{
			return Array.ConvertAll<string, int>(s, new Converter<string, int>(GClass6.smethod_12));
		}

		// Token: 0x06000218 RID: 536 RVA: 0x00021770 File Offset: 0x0001F970
		public static uint smethod_15(string s)
		{
			uint num;
			return uint.TryParse(s, out num) ? num : 0U;
		}

		// Token: 0x06000219 RID: 537 RVA: 0x00021790 File Offset: 0x0001F990
		public static uint smethod_16(string s, uint defalutValue)
		{
			uint num;
			return uint.TryParse(s, out num) ? num : defalutValue;
		}

		// Token: 0x0600021A RID: 538 RVA: 0x000217B0 File Offset: 0x0001F9B0
		public static uint[] smethod_17(string[] s)
		{
			return Array.ConvertAll<string, uint>(s, new Converter<string, uint>(GClass6.smethod_15));
		}

		// Token: 0x0600021B RID: 539 RVA: 0x000217D4 File Offset: 0x0001F9D4
		public static long smethod_18(string s, long defalutValue)
		{
			long num;
			return long.TryParse(s, out num) ? num : defalutValue;
		}

		// Token: 0x0600021C RID: 540 RVA: 0x000217F4 File Offset: 0x0001F9F4
		public static long smethod_19(string s)
		{
			return GClass6.smethod_18(s, 0L);
		}

		// Token: 0x0600021D RID: 541 RVA: 0x00021814 File Offset: 0x0001FA14
		public static long[] smethod_20(string[] s)
		{
			return Array.ConvertAll<string, long>(s, new Converter<string, long>(GClass6.smethod_19));
		}

		// Token: 0x0600021E RID: 542 RVA: 0x00021838 File Offset: 0x0001FA38
		public static ulong smethod_21(string s)
		{
			return GClass6.smethod_22(s, 0U);
		}

		// Token: 0x0600021F RID: 543 RVA: 0x00021850 File Offset: 0x0001FA50
		public static ulong smethod_22(string s, uint defaultValue)
		{
			ulong num;
			return ulong.TryParse(s, out num) ? num : ((ulong)defaultValue);
		}

		// Token: 0x06000220 RID: 544 RVA: 0x00021870 File Offset: 0x0001FA70
		public static ulong[] smethod_23(string[] s)
		{
			return Array.ConvertAll<string, ulong>(s, new Converter<string, ulong>(GClass6.smethod_21));
		}

		// Token: 0x06000221 RID: 545 RVA: 0x00021894 File Offset: 0x0001FA94
		public static float smethod_24(string s, float defaultValue)
		{
			float num;
			return float.TryParse(s, out num) ? num : defaultValue;
		}

		// Token: 0x06000222 RID: 546 RVA: 0x000218B4 File Offset: 0x0001FAB4
		public static float smethod_25(string s)
		{
			return GClass6.smethod_24(s, 0f);
		}

		// Token: 0x06000223 RID: 547 RVA: 0x000218D0 File Offset: 0x0001FAD0
		public static float[] smethod_26(string[] s)
		{
			return Array.ConvertAll<string, float>(s, new Converter<string, float>(GClass6.smethod_25));
		}

		// Token: 0x06000224 RID: 548 RVA: 0x000218F4 File Offset: 0x0001FAF4
		public static double smethod_27(string s, double defaultValue)
		{
			double num;
			return double.TryParse(s, out num) ? num : defaultValue;
		}

		// Token: 0x06000225 RID: 549 RVA: 0x00021914 File Offset: 0x0001FB14
		public static double smethod_28(string s)
		{
			return GClass6.smethod_27(s, 0.0);
		}

		// Token: 0x06000226 RID: 550 RVA: 0x00021934 File Offset: 0x0001FB34
		public static double[] smethod_29(string[] s)
		{
			return Array.ConvertAll<string, double>(s, new Converter<string, double>(GClass6.smethod_28));
		}

		// Token: 0x06000227 RID: 551 RVA: 0x00021894 File Offset: 0x0001FA94
		public static float smethod_30(string s, float defaultValue = 0f)
		{
			float num;
			return float.TryParse(s, out num) ? num : defaultValue;
		}

		// Token: 0x06000228 RID: 552 RVA: 0x00021958 File Offset: 0x0001FB58
		public static decimal smethod_31(string s, decimal defaultValue)
		{
			decimal num;
			return decimal.TryParse(s, out num) ? num : defaultValue;
		}

		// Token: 0x06000229 RID: 553 RVA: 0x00021978 File Offset: 0x0001FB78
		public static decimal smethod_32(string s)
		{
			return GClass6.smethod_31(s, 0m);
		}

		// Token: 0x0600022A RID: 554 RVA: 0x00021994 File Offset: 0x0001FB94
		public static decimal[] smethod_33(string[] s)
		{
			return Array.ConvertAll<string, decimal>(s, new Converter<string, decimal>(GClass6.smethod_32));
		}

		// Token: 0x0600022B RID: 555 RVA: 0x000219B8 File Offset: 0x0001FBB8
		public static DateTime smethod_34(string s, DateTime defaultValue)
		{
			DateTime dateTime;
			return DateTime.TryParse(s, out dateTime) ? dateTime : defaultValue;
		}

		// Token: 0x0600022C RID: 556 RVA: 0x000219D8 File Offset: 0x0001FBD8
		public static DateTime smethod_35(string s)
		{
			return GClass6.smethod_34(s, DateTime.MinValue);
		}

		// Token: 0x0600022D RID: 557 RVA: 0x000219F4 File Offset: 0x0001FBF4
		public static DateTime[] smethod_36(string[] s)
		{
			return Array.ConvertAll<string, DateTime>(s, new Converter<string, DateTime>(GClass6.smethod_35));
		}

		// Token: 0x0600022E RID: 558 RVA: 0x00021A18 File Offset: 0x0001FC18
		public static TimeSpan smethod_37(string s, TimeSpan defaultValue)
		{
			TimeSpan timeSpan;
			return TimeSpan.TryParse(s, out timeSpan) ? timeSpan : defaultValue;
		}

		// Token: 0x0600022F RID: 559 RVA: 0x00021A38 File Offset: 0x0001FC38
		public static TimeSpan smethod_38(string s)
		{
			return GClass6.smethod_37(s, TimeSpan.Zero);
		}

		// Token: 0x06000230 RID: 560 RVA: 0x00021A54 File Offset: 0x0001FC54
		public static TimeSpan[] smethod_39(string[] s)
		{
			return Array.ConvertAll<string, TimeSpan>(s, new Converter<string, TimeSpan>(GClass6.smethod_38));
		}

		// Token: 0x06000231 RID: 561 RVA: 0x00021A78 File Offset: 0x0001FC78
		public static object smethod_40(object obj, Type enumType)
		{
			object result;
			if (Enum.IsDefined(enumType, obj))
			{
				string[] names = Enum.GetNames(enumType);
				string text = obj.ToString();
				for (int i = 0; i < names.Length; i++)
				{
					if (text == names[i])
					{
						return Enum.Parse(enumType, text);
					}
				}
				result = Enum.ToObject(enumType, obj);
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000232 RID: 562 RVA: 0x00021AD4 File Offset: 0x0001FCD4
		public static T smethod_41<T>(object obj) where T : struct
		{
			int value = 0;
			bool flag = int.TryParse(obj.ToString(), out value);
			T result;
			if (Enum.IsDefined(typeof(T), obj))
			{
				string[] names = Enum.GetNames(typeof(T));
				string text = obj.ToString();
				for (int i = 0; i < names.Length; i++)
				{
					if (text == names[i])
					{
						return (T)((object)Enum.Parse(typeof(T), text));
					}
				}
				result = (T)((object)Enum.ToObject(typeof(T), obj));
			}
			else if (flag)
			{
				result = (T)((object)Enum.ToObject(typeof(T), value));
			}
			else
			{
				result = default(T);
			}
			return result;
		}

		// Token: 0x06000233 RID: 563 RVA: 0x00021B9C File Offset: 0x0001FD9C
		public static T[] smethod_42<T>(object[] s) where T : struct
		{
			return Array.ConvertAll<object, T>(s, new Converter<object, T>(GClass6.smethod_41<T>));
		}

		// Token: 0x06000234 RID: 564 RVA: 0x00021BC0 File Offset: 0x0001FDC0
		public static string smethod_43(string p)
		{
			return p;
		}

		// Token: 0x06000235 RID: 565 RVA: 0x00021BD0 File Offset: 0x0001FDD0
		public static DateTime? smethod_44(long timeStamp)
		{
			DateTime? result;
			if (timeStamp == 0L)
			{
				result = null;
			}
			else
			{
				DateTime dateTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
				long ticks = long.Parse(timeStamp.ToString() + "0000000");
				TimeSpan value = new TimeSpan(ticks);
				result = new DateTime?(dateTime.Add(value));
			}
			return result;
		}

		// Token: 0x06000236 RID: 566 RVA: 0x00021C40 File Offset: 0x0001FE40
		public static long smethod_45(DateTime time)
		{
			DateTime d = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
			return (long)(time - d).TotalSeconds;
		}
	}
}
