using System;
using System.Runtime.InteropServices;

namespace ns9
{
	// Token: 0x0200004A RID: 74
	public class GClass23
	{
		// Token: 0x060002CD RID: 717
		[DllImport("kernel32.dll")]
		public static extern bool CloseHandle(IntPtr hObject);

		// Token: 0x060002CE RID: 718
		[DllImport("kernel32.dll")]
		public static extern bool CreatePipe(ref IntPtr hReadPipe, ref IntPtr hWritePipe, GClass26 lpPipeAttributes, int nSize);

		// Token: 0x060002CF RID: 719
		[DllImport("kernel32.dll")]
		public static extern bool CreateProcess(string lpApplicationName, string lpCommandLine, GClass26 lpProcessAttributes, GClass26 lpThreadAttributes, bool bInheritHandles, int dwCreationFlags, string lpEnvironment, string lpCurrentDirectory, ref GStruct2 lpStartupInfo, ref GStruct1 lpProcessInformation);

		// Token: 0x060002D0 RID: 720
		[DllImport("kernel32.dll")]
		public static extern bool FreeLibrary(IntPtr hModule);

		// Token: 0x060002D1 RID: 721 RVA: 0x00026454 File Offset: 0x00024654
		public static Delegate smethod_0(IntPtr dllModule, string functionName, Type t)
		{
			IntPtr procAddress = GClass23.GetProcAddress(dllModule, functionName);
			Delegate result;
			if (procAddress == IntPtr.Zero)
			{
				result = null;
			}
			else
			{
				result = Marshal.GetDelegateForFunctionPointer(procAddress, t);
			}
			return result;
		}

		// Token: 0x060002D2 RID: 722
		[DllImport("kernel32.dll")]
		public static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

		// Token: 0x060002D3 RID: 723
		[DllImport("kernel32.dll")]
		public static extern IntPtr LoadLibrary(string lpFileName);

		// Token: 0x060002D4 RID: 724
		[DllImport("kernel32.dll")]
		public static extern bool ReadFile(IntPtr hFile, byte[] lpBuffer, int nNumberOfBytesToRead, ref int lpNumberOfBytesRead, IntPtr lpOverlapped);

		// Token: 0x040002A3 RID: 675
		public const int int_0 = 32;

		// Token: 0x040002A4 RID: 676
		public const int int_1 = 128;

		// Token: 0x040002A5 RID: 677
		public const int int_2 = 64;

		// Token: 0x040002A6 RID: 678
		public const int int_3 = 32;

		// Token: 0x040002A7 RID: 679
		public const int int_4 = 8;

		// Token: 0x040002A8 RID: 680
		public const int int_5 = 16;

		// Token: 0x040002A9 RID: 681
		public const int int_6 = 4;

		// Token: 0x040002AA RID: 682
		public const int int_7 = 1;

		// Token: 0x040002AB RID: 683
		public const int int_8 = 2;

		// Token: 0x040002AC RID: 684
		public const int int_9 = 256;

		// Token: 0x040002AD RID: 685
		public const int int_10 = 11;

		// Token: 0x040002AE RID: 686
		public const int int_11 = 0;

		// Token: 0x040002AF RID: 687
		public const int int_12 = 11;

		// Token: 0x040002B0 RID: 688
		public const int int_13 = 3;

		// Token: 0x040002B1 RID: 689
		public const int int_14 = 6;

		// Token: 0x040002B2 RID: 690
		public const int int_15 = 1;

		// Token: 0x040002B3 RID: 691
		public const int int_16 = 9;

		// Token: 0x040002B4 RID: 692
		public const int int_17 = 5;

		// Token: 0x040002B5 RID: 693
		public const int int_18 = 10;

		// Token: 0x040002B6 RID: 694
		public const int int_19 = 3;

		// Token: 0x040002B7 RID: 695
		public const int int_20 = 2;

		// Token: 0x040002B8 RID: 696
		public const int int_21 = 7;

		// Token: 0x040002B9 RID: 697
		public const int int_22 = 8;

		// Token: 0x040002BA RID: 698
		public const int int_23 = 4;

		// Token: 0x040002BB RID: 699
		public const int int_24 = 1;

		// Token: 0x0200004B RID: 75
		public sealed class GDelegate2 : MulticastDelegate
		{
			// Token: 0x060002D7 RID: 727
			public extern GDelegate2(object @object, IntPtr method);

