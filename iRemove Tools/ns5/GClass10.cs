using System;
using System.Security.Cryptography;
using System.Text;

namespace ns5
{
	// Token: 0x02000031 RID: 49
	public class GClass10
	{
		// Token: 0x0600026C RID: 620 RVA: 0x00022AAC File Offset: 0x00020CAC
		public string method_0(string value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			using (SHA256 sha = SHA256.Create())
			{
				Encoding utf = Encoding.UTF8;
				byte[] array = sha.ComputeHash(utf.GetBytes(value));
				foreach (byte b in array)
				{
					stringBuilder.Append(b.ToString("x2"));
				}
			}
			return stringBuilder.ToString();
		}

		// Token: 0x0600026D RID: 621 RVA: 0x00022B30 File Offset: 0x00020D30
		public string method_1(string plainText)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(plainText);
			return Convert.ToBase64String(bytes);
		}
	}
}
