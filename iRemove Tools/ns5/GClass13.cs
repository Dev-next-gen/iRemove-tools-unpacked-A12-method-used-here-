using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ns5
{
	// Token: 0x02000035 RID: 53
	public static class GClass13
	{
		// Token: 0x06000284 RID: 644 RVA: 0x000235F4 File Offset: 0x000217F4
		public static string smethod_0(string clearText)
		{
			string password = "";
			byte[] bytes = Encoding.Unicode.GetBytes(clearText);
			using (Aes aes = Aes.Create())
			{
				Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, new byte[]
				{
					73,
					118,
					97,
					110,
					32,
					77,
					101,
					100,
					118,
					101,
					100,
					101,
					118
				});
				aes.Key = rfc2898DeriveBytes.GetBytes(32);
				aes.IV = rfc2898DeriveBytes.GetBytes(16);
				using (MemoryStream memoryStream = new MemoryStream())
				{
					using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
					{
						cryptoStream.Write(bytes, 0, bytes.Length);
						cryptoStream.Close();
					}
					clearText = Convert.ToBase64String(memoryStream.ToArray());
				}
			}
			return clearText;
		}

		// Token: 0x06000285 RID: 645 RVA: 0x000236DC File Offset: 0x000218DC
		public static string smethod_1(string cipherText)
		{
			string password = "";
			cipherText = cipherText.Replace(" ", "+");
			byte[] array = Convert.FromBase64String(cipherText);
			using (Aes aes = Aes.Create())
			{
				Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, new byte[]
				{
					73,
					118,
					97,
					110,
					32,
					77,
					101,
					100,
					118,
					101,
					100,
					101,
					118
				});
				aes.Key = rfc2898DeriveBytes.GetBytes(32);
				aes.IV = rfc2898DeriveBytes.GetBytes(16);
				using (MemoryStream memoryStream = new MemoryStream())
				{
					using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Write))
					{
						cryptoStream.Write(array, 0, array.Length);
						cryptoStream.Close();
					}
					cipherText = Encoding.Unicode.GetString(memoryStream.ToArray());
				}
			}
			return cipherText;
		}
	}
}
