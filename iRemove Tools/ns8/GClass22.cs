using System;
using System.IO;
using System.IO.Compression;

namespace ns8
{
	// Token: 0x02000049 RID: 73
	public static class GClass22
	{
		// Token: 0x060002CB RID: 715 RVA: 0x000263B8 File Offset: 0x000245B8
		public static void smethod_0(this ZipArchive archive, string destinationDirectoryName, bool overwrite)
		{
			if (!overwrite)
			{
				archive.ExtractToDirectory(destinationDirectoryName);
			}
			else
			{
				foreach (ZipArchiveEntry zipArchiveEntry in archive.Entries)
				{
					try
					{
						string text = Path.Combine(destinationDirectoryName, zipArchiveEntry.FullName);
						if (zipArchiveEntry.Name == "")
						{
							Directory.CreateDirectory(Path.GetDirectoryName(text));
						}
						else
						{
							zipArchiveEntry.ExtractToFile(text, true);
						}
					}
					catch
					{
					}
				}
			}
		}
	}
}
