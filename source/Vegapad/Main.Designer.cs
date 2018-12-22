namespace Vegapad
{
	public partial class Main : global::System.Windows.Forms.Form
	{
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager resources = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Vegapad.Main));
			this.controlContentTextBox = new global::System.Windows.Forms.TextBox();
			this.menubarMain = new global::System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.menuitemFileNew = new global::System.Windows.Forms.ToolStripMenuItem();
			this.menuitemFileOpen = new global::System.Windows.Forms.ToolStripMenuItem();
			this.menuitemFileSave = new global::System.Windows.Forms.ToolStripMenuItem();
			this.menuitemFileSaveAs = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new global::System.Windows.Forms.ToolStripSeparator();
			this.menuitemFilePageSetup = new global::System.Windows.Forms.ToolStripMenuItem();
			this.menuitemFileHeaderAndFooter = new global::System.Windows.Forms.ToolStripMenuItem();
			this.menuitemFilePrint = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new global::System.Windows.Forms.ToolStripSeparator();
			this.menuitemFileExit = new global::System.Windows.Forms.ToolStripMenuItem();
			this.menuitemEdit = new global::System.Windows.Forms.ToolStripMenuItem();
			this.menuitemEditUndo = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator5 = new global::System.Windows.Forms.ToolStripSeparator();
			this.menuitemEditCut = new global::System.Windows.Forms.ToolStripMenuItem();
			this.menuitemEditCopy = new global::System.Windows.Forms.ToolStripMenuItem();
			this.menuitemEditPaste = new global::System.Windows.Forms.ToolStripMenuItem();
			this.menuitemEditDelete = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator6 = new global::System.Windows.Forms.ToolStripSeparator();
			this.menuitemEditFind = new global::System.Windows.Forms.ToolStripMenuItem();
			this.menuitemEditFindNext = new global::System.Windows.Forms.ToolStripMenuItem();
			this.menuitemEditReplace = new global::System.Windows.Forms.ToolStripMenuItem();
			this.menuitemEditGoTo = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new global::System.Windows.Forms.ToolStripSeparator();
			this.menuitemEditSelectAll = new global::System.Windows.Forms.ToolStripMenuItem();
			this.menuitemEditTimeDate = new global::System.Windows.Forms.ToolStripMenuItem();
			this.formatToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.menuitemFormatWordWrap = new global::System.Windows.Forms.ToolStripMenuItem();
			this.menuitemFormatFont = new global::System.Windows.Forms.ToolStripMenuItem();
			this.viewToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.menuitemViewStatusBar = new global::System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.menuitemHelp = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new global::System.Windows.Forms.ToolStripSeparator();
			this.menuitemAbout = new global::System.Windows.Forms.ToolStripMenuItem();
			this.controlStatusBar = new global::System.Windows.Forms.StatusStrip();
			this.controlCaretPositionLabel = new global::System.Windows.Forms.ToolStripStatusLabel();
			this.menubarMain.SuspendLayout();
			this.controlStatusBar.SuspendLayout();
			base.SuspendLayout();
			this.controlContentTextBox.AcceptsReturn = true;
			this.controlContentTextBox.AcceptsTab = true;
			this.controlContentTextBox.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.controlContentTextBox.HideSelection = false;
			this.controlContentTextBox.Location = new global::System.Drawing.Point(0, 24);
			this.controlContentTextBox.Margin = new global::System.Windows.Forms.Padding(10);
			this.controlContentTextBox.MaxLength = 0;
			this.controlContentTextBox.Multiline = true;
			this.controlContentTextBox.Name = "controlContentTextBox";
			this.controlContentTextBox.ScrollBars = global::System.Windows.Forms.ScrollBars.Both;
			this.controlContentTextBox.Size = new global::System.Drawing.Size(632, 369);
			this.controlContentTextBox.TabIndex = 0;
			this.controlContentTextBox.WordWrap = false;
			this.controlContentTextBox.TextChanged += new global::System.EventHandler(this.controlContentTextBox_TextChanged);
			this.controlContentTextBox.KeyDown += new global::System.Windows.Forms.KeyEventHandler(this.controlContentTextBox_KeyDown);
			this.controlContentTextBox.KeyUp += new global::System.Windows.Forms.KeyEventHandler(this.controlContentTextBox_KeyUp);
			this.controlContentTextBox.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.controlContentTextBox_MouseDown);
			this.menubarMain.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.Stretch;
			this.menubarMain.GripMargin = new global::System.Windows.Forms.Padding(0);
			this.menubarMain.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.fileToolStripMenuItem,
				this.menuitemEdit,
				this.formatToolStripMenuItem,
				this.viewToolStripMenuItem,
				this.helpToolStripMenuItem
			});
			this.menubarMain.Location = new global::System.Drawing.Point(0, 0);
			this.menubarMain.Name = "menubarMain";
			this.menubarMain.Padding = new global::System.Windows.Forms.Padding(0);
			this.menubarMain.Size = new global::System.Drawing.Size(632, 24);
			this.menubarMain.TabIndex = 1;
			this.fileToolStripMenuItem.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.menuitemFileNew,
				this.menuitemFileOpen,
				this.menuitemFileSave,
				this.menuitemFileSaveAs,
				this.toolStripSeparator1,
				this.menuitemFilePageSetup,
				this.menuitemFileHeaderAndFooter,
				this.menuitemFilePrint,
				this.toolStripSeparator2,
				this.menuitemFileExit
			});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new global::System.Drawing.Size(37, 24);
			this.fileToolStripMenuItem.Text = "&File";
			this.menuitemFileNew.Name = "menuitemFileNew";
			this.menuitemFileNew.ShortcutKeys = (global::System.Windows.Forms.Keys)131150;
			this.menuitemFileNew.Size = new global::System.Drawing.Size(171, 22);
			this.menuitemFileNew.Text = "&New";
			this.menuitemFileNew.Click += new global::System.EventHandler(this.menuitemFileNew_Click);
			this.menuitemFileOpen.Name = "menuitemFileOpen";
			this.menuitemFileOpen.ShortcutKeys = (global::System.Windows.Forms.Keys)131151;
			this.menuitemFileOpen.Size = new global::System.Drawing.Size(171, 22);
			this.menuitemFileOpen.Text = "&Open...";
			this.menuitemFileOpen.Click += new global::System.EventHandler(this.menuitemFileOpen_Click);
			this.menuitemFileSave.Name = "menuitemFileSave";
			this.menuitemFileSave.ShortcutKeys = (global::System.Windows.Forms.Keys)131155;
			this.menuitemFileSave.Size = new global::System.Drawing.Size(171, 22);
			this.menuitemFileSave.Text = "&Save";
			this.menuitemFileSave.Click += new global::System.EventHandler(this.menuitemFileSave_Click);
			this.menuitemFileSaveAs.Name = "menuitemFileSaveAs";
			this.menuitemFileSaveAs.Size = new global::System.Drawing.Size(171, 22);
			this.menuitemFileSaveAs.Text = "Save &As...";
			this.menuitemFileSaveAs.Click += new global::System.EventHandler(this.menuitemFileSaveAs_Click);
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new global::System.Drawing.Size(168, 6);
			this.menuitemFilePageSetup.Name = "menuitemFilePageSetup";
			this.menuitemFilePageSetup.Size = new global::System.Drawing.Size(171, 22);
			this.menuitemFilePageSetup.Text = "Page Set&up...";
			this.menuitemFilePageSetup.Click += new global::System.EventHandler(this.menuitemFilePageSetup_Click);
			this.menuitemFileHeaderAndFooter.Name = "menuitemFileHeaderAndFooter";
			this.menuitemFileHeaderAndFooter.Size = new global::System.Drawing.Size(171, 22);
			this.menuitemFileHeaderAndFooter.Text = "&Header && Footer...";
			this.menuitemFileHeaderAndFooter.Click += new global::System.EventHandler(this.menuitemFileHeaderAndFooter_Click);
			this.menuitemFilePrint.Name = "menuitemFilePrint";
			this.menuitemFilePrint.ShortcutKeys = (global::System.Windows.Forms.Keys)131152;
			this.menuitemFilePrint.Size = new global::System.Drawing.Size(171, 22);
			this.menuitemFilePrint.Text = "&Print...";
			this.menuitemFilePrint.Click += new global::System.EventHandler(this.menuitemFilePrint_Click);
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new global::System.Drawing.Size(168, 6);
			this.menuitemFileExit.Name = "menuitemFileExit";
			this.menuitemFileExit.Size = new global::System.Drawing.Size(171, 22);
			this.menuitemFileExit.Text = "E&xit";
			this.menuitemFileExit.Click += new global::System.EventHandler(this.menuitemFileExit_Click);
			this.menuitemEdit.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.menuitemEditUndo,
				this.toolStripSeparator5,
				this.menuitemEditCut,
				this.menuitemEditCopy,
				this.menuitemEditPaste,
				this.menuitemEditDelete,
				this.toolStripSeparator6,
				this.menuitemEditFind,
				this.menuitemEditFindNext,
				this.menuitemEditReplace,
				this.menuitemEditGoTo,
				this.toolStripSeparator3,
				this.menuitemEditSelectAll,
				this.menuitemEditTimeDate
			});
			this.menuitemEdit.Name = "menuitemEdit";
			this.menuitemEdit.Size = new global::System.Drawing.Size(39, 24);
			this.menuitemEdit.Text = "&Edit";
			this.menuitemEdit.DropDownOpening += new global::System.EventHandler(this.menuitemEdit_DropDownOpening);
			this.menuitemEditUndo.Name = "menuitemEditUndo";
			this.menuitemEditUndo.ShortcutKeys = (global::System.Windows.Forms.Keys)131162;
			this.menuitemEditUndo.Size = new global::System.Drawing.Size(167, 22);
			this.menuitemEditUndo.Text = "&Undo";
			this.menuitemEditUndo.Click += new global::System.EventHandler(this.menuitemEditUndo_Click);
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new global::System.Drawing.Size(164, 6);
			this.menuitemEditCut.Name = "menuitemEditCut";
			this.menuitemEditCut.ShortcutKeys = (global::System.Windows.Forms.Keys)131160;
			this.menuitemEditCut.Size = new global::System.Drawing.Size(167, 22);
			this.menuitemEditCut.Text = "Cu&t";
			this.menuitemEditCut.Click += new global::System.EventHandler(this.menuitemEditCut_Click);
			this.menuitemEditCopy.Name = "menuitemEditCopy";
			this.menuitemEditCopy.ShortcutKeys = (global::System.Windows.Forms.Keys)131139;
			this.menuitemEditCopy.Size = new global::System.Drawing.Size(167, 22);
			this.menuitemEditCopy.Text = "&Copy";
			this.menuitemEditCopy.Click += new global::System.EventHandler(this.menuitemEditCopy_Click);
			this.menuitemEditPaste.Name = "menuitemEditPaste";
			this.menuitemEditPaste.ShortcutKeys = (global::System.Windows.Forms.Keys)131158;
			this.menuitemEditPaste.Size = new global::System.Drawing.Size(167, 22);
			this.menuitemEditPaste.Text = "&Paste";
			this.menuitemEditPaste.Click += new global::System.EventHandler(this.menuitemEditPaste_Click);
			this.menuitemEditDelete.Name = "menuitemEditDelete";
			this.menuitemEditDelete.ShortcutKeys = global::System.Windows.Forms.Keys.Delete;
			this.menuitemEditDelete.Size = new global::System.Drawing.Size(167, 22);
			this.menuitemEditDelete.Text = "De&lete";
			this.menuitemEditDelete.Click += new global::System.EventHandler(this.menuitemEditDelete_Click);
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new global::System.Drawing.Size(164, 6);
			this.menuitemEditFind.Name = "menuitemEditFind";
			this.menuitemEditFind.ShortcutKeys = (global::System.Windows.Forms.Keys)131142;
			this.menuitemEditFind.Size = new global::System.Drawing.Size(167, 22);
			this.menuitemEditFind.Text = "&Find...";
			this.menuitemEditFind.Click += new global::System.EventHandler(this.menuitemEditFind_Click);
			this.menuitemEditFindNext.Name = "menuitemEditFindNext";
			this.menuitemEditFindNext.ShortcutKeys = global::System.Windows.Forms.Keys.F3;
			this.menuitemEditFindNext.Size = new global::System.Drawing.Size(167, 22);
			this.menuitemEditFindNext.Text = "Find &Next";
			this.menuitemEditFindNext.Click += new global::System.EventHandler(this.menuitemEditFindNext_Click);
			this.menuitemEditReplace.Name = "menuitemEditReplace";
			this.menuitemEditReplace.ShortcutKeys = (global::System.Windows.Forms.Keys)131144;
			this.menuitemEditReplace.Size = new global::System.Drawing.Size(167, 22);
			this.menuitemEditReplace.Text = "&Replace...";
			this.menuitemEditReplace.Click += new global::System.EventHandler(this.menuitemEditReplace_Click);
			this.menuitemEditGoTo.Name = "menuitemEditGoTo";
			this.menuitemEditGoTo.ShortcutKeys = (global::System.Windows.Forms.Keys)131143;
			this.menuitemEditGoTo.Size = new global::System.Drawing.Size(167, 22);
			this.menuitemEditGoTo.Text = "&Go To...";
			this.menuitemEditGoTo.Click += new global::System.EventHandler(this.menuitemEditGoTo_Click);
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new global::System.Drawing.Size(164, 6);
			this.menuitemEditSelectAll.Name = "menuitemEditSelectAll";
			this.menuitemEditSelectAll.ShortcutKeys = (global::System.Windows.Forms.Keys)131137;
			this.menuitemEditSelectAll.Size = new global::System.Drawing.Size(167, 22);
			this.menuitemEditSelectAll.Text = "Select &All";
			this.menuitemEditSelectAll.Click += new global::System.EventHandler(this.menuitemEditSelectAll_Click);
			this.menuitemEditTimeDate.Name = "menuitemEditTimeDate";
			this.menuitemEditTimeDate.ShortcutKeys = global::System.Windows.Forms.Keys.F5;
			this.menuitemEditTimeDate.Size = new global::System.Drawing.Size(167, 22);
			this.menuitemEditTimeDate.Text = "Time/&Date";
			this.menuitemEditTimeDate.Click += new global::System.EventHandler(this.menuitemEditTimeDate_Click);
			this.formatToolStripMenuItem.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.menuitemFormatWordWrap,
				this.menuitemFormatFont
			});
			this.formatToolStripMenuItem.Name = "formatToolStripMenuItem";
			this.formatToolStripMenuItem.Size = new global::System.Drawing.Size(57, 24);
			this.formatToolStripMenuItem.Text = "F&ormat";
			this.menuitemFormatWordWrap.Name = "menuitemFormatWordWrap";
			this.menuitemFormatWordWrap.Size = new global::System.Drawing.Size(134, 22);
			this.menuitemFormatWordWrap.Text = "&Word Wrap";
			this.menuitemFormatWordWrap.CheckedChanged += new global::System.EventHandler(this.menuitemFormatWordWrap_CheckedChanged);
			this.menuitemFormatWordWrap.Click += new global::System.EventHandler(this.menuitemFormatWordWrap_Click);
			this.menuitemFormatFont.Name = "menuitemFormatFont";
			this.menuitemFormatFont.Size = new global::System.Drawing.Size(134, 22);
			this.menuitemFormatFont.Text = "&Font...";
			this.menuitemFormatFont.Click += new global::System.EventHandler(this.menuitemFormatFont_Click);
			this.viewToolStripMenuItem.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.menuitemViewStatusBar
			});
			this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
			this.viewToolStripMenuItem.Size = new global::System.Drawing.Size(44, 24);
			this.viewToolStripMenuItem.Text = "&View";
			this.menuitemViewStatusBar.Name = "menuitemViewStatusBar";
			this.menuitemViewStatusBar.Size = new global::System.Drawing.Size(126, 22);
			this.menuitemViewStatusBar.Text = "&Status Bar";
			this.menuitemViewStatusBar.Click += new global::System.EventHandler(this.menuitemViewStatusBar_Click);
			this.helpToolStripMenuItem.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.menuitemHelp,
				this.toolStripSeparator4,
				this.menuitemAbout
			});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new global::System.Drawing.Size(44, 24);
			this.helpToolStripMenuItem.Text = "&Help";
			this.menuitemHelp.Name = "menuitemHelp";
			this.menuitemHelp.Size = new global::System.Drawing.Size(155, 22);
			this.menuitemHelp.Text = "View &Help";
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new global::System.Drawing.Size(152, 6);
			this.menuitemAbout.Name = "menuitemAbout";
			this.menuitemAbout.Size = new global::System.Drawing.Size(155, 22);
			this.menuitemAbout.Text = "&About Vegapad";
			this.menuitemAbout.Click += new global::System.EventHandler(this.menuitemAbout_Click);
			this.controlStatusBar.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.controlCaretPositionLabel
			});
			this.controlStatusBar.Location = new global::System.Drawing.Point(0, 371);
			this.controlStatusBar.Name = "controlStatusBar";
			this.controlStatusBar.RightToLeft = global::System.Windows.Forms.RightToLeft.Yes;
			this.controlStatusBar.Size = new global::System.Drawing.Size(632, 22);
			this.controlStatusBar.SizingGrip = false;
			this.controlStatusBar.TabIndex = 2;
			this.controlCaretPositionLabel.AutoSize = false;
			this.controlCaretPositionLabel.DisplayStyle = global::System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.controlCaretPositionLabel.Name = "controlCaretPositionLabel";
			this.controlCaretPositionLabel.Size = new global::System.Drawing.Size(219, 17);
			this.controlCaretPositionLabel.Text = "Ln {LineNumber}, Col {ColumnNumber}";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(632, 393);
			base.Controls.Add(this.controlStatusBar);
			base.Controls.Add(this.controlContentTextBox);
			base.Controls.Add(this.menubarMain);
			base.Icon = (global::System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.MainMenuStrip = this.menubarMain;
			base.Name = "Main";
			this.Text = "{DocumentName} - Vegapad";
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
			base.FormClosed += new global::System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
			base.Load += new global::System.EventHandler(this.Main_Load);
			this.menubarMain.ResumeLayout(false);
			this.menubarMain.PerformLayout();
			this.controlStatusBar.ResumeLayout(false);
			this.controlStatusBar.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		private global::System.ComponentModel.IContainer components;

		private global::System.Windows.Forms.TextBox controlContentTextBox;

		private global::System.Windows.Forms.MenuStrip menubarMain;

		private global::System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;

		private global::System.Windows.Forms.ToolStripMenuItem menuitemFileNew;

		private global::System.Windows.Forms.ToolStripMenuItem menuitemFileOpen;

		private global::System.Windows.Forms.ToolStripMenuItem menuitemFileSave;

		private global::System.Windows.Forms.ToolStripMenuItem menuitemFileSaveAs;

		private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator1;

		private global::System.Windows.Forms.ToolStripMenuItem menuitemFilePageSetup;

		private global::System.Windows.Forms.ToolStripMenuItem menuitemFilePrint;

		private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator2;

		private global::System.Windows.Forms.ToolStripMenuItem menuitemFileExit;

		private global::System.Windows.Forms.ToolStripMenuItem menuitemEdit;

		private global::System.Windows.Forms.ToolStripMenuItem menuitemEditFind;

		private global::System.Windows.Forms.ToolStripMenuItem menuitemEditFindNext;

		private global::System.Windows.Forms.ToolStripMenuItem menuitemEditReplace;

		private global::System.Windows.Forms.ToolStripMenuItem menuitemEditGoTo;

		private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator3;

		private global::System.Windows.Forms.ToolStripMenuItem menuitemEditSelectAll;

		private global::System.Windows.Forms.ToolStripMenuItem menuitemEditTimeDate;

		private global::System.Windows.Forms.ToolStripMenuItem formatToolStripMenuItem;

		private global::System.Windows.Forms.ToolStripMenuItem menuitemFormatWordWrap;

		private global::System.Windows.Forms.ToolStripMenuItem menuitemFormatFont;

		private global::System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;

		private global::System.Windows.Forms.ToolStripMenuItem menuitemViewStatusBar;

		private global::System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;

		private global::System.Windows.Forms.ToolStripMenuItem menuitemHelp;

		private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator4;

		private global::System.Windows.Forms.ToolStripMenuItem menuitemAbout;

		private global::System.Windows.Forms.ToolStripMenuItem menuitemEditUndo;

		private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator5;

		private global::System.Windows.Forms.ToolStripMenuItem menuitemEditCut;

		private global::System.Windows.Forms.ToolStripMenuItem menuitemEditCopy;

		private global::System.Windows.Forms.ToolStripMenuItem menuitemEditPaste;

		private global::System.Windows.Forms.ToolStripMenuItem menuitemEditDelete;

		private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator6;

		private global::System.Windows.Forms.StatusStrip controlStatusBar;

		private global::System.Windows.Forms.ToolStripStatusLabel controlCaretPositionLabel;

		private global::System.Windows.Forms.ToolStripMenuItem menuitemFileHeaderAndFooter;
	}
}
