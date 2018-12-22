using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using FileDialogExtenders;
using Win32Types;

namespace Vegapad
{
	public class SaveOpenDialog : FileDialogControlBase
	{
		public SaveOpenDialog()
		{
			this.InitializeComponent();
			new List<SaveOpenDialog.EncodingComboBoxItem>();
			this.controlEncodingComboBox.DataSource = new []
            {
				new
				{
					Display = "UTF-8",
					Value = Encoding.UTF8
				},
				new
				{
					Display = "ANSI",
					Value = Encoding.ASCII
				},
				new
				{
					Display = "Unicode",
					Value = Encoding.Unicode
				},
				new
				{
					Display = "Unicode big endian",
					Value = Encoding.BigEndianUnicode
				}
			};
			this.controlEncodingComboBox.SelectedIndex = 0;
		}

		public Encoding Encoding
		{
			get
			{
				return (Encoding)this.controlEncodingComboBox.SelectedValue;
			}
			set
			{
				this.controlEncodingComboBox.SelectedValue = value;
			}
		}

		protected override void OnPrepareMSDialog()
		{
			base.OnPrepareMSDialog();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void SaveOpenDialog_EventFileNameChanged(IWin32Window sender, string Filename)
		{
			if (base.FileDlgType == FileDialogType.OpenFileDlg && File.Exists(Filename))
			{
				using (StreamReader streamReader = new StreamReader(Filename, Encoding.ASCII, true))
				{
					streamReader.ReadToEnd();
					this.controlEncodingComboBox.SelectedValue = streamReader.CurrentEncoding;
				}
			}
		}

		private void InitializeComponent()
		{
			this.label1 = new Label();
			this.controlEncodingComboBox = new ComboBox();
			base.SuspendLayout();
			this.label1.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.label1.AutoSize = true;
			this.label1.Location = new Point(26, 11);
			this.label1.Name = "label1";
			this.label1.Size = new Size(55, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Encoding:";
			this.controlEncodingComboBox.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.controlEncodingComboBox.DisplayMember = "Display";
			this.controlEncodingComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.controlEncodingComboBox.FormattingEnabled = true;
			this.controlEncodingComboBox.Location = new Point(87, 8);
			this.controlEncodingComboBox.Name = "controlEncodingComboBox";
			this.controlEncodingComboBox.Size = new Size(178, 21);
			this.controlEncodingComboBox.TabIndex = 1;
			this.controlEncodingComboBox.ValueMember = "Value";
			this.BackColor = SystemColors.Control;
			base.Controls.Add(this.controlEncodingComboBox);
			base.Controls.Add(this.label1);
			base.FileDlgCaption = "";
			base.FileDlgCheckFileExists = false;
			base.FileDlgDefaultExt = "";
			base.FileDlgDefaultViewMode = FolderViewMode.List;
			base.FileDlgFilter = "";
			base.FileDlgOkCaption = "";
			base.FileDlgStartLocation = AddonWindowLocation.Bottom;
			base.Name = "SaveOpenDialog";
			base.Size = new Size(422, 38);
			base.EventFileNameChanged += this.SaveOpenDialog_EventFileNameChanged;
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		private IContainer components;

		private Label label1;

		private ComboBox controlEncodingComboBox;

		private class EncodingComboBoxItem
		{
			public string Display { get; set; }

			public EncodingInfo Value { get; set; }
		}
	}
}
