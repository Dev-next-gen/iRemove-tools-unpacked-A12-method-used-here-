using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using ns11;
using ns4;
using ns6;
using ns7;

namespace ns2
{
	// Token: 0x0200001B RID: 27
	public class GClass0
	{
		// Token: 0x14000001 RID: 1
		// (add) Token: 0x060000EF RID: 239 RVA: 0x0001BDD4 File Offset: 0x00019FD4
		// (remove) Token: 0x060000F0 RID: 240 RVA: 0x0001BE0C File Offset: 0x0001A00C
		public event GDelegate0 Event_0
		{
			[CompilerGenerated]
			add
			{
				GDelegate0 gdelegate = this.CommonConnectEvent;
				GDelegate0 gdelegate2;
				do
				{
					gdelegate2 = gdelegate;
					GDelegate0 value2 = (GDelegate0)Delegate.Combine(gdelegate2, value);
					gdelegate = Interlocked.CompareExchange<GDelegate0>(ref this.CommonConnectEvent, value2, gdelegate2);
				}
				while (gdelegate != gdelegate2);
			}
			[CompilerGenerated]
			remove
			{
				GDelegate0 gdelegate = this.CommonConnectEvent;
				GDelegate0 gdelegate2;
				do
				{
					gdelegate2 = gdelegate;
					GDelegate0 value2 = (GDelegate0)Delegate.Remove(gdelegate2, value);
					gdelegate = Interlocked.CompareExchange<GDelegate0>(ref this.CommonConnectEvent, value2, gdelegate2);
				}
				while (gdelegate != gdelegate2);
			}
		}

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x060000F1 RID: 241 RVA: 0x0001BE44 File Offset: 0x0001A044
		// (remove) Token: 0x060000F2 RID: 242 RVA: 0x0001BE7C File Offset: 0x0001A07C
		public event GDelegate1 Event_1
		{
			[CompilerGenerated]
			add
			{
				GDelegate1 gdelegate = this.RecoveryConnectEvent;
				GDelegate1 gdelegate2;
				do
				{
					gdelegate2 = gdelegate;
					GDelegate1 value2 = (GDelegate1)Delegate.Combine(gdelegate2, value);
					gdelegate = Interlocked.CompareExchange<GDelegate1>(ref this.RecoveryConnectEvent, value2, gdelegate2);
				}
				while (gdelegate != gdelegate2);
			}
			[CompilerGenerated]
			remove
			{
				GDelegate1 gdelegate = this.RecoveryConnectEvent;
				GDelegate1 gdelegate2;
				do
				{
					gdelegate2 = gdelegate;
					GDelegate1 value2 = (GDelegate1)Delegate.Remove(gdelegate2, value);
					gdelegate = Interlocked.CompareExchange<GDelegate1>(ref this.RecoveryConnectEvent, value2, gdelegate2);
				}
				while (gdelegate != gdelegate2);
			}
		}

		// Token: 0x14000003 RID: 3
		// (add) Token: 0x060000F3 RID: 243 RVA: 0x0001BEB4 File Offset: 0x0001A0B4
		// (remove) Token: 0x060000F4 RID: 244 RVA: 0x0001BEEC File Offset: 0x0001A0EC
		public event GDelegate1 Event_2
		{
			[CompilerGenerated]
			add
			{
				GDelegate1 gdelegate = this.DfuConnectEvent;
				GDelegate1 gdelegate2;
				do
				{
					gdelegate2 = gdelegate;
					GDelegate1 value2 = (GDelegate1)Delegate.Combine(gdelegate2, value);
					gdelegate = Interlocked.CompareExchange<GDelegate1>(ref this.DfuConnectEvent, value2, gdelegate2);
				}
				while (gdelegate != gdelegate2);
			}
			[CompilerGenerated]
			remove
			{
				GDelegate1 gdelegate = this.DfuConnectEvent;
				GDelegate1 gdelegate2;
				do
				{
					gdelegate2 = gdelegate;
					GDelegate1 value2 = (GDelegate1)Delegate.Remove(gdelegate2, value);
					gdelegate = Interlocked.CompareExchange<GDelegate1>(ref this.DfuConnectEvent, value2, gdelegate2);
				}
				while (gdelegate != gdelegate2);
			}
		}

