using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using iMobileDevice;
using iMobileDevice.Afc;
using iMobileDevice.DiagnosticsRelay;
using iMobileDevice.iDevice;
using iMobileDevice.iDeviceActivation;
using iMobileDevice.Lockdown;
using iMobileDevice.Mobileactivation;
using iMobileDevice.MobileBackup2;
using iMobileDevice.Plist;
using iMobileDevice.Recovery;
using ns10;
using ns3;
using ns5;
using ns7;
using ns9;

namespace ns2
{
	// Token: 0x0200001E RID: 30
	public class GClass2
	{
		// Token: 0x17000023 RID: 35
		// (get) Token: 0x06000107 RID: 263 RVA: 0x0001C3D4 File Offset: 0x0001A5D4
		public bool Boolean_0
		{
			get
			{
				return this.bool_0;
			}
		}

		// Token: 0x06000108 RID: 264 RVA: 0x0001C3E8 File Offset: 0x0001A5E8
		public GClass2(IntPtr devicePtr)
		{
			this.intptr_0 = devicePtr;
			this.method_3();
		}

		// Token: 0x06000109 RID: 265 RVA: 0x0001C5F0 File Offset: 0x0001A7F0
		public GClass2(byte[] deviceBytes)
		{
			this.byte_0 = deviceBytes;
		}

		// Token: 0x0600010A RID: 266 RVA: 0x0001C7F4 File Offset: 0x0001A9F4
		public void method_0(string InternationalMobileEquipmentIdentity, string SerialNumber, string UniqueDeviceID, string BuildVersion, string DeviceName, string MobileEquipmentIdentifier, string PhoneNumber, string ProductType, string ProductVersion, string Model, string IntegratedCircuitCardIdentity)
		{
			this.string_15 = InternationalMobileEquipmentIdentity;
			this.string_16 = this.InternationalMobileEquipmentIdentity2;
			this.string_17 = SerialNumber;
			this.string_19 = UniqueDeviceID;
			this.string_5 = BuildVersion;
			this.string_9 = DeviceName;
			this.string_23 = MobileEquipmentIdentifier;
			this.string_13 = PhoneNumber;
			this.productType = ProductType;
			this.string_21 = ProductVersion;
			this.string_22 = Model;
			this.string_14 = IntegratedCircuitCardIdentity;
		}

