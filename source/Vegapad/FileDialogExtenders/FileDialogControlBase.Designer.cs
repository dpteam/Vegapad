using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Win32Types;

namespace FileDialogExtenders
{
	public class FileDialogControlBase : UserControl
	{
		[Category("FileDialogExtenders")]
		public event FileDialogControlBase.PathChangedEventHandler EventFileNameChanged;

		[Category("FileDialogExtenders")]
		public event FileDialogControlBase.PathChangedEventHandler EventFolderNameChanged;

		[Category("FileDialogExtenders")]
		public event FileDialogControlBase.FilterChangedEventHandler EventFilterChanged;

		[Category("FileDialogExtenders")]
		public event CancelEventHandler EventClosingDialog;

		public FileDialogControlBase()
		{
			this.InitializeComponent();
		}

		internal static uint OriginalDlgWidth
		{
			get
			{
				return FileDialogControlBase._originalDlgWidth;
			}
			set
			{
				FileDialogControlBase._originalDlgWidth = value;
			}
		}

		internal static uint OriginalDlgHeight
		{
			get
			{
				return FileDialogControlBase._originalDlgHeight;
			}
			set
			{
				FileDialogControlBase._originalDlgHeight = value;
			}
		}

		[Browsable(false)]
		public string[] FileDlgFileNames
		{
			get
			{
				if (!base.DesignMode)
				{
					return this.MSDialog.FileNames;
				}
				return null;
			}
		}

		[Browsable(false)]
		public FileDialog MSDialog
		{
			get
			{
				return this._MSdialog;
			}
			set
			{
				this._MSdialog = value;
			}
		}

		[Category("FileDialogExtenders")]
		[DefaultValue(AddonWindowLocation.Right)]
		public AddonWindowLocation FileDlgStartLocation
		{
			get
			{
				return this._StartLocation;
			}
			set
			{
				this._StartLocation = value;
				if (base.DesignMode)
				{
					this.Refresh();
				}
			}
		}

		internal Size OriginalCtrlSize
		{
			get
			{
				return this._OriginalCtrlSize;
			}
			set
			{
				this._OriginalCtrlSize = value;
			}
		}

		[Category("FileDialogExtenders")]
		[DefaultValue(FolderViewMode.Default)]
		public FolderViewMode FileDlgDefaultViewMode
		{
			get
			{
				return this._DefaultViewMode;
			}
			set
			{
				this._DefaultViewMode = value;
			}
		}

		[Category("FileDialogExtenders")]
		[DefaultValue(FileDialogType.OpenFileDlg)]
		public FileDialogType FileDlgType
		{
			get
			{
				return this._FileDlgType;
			}
			set
			{
				this._FileDlgType = value;
			}
		}

		[Category("FileDialogExtenders")]
		[DefaultValue("")]
		public string FileDlgInitialDirectory
		{
			get
			{
				if (!base.DesignMode)
				{
					return this.MSDialog.InitialDirectory;
				}
				return this._InitialDirectory;
			}
			set
			{
				this._InitialDirectory = value;
				if (!base.DesignMode && this.MSDialog != null)
				{
					this.MSDialog.InitialDirectory = value;
				}
			}
		}

		[Category("FileDialogExtenders")]
		[DefaultValue("")]
		public string FileDlgFileName
		{
			get
			{
				if (!base.DesignMode)
				{
					return this.MSDialog.FileName;
				}
				return this._FileName;
			}
			set
			{
				this._FileName = value;
			}
		}

		[Category("FileDialogExtenders")]
		[DefaultValue("")]
		public string FileDlgCaption
		{
			get
			{
				return this._Caption;
			}
			set
			{
				this._Caption = value;
			}
		}

		[Category("FileDialogExtenders")]
		[DefaultValue("&Open")]
		public string FileDlgOkCaption
		{
			get
			{
				return this._OKCaption;
			}
			set
			{
				this._OKCaption = value;
			}
		}

		[Category("FileDialogExtenders")]
		[DefaultValue("jpg")]
		public string FileDlgDefaultExt
		{
			get
			{
				if (!base.DesignMode)
				{
					return this.MSDialog.DefaultExt;
				}
				return this._DefaultExt;
			}
			set
			{
				this._DefaultExt = value;
			}
		}

		[Category("FileDialogExtenders")]
		[DefaultValue("All files (*.*)|*.*")]
		public string FileDlgFilter
		{
			get
			{
				if (!base.DesignMode)
				{
					return this.MSDialog.Filter;
				}
				return this._Filter;
			}
			set
			{
				this._Filter = value;
			}
		}

		[Category("FileDialogExtenders")]
		[DefaultValue(1)]
		public int FileDlgFilterIndex
		{
			get
			{
				if (!base.DesignMode)
				{
					return this.MSDialog.FilterIndex;
				}
				return this._FilterIndex;
			}
			set
			{
				this._FilterIndex = value;
			}
		}

		[Category("FileDialogExtenders")]
		[DefaultValue(true)]
		public bool FileDlgAddExtension
		{
			get
			{
				if (!base.DesignMode)
				{
					return this.MSDialog.AddExtension;
				}
				return this._AddExtension;
			}
			set
			{
				this._AddExtension = value;
			}
		}

