using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Vegapad.Properties;
using Win32Types;

namespace Vegapad
{
	public partial class Main : Form
	{
		public Main()
		{
			this.InitializeComponent();
			if (!Main.Settings.WindowPosition.IsEmpty)
			{
				base.Bounds = Main.Settings.WindowPosition;
				base.StartPosition = FormStartPosition.Manual;
			}
		}

		public string Filename
		{
			get
			{
				return this._Filename;
			}
			set
			{
				this._Filename = value;
				this.OnFilenameChanged(value, value);
			}
		}

		private void OnFilenameChanged(string oldvalue, string value)
		{
			this.OnDocumentNameChanged();
		}

		private void OnDocumentNameChanged()
		{
			this.UpdateTitle();
		}

		private void UpdateTitle()
		{
			if (base.Tag == null)
			{
				base.Tag = base.Text;
			}
			base.Text = ((string)base.Tag).FormatUsingObject(new
			{
				this.DocumentName
			});
		}

		public string DocumentName
		{
			get
			{
				if (this.Filename == null)
				{
					return "Untitled";
				}
				return Path.GetFileName(this.Filename);
			}
		}

		public string Content
		{
			get
			{
				return this.controlContentTextBox.Text;
			}
			set
			{
				this.controlContentTextBox.Text = value;
			}
		}

		private void controlContentTextBox_TextChanged(object sender, EventArgs e)
		{
			this.IsDirty = true;
		}

		private void Main_Load(object sender, EventArgs e)
		{
			this.UpdateTitle();
			this.menuitemFormatWordWrap.Checked = this.controlContentTextBox.WordWrap;
			this.CurrentFont = Main.Settings.CurrentFont;
			this.UpdateStatusBar();
			this.menuitemViewStatusBar.Checked = (this.controlStatusBar.Visible = Main.Settings.IsStatusBarVisible);
			this.controlContentTextBox.BringToFront();
		}

		public bool IsStatusBarVisible
		{
			get
			{
				return Main.Settings.IsStatusBarVisible;
			}
			set
			{
				ToolStripMenuItem toolStripMenuItem = this.menuitemViewStatusBar;
				Control control = this.controlStatusBar;
				Main.Settings.IsStatusBarVisible = value;
				control.Visible = value;
				toolStripMenuItem.Checked = value;
				Main.Settings.Save();
			}
		}

		public bool WordWrap
		{
			get
			{
				return this.controlContentTextBox.WordWrap;
			}
			set
			{
				ToolStripMenuItem toolStripMenuItem = this.menuitemFormatWordWrap;
				this.controlContentTextBox.WordWrap = value;
				toolStripMenuItem.Checked = value;
			}
		}

		private void menuitemFormatWordWrap_Click(object sender, EventArgs e)
		{
			this.WordWrap = !this.WordWrap;
		}

		private void menuitemFormatWordWrap_CheckedChanged(object sender, EventArgs e)
		{
			ToolStripMenuItem Sender = (ToolStripMenuItem)sender;
			this.WordWrap = Sender.Checked;
		}

		private static Settings Settings
		{
			get
			{
				return Settings.Default;
			}
		}

		private Font CurrentFont
		{
			get
			{
				return Main.Settings.CurrentFont;
			}
			set
			{
				Control control = this.controlContentTextBox;
				Main.Settings.CurrentFont = value;
				control.Font = value;
				Main.Settings.Save();
			}
		}

		private void menuitemFormatFont_Click(object sender, EventArgs e)
		{
			FontDialog FontDialog = new FontDialog();
			FontDialog.Font = this.CurrentFont;
			if (FontDialog.ShowDialog(this) != DialogResult.OK)
			{
				return;
			}
			this.CurrentFont = FontDialog.Font;
		}

		public bool IsDirty
		{
			get
			{
				return (this.Filename != null || !this.Content.IsEmpty()) && this._IsDirty;
			}
			set
			{
				this._IsDirty = value;
			}
		}

