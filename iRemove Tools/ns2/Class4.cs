using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using iMobileDevice;
using ns11;
using ns5;
using ns7;
using ns9;

namespace ns2
{
	// Token: 0x0200001F RID: 31
	internal class Class4
	{
		// Token: 0x06000174 RID: 372 RVA: 0x00020F00 File Offset: 0x0001F100
		static Class4()
		{
			string fullName = new DirectoryInfo(Assembly.GetEntryAssembly().Location).Parent.FullName;
			Class4.string_0 = fullName + "\\cache\\";
			Class4.string_1 = fullName + "\\libs\\";
			try
			{
				if (!Directory.Exists(Class4.string_0))
				{
					Directory.CreateDirectory(Class4.string_0);
				}
			}
			catch
			{
			}
			NativeLibraries.Load(Class4.string_1);
			Class4.SetDllDirectory(Class4.string_1);
			Environment.SetEnvironmentVariable("Path", string.Join(";", new string[]
			{
				Environment.GetEnvironmentVariable("Path"),
				Class4.string_1
			}));
			GClass14.string_3 = Class4.string_0;
		}

		// Token: 0x06000175 RID: 373
		[DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool SetDllDirectory(string lpPathName);

		// Token: 0x06000176 RID: 374 RVA: 0x00020FC4 File Offset: 0x0001F1C4
		public static bool smethod_0(string strToCheck)
		{
			Regex regex = new Regex("^[a-zA-Z0-9\\s,]*$");
			return regex.IsMatch(strToCheck);
		}

		// Token: 0x06000177 RID: 375
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int AFCConnectionClose(IntPtr conn);

		// Token: 0x06000178 RID: 376
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int AFCConnectionGetFSBlockSize(IntPtr conn);

		// Token: 0x06000179 RID: 377
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int AFCConnectionInvalidate(IntPtr conn);

		// Token: 0x0600017A RID: 378
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int AFCConnectionIsValid(IntPtr conn);

		// Token: 0x0600017B RID: 379
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern GEnum3 AFCConnectionSetSecureContext(IntPtr device, IntPtr intResult);

		// Token: 0x0600017C RID: 380
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int AFCConnectionOpen(int socket, uint io_timeout, ref IntPtr conn);

		// Token: 0x0600017D RID: 381
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int AFCDeviceInfoOpen(IntPtr conn, ref IntPtr dict);

		// Token: 0x0600017E RID: 382
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int AMDeviceInstallApplication(int socket, IntPtr path, IntPtr options, IntPtr callback, IntPtr unknow1);

		// Token: 0x0600017F RID: 383
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int AMDeviceTransferApplication(int socket, IntPtr path, IntPtr options, Delegate7 callback, IntPtr unknow1);

		// Token: 0x06000180 RID: 384
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int AMDeviceUninstallApplication(IntPtr conn, IntPtr bundleIdentifier, IntPtr installOption, IntPtr unknown0, IntPtr unknown1);

		// Token: 0x06000181 RID: 385
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int AMDeviceArchiveApplication(IntPtr conn, IntPtr bundleIdentifier, IntPtr options, Delegate7 callback);

		// Token: 0x06000182 RID: 386
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int AMDPostNotification(int socket, IntPtr NoticeMessage, uint uint_0);

		// Token: 0x06000183 RID: 387
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int AMDObserveNotification(int socket, IntPtr NoticeMessage);

		// Token: 0x06000184 RID: 388
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int AMDeviceSecureStartService(IntPtr device, IntPtr service_name, IntPtr unknown, ref IntPtr socket);

		// Token: 0x06000185 RID: 389
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int AMDServiceConnectionGetSocket(IntPtr socket);

		// Token: 0x06000186 RID: 390
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int AMDServiceConnectionGetSecureIOContext(IntPtr socket);

		// Token: 0x06000187 RID: 391
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int AMDeviceLookupApplicationArchives(IntPtr conn, IntPtr AppType, ref IntPtr result);

		// Token: 0x06000188 RID: 392
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int AMDeviceLookupApplications(IntPtr conn, IntPtr AppType, ref IntPtr result);

		// Token: 0x06000189 RID: 393
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int AFCDirectoryClose(IntPtr conn, IntPtr dir);

		// Token: 0x0600018A RID: 394
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int AFCDirectoryCreate(IntPtr conn, string path);

		// Token: 0x0600018B RID: 395
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int AFCFileRefLock(IntPtr conn, long long_0);

		// Token: 0x0600018C RID: 396
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int AFCDirectoryOpen(IntPtr conn, byte[] path, ref IntPtr dir);

		// Token: 0x0600018D RID: 397
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "AFCDirectoryOpen")]
		public static extern GEnum3 AFCDirectoryOpen_1(IntPtr afcHandle, IntPtr path, ref IntPtr dir);

