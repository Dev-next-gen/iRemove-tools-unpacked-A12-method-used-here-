using System;
using System.Security.Cryptography;
using System.Text;

namespace ns5
{
	// Token: 0x0200003A RID: 58
	public class GClass18
	{
		// Token: 0x060002A7 RID: 679 RVA: 0x00025CE8 File Offset: 0x00023EE8
		public GClass18()
		{
			this.utf8Encoding_0 = new UTF8Encoding();
			this.rijndaelManaged_0 = new RijndaelManaged();
			this.rijndaelManaged_0.Mode = CipherMode.CBC;
			this.rijndaelManaged_0.Padding = PaddingMode.PKCS7;
			this.rijndaelManaged_0.KeySize = 256;
			this.rijndaelManaged_0.BlockSize = 128;
			this.byte_0 = new byte[32];
			this.byte_3 = new byte[this.rijndaelManaged_0.BlockSize / 8];
			this.byte_2 = new byte[16];
		}

		// Token: 0x060002A8 RID: 680 RVA: 0x00025D7C File Offset: 0x00023F7C
		private string method_0(string _inputText, GClass18.Enum5 _mode)
		{
		}

		// Token: 0x060002A9 RID: 681 RVA: 0x00025D88 File Offset: 0x00023F88
		public string method_1(string _plainText)
		{
			return this.method_0(_plainText, GClass18.Enum5.const_0);
		}

		// Token: 0x060002AA RID: 682 RVA: 0x00025DA0 File Offset: 0x00023FA0
		public string method_2(string _encryptedText)
		{
			return this.method_0(_encryptedText, GClass18.Enum5.const_1);
		}

		// Token: 0x04000198 RID: 408
		private UTF8Encoding utf8Encoding_0;

		// Token: 0x04000199 RID: 409
		private RijndaelManaged rijndaelManaged_0;

		// Token: 0x0400019A RID: 410
		private byte[] byte_0;

		// Token: 0x0400019B RID: 411
		private byte[] byte_1;

		// Token: 0x0400019C RID: 412
		private byte[] byte_2;

		// Token: 0x0400019D RID: 413
		private byte[] byte_3;

		// Token: 0x0200003B RID: 59
		private enum Enum5
		{
			// Token: 0x0400019F RID: 415
			const_0,
			// Token: 0x040001A0 RID: 416
			const_1
		}
	}
}
