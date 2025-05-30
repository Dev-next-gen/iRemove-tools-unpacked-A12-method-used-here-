using System;
using System.Security.Cryptography;
using System.Text;

namespace ns5
{
	// Token: 0x02000032 RID: 50
	public class GClass11
	{
		// Token: 0x0600026F RID: 623 RVA: 0x00022B54 File Offset: 0x00020D54
		public static string smethod_0(int length)
		{
			char[] array = new char[length];
			byte[] array2 = new byte[length];
			using (RNGCryptoServiceProvider rngcryptoServiceProvider = new RNGCryptoServiceProvider())
			{
				rngcryptoServiceProvider.GetBytes(array2);
			}
			for (int i = 0; i < array.Length; i++)
			{
				int num = (int)array2[i] % GClass11.char_0.Length;
				array[i] = GClass11.char_0[num];
			}
			return new string(array);
		}

		// Token: 0x06000270 RID: 624 RVA: 0x00022BCC File Offset: 0x00020DCC
		public GClass11()
		{
			this.utf8Encoding_0 = new UTF8Encoding();
			this.rijndaelManaged_0 = new RijndaelManaged();
			this.rijndaelManaged_0.Mode = CipherMode.ECB;
			this.rijndaelManaged_0.Padding = PaddingMode.PKCS7;
			this.byte_0 = new byte[32];
			this.byte_3 = new byte[this.rijndaelManaged_0.BlockSize / 8];
			this.byte_2 = new byte[16];
		}

		// Token: 0x06000271 RID: 625 RVA: 0x00022C40 File Offset: 0x00020E40
		private string method_0(string _inputText, string _encryptionKey, GClass11.Enum4 _mode, string _initVector)
		{
			string result = "";
			this.rijndaelManaged_0.Key = Encoding.UTF8.GetBytes(_encryptionKey.Substring(0, _encryptionKey.Length - 8));
			this.rijndaelManaged_0.IV = Encoding.UTF8.GetBytes(_initVector.Substring(0, _initVector.Length - 8));
			if (_mode.Equals(GClass11.Enum4.const_0))
			{
				byte[] inArray = this.rijndaelManaged_0.CreateEncryptor().TransformFinalBlock(this.utf8Encoding_0.GetBytes(_inputText), 0, _inputText.Length);
				result = Convert.ToBase64String(inArray);
			}
			if (_mode.Equals(GClass11.Enum4.const_1))
			{
				byte[] bytes = this.rijndaelManaged_0.CreateDecryptor().TransformFinalBlock(Convert.FromBase64String(_inputText), 0, Convert.FromBase64String(_inputText).Length);
				result = this.utf8Encoding_0.GetString(bytes);
			}
			this.rijndaelManaged_0.Dispose();
			return result;
		}

		// Token: 0x06000272 RID: 626 RVA: 0x00022D3C File Offset: 0x00020F3C
		private byte[] method_1(string _inputText, string _encryptionKey, GClass11.Enum4 _mode, string _initVector)
		{
			this.rijndaelManaged_0.Key = Encoding.UTF8.GetBytes(_encryptionKey);
			this.rijndaelManaged_0.IV = Encoding.UTF8.GetBytes(_initVector.Substring(0, _initVector.Length - 8));
			byte[] result;
			if (_mode.Equals(GClass11.Enum4.const_0))
			{
				result = this.rijndaelManaged_0.CreateEncryptor().TransformFinalBlock(this.utf8Encoding_0.GetBytes(_inputText), 0, _inputText.Length);
			}
			else if (_mode.Equals(GClass11.Enum4.const_1))
			{
				result = this.rijndaelManaged_0.CreateDecryptor().TransformFinalBlock(Convert.FromBase64String(_inputText), 0, Convert.FromBase64String(_inputText).Length);
			}
			else
			{
				this.rijndaelManaged_0.Dispose();
				result = null;
			}
			return result;
		}

		// Token: 0x06000273 RID: 627 RVA: 0x00022E08 File Offset: 0x00021008
		private byte[] method_2(string _inputText, string _encryptionKey, GClass11.Enum4 _mode, string _initVector)
		{
			byte[] result = null;
			this.rijndaelManaged_0.Key = Encoding.UTF8.GetBytes(_encryptionKey.Substring(0, _encryptionKey.Length - 8));
			this.rijndaelManaged_0.IV = Encoding.UTF8.GetBytes(_initVector.Substring(0, _initVector.Length - 8));
			if (_mode.Equals(GClass11.Enum4.const_0))
			{
				byte[] array = this.rijndaelManaged_0.CreateEncryptor().TransformFinalBlock(this.utf8Encoding_0.GetBytes(_inputText), 0, _inputText.Length);
				result = array;
			}
			if (_mode.Equals(GClass11.Enum4.const_1))
			{
				byte[] array2 = this.rijndaelManaged_0.CreateDecryptor().TransformFinalBlock(Convert.FromBase64String(_inputText), 0, Convert.FromBase64String(_inputText).Length);
				result = array2;
			}
			this.rijndaelManaged_0.Dispose();
			return result;
		}

