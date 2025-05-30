using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace ns1
{
	// Token: 0x02000006 RID: 6
	internal class Class3 : Panel
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x0600000E RID: 14 RVA: 0x0000DE4C File Offset: 0x0000C04C
		// (set) Token: 0x0600000F RID: 15 RVA: 0x0000DE60 File Offset: 0x0000C060
		public bool Boolean_0 { get; set; }

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000010 RID: 16 RVA: 0x0000DE74 File Offset: 0x0000C074
		// (set) Token: 0x06000011 RID: 17 RVA: 0x0000DE88 File Offset: 0x0000C088
		public Color Color_0 { get; set; }

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000012 RID: 18 RVA: 0x0000DE9C File Offset: 0x0000C09C
		// (set) Token: 0x06000013 RID: 19 RVA: 0x0000DEB0 File Offset: 0x0000C0B0
		public bool Boolean_1 { get; set; }

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000014 RID: 20 RVA: 0x0000DEC4 File Offset: 0x0000C0C4
		// (set) Token: 0x06000015 RID: 21 RVA: 0x0000DED8 File Offset: 0x0000C0D8
		public bool Boolean_2 { get; private set; }

		// Token: 0x06000016 RID: 22 RVA: 0x0000DEEC File Offset: 0x0000C0EC
		public Class3()
		{
			this.DoubleBuffered = true;
			this.class2_0.Size = Size.Empty;
			this.class2_0.Parent = this;
			this.class2_0.BackColor = Color.Transparent;
			this.class2_0.Paint += this.class2_0_Paint;
			this.BackColor = Color.DodgerBlue;
			this.Boolean_0 = false;
			Color backColor = this.BackColor;
			this.Boolean_2 = false;
			this.Boolean_1 = true;
			this.class2_0.BackgroundImageLayout = ImageLayout.None;
			this.timer_0.Tick += this.timer_0_Tick;
		}

		// Token: 0x06000017 RID: 23 RVA: 0x0000DFD0 File Offset: 0x0000C1D0
		private void class2_0_Paint(object sender, PaintEventArgs e)
		{
			if (this.float_0 >= 0f && this.float_0 <= 255f)
			{
				using (SolidBrush solidBrush = new SolidBrush(Color.FromArgb((int)this.float_0, this.Color_0)))
				{
					e.Graphics.FillRectangle(solidBrush, this.class2_0.ClientRectangle);
				}
			}
		}

		// Token: 0x06000018 RID: 24 RVA: 0x0000E04C File Offset: 0x0000C24C
		public void method_0()
		{
			if (this.bitmap_0 == null)
			{
				this.bitmap_0 = new Bitmap(base.ClientSize.Width, base.ClientSize.Height);
			}
			base.DrawToBitmap(this.bitmap_0, base.ClientRectangle);
			this.class2_0.BackgroundImage = this.bitmap_0;
		}

		// Token: 0x06000019 RID: 25 RVA: 0x0000E0B0 File Offset: 0x0000C2B0
		public void method_1(int ms)
		{
			this.float_0 = 0f;
			this.float_1 = 256f / (float)ms * (float)this.timer_0.Interval;
			this.method_3(this.float_1);
		}

		// Token: 0x0600001A RID: 26 RVA: 0x0000E0F0 File Offset: 0x0000C2F0
		public void method_2(int ms)
		{
			this.float_0 = 255f;
			this.float_1 = -256f / (float)ms * (float)this.timer_0.Interval;
			this.method_3(this.float_1);
		}

		// Token: 0x0600001B RID: 27 RVA: 0x0000E130 File Offset: 0x0000C330
		private void method_3(float delta)
		{
			if (this.bitmap_0 == null || !this.Boolean_1)
			{
				this.method_0();
			}
			base.BringToFront();
			this.Color_0 = (this.Boolean_0 ? base.Parent.BackColor : this.Color_0);
			this.class2_0.BringToFront();
			this.class2_0.Size = base.ClientSize;
			this.timer_0.Start();
		}

		// Token: 0x0600001C RID: 28 RVA: 0x0000E1A8 File Offset: 0x0000C3A8
		private void timer_0_Tick(object sender, EventArgs e)
		{
			this.float_0 += this.float_1;
			if (this.float_0 >= 255f || this.float_0 <= 0f)
			{
				this.float_0 = (float)((this.float_1 > 0f) ? 255 : 0);
				this.timer_0.Stop();
				if (this.float_1 < 0f)
				{
					base.BringToFront();
				}
				else
				{
					base.SendToBack();
				}
				this.Boolean_2 = (this.float_1 > 0f);
				this.class2_0.Size = ((this.float_1 > 0f) ? base.ClientSize : Size.Empty);
			}
			this.class2_0.Invalidate();
		}

		// Token: 0x04000007 RID: 7
		private Class2 class2_0 = new Class2();

		// Token: 0x04000008 RID: 8
		private Bitmap bitmap_0 = null;

		// Token: 0x04000009 RID: 9
		private float float_0 = 0f;

		// Token: 0x0400000A RID: 10
		private float float_1 = 1f;

		// Token: 0x0400000B RID: 11
		private Timer timer_0 = new Timer
		{
			Interval = 25
		};

		// Token: 0x0400000C RID: 12
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool bool_0;

		// Token: 0x0400000D RID: 13
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private Color color_0;

		// Token: 0x0400000E RID: 14
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool bool_1;

		// Token: 0x0400000F RID: 15
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private bool bool_2;
	}
}
