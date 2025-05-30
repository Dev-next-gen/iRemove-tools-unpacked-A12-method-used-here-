using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using iRemoveTools.Properties;
using MaterialSkin;
using MaterialSkin.Controls;
using ns2;
using ns5;

namespace ns1
{
	// Token: 0x0200000C RID: 12
	public class JailForm : MaterialForm
	{
		// Token: 0x06000089 RID: 137
		[DllImport("libcrypto-1_0.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool dll_pongo(byte[] data1, int data1_size);

		// Token: 0x0600008A RID: 138
		[DllImport("libcrypto-1_0.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool dll_checkra1n_load(byte[] data1, int data1_size, byte[] data2, int data2_size);

		// Token: 0x0600008B RID: 139
		[DllImport("libcrypto-1_0.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool dll_checkm8();

		// Token: 0x0600008C RID: 140 RVA: 0x00017B3C File Offset: 0x00015D3C
		public JailForm()
		{
			string fullName = new DirectoryInfo(Assembly.GetEntryAssembly().Location).Parent.FullName;
			this.string_4 = fullName + "\\drivers\\libusbk\\Apple_Mobile_Device_DFU_Mode.inf";
			if (Environment.Is64BitOperatingSystem)
			{
				this.string_5 = fullName + "\\drivers\\usbaapl\\x64\\usbaapl64.inf";
			}
			else
			{
				this.string_5 = fullName + "\\drivers\\usbaapl\\x86\\usbaapl.inf";
			}
			this.InitializeComponent();
			this.materialSkinManager_0 = MaterialSkinManager.Instance;
			base.MaximizeBox = false;
			if (GClass14.gclass2_0 != null)
			{
				this.productType = GClass14.gclass2_0.ProductType;
				this.string_1 = GClass14.gclass2_0.UniqueDeviceID;
				float single_ = GClass14.gclass2_0.Single_0;
				this.dfuNext.Enabled = true;
				this.infoText.Text = "The device needs to be put into DFU mode to apply the jailbreak. This is a manual process and we will guide you through it.\nIn order to prevent filesystem corruption through hard reset, the device will be put into recovery mode first. Click Next when you are ready.";
				if ((double)single_ >= 15.0)
				{
					this.bool_2 = false;
				}
				else
				{
					this.bool_2 = true;
				}
				if ((double)single_ < 12.0)
				{
					this.dfuNext.Enabled = false;
					this.infoText.Text = "Sorry, your device is not supported";
				}
			}
			this.dictionary_0 = new Dictionary<string, string>
			{
				{
					"iPhone6,1",
					"tab_for_se"
				},
				{
					"iPhone6,2",
					"tab_for_se"
				},
				{
					"iPhone7,1",
					"tab_for_6s"
				},
				{
					"iPhone7,2",
					"tab_for_6s"
				},
				{
					"iPhone8,1",
					"tab_for_6s"
				},
				{
					"iPhone8,2",
					"tab_for_6s"
				},
				{
					"iPhone8,4",
					"tab_for_se"
				},
				{
					"iPhone9,1",
					"tab_for_8"
				},
				{
					"iPhone9,2",
					"tab_for_8"
				},
				{
					"iPhone9,3",
					"tab_for_8"
				},
				{
					"iPhone9,4",
					"tab_for_8"
				},
				{
					"iPhone10,1",
					"tab_for_8"
				},
				{
					"iPhone10,2",
					"tab_for_8"
				},
				{
					"iPhone10,3",
					"tab_for_x"
				},
				{
					"iPhone10,4",
					"tab_for_8"
				},
				{
					"iPhone10,5",
					"tab_for_8"
				},
				{
					"iPhone10,6",
					"tab_for_x"
				},
				{
					"iPad5,2",
					"tab_for_ipad"
				}
			};
			this.dictionary_2 = new Dictionary<string, string[]>
			{
				{
					"tab_for_x",
					new string[]
					{
						"2. Press and hold the Side\n     and Volume down buttons\n     together (4)",
						"3. Release the Side button\n     BUT KEEP HOLDING the\n     Volume down button (10)"
					}
				},
				{
					"tab_for_8",
					new string[]
					{
						"2. Press and hold the Side\n     and Volume down buttons\n     together (4)",
						"3. Release the Side button\n     BUT KEEP HOLDING the\n     Volume down button (10)"
					}
				},
				{
					"tab_for_se",
					new string[]
					{
						"2. Press and hold the Top\n     and Home buttons\n     together (4)",
						"3. Release the Top button\n     BUT KEEP HOLDING the\n     Home button (10)"
					}
				},
				{
					"tab_for_6s",
					new string[]
					{
						"2. Press and hold the Side\n     and Home buttons\n     together (4)",
						"3. Release the Side button\n     BUT KEEP HOLDING the\n     Home button (10)"
					}
				},
				{
					"tab_for_ipad",
					new string[]
					{
						"2. Press and hold the Top\n     and Home buttons\n     together (4)",
						"3. Release the Top button\n     BUT KEEP HOLDING the\n     Home button (10)"
					}
				}
			};
		}

		// Token: 0x0600008D RID: 141 RVA: 0x00017E98 File Offset: 0x00016098
		private void JailForm_Resize(object sender, EventArgs e)
		{
		}

		// Token: 0x0600008E RID: 142 RVA: 0x00017EA8 File Offset: 0x000160A8
		public void method_0()
		{
			if (!this.bool_0)
			{
				this.bool_4 = true;
				base.Close();
			}
		}

		// Token: 0x0600008F RID: 143 RVA: 0x00017E98 File Offset: 0x00016098
		private void method_1(object sender, EventArgs e)
		{
		}

		// Token: 0x06000090 RID: 144 RVA: 0x00017E98 File Offset: 0x00016098
		private void method_2(object sender, EventArgs e)
		{
		}

		// Token: 0x06000091 RID: 145 RVA: 0x00017ED0 File Offset: 0x000160D0
		private void JailForm_Load(object sender, EventArgs e)
		{
			this.color_0 = this.stepText1.ForeColor;
			Font fontByType = this.materialSkinManager_0.getFontByType(2);
			this.infoText.Font = new Font(fontByType.FontFamily, 13.5f, FontStyle.Regular);
			this.infoText2.Font = new Font(fontByType.FontFamily, 13.5f, FontStyle.Regular);
			this.stepsInfo.Font = new Font(fontByType.FontFamily, 13.5f, FontStyle.Regular);
			this.stepText1.Font = new Font(fontByType.FontFamily, 13.5f, FontStyle.Regular);
			this.stepText2.Font = new Font(fontByType.FontFamily, 13.5f, FontStyle.Regular);
			this.stepText3.Font = new Font(fontByType.FontFamily, 13.5f, FontStyle.Regular);
			this.statusText.Font = new Font(fontByType.FontFamily, 13.5f, FontStyle.Regular);
			this.jailInfoText.Font = new Font(fontByType.FontFamily, 13.5f, FontStyle.Regular);
			this.hardResetText.Font = new Font(fontByType.FontFamily, 13.5f, FontStyle.Regular);
			this.hardResetText.ForeColor = Color.DeepSkyBlue;
			this.hardResetText.Visible = false;
			this.stepText2.Text = "2. Press and hold the Side\n     and Volume down buttons\n     together(4)";
			this.stepText3.Text = "3. Release the Side button\n     BUT KEEP HOLDING the\n     Volume down button(10)";
			this.startSteps.Text = "     Start     ";
		}

		// Token: 0x06000092 RID: 146 RVA: 0x00018044 File Offset: 0x00016244
		private void dfuCancel_Click(object sender, EventArgs e)
		{
			this.bool_4 = true;
			base.Close();
		}

		// Token: 0x06000093 RID: 147 RVA: 0x00018060 File Offset: 0x00016260
		private void timer_0_Tick(object sender, EventArgs e)
		{
			if (this.int_0 >= this.string_0.Length)
			{
				this.int_0 = 22;
				this.infoText2.Text = this.string_0;
			}
			else
			{
				char[] array = this.string_0.ToCharArray();
				array[this.int_0] = '|';
				this.infoText2.Text = new string(array);
			}
			this.int_0++;
		}

		// Token: 0x06000094 RID: 148 RVA: 0x00017E98 File Offset: 0x00016098
		private static void smethod_0(object sender, DataReceivedEventArgs e)
		{
		}

		// Token: 0x06000095 RID: 149 RVA: 0x000180D8 File Offset: 0x000162D8
		private bool method_3()
		{
			WindowsIdentity current = WindowsIdentity.GetCurrent();
			WindowsPrincipal windowsPrincipal = new WindowsPrincipal(current);
			return windowsPrincipal.IsInRole(WindowsBuiltInRole.Administrator);
		}

		// Token: 0x06000096 RID: 150 RVA: 0x00018100 File Offset: 0x00016300
		private void dfuNext_Click(object sender, EventArgs e)
		{
			this.hardResetText.Visible = false;
			this.bool_0 = true;
			this.dfuCancel.Enabled = false;
			this.dfuNext.Enabled = false;
			this.timer_0 = new System.Windows.Forms.Timer();
			this.timer_0.Interval = 100;
			this.timer_0.Tick += this.timer_0_Tick;
			this.timer_0.Start();
			this.infoText2.Visible = true;
			this.thread_0 = new Thread(new ThreadStart(this.method_4));
			this.thread_0.IsBackground = true;
			this.thread_0.Start();
		}

		// Token: 0x06000097 RID: 151 RVA: 0x000181AC File Offset: 0x000163AC
		private void method_4()
		{
			GClass14.gclass2_0.method_60();
			int num = 0;
			new Thread(delegate()
			{
				this.method_12(JailForm.Enum1.const_0);
				Thread.Sleep(1000);
				this.method_12(JailForm.Enum1.const_1);
				Thread.Sleep(1000);
				JailForm.smethod_2(this.string_5);
			}).Start();
			while (this.gclass2_0 == null)
			{
				if (num > 400)
				{
					base.Invoke(new Action(delegate()
					{
						this.timer_0.Stop();
						this.infoText2.Text = "Problem with entering recovery mode.\nPlease, reconnect your device and try again.";
						this.dfuCancel.Enabled = true;
					}));
					return;
				}
				num++;
				Thread.Sleep(100);
			}
			base.Invoke(new Action(delegate()
			{
				this.timer_0.Stop();
				this.infoText2.Text = "Device is now in recovery mode.";
			}));
			Thread.Sleep(2000);
			string text;
			if (this.productType.Contains("iPad"))
			{
				text = this.dictionary_0["iPad5,2"];
			}
			else
			{
				text = this.dictionary_0[this.productType];
			}
			string[] array = this.dictionary_2[text];
			this.stepText2.Text = array[0];
			this.stepText3.Text = array[1];
			foreach (object obj in this.modelTabs.TabPages)
			{
				TabPage tabPage = (TabPage)obj;
				if (tabPage.Name != null && tabPage.Name.ToString() == text)
				{
					this.modelTabs.SelectedTab = tabPage;
					break;
				}
			}
			base.Invoke(new Action(delegate()
			{
				this.stepText2.ForeColor = Color.Gray;
				this.stepText3.ForeColor = Color.Gray;
				this.dfuTabs.SelectedIndex = 1;
			}));
		}

		// Token: 0x06000098 RID: 152 RVA: 0x00018328 File Offset: 0x00016528
		private void cancelSteps_Click(object sender, EventArgs e)
		{
			if (this.gclass2_0 != null)
			{
				this.gclass2_0.method_61();
			}
			this.bool_4 = true;
			base.Close();
		}

		// Token: 0x06000099 RID: 153 RVA: 0x0001835C File Offset: 0x0001655C
		private void startSteps_Click(object sender, EventArgs e)
		{
			this.bool_1 = false;
			if (this.startSteps.Text.Equals("     Retry     "))
			{
				this.bool_4 = true;
				base.Close();
				this.bool_1 = true;
			}
			else
			{
				this.gclass2_1 = null;
				this.startSteps.Enabled = false;
				this.cancelSteps.Enabled = false;
				this.stepText1.ForeColor = Color.Gray;
				this.stepText2.ForeColor = this.color_0;
				this.thread_0 = new Thread(new ThreadStart(this.method_5));
				this.thread_0.IsBackground = true;
				this.thread_0.Start();
			}
		}

		// Token: 0x0600009A RID: 154 RVA: 0x0001840C File Offset: 0x0001660C
		private void method_5()
		{
			Thread.Sleep(1000);
			if (!this.bool_1)
			{
				int i;
				int m;
				for (i = 3; i >= 0; i = m)
				{
					base.Invoke(new Action(delegate()
					{
						int num2 = i + 1;
						this.stepText2.Text = this.stepText2.Text.Replace("(" + num2.ToString() + ")", "(" + i.ToString() + ")");
					}));
					if (i == 2)
					{
						new Thread(delegate()
						{
							if (this.gclass2_0 != null)
							{
								this.gclass2_0.method_61();
							}
						}).Start();
					}
					if (i != 0)
					{
						Thread.Sleep(1000);
					}
					m = i - 1;
				}
				base.Invoke(new Action(delegate()
				{
					this.stepText2.ForeColor = Color.Gray;
					this.stepText3.ForeColor = this.color_0;
				}));
				Thread.Sleep(1000);
				for (i = 9; i >= 0; i = m)
				{
					base.Invoke(new Action(delegate()
					{
						int num2 = i + 1;
						this.stepText3.Text = this.stepText3.Text.Replace("(" + num2.ToString() + ")", "(" + i.ToString() + ")");
					}));
					if (i != 0)
					{
						Thread.Sleep(1000);
					}
					if (this.gclass2_1 != null)
					{
						break;
					}
					m = i - 1;
				}
				base.Invoke(new Action(delegate()
				{
					this.stepText3.ForeColor = Color.Gray;
				}));
				if (this.gclass2_1 == null && this.method_11(this.string_5, this.string_2, true))
				{
					int num = 0;
					while (num < 5 && this.gclass2_1 == null)
					{
						Thread.Sleep(1000);
						num++;
					}
					Thread.Sleep(1500);
				}
				if (this.gclass2_1 == null)
				{
					base.Invoke(new Action(delegate()
					{
						this.startSteps.Enabled = true;
						this.startSteps.Text = "     Retry     ";
					}));
				}
				else
				{
					base.Invoke(new Action(delegate()
					{
						this.stepsInfo.Text = "Device entered DFU mode successfully.";
					}));
					Thread.Sleep(2000);
					base.Invoke(new Action(delegate()
					{
						this.dfuTabs.SelectedIndex = 2;
					}));
					Thread.Sleep(500);
					base.Invoke(new Action(delegate()
					{
						this.statusText.Text = "Setting up the exploit (this is the heap spray)";
						this.progressBar.Value = 10;
					}));
					try
					{
						this.method_8();
						JailForm.smethod_2(this.string_4);
						Thread.Sleep(1000);
						base.Invoke(new Action(delegate()
						{
							this.statusText.Text = "Setting up the exploit (this is the heap spray)";
							this.progressBar.Value = 30;
						}));
						if (!JailForm.dll_checkm8())
						{
							throw new Exception("Error: setting up the exploit failed. Please reconnect device and try again.");
						}
						Thread.Sleep(500);
						base.Invoke(new Action(delegate()
						{
							this.statusText.Text = "Right before trigger (this is the real bug setup)";
							this.progressBar.Value = 60;
						}));
						if (!JailForm.dll_pongo(null, 0))
						{
							throw new Exception("Error: right before trigger failed. Please reconnect device and try again.");
						}
						GClass11 gclass = new GClass11();
						if (this.bool_2)
						{
							byte[] array = gclass.method_9(File.ReadAllBytes(GClass14.string_3.Replace("cache\\", "") + "boot\\boot-old.raw"), "KA7vv73CtMOzA++/vcKqasOU", "CMKLw6gXQMO5CBlAw7nDqAoA");
							JailForm.dll_checkra1n_load(null, 0, array, array.Length);
						}
						else
						{
							byte[] array2 = gclass.method_9(File.ReadAllBytes(GClass14.string_3.Replace("cache\\", "") + "boot\\patch.raw"), "KA7vv73CtMOzA++/vcKqasOU", "CMKLw6gXQMO5CBlAw7nDqAoA");
							byte[] array3 = gclass.method_9(File.ReadAllBytes(GClass14.string_3.Replace("cache\\", "") + "boot\\boot.raw"), "KA7vv73CtMOzA++/vcKqasOU", "CMKLw6gXQMO5CBlAw7nDqAoA");
							JailForm.dll_checkra1n_load(array2, array2.Length, array3, array3.Length);
						}
						base.Invoke(new Action(delegate()
						{
							this.statusText.Text = "Booting...";
							this.progressBar.Value = 80;
						}));
						Thread.Sleep(3000);
						this.method_12(JailForm.Enum1.const_1);
						Thread.Sleep(3000);
						JailForm.smethod_2(this.string_5);
						Thread.Sleep(1000);
						base.Invoke(new Action(delegate()
						{
							this.statusText.Text = "Uploading bootstrap...\nIt might take up to 60 seconds";
							this.progressBar.Value = 90;
						}));
						GClass15 gclass2 = new GClass15();
						bool flag = false;
						if (this.bool_2)
						{
							GClass17 gclass3 = new GClass17();
							for (int j = 0; j <= 40; j++)
							{
								if (gclass3.method_2(this.string_1))
								{
									flag = true;
									break;
								}
								Thread.Sleep(1000);
							}
						}
						else
						{
							foreach (Process process in Process.GetProcessesByName("iproxy"))
							{
								process.Kill();
							}
							gclass2.method_0("iproxy", "2040 2040 " + this.string_1, false);
							Thread.Sleep(500);
							GClass7 gclass4 = new GClass7();
							for (int l = 0; l <= 80; l++)
							{
								if (gclass4.method_5() == 501)
								{
									flag = true;
									break;
								}
								Thread.Sleep(1000);
							}
						}
						if (flag)
						{
							base.Invoke(new Action(delegate()
							{
								if (this.bool_3)
								{
									this.statusText.Text = "Jailbreak Done.\nNow click on \"Close\" button to hide this window and continue checking device compatibility.";
								}
								else
								{
									this.statusText.Text = "Jailbreak Done.\nNow click on \"Close\" button to hide this window. Then click on \"Start\" button to begin the bypass process.";
								}
								this.progressBar.Value = 100;
								this.closeJailForm.Enabled = true;
							}));
						}
						else
						{
							base.Invoke(new Action(delegate()
							{
								this.statusText.Text = "Error: jailbreak failed. Please reconnect device or restore your device into DFU (recovery) mode via iTunes (Finder) and try again.";
								this.progressBar.Value = 100;
								this.closeJailForm.Enabled = true;
							}));
						}
					}
					catch (Exception ex)
					{
						Exception e2 = ex;
						Exception e = e2;
						this.method_12(JailForm.Enum1.const_1);
						Thread.Sleep(1000);
						JailForm.smethod_2(this.string_5);
						base.Invoke(new Action(delegate()
						{
							if (e.Message.Equals("Error: right before trigger failed. Please reconnect device and try again.") || e.Message.Equals("Error: setting up the exploit failed. Please reconnect device and try again."))
							{
								this.hardResetText.Visible = true;
							}
							this.statusText.Text = e.Message;
							this.progressBar.Value = 100;
							this.closeJailForm.Enabled = true;
						}));
					}
					this.bool_0 = false;
				}
			}
		}

		// Token: 0x0600009B RID: 155 RVA: 0x00017E98 File Offset: 0x00016098
		public void method_6()
		{
		}

		// Token: 0x0600009C RID: 156 RVA: 0x00018924 File Offset: 0x00016B24
		public void method_7()
		{
		}

		// Token: 0x0600009D RID: 157 RVA: 0x00018934 File Offset: 0x00016B34
		private void hardResetText_Click(object sender, EventArgs e)
		{
			Process.Start(GClass14.string_86);
		}

		// Token: 0x0600009E RID: 158 RVA: 0x00018044 File Offset: 0x00016244
		private void closeJailForm_Click(object sender, EventArgs e)
		{
			this.bool_4 = true;
			base.Close();
		}

		// Token: 0x0600009F RID: 159 RVA: 0x0001894C File Offset: 0x00016B4C
		public bool method_8()
		{
			string arguments = "";
			string fullName = new DirectoryInfo(Assembly.GetEntryAssembly().Location).Parent.FullName;
			bool result;
			if (Directory.Exists(fullName + "\\drivers\\libusbk\\"))
			{
				string fileName = fullName + "\\drivers\\libusbk\\dpscat.exe";
				if (!this.method_3())
				{
					result = false;
				}
				else
				{
					Process process = new Process();
					process.StartInfo.FileName = fileName;
					process.StartInfo.Arguments = arguments;
					process.StartInfo.WorkingDirectory = fullName + "\\drivers\\libusbk\\";
					process.EnableRaisingEvents = true;
					process.StartInfo.UseShellExecute = false;
					process.StartInfo.RedirectStandardOutput = true;
					process.StartInfo.RedirectStandardError = true;
					process.StartInfo.CreateNoWindow = true;
					process.ErrorDataReceived += JailForm.smethod_0;
					process.OutputDataReceived += JailForm.smethod_0;
					process.Start();
					process.BeginOutputReadLine();
					process.BeginErrorReadLine();
					process.WaitForExit();
					result = true;
				}
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x00018A64 File Offset: 0x00016C64
		public static bool smethod_1(string infFilePath)
		{
			string fullName = new DirectoryInfo(Assembly.GetEntryAssembly().Location).Parent.FullName;
			bool result;
			if (Directory.Exists(fullName + "\\drivers\\libusbk\\"))
			{
				string fileName;
				if (Environment.Is64BitOperatingSystem)
				{
					fileName = fullName + "\\drivers\\dpinst64.exe";
				}
				else
				{
					fileName = fullName + "\\drivers\\dpinst32.exe";
				}
				string directoryName = Path.GetDirectoryName(infFilePath);
				Process process = new Process();
				process.StartInfo.FileName = fileName;
				process.StartInfo.Arguments = "/F /A /S /PATH \"" + directoryName + "\"";
				process.StartInfo.WorkingDirectory = fullName + "\\drivers\\";
				process.EnableRaisingEvents = true;
				process.StartInfo.UseShellExecute = false;
				process.StartInfo.RedirectStandardOutput = true;
				process.StartInfo.RedirectStandardError = true;
				process.StartInfo.CreateNoWindow = true;
				process.ErrorDataReceived += JailForm.smethod_0;
				process.OutputDataReceived += JailForm.smethod_0;
				process.Start();
				process.BeginOutputReadLine();
				process.BeginErrorReadLine();
				process.WaitForExit();
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x00018B8C File Offset: 0x00016D8C
		public bool method_9(string infFilePath)
		{
			string fullName = new DirectoryInfo(Assembly.GetEntryAssembly().Location).Parent.FullName;
			bool result;
			if (Directory.Exists(fullName + "\\drivers\\libusbk\\"))
			{
				string fileName;
				if (Environment.Is64BitOperatingSystem)
				{
					fileName = fullName + "\\drivers\\dpinst64.exe";
				}
				else
				{
					fileName = fullName + "\\drivers\\dpinst32.exe";
				}
				string directoryName = Path.GetDirectoryName(infFilePath);
				if (this.method_3())
				{
					Process process = new Process();
					process.StartInfo.FileName = fileName;
					process.StartInfo.Arguments = string.Concat(new string[]
					{
						"/F /A /S /PATH \"",
						directoryName,
						"\" /U \"",
						infFilePath,
						"\" "
					});
					process.StartInfo.WorkingDirectory = fullName + "\\drivers\\";
					process.EnableRaisingEvents = true;
					process.StartInfo.UseShellExecute = false;
					process.StartInfo.RedirectStandardOutput = true;
					process.StartInfo.RedirectStandardError = true;
					process.StartInfo.CreateNoWindow = true;
					process.ErrorDataReceived += JailForm.smethod_0;
					process.OutputDataReceived += JailForm.smethod_0;
					process.Start();
					process.BeginOutputReadLine();
					process.BeginErrorReadLine();
					process.WaitForExit();
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

		// Token: 0x060000A2 RID: 162
		[DllImport("newdev.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		public static extern bool UpdateDriverForPlugAndPlayDevices(IntPtr hwndParent, [MarshalAs(UnmanagedType.LPTStr)] [In] string hardwareId, [MarshalAs(UnmanagedType.LPTStr)] [In] string fullInfPath, uint installFlags, out bool pbRebootRequired);

		// Token: 0x060000A3 RID: 163
		[DllImport("newdev.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		public static extern bool DiInstallDriver(IntPtr hwndParent, string fullInfPath, uint installFlags, out bool pbRebootRequired);

		// Token: 0x060000A4 RID: 164
		[DllImport("newdev.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		public static extern bool DiUninstallDriver(IntPtr hwndParent, string fullInfPath, uint installFlags, out bool pbRebootRequired);

		// Token: 0x060000A5 RID: 165
		[DllImport("setupapi.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool SetupCopyOEMInf([MarshalAs(UnmanagedType.LPWStr)] string infName, [MarshalAs(UnmanagedType.LPWStr)] string sourceMediaLocation, JailForm.Enum0 sourceMediaType, JailForm.Enum2 copyStyle, [MarshalAs(UnmanagedType.LPWStr)] [In] [Out] StringBuilder destInfFullPath, uint destInfFullPathSize, ref uint desInfFullPathReqSize, IntPtr destInfFilename);

		// Token: 0x060000A6 RID: 166
		[DllImport("setupapi.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool SetupUninstallOEMInf([MarshalAs(UnmanagedType.LPWStr)] string infName, JailForm.Enum3 flags, IntPtr reserved);

		// Token: 0x060000A7 RID: 167
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern uint GetWindowsDirectory(StringBuilder path, int pathLen);

		// Token: 0x060000A8 RID: 168 RVA: 0x00018CE4 File Offset: 0x00016EE4
		public bool method_10(string text)
		{
			bool result;
			try
			{
				bool flag = false;
				StringBuilder stringBuilder = new StringBuilder(256);
				if (JailForm.GetWindowsDirectory(stringBuilder, stringBuilder.Capacity) == 0U)
				{
					result = false;
				}
				else
				{
					string path = stringBuilder.ToString() + "\\inf";
					string[] files = Directory.GetFiles(path, "oem*.inf");
					foreach (string text2 in files)
					{
						if (File.ReadAllText(text2).Contains(text))
						{
							string infName = text2.Remove(0, text2.LastIndexOf('\\') + 1);
							if (JailForm.SetupUninstallOEMInf(infName, JailForm.Enum3.flag_1, IntPtr.Zero))
							{
								flag = true;
							}
						}
					}
					result = flag;
				}
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x00018DA4 File Offset: 0x00016FA4
		private bool method_11(string infFilePath, string hardwareId, bool correctResult = false)
		{
			this.method_8();
			bool result;
			if (!correctResult)
			{
				result = JailForm.smethod_2(infFilePath);
			}
			else
			{
				bool flag = false;
				try
				{
					IntPtr zero = IntPtr.Zero;
					bool flag2;
					flag = JailForm.UpdateDriverForPlugAndPlayDevices(zero, hardwareId, infFilePath, 1U, out flag2);
				}
				catch (Exception)
				{
					flag = false;
				}
				if (correctResult)
				{
					result = flag;
				}
				else
				{
					if (!flag)
					{
						JailForm.smethod_1(infFilePath);
						flag = true;
					}
					result = flag;
				}
			}
			return result;
		}

		// Token: 0x060000AA RID: 170 RVA: 0x00018E0C File Offset: 0x0001700C
		public static bool smethod_2(string infFilePath)
		{
			bool flag = false;
			try
			{
				StringBuilder stringBuilder = new StringBuilder(260);
				uint num = 0U;
				JailForm.SetupCopyOEMInf(infFilePath, null, JailForm.Enum0.const_1, JailForm.Enum2.const_0, stringBuilder, (uint)stringBuilder.Capacity, ref num, IntPtr.Zero);
			}
			catch (Exception)
			{
			}
			try
			{
				IntPtr zero = IntPtr.Zero;
				bool flag2;
				flag = JailForm.DiInstallDriver(zero, infFilePath, 2U, out flag2);
			}
			catch (Exception)
			{
				flag = false;
			}
			if (!flag)
			{
				JailForm.smethod_1(infFilePath);
				flag = true;
			}
			return flag;
		}

		// Token: 0x060000AB RID: 171 RVA: 0x00018E8C File Offset: 0x0001708C
		private bool method_12(JailForm.Enum1 driverType)
		{
			string text = null;
			bool flag = false;
			if (driverType == JailForm.Enum1.const_0)
			{
				text = this.string_5;
				this.method_10("AppleUSB");
				this.method_10("USBAAPL");
				flag = true;
			}
			if (driverType == JailForm.Enum1.const_1)
			{
				text = this.string_4;
				flag = this.method_10("libusb");
			}
			if (!flag)
			{
				try
				{
					IntPtr zero = IntPtr.Zero;
					bool flag2;
					flag = JailForm.DiUninstallDriver(zero, text, 0U, out flag2);
				}
				catch (Exception)
				{
					flag = false;
				}
			}
			if (!flag)
			{
				this.method_9(text);
				flag = true;
			}
			return flag;
		}

		// Token: 0x060000AC RID: 172 RVA: 0x00018F20 File Offset: 0x00017120
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060000AD RID: 173 RVA: 0x00018F50 File Offset: 0x00017150
		private void InitializeComponent()
		{
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(JailForm));
			this.dfuTabs = new MaterialTabControl();
			this.startTab = new TabPage();
			this.infoText2 = new Label();
			this.dfuNext = new MaterialButton();
			this.infoText = new Label();
			this.dfuCancel = new MaterialButton();
			this.stepsTab = new TabPage();
			this.startSteps = new MaterialButton();
			this.cancelSteps = new MaterialButton();
			this.stepText3 = new Label();
			this.stepText2 = new Label();
			this.stepText1 = new Label();
			this.modelTabs = new MaterialTabControl();
			this.tab_for_x = new TabPage();
			this.label2 = new Label();
			this.label1 = new Label();
			this.pictureBox1 = new PictureBox();
			this.tab_for_8 = new TabPage();
			this.label3 = new Label();
			this.label4 = new Label();
			this.pictureBox2 = new PictureBox();
			this.tab_for_6s = new TabPage();
			this.label11 = new Label();
			this.label5 = new Label();
			this.label6 = new Label();
			this.pictureBox3 = new PictureBox();
			this.tab_for_se = new TabPage();
			this.label13 = new Label();
			this.label7 = new Label();
			this.label8 = new Label();
			this.label12 = new Label();
			this.pictureBox4 = new PictureBox();
			this.tab_for_ipad = new TabPage();
			this.label9 = new Label();
			this.label10 = new Label();
			this.label14 = new Label();
			this.label15 = new Label();
			this.pictureBox5 = new PictureBox();
			this.stepsInfo = new Label();
			this.processTab = new TabPage();
			this.hardResetText = new Label();
			this.closeJailForm = new MaterialButton();
			this.statusText = new Label();
			this.progressBar = new MaterialProgressBar();
			this.jailInfoText = new Label();
			this.dfuTabs.SuspendLayout();
			this.startTab.SuspendLayout();
			this.stepsTab.SuspendLayout();
			this.modelTabs.SuspendLayout();
			this.tab_for_x.SuspendLayout();
			((ISupportInitialize)this.pictureBox1).BeginInit();
			this.tab_for_8.SuspendLayout();
			((ISupportInitialize)this.pictureBox2).BeginInit();
			this.tab_for_6s.SuspendLayout();
			((ISupportInitialize)this.pictureBox3).BeginInit();
			this.tab_for_se.SuspendLayout();
			((ISupportInitialize)this.pictureBox4).BeginInit();
			this.tab_for_ipad.SuspendLayout();
			((ISupportInitialize)this.pictureBox5).BeginInit();
			this.processTab.SuspendLayout();
			base.SuspendLayout();
			this.dfuTabs.Controls.Add(this.startTab);
			this.dfuTabs.Controls.Add(this.stepsTab);
			this.dfuTabs.Controls.Add(this.processTab);
			this.dfuTabs.Depth = 0;
			this.dfuTabs.Location = new Point(-10, -30);
			this.dfuTabs.Margin = new Padding(2, 3, 2, 3);
			this.dfuTabs.MouseState = 0;
			this.dfuTabs.Multiline = true;
			this.dfuTabs.Name = "dfuTabs";
			this.dfuTabs.SelectedIndex = 0;
			this.dfuTabs.Size = new Size(804, 599);
			this.dfuTabs.TabIndex = 0;
			this.startTab.Controls.Add(this.infoText2);
			this.startTab.Controls.Add(this.dfuNext);
			this.startTab.Controls.Add(this.infoText);
			this.startTab.Controls.Add(this.dfuCancel);
			this.startTab.Location = new Point(4, 22);
			this.startTab.Margin = new Padding(2, 3, 2, 3);
			this.startTab.Name = "startTab";
			this.startTab.Padding = new Padding(2, 3, 2, 3);
			this.startTab.Size = new Size(796, 573);
			this.startTab.TabIndex = 0;
			this.startTab.Text = "startTab";
			this.startTab.UseVisualStyleBackColor = true;
			this.infoText2.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.infoText2.Location = new Point(58, 214);
			this.infoText2.Margin = new Padding(2, 0, 2, 0);
			this.infoText2.Name = "infoText2";
			this.infoText2.Size = new Size(696, 89);
			this.infoText2.TabIndex = 21;
			this.infoText2.Text = "Entering recovery mode ........";
			this.infoText2.Visible = false;
			this.dfuNext.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			this.dfuNext.Density = 0;
			this.dfuNext.Depth = 0;
			this.dfuNext.HighEmphasis = true;
			this.dfuNext.Icon = null;
			this.dfuNext.Location = new Point(696, 450);
			this.dfuNext.Margin = new Padding(4, 6, 4, 6);
			this.dfuNext.MouseState = 0;
			this.dfuNext.Name = "dfuNext";
			this.dfuNext.NoAccentTextColor = Color.Empty;
			this.dfuNext.Size = new Size(87, 36);
			this.dfuNext.TabIndex = 20;
			this.dfuNext.Text = "        Next        ";
			this.dfuNext.Type = 2;
			this.dfuNext.UseAccentColor = false;
			this.dfuNext.UseVisualStyleBackColor = true;
			this.dfuNext.Click += this.dfuNext_Click;
			this.infoText.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.infoText.Location = new Point(58, 65);
			this.infoText.Margin = new Padding(2, 0, 2, 0);
			this.infoText.Name = "infoText";
			this.infoText.Size = new Size(696, 114);
			this.infoText.TabIndex = 19;
			this.infoText.Text = componentResourceManager.GetString("infoText.Text");
			this.infoText.TextAlign = ContentAlignment.MiddleLeft;
			this.dfuCancel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			this.dfuCancel.Density = 0;
			this.dfuCancel.Depth = 0;
			this.dfuCancel.HighEmphasis = true;
			this.dfuCancel.Icon = null;
			this.dfuCancel.Location = new Point(610, 450);
			this.dfuCancel.Margin = new Padding(4, 6, 4, 6);
			this.dfuCancel.MouseState = 0;
			this.dfuCancel.Name = "dfuCancel";
			this.dfuCancel.NoAccentTextColor = Color.Empty;
			this.dfuCancel.Size = new Size(77, 36);
			this.dfuCancel.TabIndex = 2;
			this.dfuCancel.Text = "Cancel";
			this.dfuCancel.Type = 0;
			this.dfuCancel.UseAccentColor = false;
			this.dfuCancel.UseVisualStyleBackColor = true;
			this.dfuCancel.Click += this.dfuCancel_Click;
			this.stepsTab.Controls.Add(this.startSteps);
			this.stepsTab.Controls.Add(this.cancelSteps);
			this.stepsTab.Controls.Add(this.stepText3);
			this.stepsTab.Controls.Add(this.stepText2);
			this.stepsTab.Controls.Add(this.stepText1);
			this.stepsTab.Controls.Add(this.modelTabs);
			this.stepsTab.Controls.Add(this.stepsInfo);
			this.stepsTab.Location = new Point(4, 22);
			this.stepsTab.Margin = new Padding(2, 3, 2, 3);
			this.stepsTab.Name = "stepsTab";
			this.stepsTab.Padding = new Padding(2, 3, 2, 3);
			this.stepsTab.Size = new Size(796, 573);
			this.stepsTab.TabIndex = 1;
			this.stepsTab.Text = "tabPage2";
			this.stepsTab.UseVisualStyleBackColor = true;
			this.startSteps.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			this.startSteps.Density = 0;
			this.startSteps.Depth = 0;
			this.startSteps.HighEmphasis = true;
			this.startSteps.Icon = null;
			this.startSteps.Location = new Point(696, 450);
			this.startSteps.Margin = new Padding(4, 6, 4, 6);
			this.startSteps.MouseState = 0;
			this.startSteps.Name = "startSteps";
			this.startSteps.NoAccentTextColor = Color.Empty;
			this.startSteps.Size = new Size(95, 36);
			this.startSteps.TabIndex = 26;
			this.startSteps.Text = "        Start        ";
			this.startSteps.Type = 2;
			this.startSteps.UseAccentColor = false;
			this.startSteps.UseVisualStyleBackColor = true;
			this.startSteps.Click += this.startSteps_Click;
			this.cancelSteps.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			this.cancelSteps.Density = 0;
			this.cancelSteps.Depth = 0;
			this.cancelSteps.HighEmphasis = true;
			this.cancelSteps.Icon = null;
			this.cancelSteps.Location = new Point(612, 450);
			this.cancelSteps.Margin = new Padding(4, 6, 4, 6);
			this.cancelSteps.MouseState = 0;
			this.cancelSteps.Name = "cancelSteps";
			this.cancelSteps.NoAccentTextColor = Color.Empty;
			this.cancelSteps.Size = new Size(77, 36);
			this.cancelSteps.TabIndex = 25;
			this.cancelSteps.Text = "Cancel";
			this.cancelSteps.Type = 0;
			this.cancelSteps.UseAccentColor = false;
			this.cancelSteps.UseVisualStyleBackColor = true;
			this.cancelSteps.Click += this.cancelSteps_Click;
			this.stepText3.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.stepText3.Location = new Point(486, 298);
			this.stepText3.Margin = new Padding(2, 0, 2, 0);
			this.stepText3.Name = "stepText3";
			this.stepText3.Size = new Size(304, 104);
			this.stepText3.TabIndex = 24;
			this.stepText3.Text = "3. Release the Side buttonBUT KEEP HOLDING theVolume down button (10)";
			this.stepText2.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.stepText2.Location = new Point(486, 207);
			this.stepText2.Margin = new Padding(2, 0, 2, 0);
			this.stepText2.Name = "stepText2";
			this.stepText2.Size = new Size(304, 84);
			this.stepText2.TabIndex = 23;
			this.stepText2.Text = "2. Press and hold the Sideand Volume down buttons together (4)";
			this.stepText1.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.stepText1.Location = new Point(486, 159);
			this.stepText1.Margin = new Padding(2, 0, 2, 0);
			this.stepText1.Name = "stepText1";
			this.stepText1.Size = new Size(120, 34);
			this.stepText1.TabIndex = 22;
			this.stepText1.Text = "1. Click Start";
			this.stepText1.TextAlign = ContentAlignment.MiddleLeft;
			this.modelTabs.Controls.Add(this.tab_for_x);
			this.modelTabs.Controls.Add(this.tab_for_8);
			this.modelTabs.Controls.Add(this.tab_for_6s);
			this.modelTabs.Controls.Add(this.tab_for_se);
			this.modelTabs.Controls.Add(this.tab_for_ipad);
			this.modelTabs.Depth = 0;
			this.modelTabs.Location = new Point(34, 130);
			this.modelTabs.Margin = new Padding(2, 3, 2, 3);
			this.modelTabs.MouseState = 0;
			this.modelTabs.Multiline = true;
			this.modelTabs.Name = "modelTabs";
			this.modelTabs.SelectedIndex = 0;
			this.modelTabs.Size = new Size(444, 419);
			this.modelTabs.TabIndex = 21;
			this.tab_for_x.Controls.Add(this.label2);
			this.tab_for_x.Controls.Add(this.label1);
			this.tab_for_x.Controls.Add(this.pictureBox1);
			this.tab_for_x.Location = new Point(4, 22);
			this.tab_for_x.Margin = new Padding(2, 3, 2, 3);
			this.tab_for_x.Name = "tab_for_x";
			this.tab_for_x.Padding = new Padding(2, 3, 2, 3);
			this.tab_for_x.Size = new Size(436, 393);
			this.tab_for_x.TabIndex = 0;
			this.tab_for_x.Text = "tab_for_x";
			this.tab_for_x.UseVisualStyleBackColor = true;
			this.label2.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.label2.Location = new Point(282, 103);
			this.label2.Margin = new Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new Size(148, 35);
			this.label2.TabIndex = 28;
			this.label2.Text = "-- Side button";
			this.label2.TextAlign = ContentAlignment.MiddleLeft;
			this.label1.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.label1.Location = new Point(2, 119);
			this.label1.Margin = new Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new Size(144, 35);
			this.label1.TabIndex = 27;
			this.label1.Text = "Volume down --";
			this.label1.TextAlign = ContentAlignment.MiddleRight;
			this.pictureBox1.Image = Resources.x_black;
			this.pictureBox1.Location = new Point(78, 15);
			this.pictureBox1.Margin = new Padding(2, 3, 2, 3);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new Size(268, 324);
			this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			this.tab_for_8.Controls.Add(this.label3);
			this.tab_for_8.Controls.Add(this.label4);
			this.tab_for_8.Controls.Add(this.pictureBox2);
			this.tab_for_8.Location = new Point(4, 22);
			this.tab_for_8.Margin = new Padding(2, 3, 2, 3);
			this.tab_for_8.Name = "tab_for_8";
			this.tab_for_8.Padding = new Padding(2, 3, 2, 3);
			this.tab_for_8.Size = new Size(436, 393);
			this.tab_for_8.TabIndex = 1;
			this.tab_for_8.Text = "tab_for_8";
			this.tab_for_8.UseVisualStyleBackColor = true;
			this.label3.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.label3.Location = new Point(282, 84);
			this.label3.Margin = new Padding(2, 0, 2, 0);
			this.label3.Name = "label3";
			this.label3.Size = new Size(148, 35);
			this.label3.TabIndex = 31;
			this.label3.Text = "-- Side button";
			this.label3.TextAlign = ContentAlignment.MiddleLeft;
			this.label4.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.label4.Location = new Point(2, 104);
			this.label4.Margin = new Padding(2, 0, 2, 0);
			this.label4.Name = "label4";
			this.label4.Size = new Size(144, 35);
			this.label4.TabIndex = 30;
			this.label4.Text = "Volume down --";
			this.label4.TextAlign = ContentAlignment.MiddleRight;
			this.pictureBox2.Image = Resources.Bitmap_7;
			this.pictureBox2.Location = new Point(82, 7);
			this.pictureBox2.Margin = new Padding(2, 3, 2, 3);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new Size(268, 339);
			this.pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
			this.pictureBox2.TabIndex = 29;
			this.pictureBox2.TabStop = false;
			this.tab_for_6s.Controls.Add(this.label11);
			this.tab_for_6s.Controls.Add(this.label5);
			this.tab_for_6s.Controls.Add(this.label6);
			this.tab_for_6s.Controls.Add(this.pictureBox3);
			this.tab_for_6s.Location = new Point(4, 22);
			this.tab_for_6s.Margin = new Padding(2, 3, 2, 3);
			this.tab_for_6s.Name = "tab_for_6s";
			this.tab_for_6s.Size = new Size(436, 393);
			this.tab_for_6s.TabIndex = 2;
			this.tab_for_6s.Text = "tab_for_6s";
			this.tab_for_6s.UseVisualStyleBackColor = true;
			this.label11.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.label11.Location = new Point(144, 300);
			this.label11.Margin = new Padding(2, 0, 2, 0);
			this.label11.Name = "label11";
			this.label11.Size = new Size(140, 32);
			this.label11.TabIndex = 35;
			this.label11.Text = "|";
			this.label11.TextAlign = ContentAlignment.MiddleCenter;
			this.label5.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.label5.Location = new Point(282, 68);
			this.label5.Margin = new Padding(2, 0, 2, 0);
			this.label5.Name = "label5";
			this.label5.Size = new Size(148, 35);
			this.label5.TabIndex = 34;
			this.label5.Text = "-- Side button";
			this.label5.TextAlign = ContentAlignment.MiddleLeft;
			this.label6.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.label6.Location = new Point(150, 321);
			this.label6.Margin = new Padding(2, 0, 2, 0);
			this.label6.Name = "label6";
			this.label6.Size = new Size(124, 35);
			this.label6.TabIndex = 33;
			this.label6.Text = "Home button";
			this.label6.TextAlign = ContentAlignment.MiddleCenter;
			this.pictureBox3.Image = Resources.Bitmap_7;
			this.pictureBox3.Location = new Point(72, -9);
			this.pictureBox3.Margin = new Padding(2, 3, 2, 3);
			this.pictureBox3.Name = "pictureBox3";
			this.pictureBox3.Size = new Size(282, 351);
			this.pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
			this.pictureBox3.TabIndex = 32;
			this.pictureBox3.TabStop = false;
			this.tab_for_se.Controls.Add(this.label13);
			this.tab_for_se.Controls.Add(this.label7);
			this.tab_for_se.Controls.Add(this.label8);
			this.tab_for_se.Controls.Add(this.label12);
			this.tab_for_se.Controls.Add(this.pictureBox4);
			this.tab_for_se.Location = new Point(4, 22);
			this.tab_for_se.Margin = new Padding(2, 3, 2, 3);
			this.tab_for_se.Name = "tab_for_se";
			this.tab_for_se.Size = new Size(436, 393);
			this.tab_for_se.TabIndex = 3;
			this.tab_for_se.Text = "tab_for_se";
			this.tab_for_se.UseVisualStyleBackColor = true;
			this.label13.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.label13.Location = new Point(168, 26);
			this.label13.Margin = new Padding(2, 0, 2, 0);
			this.label13.Name = "label13";
			this.label13.Size = new Size(140, 25);
			this.label13.TabIndex = 40;
			this.label13.Text = "|";
			this.label13.TextAlign = ContentAlignment.BottomCenter;
			this.label7.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.label7.Location = new Point(138, 295);
			this.label7.Margin = new Padding(2, 0, 2, 0);
			this.label7.Name = "label7";
			this.label7.Size = new Size(140, 32);
			this.label7.TabIndex = 39;
			this.label7.Text = "|";
			this.label7.TextAlign = ContentAlignment.MiddleCenter;
			this.label8.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.label8.Location = new Point(166, 1);
			this.label8.Margin = new Padding(2, 0, 2, 0);
			this.label8.Name = "label8";
			this.label8.Size = new Size(148, 35);
			this.label8.TabIndex = 38;
			this.label8.Text = "Top button";
			this.label8.TextAlign = ContentAlignment.MiddleCenter;
			this.label12.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.label12.Location = new Point(144, 316);
			this.label12.Margin = new Padding(2, 0, 2, 0);
			this.label12.Name = "label12";
			this.label12.Size = new Size(124, 35);
			this.label12.TabIndex = 37;
			this.label12.Text = "Home button";
			this.label12.TextAlign = ContentAlignment.MiddleCenter;
			this.pictureBox4.Image = Resources.Bitmap_5;
			this.pictureBox4.Location = new Point(84, 0);
			this.pictureBox4.Margin = new Padding(2, 3, 2, 3);
			this.pictureBox4.Name = "pictureBox4";
			this.pictureBox4.Size = new Size(246, 355);
			this.pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
			this.pictureBox4.TabIndex = 36;
			this.pictureBox4.TabStop = false;
			this.tab_for_ipad.Controls.Add(this.label9);
			this.tab_for_ipad.Controls.Add(this.label10);
			this.tab_for_ipad.Controls.Add(this.label14);
			this.tab_for_ipad.Controls.Add(this.label15);
			this.tab_for_ipad.Controls.Add(this.pictureBox5);
			this.tab_for_ipad.Location = new Point(4, 22);
			this.tab_for_ipad.Margin = new Padding(2, 3, 2, 3);
			this.tab_for_ipad.Name = "tab_for_ipad";
			this.tab_for_ipad.Size = new Size(436, 393);
			this.tab_for_ipad.TabIndex = 4;
			this.tab_for_ipad.Text = "tab_for_ipad";
			this.tab_for_ipad.UseVisualStyleBackColor = true;
			this.label9.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.label9.Location = new Point(198, 26);
			this.label9.Margin = new Padding(2, 0, 2, 0);
			this.label9.Name = "label9";
			this.label9.Size = new Size(140, 25);
			this.label9.TabIndex = 45;
			this.label9.Text = "|";
			this.label9.TextAlign = ContentAlignment.BottomCenter;
			this.label10.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.label10.Location = new Point(136, 295);
			this.label10.Margin = new Padding(2, 0, 2, 0);
			this.label10.Name = "label10";
			this.label10.Size = new Size(140, 32);
			this.label10.TabIndex = 44;
			this.label10.Text = "|";
			this.label10.TextAlign = ContentAlignment.MiddleCenter;
			this.label14.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.label14.Location = new Point(194, 1);
			this.label14.Margin = new Padding(2, 0, 2, 0);
			this.label14.Name = "label14";
			this.label14.Size = new Size(148, 35);
			this.label14.TabIndex = 43;
			this.label14.Text = "Top button";
			this.label14.TextAlign = ContentAlignment.MiddleCenter;
			this.label15.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.label15.Location = new Point(142, 316);
			this.label15.Margin = new Padding(2, 0, 2, 0);
			this.label15.Name = "label15";
			this.label15.Size = new Size(124, 35);
			this.label15.TabIndex = 42;
			this.label15.Text = "Home button";
			this.label15.TextAlign = ContentAlignment.MiddleCenter;
			this.pictureBox5.Image = Resources.ipad_black;
			this.pictureBox5.Location = new Point(80, 0);
			this.pictureBox5.Margin = new Padding(2, 3, 2, 3);
			this.pictureBox5.Name = "pictureBox5";
			this.pictureBox5.Size = new Size(246, 355);
			this.pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
			this.pictureBox5.TabIndex = 41;
			this.pictureBox5.TabStop = false;
			this.stepsInfo.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.stepsInfo.Location = new Point(58, 65);
			this.stepsInfo.Margin = new Padding(2, 0, 2, 0);
			this.stepsInfo.Name = "stepsInfo";
			this.stepsInfo.Size = new Size(696, 52);
			this.stepsInfo.TabIndex = 20;
			this.stepsInfo.Text = "Time to put the device into DFU mode. Locate the buttons as marked below on your device and check the instructions on the right *before* clicking Start.";
			this.stepsInfo.TextAlign = ContentAlignment.MiddleLeft;
			this.processTab.Controls.Add(this.hardResetText);
			this.processTab.Controls.Add(this.closeJailForm);
			this.processTab.Controls.Add(this.statusText);
			this.processTab.Controls.Add(this.progressBar);
			this.processTab.Controls.Add(this.jailInfoText);
			this.processTab.Location = new Point(4, 22);
			this.processTab.Margin = new Padding(2, 3, 2, 3);
			this.processTab.Name = "processTab";
			this.processTab.Size = new Size(796, 573);
			this.processTab.TabIndex = 2;
			this.processTab.Text = "tabPage1";
			this.processTab.UseVisualStyleBackColor = true;
			this.hardResetText.Cursor = Cursors.Hand;
			this.hardResetText.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.hardResetText.ForeColor = Color.DeepSkyBlue;
			this.hardResetText.Location = new Point(58, 361);
			this.hardResetText.Margin = new Padding(2, 0, 2, 0);
			this.hardResetText.Name = "hardResetText";
			this.hardResetText.Size = new Size(700, 58);
			this.hardResetText.TabIndex = 25;
			this.hardResetText.Text = "Seems like your device stuck on a black screen loading, you need to do a hard reset. Click here to see instruction.";
			this.hardResetText.TextAlign = ContentAlignment.MiddleLeft;
			this.hardResetText.Visible = false;
			this.hardResetText.Click += this.hardResetText_Click;
			this.closeJailForm.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			this.closeJailForm.Density = 0;
			this.closeJailForm.Depth = 0;
			this.closeJailForm.Enabled = false;
			this.closeJailForm.HighEmphasis = true;
			this.closeJailForm.Icon = null;
			this.closeJailForm.Location = new Point(696, 450);
			this.closeJailForm.Margin = new Padding(4, 6, 4, 6);
			this.closeJailForm.MouseState = 0;
			this.closeJailForm.Name = "closeJailForm";
			this.closeJailForm.NoAccentTextColor = Color.Empty;
			this.closeJailForm.Size = new Size(84, 36);
			this.closeJailForm.TabIndex = 24;
			this.closeJailForm.Text = "     Close     ";
			this.closeJailForm.Type = 2;
			this.closeJailForm.UseAccentColor = false;
			this.closeJailForm.UseVisualStyleBackColor = true;
			this.closeJailForm.Click += this.closeJailForm_Click;
			this.statusText.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.statusText.Location = new Point(58, 229);
			this.statusText.Margin = new Padding(2, 0, 2, 0);
			this.statusText.Name = "statusText";
			this.statusText.Size = new Size(696, 95);
			this.statusText.TabIndex = 23;
			this.statusText.Text = "Checking if device is ready";
			this.progressBar.Depth = 0;
			this.progressBar.Location = new Point(62, 209);
			this.progressBar.Margin = new Padding(2, 3, 2, 3);
			this.progressBar.MouseState = 0;
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new Size(680, 5);
			this.progressBar.TabIndex = 22;
			this.jailInfoText.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.jailInfoText.Location = new Point(58, 65);
			this.jailInfoText.Margin = new Padding(2, 0, 2, 0);
			this.jailInfoText.Name = "jailInfoText";
			this.jailInfoText.Size = new Size(696, 52);
			this.jailInfoText.TabIndex = 21;
			this.jailInfoText.Text = "Installing jailbreak, this will take a moment. If the device asks for a passcode please enter it. Do not disconnect the device until finished.";
			this.jailInfoText.TextAlign = ContentAlignment.MiddleLeft;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = SystemColors.ActiveCaption;
			this.BackgroundImageLayout = ImageLayout.None;
			base.ClientSize = new Size(772, 432);
			base.Controls.Add(this.dfuTabs);
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.FormStyle = 0;
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.Margin = new Padding(2, 3, 2, 3);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "JailForm";
			base.Padding = new Padding(2, 0, 2, 3);
			base.Sizable = false;
			base.StartPosition = FormStartPosition.CenterParent;
			this.Text = "Jailbreak";
			base.Load += this.JailForm_Load;
			base.Resize += this.JailForm_Resize;
			this.dfuTabs.ResumeLayout(false);
			this.startTab.ResumeLayout(false);
			this.startTab.PerformLayout();
			this.stepsTab.ResumeLayout(false);
			this.stepsTab.PerformLayout();
			this.modelTabs.ResumeLayout(false);
			this.tab_for_x.ResumeLayout(false);
			((ISupportInitialize)this.pictureBox1).EndInit();
			this.tab_for_8.ResumeLayout(false);
			((ISupportInitialize)this.pictureBox2).EndInit();
			this.tab_for_6s.ResumeLayout(false);
			((ISupportInitialize)this.pictureBox3).EndInit();
			this.tab_for_se.ResumeLayout(false);
			((ISupportInitialize)this.pictureBox4).EndInit();
			this.tab_for_ipad.ResumeLayout(false);
			((ISupportInitialize)this.pictureBox5).EndInit();
			this.processTab.ResumeLayout(false);
			this.processTab.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x0400004D RID: 77
		public MaterialForm materialForm_0;

		// Token: 0x0400004E RID: 78
		public MaterialSkinManager materialSkinManager_0;

		// Token: 0x0400004F RID: 79
		private int int_0 = 22;

		// Token: 0x04000050 RID: 80
		private string string_0 = "Entering recovery mode ........";

		// Token: 0x04000051 RID: 81
		public bool bool_0 = false;

		// Token: 0x04000052 RID: 82
		public GClass2 gclass2_0 = null;

		// Token: 0x04000053 RID: 83
		public GClass2 gclass2_1 = null;

		// Token: 0x04000054 RID: 84
		private System.Windows.Forms.Timer timer_0;

		// Token: 0x04000055 RID: 85
		private Thread thread_0;

		// Token: 0x04000056 RID: 86
		private string productType;

		// Token: 0x04000057 RID: 87
		private string string_1;

		// Token: 0x04000058 RID: 88
		private bool bool_1;

		// Token: 0x04000059 RID: 89
		private Color color_0;

		// Token: 0x0400005A RID: 90
		private bool bool_2;

		// Token: 0x0400005B RID: 91
		public bool bool_3 = false;

		// Token: 0x0400005C RID: 92
		public bool bool_4 = false;

		// Token: 0x0400005D RID: 93
		public Dictionary<string, string> dictionary_0;

		// Token: 0x0400005E RID: 94
		public Dictionary<string, string> dictionary_1;

		// Token: 0x0400005F RID: 95
		public Dictionary<string, string[]> dictionary_2;

		// Token: 0x04000060 RID: 96
		private string string_2 = "USB\\VID_05AC&PID_1227";

		// Token: 0x04000061 RID: 97
		private string string_3 = "USB\\VID_05AC&PID_4141";

		// Token: 0x04000062 RID: 98
		private string string_4;

		// Token: 0x04000063 RID: 99
		private string string_5;

		// Token: 0x04000064 RID: 100
		internal const int int_1 = 260;

		// Token: 0x04000065 RID: 101
		private IContainer icontainer_0 = null;

		// Token: 0x04000066 RID: 102
		private MaterialTabControl dfuTabs;

		// Token: 0x04000067 RID: 103
		private TabPage startTab;

		// Token: 0x04000068 RID: 104
		private TabPage stepsTab;

		// Token: 0x04000069 RID: 105
		private MaterialButton dfuCancel;

		// Token: 0x0400006A RID: 106
		private Label infoText;

		// Token: 0x0400006B RID: 107
		private Label infoText2;

		// Token: 0x0400006C RID: 108
		private Label stepText3;

		// Token: 0x0400006D RID: 109
		private Label stepText2;

		// Token: 0x0400006E RID: 110
		private Label stepText1;

		// Token: 0x0400006F RID: 111
		private MaterialTabControl modelTabs;

		// Token: 0x04000070 RID: 112
		private TabPage tab_for_x;

		// Token: 0x04000071 RID: 113
		private TabPage tab_for_8;

		// Token: 0x04000072 RID: 114
		private TabPage tab_for_6s;

		// Token: 0x04000073 RID: 115
		private TabPage tab_for_se;

		// Token: 0x04000074 RID: 116
		private TabPage tab_for_ipad;

		// Token: 0x04000075 RID: 117
		private Label stepsInfo;

		// Token: 0x04000076 RID: 118
		private TabPage processTab;

		// Token: 0x04000077 RID: 119
		private MaterialButton cancelSteps;

		// Token: 0x04000078 RID: 120
		private MaterialButton dfuNext;

		// Token: 0x04000079 RID: 121
		private MaterialButton startSteps;

		// Token: 0x0400007A RID: 122
		private Label label2;

		// Token: 0x0400007B RID: 123
		private Label label1;

		// Token: 0x0400007C RID: 124
		private PictureBox pictureBox1;

		// Token: 0x0400007D RID: 125
		private Label label3;

		// Token: 0x0400007E RID: 126
		private Label label4;

		// Token: 0x0400007F RID: 127
		private PictureBox pictureBox2;

		// Token: 0x04000080 RID: 128
		private Label label5;

		// Token: 0x04000081 RID: 129
		private Label label6;

		// Token: 0x04000082 RID: 130
		private PictureBox pictureBox3;

		// Token: 0x04000083 RID: 131
		private Label label11;

		// Token: 0x04000084 RID: 132
		private Label label13;

		// Token: 0x04000085 RID: 133
		private Label label7;

		// Token: 0x04000086 RID: 134
		private Label label8;

		// Token: 0x04000087 RID: 135
		private Label label12;

		// Token: 0x04000088 RID: 136
		private PictureBox pictureBox4;

		// Token: 0x04000089 RID: 137
		private Label label9;

		// Token: 0x0400008A RID: 138
		private Label label10;

		// Token: 0x0400008B RID: 139
		private Label label14;

		// Token: 0x0400008C RID: 140
		private Label label15;

		// Token: 0x0400008D RID: 141
		private PictureBox pictureBox5;

		// Token: 0x0400008E RID: 142
		private Label statusText;

		// Token: 0x0400008F RID: 143
		private MaterialProgressBar progressBar;

		// Token: 0x04000090 RID: 144
		private Label jailInfoText;

		// Token: 0x04000091 RID: 145
		private MaterialButton closeJailForm;

		// Token: 0x04000092 RID: 146
		private Label hardResetText;

		// Token: 0x0200000D RID: 13
		internal enum Enum0
		{
			// Token: 0x04000094 RID: 148
			const_0,
			// Token: 0x04000095 RID: 149
			const_1,
			// Token: 0x04000096 RID: 150
			const_2,
			// Token: 0x04000097 RID: 151
			const_3
		}

		// Token: 0x0200000E RID: 14
		internal enum Enum1
		{
			// Token: 0x04000099 RID: 153
			const_0,
			// Token: 0x0400009A RID: 154
			const_1
		}

		// Token: 0x0200000F RID: 15
		internal enum Enum2
		{
			// Token: 0x0400009C RID: 156
			const_0,
			// Token: 0x0400009D RID: 157
			const_1,
			// Token: 0x0400009E RID: 158
			const_2,
			// Token: 0x0400009F RID: 159
			const_3 = 4,
			// Token: 0x040000A0 RID: 160
			const_4 = 4,
			// Token: 0x040000A1 RID: 161
			const_5 = 8,
			// Token: 0x040000A2 RID: 162
			const_6 = 16,
			// Token: 0x040000A3 RID: 163
			const_7 = 32,
			// Token: 0x040000A4 RID: 164
			const_8 = 64,
			// Token: 0x040000A5 RID: 165
			const_9 = 128,
			// Token: 0x040000A6 RID: 166
			const_10 = 256,
			// Token: 0x040000A7 RID: 167
			const_11 = 512,
			// Token: 0x040000A8 RID: 168
			const_12 = 1024,
			// Token: 0x040000A9 RID: 169
			const_13 = 2048,
			// Token: 0x040000AA RID: 170
			const_14 = 4096,
			// Token: 0x040000AB RID: 171
			const_15 = 8192,
			// Token: 0x040000AC RID: 172
			const_16 = 16384,
			// Token: 0x040000AD RID: 173
			const_17 = 32768,
			// Token: 0x040000AE RID: 174
			const_18 = 65536,
			// Token: 0x040000AF RID: 175
			const_19 = 131072,
			// Token: 0x040000B0 RID: 176
			const_20 = 262144,
			// Token: 0x040000B1 RID: 177
			const_21 = 524288,
			// Token: 0x040000B2 RID: 178
			const_22 = 1048576
		}

		// Token: 0x02000010 RID: 16
		[Flags]
		internal enum Enum3 : uint
		{
			// Token: 0x040000B4 RID: 180
			flag_0 = 0U,
			// Token: 0x040000B5 RID: 181
			flag_1 = 1U
		}
	}
}
