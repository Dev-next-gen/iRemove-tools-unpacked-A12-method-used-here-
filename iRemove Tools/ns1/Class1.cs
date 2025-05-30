using System;
using System.Diagnostics;
using System.Windows.Forms;
using MaterialSkin.Controls;
using ns5;

namespace ns1
{
	// Token: 0x02000003 RID: 3
	internal class Class1
	{
		// Token: 0x06000003 RID: 3 RVA: 0x0000DBBC File Offset: 0x0000BDBC
		public Class1(Form1 form)
		{
			this.materialForm_0 = form;
		}

		// Token: 0x06000004 RID: 4 RVA: 0x0000DBD8 File Offset: 0x0000BDD8
		public void method_0(string msg, string okText = "OK", string linkUrl = "")
		{
			this.materialForm_0.Invoke(new Action(delegate()
			{
				this.method_1();
				if (okText == "OK")
				{
					this.materialDialog_0 = new MaterialDialog(this.materialForm_0, GClass14.string_9, msg, okText, false, "Cancel", true);
				}
				else if (msg.Equals(GClass14.string_11))
				{
					this.materialDialog_0 = new MaterialDialog(this.materialForm_0, GClass14.string_9, msg, okText, true, "Download old version", true);
				}
				else
				{
					this.materialDialog_0 = new MaterialDialog(this.materialForm_0, GClass14.string_9, msg, okText, true, "Cancel", true);
				}
				DialogResult dialogResult = this.materialDialog_0.ShowDialog(this.materialForm_0);
				if (dialogResult == DialogResult.OK && okText != "OK")
				{
					if (linkUrl != "" && dialogResult == DialogResult.OK)
					{
						this.method_2(linkUrl);
					}
					if (msg.Equals(GClass14.string_50))
					{
						GClass15 gclass = new GClass15();
						gclass.method_0("idevicediagnostics", "--udid " + GClass14.gclass2_0.UniqueDeviceID + " restart", false);
					}
				}
				if (msg.Equals(GClass14.string_11) && dialogResult == DialogResult.Cancel)
				{
					this.method_2(GClass14.string_81);
					Environment.Exit(0);
				}
			}));
		}

		// Token: 0x06000005 RID: 5 RVA: 0x0000DC20 File Offset: 0x0000BE20
		public void method_1()
		{
			this.materialForm_0.Invoke(new Action(delegate()
			{
				try
				{
					if (this.materialDialog_0 != null)
					{
						this.materialDialog_0.Hide();
						this.materialDialog_0.Close();
					}
					this.materialDialog_0 = null;
				}
				catch
				{
				}
			}));
		}

		// Token: 0x06000006 RID: 6 RVA: 0x0000DC48 File Offset: 0x0000BE48
		public void method_2(string url)
		{
			Process.Start(url);
		}

		// Token: 0x04000001 RID: 1
		private MaterialForm materialForm_0;

		// Token: 0x04000002 RID: 2
		private MaterialDialog materialDialog_0;
	}
}