		// Token: 0x14000004 RID: 4
		// (add) Token: 0x060000F5 RID: 245 RVA: 0x0001BF24 File Offset: 0x0001A124
		// (remove) Token: 0x060000F6 RID: 246 RVA: 0x0001BF5C File Offset: 0x0001A15C
		public event EventHandler<GEventArgs2> Event_3
		{
			[CompilerGenerated]
			add
			{
				EventHandler<GEventArgs2> eventHandler = this.ListenErrorEvent;
				EventHandler<GEventArgs2> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<GEventArgs2> value2 = (EventHandler<GEventArgs2>)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<GEventArgs2>>(ref this.ListenErrorEvent, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<GEventArgs2> eventHandler = this.ListenErrorEvent;
				EventHandler<GEventArgs2> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<GEventArgs2> value2 = (EventHandler<GEventArgs2>)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<GEventArgs2>>(ref this.ListenErrorEvent, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x060000F7 RID: 247 RVA: 0x0001BF94 File Offset: 0x0001A194
		public List<GClass2> List_0
		{
			get
			{
				return this.list_0;
			}
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x0001BFAC File Offset: 0x0001A1AC
		private void method_0(ref Struct6 callback)
		{
			try
			{
				switch (callback.genum0_0)
				{
				case GEnum0.const_0:
				{
					GClass2 gclass = this.method_1(callback.intptr_0);
					if (gclass == null)
					{
						gclass = new GClass2(callback.intptr_0);
						gclass.method_59();
						this.list_0.Add(gclass);
					}
					if (this.CommonConnectEvent != null)
					{
						this.CommonConnectEvent(this, new GEventArgs0(gclass, GEnum0.const_0));
					}
					break;
				}
				case GEnum0.const_1:
				{
					GClass2 gclass2 = this.method_1(callback.intptr_0);
					if (gclass2 == null)
					{
						this.list_0.Remove(gclass2);
					}
					if (this.CommonConnectEvent != null)
					{
						this.CommonConnectEvent(this, new GEventArgs0(gclass2, GEnum0.const_1));
					}
					break;
				}
				case GEnum0.Unknown:
					Console.WriteLine("Unknown");
					break;
				case GEnum0.const_3:
				{
					GClass2 gclass3 = this.method_1(callback.intptr_0);
					if (gclass3 != null)
					{
						this.list_0.Remove(gclass3);
						gclass3 = new GClass2(callback.intptr_0);
						gclass3.method_59();
						this.list_0.Add(gclass3);
					}
					if (this.CommonConnectEvent != null)
					{
						this.CommonConnectEvent(this, new GEventArgs0(gclass3, GEnum0.const_0));
					}
					break;
				}
				}
			}
			catch (Exception ex)
			{
				this.ListenErrorEvent(this, new GEventArgs2(ex.Message, GEnum4.const_1));
			}
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x0001C11C File Offset: 0x0001A31C
		private GClass2 method_1(IntPtr devicePtr)
		{
			return (from p in this.list_0
			where p.intptr_0 == devicePtr
			select p).FirstOrDefault<GClass2>();
		}

		// Token: 0x060000FA RID: 250 RVA: 0x0001C154 File Offset: 0x0001A354
		public string method_2()
		{
			return Class4.string_0;
		}

		// Token: 0x060000FB RID: 251 RVA: 0x0001C16C File Offset: 0x0001A36C
		private void method_3(ref GStruct0 callback)
		{
			this.DfuConnectEvent(this, new GEventArgs1(new GClass2(callback.byte_0), GEnum0.const_0));
		}

		// Token: 0x060000FC RID: 252 RVA: 0x0001C198 File Offset: 0x0001A398
		private void method_4(ref GStruct0 callback)
		{
			this.DfuConnectEvent(this, new GEventArgs1(new GClass2(callback.byte_0), GEnum0.const_1));
		}

		// Token: 0x060000FD RID: 253 RVA: 0x0001C1C4 File Offset: 0x0001A3C4
		private void method_5(ref GStruct0 callback)
		{
			Class4.AMRecoveryModeDeviceSetAutoBoot(callback.byte_0, 1);
			if (this.RecoveryConnectEvent != null)
			{
				this.RecoveryConnectEvent(this, new GEventArgs1(new GClass2(callback.byte_0), GEnum0.const_0));
			}
		}

		// Token: 0x060000FE RID: 254 RVA: 0x0001C208 File Offset: 0x0001A408
		private void method_6(ref GStruct0 callback)
		{
			if (this.RecoveryConnectEvent != null)
			{
				this.RecoveryConnectEvent(this, new GEventArgs1(new GClass2(callback.byte_0), GEnum0.const_1));
			}
		}

		// Token: 0x060000FF RID: 255 RVA: 0x0001C240 File Offset: 0x0001A440
		public void method_7()
		{
			if (!this.bool_0)
			{
				this.bool_0 = true;
				try
				{
					this.delegate8_0 = new Delegate8(this.method_0);
					this.delegate9_2 = new Delegate9(this.method_3);
					this.delegate9_0 = new Delegate9(this.method_5);
					this.delegate9_3 = new Delegate9(this.method_4);
					this.delegate9_1 = new Delegate9(this.method_6);
					IntPtr zero = IntPtr.Zero;
					GEnum3 genum = (GEnum3)Class4.AMDeviceNotificationSubscribe(this.delegate8_0, 0U, 1U, 0U, ref zero);
					if (genum > GEnum3.const_80 && this.ListenErrorEvent != null)
					{
						this.ListenErrorEvent(this, new GEventArgs2("AMDeviceNotificationSubscribe failed with error : " + genum.ToString(), GEnum4.const_0));
					}
					IntPtr zero2 = IntPtr.Zero;
					genum = (GEnum3)Class4.AMRestoreRegisterForDeviceNotifications(this.delegate9_2, this.delegate9_0, this.delegate9_3, this.delegate9_1, 0U, ref zero2);
					if (genum > GEnum3.const_80 && this.ListenErrorEvent != null)
					{
						this.ListenErrorEvent(this, new GEventArgs2("AMRestoreRegisterForDeviceNotifications failed with error : " + genum.ToString(), GEnum4.const_0));
					}
				}
				catch (Exception ex)
				{
					if (this.ListenErrorEvent != null)
					{
						this.ListenErrorEvent(this, new GEventArgs2(ex.Message, GEnum4.const_0));
					}
				}
			}
		}

		// Token: 0x040000C2 RID: 194
		private bool bool_0 = false;

		// Token: 0x040000C3 RID: 195
		private Delegate8 delegate8_0;

		// Token: 0x040000C4 RID: 196
		private Delegate9 delegate9_0;

		// Token: 0x040000C5 RID: 197
		private Delegate9 delegate9_1;

		// Token: 0x040000C6 RID: 198
		private Delegate9 delegate9_2;

		// Token: 0x040000C7 RID: 199
		private Delegate9 delegate9_3;

		// Token: 0x040000C8 RID: 200
		private List<GClass2> list_0 = new List<GClass2>();

		// Token: 0x040000C9 RID: 201
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private GDelegate0 CommonConnectEvent;

		// Token: 0x040000CA RID: 202
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private GDelegate1 RecoveryConnectEvent;

		// Token: 0x040000CB RID: 203
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private GDelegate1 DfuConnectEvent;

		// Token: 0x040000CC RID: 204
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EventHandler<GEventArgs2> ListenErrorEvent;
	}
}
