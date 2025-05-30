using System;
using System.IO;
using Microsoft.Win32;
using ns2;

namespace ns5
{
	// Token: 0x0200003C RID: 60
	public class GClass19
	{
		// Token: 0x060002AC RID: 684 RVA: 0x00025DB8 File Offset: 0x00023FB8
		public static string smethod_0()
		{
			RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Apple Inc.\\Apple Mobile Device Support\\Shared");
			if (registryKey != null)
			{
				string text = registryKey.GetValue("iTunesMobileDeviceDLL") as string;
				if (!string.IsNullOrWhiteSpace(text))
				{
					FileInfo fileInfo = new FileInfo(text);
					if (fileInfo.Exists)
					{
						return fileInfo.DirectoryName;
					}
				}
			}
			string text2 = Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFiles) + "\\Apple\\Mobile Device Support";
			string result;
			if (File.Exists(text2 + "\\iTunesMobileDevice.dll"))
			{
				result = text2;
			}
			else
			{
				text2 = Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFilesX86) + "\\Apple\\Mobile Device Support";
				if (!File.Exists(text2 + "\\iTunesMobileDevice.dll"))
				{
					if (File.Exists(Class4.string_0 + "\\win-x64\\iTunesMobileDevice.dll"))
					{
						if (Environment.Is64BitOperatingSystem)
						{
							result = Class4.string_0 + "\\win-x64\\";
						}
						else
						{
							result = Class4.string_0 + "\\win-x86\\";
						}
					}
					else
					{
						result = string.Empty;
					}
				}
				else
				{
					result = text2;
				}
			}
			return result;
		}

		// Token: 0x060002AD RID: 685 RVA: 0x00025EB4 File Offset: 0x000240B4
		public static string smethod_1()
		{
			RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Apple Inc.\\Apple Mobile Device Support\\Shared");
			if (registryKey != null)
			{
				string text = registryKey.GetValue("MobileDeviceDLL") as string;
				if (!string.IsNullOrWhiteSpace(text))
				{
					FileInfo fileInfo = new FileInfo(text);
					if (fileInfo.Exists)
					{
						return fileInfo.DirectoryName;
					}
				}
			}
			string text2 = Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFiles) + "\\Apple\\Mobile Device Support";
			string result;
			if (!File.Exists(text2 + "\\MobileDevice.dll"))
			{
				text2 = Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFilesX86) + "\\Apple\\Mobile Device Support";
				if (File.Exists(text2 + "\\MobileDevice.dll"))
				{
					result = text2;
				}
				else
				{
					result = string.Empty;
				}
			}
			else
			{
				result = text2;
			}
			return result;
		}

		// Token: 0x060002AE RID: 686 RVA: 0x00025F6C File Offset: 0x0002416C
		public static string smethod_2()
		{
			RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Apple Inc.\\Apple Application Support");
			if (registryKey != null)
			{
				string text = registryKey.GetValue("InstallDir") as string;
				if (!string.IsNullOrWhiteSpace(text) && File.Exists(text + "\\CoreFoundation.dll"))
				{
					return text;
				}
			}
			string text2 = Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFiles) + "\\Apple\\Apple Application Support\\";
			string result;
			if (File.Exists(text2 + "\\CoreFoundation.dll"))
			{
				result = text2;
			}
			else
			{
				text2 = Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFilesX86) + "\\Apple\\Apple Application Support\\";
				if (File.Exists(text2 + "\\CoreFoundation.dll"))
				{
					result = text2;
				}
				else
				{
					result = string.Empty;
				}
			}
			return result;
		}
	}
}