		[Category("FileDialogExtenders")]
		[DefaultValue(true)]
		public bool FileDlgEnableOkBtn
		{
			get
			{
				return this._EnableOkBtn;
			}
			set
			{
				this._EnableOkBtn = value;
				if (!base.DesignMode && this.MSDialog != null && this._hOKButton != IntPtr.Zero)
				{
					NativeMethods.EnableWindow(this._hOKButton, this._EnableOkBtn);
				}
			}
		}

		[Category("FileDialogExtenders")]
		[DefaultValue(true)]
		public bool FileDlgCheckFileExists
		{
			get
			{
				if (!base.DesignMode)
				{
					return this.MSDialog.CheckFileExists;
				}
				return this._CheckFileExists;
			}
			set
			{
				this._CheckFileExists = value;
			}
		}

		[Category("FileDialogExtenders")]
		[DefaultValue(false)]
		public bool FileDlgShowHelp
		{
			get
			{
				if (!base.DesignMode)
				{
					return this.MSDialog.ShowHelp;
				}
				return this._ShowHelp;
			}
			set
			{
				this._ShowHelp = value;
			}
		}

		[Category("FileDialogExtenders")]
		[DefaultValue(true)]
		public bool FileDlgDereferenceLinks
		{
			get
			{
				if (!base.DesignMode)
				{
					return this.MSDialog.DereferenceLinks;
				}
				return this._DereferenceLinks;
			}
			set
			{
				this._DereferenceLinks = value;
			}
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			if (!base.DesignMode && this.MSDialog != null)
			{
				this.MSDialog.FileOk += this.FileDialogControlBase_ClosingDialog;
				this.MSDialog.Disposed += this.FileDialogControlBase_DialogDisposed;
				this.MSDialog.HelpRequest += this.FileDialogControlBase_HelpRequest;
				this.FileDlgEnableOkBtn = this._EnableOkBtn;
				NativeMethods.SetWindowText(new HandleRef(this._dlgWrapper, this._dlgWrapper.Handle), this._Caption);
				NativeMethods.SetWindowText(new HandleRef(this, this._hOKButton), this._OKCaption);
			}
		}

