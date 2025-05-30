using System;
using System.Diagnostics;
using ns2;

namespace ns5
{
	// Token: 0x02000037 RID: 55
	public class GClass15
	{
		// Token: 0x0600028A RID: 650 RVA: 0x000254EC File Offset: 0x000236EC
		public string method_0(string libName, string args, bool wait)
		{
			Process process = new Process();
			string string_ = Class4.string_1;
			string_.Replace("\\", "\\");
			string valor = string_ + libName + ".exe";
			process.StartInfo.FileName = Environment.SystemDirectory + "\\cmd.exe";
			process.StartInfo.Arguments = " /c " + GClass15.smethod_0(GClass15.smethod_0(valor) + " " + args);
			process.StartInfo.CreateNoWindow = true;
			process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.RedirectStandardOutput = true;
			process.Start();
			string result;
			if (wait)
			{
				string text = process.StandardOutput.ReadToEnd();
				result = text;
			}
			else
			{
				result = "";
			}
			return result;
		}

		// Token: 0x0600028B RID: 651 RVA: 0x000255C0 File Offset: 0x000237C0
		public void method_1(string name)
		{
			new Process
			{
				StartInfo = 
				{
					FileName = Environment.SystemDirectory + "\\cmd.exe",
					Arguments = " /c taskkill /IM \"" + name + "\" /F",
					CreateNoWindow = true,
					WindowStyle = ProcessWindowStyle.Hidden,
					UseShellExecute = false,
					RedirectStandardOutput = true
				}
			}.Start();
		}

		// Token: 0x0600028C RID: 652 RVA: 0x00025640 File Offset: 0x00023840
		private static string smethod_0(string valor)
		{
			return "\"" + valor + "\"";
		}
	}
}