		// Token: 0x06000274 RID: 628 RVA: 0x00022EE8 File Offset: 0x000210E8
		private byte[] method_3(byte[] _inputText, string _encryptionKey, GClass11.Enum4 _mode, string _initVector)
		{
			byte[] result = null;
			this.rijndaelManaged_0.Key = Encoding.UTF8.GetBytes(_encryptionKey.Substring(0, _encryptionKey.Length - 8));
			this.rijndaelManaged_0.IV = Encoding.UTF8.GetBytes(_initVector.Substring(0, _initVector.Length - 8));
			if (_mode.Equals(GClass11.Enum4.const_0))
			{
				byte[] array = this.rijndaelManaged_0.CreateEncryptor().TransformFinalBlock(_inputText, 0, _inputText.Length);
				result = array;
			}
			if (_mode.Equals(GClass11.Enum4.const_1))
			{
				byte[] array2 = this.rijndaelManaged_0.CreateDecryptor().TransformFinalBlock(_inputText, 0, _inputText.Length);
				result = array2;
			}
			this.rijndaelManaged_0.Dispose();
			return result;
		}

		// Token: 0x06000275 RID: 629 RVA: 0x00022FB0 File Offset: 0x000211B0
		public string method_4(string _plainText, string _key, string _initVector)
		{
			return this.method_0(_plainText, _key, GClass11.Enum4.const_0, _initVector);
		}

		// Token: 0x06000276 RID: 630 RVA: 0x00022FCC File Offset: 0x000211CC
		public string method_5(string _encryptedText, string _key, string _initVector)
		{
			return this.method_0(_encryptedText, _key, GClass11.Enum4.const_1, _initVector);
		}

		// Token: 0x06000277 RID: 631 RVA: 0x00022FE8 File Offset: 0x000211E8
		public byte[] method_6(string _encryptedText, string _key, string _initVector)
		{
			return this.method_1(_encryptedText, _key, GClass11.Enum4.const_1, _initVector);
		}

		// Token: 0x06000278 RID: 632 RVA: 0x00023004 File Offset: 0x00021204
		public byte[] method_7(string _encryptedText, string _key, string _initVector)
		{
			return this.method_1(_encryptedText, _key, GClass11.Enum4.const_0, _initVector);
		}

		// Token: 0x06000279 RID: 633 RVA: 0x00023020 File Offset: 0x00021220
		public byte[] method_8(string _encryptedText, string _key, string _initVector)
		{
			return this.method_2(_encryptedText, _key, GClass11.Enum4.const_1, _initVector);
		}

		// Token: 0x0600027A RID: 634 RVA: 0x0002303C File Offset: 0x0002123C
		public byte[] method_9(byte[] _encryptedText, string _key, string _initVector)
		{
			return this.method_3(_encryptedText, _key, GClass11.Enum4.const_1, _initVector);
		}

		// Token: 0x0600027B RID: 635 RVA: 0x00023058 File Offset: 0x00021258
		public byte[] method_10(byte[] _encryptedText, string _key, string _initVector)
		{
			return this.method_3(_encryptedText, _key, GClass11.Enum4.const_0, _initVector);
		}

		// Token: 0x0600027C RID: 636 RVA: 0x00023074 File Offset: 0x00021274
		public static string smethod_1(string text, int length)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(text);
			SHA256Managed sha256Managed = new SHA256Managed();
			byte[] array = sha256Managed.ComputeHash(bytes);
			string text2 = string.Empty;
			foreach (byte b in array)
			{
				text2 += string.Format("{0:x2}", b);
			}
			string result;
			if (length > text2.Length)
			{
				result = text2;
			}
			else
			{
				result = text2.Substring(0, length);
			}
			return result;
		}

		// Token: 0x0600027D RID: 637 RVA: 0x000230F4 File Offset: 0x000212F4
		private static string smethod_2(string text)
		{
			MD5 md = new MD5CryptoServiceProvider();
			md.ComputeHash(Encoding.ASCII.GetBytes(text));
			byte[] hash = md.Hash;
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < hash.Length; i++)
			{
				stringBuilder.Append(hash[i].ToString("x2"));
			}
			return stringBuilder.ToString();
		}

		// Token: 0x0400011F RID: 287
		private UTF8Encoding utf8Encoding_0;

		// Token: 0x04000120 RID: 288
		private RijndaelManaged rijndaelManaged_0;

		// Token: 0x04000121 RID: 289
		private byte[] byte_0;

		// Token: 0x04000122 RID: 290
		private byte[] byte_1;

		// Token: 0x04000123 RID: 291
		private byte[] byte_2;

		// Token: 0x04000124 RID: 292
		private byte[] byte_3;

		// Token: 0x04000125 RID: 293
		private static readonly char[] char_0 = new char[]
		{
			'A',
			'B',
			'C',
			'D',
			'E',
			'F',
			'G',
			'H',
			'I',
			'J',
			'K',
			'L',
			'M',
			'N',
			'O',
			'P',
			'Q',
			'R',
			'S',
			'T',
			'U',
			'V',
			'W',
			'X',
			'Y',
			'Z',
			'a',
			'b',
			'c',
			'd',
			'e',
			'f',
			'g',
			'h',
			'i',
			'j',
			'k',
			'l',
			'm',
			'n',
			'o',
			'p',
			'q',
			'r',
			's',
			't',
			'u',
			'v',
			'w',
			'x',
			'y',
			'z',
			'0',
			'1',
			'2',
			'3',
			'4',
			'5',
			'6',
			'7',
			'8',
			'9',
			'-',
			'_'
		};

		// Token: 0x02000033 RID: 51
		private enum Enum4
		{
			// Token: 0x04000127 RID: 295
			const_0,
			// Token: 0x04000128 RID: 296
			const_1
		}
	}
}
