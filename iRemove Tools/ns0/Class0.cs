using System;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using ns1;

namespace ns0
{
	// Token: 0x02000002 RID: 2
	internal static class Class0
	{
		// Token: 0x06000001 RID: 1 RVA: 0x0000DB4C File Offset: 0x0000BD4C
		[STAThread]
		private static void Main()
		{
			bool flag = false;
			string name = Assembly.GetExecutingAssembly().GetName().Name;
			using (Mutex mutex = new Mutex(true, name, ref flag))
			{
				if (flag)
				{
					Application.EnableVisualStyles();
					Application.SetCompatibleTextRenderingDefault(false);
					Application.Run(new Form1());
					mutex.ReleaseMutex();
				}
				else
				{
					MessageBox.Show("An application instance is already running");
				}
			}
		}
	}
}
