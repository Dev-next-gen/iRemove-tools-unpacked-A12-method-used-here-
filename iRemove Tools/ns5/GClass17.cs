using System;
using System.Diagnostics;
using System.Threading;
using Renci.SshNet;

namespace ns5
{
	// Token: 0x02000039 RID: 57
	public class GClass17
	{
		// Token: 0x0600029D RID: 669 RVA: 0x00025764 File Offset: 0x00023964
		public GClass17()
		{
			this.gclass15_0 = new GClass15();
			this.gclass18_0 = new GClass18();
		}

		// Token: 0x0600029E RID: 670 RVA: 0x00025794 File Offset: 0x00023994
		public bool method_0(string port = "44", string udid = null)
		{
			for (int i = 0; i < 2; i++)
			{
				if (GClass14.dictionary_0 != null || udid != null)
				{
					foreach (Process process in Process.GetProcessesByName(this.gclass18_0.method_2("C977OyILiJi12Pq/BbBumQ==")))
					{
						process.Kill();
					}
					Thread.Sleep(200);
					if (udid != null)
					{
						this.gclass15_0.method_0(this.gclass18_0.method_2("C977OyILiJi12Pq/BbBumQ=="), this.gclass18_0.method_2("BGgbYy1U4yGcA9LjLAaqFQ==") + port + " " + udid, false);
					}
					else
					{
						this.gclass15_0.method_0(this.gclass18_0.method_2("C977OyILiJi12Pq/BbBumQ=="), this.gclass18_0.method_2("BGgbYy1U4yGcA9LjLAaqFQ==") + port + " " + GClass14.dictionary_0[this.gclass18_0.method_2("9RTu7arVM/dkUpIzP5i54g==")], false);
					}
					Thread.Sleep(200);
					this.sshClient_0 = new SshClient(this.gclass18_0.method_2("COqeJJLyIeo/1SKpbVN8Uw=="), 2221, this.gclass18_0.method_2("69dFLqAscp5MR/lzBUxshg=="), this.gclass18_0.method_2("LUCxjR/sEvi7riU+lslqyg=="));
					try
					{
						this.sshClient_0.Connect();
						goto IL_158;
					}
					catch
					{
						goto IL_158;
					}
					goto IL_145;
					IL_158:
					if (this.sshClient_0.IsConnected)
					{
						return port.Equals("22") || this.method_6();
					}
				}
				IL_145:
				Thread.Sleep(200);
			}
			return false;
		}

		// Token: 0x0600029F RID: 671 RVA: 0x00025938 File Offset: 0x00023B38
		public bool method_1()
		{
			bool result;
			if (this.sshClient_0 != null)
			{
				result = (this.sshClient_0.IsConnected || this.method_0("44", null));
			}
			else
			{
				result = this.method_0("44", null);
			}
			return result;
		}

		// Token: 0x060002A0 RID: 672 RVA: 0x00025980 File Offset: 0x00023B80
		public bool method_2(string udid)
		{
			bool result;
			if (this.sshClient_0 != null)
			{
				result = (this.sshClient_0.IsConnected || this.method_0("44", udid));
			}
			else
			{
				result = this.method_0("44", udid);
			}
			return result;
		}

		// Token: 0x060002A1 RID: 673 RVA: 0x000259C8 File Offset: 0x00023BC8
		public bool method_3()
		{
			bool result;
			if (this.sshClient_0 != null)
			{
				result = (this.sshClient_0.IsConnected || this.method_0("44", null) || this.method_0("22", null));
			}
			else
			{
				result = (this.method_0("44", null) || this.method_0("22", null));
			}
			return result;
		}

		// Token: 0x060002A2 RID: 674 RVA: 0x00025A34 File Offset: 0x00023C34
		public void method_4()
		{
			if (this.sshClient_0 != null)
			{
				try
				{
					this.sshClient_0.Disconnect();
					this.sshClient_0.Dispose();
					this.sshClient_0 = null;
				}
				catch
				{
				}
			}
			this.gclass15_0.method_1("iproxy.exe");
			foreach (Process process in Process.GetProcessesByName(this.gclass18_0.method_2("C977OyILiJi12Pq/BbBumQ==")))
			{
				process.Kill();
			}
		}

		// Token: 0x060002A3 RID: 675 RVA: 0x00025AC0 File Offset: 0x00023CC0
		public string method_5(string command, int timeout = 0)
		{
			if (this.method_1())
			{
				if (timeout > 0)
				{
					try
					{
						SshCommand sshCommand = this.sshClient_0.CreateCommand(command);
						sshCommand.CommandTimeout = TimeSpan.FromSeconds((double)timeout);
						return sshCommand.Execute();
					}
					catch
					{
					}
				}
				try
				{
					SshCommand sshCommand2 = this.sshClient_0.RunCommand(command);
					if (sshCommand2 != null)
					{
						return sshCommand2.Result;
					}
					return null;
				}
				catch
				{
				}
			}
			return null;
		}

		// Token: 0x060002A4 RID: 676 RVA: 0x00025B48 File Offset: 0x00023D48
		private bool method_6()
		{
			this.method_5(this.gclass18_0.method_2("SbIHnFnCUJ5fW3rC+Hx8bQ0ITsztzM3unvsopGOxew0="), 0);
			string text = this.method_5(this.gclass18_0.method_2("VG/2hkhXtWRq2U35SdPNaw=="), 0);
			bool result;
			if (text.Contains(this.gclass18_0.method_2("Kfm09MqtTNVMWwtS6/2ObA==")))
			{
				result = true;
			}
			else
			{
				text = text.Replace(this.gclass18_0.method_2("lANJbDIzgAo4bwuA0GLbcMJSZAt27g7ERnt6jWfRm14="), "").Replace("\r", "").Replace("\n", "");
				this.method_5(this.gclass18_0.method_2("jN1q3Ph6Rji4ygsc1pxktQ==") + text + this.gclass18_0.method_2("ROAVeh0ersRZj9PbGsuIMQ=="), 0);
				string text2 = this.method_5(this.gclass18_0.method_2("VG/2hkhXtWRq2U35SdPNaw=="), 0);
				result = text2.Contains(this.gclass18_0.method_2("Kfm09MqtTNVMWwtS6/2ObA=="));
			}
			return result;
		}

		// Token: 0x060002A5 RID: 677 RVA: 0x00025C44 File Offset: 0x00023E44
		public bool method_7()
		{
			string text = this.method_5(this.gclass18_0.method_2("/ACTTpC59AkvwJCQSMg+hm/vAOD/tlL/wRZ8iMW8hy/KdUb+D6sdzMpzIEXj6g5F82c2i4Eq4NKaAkD7ZSqLCA=="), 0);
			bool result;
			if (text.Contains(this.gclass18_0.method_2("SFJMadcA0xl/YcKmOJvkRg==")))
			{
				GClass14.string_87 = text.Replace("\r", "").Replace("\n", "").Replace(this.gclass18_0.method_2("iK95kSGJhE/kCI5Qd4ZQ6Q=="), "");
				result = GClass14.string_87.Contains(this.gclass18_0.method_2("gt5fbY6WrhuD1qsY9MK3ow=="));
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x04000195 RID: 405
		private GClass15 gclass15_0;

		// Token: 0x04000196 RID: 406
		private GClass18 gclass18_0;

		// Token: 0x04000197 RID: 407
		private SshClient sshClient_0 = null;
	}
}
