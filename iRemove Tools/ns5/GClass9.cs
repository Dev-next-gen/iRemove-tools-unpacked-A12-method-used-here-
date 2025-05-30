using System;
using System.Text.RegularExpressions;

namespace ns5
{
	// Token: 0x02000030 RID: 48
	public static class GClass9
	{
		// Token: 0x06000269 RID: 617 RVA: 0x00022A6C File Offset: 0x00020C6C
		public static bool smethod_0(this string str, string pattern)
		{
			return new Regex(Regex.Escape(pattern).Replace("\\*", ".*").Replace("\\?", "."), RegexOptions.IgnoreCase | RegexOptions.Singleline).IsMatch(str);
		}
	}
}