		private bool Save()
		{
			if (!this.IsDirty)
			{
				return true;
			}
			if (this.Filename == null || new FileInfo(this.Filename).IsReadOnly)
			{
				return this.SaveAs();
			}
			File.WriteAllText(this.Filename, this.Content);
			this.IsDirty = false;
			return true;
		}

		private bool SaveAs()
		{
			SaveOpenDialog SaveDialog = new SaveOpenDialog();
			SaveDialog.FileDlgFileName = this.Filename;
			SaveDialog.FileDlgDefaultExt = ".txt";
			SaveDialog.FileDlgFilter = "Text Documents (*.txt)|*.txt|All Files (*.*)|*.*";
			SaveDialog.Encoding = this._encoding;
			SaveDialog.FileDlgCaption = "Save";
			SaveDialog.FileDlgOkCaption = "Save";
			if (SaveDialog.ShowDialog(this) != DialogResult.OK)
			{
				return false;
			}
			string PotentialFilename = SaveDialog.MSDialog.FileName;
			this._encoding = SaveDialog.Encoding;
			File.WriteAllText(PotentialFilename, this.Content, this._encoding);
			this.Filename = PotentialFilename;
			this.IsDirty = false;
			return true;
		}

		private void menuitemFileOpen_Click(object sender, EventArgs e)
		{
			if (!this.EnsureWorkNotLost())
			{
				return;
			}
			SaveOpenDialog OpenDialog = new SaveOpenDialog();
			OpenDialog.FileDlgDefaultExt = ".txt";
			OpenDialog.FileDlgFileName = this.Filename;
			OpenDialog.FileDlgFilter = "Text Documents (*.txt)|*.txt|All Files (*.*)|*.*";
			OpenDialog.FileDlgType = FileDialogType.OpenFileDlg;
			OpenDialog.FileDlgCaption = "Open";
			OpenDialog.FileDlgOkCaption = "Open";
			if (OpenDialog.ShowDialog(this) != DialogResult.OK)
			{
				return;
			}
			this.Open(OpenDialog.MSDialog.FileName, OpenDialog.Encoding);
		}