		// Token: 0x0600018E RID: 398 RVA: 0x00020FE4 File Offset: 0x0001F1E4
		public static int smethod_1(IntPtr conn, string path, ref IntPtr dir)
		{
			return Class4.AFCDirectoryOpen(conn, Encoding.UTF8.GetBytes(path), ref dir);
		}

		// Token: 0x0600018F RID: 399 RVA: 0x00021008 File Offset: 0x0001F208
		public static int smethod_2(IntPtr conn, IntPtr dir, ref string buffer)
		{
			IntPtr zero = IntPtr.Zero;
			int num = Class4.AFCDirectoryRead(conn, dir, ref zero);
			int result;
			if (num == 0 && zero != IntPtr.Zero)
			{
				int num2 = 0;
				List<byte> list = new List<byte>();
				while (Marshal.ReadByte(zero, num2) > 0)
				{
					list.Add(Marshal.ReadByte(zero, num2));
					num2++;
				}
				buffer = Encoding.UTF8.GetString(list.ToArray());
				result = num;
			}
			else
			{
				buffer = null;
				result = num;
			}
			return result;
		}

		// Token: 0x06000190 RID: 400
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern GEnum3 AFCGetFileInfo(IntPtr afcHandle, IntPtr path, ref IntPtr buffer, ref uint length);

		// Token: 0x06000191 RID: 401
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int AFCDirectoryRead(IntPtr afcHandle, IntPtr dir, ref IntPtr dirent);

		// Token: 0x06000192 RID: 402
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int AFCFileInfoOpen(IntPtr conn, byte[] path, ref IntPtr dict);