			// Token: 0x060002D8 RID: 728
			public extern bool Invoke();

			// Token: 0x060002D9 RID: 729
			public extern IAsyncResult BeginInvoke(AsyncCallback callback, object @object);

			// Token: 0x060002DA RID: 730
			public extern bool EndInvoke(IAsyncResult result);
		}

		// Token: 0x0200004C RID: 76
		public sealed class GDelegate3 : MulticastDelegate
		{
			// Token: 0x060002DC RID: 732
			public extern GDelegate3(object @object, IntPtr method);

			// Token: 0x060002DD RID: 733
			public extern bool Invoke(string sourceFileMp3, string destFileWav);

			// Token: 0x060002DE RID: 734
			public extern IAsyncResult BeginInvoke(string sourceFileMp3, string destFileWav, AsyncCallback callback, object @object);

			// Token: 0x060002DF RID: 735
			public extern bool EndInvoke(IAsyncResult result);
		}

		// Token: 0x0200004D RID: 77
		public sealed class GDelegate4 : MulticastDelegate
		{
			// Token: 0x060002E1 RID: 737
			public extern GDelegate4(object @object, IntPtr method);

			// Token: 0x060002E2 RID: 738
			public extern bool Invoke(string sourceFileWav, string destFileMp3);

			// Token: 0x060002E3 RID: 739
			public extern IAsyncResult BeginInvoke(string sourceFileWav, string destFileMp3, AsyncCallback callback, object @object);

			// Token: 0x060002E4 RID: 740
			public extern bool EndInvoke(IAsyncResult result);
		}

		// Token: 0x0200004E RID: 78
		public sealed class GDelegate5 : MulticastDelegate
		{
			// Token: 0x060002E6 RID: 742
			public extern GDelegate5(object @object, IntPtr method);

			// Token: 0x060002E7 RID: 743
			public extern int Invoke();

			// Token: 0x060002E8 RID: 744
			public extern IAsyncResult BeginInvoke(AsyncCallback callback, object @object);

			// Token: 0x060002E9 RID: 745
			public extern int EndInvoke(IAsyncResult result);
		}

		// Token: 0x0200004F RID: 79
		public sealed class GDelegate6 : MulticastDelegate
		{
			// Token: 0x060002EB RID: 747
			public extern GDelegate6(object @object, IntPtr method);

			// Token: 0x060002EC RID: 748
			public extern double Invoke(double secondTime);

			// Token: 0x060002ED RID: 749
			public extern IAsyncResult BeginInvoke(double secondTime, AsyncCallback callback, object @object);

			// Token: 0x060002EE RID: 750
			public extern double EndInvoke(IAsyncResult result);
		}

		// Token: 0x02000050 RID: 80
		public sealed class GDelegate7 : MulticastDelegate
		{
			// Token: 0x060002F0 RID: 752
			public extern GDelegate7(object @object, IntPtr method);

			// Token: 0x060002F1 RID: 753
			public extern int Invoke();

			// Token: 0x060002F2 RID: 754
			public extern IAsyncResult BeginInvoke(AsyncCallback callback, object @object);

			// Token: 0x060002F3 RID: 755
			public extern int EndInvoke(IAsyncResult result);
		}

		// Token: 0x02000051 RID: 81
		public sealed class GDelegate8 : MulticastDelegate
		{
			// Token: 0x060002F5 RID: 757
			public extern GDelegate8(object @object, IntPtr method);

			// Token: 0x060002F6 RID: 758
			public extern bool Invoke(string fileWavName);

			// Token: 0x060002F7 RID: 759
			public extern IAsyncResult BeginInvoke(string fileWavName, AsyncCallback callback, object @object);

			// Token: 0x060002F8 RID: 760
			public extern bool EndInvoke(IAsyncResult result);
		}

		// Token: 0x02000052 RID: 82
		public sealed class GDelegate9 : MulticastDelegate
		{
			// Token: 0x060002FA RID: 762
			public extern GDelegate9(object @object, IntPtr method);

			// Token: 0x060002FB RID: 763
			public extern bool Invoke(string fileWavOut, double begin, double end, double in_time, double out_time);

			// Token: 0x060002FC RID: 764
			public extern IAsyncResult BeginInvoke(string fileWavOut, double begin, double end, double in_time, double out_time, AsyncCallback callback, object @object);

			// Token: 0x060002FD RID: 765
			public extern bool EndInvoke(IAsyncResult result);
		}
	}
}