		public void Open(string pFilename, Encoding encoding = null)
		{
			string Filename = pFilename;
			if (!File.Exists(Filename))
			{
				bool FileExists = false;
				if (Path.GetExtension(Filename) == "")
				{
					Filename += ".txt";
					FileExists = File.Exists(Filename);
				}
				if (!FileExists)
				{
					DialogResult Result = MessageBox.Show("Cannot find the {Filename} file.\n\nDo you want to create a new file?\n".FormatUsingObject(new
					{
						Filename
					}), "Vegapad", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
					if (Result != DialogResult.Cancel)
					{
						if (Result == DialogResult.Yes)
						{
							File.WriteAllText(Filename, "");
							goto IL_74;
						}
						if (Result != DialogResult.No)
						{
							throw new Exception();
						}
					}
					return;
				}
			}
			IL_74:
			if (encoding == null)
			{
				using (StreamReader streamReader = new StreamReader(Filename, true))
				{
					streamReader.ReadToEnd();
					this._encoding = streamReader.CurrentEncoding;
				}
			}
			this.Content = Main.ReadAllText(Filename, encoding);
			this.SelectionStart = 0;
			this.Filename = Filename;
			this.IsDirty = false;
		}

		private static string ReadAllText(string pFilename, Encoding encoding)
		{
			string result;
			using (FileStream FileStream = new FileStream(pFilename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
			{
				if (encoding == null)
				{
					using (StreamReader StreamReader = new StreamReader(FileStream))
					{
						return StreamReader.ReadToEnd();
					}
				}
				using (StreamReader StreamReader2 = new StreamReader(FileStream, encoding, false))
				{
					result = StreamReader2.ReadToEnd();
				}
			}
			return result;
		}

		private void menuitemFileSave_Click(object sender, EventArgs e)
		{
			this.Save();
		}

		private void menuitemFileSaveAs_Click(object sender, EventArgs e)
		{
			this.SaveAs();
		}

		private void menuitemFileNew_Click(object sender, EventArgs e)
		{
			this.New();
		}

		private bool EnsureWorkNotLost()
		{
			if (!this.IsDirty)
			{
				return true;
			}
			DialogResult DialogResult = new SaveChangesPrompt(this.Filename).ShowDialog(this);
			if (DialogResult == DialogResult.Cancel)
			{
				return false;
			}
			if (DialogResult == DialogResult.Yes)
			{
				return this.Save();
			}
			if (DialogResult != DialogResult.No)
			{
				throw new Exception();
			}
			return true;
		}

		private bool New()
		{
			if (!this.EnsureWorkNotLost())
			{
				return false;
			}
			this.Filename = null;
			this.Content = "";
			this.IsDirty = false;
			this._encoding = Encoding.ASCII;
			return true;
		}

		private void menuitemFilePageSetup_Click(object sender, EventArgs e)
		{
			PageSetupDialog PageSetupDialog = new PageSetupDialog();
			PageSetupDialog.PageSettings = this.PageSettings;
			if (PageSetupDialog.ShowDialog(this) != DialogResult.OK)
			{
				return;
			}
			this.PageSettings = PageSetupDialog.PageSettings;
		}

		private PageSettings PageSettings
		{
			get
			{
				if (this._PageSettings == null)
				{
					if (Main.Settings.MoreSettings.PageSettings != null)
					{
						this._PageSettings = Main.Settings.MoreSettings.PageSettings;
					}
					else
					{
						PageSettings PageSettings = new PageSettings
						{
							Margins = new Margins(75, 75, 100, 100)
						};
						this._PageSettings = PageSettings;
					}
				}
				return this._PageSettings;
			}
			set
			{
				Main.Settings.MoreSettings.PageSettings = value;
				Main.Settings.Save();
			}
		}

		private void menuitemFilePrint_Click(object IGNORE_sender, EventArgs IGNORE_e)
		{
			PrintDialog PrintDialog = new PrintDialog();
			if (Main.Settings.MoreSettings.PrinterSettings != null)
			{
				PrintDialog.PrinterSettings = Main.Settings.MoreSettings.PrinterSettings;
			}
			if (PrintDialog.ShowDialog(this) != DialogResult.OK)
			{
				return;
			}
			Main.Settings.MoreSettings.PrinterSettings = PrintDialog.PrinterSettings;
			Main.Settings.Save();
			PrintDocument printDocument = new PrintDocument();
			printDocument.DefaultPageSettings = this.PageSettings;
			printDocument.PrinterSettings = Main.Settings.MoreSettings.PrinterSettings;
			printDocument.DocumentName = this.DocumentName + " - Vegapad";
			string RemainingContentToPrint = this.Content;
			int PageIndex = 0;
			printDocument.PrintPage += delegate(object sender, PrintPageEventArgs e)
			{
				Main.HeaderOrFooterInfo HeaderText = this.FormatHeaderFooterText(Main.Settings.Header, PageIndex);
				int Top = this.PageSettings.Margins.Top;
				this.DrawStringAtPosition(e.Graphics, HeaderText.Left, Top, Main.DrawStringPosition.Left);
				this.DrawStringAtPosition(e.Graphics, HeaderText.Center, Top, Main.DrawStringPosition.Center);
				this.DrawStringAtPosition(e.Graphics, HeaderText.Right, Top, Main.DrawStringPosition.Right);
				int CharactersFitted = 0;
				int LinesFilled = 0;
				RectangleF MarginBounds = new RectangleF((float)e.MarginBounds.X, (float)(e.MarginBounds.Y + this.CurrentFont.Height), (float)e.MarginBounds.Width, (float)(e.MarginBounds.Height - this.CurrentFont.Height * 2));
				e.Graphics.MeasureString(RemainingContentToPrint, this.CurrentFont, MarginBounds.Size, StringFormat.GenericTypographic, out CharactersFitted, out LinesFilled);
				e.Graphics.DrawString(RemainingContentToPrint, this.CurrentFont, Brushes.Black, MarginBounds, StringFormat.GenericTypographic);
				RemainingContentToPrint = RemainingContentToPrint.Substring(CharactersFitted);
				e.HasMorePages = (RemainingContentToPrint.Length > 0);
				Main.HeaderOrFooterInfo FooterText = this.FormatHeaderFooterText(Main.Settings.Footer, PageIndex);
				int Top2 = this.PageSettings.Bounds.Bottom - this.PageSettings.Margins.Bottom - this.CurrentFont.Height;
				this.DrawStringAtPosition(e.Graphics, FooterText.Left, Top2, Main.DrawStringPosition.Left);
				this.DrawStringAtPosition(e.Graphics, FooterText.Center, Top2, Main.DrawStringPosition.Center);
				this.DrawStringAtPosition(e.Graphics, FooterText.Right, Top2, Main.DrawStringPosition.Right);
				int pageIndex = PageIndex;
				PageIndex = pageIndex + 1;
			};
			printDocument.Print();
		}

		private void DrawStringAtPosition(Graphics pGraphics, string pText, int Top, Main.DrawStringPosition pPosition)
		{
			SizeF HeaderTextSize = new SizeF(pGraphics.MeasureString(pText, this.CurrentFont));
			float HeaderTextWidth = HeaderTextSize.Width;
			int PageWidth = this.PageSettings.Bounds.Right - this.PageSettings.Bounds.Left;
			float Left;
			if (pPosition == Main.DrawStringPosition.Left)
			{
				Left = (float)this.PageSettings.Margins.Left;
			}
			else if (pPosition == Main.DrawStringPosition.Center)
			{
				Left = ((float)PageWidth - HeaderTextWidth) / 2f;
			}
			else
			{
				if (pPosition != Main.DrawStringPosition.Right)
				{
					throw new Exception();
				}
				Left = (float)(PageWidth - this.PageSettings.Margins.Right) - HeaderTextWidth;
			}
			pGraphics.DrawString(pText, this.CurrentFont, Brushes.Black, Left, (float)Top);
		}

		private Main.HeaderOrFooterInfo FormatHeaderFooterText(string pText, int PageIndex)
		{
			Main.HeaderOrFooterInfo HeaderOrFooterInfo = Main.GetHeaderOrFooterInfo(pText);
			HeaderOrFooterInfo.Left = this.FormatSingleHeaderFooterText(HeaderOrFooterInfo.Left, PageIndex);
			HeaderOrFooterInfo.Center = this.FormatSingleHeaderFooterText(HeaderOrFooterInfo.Center, PageIndex);
			HeaderOrFooterInfo.Right = this.FormatSingleHeaderFooterText(HeaderOrFooterInfo.Right, PageIndex);
			return HeaderOrFooterInfo;
		}

		private string FormatSingleHeaderFooterText(string pText, int PageIndex)
		{
			return pText.Replace("&f", this.DocumentName).Replace("&p", (PageIndex + 1).ToString()).Replace("&d", DateTime.Now.ToLongDateString()).Replace("&t", DateTime.Now.ToLongTimeString());
		}

		private static Main.HeaderOrFooterInfo GetHeaderOrFooterInfo(string pText)
		{
			IEnumerable<int> indexes = Helper.GetIndexes(pText, "&l", false);
			List<int> CenterIndexes = Helper.GetIndexes(pText, "&c", false);
			List<int> RightIndexes = Helper.GetIndexes(pText, "&r", false);
			var SideInfos = (from o in (from o in indexes
			select new
			{
				Side = "Left",
				Index = o
			}).Union(from o in CenterIndexes
			select new
			{
				Side = "Center",
				Index = o
			}).Union(from o in RightIndexes
			select new
			{
				Side = "Right",
				Index = o
			})
			orderby o.Index
			select o).ToList();
			Main.HeaderOrFooterInfo HeaderOrFooterInfo = new Main.HeaderOrFooterInfo();
			if (SideInfos.Count == 0)
			{
				HeaderOrFooterInfo.Center = pText;
				return HeaderOrFooterInfo;
			}
			for (int i = 0; i < SideInfos.Count; i++)
			{
				var SideInfo = SideInfos[i];
				bool flag = i == 0;
				bool IsLastSideInfo = i == SideInfos.Count - 1;
				if (flag && SideInfo.Index != 0)
				{
					HeaderOrFooterInfo.Center = pText.Substring(0, SideInfo.Index - 1);
				}
				int StartIndex = SideInfo.Index + 2;
				int EndIndex;
				if (IsLastSideInfo)
				{
					EndIndex = pText.Length - 1;
				}
				else
				{
					EndIndex = SideInfos[i + 1].Index - 1;
				}
				int Length = EndIndex - StartIndex + 1;
				string Text = pText.Substring(StartIndex, Length);
				string side = SideInfo.Side;
				if (!(side == "Left"))
				{
					if (!(side == "Center"))
					{
						if (!(side == "Right"))
						{
							throw new Exception();
						}
						Main.HeaderOrFooterInfo headerOrFooterInfo = HeaderOrFooterInfo;
						headerOrFooterInfo.Right += Text;
					}
					else
					{
						Main.HeaderOrFooterInfo headerOrFooterInfo2 = HeaderOrFooterInfo;
						headerOrFooterInfo2.Center += Text;
					}
				}
				else
				{
					Main.HeaderOrFooterInfo headerOrFooterInfo3 = HeaderOrFooterInfo;
					headerOrFooterInfo3.Left += Text;
				}
			}
			return HeaderOrFooterInfo;
		}

		private void menuitemFileExit_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		private void menuitemEditUndo_Click(object sender, EventArgs e)
		{
			this.controlContentTextBox.Undo();
		}

		private void menuitemEditCut_Click(object sender, EventArgs e)
		{
			this.controlContentTextBox.Cut();
		}

		private void menuitemEditCopy_Click(object sender, EventArgs e)
		{
			this.controlContentTextBox.Copy();
		}

		private void menuitemEditPaste_Click(object sender, EventArgs e)
		{
			this.controlContentTextBox.Paste();
		}

		private void menuitemEditDelete_Click(object sender, EventArgs e)
		{
			if (this.SelectionLength == 0)
			{
				this.SelectionLength = 1;
			}
			this.SelectedText = "";
		}

		public string SelectedText
		{
			get
			{
				return this.controlContentTextBox.SelectedText;
			}
			set
			{
				this.controlContentTextBox.SelectedText = value;
				this.IsDirty = true;
			}
		}

		private void menuitemEditSelectAll_Click(object sender, EventArgs e)
		{
			this.controlContentTextBox.SelectAll();
		}

		private void menuitemEditTimeDate_Click(object sender, EventArgs e)
		{
			this.SelectedText = DateTime.Now.ToShortTimeString() + " " + DateTime.Now.ToShortDateString();
		}

		private void menuitemEditGoTo_Click(object sender, EventArgs e)
		{
			GoToLinePrompt GoToLinePrompt = new GoToLinePrompt(this.LineIndex + 1);
			GoToLinePrompt.Left = base.Left + 5;
			GoToLinePrompt.Top = base.Top + 44;
			if (GoToLinePrompt.ShowDialog(this) != DialogResult.OK)
			{
				return;
			}
			int TargetLineIndex = GoToLinePrompt.LineNumber - 1;
			if (TargetLineIndex > this.controlContentTextBox.Lines.Length)
			{
				MessageBox.Show(this, "The line number is beyond the total number of lines", "Vegapad - Goto Line");
				return;
			}
			this.LineIndex = TargetLineIndex;
		}

		private Main.ContentPosition CaretPosition
		{
			get
			{
				return this.CharIndexToPosition(this.SelectionStart);
			}
		}

		private Main.ContentPosition CharIndexToPosition(int pCharIndex)
		{
			int CurrentCharIndex = 0;
			if (this.controlContentTextBox.Lines.Length == 0 && CurrentCharIndex == 0)
			{
				return new Main.ContentPosition
				{
					LineIndex = 0,
					ColumnIndex = 0
				};
			}
			for (int CurrentLineIndex = 0; CurrentLineIndex < this.controlContentTextBox.Lines.Length; CurrentLineIndex++)
			{
				int LineStartCharIndex = CurrentCharIndex;
				string Line = this.controlContentTextBox.Lines[CurrentLineIndex];
				int LineEndCharIndex = LineStartCharIndex + Line.Length + 1;
				if (pCharIndex >= LineStartCharIndex && pCharIndex <= LineEndCharIndex)
				{
					int ColumnIndex = pCharIndex - LineStartCharIndex;
					return new Main.ContentPosition
					{
						LineIndex = CurrentLineIndex,
						ColumnIndex = ColumnIndex
					};
				}
				CurrentCharIndex += this.controlContentTextBox.Lines[CurrentLineIndex].Length + Environment.NewLine.Length;
			}
			return null;
		}

		private void UpdateStatusBar()
		{
			if (this.controlCaretPositionLabel.Tag == null)
			{
				this.controlCaretPositionLabel.Tag = this.controlCaretPositionLabel.Text;
			}
			this.controlCaretPositionLabel.Text = ((string)this.controlCaretPositionLabel.Tag).FormatUsingObject(new
			{
				LineNumber = this.CaretPosition.LineIndex + 1,
				ColumnNumber = this.CaretPosition.ColumnIndex + 1
			});
		}

		private int LineIndex
		{
			get
			{
				return this.CaretPosition.LineIndex;
			}
			set
			{
				int TargetLineIndex = value;
				if (TargetLineIndex < 0)
				{
					TargetLineIndex = 0;
				}
				if (TargetLineIndex >= this.controlContentTextBox.Lines.Length)
				{
					TargetLineIndex = this.controlContentTextBox.Lines.Length - 1;
				}
				int CharIndex = 0;
				for (int CurrentLineIndex = 0; CurrentLineIndex < TargetLineIndex; CurrentLineIndex++)
				{
					CharIndex += this.controlContentTextBox.Lines[CurrentLineIndex].Length + Environment.NewLine.Length;
				}
				this.SelectionStart = CharIndex;
				this.controlContentTextBox.ScrollToCaret();
			}
		}

		public int SelectionEnd
		{
			get
			{
				return this.SelectionStart + this.SelectionLength;
			}
		}

		public int SelectionStart
		{
			get
			{
				return this.controlContentTextBox.SelectionStart;
			}
			set
			{
				this.controlContentTextBox.SelectionStart = value;
				this.controlContentTextBox.ScrollToCaret();
			}
		}

		public int SelectionLength
		{
			get
			{
				return this.controlContentTextBox.SelectionLength;
			}
			set
			{
				this.controlContentTextBox.SelectionLength = value;
			}
		}

		private void menuitemAbout_Click(object sender, EventArgs e)
		{
			new About().ShowDialog(this);
		}

		private void controlContentTextBox_KeyDown(object sender, KeyEventArgs e)
		{
			this.UpdateStatusBar();
		}

		private void controlContentTextBox_KeyUp(object sender, KeyEventArgs e)
		{
			this.UpdateStatusBar();
		}

		private void menuitemViewStatusBar_Click(object sender, EventArgs e)
		{
			this.IsStatusBarVisible = !this.IsStatusBarVisible;
		}

		private void menuitemEdit_DropDownOpening(object sender, EventArgs e)
		{
			this.menuitemEditCut.Enabled = (this.menuitemEditCopy.Enabled = (this.menuitemEditDelete.Enabled = (this.SelectionLength > 0)));
			this.menuitemEditFind.Enabled = (this.menuitemEditFindNext.Enabled = (this.Content.Length > 0));
		}

		public bool FindAndSelect(string pSearchText, bool pMatchCase, bool pSearchDown)
		{
			StringComparison eStringComparison = pMatchCase ? StringComparison.CurrentCulture : StringComparison.CurrentCultureIgnoreCase;
			int Index;
			if (pSearchDown)
			{
				Index = this.Content.IndexOf(pSearchText, this.SelectionEnd, eStringComparison);
			}
			else
			{
				Index = this.Content.LastIndexOf(pSearchText, this.SelectionStart, this.SelectionStart, eStringComparison);
			}
			if (Index == -1)
			{
				return false;
			}
			this._LastSearchText = pSearchText;
			this._LastMatchCase = pMatchCase;
			this._LastSearchDown = pSearchDown;
			this.SelectionStart = Index;
			this.SelectionLength = pSearchText.Length;
			return true;
		}

		private void menuitemEditFind_Click(object sender, EventArgs e)
		{
			this.Find();
		}

		private void Find()
		{
			if (this.Content.Length == 0)
			{
				return;
			}
			if (this._FindDialog == null)
			{
				this._FindDialog = new FindDialog(this);
			}
			this._FindDialog.Left = base.Left + 56;
			this._FindDialog.Top = base.Top + 160;
			if (!this._FindDialog.Visible)
			{
				this._FindDialog.Show(this);
			}
			else
			{
				this._FindDialog.Show(null);
			}
			this._FindDialog.Triggered();
		}

		private void Main_FormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = !this.EnsureWorkNotLost();
		}

		private void menuitemEditFindNext_Click(object sender, EventArgs e)
		{
			if (this._LastSearchText == null)
			{
				this.Find();
				return;
			}
			if (!this.FindAndSelect(this._LastSearchText, this._LastMatchCase, this._LastSearchDown))
			{
				MessageBox.Show(this, "Cannot find \"{SearchText}\"".FormatUsingObject(new
				{
					SearchText = this._LastSearchText
				}), "Vegapad");
			}
		}

		private void menuitemEditReplace_Click(object sender, EventArgs e)
		{
			if (this.Content.Length == 0)
			{
				return;
			}
			if (this._ReplaceDialog == null)
			{
				this._ReplaceDialog = new ReplaceDialog(this);
			}
			this._ReplaceDialog.Left = base.Left + 56;
			this._ReplaceDialog.Top = base.Top + 113;
			if (!this._ReplaceDialog.Visible)
			{
				this._ReplaceDialog.Show(this);
			}
			else
			{
				this._ReplaceDialog.Show();
			}
			this._ReplaceDialog.Triggered();
		}

		private void Main_FormClosed(object sender, FormClosedEventArgs e)
		{
			Main.Settings.WindowPosition = base.Bounds;
			Main.Settings.Save();
		}

		private void menuitemFileHeaderAndFooter_Click(object sender, EventArgs e)
		{
			PageSetupHeaderFooter PageSetupHeaderFooter = new PageSetupHeaderFooter();
			PageSetupHeaderFooter.Header = Main.Settings.Header;
			PageSetupHeaderFooter.Footer = Main.Settings.Footer;
			if (PageSetupHeaderFooter.ShowDialog(this) != DialogResult.OK)
			{
				return;
			}
			Main.Settings.Header = PageSetupHeaderFooter.Header;
			Main.Settings.Footer = PageSetupHeaderFooter.Footer;
			Main.Settings.Save();
		}

		private void controlContentTextBox_MouseDown(object sender, MouseEventArgs e)
		{
			this.UpdateStatusBar();
		}

		private Encoding _encoding = Encoding.ASCII;

		private string _Filename;

		private bool _IsDirty;

		private PageSettings _PageSettings;

		private string _LastSearchText;

		private bool _LastMatchCase;

		private bool _LastSearchDown;

		private FindDialog _FindDialog;

		private ReplaceDialog _ReplaceDialog;

		private enum DrawStringPosition
		{
			Left,
			Center,
			Right
		}

		private class HeaderOrFooterInfo
		{
			public string Left = "";

			public string Center = "";

			public string Right = "";
		}

		private class ContentPosition
		{
			public int LineIndex;

			public int ColumnIndex;
		}
	}
}
