using System;
using System.Collections.Generic;

namespace ns3
{
	// Token: 0x02000021 RID: 33
	public class GClass4
	{
		// Token: 0x060001FB RID: 507 RVA: 0x000213F0 File Offset: 0x0001F5F0
		public static string smethod_0(Type enumType, object val)
		{
			return string.Empty;
		}

		// Token: 0x060001FC RID: 508 RVA: 0x00021404 File Offset: 0x0001F604
		public static IList<GClass5> smethod_1<T>()
		{
			IList<GClass5> list = new List<GClass5>();
			Type typeFromHandle = typeof(T);
			foreach (object obj in Enum.GetValues(typeof(T)))
			{
				int num = (int)obj;
				GClass5 gclass = new GClass5();
				gclass.String_0 = GClass4.smethod_0(typeFromHandle, num);
				GClass5 gclass2 = gclass;
				T t = GClass4.smethod_2<T>(num);
				gclass2.String_1 = t.ToString();
				gclass.Int32_0 = num;
				list.Add(gclass);
			}
			return list;
		}

		// Token: 0x060001FD RID: 509 RVA: 0x000214C0 File Offset: 0x0001F6C0
		public static T smethod_2<T>(int value)
		{
			return (T)((object)Enum.Parse(typeof(T), value.ToString(), true));
		}

		// Token: 0x060001FE RID: 510 RVA: 0x000214F0 File Offset: 0x0001F6F0
		public static T smethod_3<T>(string value)
		{
			return (T)((object)Enum.Parse(typeof(T), value.ToString(), true));
		}
	}
}
