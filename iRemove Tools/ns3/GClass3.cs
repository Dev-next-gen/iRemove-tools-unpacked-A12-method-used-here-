using System;
using System.Collections.Generic;

namespace ns3
{
	// Token: 0x02000020 RID: 32
	public static class GClass3
	{
		// Token: 0x060001F9 RID: 505 RVA: 0x000213A4 File Offset: 0x0001F5A4
		public static void smethod_0<T>(this IEnumerable<T> enumeration, Action<T> action)
		{
			foreach (T obj in enumeration)
			{
				action(obj);
			}
		}
	}
}
