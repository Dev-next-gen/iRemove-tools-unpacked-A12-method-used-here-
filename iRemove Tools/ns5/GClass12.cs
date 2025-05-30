using System;
using System.IO;
using System.Threading;

namespace ns5
{
	// Token: 0x02000034 RID: 52
	public class GClass12
	{
		// Token: 0x0600027F RID: 639 RVA: 0x0000DA7E File Offset: 0x0000BC7E
		public GClass12(GClass17 sshHelper)
		{
			this.gclass18_0 = new GClass18();
			this.gclass17_0 = sshHelper;
		}

		// Token: 0x06000280 RID: 640 RVA: 0x0002317C File Offset: 0x0002137C
		public bool method_0()
		{
			bool result;
			if (GClass14.gclass2_0.method_27(File.ReadAllBytes(GClass14.string_3.Replace("cache\\", "") + "boot\\lzma"), "lzma"))
			{
				this.gclass17_0.method_5(this.gclass18_0.method_2("zoQUTFJgzo+uip+eNXoOew==") + GClass14.string_75 + this.gclass18_0.method_2("v/E0SFv+bJpQrkSmQtEriQ=="), 0);
				this.gclass17_0.method_5(this.gclass18_0.method_2("z7N/ZLu617CZY5x4Qbbfz/37ETV4WqgXN8HGIhbn3J8="), 0);
				this.method_2(this.gclass18_0.method_2("f04tuY6qWL7R1Umb97A0/A=="));
				string text = this.gclass17_0.method_5(this.gclass18_0.method_2("fGpBztqumU7wjNwSOU1z9eip7QXI+QEGP2veGKJmY2A="), 0);
				if (text != null && text.Equals(""))
				{
					string text2 = this.gclass17_0.method_5(this.gclass18_0.method_2("hk4u3M16qNOYVGgnhrLwVV42OYQAYVQ78NK254B7Jb+S/tm3xHuJ8voJ98Waeesv"), 0);
					if (!text2.Contains(this.gclass18_0.method_2("smaWtzcBmoNIWHDlpVA1dz4fEYCJJRcYX/Xg7ThdpxI=")))
					{
						this.gclass17_0.method_5(this.gclass18_0.method_2("BemC6QZu4hH8xn+jOPIcJAprf1a1tj0+51jGD1lN8FMpN2mhfzPp9IJpU9wbECbctBWwa0PjDS2BWk2asINB/nfGS8AP7lLmioXagqZFJekb5bIYZgwCCLV55j3kHJyu"), 0);
						Thread.Sleep(1000);
						this.gclass17_0.method_5(this.gclass18_0.method_2("xerTtu09CCOs6Dz6CUpAjs4sp3xOimtwWWL1RguP8uMd7mNAUhkmc1+rOttkZno7/rosKsLC3uChFd0XUi7Op5NCaPaQ4AH30jhpd8edtNc="), 0);
						this.gclass17_0.method_5(this.gclass18_0.method_2("zhXFCanixiMP1ofdk619002G9ftRyj76U8jvLxRU/LARDoYzQoF2Opq7zpwyLUxpWbva9GGpgpe+8YCKEyS8lB332jzZvpEsWZVXTkRndcA="), 0);
						string activationState = GClass14.gclass2_0.ActivationState;
					}
					result = true;
				}
				else
				{
					result = false;
				}
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000281 RID: 641 RVA: 0x00023314 File Offset: 0x00021514
		public void method_1()
		{
			this.gclass17_0.method_5(this.gclass18_0.method_2("4+vxUM9jK+THAOaRjXigeF97fOkGd0jgkrH4VoO4uM7RS6dyBQhgzQQD7S14TWATHAGBjH5BQAA8bE8B9OXzyf3svnvBpYsGY3QPVm6JKso="), 0);
			this.gclass17_0.method_5(this.gclass18_0.method_2("93jLWOqY/ZHpm21gzlhAm3M0P9TQtqw6hBRNWK7zcq4="), 0);
			this.gclass17_0.method_5(this.gclass18_0.method_2("usOIob6snTpDKx2s2Kr9etYRZL/YpTOUqfI+NemGbl8="), 0);
			this.gclass17_0.method_5(this.gclass18_0.method_2("ZKUG78/HhP89zx8qdvMSLM8nL/1KiwATBGAI0gNMRfADkngc1xFMicora7CPppubqfVN6R4uFD87s2vhNiaE7g=="), 0);
			this.gclass17_0.method_5(this.gclass18_0.method_2("WWYasgnC8WNLxWza0Z34ndVlX7mcep6b8E+rzZ23Ao4="), 0);
			this.gclass17_0.method_5(this.gclass18_0.method_2("WWYasgnC8WNLxWza0Z34nYUfe3Uq1KZABjX0yl2tGCY="), 0);
			this.gclass17_0.method_5(this.gclass18_0.method_2("XncE3vJCMhKnT1yE7EbSWDvY7xPAHOYyDbejBQ37xbg="), 0);
			this.gclass17_0.method_5(this.gclass18_0.method_2("QBRhro/SnraaqEYYTmxIZV3SzZwZloWeyTB2+Du6d34="), 0);
			this.gclass17_0.method_5(this.gclass18_0.method_2("QBRhro/SnraaqEYYTmxIZduFOf+DX2smud9TVEBKfIA="), 0);
			this.gclass17_0.method_5(this.gclass18_0.method_2("MnZqTNx2poUgypjL5OouHA=="), 0);
			this.gclass17_0.method_5(this.gclass18_0.method_2("ND6XjeGR+yNRdFpUOR7eGa4RKWYTnF2ktba9OG61fFQ="), 0);
			this.gclass17_0.method_5(this.gclass18_0.method_2("Neumnq0AClEAupe2obBg5kroQMxhUODXO93EPUlrjlw="), 0);
			this.gclass17_0.method_5(this.gclass18_0.method_2("ys2n/JQtzOkDyNqtd1pTKJc+pD8C/uFAe9y+Bvk52Ec="), 0);
			this.gclass17_0.method_5(this.gclass18_0.method_2("zZONlMpkv5M+qcUheVEnC+L9NZJ8b6QOaM9jqBWw6rQfKX74/ufXw5M6h+qoSmzDXU547GQEHWenZU/wWXM2hQ=="), 0);
		}

		// Token: 0x06000282 RID: 642 RVA: 0x000234B8 File Offset: 0x000216B8
		private void method_2(string name)
		{
			string text = name + this.gclass18_0.method_2("ZdbQ2geBgbYWD5Jw3ssTWw==");
			string str = name + this.gclass18_0.method_2("/A3Ic2HVn1jc2Acv+6Xe9A==");
			GClass14.gclass2_0.method_27(File.ReadAllBytes(GClass14.string_3.Replace("cache\\", "") + "boot\\" + text), text);
			this.gclass17_0.method_5(string.Concat(new string[]
			{
				this.gclass18_0.method_2("zoQUTFJgzo+uip+eNXoOew=="),
				GClass14.string_75,
				text,
				" /",
				text
			}), 0);
			this.gclass17_0.method_5(this.gclass18_0.method_2("WjzkCLweQ3Lop2GnvOn0SNzJsdiB9KwyfZouQHq2vQk=") + text, 0);
			this.gclass17_0.method_5(this.gclass18_0.method_2("IQbXXVdxaeKUAt5B56f8suRtDkgAOgBzJ6QuCwkfpME=") + str, 0);
			this.gclass17_0.method_5(this.gclass18_0.method_2("1GsRlOEAlMQCH1FI1OBimg==") + text, 0);
			this.gclass17_0.method_5(this.gclass18_0.method_2("1GsRlOEAlMQCH1FI1OBimg==") + str, 0);
		}

		// Token: 0x04000129 RID: 297
		private GClass17 gclass17_0;

		// Token: 0x0400012A RID: 298
		private GClass18 gclass18_0;
	}
}