		public void SortViewByColumn(int index)
		{
			try
			{
				IntPtr hWndWin = NativeMethods.FindWindowEx(this._dlgWrapper.Handle, IntPtr.Zero, "SHELLDLL_DefView", "");
				if (hWndWin != IntPtr.Zero)
				{
					NativeMethods.SendMessage(new HandleRef(this, hWndWin), 273u, (IntPtr)28716, IntPtr.Zero);
					int HDN_ITEMCLICKW = -300 - 22;
					IntPtr hWndLV = NativeMethods.FindWindowEx(hWndWin, IntPtr.Zero, "SysListView32", IntPtr.Zero);
					IntPtr hWndColHd = NativeMethods.FindWindowEx(hWndLV, IntPtr.Zero, "SysHeader32", IntPtr.Zero);
					NMHEADER NMH = default(NMHEADER);
					NMH.hdr.hwndFrom = hWndColHd;
					NMH.hdr.code = (uint)HDN_ITEMCLICKW;
					NMH.iItem = index;
					NMH.iButton = 0;
					IntPtr ptrNMH = Marshal.AllocHGlobal(Marshal.SizeOf<NMHEADER>(NMH));
					try
					{
						Marshal.StructureToPtr<NMHEADER>(NMH, ptrNMH, false);
						NativeMethods.SendMessage(new HandleRef(this, hWndLV), 78u, IntPtr.Zero, ptrNMH);
						NativeMethods.SendMessage(new HandleRef(this, hWndLV), 78u, IntPtr.Zero, ptrNMH);
					}
					finally
					{
						Marshal.FreeHGlobal(ptrNMH);
					}
				}
			}
			catch
			{
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (base.IsDisposed)
			{
				return;
			}
			if (this.MSDialog != null)
			{
				this.MSDialog.FileOk -= this.FileDialogControlBase_ClosingDialog;
				this.MSDialog.Disposed -= this.FileDialogControlBase_DialogDisposed;
				this.MSDialog.HelpRequest -= this.FileDialogControlBase_HelpRequest;
				this.MSDialog.Dispose();
				this.MSDialog = null;
			}
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		public virtual void OnFileNameChanged(IWin32Window sender, string fileName)
		{
			if (this.EventFileNameChanged != null)
			{
				this.EventFileNameChanged(sender, fileName);
			}
		}

		public void OnFolderNameChanged(IWin32Window sender, string folderName)
		{
			if (this.EventFolderNameChanged != null)
			{
				this.EventFolderNameChanged(sender, folderName);
			}
			this.UpdateListView();
		}

		private void UpdateListView()
		{
			this._hListViewPtr = NativeMethods.GetDlgItem(this._hFileDialogHandle, 1121);
			if (this.FileDlgDefaultViewMode != FolderViewMode.Default && this._hFileDialogHandle != IntPtr.Zero)
			{
				NativeMethods.SendMessage(new HandleRef(this, this._hListViewPtr), 273u, (IntPtr)((int)this.FileDlgDefaultViewMode), IntPtr.Zero);
				if (this.FileDlgDefaultViewMode == FolderViewMode.Details || this.FileDlgDefaultViewMode == FolderViewMode.List)
				{
					this.SortViewByColumn(0);
				}
			}
		}

		internal void OnFilterChanged(IWin32Window sender, int index)
		{
			if (this.EventFilterChanged != null)
			{
				this.EventFilterChanged(sender, index);
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			if (base.DesignMode)
			{
				Graphics gr = e.Graphics;
				HatchBrush hb = null;
				Pen p = null;
				try
				{
					switch (this.FileDlgStartLocation)
					{
					case AddonWindowLocation.Right:
						hb = new HatchBrush(HatchStyle.NarrowHorizontal, Color.Black, Color.Red);
						p = new Pen(hb, 5f);
						gr.DrawLine(p, 0, 0, 0, base.Height);
						goto IL_CF;
					case AddonWindowLocation.Bottom:
						hb = new HatchBrush(HatchStyle.NarrowVertical, Color.Black, Color.Red);
						p = new Pen(hb, 5f);
						gr.DrawLine(p, 0, 0, base.Width, 0);
						goto IL_CF;
					}
					hb = new HatchBrush(HatchStyle.Sphere, Color.Black, Color.Red);
					p = new Pen(hb, 5f);
					gr.DrawLine(p, 0, 0, 4, 4);
				}
				finally
				{
					if (p != null)
					{
						p.Dispose();
					}
					if (hb != null)
					{
						hb.Dispose();
					}
				}
			}
			IL_CF:
			base.OnPaint(e);
		}

		public DialogResult ShowDialog()
		{
			return this.ShowDialog(null);
		}

		protected virtual void OnPrepareMSDialog()
		{
			this.InitMSDialog();
		}

		private void InitMSDialog()
		{
			this.MSDialog.InitialDirectory = ((this._InitialDirectory.Length == 0) ? Path.GetDirectoryName(Application.ExecutablePath) : this._InitialDirectory);
			this.MSDialog.AddExtension = this._AddExtension;
			this.MSDialog.Filter = this._Filter;
			this.MSDialog.FilterIndex = this._FilterIndex;
			this.MSDialog.CheckFileExists = this._CheckFileExists;
			this.MSDialog.DefaultExt = this._DefaultExt;
			this.MSDialog.FileName = this._FileName;
			this.MSDialog.DereferenceLinks = this._DereferenceLinks;
			this.MSDialog.ShowHelp = this._ShowHelp;
			this._hasRunInitMSDialog = true;
		}

		public DialogResult ShowDialog(IWin32Window owner)
		{
			DialogResult returnDialogResult = DialogResult.Cancel;
			if (base.IsDisposed)
			{
				return returnDialogResult;
			}
			if (owner == null || owner.Handle == IntPtr.Zero)
			{
				owner = new FileDialogControlBase.WindowWrapper(Process.GetCurrentProcess().MainWindowHandle);
			}
			this.OriginalCtrlSize = base.Size;
            _MSdialog = (FileDlgType == FileDialogType.OpenFileDlg) ? new OpenFileDialog() as FileDialog : new SaveFileDialog() as FileDialog;
            this._dlgWrapper = new FileDialogControlBase.WholeDialogWrapper(this);
			this.OnPrepareMSDialog();
			if (!this._hasRunInitMSDialog)
			{
				this.InitMSDialog();
			}
			try
			{
				PropertyInfo AutoUpgradeInfo = this.MSDialog.GetType().GetProperty("AutoUpgradeEnabled");
				if (AutoUpgradeInfo != null)
				{
					AutoUpgradeInfo.SetValue(this.MSDialog, false, null);
				}
				returnDialogResult = this._MSdialog.ShowDialog(owner);
			}
			catch (ObjectDisposedException)
			{
			}
			catch (Exception ex)
			{
				MessageBox.Show("unable to get the modal dialog handle", ex.Message);
			}
			return returnDialogResult;
		}

		internal DialogResult ShowDialogExt(FileDialog fdlg, IWin32Window owner)
		{
			DialogResult returnDialogResult = DialogResult.Cancel;
			if (base.IsDisposed)
			{
				return returnDialogResult;
			}
			if (owner == null || owner.Handle == IntPtr.Zero)
			{
				owner = new FileDialogControlBase.WindowWrapper(Process.GetCurrentProcess().MainWindowHandle);
			}
			this.OriginalCtrlSize = base.Size;
			this.MSDialog = fdlg;
			this._dlgWrapper = new FileDialogControlBase.WholeDialogWrapper(this);
			try
			{
				PropertyInfo AutoUpgradeInfo = this.MSDialog.GetType().GetProperty("AutoUpgradeEnabled");
				if (AutoUpgradeInfo != null)
				{
					AutoUpgradeInfo.SetValue(this.MSDialog, false, null);
				}
				returnDialogResult = this._MSdialog.ShowDialog(owner);
			}
			catch (ObjectDisposedException)
			{
			}
			catch (Exception ex)
			{
				MessageBox.Show("unable to get the modal dialog handle", ex.Message);
			}
			return returnDialogResult;
		}

		private void FileDialogControlBase_DialogDisposed(object sender, EventArgs e)
		{
			this.Dispose(true);
		}

		private void FileDialogControlBase_ClosingDialog(object sender, CancelEventArgs e)
		{
			if (this.EventClosingDialog != null)
			{
				this.EventClosingDialog(this, e);
			}
		}

		private void FileDialogControlBase_HelpRequest(object sender, EventArgs e)
		{
			this.OnHelpRequested(new HelpEventArgs(default(Point)));
		}

		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.Name = "FileDialogControlBase";
			base.Size = new Size(555, 385);
			base.ResumeLayout(false);
		}

		private const SetWindowPosFlags UFLAGSHIDE = SetWindowPosFlags.SWP_NOSIZE | SetWindowPosFlags.SWP_NOMOVE | SetWindowPosFlags.SWP_NOACTIVATE | SetWindowPosFlags.SWP_HIDEWINDOW | SetWindowPosFlags.SWP_NOOWNERZORDER;

		private FileDialog _MSdialog;

		private NativeWindow _dlgWrapper;

		private AddonWindowLocation _StartLocation = AddonWindowLocation.Right;

		private FolderViewMode _DefaultViewMode = FolderViewMode.Default;

		private IntPtr _hFileDialogHandle = IntPtr.Zero;

		private FileDialogType _FileDlgType;

		private string _InitialDirectory = string.Empty;

		private string _Filter = "All files (*.*)|*.*";

		private string _DefaultExt = "jpg";

		private string _FileName = string.Empty;

		private string _Caption = "Save";

		private string _OKCaption = "&Open";

		private int _FilterIndex = 1;

		private bool _AddExtension = true;

		private bool _CheckFileExists = true;

		private bool _EnableOkBtn = true;

		private bool _DereferenceLinks = true;

		private bool _ShowHelp;

		private RECT _OpenDialogWindowRect;

		private IntPtr _hOKButton = IntPtr.Zero;

		private bool _hasRunInitMSDialog;

		private IntPtr _hListViewPtr;

		private static uint _originalDlgHeight;

		private static uint _originalDlgWidth;

		private Size _OriginalCtrlSize;

		private IContainer components;

		public delegate void PathChangedEventHandler(IWin32Window sender, string filePath);

		public delegate void FilterChangedEventHandler(IWin32Window sender, int index);

		public class WindowWrapper : IWin32Window
		{
			public WindowWrapper(IntPtr handle)
			{
				this._hwnd = handle;
			}

			public IntPtr Handle
			{
				get
				{
					return this._hwnd;
				}
			}

			private IntPtr _hwnd;
		}

		private class MSFileDialogWrapper : NativeWindow, IDisposable
		{
			public MSFileDialogWrapper(FileDialogControlBase fd)
			{
				this._CustomCtrl = fd;
				if (this._CustomCtrl != null)
				{
					fd.MSDialog.Disposed += this.NativeDialogWrapper_Disposed;
				}
			}

			private void NativeDialogWrapper_Disposed(object sender, EventArgs e)
			{
				this.Dispose();
			}

			public void Dispose()
			{
				if (this._CustomCtrl != null)
				{
					if (this._CustomCtrl.MSDialog != null)
					{
						this._CustomCtrl.MSDialog.Disposed -= this.NativeDialogWrapper_Disposed;
						this._CustomCtrl.MSDialog.Dispose();
						if (this._CustomCtrl != null)
						{
							this._CustomCtrl.MSDialog = null;
						}
					}
					if (this._CustomCtrl != null)
					{
						if (!this._CustomCtrl.IsDisposed)
						{
							this._CustomCtrl.Dispose();
						}
						this._CustomCtrl = null;
					}
				}
				this.DestroyHandle();
			}

			protected override void WndProc(ref Message m)
			{
				Msg msg = (Msg)m.Msg;
				if (msg != Msg.WM_NOTIFY)
				{
					if (msg == Msg.WM_COMMAND)
					{
						int dlgCtrlID = NativeMethods.GetDlgCtrlID(m.LParam);
						if (dlgCtrlID == 1 || dlgCtrlID != 2)
						{
						}
					}
				}
				else
				{
					OFNOTIFY ofNotify = (OFNOTIFY)Marshal.PtrToStructure(m.LParam, typeof(OFNOTIFY));
					switch (ofNotify.hdr.code)
					{
					case 4294966689u:
					{
						int i = ((OPENFILENAME)Marshal.PtrToStructure(ofNotify.OpenFileName, typeof(OPENFILENAME))).nFilterIndex;
						if (this._CustomCtrl != null && this._filterIndex != i)
						{
							this._filterIndex = i;
							this._CustomCtrl.OnFilterChanged(this, i);
						}
						break;
					}
					case 4294966693u:
					{
						StringBuilder folderPath = new StringBuilder(256);
						NativeMethods.SendMessage(new HandleRef(this, NativeMethods.GetParent(base.Handle)), 1126u, (IntPtr)256, folderPath);
						if (this._CustomCtrl != null)
						{
							this._CustomCtrl.OnFolderNameChanged(this, folderPath.ToString());
						}
						break;
					}
					case 4294966694u:
					{
						StringBuilder filePath = new StringBuilder(256);
						NativeMethods.SendMessage(new HandleRef(this, NativeMethods.GetParent(base.Handle)), 1125u, (IntPtr)256, filePath);
						if (this._CustomCtrl != null)
						{
							this._CustomCtrl.OnFileNameChanged(this, filePath.ToString());
						}
						break;
					}
					}
				}
				base.WndProc(ref m);
			}

			public const SetWindowPosFlags UFLAGSSIZE = SetWindowPosFlags.SWP_NOMOVE | SetWindowPosFlags.SWP_NOACTIVATE | SetWindowPosFlags.SWP_NOOWNERZORDER;

			private int _filterIndex;

			private FileDialogControlBase _CustomCtrl;
		}

		private class WholeDialogWrapper : NativeWindow, IDisposable
		{
			public WholeDialogWrapper(FileDialogControlBase fileDialogEx)
			{
				this._CustomControl = fileDialogEx;
				this.AssignDummyWindow();
				this._WatchForActivate = true;
			}

			private void AssignDummyWindow()
			{
				this._hDummyWnd = NativeMethods.CreateWindowEx(0u, "Message", null, 268435456u, 0, 0, 0, 0, FileDialogControlBase.WholeDialogWrapper.HWND_MESSAGE, FileDialogControlBase.WholeDialogWrapper.NULL, FileDialogControlBase.WholeDialogWrapper.NULL, FileDialogControlBase.WholeDialogWrapper.NULL);
				if (this._hDummyWnd == FileDialogControlBase.WholeDialogWrapper.NULL || !NativeMethods.IsWindow(this._hDummyWnd))
				{
					throw new ApplicationException("Unable to create a dummy window");
				}
				base.AssignHandle(this._hDummyWnd);
			}

			public void Dispose()
			{
				if (this._CustomControl != null && !this._CustomControl.IsDisposed)
				{
					if (this._CustomControl.MSDialog != null)
					{
						this._CustomControl.MSDialog.Disposed -= this.DialogWrappper_Disposed;
						this._CustomControl.MSDialog.Dispose();
					}
					if (this._CustomControl != null)
					{
						this._CustomControl.MSDialog = null;
						this._CustomControl.Dispose();
					}
					this._CustomControl = null;
				}
				if (this._BaseDialogNative != null)
				{
					this._BaseDialogNative.Dispose();
					this._BaseDialogNative = null;
				}
				if (this._hDummyWnd != IntPtr.Zero)
				{
					NativeMethods.DestroyWindow(this._hDummyWnd);
					this.DestroyHandle();
					this._hDummyWnd = IntPtr.Zero;
				}
			}

			private void PopulateWindowsHandlers()
			{
				NativeMethods.EnumChildWindows(new HandleRef(this, this._hFileDialogHandle), new NativeMethods.EnumWindowsCallBack(this.FileDialogEnumWindowCallBack), 0);
			}

			private bool FileDialogEnumWindowCallBack(IntPtr hwnd, int lParam)
			{
				StringBuilder className = new StringBuilder(256);
				NativeMethods.GetClassName(new HandleRef(this, hwnd), className, className.Capacity);
				int controlID = NativeMethods.GetDlgCtrlID(hwnd);
				WINDOWINFO windowInfo;
				NativeMethods.GetWindowInfo(new HandleRef(this, hwnd), out windowInfo);
				if (className.ToString().StartsWith("#32770"))
				{
					this._BaseDialogNative = new FileDialogControlBase.MSFileDialogWrapper(this._CustomControl);
					this._BaseDialogNative.AssignHandle(hwnd);
					return true;
				}
				ControlsId controlsId = (ControlsId)controlID;
				if (controlsId <= ControlsId.LabelFileName)
				{
					if (controlsId <= ControlsId.ButtonCancel)
					{
						if (controlsId != ControlsId.ButtonOk)
						{
							if (controlsId == ControlsId.ButtonCancel)
							{
								this._hCancelButton = hwnd;
								this._CancelButtonInfo = windowInfo;
							}
						}
						else
						{
							this._hOKButton = hwnd;
							this._OKButtonInfo = windowInfo;
							this._CustomControl._hOKButton = hwnd;
						}
					}
					else if (controlsId != ControlsId.ButtonHelp)
					{
						if (controlsId != ControlsId.CheckBoxReadOnly)
						{
							switch (controlsId)
							{
							case ControlsId.GroupFolder:
								this._hGroupButtons = hwnd;
								this._GroupButtonsInfo = windowInfo;
								break;
							case ControlsId.LabelFileType:
								this._hLabelFileType = hwnd;
								this._LabelFileTypeInfo = windowInfo;
								break;
							case ControlsId.LabelFileName:
								this._hLabelFileName = hwnd;
								this._LabelFileNameInfo = windowInfo;
								break;
							}
						}
						else
						{
							this._hChkReadOnly = hwnd;
							this._ChkReadOnlyInfo = windowInfo;
						}
					}
					else
					{
						this._hHelpButton = hwnd;
						this._HelpButtonInfo = windowInfo;
					}
				}
				else if (controlsId <= ControlsId.ComboFileType)
				{
					if (controlsId != ControlsId.DefaultView)
					{
						if (controlsId == ControlsId.ComboFileType)
						{
							this._hComboExtensions = hwnd;
							this._ComboExtensionsInfo = windowInfo;
						}
					}
					else
					{
						this._CustomControl._hListViewPtr = hwnd;
						NativeMethods.GetWindowInfo(new HandleRef(this, hwnd), out this._ListViewInfo);
						this._CustomControl.UpdateListView();
					}
				}
				else if (controlsId != ControlsId.ComboFolder)
				{
					if (controlsId != ControlsId.ComboFileName)
					{
						if (controlsId == ControlsId.LeftToolBar)
						{
							this._hToolBarFolders = hwnd;
							this._ToolBarFoldersInfo = windowInfo;
						}
					}
					else if (className.ToString().ToLower() == "comboboxex32")
					{
						this._hComboFileName = hwnd;
						this._ComboFileNameInfo = windowInfo;
					}
				}
				else
				{
					this._ComboFolders = hwnd;
					this._ComboFoldersInfo = windowInfo;
				}
				return true;
			}

			private void InitControls()
			{
				this.mInitializated = true;
				NativeMethods.GetClientRect(new HandleRef(this, this._hFileDialogHandle), ref this._DialogClientRect);
				NativeMethods.GetWindowRect(new HandleRef(this, this._hFileDialogHandle), ref this._DialogWindowRect);
				this.PopulateWindowsHandlers();
				switch (this._CustomControl.FileDlgStartLocation)
				{
				case AddonWindowLocation.BottomRight:
					this._CustomControl.Location = new Point((int)((ulong)this._DialogClientRect.Width - (ulong)((long)this._CustomControl.Width)), (int)((ulong)this._DialogClientRect.Height - (ulong)((long)this._CustomControl.Height)));
					break;
				case AddonWindowLocation.Right:
					this._CustomControl.Location = new Point((int)((ulong)this._DialogClientRect.Width - (ulong)((long)this._CustomControl.Width)), 0);
					break;
				case AddonWindowLocation.Bottom:
					this._CustomControl.Location = new Point(0, (int)((ulong)this._DialogClientRect.Height - (ulong)((long)this._CustomControl.Height)));
					break;
				}
				NativeMethods.SetParent(new HandleRef(this._CustomControl, this._CustomControl.Handle), new HandleRef(this, this._hFileDialogHandle));
				this._CustomControl.MSDialog.Disposed += this.DialogWrappper_Disposed;
			}

			private void DialogWrappper_Disposed(object sender, EventArgs e)
			{
				this.Dispose();
			}

			protected override void WndProc(ref Message m)
			{
				RECT currentSize = default(RECT);
				Msg msg = (Msg)m.Msg;
				if (msg <= Msg.WM_SHOWWINDOW)
				{
					if (msg <= Msg.WM_SIZE)
					{
						if (msg != Msg.WM_CREATE)
						{
							if (msg == Msg.WM_SIZE)
							{
								NativeMethods.GetClientRect(new HandleRef(this, this._hFileDialogHandle), ref currentSize);
								AddonWindowLocation fileDlgStartLocation = this._CustomControl.FileDlgStartLocation;
								if (fileDlgStartLocation != AddonWindowLocation.Right)
								{
									if (fileDlgStartLocation == AddonWindowLocation.Bottom)
									{
										if (!this.mInitializated && FileDialogControlBase.OriginalDlgWidth == 0u)
										{
											FileDialogControlBase.OriginalDlgWidth = currentSize.Width;
										}
										if ((ulong)currentSize.Width != (ulong)((long)this._CustomControl.Width))
										{
											this._CustomControl.Width = (int)currentSize.Width;
										}
									}
								}
								else
								{
									if (!this.mInitializated && FileDialogControlBase.OriginalDlgHeight == 0u)
									{
										FileDialogControlBase.OriginalDlgHeight = currentSize.Height;
									}
									if ((ulong)currentSize.Height != (ulong)((long)this._CustomControl.Height))
									{
										this._CustomControl.Height = (int)currentSize.Height;
									}
								}
							}
						}
					}
					else if (msg != Msg.WM_ACTIVATE)
					{
						if (msg != Msg.WM_PAINT)
						{
							if (msg == Msg.WM_SHOWWINDOW)
							{
								this.InitControls();
								NativeMethods.GetWindowRect(new HandleRef(this, this._hFileDialogHandle), ref currentSize);
								int top = (this._CustomControl.Parent == null) ? currentSize.top : this._CustomControl.Parent.Top;
								int right = (this._CustomControl.Parent == null) ? currentSize.right : this._CustomControl.Parent.Right;
								RECT currentClientSize = default(RECT);
								NativeMethods.GetClientRect(new HandleRef(this, this._hFileDialogHandle), ref currentClientSize);
								int dy = (int)(currentSize.Height - currentClientSize.Height);
								int dx = (int)(currentSize.Width - currentClientSize.Width);
								AddonWindowLocation fileDlgStartLocation = this._CustomControl.FileDlgStartLocation;
								if (fileDlgStartLocation != AddonWindowLocation.Right)
								{
									if (fileDlgStartLocation == AddonWindowLocation.Bottom)
									{
										int Width = Math.Max(this._CustomControl.OriginalCtrlSize.Width + dx, (int)FileDialogControlBase.OriginalDlgWidth);
										NativeMethods.SetWindowPos(this._hFileDialogHandle, (IntPtr)1, right, top, Width, (int)currentSize.Height, SetWindowPosFlags.SWP_NOMOVE | SetWindowPosFlags.SWP_NOZORDER);
									}
								}
								else
								{
									int Height = Math.Max(this._CustomControl.OriginalCtrlSize.Height + dy, (int)FileDialogControlBase.OriginalDlgHeight);
									NativeMethods.SetWindowPos(this._hFileDialogHandle, (IntPtr)1, right, top, (int)currentSize.Width, Height, SetWindowPosFlags.SWP_NOMOVE | SetWindowPosFlags.SWP_NOZORDER);
								}
							}
						}
					}
					else if (this._WatchForActivate && !this.mIsClosing)
					{
						this._WatchForActivate = false;
						this._hFileDialogHandle = m.LParam;
						this.ReleaseHandle();
						base.AssignHandle(this._hFileDialogHandle);
						NativeMethods.GetWindowRect(new HandleRef(this, this._hFileDialogHandle), ref this._CustomControl._OpenDialogWindowRect);
						this._CustomControl._hFileDialogHandle = this._hFileDialogHandle;
					}
				}
				else if (msg <= Msg.WM_NCCREATE)
				{
					if (msg != Msg.WM_WINDOWPOSCHANGING)
					{
						if (msg != Msg.WM_NCCREATE)
						{
						}
					}
					else if (!this.mIsClosing && !this.mInitializated && !this.mResized)
					{
						WINDOWPOS pos = (WINDOWPOS)Marshal.PtrToStructure(m.LParam, typeof(WINDOWPOS));
						if (pos.flags != 0u && (pos.flags & 1u) != 1u)
						{
							switch (this._CustomControl.FileDlgStartLocation)
							{
							case AddonWindowLocation.BottomRight:
								this.mOriginalSize = new Size(pos.cx, pos.cy);
								pos.cy += this._CustomControl.Height;
								pos.cx += this._CustomControl.Width;
								Marshal.StructureToPtr<WINDOWPOS>(pos, m.LParam, true);
								break;
							case AddonWindowLocation.Right:
								this.mOriginalSize = new Size(pos.cx, pos.cy);
								pos.cx += this._CustomControl.Width;
								Marshal.StructureToPtr<WINDOWPOS>(pos, m.LParam, true);
								currentSize = default(RECT);
								NativeMethods.GetClientRect(new HandleRef(this, this._hFileDialogHandle), ref currentSize);
								if (this._CustomControl.Height < (int)currentSize.Height)
								{
									this._CustomControl.Height = (int)currentSize.Height;
								}
								break;
							case AddonWindowLocation.Bottom:
								this.mOriginalSize = new Size(pos.cx, pos.cy);
								pos.cy += this._CustomControl.Height;
								Marshal.StructureToPtr<WINDOWPOS>(pos, m.LParam, true);
								currentSize = default(RECT);
								NativeMethods.GetClientRect(new HandleRef(this, this._hFileDialogHandle), ref currentSize);
								if (this._CustomControl.Width < (int)currentSize.Width)
								{
									this._CustomControl.Width = (int)currentSize.Width;
								}
								break;
							}
							this.mResized = true;
						}
					}
				}
				else if (msg != Msg.WM_COMMAND)
				{
					if (msg != Msg.WM_SIZING)
					{
						if (msg == Msg.WM_IME_NOTIFY)
						{
							if (m.WParam == (IntPtr)1)
							{
								this.mIsClosing = true;
								NativeMethods.SetWindowPos(this._hFileDialogHandle, IntPtr.Zero, 0, 0, 0, 0, SetWindowPosFlags.SWP_NOSIZE | SetWindowPosFlags.SWP_NOMOVE | SetWindowPosFlags.SWP_NOACTIVATE | SetWindowPosFlags.SWP_HIDEWINDOW | SetWindowPosFlags.SWP_NOOWNERZORDER);
								NativeMethods.GetWindowRect(new HandleRef(this, this._hFileDialogHandle), ref this._DialogWindowRect);
								NativeMethods.SetWindowPos(this._hFileDialogHandle, IntPtr.Zero, this._DialogWindowRect.left, this._DialogWindowRect.top, this.mOriginalSize.Width, this.mOriginalSize.Height, SetWindowPosFlags.SWP_NOMOVE | SetWindowPosFlags.SWP_NOACTIVATE | SetWindowPosFlags.SWP_NOOWNERZORDER);
							}
						}
					}
					else
					{
						NativeMethods.GetClientRect(new HandleRef(this, this._hFileDialogHandle), ref currentSize);
						switch (this._CustomControl.FileDlgStartLocation)
						{
						case AddonWindowLocation.BottomRight:
							if ((ulong)currentSize.Width != (ulong)((long)this._CustomControl.Width) || (ulong)currentSize.Height != (ulong)((long)this._CustomControl.Height))
							{
								NativeMethods.SetWindowPos(this._CustomControl.Handle, (IntPtr)1, (int)currentSize.Width, (int)currentSize.Height, (int)currentSize.Width, (int)currentSize.Height, SetWindowPosFlags.SWP_NOMOVE | SetWindowPosFlags.SWP_NOACTIVATE | SetWindowPosFlags.SWP_NOOWNERZORDER | SetWindowPosFlags.SWP_DEFERERASE | SetWindowPosFlags.SWP_ASYNCWINDOWPOS);
							}
							break;
						case AddonWindowLocation.Right:
							if ((ulong)currentSize.Height != (ulong)((long)this._CustomControl.Height))
							{
								NativeMethods.SetWindowPos(this._CustomControl.Handle, (IntPtr)1, 0, 0, this._CustomControl.Width, (int)currentSize.Height, SetWindowPosFlags.SWP_NOMOVE | SetWindowPosFlags.SWP_NOACTIVATE | SetWindowPosFlags.SWP_NOOWNERZORDER | SetWindowPosFlags.SWP_DEFERERASE | SetWindowPosFlags.SWP_ASYNCWINDOWPOS);
							}
							break;
						case AddonWindowLocation.Bottom:
							if ((ulong)currentSize.Height != (ulong)((long)this._CustomControl.Height))
							{
								NativeMethods.SetWindowPos(this._CustomControl.Handle, (IntPtr)1, 0, 0, (int)currentSize.Width, this._CustomControl.Height, SetWindowPosFlags.SWP_NOMOVE | SetWindowPosFlags.SWP_NOACTIVATE | SetWindowPosFlags.SWP_NOOWNERZORDER | SetWindowPosFlags.SWP_DEFERERASE | SetWindowPosFlags.SWP_ASYNCWINDOWPOS);
							}
							break;
						}
					}
				}
				else
				{
					switch (NativeMethods.GetDlgCtrlID(m.LParam))
					{
					}
				}
				base.WndProc(ref m);
			}

			private const SetWindowPosFlags UFLAGSSIZEEX = SetWindowPosFlags.SWP_NOMOVE | SetWindowPosFlags.SWP_NOACTIVATE | SetWindowPosFlags.SWP_NOOWNERZORDER | SetWindowPosFlags.SWP_DEFERERASE | SetWindowPosFlags.SWP_ASYNCWINDOWPOS;

			private const SetWindowPosFlags UFLAGSHIDE = SetWindowPosFlags.SWP_NOSIZE | SetWindowPosFlags.SWP_NOMOVE | SetWindowPosFlags.SWP_NOACTIVATE | SetWindowPosFlags.SWP_HIDEWINDOW | SetWindowPosFlags.SWP_NOOWNERZORDER;

			private const SetWindowPosFlags UFLAGSZORDER = SetWindowPosFlags.SWP_NOSIZE | SetWindowPosFlags.SWP_NOMOVE | SetWindowPosFlags.SWP_NOACTIVATE;

			private const uint WS_VISIBLE = 268435456u;

			private static readonly IntPtr HWND_MESSAGE = new IntPtr(-3);

			private static readonly IntPtr NULL = IntPtr.Zero;

			private IntPtr _hDummyWnd = FileDialogControlBase.WholeDialogWrapper.NULL;

			private bool mResized;

			private FileDialogControlBase _CustomControl;

			private bool _WatchForActivate;

			private Size mOriginalSize;

			private IntPtr _hFileDialogHandle;

			private WINDOWINFO _ListViewInfo;

			private FileDialogControlBase.MSFileDialogWrapper _BaseDialogNative;

			private IntPtr _ComboFolders;

			private WINDOWINFO _ComboFoldersInfo;

			private IntPtr _hGroupButtons;

			private WINDOWINFO _GroupButtonsInfo;

			private IntPtr _hComboFileName;

			private WINDOWINFO _ComboFileNameInfo;

			private IntPtr _hComboExtensions;

			private WINDOWINFO _ComboExtensionsInfo;

			private IntPtr _hOKButton;

			private WINDOWINFO _OKButtonInfo;

			private IntPtr _hCancelButton;

			private WINDOWINFO _CancelButtonInfo;

			private IntPtr _hHelpButton;

			private WINDOWINFO _HelpButtonInfo;

			private IntPtr _hToolBarFolders;

			private WINDOWINFO _ToolBarFoldersInfo;

			private IntPtr _hLabelFileName;

			private WINDOWINFO _LabelFileNameInfo;

			private IntPtr _hLabelFileType;

			private WINDOWINFO _LabelFileTypeInfo;

			private IntPtr _hChkReadOnly;

			private WINDOWINFO _ChkReadOnlyInfo;

			private bool mIsClosing;

			private bool mInitializated;

			private RECT _DialogWindowRect;

			private RECT _DialogClientRect;
		}
	}
}