		// Token: 0x0600010B RID: 267 RVA: 0x0001C864 File Offset: 0x0001AA64
		public GEnum3 method_1()
		{
			GEnum3 genum = GEnum3.const_80;
			try
			{
				if (!this.bool_0)
				{
					genum = (GEnum3)Class4.AMDeviceConnect(this.intptr_0);
					if (genum == GEnum3.const_80)
					{
						this.bool_0 = true;
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
			return genum;
		}

		// Token: 0x0600010C RID: 268 RVA: 0x0001C8BC File Offset: 0x0001AABC
		public GEnum3 method_2()
		{
			GEnum3 result = GEnum3.const_80;
			this.bool_0 = false;
			try
			{
				result = (GEnum3)Class4.AMDeviceDisconnect(this.intptr_0);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
			return result;
		}

		// Token: 0x0600010D RID: 269 RVA: 0x0001C904 File Offset: 0x0001AB04
		private bool method_3()
		{
			bool result = false;
			try
			{
				if (this.method_1() > GEnum3.const_80)
				{
					return false;
				}
				if (Class4.AMDeviceValidatePairing(this.intptr_0) != 0)
				{
					GEnum3 genum = (GEnum3)Class4.AMDevicePair(this.intptr_0);
					if (genum > GEnum3.const_80)
					{
						this.method_2();
						return false;
					}
				}
				this.bool_1 = false;
				if (this.method_4(false) == GEnum3.const_80)
				{
					this.bool_0 = true;
					result = true;
				}
			}
			catch
			{
			}
			return result;
		}

		// Token: 0x0600010E RID: 270 RVA: 0x0001C98C File Offset: 0x0001AB8C
		public GEnum3 method_4(bool isRretry = false)
		{
			GEnum3 genum = GEnum3.const_80;
			try
			{
				if (!this.bool_1)
				{
					genum = (GEnum3)Class4.AMDeviceStartSession(this.intptr_0);
					if (genum != GEnum3.const_33)
					{
						if (genum <= GEnum3.const_80)
						{
							this.bool_1 = true;
							return genum;
						}
						if (!isRretry)
						{
							this.method_2();
							this.method_1();
							return this.method_4(true);
						}
						return genum;
					}
					else if (Class4.AMDeviceUnpair(this.intptr_0) == 0 && Class4.AMDevicePair(this.intptr_0) == 0)
					{
						genum = (GEnum3)Class4.AMDeviceStartSession(this.intptr_0);
						if (genum > GEnum3.const_80)
						{
							return genum;
						}
						this.bool_1 = true;
						return genum;
					}
				}
				return genum;
			}
			catch
			{
				genum = GEnum3.const_87;
			}
			return genum;
		}

		// Token: 0x0600010F RID: 271 RVA: 0x0001CA60 File Offset: 0x0001AC60
		private GEnum3 method_5()
		{
			this.bool_1 = false;
			GEnum3 result;
			try
			{
				result = (GEnum3)Class4.AMDeviceStopSession(this.intptr_0);
			}
			catch
			{
				result = GEnum3.const_87;
			}
			return result;
		}

		// Token: 0x06000110 RID: 272 RVA: 0x0001CA9C File Offset: 0x0001AC9C
		private bool method_6(string serviceName, ref int serviceSocket)
		{
			bool result;
			if (serviceSocket <= 0)
			{
				if (!this.bool_0 && this.method_1() > GEnum3.const_80)
				{
					Console.WriteLine("StartService() Connect()");
					result = false;
				}
				else
				{
					bool flag = false;
					if (!this.bool_1)
					{
						GEnum3 genum = this.method_4(false);
						if (genum != GEnum3.const_80)
						{
							return false;
						}
						flag = true;
					}
					bool flag2 = false;
					IntPtr zero = IntPtr.Zero;
					if (Class4.AMDeviceSecureStartService(this.intptr_0, GClass25.smethod_25(serviceName), IntPtr.Zero, ref zero) == 0)
					{
						serviceSocket = Class4.AMDServiceConnectionGetSocket(zero);
						flag2 = true;
					}
					else if (Class4.AMDeviceStartService(this.intptr_0, GClass25.smethod_25(serviceName), ref serviceSocket, IntPtr.Zero) == 0)
					{
						flag2 = true;
					}
					if (flag)
					{
						this.method_5();
					}
					result = flag2;
				}
			}
			else
			{
				result = true;
			}
			return result;
		}

		// Token: 0x06000111 RID: 273 RVA: 0x0001CB64 File Offset: 0x0001AD64
		private bool method_7(ref int socket)
		{
			GEnum3 genum = GEnum3.const_80;
			if (socket > 0)
			{
				try
				{
					genum = (GEnum3)Class4.closesocket(socket);
				}
				catch (Exception)
				{
					return false;
				}
			}
			socket = 0;
			return genum > GEnum3.const_80;
		}

		// Token: 0x06000112 RID: 274 RVA: 0x0001CBA4 File Offset: 0x0001ADA4
		public bool method_8(int sock, IntPtr message)
		{
			bool result;
			if (sock >= 1 && !(message == IntPtr.Zero))
			{
				bool flag = false;
				IntPtr intPtr = GClass25.CFWriteStreamCreateWithAllocatedBuffers(IntPtr.Zero, IntPtr.Zero);
				if (intPtr != IntPtr.Zero)
				{
					if (!GClass25.CFWriteStreamOpen(intPtr))
					{
						return false;
					}
					IntPtr zero = IntPtr.Zero;
					if (GClass25.CFPropertyListWriteToStream(message, intPtr, Enum6.const_0, ref zero) > 0)
					{
						IntPtr kCFStreamPropertyDataWritten = GClass25.kCFStreamPropertyDataWritten;
						IntPtr intPtr2 = GClass25.CFWriteStreamCopyProperty(intPtr, kCFStreamPropertyDataWritten);
						IntPtr buffer = GClass25.CFDataGetBytePtr(intPtr2);
						int num = GClass25.CFDataGetLength(intPtr2);
						uint structure = Class4.htonl((uint)num);
						int num2 = Marshal.SizeOf<uint>(structure);
						if (Class4.send_1(sock, ref structure, num2, 0) == num2)
						{
							if (Class4.send(sock, buffer, num, 0) != num)
							{
								Console.WriteLine("Could not send message.");
							}
							else
							{
								flag = true;
							}
						}
						else
						{
							Console.WriteLine("could not send message size");
						}
						GClass25.CFRelease(intPtr2);
					}
					GClass25.CFWriteStreamClose(intPtr);
				}
				result = flag;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000113 RID: 275 RVA: 0x0001CCA4 File Offset: 0x0001AEA4
		public bool method_9(int sock, object dict)
		{
			IntPtr message = GClass25.smethod_7(RuntimeHelpers.GetObjectValue(dict));
			return this.method_8(sock, message);
		}

		// Token: 0x06000114 RID: 276 RVA: 0x0001CCC8 File Offset: 0x0001AEC8
		public object method_10(int sock)
		{
			object result;
			if (sock < 0)
			{
				result = null;
			}
			else
			{
				uint netlong = 0U;
				uint num = 0U;
				IntPtr intPtr = IntPtr.Zero;
				int num2;
				do
				{
					num2 = Class4.recv_1(sock, ref netlong, 4, 0);
				}
				while (num2 < 0);
				if (num2 != 4)
				{
					result = null;
				}
				else
				{
					uint num3 = Class4.ntohl(netlong);
					if (num3 <= 0U)
					{
						Console.WriteLine("receive size error, dataSize:" + num3.ToString());
						result = null;
					}
					else
					{
						intPtr = Marshal.AllocCoTaskMem((int)num3);
						if (!(intPtr == IntPtr.Zero))
						{
							IntPtr buffer = intPtr;
							while (num < num3)
							{
								num2 = Class4.recv(sock, buffer, (int)(num3 - num), 0);
								if (num2 <= -1)
								{
									Console.WriteLine("Could not receive secure message: " + num2.ToString());
									num = num3 + 1U;
								}
								else
								{
									if (num2 == 0)
									{
										Console.WriteLine("receive size is zero. ");
										IL_FA:
										IntPtr intPtr2 = IntPtr.Zero;
										IntPtr intPtr3 = IntPtr.Zero;
										if (num == num3)
										{
											intPtr2 = GClass25.CFDataCreate(GClass25.intptr_0, intPtr, (int)num3);
											if (intPtr2 == IntPtr.Zero)
											{
												Console.WriteLine("Could not create CFData for message");
											}
											else
											{
												IntPtr zero = IntPtr.Zero;
												intPtr3 = GClass25.CFPropertyListCreateFromXMLData(GClass25.intptr_0, intPtr2, Enum7.const_0, ref zero);
												if (intPtr3 == IntPtr.Zero)
												{
													Console.WriteLine("Could not convert raw xml into a dictionary: " + Convert.ToString(GClass25.smethod_15(ref zero)));
													return null;
												}
											}
										}
										if (intPtr2 != IntPtr.Zero)
										{
											try
											{
												GClass25.CFRelease(intPtr2);
											}
											catch
											{
											}
										}
										if (intPtr != IntPtr.Zero)
										{
											Marshal.FreeCoTaskMem(intPtr);
										}
										object result2 = GClass25.smethod_15(ref intPtr3);
										if (intPtr3 != IntPtr.Zero)
										{
											GClass25.CFRelease(intPtr3);
										}
										return result2;
									}
									buffer = new IntPtr(buffer.ToInt64() + (long)num2);
									num += (uint)num2;
								}
							}
							goto IL_FA;
						}
						Console.WriteLine("Could not allocate message buffer.");
						result = null;
					}
				}
			}
			return result;
		}

		// Token: 0x06000115 RID: 277 RVA: 0x0001CEB8 File Offset: 0x0001B0B8
		public object method_11(GEnum2 key)
		{
			return this.method_12(null, key);
		}

		// Token: 0x06000116 RID: 278 RVA: 0x0001CED0 File Offset: 0x0001B0D0
		public object method_12(string domain, GEnum2 key)
		{
			return this.method_13(domain, key.ToString());
		}

		// Token: 0x06000117 RID: 279 RVA: 0x0001CEF4 File Offset: 0x0001B0F4
		public object method_13(string domain, string key)
		{
			object result = null;
			try
			{
				bool flag = false;
				bool flag2 = false;
				if (!this.bool_0)
				{
					if (this.method_1() > GEnum3.const_80)
					{
						return null;
					}
					flag = true;
				}
				if (!this.bool_1)
				{
					if (this.method_4(false) == GEnum3.const_80)
					{
						flag2 = true;
					}
					else if (flag)
					{
						this.method_2();
					}
				}
				result = Class4.smethod_5(this.intptr_0, domain, key);
				if (flag2)
				{
					this.method_5();
				}
				if (flag)
				{
					this.method_2();
				}
			}
			catch
			{
			}
			return result;
		}

		// Token: 0x06000118 RID: 280 RVA: 0x0001CF88 File Offset: 0x0001B188
		public int method_14()
		{
			try
			{
				string text = Convert.ToString(this.method_12("com.apple.mobile.battery", GEnum2.const_62)) + string.Empty;
				if (text.Length > 0)
				{
					return GClass6.smethod_12(text);
				}
			}
			catch (Exception)
			{
			}
			return -1;
		}

		// Token: 0x06000119 RID: 281 RVA: 0x0001CFE0 File Offset: 0x0001B1E0
		public bool method_15()
		{
			try
			{
				object obj = this.method_12("com.apple.mobile.battery", GEnum2.const_63);
				if (obj != null && obj is bool)
				{
					return Convert.ToBoolean(obj);
				}
			}
			catch
			{
			}
			return false;
		}

		// Token: 0x0600011A RID: 282 RVA: 0x0001D030 File Offset: 0x0001B230
		public Dictionary<object, object> method_16()
		{
			Dictionary<object, object> result;
			try
			{
				object obj = this.method_18();
				if (obj == null)
				{
					result = null;
				}
				else
				{
					Dictionary<object, object> dictionary = obj as Dictionary<object, object>;
					if (dictionary["Status"].ToString() != "Success")
					{
						result = null;
					}
					else
					{
						Dictionary<object, object> dictionary2 = dictionary["Diagnostics"] as Dictionary<object, object>;
						if (dictionary2 == null)
						{
							result = null;
						}
						else
						{
							result = (dictionary2["GasGauge"] as Dictionary<object, object>);
						}
					}
				}
			}
			catch (Exception)
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0600011B RID: 283 RVA: 0x0001D0C0 File Offset: 0x0001B2C0
		public object method_17()
		{
			int sock = 0;
			bool flag;
			Console.WriteLine(flag = this.method_6("com.apple.mobile.diagnostics_relay", ref sock));
			object result;
			if (!flag)
			{
				result = null;
			}
			else
			{
				Dictionary<object, object> dictionary = new Dictionary<object, object>();
				dictionary.Add("Request", "Restart");
				if (this.method_9(sock, dictionary))
				{
					Console.WriteLine("TRUE");
					object obj = this.method_10(sock);
					Console.WriteLine("TRUE");
					Dictionary<object, object> dictionary2 = obj as Dictionary<object, object>;
					Console.WriteLine(dictionary2["Status"].ToString());
					result = obj;
				}
				else
				{
					Console.WriteLine("false");
					result = null;
				}
			}
			return result;
		}

		// Token: 0x0600011C RID: 284 RVA: 0x0001D160 File Offset: 0x0001B360
		public object method_18()
		{
			int sock = 0;
			bool flag;
			Console.WriteLine(flag = this.method_6("com.apple.mobile.diagnostics_relay", ref sock));
			object result;
			if (!flag)
			{
				result = null;
			}
			else
			{
				Dictionary<object, object> dictionary = new Dictionary<object, object>();
				dictionary.Add("Request", "All");
				if (this.method_9(sock, dictionary))
				{
					Console.WriteLine("TRUE");
					object obj = this.method_10(sock);
					Console.WriteLine(obj);
					result = obj;
				}
				else
				{
					Console.WriteLine("false");
					result = null;
				}
			}
			return result;
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x0600011D RID: 285 RVA: 0x0001D1E0 File Offset: 0x0001B3E0
		public string ActivationState
		{
			get
			{
				object obj = this.method_25("ActivationState", null);
				string result;
				if (obj != null)
				{
					result = obj.ToString();
				}
				else
				{
					result = null;
				}
				return result;
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x0600011E RID: 286 RVA: 0x0001D20C File Offset: 0x0001B40C
		public string String_0
		{
			get
			{
				if (this.string_24.Length == 0)
				{
					object obj = this.method_11(GEnum2.const_42);
					if (obj != null)
					{
						this.string_24 = obj.ToString();
					}
				}
				return this.string_24;
			}
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x0600011F RID: 287 RVA: 0x0001D24C File Offset: 0x0001B44C
		public string BasebandStatus
		{
			get
			{
				object obj = this.method_25("BasebandStatus", null);
				string result;
				if (obj != null)
				{
					result = obj.ToString();
				}
				else
				{
					result = null;
				}
				return result;
			}
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x06000120 RID: 288 RVA: 0x0001D278 File Offset: 0x0001B478
		public string String_1
		{
			get
			{
				if (this.string_1.Length == 0)
				{
					object obj = this.method_11(GEnum2.const_3);
					if (obj != null)
					{
						this.string_1 = obj.ToString();
					}
				}
				return this.string_1;
			}
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x06000121 RID: 289 RVA: 0x0001D2B8 File Offset: 0x0001B4B8
		public string String_2
		{
			get
			{
				if (this.string_2.Length == 0)
				{
					object obj = this.method_11(GEnum2.const_7);
					if (obj != null)
					{
						this.string_2 = obj.ToString();
					}
				}
				return this.string_2;
			}
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x06000122 RID: 290 RVA: 0x0001D2F8 File Offset: 0x0001B4F8
		public string String_3
		{
			get
			{
				if (this.string_3.Length == 0)
				{
					object obj = this.method_11(GEnum2.const_9);
					if (obj != null)
					{
						this.string_3 = obj.ToString();
					}
				}
				return this.string_3;
			}
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x06000123 RID: 291 RVA: 0x0001D338 File Offset: 0x0001B538
		public string String_4
		{
			get
			{
				if (this.string_4.Length == 0)
				{
					object obj = this.method_11(GEnum2.const_10);
					if (obj != null)
					{
						this.string_4 = obj.ToString();
					}
				}
				return this.string_4;
			}
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x06000124 RID: 292 RVA: 0x0001D378 File Offset: 0x0001B578
		// (set) Token: 0x06000125 RID: 293 RVA: 0x0001D3BC File Offset: 0x0001B5BC
		public string BuildVersion
		{
			get
			{
				if (this.string_5.Length == 0)
				{
					object obj = this.method_25("BuildVersion", null);
					if (obj != null)
					{
						this.string_5 = obj.ToString();
					}
				}
				return this.string_5;
			}
			set
			{
				this.string_5 = this.BuildVersion;
			}
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x06000126 RID: 294 RVA: 0x0001D3D8 File Offset: 0x0001B5D8
		public string String_5
		{
			get
			{
				if (this.string_6.Length == 0)
				{
					object obj = this.method_11(GEnum2.const_12);
					if (obj != null)
					{
						this.string_6 = obj.ToString();
					}
				}
				return this.string_6;
			}
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x06000127 RID: 295 RVA: 0x0001D418 File Offset: 0x0001B618
		public GEnum1 DeviceColor
		{
			get
			{
				if (this.genum1_0 == GEnum1.const_1)
				{
					string text = this.method_25("DeviceColor", null);
					if (text != null)
					{
						string text2 = text.ToString();
						if (!string.IsNullOrWhiteSpace(text2))
						{
							string text3 = text2.ToLower();
							string text4 = text3;
							uint num = <PrivateImplementationDetails>1.ComputeStringHash(text4);
							if (num <= 1424373031U)
							{
								if (num > 839689206U)
								{
									if (num <= 873244444U)
									{
										if (num != 856466825U)
										{
											if (num != 873244444U)
											{
												goto IL_347;
											}
											if (!(text4 == "1"))
											{
												goto IL_347;
											}
										}
										else
										{
											if (!(text4 == "6"))
											{
												goto IL_347;
											}
											goto IL_2CB;
										}
									}
									else if (num != 906799682U)
									{
										if (num != 923577301U)
										{
											if (num != 1424373031U)
											{
												goto IL_347;
											}
											if (!(text4 == "#e1ccb5"))
											{
												goto IL_347;
											}
											goto IL_330;
										}
										else
										{
											if (!(text4 == "2"))
											{
												goto IL_347;
											}
											goto IL_275;
										}
									}
									else
									{
										if (!(text4 == "3"))
										{
											goto IL_347;
										}
										goto IL_319;
									}
								}
								else if (num <= 631080093U)
								{
									if (num != 292550004U)
									{
										if (num != 631080093U)
										{
											goto IL_347;
										}
										if (!(text4 == "#0a0a0a"))
										{
											goto IL_347;
										}
										goto IL_2E5;
									}
									else
									{
										if (!(text4 == "#3b3b3c"))
										{
											goto IL_347;
										}
										goto IL_2CB;
									}
								}
								else if (num != 806133968U)
								{
									if (num != 822911587U)
									{
										if (num != 839689206U)
										{
											goto IL_347;
										}
										if (!(text4 == "7"))
										{
											goto IL_347;
										}
										goto IL_350;
									}
									else
									{
										if (!(text4 == "4"))
										{
											goto IL_347;
										}
										goto IL_330;
									}
								}
								else
								{
									if (!(text4 == "5"))
									{
										goto IL_347;
									}
									goto IL_2E5;
								}
							}
							else if (num <= 3088844764U)
							{
								if (num <= 1652609262U)
								{
									if (num != 1452231588U)
									{
										if (num != 1652609262U)
										{
											goto IL_347;
										}
										if (!(text4 == "#99989b"))
										{
											goto IL_347;
										}
									}
									else if (!(text4 == "black"))
									{
										goto IL_347;
									}
								}
								else if (num != 2227227460U)
								{
									if (num != 3042244896U)
									{
										if (num != 3088844764U)
										{
											goto IL_347;
										}
										if (!(text4 == "#272728"))
										{
											goto IL_347;
										}
										goto IL_2CB;
									}
									else
									{
										if (!(text4 == "silver"))
										{
											goto IL_347;
										}
										goto IL_275;
									}
								}
								else
								{
									if (text4 == "#d7d9d8")
									{
										goto IL_275;
									}
									goto IL_347;
								}
							}
							else if (num <= 3552793977U)
							{
								if (num != 3208313311U)
								{
									if (num != 3430518549U)
									{
										if (num != 3552793977U)
										{
											goto IL_347;
										}
										if (!(text4 == "#d4c5b3"))
										{
											goto IL_347;
										}
										goto IL_319;
									}
									else
									{
										if (text4 == "space_gray")
										{
											goto IL_2CB;
										}
										goto IL_347;
									}
								}
								else
								{
									if (text4 == "jet black")
									{
										goto IL_2E5;
									}
									goto IL_347;
								}
							}
							else if (num != 3724674918U)
							{
								if (num != 3856023968U)
								{
									if (num != 3966162835U)
									{
										goto IL_347;
									}
									if (text4 == "gold")
									{
										goto IL_319;
									}
									goto IL_347;
								}
								else
								{
									if (text4 == "rose gold")
									{
										goto IL_330;
									}
									goto IL_347;
								}
							}
							else
							{
								if (!(text4 == "white"))
								{
									goto IL_347;
								}
								goto IL_350;
							}
							this.genum1_0 = GEnum1.const_2;
							goto IL_357;
							IL_275:
							this.genum1_0 = GEnum1.const_3;
							goto IL_357;
							IL_2CB:
							this.genum1_0 = GEnum1.const_7;
							goto IL_357;
							IL_2E5:
							this.genum1_0 = GEnum1.const_6;
							goto IL_357;
							IL_319:
							this.genum1_0 = GEnum1.const_4;
							goto IL_357;
							IL_330:
							this.genum1_0 = GEnum1.const_5;
							goto IL_357;
							IL_347:
							this.genum1_0 = GEnum1.Unknown;
							goto IL_357;
							IL_350:
							this.genum1_0 = GEnum1.const_8;
						}
					}
				}
				IL_357:
				return this.genum1_0;
			}
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x06000128 RID: 296 RVA: 0x0001D788 File Offset: 0x0001B988
		// (set) Token: 0x06000129 RID: 297 RVA: 0x0001D7C8 File Offset: 0x0001B9C8
		public string String_6
		{
			get
			{
				if (this.string_9.Length == 0)
				{
					object obj = this.method_11(GEnum2.const_17);
					if (obj != null)
					{
						this.string_9 = obj.ToString();
					}
				}
				return this.string_9;
			}
			set
			{
				this.string_9 = this.String_6;
			}
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x0600012A RID: 298 RVA: 0x0001D7E4 File Offset: 0x0001B9E4
		public string String_7
		{
			get
			{
				if (this.string_10.Length == 0)
				{
					object obj = this.method_11(GEnum2.const_20);
					if (obj != null)
					{
						this.string_10 = obj.ToString();
					}
				}
				return this.string_10;
			}
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x0600012B RID: 299 RVA: 0x0001D824 File Offset: 0x0001BA24
		public string String_8
		{
			get
			{
				if (this.string_11.Length == 0)
				{
					object obj = this.method_11(GEnum2.const_21);
					if (obj != null)
					{
						this.string_11 = obj.ToString();
					}
				}
				return this.string_11;
			}
		}

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x0600012C RID: 300 RVA: 0x0001D864 File Offset: 0x0001BA64
		// (set) Token: 0x0600012D RID: 301 RVA: 0x0001D8A4 File Offset: 0x0001BAA4
		public string String_9
		{
			get
			{
				if (this.string_12.Length == 0)
				{
					object obj = this.method_11(GEnum2.const_33);
					if (obj != null)
					{
						this.string_12 = obj.ToString();
					}
				}
				return this.string_12;
			}
			set
			{
				this.string_12 = this.String_9;
			}
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x0600012E RID: 302 RVA: 0x0001D8C0 File Offset: 0x0001BAC0
		// (set) Token: 0x0600012F RID: 303 RVA: 0x0001D904 File Offset: 0x0001BB04
		public string PhoneNumber
		{
			get
			{
				if (this.string_13.Length == 0)
				{
					object obj = this.method_25("PhoneNumber", null);
					if (obj != null)
					{
						this.string_13 = obj.ToString();
					}
				}
				return this.string_13;
			}
			set
			{
				this.string_13 = this.PhoneNumber;
			}
		}

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x06000130 RID: 304 RVA: 0x0001D920 File Offset: 0x0001BB20
		// (set) Token: 0x06000131 RID: 305 RVA: 0x0001D964 File Offset: 0x0001BB64
		public string MobileEquipmentIdentifier
		{
			get
			{
				if (this.string_23.Length == 0)
				{
					object obj = this.method_25("MobileEquipmentIdentifier", null);
					if (obj != null)
					{
						this.string_23 = obj.ToString();
					}
				}
				return this.string_23;
			}
			set
			{
				this.string_23 = this.MobileEquipmentIdentifier;
			}
		}

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x06000132 RID: 306 RVA: 0x0001D980 File Offset: 0x0001BB80
		// (set) Token: 0x06000133 RID: 307 RVA: 0x0001D9C4 File Offset: 0x0001BBC4
		public string ProductType
		{
			get
			{
				if (this.productType.Length == 0)
				{
					object obj = this.method_25("ProductType", null);
					if (obj != null)
					{
						this.productType = obj.ToString();
					}
				}
				return this.productType;
			}
			set
			{
				this.productType = this.ProductType;
			}
		}

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x06000134 RID: 308 RVA: 0x0001D9E0 File Offset: 0x0001BBE0
		// (set) Token: 0x06000135 RID: 309 RVA: 0x0001E600 File Offset: 0x0001C800
		public string String_10
		{
			get
			{
				if (this.string_22.Length == 0)
				{
					object obj = this.method_11(GEnum2.ProductType);
					if (obj != null)
					{
						this.productType = obj.ToString();
						if (!string.IsNullOrWhiteSpace(this.productType))
						{
							string text = this.productType;
							string text2 = text;
							uint num = <PrivateImplementationDetails>1.ComputeStringHash(text2);
							if (num <= 2031420072U)
							{
								if (num <= 1027150186U)
								{
									if (num > 277956311U)
									{
										if (num <= 960488082U)
										{
											if (num > 876599987U)
											{
												if (num != 926932844U)
												{
													if (num == 960488082U)
													{
														if (text2 == "iPhone9,3")
														{
															this.string_22 = GClass20.string_21;
															goto IL_C09;
														}
													}
												}
												else if (text2 == "iPhone9,1")
												{
													this.string_22 = GClass20.string_19;
													goto IL_C09;
												}
											}
											else if (num != 519927770U)
											{
												if (num == 876599987U)
												{
													if (text2 == "iPhone9,4")
													{
														this.string_22 = GClass20.string_22;
														goto IL_C09;
													}
												}
											}
											else if (text2 == "iPod4,1")
											{
												this.string_22 = GClass20.string_29;
												goto IL_C09;
											}
										}
										else if (num <= 993594948U)
										{
											if (num != 977265701U)
											{
												if (num == 993594948U)
												{
													if (text2 == "iPhone3,3")
													{
														this.string_22 = GClass20.string_5;
														goto IL_C09;
													}
												}
											}
											else if (text2 == "iPhone9,2")
											{
												this.string_22 = GClass20.string_20;
												goto IL_C09;
											}
										}
										else if (num != 1010372567U)
										{
											if (num == 1027150186U)
											{
												if (text2 == "iPhone3,1")
												{
													this.string_22 = GClass20.string_3;
													goto IL_C09;
												}
											}
										}
										else if (text2 == "iPhone3,2")
										{
											this.string_22 = GClass20.string_4;
											goto IL_C09;
										}
									}
									else if (num <= 194068216U)
									{
										if (num != 13713525U)
										{
											if (num != 80824001U)
											{
												if (num == 194068216U)
												{
													if (text2 == "iPhone5,1")
													{
														this.string_22 = GClass20.string_7;
														goto IL_C09;
													}
												}
											}
											else if (text2 == "iPad6,8")
											{
												this.string_22 = GClass20.string_60;
												goto IL_C09;
											}
										}
										else if (text2 == "iPad6,4")
										{
											this.string_22 = GClass20.string_58;
											goto IL_C09;
										}
									}
									else if (num <= 235638739U)
									{
										if (num != 227623454U)
										{
											if (num == 235638739U)
											{
												if (text2 == "iPhone4,1")
												{
													this.string_22 = GClass20.string_6;
													goto IL_C09;
												}
											}
										}
										else if (text2 == "iPhone5,3")
										{
											this.string_22 = GClass20.string_9;
											goto IL_C09;
										}
									}
									else if (num != 244401073U)
									{
										if (num == 277956311U)
										{
											if (text2 == "iPhone5,4")
											{
												this.string_22 = GClass20.string_10;
												goto IL_C09;
											}
										}
									}
									else if (text2 == "iPhone5,2")
									{
										this.string_22 = GClass20.string_8;
										goto IL_C09;
									}
								}
								else if (num > 1605455532U)
								{
									if (num > 1664191389U)
									{
										if (num > 1760014814U)
										{
											if (num != 1886294147U)
											{
												if (num == 2031420072U)
												{
													if (text2 == "iPhone6,2")
													{
														this.string_22 = GClass20.string_12;
														goto IL_C09;
													}
												}
											}
											else if (text2 == "iPod3,1")
											{
												this.string_22 = GClass20.string_28;
												goto IL_C09;
											}
										}
										else if (num != 1743237195U)
										{
											if (num == 1760014814U)
											{
												if (text2 == "iPhone7,1")
												{
													this.string_22 = GClass20.string_13;
													goto IL_C09;
												}
											}
										}
										else if (text2 == "iPhone7,2")
										{
											this.string_22 = GClass20.string_14;
											goto IL_C09;
										}
									}
									else if (num <= 1622233151U)
									{
										if (num != 1613858532U)
										{
											if (num == 1622233151U)
											{
												if (text2 == "iPad3,3")
												{
													this.string_22 = GClass20.string_40;
													goto IL_C09;
												}
											}
										}
										else if (text2 == "iPhone1,1")
										{
											this.string_22 = GClass20.string_0;
											goto IL_C09;
										}
									}
									else if (num != 1655788389U)
									{
										if (num == 1664191389U)
										{
											if (text2 == "iPhone1,2")
											{
												this.string_22 = GClass20.string_1;
												goto IL_C09;
											}
										}
									}
									else if (text2 == "iPad3,1")
									{
										this.string_22 = GClass20.string_38;
										goto IL_C09;
									}
								}
								else if (num <= 1158652399U)
								{
									if (num != 1118200753U)
									{
										if (num != 1134978372U)
										{
											if (num == 1158652399U)
											{
												if (text2 == "iPod7,1")
												{
													this.string_22 = GClass20.string_31;
													goto IL_C09;
												}
											}
										}
										else if (text2 == "iPad5,4")
										{
											this.string_22 = GClass20.string_56;
											goto IL_C09;
										}
									}
									else if (text2 == "iPad5,3")
									{
										this.string_22 = GClass20.string_55;
										goto IL_C09;
									}
								}
								else if (num <= 1571900294U)
								{
									if (num != 1538345056U)
									{
										if (num == 1571900294U)
										{
											if (text2 == "iPad3,4")
											{
												this.string_22 = GClass20.string_44;
												goto IL_C09;
											}
										}
									}
									else if (text2 == "iPad3,6")
									{
										this.string_22 = GClass20.string_46;
										goto IL_C09;
									}
								}
								else if (num != 1588677913U)
								{
									if (num == 1605455532U)
									{
										if (text2 == "iPad3,2")
										{
											this.string_22 = GClass20.string_39;
											goto IL_C09;
										}
									}
								}
								else if (text2 == "iPad3,5")
								{
									this.string_22 = GClass20.string_45;
									goto IL_C09;
								}
							}
							else if (num <= 2989097949U)
							{
								if (num <= 2643280656U)
								{
									if (num > 2270209086U)
									{
										if (num > 2509658711U)
										{
											if (num != 2526436330U)
											{
												if (num == 2643280656U)
												{
													if (text2 == "iPad4,1")
													{
														this.string_22 = GClass20.string_47;
														goto IL_C09;
													}
												}
											}
											else if (text2 == "iPad1,2")
											{
												this.string_22 = GClass20.string_33;
												goto IL_C09;
											}
										}
										else if (num != 2286986705U)
										{
											if (num == 2509658711U)
											{
												if (text2 == "iPad1,1")
												{
													this.string_22 = GClass20.string_32;
													goto IL_C09;
												}
											}
										}
										else if (text2 == "iPhone10,4")
										{
											this.string_22 = GClass20.string_23;
											goto IL_C09;
										}
									}
									else if (num != 2081752929U)
									{
										if (num != 2253431467U)
										{
											if (num == 2270209086U)
											{
												if (text2 == "iPhone10,5")
												{
													this.string_22 = GClass20.string_24;
													goto IL_C09;
												}
											}
										}
										else if (text2 == "iPhone10,6")
										{
											this.string_22 = GClass20.string_25;
											goto IL_C09;
										}
									}
									else if (text2 == "iPhone6,1")
									{
										this.string_22 = GClass20.string_11;
										goto IL_C09;
									}
								}
								else if (num <= 2743946370U)
								{
									if (num <= 2710391132U)
									{
										if (num != 2693613513U)
										{
											if (num == 2710391132U)
											{
												if (text2 == "iPad4,5")
												{
													this.string_22 = GClass20.string_50;
													goto IL_C09;
												}
											}
										}
										else if (text2 == "iPad4,2")
										{
											this.string_22 = GClass20.string_48;
											goto IL_C09;
										}
									}
									else if (num != 2727168751U)
									{
										if (num == 2743946370U)
										{
											if (text2 == "iPad4,7")
											{
												this.string_22 = GClass20.string_52;
												goto IL_C09;
											}
										}
									}
									else if (text2 == "iPad4,4")
									{
										this.string_22 = GClass20.string_49;
										goto IL_C09;
									}
								}
								else if (num <= 2777501608U)
								{
									if (num != 2760723989U)
									{
										if (num == 2777501608U)
										{
											if (text2 == "iPad4,9")
											{
												this.string_22 = GClass20.string_54;
												goto IL_C09;
											}
										}
									}
									else if (text2 == "iPad4,6")
									{
										this.string_22 = GClass20.string_51;
										goto IL_C09;
									}
								}
								else if (num != 2794279227U)
								{
									if (num == 2989097949U)
									{
										if (text2 == "iPod5,1")
										{
											this.string_22 = GClass20.string_30;
											goto IL_C09;
										}
									}
								}
								else if (text2 == "iPad4,8")
								{
									this.string_22 = GClass20.string_53;
									goto IL_C09;
								}
							}
							else if (num <= 3506766125U)
							{
								if (num <= 3446818121U)
								{
									if (num <= 3413262883U)
									{
										if (num != 3396485264U)
										{
											if (num == 3413262883U)
											{
												if (text2 == "iPad2,6")
												{
													this.string_22 = GClass20.string_42;
													goto IL_C09;
												}
											}
										}
										else if (text2 == "iPad2,7")
										{
											this.string_22 = GClass20.string_43;
											goto IL_C09;
										}
									}
									else if (num != 3430040502U)
									{
										if (num == 3446818121U)
										{
											if (text2 == "iPad2,4")
											{
												this.string_22 = GClass20.string_37;
												goto IL_C09;
											}
										}
									}
									else if (text2 == "iPad2,5")
									{
										this.string_22 = GClass20.string_41;
										goto IL_C09;
									}
								}
								else if (num <= 3480373359U)
								{
									if (num != 3463595740U)
									{
										if (num == 3480373359U)
										{
											if (text2 == "iPad2,2")
											{
												this.string_22 = GClass20.string_35;
												goto IL_C09;
											}
										}
									}
									else if (text2 == "iPad2,3")
									{
										this.string_22 = GClass20.string_36;
										goto IL_C09;
									}
								}
								else if (num != 3497150978U)
								{
									if (num == 3506766125U)
									{
										if (text2 == "iPhone2,1")
										{
											this.string_22 = GClass20.string_2;
											goto IL_C09;
										}
									}
								}
								else if (text2 == "iPad2,1")
								{
									this.string_22 = GClass20.string_34;
									goto IL_C09;
								}
							}
							else if (num <= 3696820237U)
							{
								if (num <= 3663264999U)
								{
									if (num != 3579376904U)
									{
										if (num == 3663264999U)
										{
											if (text2 == "iPhone8,1")
											{
												this.string_22 = GClass20.string_15;
												goto IL_C09;
											}
										}
									}
									else if (text2 == "iPhone8,4")
									{
										this.string_22 = GClass20.string_18;
										goto IL_C09;
									}
								}
								else if (num != 3680042618U)
								{
									if (num == 3696820237U)
									{
										if (text2 == "iPhone8,3")
										{
											this.string_22 = GClass20.string_17;
											goto IL_C09;
										}
									}
								}
								else if (text2 == "iPhone8,2")
								{
									this.string_22 = GClass20.string_16;
									goto IL_C09;
								}
							}
							else if (num <= 3981813096U)
							{
								if (num != 3721962577U)
								{
									if (num == 3981813096U)
									{
										if (text2 == "iPod2,1")
										{
											this.string_22 = GClass20.string_27;
											goto IL_C09;
										}
									}
								}
								else if (text2 == "iPod1,1")
								{
									this.string_22 = GClass20.string_26;
									goto IL_C09;
								}
							}
							else if (num != 4191237488U)
							{
								if (num == 4258347964U)
								{
									if (text2 == "iPad6,7")
									{
										this.string_22 = GClass20.string_59;
										goto IL_C09;
									}
								}
							}
							else if (text2 == "iPad6,3")
							{
								this.string_22 = GClass20.string_57;
								goto IL_C09;
							}
							this.string_22 = string.Empty;
							this.genum1_0 = GEnum1.Unknown;
						}
					}
				}
				IL_C09:
				return this.string_22;
			}
			set
			{
				this.string_22 = this.String_10;
			}
		}

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x06000136 RID: 310 RVA: 0x0001E61C File Offset: 0x0001C81C
		// (set) Token: 0x06000137 RID: 311 RVA: 0x0001E658 File Offset: 0x0001C858
		public string IntegratedCircuitCardIdentity
		{
			get
			{
				object obj = this.method_25("IntegratedCircuitCardIdentity", null);
				string empty;
				if (obj != null)
				{
					this.string_14 = obj.ToString();
					empty = this.string_14;
				}
				else
				{
					empty = string.Empty;
				}
				return empty;
			}
			set
			{
				this.string_14 = this.IntegratedCircuitCardIdentity;
			}
		}

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x06000138 RID: 312 RVA: 0x0001E674 File Offset: 0x0001C874
		// (set) Token: 0x06000139 RID: 313 RVA: 0x0001E6B8 File Offset: 0x0001C8B8
		public string InternationalMobileEquipmentIdentity
		{
			get
			{
				if (this.string_15.Length == 0)
				{
					object obj = this.method_25("InternationalMobileEquipmentIdentity", null);
					if (obj != null)
					{
						this.string_15 = obj.ToString();
					}
				}
				return this.string_15;
			}
			set
			{
				this.string_15 = this.InternationalMobileEquipmentIdentity;
			}
		}

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x0600013A RID: 314 RVA: 0x0001E6D4 File Offset: 0x0001C8D4
		// (set) Token: 0x0600013B RID: 315 RVA: 0x0001E718 File Offset: 0x0001C918
		public string InternationalMobileEquipmentIdentity2
		{
			get
			{
				if (this.string_16.Length == 0)
				{
					object obj = this.method_25("InternationalMobileEquipmentIdentity2", null);
					if (obj != null)
					{
						this.string_16 = obj.ToString();
					}
				}
				return this.string_16;
			}
			set
			{
				this.string_16 = this.InternationalMobileEquipmentIdentity2;
			}
		}

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x0600013C RID: 316 RVA: 0x0001E734 File Offset: 0x0001C934
		// (set) Token: 0x0600013D RID: 317 RVA: 0x0001E778 File Offset: 0x0001C978
		public string SerialNumber
		{
			get
			{
				if (this.string_17.Length == 0)
				{
					object obj = this.method_25("SerialNumber", null);
					if (obj != null)
					{
						this.string_17 = obj.ToString();
					}
				}
				return this.string_17;
			}
			set
			{
				this.string_17 = this.SerialNumber;
			}
		}

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x0600013E RID: 318 RVA: 0x0001E794 File Offset: 0x0001C994
		public string SIMStatus
		{
			get
			{
				object obj = this.method_25("SIMStatus", null);
				string result;
				if (obj != null)
				{
					this.string_18 = obj.ToString();
					result = this.string_18;
				}
				else
				{
					result = "";
				}
				return result;
			}
		}

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x0600013F RID: 319 RVA: 0x0001E7D0 File Offset: 0x0001C9D0
		// (set) Token: 0x06000140 RID: 320 RVA: 0x0001E814 File Offset: 0x0001CA14
		public string UniqueDeviceID
		{
			get
			{
				if (this.string_19.Length == 0)
				{
					object obj = this.method_25("UniqueDeviceID", null);
					if (obj != null)
					{
						this.string_19 = obj.ToString();
					}
				}
				return this.string_19;
			}
			set
			{
				Console.WriteLine("uniqueDeviceID: " + this.string_19);
				Console.WriteLine("UniqueDeviceID: " + this.UniqueDeviceID);
				this.string_19 = this.UniqueDeviceID;
			}
		}

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x06000141 RID: 321 RVA: 0x0001E858 File Offset: 0x0001CA58
		public string String_11
		{
			get
			{
				if (this.string_20.Length == 0)
				{
					object obj = this.method_11(GEnum2.const_61);
					if (obj != null)
					{
						this.string_20 = obj.ToString();
					}
				}
				return this.string_20;
			}
		}

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x06000142 RID: 322 RVA: 0x0001E898 File Offset: 0x0001CA98
		// (set) Token: 0x06000143 RID: 323 RVA: 0x0001E8DC File Offset: 0x0001CADC
		public string ProductVersion
		{
			get
			{
				if (string.IsNullOrEmpty(this.string_21))
				{
					this.string_21 = Convert.ToString(this.method_25("ProductVersion", null) + string.Empty);
				}
				return this.string_21;
			}
			set
			{
				this.string_21 = this.ProductVersion;
			}
		}

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x06000144 RID: 324 RVA: 0x0001E8F8 File Offset: 0x0001CAF8
		public float Single_0
		{
			get
			{
				if (string.IsNullOrEmpty(this.string_21))
				{
					this.string_21 = Convert.ToString(this.method_25("ProductVersion", null) + string.Empty);
				}
				float result = 0f;
				string[] array = this.string_21.Split(new char[]
				{
					'.'
				});
				if (array.Length > 1)
				{
					result = float.Parse(array[0] + "." + array[1], CultureInfo.InvariantCulture.NumberFormat);
				}
				else if (array.Length == 1)
				{
					result = float.Parse(array[0] + ".0", CultureInfo.InvariantCulture.NumberFormat);
				}
				return result;
			}
		}

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x06000145 RID: 325 RVA: 0x0001E9A4 File Offset: 0x0001CBA4
		public int Int32_0
		{
			get
			{
				if (this.int_0 == 0)
				{
					this.int_0 = Convert.ToInt32(this.ProductVersion.Replace(".", string.Empty).PadRight(3, '0'));
				}
				return this.int_0;
			}
		}

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x06000146 RID: 326 RVA: 0x0001E9EC File Offset: 0x0001CBEC
		public string String_12
		{
			get
			{
				string result = string.Empty;
				IntPtr intPtr = IntPtr.Zero;
				try
				{
					intPtr = Class4.AMDeviceCopyDeviceIdentifier(this.intptr_0);
				}
				catch (Exception)
				{
				}
				finally
				{
					if (intPtr != IntPtr.Zero)
					{
						result = Convert.ToString(GClass25.smethod_15(ref intPtr));
						GClass25.CFRelease(intPtr);
					}
				}
				return result;
			}
		}

		// Token: 0x06000147 RID: 327 RVA: 0x0001EA58 File Offset: 0x0001CC58
		public GEnum3 method_19()
		{
			this.method_3();
			GEnum3 genum = GEnum3.const_80;
			try
			{
				genum = (GEnum3)Class4.AMDeviceDeactivate(this.intptr_0);
				if (genum == GEnum3.const_80)
				{
					this.bool_0 = true;
				}
			}
			catch (Exception)
			{
			}
			return genum;
		}

		// Token: 0x06000148 RID: 328 RVA: 0x0001EAA0 File Offset: 0x0001CCA0
		public bool method_20(string activationRecord)
		{
			this.method_3();
			IntPtr activationRecord2 = GClass32.smethod_3(this.method_57(activationRecord));
			return Class4.smethod_4(this.intptr_0, activationRecord2);
		}

		// Token: 0x06000149 RID: 329 RVA: 0x0001EAD8 File Offset: 0x0001CCD8
		public bool method_21(string activationRecordString)
		{
			bool result;
			if (!activationRecordString.Contains("AccountToken"))
			{
				result = false;
			}
			else
			{
				byte[] objVal = Convert.FromBase64String("PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0iVVRGLTgiPz4KPCFET0NUWVBFIHBsaXN0IFBVQkxJQyAiLS8vQXBwbGUvL0RURCBQTElTVCAxLjAvL0VOIiAiaHR0cDovL3d3dy5hcHBsZS5jb20vRFREcy9Qcm9wZXJ0eUxpc3QtMS4wLmR0ZCI+CjxwbGlzdCB2ZXJzaW9uPSIxLjAiPgo8ZGljdD4KCTxrZXk+QWN0aXZhdGlvblJlc3BvbnNlSGVhZGVyczwva2V5PgoJPGRpY3Q+CgkJPGtleT5BUlM8L2tleT4KCQk8c3RyaW5nPjQ0aEFYcC9ycnpJRzdwSE54aVBpRGc9PTwvc3RyaW5nPgoJCTxrZXk+Q29ubmVjdGlvbjwva2V5PgoJCTxzdHJpbmc+a2VlcC1hbGl2ZTwvc3RyaW5nPgoJPC9kaWN0Pgo8L2RpY3Q+CjwvcGxpc3Q+");
				IntPtr zero = IntPtr.Zero;
				IntPtr intPtr = GClass25.CFPropertyListCreateFromXMLData(GClass25.intptr_0, GClass25.smethod_7(objVal), Enum7.const_0, ref zero);
				if (intPtr == IntPtr.Zero)
				{
					result = false;
				}
				else
				{
					GClass32 value = GClass32.smethod_2(intPtr);
					IntPtr activationRecord = GClass25.smethod_7(Encoding.Default.GetBytes(activationRecordString));
					this.method_3();
					result = Class4.smethod_3(this.intptr_0, activationRecord, GClass32.smethod_3(value));
				}
			}
			return result;
		}

		// Token: 0x0600014A RID: 330 RVA: 0x0001EB68 File Offset: 0x0001CD68
		public IntPtr method_22(string base64String)
		{
			GClass31 gclass = new GClass31(Convert.FromBase64String(base64String));
			IntPtr zero = IntPtr.Zero;
			IntPtr dictionary = GClass25.CFPropertyListCreateFromXMLData(GClass25.intptr_0, gclass.intptr_0, Enum7.const_0, ref zero);
			GClass32 value = new GClass32(dictionary);
			return GClass32.smethod_3(value);
		}

		// Token: 0x0600014B RID: 331 RVA: 0x0001EBAC File Offset: 0x0001CDAC
		public bool method_23(string activationRecord)
		{
			bool result;
			try
			{
				uint num = 0U;
				PlistHandle plistHandle;
				this.iplistApi_0.plist_from_xml(activationRecord, Convert.ToUInt32(activationRecord.Length), ref plistHandle);
				PlistHandle plistHandle2 = this.iplistApi_0.plist_new_dict();
				this.iplistApi_0.plist_dict_insert_item(plistHandle2, "ARS", this.iplistApi_0.plist_new_string("44hAXp/rrzIG7pHNxiPiDg=="));
				this.iplistApi_0.plist_dict_insert_item(plistHandle2, "Connection", this.iplistApi_0.plist_new_string("keep-alive"));
				string text;
				this.iplistApi_0.plist_to_xml(plistHandle2, ref text, ref num);
				this.method_24();
				MobileactivationClientHandle mobileactivationClientHandle;
				this.imobileactivationApi_0.mobileactivation_client_start_service(this.iDeviceHandle_0, ref mobileactivationClientHandle, this.string_26);
				MobileactivationError mobileactivationError = this.imobileactivationApi_0.mobileactivation_activate_with_session(mobileactivationClientHandle, plistHandle, plistHandle2);
				if (mobileactivationError == 0)
				{
					result = true;
				}
				else
				{
					result = false;
				}
			}
			catch
			{
				result = false;
			}
			return result;
		}

		// Token: 0x0600014C RID: 332 RVA: 0x0001EC90 File Offset: 0x0001CE90
		public void method_24()
		{
			if (this.iDeviceHandle_0 != null || this.lockdownClientHandle_0 != null)
			{
				try
				{
					string value;
					this.ilockdownApi_0.lockdownd_get_device_udid(this.lockdownClientHandle_0, ref value);
					if (this.string_25 != null && !this.string_25.Equals(value))
					{
						throw new Exception("stop");
					}
					return;
				}
				catch
				{
				}
			}
			int num = 0;
			ReadOnlyCollection<string> source;
			this.iiDeviceApi_0.idevice_get_device_list(ref source, ref num);
			if (num > 0)
			{
				this.string_25 = source.First<string>();
				this.iiDeviceApi_0.idevice_new(ref this.iDeviceHandle_0, this.string_25);
				this.ilockdownApi_0.lockdownd_client_new_with_handshake(this.iDeviceHandle_0, ref this.lockdownClientHandle_0, this.string_26);
			}
		}

		// Token: 0x0600014D RID: 333 RVA: 0x0001ED68 File Offset: 0x0001CF68
		public string method_25(string key, string domain = null)
		{
			this.method_24();
			PlistHandle plistHandle;
			this.ilockdownApi_0.lockdownd_get_value(this.lockdownClientHandle_0, domain, key, ref plistHandle);
			string result;
			this.iplistApi_0.plist_get_string_val(plistHandle, ref result);
			return result;
		}

		// Token: 0x0600014E RID: 334 RVA: 0x0001EDA4 File Offset: 0x0001CFA4
		public bool method_26()
		{
			this.method_19();
			if (this.ActivationState != "Unactivated")
			{
				this.method_3();
				this.method_19();
				if (this.ActivationState != "Unactivated")
				{
					this.method_24();
					MobileactivationClientHandle mobileactivationClientHandle;
					this.imobileactivationApi_0.mobileactivation_client_start_service(this.iDeviceHandle_0, ref mobileactivationClientHandle, this.string_26);
					this.imobileactivationApi_0.mobileactivation_deactivate(mobileactivationClientHandle);
					this.ilockdownApi_0.lockdownd_deactivate(this.lockdownClientHandle_0);
					if (this.ActivationState != "Unactivated")
					{
						this.method_24();
						this.imobileactivationApi_0.mobileactivation_deactivate(mobileactivationClientHandle);
						this.ilockdownApi_0.lockdownd_deactivate(this.lockdownClientHandle_0);
						if (this.ActivationState != "Unactivated")
						{
							return false;
						}
					}
				}
			}
			return true;
		}

		// Token: 0x0600014F RID: 335 RVA: 0x0001EE84 File Offset: 0x0001D084
		public bool method_27(byte[] byteArray, string filename)
		{
			this.method_24();
			ulong num = 0UL;
			uint num2 = 0U;
			AfcClientHandle afcClientHandle;
			this.afc.afc_client_start_service(this.iDeviceHandle_0, ref afcClientHandle, "afc");
			this.afc.afc_file_open(afcClientHandle, "/PhotoData/Caches/" + filename, 4, ref num);
			AfcError afcError = this.afc.afc_file_write(afcClientHandle, num, byteArray, (uint)byteArray.Length, ref num2);
			this.afc.afc_file_close(afcClientHandle, num);
			return afcError == 0;
		}

		// Token: 0x06000150 RID: 336 RVA: 0x0001EF0C File Offset: 0x0001D10C
		public bool method_28(string path, string filename)
		{
			this.method_24();
			ulong num = 0UL;
			uint newSize = 0U;
			AfcClientHandle afcClientHandle;
			this.afc.afc_client_start_service(this.iDeviceHandle_0, ref afcClientHandle, "afc");
			byte[] array = new byte[1024000];
			AfcError afcError = this.afc.afc_file_open(afcClientHandle, "/PhotoData/Caches/" + filename, 1, ref num);
			if (afcError == 0)
			{
				AfcError afcError2 = this.afc.afc_file_read(afcClientHandle, num, array, (uint)array.Length, ref newSize);
				this.afc.afc_file_close(afcClientHandle, num);
				if (afcError2 == 0)
				{
					Array.Resize<byte>(ref array, (int)newSize);
					File.WriteAllBytes(path + filename, array);
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000151 RID: 337 RVA: 0x0001EFBC File Offset: 0x0001D1BC
		public string method_29(string commcenter)
		{
			string result;
			try
			{
				uint num = 0U;
				PlistHandle plistHandle;
				this.iplistApi_0.plist_from_bin(commcenter, Convert.ToUInt32(commcenter.Length), ref plistHandle);
				this.iplistApi_0.plist_dict_set_item(plistHandle, "kPostponementTicketLock", this.iplistApi_0.plist_new_uint(0UL));
				this.iplistApi_0.plist_dict_remove_item(plistHandle, "kPostponementTicket");
				string text;
				this.iplistApi_0.plist_to_xml(plistHandle, ref text, ref num);
				result = text;
			}
			catch
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000152 RID: 338 RVA: 0x0001F048 File Offset: 0x0001D248
		public string method_30(string activationXml)
		{
			try
			{
				byte[] bytes = Encoding.Default.GetBytes(activationXml);
				IntPtr zero = IntPtr.Zero;
				IntPtr intPtr = GClass25.CFPropertyListCreateFromXMLData(GClass25.intptr_0, GClass25.smethod_7(bytes), Enum7.const_2, ref zero);
				if (intPtr == IntPtr.Zero)
				{
					return string.Empty;
				}
				IntPtr value = GClass25.CFDictionaryGetValue(intPtr, GClass25.smethod_7("ActivationInfoXML"));
				if (value == IntPtr.Zero)
				{
					return string.Empty;
				}
				byte[] bytes2 = (byte[])GClass25.smethod_15(ref value);
				return Encoding.Default.GetString(bytes2);
			}
			catch
			{
			}
			return string.Empty;
		}

		// Token: 0x06000153 RID: 339 RVA: 0x0001F0F4 File Offset: 0x0001D2F4
		public string method_31(string additional1, string additional2, string ios, string build)
		{
			byte[] objVal = Convert.FromBase64String("PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0iVVRGLTgiPz4KPCFET0NUWVBFIHBsaXN0IFBVQkxJQyAiLS8vQXBwbGUvL0RURCBQTElTVCAxLjAvL0VOIiAiaHR0cDovL3d3dy5hcHBsZS5jb20vRFREcy9Qcm9wZXJ0eUxpc3QtMS4wLmR0ZCI+CjxwbGlzdCB2ZXJzaW9uPSIxLjAiPgo8ZGljdD4KCTxrZXk+VGVzdDwva2V5PgoJPHN0cmluZz50ZXN0PC9zdHJpbmc+CjwvZGljdD4KPC9wbGlzdD4K");
			IntPtr zero = IntPtr.Zero;
			IntPtr intPtr = GClass25.CFPropertyListCreateFromXMLData(GClass25.intptr_0, GClass25.smethod_7(objVal), Enum7.const_2, ref zero);
			GClass25.CFDictionarySetValue(intPtr, GClass25.smethod_7("additional1"), GClass25.smethod_7(additional1));
			GClass25.CFDictionarySetValue(intPtr, GClass25.smethod_7("additional2"), GClass25.smethod_7(additional2));
			if (ios != string.Empty)
			{
				GClass25.CFDictionarySetValue(intPtr, GClass25.smethod_7("ios"), GClass25.smethod_7(ios));
			}
			if (build != string.Empty)
			{
				GClass25.CFDictionarySetValue(intPtr, GClass25.smethod_7("build"), GClass25.smethod_7(build));
			}
			GClass25.CFDictionaryRemoveValue(intPtr, GClass25.smethod_7("Test"));
			return GClass25.smethod_3(intPtr);
		}

		// Token: 0x06000154 RID: 340 RVA: 0x0001F1B8 File Offset: 0x0001D3B8
		public string method_32(byte[] commcenterData, string wildcard)
		{
			try
			{
				byte[] objVal = Convert.FromBase64String("PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0iVVRGLTgiPz4KPCFET0NUWVBFIHBsaXN0IFBVQkxJQyAiLS8vQXBwbGUvL0RURCBQTElTVCAxLjAvL0VOIiAiaHR0cDovL3d3dy5hcHBsZS5jb20vRFREcy9Qcm9wZXJ0eUxpc3QtMS4wLmR0ZCI+CjxwbGlzdCB2ZXJzaW9uPSIxLjAiPgo8ZGljdD4KCTxrZXk+QWN0aXZhdGlvblN0YXRlPC9rZXk+Cgk8c3RyaW5nPkFjdGl2YXRlZDwvc3RyaW5nPgoJPGtleT5BY3Rpdml0eVVSTDwva2V5PgoJPHN0cmluZz5odHRwczovL2FsYmVydC5hcHBsZS5jb20vZGV2aWNlc2VydmljZXMvYWN0aXZpdHk8L3N0cmluZz4KCTxrZXk+UGhvbmVOdW1iZXJOb3RpZmljYXRpb25VUkw8L2tleT4KCTxzdHJpbmc+aHR0cHM6Ly9hbGJlcnQuYXBwbGUuY29tL2RldmljZXNlcnZpY2VzL3Bob25lSG9tZTwvc3RyaW5nPgo8L2RpY3Q+CjwvcGxpc3Q+Cg==");
				IntPtr zero = IntPtr.Zero;
				IntPtr intPtr = GClass25.CFPropertyListCreateFromXMLData(GClass25.intptr_0, GClass25.smethod_7(objVal), Enum7.const_2, ref zero);
				GClass25.CFDictionarySetValue(intPtr, GClass25.smethod_7("ActivationTicket"), GClass25.smethod_7(wildcard));
				IntPtr intPtr2 = GClass25.CFPropertyListCreateFromXMLData(GClass25.intptr_0, GClass25.smethod_7(commcenterData), Enum7.const_2, ref zero);
				if (intPtr2 == IntPtr.Zero)
				{
					return null;
				}
				GClass25.CFDictionarySetValue(intPtr2, GClass25.smethod_7("kPostponementTicketLock"), GClass25.kCFBooleanTrue);
				GClass25.CFDictionarySetValue(intPtr2, GClass25.smethod_7("kPostponementTicket"), intPtr);
				return GClass25.smethod_3(intPtr2);
			}
			catch
			{
			}
			return null;
		}

		// Token: 0x06000155 RID: 341 RVA: 0x0001F274 File Offset: 0x0001D474
		public string method_33(string activationRecord)
		{
			try
			{
				byte[] bytes = Encoding.Default.GetBytes(activationRecord);
				IntPtr zero = IntPtr.Zero;
				IntPtr intPtr = GClass25.CFPropertyListCreateFromXMLData(GClass25.intptr_0, GClass25.smethod_7(bytes), Enum7.const_0, ref zero);
				if (intPtr == IntPtr.Zero)
				{
					return null;
				}
				IntPtr value = GClass25.CFDictionaryGetValue(intPtr, GClass25.smethod_7("AccountToken"));
				if (value == IntPtr.Zero)
				{
					return null;
				}
				byte[] bytes2 = (byte[])GClass25.smethod_15(ref value);
				string @string = Encoding.Default.GetString(bytes2);
				return @string.Replace("\n", "").Replace("\r", "").Replace("\t", "").Replace(" = ", ": ").Replace(";}", "}").Replace(";", ", ");
			}
			catch
			{
			}
			return null;
		}

		// Token: 0x06000156 RID: 342 RVA: 0x0001F37C File Offset: 0x0001D57C
		public string method_34(string activationRecord)
		{
			try
			{
				byte[] bytes = Encoding.Default.GetBytes(activationRecord);
				IntPtr zero = IntPtr.Zero;
				IntPtr intPtr = GClass25.CFPropertyListCreateFromXMLData(GClass25.intptr_0, GClass25.smethod_7(bytes), Enum7.const_0, ref zero);
				if (intPtr == IntPtr.Zero)
				{
					return null;
				}
				IntPtr intPtr2 = GClass25.CFDictionaryGetValue(intPtr, GClass25.smethod_7("ActivationRecord"));
				GClass25.CFDictionaryRemoveValue(intPtr2, GClass25.smethod_7("UniqueDeviceCertificate"));
				if (GClass14.string_2.Equals("+mw7/apTJ95Sj069kywAVg=="))
				{
					GClass25.CFDictionaryRemoveValue(intPtr2, GClass25.smethod_7("unbrick"));
				}
				return GClass25.smethod_3(intPtr2);
			}
			catch
			{
			}
			return null;
		}

		// Token: 0x06000157 RID: 343 RVA: 0x0001F42C File Offset: 0x0001D62C
		public void method_35()
		{
			Class4.smethod_7(this.intptr_0, "com.apple.purplebuddy", "ForceNoBuddy", true);
			Class4.smethod_7(this.intptr_0, "com.apple.purplebuddy", "SetupDone", true);
			Class4.smethod_7(this.intptr_0, "com.apple.purplebuddy", "SetupFinishedAllSteps", true);
			Class4.smethod_7(this.intptr_0, "com.apple.purplebuddy", "SetupState", "SetupUsingiTunes");
			Class4.smethod_7(this.intptr_0, "com.apple.PurpleBuddy", "ForceNoBuddy", true);
			Class4.smethod_7(this.intptr_0, "com.apple.PurpleBuddy", "SetupDone", true);
			Class4.smethod_7(this.intptr_0, "com.apple.PurpleBuddy", "SetupFinishedAllSteps", true);
			Class4.smethod_7(this.intptr_0, "com.apple.PurpleBuddy", "SetupState", "SetupUsingiTunes");
			Class4.smethod_7(this.intptr_0, "com.apple.mobile.lockdown_cache", "ActivationState", "FactoryActivated");
			Class4.smethod_7(this.intptr_0, "com.apple.mobile.iTunes", "iTunesSetupComplete", true);
		}

		// Token: 0x06000158 RID: 344 RVA: 0x0001F550 File Offset: 0x0001D750
		public static uint smethod_0(uint value)
		{
			byte[] bytes = BitConverter.GetBytes(value);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(bytes);
			}
			return BitConverter.ToUInt32(bytes, 0);
		}

		// Token: 0x06000159 RID: 345 RVA: 0x0001F57C File Offset: 0x0001D77C
		public Array method_36(IntPtr handle)
		{
			IntPtr zero = IntPtr.Zero;
			Class4.AMDServiceConnectionReceiveMessage(handle, ref zero, IntPtr.Zero);
			GClass32.smethod_2(zero);
			return (Array)GClass25.smethod_15(ref zero);
		}

		// Token: 0x0600015A RID: 346 RVA: 0x0001F5B4 File Offset: 0x0001D7B4
		public IntPtr method_37(IntPtr handle)
		{
			IntPtr zero = IntPtr.Zero;
			Class4.AMDServiceConnectionReceiveMessage(handle, ref zero, IntPtr.Zero);
			return zero;
		}

		// Token: 0x0600015B RID: 347 RVA: 0x0001F5D8 File Offset: 0x0001D7D8
		public void method_38(IntPtr handle, IntPtr cfData)
		{
			int num = GClass25.CFDataGetLength(cfData);
			IntPtr buffer = GClass25.CFDataGetBytePtr(cfData);
			uint structure = Class4.htonl((uint)num);
			int bufferlen = Marshal.SizeOf<uint>(structure);
			Class4.AMDServiceConnectionSend_1(handle, ref structure, bufferlen);
			Class4.AMDServiceConnectionSend(handle, buffer, num);
		}

		// Token: 0x0600015C RID: 348 RVA: 0x0001F614 File Offset: 0x0001D814
		public void method_39(IntPtr handle, IntPtr cfData)
		{
			IntPtr buffer = GClass25.CFDataGetBytePtr(cfData);
			int bufferlen = GClass25.CFDataGetLength(cfData);
			Class4.AMDServiceConnectionSend(handle, buffer, bufferlen);
		}

		// Token: 0x0600015D RID: 349 RVA: 0x0001F638 File Offset: 0x0001D838
		public void method_40(IntPtr handle, List<object> data)
		{
			IntPtr list = GClass25.smethod_7(RuntimeHelpers.GetObjectValue(data));
			IntPtr zero = IntPtr.Zero;
			this.method_38(handle, GClass25.CFPropertyListCreateData(GClass25.intptr_0, list, Enum6.const_0, Enum7.const_0, ref zero));
		}

		// Token: 0x0600015E RID: 350 RVA: 0x0001F674 File Offset: 0x0001D874
		public void method_41(IntPtr handle, string path, byte[] file)
		{
			this.method_43(handle, path, file);
			this.method_44(handle);
		}

		// Token: 0x0600015F RID: 351 RVA: 0x0001F694 File Offset: 0x0001D894
		public void method_42(IntPtr handle, Array paths, Array files)
		{
			if (paths.Length == files.Length)
			{
				for (int i = 0; i < paths.Length; i++)
				{
					this.method_43(handle, (string)paths.GetValue(i), (byte[])files.GetValue(i));
				}
			}
			this.method_44(handle);
		}

		// Token: 0x06000160 RID: 352 RVA: 0x0001F6EC File Offset: 0x0001D8EC
		public void method_43(IntPtr handle, string path, byte[] file)
		{
			IntPtr cfString = GClass25.smethod_7(path);
			IntPtr cfData = GClass25.CFStringCreateExternalRepresentation(GClass25.intptr_0, cfString, (GEnum6)134217984, 0U);
			this.method_38(handle, cfData);
			byte[] array = new byte[file.Length + 1];
			array[0] = 12;
			Array.Copy(file, 0, array, 1, file.Length);
			IntPtr cfData2 = GClass25.smethod_7(array);
			this.method_38(handle, cfData2);
			byte[] objVal = new byte[1];
			IntPtr cfData3 = GClass25.smethod_7(objVal);
			this.method_38(handle, cfData3);
		}

		// Token: 0x06000161 RID: 353 RVA: 0x0001F760 File Offset: 0x0001D960
		public void method_44(IntPtr handle)
		{
			byte[] bytes = BitConverter.GetBytes(0U);
			IntPtr cfData = GClass25.smethod_7(bytes);
			this.method_39(handle, cfData);
			this.method_40(handle, new List<object>
			{
				"DLMessageStatusResponse",
				0,
				"___EmptyParameterString___",
				new Dictionary<object, object>()
			});
		}

		// Token: 0x06000162 RID: 354 RVA: 0x0001F7BC File Offset: 0x0001D9BC
		public bool method_45(ref string error)
		{
			bool result;
			try
			{
				IntPtr zero = IntPtr.Zero;
				if (Class4.AMDeviceSecureStartService(this.intptr_0, GClass25.smethod_25("com.apple.mobilebackup2"), IntPtr.Zero, ref zero) != 0)
				{
					error = "bypassError1";
					result = false;
				}
				else
				{
					this.method_36(zero);
					this.method_40(zero, new List<object>
					{
						"DLMessageVersionExchange",
						"DLVersionsOk",
						400
					});
					this.method_36(zero);
					this.method_40(zero, new List<object>
					{
						"DLMessageProcessMessage",
						new Dictionary<object, object>
						{
							{
								"MessageName",
								"Hello"
							},
							{
								"SupportedProtocolVersions",
								new List<object>
								{
									2.1
								}
							}
						}
					});
					this.method_36(zero);
					this.method_40(zero, new List<object>
					{
						"DLMessageProcessMessage",
						new Dictionary<object, object>
						{
							{
								"MessageName",
								"Restore"
							},
							{
								"TargetIdentifier",
								this.UniqueDeviceID
							},
							{
								"SourceIdentifier",
								"aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"
							},
							{
								"Options",
								new Dictionary<object, object>
								{
									{
										"RemoveItemsNotRestored",
										false
									},
									{
										"RestorePreserveSettings",
										true
									},
									{
										"RestoreShouldReboot",
										false
									},
									{
										"RestoreDontCopyBackup",
										true
									},
									{
										"RestoreSystemFiles",
										true
									},
									{
										"Password",
										"06fb5141d81097577cf4b76ffb9e2c2825b210df"
									}
								}
							}
						}
					});
					IntPtr intPtr = this.method_37(zero);
					if (!GClass25.smethod_3(intPtr).ToString().Contains("Status"))
					{
						this.method_40(zero, new List<object>
						{
							"DLMessageDisconnect"
						});
						error = "bypassError2";
						result = false;
					}
					else
					{
						GClass32.smethod_2(intPtr);
						Array array = (Array)GClass25.smethod_15(ref intPtr);
						if (array.Length > 1)
						{
							Array array2 = (Array)array.GetValue(1);
							if (array2.Length > 0)
							{
								string path = (string)array2.GetValue(0);
								this.method_41(zero, path, (byte[])this.object_0[1]);
								array = this.method_36(zero);
								if (array.Length > 1)
								{
									array2 = (Array)array.GetValue(1);
									if (array2.Length > 0)
									{
										string path2 = (string)array2.GetValue(0);
										this.method_41(zero, path2, (byte[])this.object_0[2]);
										array = this.method_36(zero);
										if (array.Length > 1)
										{
											array2 = (Array)array.GetValue(1);
											if (array2.Length > 0)
											{
												string path3 = (string)array2.GetValue(0);
												this.method_41(zero, path3, (byte[])this.object_0[4]);
												array = this.method_36(zero);
												if (array.Length > 1)
												{
													array2 = (Array)array.GetValue(1);
													if (array2.Length > 0)
													{
														string path4 = (string)array2.GetValue(0);
														this.method_41(zero, path4, (byte[])this.object_0[0]);
														array = this.method_36(zero);
														if (array.Length > 1)
														{
															array2 = (Array)array.GetValue(1);
															if (array2.Length == 1)
															{
																array2 = (Array)array.GetValue(1);
																List<object> list = new List<object>();
																foreach (object obj in array2)
																{
																	if (obj.ToString().Contains("876a63abe36aefe5888afe97a3d3fa5ff4786031"))
																	{
																		list.Add((byte[])this.object_0[3]);
																	}
																}
																this.method_42(zero, array2, list.ToArray());
																array = this.method_36(zero);
																this.method_40(zero, new List<object>
																{
																	"DLMessageProcessMessage",
																	new Dictionary<object, object>
																	{
																		{
																			"OldPassword",
																			"06fb5141d81097577cf4b76ffb9e2c2825b210df"
																		},
																		{
																			"TargetIdentifier",
																			this.UniqueDeviceID
																		},
																		{
																			"MessageName",
																			"ChangePassword"
																		}
																	}
																});
																this.method_36(zero);
																this.method_40(zero, new List<object>
																{
																	"DLMessageDisconnect"
																});
																if (array.GetValue(1) is Dictionary<object, object>)
																{
																	Dictionary<object, object> dictionary = (Dictionary<object, object>)array.GetValue(1);
																	if (dictionary.ContainsKey("ErrorCode") && Convert.ToInt32(dictionary["ErrorCode"]) == 0)
																	{
																		return true;
																	}
																}
																error = "bypassError7";
																result = false;
															}
															else
															{
																error = "bypassError6";
																result = false;
															}
														}
														else
														{
															error = "bypassError6";
															result = false;
														}
													}
													else
													{
														error = "bypassError5";
														result = false;
													}
												}
												else
												{
													error = "bypassError5";
													result = false;
												}
											}
											else
											{
												error = "bypassError4";
												result = false;
											}
										}
										else
										{
											error = "bypassError4";
											result = false;
										}
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
							}
							else
							{
								error = "bypassError3";
								result = false;
							}
						}
						else
						{
							error = "bypassError3";
							result = false;
						}
					}
				}
			}
			catch (Exception ex)
			{
				error = ex.Message;
				result = false;
			}
			return result;
		}

		// Token: 0x06000163 RID: 355 RVA: 0x0001FD40 File Offset: 0x0001DF40
		public bool method_46(string arg, ref string error)
		{
			bool result;
			try
			{
				IntPtr zero = IntPtr.Zero;
				if (Class4.AMDeviceSecureStartService(this.intptr_0, GClass25.smethod_25("com.apple.mobilebackup2"), IntPtr.Zero, ref zero) != 0)
				{
					error = "bypassError1";
					result = false;
				}
				else
				{
					this.method_36(zero);
					this.method_40(zero, new List<object>
					{
						"DLMessageVersionExchange",
						"DLVersionsOk",
						400
					});
					this.method_36(zero);
					this.method_40(zero, new List<object>
					{
						"DLMessageProcessMessage",
						new Dictionary<object, object>
						{
							{
								"MessageName",
								"Hello"
							},
							{
								"SupportedProtocolVersions",
								new List<object>
								{
									2.1
								}
							}
						}
					});
					this.method_36(zero);
					this.method_40(zero, new List<object>
					{
						"DLMessageProcessMessage",
						new Dictionary<object, object>
						{
							{
								"MessageName",
								"Restore"
							},
							{
								"TargetIdentifier",
								this.UniqueDeviceID
							},
							{
								"SourceIdentifier",
								"aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"
							},
							{
								"Options",
								new Dictionary<object, object>
								{
									{
										"RemoveItemsNotRestored",
										false
									},
									{
										"RestorePreserveSettings",
										true
									},
									{
										"RestoreShouldReboot",
										false
									},
									{
										"RestoreDontCopyBackup",
										true
									},
									{
										"RestoreSystemFiles",
										true
									},
									{
										"Password",
										arg
									}
								}
							}
						}
					});
					IntPtr intPtr = this.method_37(zero);
					if (!GClass25.smethod_3(intPtr).ToString().Contains("Status"))
					{
						this.method_40(zero, new List<object>
						{
							"DLMessageDisconnect"
						});
						error = "bypassError2";
						result = false;
					}
					else
					{
						GClass32.smethod_2(intPtr);
						Array array = (Array)GClass25.smethod_15(ref intPtr);
						if (array.Length > 1)
						{
							Array array2 = (Array)array.GetValue(1);
							if (array2.Length > 0)
							{
								string path = (string)array2.GetValue(0);
								this.method_41(zero, path, (byte[])this.object_0[1]);
								array = this.method_36(zero);
								if (array.Length > 1)
								{
									array2 = (Array)array.GetValue(1);
									if (array2.Length > 0)
									{
										string path2 = (string)array2.GetValue(0);
										this.method_41(zero, path2, (byte[])this.object_0[2]);
										array = this.method_36(zero);
										if (array.Length > 1)
										{
											array2 = (Array)array.GetValue(1);
											if (array2.Length > 0)
											{
												string path3 = (string)array2.GetValue(0);
												this.method_41(zero, path3, (byte[])this.object_0[4]);
												array = this.method_36(zero);
												if (array.Length > 1)
												{
													array2 = (Array)array.GetValue(1);
													if (array2.Length > 0)
													{
														string path4 = (string)array2.GetValue(0);
														this.method_41(zero, path4, (byte[])this.object_0[0]);
														array = this.method_36(zero);
														if (array.Length > 1)
														{
															array2 = (Array)array.GetValue(1);
															if (array2.Length > 5)
															{
																array2 = (Array)array.GetValue(1);
																List<object> list = new List<object>();
																foreach (object obj in array2)
																{
																	if (obj.ToString().Contains("212c1cd59644e9dbc48d449e5ac68427b4da1cb9"))
																	{
																		list.Add((byte[])this.object_0[3]);
																	}
																	else if (obj.ToString().Contains("3b7fe9a5cf26109e124c4f9a1f74c9031ec26565"))
																	{
																		list.Add((byte[])this.object_0[3]);
																	}
																	else if (obj.ToString().Contains("896cbb8a7992148c2e510ae551c3008d060e62bb"))
																	{
																		list.Add((byte[])this.object_0[9]);
																	}
																	else if (obj.ToString().Contains("9acd000f9ce06e6a355e9720f1fcc590aecc2841"))
																	{
																		list.Add((byte[])this.object_0[9]);
																	}
																	else if (obj.ToString().Contains("51a4616e576dd33cd2abadfea874eb8ff246bf0e"))
																	{
																		list.Add((byte[])this.object_0[11]);
																	}
																	else if (obj.ToString().Contains("876a63abe36aefe5888afe97a3d3fa5ff4786031"))
																	{
																		list.Add((byte[])this.object_0[5]);
																	}
																	else if (obj.ToString().Contains("80fa782261261e54bb73c0253e5b6beefb6a2f39"))
																	{
																		list.Add((byte[])this.object_0[6]);
																	}
																	else if (obj.ToString().Contains("7e29f29b6cb8e63e70bccf5a3500b7ed26513228"))
																	{
																		list.Add((byte[])this.object_0[7]);
																	}
																	else if (obj.ToString().Contains("bb04a41ddaa7ac9165f6b5f629710c6f5c5f2f7a"))
																	{
																		list.Add((byte[])this.object_0[10]);
																	}
																	else if (obj.ToString().Contains("e3acdfe009186f7d3f2b1395b12e163e27bd7bf9"))
																	{
																		list.Add((byte[])this.object_0[8]);
																	}
																}
																this.method_42(zero, array2, list.ToArray());
																array = this.method_36(zero);
																this.method_40(zero, new List<object>
																{
																	"DLMessageProcessMessage",
																	new Dictionary<object, object>
																	{
																		{
																			"OldPassword",
																			arg
																		},
																		{
																			"TargetIdentifier",
																			this.UniqueDeviceID
																		},
																		{
																			"MessageName",
																			"ChangePassword"
																		}
																	}
																});
																this.method_36(zero);
																this.method_40(zero, new List<object>
																{
																	"DLMessageDisconnect"
																});
																if (array.GetValue(1) is Dictionary<object, object>)
																{
																	Dictionary<object, object> dictionary = (Dictionary<object, object>)array.GetValue(1);
																	if (dictionary.ContainsKey("ErrorCode") && Convert.ToInt32(dictionary["ErrorCode"]) == 0)
																	{
																		return true;
																	}
																}
																error = "bypassError7";
																result = false;
															}
															else
															{
																error = "bypassError6";
																result = false;
															}
														}
														else
														{
															error = "bypassError6";
															result = false;
														}
													}
													else
													{
														error = "bypassError5";
														result = false;
													}
												}
												else
												{
													error = "bypassError5";
													result = false;
												}
											}
											else
											{
												error = "bypassError4";
												result = false;
											}
										}
										else
										{
											error = "bypassError4";
											result = false;
										}
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
							}
							else
							{
								error = "bypassError3";
								result = false;
							}
						}
						else
						{
							error = "bypassError3";
							result = false;
						}
					}
				}
			}
			catch (Exception ex)
			{
				error = ex.Message;
				result = false;
			}
			return result;
		}

		// Token: 0x06000164 RID: 356 RVA: 0x0002044C File Offset: 0x0001E64C
		public Dictionary<object, object> method_47()
		{
			byte[] objVal = Convert.FromBase64String("PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0iVVRGLTgiPz4KPCFET0NUWVBFIHBsaXN0IFBVQkxJQyAiLS8vQXBwbGUvL0RURCBQTElTVCAxLjAvL0VOIiAiaHR0cDovL3d3dy5hcHBsZS5jb20vRFREcy9Qcm9wZXJ0eUxpc3QtMS4wLmR0ZCI+CjxwbGlzdCB2ZXJzaW9uPSIxLjAiPgo8ZGljdD4KICAgIDxrZXk+Q29tbWFuZDwva2V5PgogICAgPHN0cmluZz5Ccm93c2U8L3N0cmluZz4KICAgIDxrZXk+Q2xpZW50T3B0aW9uczwva2V5PgogICAgPGRpY3Q+CiAgICAgICAgPGtleT5BcHBsaWNhdGlvblR5cGU8L2tleT4KICAgICAgICA8c3RyaW5nPkFueTwvc3RyaW5nPgogICAgPC9kaWN0Pgo8L2RpY3Q+CjwvcGxpc3Q+Cg==");
			IntPtr zero = IntPtr.Zero;
			IntPtr intPtr = GClass25.CFPropertyListCreateFromXMLData(GClass25.intptr_0, GClass25.smethod_7(objVal), Enum7.const_0, ref zero);
			Dictionary<object, object> result;
			if (intPtr == IntPtr.Zero)
			{
				result = null;
			}
			else
			{
				GClass32 value = GClass32.smethod_2(intPtr);
				IntPtr zero2 = IntPtr.Zero;
				this.method_3();
				if (Class4.AMDeviceLookupApplications(this.intptr_0, GClass32.smethod_3(value), ref zero2) != 0)
				{
					result = null;
				}
				else
				{
					try
					{
						result = (Dictionary<object, object>)GClass25.smethod_15(ref zero2);
					}
					catch
					{
						result = null;
					}
				}
			}
			return result;
		}

		// Token: 0x06000165 RID: 357 RVA: 0x000204EC File Offset: 0x0001E6EC
		public string method_48()
		{
			IntPtr zero = IntPtr.Zero;
			string result;
			if (Class4.AMDeviceSecureStartService(this.intptr_0, GClass25.smethod_25("com.apple.mobile.MCInstall"), IntPtr.Zero, ref zero) != 0)
			{
				result = null;
			}
			else
			{
				Dictionary<object, object> obj = new Dictionary<object, object>
				{
					{
						"RequestType",
						"GetCloudConfiguration"
					}
				};
				IntPtr list = GClass25.smethod_7(RuntimeHelpers.GetObjectValue(obj));
				IntPtr zero2 = IntPtr.Zero;
				this.method_38(zero, GClass25.CFPropertyListCreateData(GClass25.intptr_0, list, Enum6.const_0, Enum7.const_0, ref zero2));
				IntPtr intPtr = this.method_37(zero);
				string text = GClass25.smethod_3(intPtr).ToString();
				if (text.Contains("CloudConfiguration") && text.Contains("CacheData"))
				{
					IntPtr propertyList = GClass25.CFDictionaryGetValue(intPtr, GClass25.smethod_7("CloudConfiguration"));
					string text2 = GClass25.smethod_3(propertyList).ToString();
					result = text2;
				}
				else
				{
					result = null;
				}
			}
			return result;
		}

		// Token: 0x06000166 RID: 358 RVA: 0x00017E98 File Offset: 0x00016098
		public void method_49()
		{
		}

		// Token: 0x06000167 RID: 359 RVA: 0x000205CC File Offset: 0x0001E7CC
		public string method_50()
		{
			PlistHandle plistHandle = null;
			uint num = 0U;
			string result = null;
			this.method_24();
			this.ilockdownApi_0.lockdownd_start_service(this.lockdownClientHandle_0, this.string_27, ref this.lockdownServiceDescriptorHandle_0);
			MobileactivationClientHandle mobileactivationClientHandle;
			this.imobileactivationApi_0.mobileactivation_client_new(this.iDeviceHandle_0, this.lockdownServiceDescriptorHandle_0, ref mobileactivationClientHandle);
			this.imobileactivationApi_0.mobileactivation_client_start_service(this.iDeviceHandle_0, ref mobileactivationClientHandle, this.string_26);
			this.imobileactivationApi_0.mobileactivation_create_activation_session_info(mobileactivationClientHandle, ref plistHandle);
			this.iplistApi_0.plist_to_xml(plistHandle, ref result, ref num);
			return result;
		}

		// Token: 0x06000168 RID: 360 RVA: 0x00020660 File Offset: 0x0001E860
		public string method_51()
		{
			PlistHandle plistHandle = null;
			PlistHandle plistHandle2 = null;
			string result = null;
			iDeviceActivationRequestHandle iDeviceActivationRequestHandle = null;
			iDeviceActivationResponseHandle iDeviceActivationResponseHandle = null;
			uint num = 0U;
			this.method_24();
			this.ilockdownApi_0.lockdownd_start_service(this.lockdownClientHandle_0, this.string_27, ref this.lockdownServiceDescriptorHandle_0);
			MobileactivationClientHandle mobileactivationClientHandle;
			this.imobileactivationApi_0.mobileactivation_client_new(this.iDeviceHandle_0, this.lockdownServiceDescriptorHandle_0, ref mobileactivationClientHandle);
			this.imobileactivationApi_0.mobileactivation_client_start_service(this.iDeviceHandle_0, ref mobileactivationClientHandle, this.string_26);
			this.imobileactivationApi_0.mobileactivation_create_activation_session_info(mobileactivationClientHandle, ref plistHandle);
			this.iiDeviceActivationApi_0.idevice_activation_drm_handshake_request_new(1, ref iDeviceActivationRequestHandle);
			this.iiDeviceActivationApi_0.idevice_activation_request_set_fields(iDeviceActivationRequestHandle, plistHandle);
			this.iiDeviceActivationApi_0.idevice_activation_send_request(iDeviceActivationRequestHandle, ref iDeviceActivationResponseHandle);
			this.iiDeviceActivationApi_0.idevice_activation_response_get_fields(iDeviceActivationResponseHandle, ref plistHandle2);
			this.iplistApi_0.plist_to_xml(plistHandle2, ref result, ref num);
			return result;
		}

		// Token: 0x06000169 RID: 361 RVA: 0x00020738 File Offset: 0x0001E938
		public string method_52(string blob)
		{
			this.method_24();
			string text = null;
			PlistHandle plistHandle = null;
			uint num = Convert.ToUInt32(blob.Length);
			PlistHandle plistHandle2 = null;
			uint num2 = 0U;
			this.ilockdownApi_0.lockdownd_start_service(this.lockdownClientHandle_0, this.string_27, ref this.lockdownServiceDescriptorHandle_0);
			MobileactivationClientHandle mobileactivationClientHandle;
			this.imobileactivationApi_0.mobileactivation_client_new(this.iDeviceHandle_0, this.lockdownServiceDescriptorHandle_0, ref mobileactivationClientHandle);
			this.imobileactivationApi_0.mobileactivation_client_start_service(this.iDeviceHandle_0, ref mobileactivationClientHandle, this.string_26);
			this.iplistApi_0.plist_from_xml(blob, num, ref plistHandle);
			this.imobileactivationApi_0.mobileactivation_create_activation_info_with_session(mobileactivationClientHandle, plistHandle, ref plistHandle2);
			this.iplistApi_0.plist_to_xml(plistHandle2, ref text, ref num2);
			string result;
			if (text.Contains("ActivationInfoXML"))
			{
				result = text;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0600016A RID: 362 RVA: 0x000207FC File Offset: 0x0001E9FC
		public string method_53()
		{
			string text = null;
			PlistHandle plistHandle = null;
			uint num = 0U;
			this.method_24();
			this.ilockdownApi_0.lockdownd_start_service(this.lockdownClientHandle_0, this.string_27, ref this.lockdownServiceDescriptorHandle_0);
			this.ilockdownApi_0.lockdownd_get_value(this.lockdownClientHandle_0, null, "ActivationInfo", ref plistHandle);
			this.iplistApi_0.plist_to_xml(plistHandle, ref text, ref num);
			string result;
			if (text.Contains("ActivationInfoXML"))
			{
				result = text;
			}
			else
			{
				MobileactivationClientHandle mobileactivationClientHandle;
				this.imobileactivationApi_0.mobileactivation_client_new(this.iDeviceHandle_0, this.lockdownServiceDescriptorHandle_0, ref mobileactivationClientHandle);
				if (this.imobileactivationApi_0.mobileactivation_create_activation_info(mobileactivationClientHandle, ref plistHandle) == 0)
				{
					this.iplistApi_0.plist_to_xml(plistHandle, ref text, ref num);
				}
				if (text.Contains("ActivationInfoXML"))
				{
					result = text;
				}
				else
				{
					result = null;
				}
			}
			return result;
		}

		// Token: 0x0600016B RID: 363 RVA: 0x000208C4 File Offset: 0x0001EAC4
		public string method_54()
		{
			PlistHandle plistHandle = null;
			PlistHandle plistHandle2 = null;
			PlistHandle plistHandle3 = null;
			iDeviceActivationRequestHandle iDeviceActivationRequestHandle = null;
			iDeviceActivationResponseHandle iDeviceActivationResponseHandle = null;
			uint num = 0U;
			string text = null;
			this.method_24();
			this.ilockdownApi_0.lockdownd_start_service(this.lockdownClientHandle_0, this.string_27, ref this.lockdownServiceDescriptorHandle_0);
			this.ilockdownApi_0.lockdownd_get_value(this.lockdownClientHandle_0, null, "ActivationInfo", ref plistHandle2);
			this.iplistApi_0.plist_to_xml(plistHandle2, ref text, ref num);
			string result;
			if (!text.Contains("ActivationInfoXML"))
			{
				MobileactivationClientHandle mobileactivationClientHandle;
				this.imobileactivationApi_0.mobileactivation_client_new(this.iDeviceHandle_0, this.lockdownServiceDescriptorHandle_0, ref mobileactivationClientHandle);
				if (this.imobileactivationApi_0.mobileactivation_create_activation_info(mobileactivationClientHandle, ref plistHandle2) == 0)
				{
					this.iplistApi_0.plist_to_xml(plistHandle2, ref text, ref num);
				}
				if (!text.Contains("ActivationInfoXML"))
				{
					this.imobileactivationApi_0.mobileactivation_client_start_service(this.iDeviceHandle_0, ref mobileactivationClientHandle, this.string_26);
					this.imobileactivationApi_0.mobileactivation_create_activation_session_info(mobileactivationClientHandle, ref plistHandle);
					this.iiDeviceActivationApi_0.idevice_activation_drm_handshake_request_new(1, ref iDeviceActivationRequestHandle);
					this.iiDeviceActivationApi_0.idevice_activation_request_set_fields(iDeviceActivationRequestHandle, plistHandle);
					this.iiDeviceActivationApi_0.idevice_activation_send_request(iDeviceActivationRequestHandle, ref iDeviceActivationResponseHandle);
					this.iiDeviceActivationApi_0.idevice_activation_response_get_fields(iDeviceActivationResponseHandle, ref plistHandle3);
					iDeviceActivationResponseHandle = null;
					this.imobileactivationApi_0.mobileactivation_client_start_service(this.iDeviceHandle_0, ref mobileactivationClientHandle, this.string_26);
					this.imobileactivationApi_0.mobileactivation_create_activation_info_with_session(mobileactivationClientHandle, plistHandle3, ref plistHandle2);
					this.iplistApi_0.plist_to_xml(plistHandle2, ref text, ref num);
					if (text.Contains("ActivationInfoXML"))
					{
						result = text;
					}
					else
					{
						result = null;
					}
				}
				else
				{
					result = text;
				}
			}
			else
			{
				result = text;
			}
			return result;
		}

		// Token: 0x0600016C RID: 364 RVA: 0x00020A58 File Offset: 0x0001EC58
		public string method_55()
		{
			byte[] objVal = Convert.FromBase64String("PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0iVVRGLTgiPz4KPCFET0NUWVBFIHBsaXN0IFBVQkxJQyAiLS8vQXBwbGUvL0RURCBQTElTVCAxLjAvL0VOIiAiaHR0cDovL3d3dy5hcHBsZS5jb20vRFREcy9Qcm9wZXJ0eUxpc3QtMS4wLmR0ZCI+CjxwbGlzdCB2ZXJzaW9uPSIxLjAiPgo8ZGljdD4KCTxrZXk+RmFjdG9yeUFjdGl2YXRpb248L2tleT4KCSA8dHJ1ZS8+CjwvZGljdD4KPC9wbGlzdD4=");
			IntPtr zero = IntPtr.Zero;
			IntPtr intPtr = GClass25.CFPropertyListCreateFromXMLData(GClass25.intptr_0, GClass25.smethod_7(objVal), Enum7.const_0, ref zero);
			string result;
			if (intPtr == IntPtr.Zero)
			{
				result = null;
			}
			else
			{
				GClass32 value = GClass32.smethod_2(intPtr);
				this.method_3();
				IntPtr propertyList = Class4.AMDeviceCreateActivationInfoWithOptions(this.intptr_0, IntPtr.Zero, GClass32.smethod_3(value), IntPtr.Zero);
				string text = GClass25.smethod_3(propertyList).ToString();
				result = text;
			}
			return result;
		}

		// Token: 0x0600016D RID: 365 RVA: 0x00017E98 File Offset: 0x00016098
		public void method_56(string msg)
		{
		}

		// Token: 0x0600016E RID: 366 RVA: 0x00020ADC File Offset: 0x0001ECDC
		public GClass32 method_57(string response)
		{
			string[] keys = new string[]
			{
				"AccountTokenCertificate",
				"AccountToken",
				"FairPlayKeyData",
				"DeviceCertificate",
				"AccountTokenSignature",
				"UniqueDeviceCertificate"
			};
			string[] keys2 = new string[]
			{
				"unbrick",
				"AccountTokenCertificate",
				"AccountToken",
				"FairPlayKeyData",
				"DeviceCertificate",
				"AccountTokenSignature",
				"UniqueDeviceCertificate"
			};
			string text;
			if (response.Contains("iphone-activation"))
			{
				text = "iphone-activation";
			}
			else if (response.Contains("device-activation"))
			{
				text = "device-activation";
			}
			else
			{
				if (!response.Contains("ActivationRecord"))
				{
					return null;
				}
				text = "ActivationRecord";
			}
			this.method_58();
			File.AppendAllText(Class4.string_0 + "wildcard.ticket", response);
			GClass34 value = new GClass34(Class4.string_0 + "wildcard.ticket");
			GClass32 gclass = GClass32.smethod_2(GClass34.smethod_3(value));
			GClass32 gclass2 = new GClass32();
			GClass32 gclass3 = new GClass32();
			if (!text.Equals("ActivationRecord"))
			{
				gclass2 = GClass32.smethod_2(GClass29.smethod_0(gclass.method_7(text)));
				gclass3 = GClass32.smethod_2(GClass29.smethod_0(gclass2.method_7("activation-record")));
			}
			else
			{
				gclass2 = GClass32.smethod_2(GClass29.smethod_0(gclass.method_7(text)));
			}
			GClass32 result;
			if (text == "iphone-activation")
			{
				IntPtr[] array = new IntPtr[6];
				array[0] = GClass29.smethod_0(gclass2.method_7("unbrick"));
				array[1] = GClass29.smethod_0(gclass3.method_7("AccountTokenCertificate"));
				array[2] = GClass29.smethod_0(gclass3.method_7("AccountToken"));
				array[3] = GClass29.smethod_0(gclass3.method_7("FairPlayKeyData"));
				array[4] = GClass29.smethod_0(gclass3.method_7("DeviceCertificate"));
				array[5] = GClass29.smethod_0(gclass3.method_7("AccountTokenSignature"));
				array[6] = GClass29.smethod_0(gclass3.method_7("UniqueDeviceCertificate"));
				GClass32 gclass4 = new GClass32(keys2, array);
				result = gclass4;
			}
			else if (text == "device-activation")
			{
				IntPtr[] array = new IntPtr[5];
				array[0] = GClass29.smethod_0(gclass3.method_7("AccountTokenCertificate"));
				array[1] = GClass29.smethod_0(gclass3.method_7("AccountToken"));
				array[2] = GClass29.smethod_0(gclass3.method_7("FairPlayKeyData"));
				array[3] = GClass29.smethod_0(gclass3.method_7("DeviceCertificate"));
				array[4] = GClass29.smethod_0(gclass3.method_7("AccountTokenSignature"));
				array[5] = GClass29.smethod_0(gclass3.method_7("UniqueDeviceCertificate"));
				GClass32 gclass4 = new GClass32(keys, array);
				result = gclass4;
			}
			else
			{
				result = gclass2;
			}
			return result;
		}

		// Token: 0x0600016F RID: 367 RVA: 0x00020DAC File Offset: 0x0001EFAC
		public void method_58()
		{
			try
			{
				File.Delete(Class4.string_0 + "wildcard.ticket");
			}
			catch
			{
			}
		}

		// Token: 0x06000170 RID: 368 RVA: 0x00020DE4 File Offset: 0x0001EFE4
		public void method_59()
		{
			try
			{
			}
			catch
			{
			}
		}

		// Token: 0x06000171 RID: 369 RVA: 0x00020E08 File Offset: 0x0001F008
		public bool method_60()
		{
			this.method_24();
			if (!this.ilockdownApi_0.lockdownd_enter_recovery(this.lockdownClientHandle_0).Equals(0))
			{
				this.method_3();
				GEnum3 genum = (GEnum3)Class4.AMDeviceEnterRecovery(this.intptr_0);
				if (genum == GEnum3.const_80)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000172 RID: 370 RVA: 0x00020E68 File Offset: 0x0001F068
		public bool method_61()
		{
			RecoveryClientHandle recoveryClientHandle;
			RecoveryError recoveryError = this.irecoveryApi_0.irecv_open_with_ecid(ref recoveryClientHandle, 0UL);
			if (recoveryError == 0)
			{
				this.irecoveryApi_0.irecv_setenv(recoveryClientHandle, "auto-boot", "true");
				this.irecoveryApi_0.irecv_saveenv(recoveryClientHandle);
				recoveryError = this.irecoveryApi_0.irecv_reboot(recoveryClientHandle);
				if (recoveryError == 0)
				{
					return true;
				}
			}
			this.method_3();
			Class4.AMRecoveryModeDeviceSetAutoBoot(this.byte_0, 1);
			GEnum3 genum = (GEnum3)Class4.AMRecoveryModeDeviceReboot(this.byte_0);
			return genum == GEnum3.const_80;
		}

		// Token: 0x040000CF RID: 207
		private bool bool_0 = false;

		// Token: 0x040000D0 RID: 208
		private bool bool_1 = false;

		// Token: 0x040000D1 RID: 209
		private string string_0 = string.Empty;

		// Token: 0x040000D2 RID: 210
		private string string_1 = string.Empty;

		// Token: 0x040000D3 RID: 211
		private string string_2 = string.Empty;

		// Token: 0x040000D4 RID: 212
		private string string_3 = string.Empty;

		// Token: 0x040000D5 RID: 213
		private string string_4 = string.Empty;

		// Token: 0x040000D6 RID: 214
		private string string_5 = string.Empty;

		// Token: 0x040000D7 RID: 215
		private string string_6 = string.Empty;

		// Token: 0x040000D8 RID: 216
		private GEnum1 genum1_0;

		// Token: 0x040000D9 RID: 217
		private string string_7 = string.Empty;

		// Token: 0x040000DA RID: 218
		private string string_8 = string.Empty;

		// Token: 0x040000DB RID: 219
		private string string_9 = string.Empty;

		// Token: 0x040000DC RID: 220
		private string string_10 = string.Empty;

		// Token: 0x040000DD RID: 221
		private string string_11 = string.Empty;

		// Token: 0x040000DE RID: 222
		private string string_12 = string.Empty;

		// Token: 0x040000DF RID: 223
		private string string_13 = string.Empty;

		// Token: 0x040000E0 RID: 224
		private string productType = string.Empty;

		// Token: 0x040000E1 RID: 225
		private string string_14 = string.Empty;

		// Token: 0x040000E2 RID: 226
		private string string_15 = string.Empty;

		// Token: 0x040000E3 RID: 227
		private string string_16 = string.Empty;

		// Token: 0x040000E4 RID: 228
		private string string_17 = string.Empty;

		// Token: 0x040000E5 RID: 229
		private string string_18 = string.Empty;

		// Token: 0x040000E6 RID: 230
		public string string_19 = string.Empty;

		// Token: 0x040000E7 RID: 231
		private string string_20 = string.Empty;

		// Token: 0x040000E8 RID: 232
		private string string_21 = string.Empty;

		// Token: 0x040000E9 RID: 233
		private string string_22 = string.Empty;

		// Token: 0x040000EA RID: 234
		private string string_23 = string.Empty;

		// Token: 0x040000EB RID: 235
		public object[] object_0;

		// Token: 0x040000EC RID: 236
		private string string_24 = string.Empty;

		// Token: 0x040000ED RID: 237
		private int int_0;

		// Token: 0x040000EE RID: 238
		public IntPtr intptr_0;

		// Token: 0x040000EF RID: 239
		public byte[] byte_0;

		// Token: 0x040000F0 RID: 240
		private string string_25 = null;

		// Token: 0x040000F1 RID: 241
		private IPlistApi iplistApi_0 = LibiMobileDevice.Instance.Plist;

		// Token: 0x040000F2 RID: 242
		private IMobileactivationApi imobileactivationApi_0 = LibiMobileDevice.Instance.Mobileactivation;

		// Token: 0x040000F3 RID: 243
		private IMobileBackup2Api imobileBackup2Api_0 = LibiMobileDevice.Instance.MobileBackup2;

		// Token: 0x040000F4 RID: 244
		private IiDeviceApi iiDeviceApi_0 = LibiMobileDevice.Instance.iDevice;

		// Token: 0x040000F5 RID: 245
		private ILockdownApi ilockdownApi_0 = LibiMobileDevice.Instance.Lockdown;

		// Token: 0x040000F6 RID: 246
		private IiDeviceActivationApi iiDeviceActivationApi_0 = LibiMobileDevice.Instance.iDeviceActivation;

		// Token: 0x040000F7 RID: 247
		private IDiagnosticsRelayApi idiagnosticsRelayApi_0 = LibiMobileDevice.Instance.DiagnosticsRelay;

		// Token: 0x040000F8 RID: 248
		private IAfcApi afc = LibiMobileDevice.Instance.Afc;

		// Token: 0x040000F9 RID: 249
		private IRecoveryApi irecoveryApi_0 = LibiMobileDevice.Instance.Recovery;

		// Token: 0x040000FA RID: 250
		private iDeviceHandle iDeviceHandle_0 = null;

		// Token: 0x040000FB RID: 251
		private LockdownClientHandle lockdownClientHandle_0 = null;

		// Token: 0x040000FC RID: 252
		private LockdownServiceDescriptorHandle lockdownServiceDescriptorHandle_0;

		// Token: 0x040000FD RID: 253
		private string string_26 = "ideviceactivation";

		// Token: 0x040000FE RID: 254
		private string string_27 = "com.apple.mobileactivationd";
	}
}