		// Token: 0x06000193 RID: 403
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "AFCFileInfoOpen")]
		public static extern GEnum3 AFCFileInfoOpen_1(IntPtr afcHandle, IntPtr path, ref IntPtr info);

		// Token: 0x06000194 RID: 404
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int AFCFileRefClose(IntPtr conn, long handle);

		// Token: 0x06000195 RID: 405
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int AFCFileRefOpen(IntPtr conn, byte[] path, int mode, ref long handle);

		// Token: 0x06000196 RID: 406
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "AFCFileRefOpen")]
		public static extern GEnum3 AFCFileRefOpen_1(IntPtr afcHandle, IntPtr path, int mode, ref long handle);

		// Token: 0x06000197 RID: 407
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int AFCFileRefRead(IntPtr conn, long handle, byte[] buffer, ref uint len);

		// Token: 0x06000198 RID: 408
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int AFCFileRefSeek(IntPtr conn, long handle, uint pos, uint origin);

		// Token: 0x06000199 RID: 409
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "AFCFileRefSeek")]
		public static extern GEnum3 AFCFileRefSeek_1(IntPtr afcHandle, long handle, long pos, uint origin);

		// Token: 0x0600019A RID: 410
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern GEnum3 AFCFileRefUnlock(IntPtr afcHandle, long handle);

		// Token: 0x0600019B RID: 411
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int AFCFileRefSetFileSize(IntPtr conn, long handle, uint size);

		// Token: 0x0600019C RID: 412
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int AFCFileRefTell(IntPtr conn, long handle, ref uint position);

		// Token: 0x0600019D RID: 413
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int AFCFileRefWrite(IntPtr conn, long handle, byte[] buffer, uint len);

		// Token: 0x0600019E RID: 414
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int AFCFlushData(IntPtr conn, long handle);

		// Token: 0x0600019F RID: 415
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int AFCKeyValueClose(IntPtr dict);

		// Token: 0x060001A0 RID: 416
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int AFCKeyValueRead(IntPtr dict, ref IntPtr key, ref IntPtr val);

		// Token: 0x060001A1 RID: 417
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int AFCRemovePath(IntPtr conn, byte[] path);

		// Token: 0x060001A2 RID: 418
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "AFCRemovePath")]
		public static extern GEnum3 AFCRemovePath_1(IntPtr afcHandle, IntPtr path);

		// Token: 0x060001A3 RID: 419
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int AFCRenamePath(IntPtr conn, byte[] old_path, byte[] new_path);

		// Token: 0x060001A4 RID: 420
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr AMDeviceCreateActivationSessionInfo(IntPtr device, ref IntPtr result);

		// Token: 0x060001A5 RID: 421
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int AMDeviceActivate(IntPtr device, IntPtr activation_ticket);

		// Token: 0x060001A6 RID: 422
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr AMDeviceCreateActivationInfoWithOptions(IntPtr device, IntPtr callback, IntPtr options, IntPtr error);

		// Token: 0x060001A7 RID: 423
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int AMDeviceActivateWithOptions(IntPtr device, IntPtr activation_ticket, IntPtr activation_headers);

		// Token: 0x060001A8 RID: 424 RVA: 0x00021084 File Offset: 0x0001F284
		public static bool smethod_3(IntPtr device, IntPtr ActivationRecord, IntPtr ActivationHeaders)
		{
			bool result = true;
			int num = Class4.AMDeviceActivateWithOptions(device, ActivationRecord, ActivationHeaders);
			if (num != 0)
			{
				result = false;
			}
			return result;
		}

		// Token: 0x060001A9 RID: 425 RVA: 0x000210A8 File Offset: 0x0001F2A8
		public static bool smethod_4(IntPtr device, IntPtr ActivationRecord)
		{
			bool result = true;
			if (Class4.AMDeviceActivate(device, ActivationRecord) != 0)
			{
				result = false;
			}
			return result;
		}

		// Token: 0x060001AA RID: 426
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int AMDeviceConnect(IntPtr device);

		// Token: 0x060001AB RID: 427
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr AMDeviceCopyDeviceIdentifier(IntPtr device);

		// Token: 0x060001AC RID: 428 RVA: 0x000210C8 File Offset: 0x0001F2C8
		public static object smethod_5(IntPtr device, string domain, string name)
		{
			object result = string.Empty;
			IntPtr intPtr = GClass25.smethod_25(domain);
			IntPtr intPtr2 = GClass25.smethod_25(name);
			IntPtr intPtr3 = Class4.AMDeviceCopyValue(device, intPtr, intPtr2);
			if (intPtr != IntPtr.Zero)
			{
				GClass25.CFRelease(intPtr);
			}
			if (intPtr2 != IntPtr.Zero)
			{
				GClass25.CFRelease(intPtr2);
			}
			if (intPtr3 != IntPtr.Zero)
			{
				object obj = GClass25.smethod_15(ref intPtr3);
				result = RuntimeHelpers.GetObjectValue(obj);
				GClass25.CFRelease(intPtr3);
			}
			return result;
		}

		// Token: 0x060001AD RID: 429
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr AMDeviceCopyValue(IntPtr device, IntPtr domain, IntPtr cfstring);

		// Token: 0x060001AE RID: 430 RVA: 0x00021144 File Offset: 0x0001F344
		public static bool smethod_6(IntPtr device, string domain, string name)
		{
			bool result = true;
			try
			{
				IntPtr intPtr = GClass25.smethod_25(domain);
				IntPtr intPtr2 = GClass25.smethod_25(name);
				if (Class4.AMDeviceRemoveValue(device, intPtr, intPtr2) != 0)
				{
					result = false;
				}
				if (intPtr != IntPtr.Zero)
				{
					GClass25.CFRelease(intPtr);
				}
				if (intPtr2 != IntPtr.Zero)
				{
					GClass25.CFRelease(intPtr2);
				}
			}
			catch (Exception)
			{
			}
			return result;
		}

		// Token: 0x060001AF RID: 431
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int AMDeviceRemoveValue(IntPtr device, IntPtr domain, IntPtr cfsKey);

		// Token: 0x060001B0 RID: 432 RVA: 0x000211AC File Offset: 0x0001F3AC
		public static bool smethod_7(IntPtr device, string domain, string name, object value)
		{
			bool result = true;
			IntPtr intPtr = GClass25.smethod_25(domain);
			IntPtr intPtr2 = GClass25.smethod_25(name);
			IntPtr intPtr3 = GClass25.smethod_7(value);
			if (Class4.AMDeviceSetValue(device, intPtr, intPtr2, intPtr3) != 0)
			{
				result = false;
			}
			if (intPtr != IntPtr.Zero)
			{
				GClass25.CFRelease(intPtr);
			}
			if (intPtr2 != IntPtr.Zero)
			{
				GClass25.CFRelease(intPtr2);
			}
			if (intPtr3 != IntPtr.Zero)
			{
				GClass25.CFRelease(intPtr3);
			}
			return result;
		}

		// Token: 0x060001B1 RID: 433
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int AMDeviceSetValue(IntPtr device, IntPtr domain, IntPtr cfsKey, IntPtr cfsValue);

		// Token: 0x060001B2 RID: 434
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "AMDeviceSetValue")]
		public static extern int AMDeviceSetValue_1(IntPtr device, IntPtr mbz, IntPtr cfstringkey, IntPtr cfstringname);

		// Token: 0x060001B3 RID: 435
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int AMDeviceDeactivate(IntPtr device);

		// Token: 0x060001B4 RID: 436
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int AMDeviceDisconnect(IntPtr device);

		// Token: 0x060001B5 RID: 437
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int AMDeviceEnterRecovery(IntPtr device);

		// Token: 0x060001B6 RID: 438
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int AMDeviceGetConnectionID(IntPtr device);

		// Token: 0x060001B7 RID: 439
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int AMDeviceIsPaired(IntPtr device);

		// Token: 0x060001B8 RID: 440
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int AMDeviceNotificationSubscribe(Delegate8 callback, uint unused1, uint unused2, uint unused3, ref IntPtr am_device_notification_ptr);

		// Token: 0x060001B9 RID: 441
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern GEnum3 AMDeviceNotificationUnsubscribe(IntPtr am_device_notification_ptr);

		// Token: 0x060001BA RID: 442
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int AMDeviceRelease(IntPtr device);

		// Token: 0x060001BB RID: 443
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int AMDeviceStartService(IntPtr device, IntPtr service_name, ref int socket, IntPtr unknown);

		// Token: 0x060001BC RID: 444
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void AMDeviceRetain(IntPtr device);

		// Token: 0x060001BD RID: 445
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int AMDeviceStartSession(IntPtr device);

		// Token: 0x060001BE RID: 446
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int AMDeviceStopSession(IntPtr device);

		// Token: 0x060001BF RID: 447
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int AMDeviceValidatePairing(IntPtr device);

		// Token: 0x060001C0 RID: 448
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int AMDevicePair(IntPtr device);

		// Token: 0x060001C1 RID: 449
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern GEnum3 AMDevicePairWithOptions(IntPtr device, IntPtr ptrOption);

		// Token: 0x060001C2 RID: 450
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int AMDeviceUnpair(IntPtr device);

		// Token: 0x060001C3 RID: 451
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern GEnum3 AMDListenForNotifications(int socket, Delegate6 callback, IntPtr userdata);

		// Token: 0x060001C4 RID: 452
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr AMRecoveryModeDeviceCopyIMEI(byte[] device);

		// Token: 0x060001C5 RID: 453
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int AMRecoveryModeDeviceGetLocationID(byte[] device);

		// Token: 0x060001C6 RID: 454
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int AMRecoveryModeDeviceGetProductID(byte[] device);

		// Token: 0x060001C7 RID: 455
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int AMRecoveryModeDeviceGetProductType(byte[] device);

		// Token: 0x060001C8 RID: 456
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int AMRecoveryModeDeviceGetTypeID();

		// Token: 0x060001C9 RID: 457
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int AMRecoveryModeGetSoftwareBuildVersion();

		// Token: 0x060001CA RID: 458
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr AMRecoveryModeDeviceCopySerialNumber(byte[] device);

		// Token: 0x060001CB RID: 459
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr AMRecoveryModeDeviceCopyAuthlnstallPreflightOptions(byte[] byte_0, IntPtr intptr_0, IntPtr intptr_1);

		// Token: 0x060001CC RID: 460
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int AMRecoveryModeDeviceReboot(byte[] device);

		// Token: 0x060001CD RID: 461
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int AMRecoveryModeDeviceSetAutoBoot(byte[] device, byte paramByte);

		// Token: 0x060001CE RID: 462
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern string AMRestoreModeDeviceCopyIMEI(byte[] device);

		// Token: 0x060001CF RID: 463
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int AMRestoreModeDeviceCreate(uint unknown0, int connection_id, uint unknown1);

		// Token: 0x060001D0 RID: 464
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int AMRestoreRegisterForDeviceNotifications(Delegate9 dfu_connect, Delegate9 recovery_connect, Delegate9 dfu_disconnect, Delegate9 recovery_disconnect, uint unknown0, ref IntPtr user_info);

		// Token: 0x060001D1 RID: 465
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int AMDeviceGetInterfaceType(IntPtr device);

		// Token: 0x060001D2 RID: 466
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int AMDServiceConnectionReceiveMessage(IntPtr socket, ref IntPtr response, IntPtr format);

		// Token: 0x060001D3 RID: 467
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "AMDServiceConnectionReceiveMessage")]
		public static extern int AMDServiceConnectionReceiveMessage_1(IntPtr socket, ref uint uint_0, int int_1);

		// Token: 0x060001D4 RID: 468
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int AMDServiceConnectionReceive(IntPtr socket, IntPtr intptr_0, int int_1);

		// Token: 0x060001D5 RID: 469
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int AMRestorePerformRecoveryModeRestore(byte[] device, IntPtr dicopts, Delegate7 callback, IntPtr user_info);

		// Token: 0x060001D6 RID: 470
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr AMRestoreCreateDefaultOptions(IntPtr allocator);

		// Token: 0x060001D7 RID: 471
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "AMDServiceConnectionReceive")]
		public static extern int AMDServiceConnectionReceive_1(int inSocket, IntPtr buffer, int bufferlen);

		// Token: 0x060001D8 RID: 472
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "AMDServiceConnectionReceive")]
		public static extern int AMDServiceConnectionReceive_2(int inSocket, ref uint buffer, int bufferlen);

		// Token: 0x060001D9 RID: 473
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int AMDServiceConnectionSend(IntPtr handle, IntPtr buffer, int bufferlen);

		// Token: 0x060001DA RID: 474
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "AMDServiceConnectionSend")]
		public static extern int AMDServiceConnectionSend_1(IntPtr handle, ref uint buffer, int bufferlen);

		// Token: 0x060001DB RID: 475
		[DllImport("iTunesMobileDevice.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int USBMuxConnectByPort(int connectionID, uint iPhone_port_network_byte_order, ref int outSocket);

		// Token: 0x060001DC RID: 476
		[DllImport("Ws2_32.dll", CallingConvention = CallingConvention.StdCall)]
		public static extern uint htonl(uint hostlong);

		// Token: 0x060001DD RID: 477
		[DllImport("Ws2_32.dll", CallingConvention = CallingConvention.StdCall)]
		public static extern uint htons(uint hostshort);

		// Token: 0x060001DE RID: 478
		[DllImport("Ws2_32.dll", CallingConvention = CallingConvention.StdCall)]
		public static extern uint ntohl(uint netlong);

		// Token: 0x060001DF RID: 479
		[DllImport("Ws2_32.dll", CallingConvention = CallingConvention.StdCall)]
		public static extern int send(int inSocket, IntPtr buffer, int bufferlen, int flags);

		// Token: 0x060001E0 RID: 480
		[DllImport("Ws2_32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "send")]
		public static extern int send_1(int inSocket, ref uint buffer, int bufferlen, int flags);

		// Token: 0x060001E1 RID: 481
		[DllImport("Ws2_32.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
		public static extern int recv(int inSocket, IntPtr buffer, int bufferlen, int flags);

		// Token: 0x060001E2 RID: 482
		[DllImport("Ws2_32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "recv")]
		public static extern int recv_1(int inSocket, ref uint buffer, int bufferlen, int flags);

		// Token: 0x060001E3 RID: 483
		[DllImport("Ws2_32.dll", CallingConvention = CallingConvention.StdCall)]
		public static extern int closesocket(int inSocket);

		// Token: 0x060001E4 RID: 484 RVA: 0x0002121C File Offset: 0x0001F41C
		public static IntPtr smethod_8(int sesssion, string strMessageType, Dictionary<object, object> dictParams)
		{
			IntPtr intPtr = GClass25.smethod_25(strMessageType);
			IntPtr intPtr2 = GClass25.smethod_7(dictParams);
			IntPtr result = Class4.ATCFMessageCreate(sesssion, intPtr, intPtr2);
			GClass25.CFRelease(intPtr);
			GClass25.CFRelease(intPtr2);
			return result;
		}

		// Token: 0x060001E5 RID: 485
		[DllImport("AirTrafficHost.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ATCFMessageCreate(int sesssion, IntPtr hMessageType, IntPtr hParams);

		// Token: 0x060001E6 RID: 486 RVA: 0x00021250 File Offset: 0x0001F450
		public static IntPtr smethod_9(string strPrefsValue, string strUUID)
		{
			IntPtr intPtr = GClass25.smethod_25(strPrefsValue);
			IntPtr intPtr2 = GClass25.smethod_25(strUUID);
			IntPtr result = Class4.ATHostConnectionCreateWithLibrary(intPtr, intPtr2, 0);
			GClass25.CFRelease(intPtr2);
			GClass25.CFRelease(intPtr);
			return result;
		}

		// Token: 0x060001E7 RID: 487
		[DllImport("AirTrafficHost.dll", CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr ATHostConnectionCreateWithLibrary(IntPtr hPrefsValue, IntPtr hUUID, int unkonwn);

		// Token: 0x060001E8 RID: 488
		[DllImport("AirTrafficHost.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int ATHostConnectionGetCurrentSessionNumber(IntPtr hATHost);

		// Token: 0x060001E9 RID: 489
		[DllImport("AirTrafficHost.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int ATHostConnectionGetGrappaSessionId(IntPtr hATHost);

		// Token: 0x060001EA RID: 490
		[DllImport("AirTrafficHost.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ATHostConnectionReadMessage(IntPtr hATHost);

		// Token: 0x060001EB RID: 491
		[DllImport("AirTrafficHost.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ATHostConnectionRelease(IntPtr hATHost);

		// Token: 0x060001EC RID: 492 RVA: 0x00021284 File Offset: 0x0001F484
		public static int smethod_10(IntPtr hATHost, string strPid, string strMediaType, string strFilePath)
		{
			IntPtr intPtr = GClass25.__CFStringMakeConstantString(strPid);
			IntPtr intPtr2 = GClass25.__CFStringMakeConstantString(strMediaType);
			IntPtr intPtr3 = GClass25.__CFStringMakeConstantString(strFilePath);
			IntPtr intPtr4 = Class4.ATHostConnectionSendAssetCompleted(hATHost, intPtr, intPtr2, intPtr3);
			GClass25.CFRelease(intPtr);
			GClass25.CFRelease(intPtr2);
			GClass25.CFRelease(intPtr3);
			return intPtr4.ToInt32();
		}

		// Token: 0x060001ED RID: 493
		[DllImport("AirTrafficHost.dll", CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr ATHostConnectionSendAssetCompleted(IntPtr hATHost, IntPtr hPid, IntPtr hMediaType, IntPtr hFilePath);

		// Token: 0x060001EE RID: 494 RVA: 0x000212D0 File Offset: 0x0001F4D0
		public static int smethod_11(IntPtr hATHost, string strPid, string strMediaType, int intType)
		{
			IntPtr intPtr = GClass25.__CFStringMakeConstantString(strPid);
			IntPtr intPtr2 = GClass25.__CFStringMakeConstantString(strMediaType);
			IntPtr intPtr3 = (IntPtr)((int)Class4.ATHostConnectionSendFileError(hATHost, intPtr, intPtr2, intType));
			GClass25.CFRelease(intPtr);
			GClass25.CFRelease(intPtr2);
			return intPtr3.ToInt32();
		}

		// Token: 0x060001EF RID: 495
		[DllImport("AirTrafficHost.dll", CallingConvention = CallingConvention.Cdecl)]
		private static extern GEnum3 ATHostConnectionSendFileError(IntPtr hATHost, IntPtr hPid, IntPtr hMediaType, int intType);

		// Token: 0x060001F0 RID: 496 RVA: 0x00021310 File Offset: 0x0001F510
		public static int smethod_12(IntPtr hATHost, string strPid, string strMediaType, double fileProgress, double totalProgress)
		{
			IntPtr intPtr = GClass25.__CFStringMakeConstantString(strPid);
			IntPtr intPtr2 = GClass25.__CFStringMakeConstantString(strMediaType);
			byte[] bytes = BitConverter.GetBytes(fileProgress);
			byte[] bytes2 = BitConverter.GetBytes(totalProgress);
			int proc1L = BitConverter.ToInt32(bytes, 0);
			int proc1H = BitConverter.ToInt32(bytes, 4);
			int proc2L = BitConverter.ToInt32(bytes2, 0);
			int proc2H = BitConverter.ToInt32(bytes2, 4);
			IntPtr intPtr3 = (IntPtr)((int)Class4.ATHostConnectionSendFileProgress(hATHost, intPtr, intPtr2, proc1L, proc1H, proc2L, proc2H));
			GClass25.CFRelease(intPtr);
			GClass25.CFRelease(intPtr2);
			return intPtr3.ToInt32();
		}

		// Token: 0x060001F1 RID: 497
		[DllImport("AirTrafficHost.dll", CallingConvention = CallingConvention.Cdecl)]
		private static extern GEnum3 ATHostConnectionSendFileProgress(IntPtr hATHost, IntPtr hPid, IntPtr hMediaType, int proc1L, int proc1H, int proc2L, int proc2H);

		// Token: 0x060001F2 RID: 498
		[DllImport("AirTrafficHost.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern GEnum3 ATHostConnectionSendHostInfo(IntPtr hATHost, IntPtr hDictInfo);

		// Token: 0x060001F3 RID: 499
		[DllImport("AirTrafficHost.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern GEnum3 ATHostConnectionSendMetadataSyncFinished(IntPtr hATHost, IntPtr hKeybag, IntPtr hMedia);

		// Token: 0x060001F4 RID: 500
		[DllImport("AirTrafficHost.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern GEnum3 ATHostConnectionSendPowerAssertion(IntPtr hATHost, IntPtr allocator);

		// Token: 0x060001F5 RID: 501
		[DllImport("AirTrafficHost.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern GEnum3 ATHostConnectionSendSyncRequest(IntPtr hATHost, IntPtr hArrDataclasses, IntPtr hDictDataclassAnchors, IntPtr hDictHostInfo);

		// Token: 0x060001F6 RID: 502
		[DllImport("AirTrafficHost.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ATProcessLinkSendMessage(IntPtr hATHost, IntPtr hATCFMessage);

		// Token: 0x060001F7 RID: 503 RVA: 0x0002138C File Offset: 0x0001F58C
		public static IntPtr smethod_13(string s)
		{
			return GClass25.smethod_25(s);
		}

		// Token: 0x040000FF RID: 255
		public static string string_0;

		// Token: 0x04000100 RID: 256
		public static string string_1;
	}
}
