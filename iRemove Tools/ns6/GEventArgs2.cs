using System;
using ns7;

namespace ns6
{
	// Token: 0x02000041 RID: 65
	public class GEventArgs2 : EventArgs
	{
		// Token: 0x1700004B RID: 75
		// (get) Token: 0x060002C3 RID: 707 RVA: 0x00026080 File Offset: 0x00024280
		public string String_0
		{
			get
			{
				return this.string_0;
			}
		}

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x060002C4 RID: 708 RVA: 0x00026098 File Offset: 0x00024298
		public GEnum4 GEnum4_0
		{
			get
			{
				return this.genum4_0;
			}
		}

		// Token: 0x060002C5 RID: 709 RVA: 0x0000DAC4 File Offset: 0x0000BCC4
		public GEventArgs2(string errorMessage, GEnum4 errorType)
		{
			this.string_0 = errorMessage;
			this.genum4_0 = errorType;
		}

		// Token: 0x040001A5 RID: 421
		private string string_0;

		// Token: 0x040001A6 RID: 422
		private GEnum4 genum4_0;
	}
}
