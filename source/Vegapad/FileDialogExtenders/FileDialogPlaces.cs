using System;
using System.Windows.Forms;
using Microsoft.Win32;
using Win32Types;

namespace FileDialogExtenders
{
	public static class FileDialogPlaces
	{
		public static void SetPlaces(this FileDialog fd, object[] places)
		{
			if (fd == null || places == null)
			{
				return;
			}
			if (FileDialogPlaces.m_places == null)
			{
				FileDialogPlaces.m_places = new object[places.GetLength(0)];
			}
			for (int i = 0; i < FileDialogPlaces.m_places.GetLength(0); i++)
			{
				FileDialogPlaces.m_places[i] = places[i];
			}
			if (FileDialogPlaces._fakeKey != null)
			{
				fd.ResetPlaces();
			}
			FileDialogPlaces.SetupFakeRegistryTree();
			if (fd != null)
			{
				fd.Disposed += delegate(object sender, EventArgs e)
				{
					if (FileDialogPlaces.m_places != null && fd != null)
					{
						fd.ResetPlaces();
					}
				};
			}
		}

		public static void ResetPlaces(this FileDialog fd)
		{
			if (FileDialogPlaces._overriddenKey != IntPtr.Zero)
			{
				FileDialogPlaces.ResetRegistry(FileDialogPlaces._overriddenKey);
				FileDialogPlaces._overriddenKey = IntPtr.Zero;
			}
			if (FileDialogPlaces._fakeKey != null)
			{
				FileDialogPlaces._fakeKey.Close();
				FileDialogPlaces._fakeKey = null;
			}
			Registry.CurrentUser.DeleteSubKeyTree(FileDialogPlaces.TempKeyName);
			FileDialogPlaces.m_places = null;
		}

		private static void SetupFakeRegistryTree()
		{
			try
			{
				FileDialogPlaces._fakeKey = Registry.CurrentUser.CreateSubKey(FileDialogPlaces.TempKeyName);
				FileDialogPlaces._overriddenKey = FileDialogPlaces.InitializeRegistry();
				RegistryKey reg = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\ComDlg32\\PlacesBar");
				for (int i = 0; i < FileDialogPlaces.m_places.GetLength(0); i++)
				{
					if (FileDialogPlaces.m_places[i] != null)
					{
						reg.SetValue("Place" + i.ToString(), FileDialogPlaces.m_places[i]);
					}
				}
			}
			catch
			{
			}
		}

		private static IntPtr InitializeRegistry()
		{
			IntPtr hkMyCU;
			NativeMethods.RegCreateKeyW(FileDialogPlaces.HKEY_CURRENT_USER, FileDialogPlaces.TempKeyName, out hkMyCU);
			NativeMethods.RegOverridePredefKey(FileDialogPlaces.HKEY_CURRENT_USER, hkMyCU);
			return hkMyCU;
		}

		private static void ResetRegistry(IntPtr hkMyCU)
		{
			try
			{
				NativeMethods.RegOverridePredefKey(FileDialogPlaces.HKEY_CURRENT_USER, IntPtr.Zero);
				NativeMethods.RegCloseKey(hkMyCU);
			}
			catch
			{
			}
		}

		private static readonly string TempKeyName = "TempPredefKey_" + Guid.NewGuid().ToString();

		private const string Key_PlacesBar = "Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\ComDlg32\\PlacesBar";

		private static RegistryKey _fakeKey;

		private static IntPtr _overriddenKey;

		private static object[] m_places;

		private static readonly UIntPtr HKEY_CURRENT_USER = new UIntPtr(2147483649u);
	}
}
