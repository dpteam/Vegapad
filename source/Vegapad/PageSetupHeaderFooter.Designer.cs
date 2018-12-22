namespace Vegapad
{
	public partial class PageSetupHeaderFooter : global::System.Windows.Forms.Form
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
			this.labelHeader = new global::System.Windows.Forms.Label();
			this.controlHeaderTextBox = new global::System.Windows.Forms.TextBox();
			this.controlFooterTextBox = new global::System.Windows.Forms.TextBox();
			this.labelFooter = new global::System.Windows.Forms.Label();
			this.buttonCancel = new global::System.Windows.Forms.Button();
			this.buttonOk = new global::System.Windows.Forms.Button();
			base.SuspendLayout();
			this.labelHeader.AutoSize = true;
			this.labelHeader.Location = new global::System.Drawing.Point(15, 15);
			this.labelHeader.Name = "labelHeader";
			this.labelHeader.Size = new global::System.Drawing.Size(45, 13);
			this.labelHeader.TabIndex = 0;
			this.labelHeader.Text = "Header:";
			this.controlHeaderTextBox.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.controlHeaderTextBox.Location = new global::System.Drawing.Point(78, 12);
			this.controlHeaderTextBox.Name = "controlHeaderTextBox";
			this.controlHeaderTextBox.Size = new global::System.Drawing.Size(260, 20);
			this.controlHeaderTextBox.TabIndex = 1;
			this.controlFooterTextBox.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.controlFooterTextBox.Location = new global::System.Drawing.Point(78, 38);
			this.controlFooterTextBox.Name = "controlFooterTextBox";
			this.controlFooterTextBox.Size = new global::System.Drawing.Size(260, 20);
			this.controlFooterTextBox.TabIndex = 3;
			this.labelFooter.AutoSize = true;
			this.labelFooter.Location = new global::System.Drawing.Point(15, 41);
			this.labelFooter.Name = "labelFooter";
			this.labelFooter.Size = new global::System.Drawing.Size(40, 13);
			this.labelFooter.TabIndex = 2;
			this.labelFooter.Text = "Footer:";
			this.buttonCancel.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.buttonCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new global::System.Drawing.Point(263, 71);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new global::System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 5;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new global::System.EventHandler(this.buttonCancel_Click);
			this.buttonOk.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.buttonOk.Location = new global::System.Drawing.Point(182, 71);
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.Size = new global::System.Drawing.Size(75, 23);
			this.buttonOk.TabIndex = 4;
			this.buttonOk.Text = "OK";
			this.buttonOk.UseVisualStyleBackColor = true;
			this.buttonOk.Click += new global::System.EventHandler(this.buttonOk_Click);
			base.AcceptButton = this.buttonOk;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = this.buttonCancel;
			base.ClientSize = new global::System.Drawing.Size(350, 106);
			base.Controls.Add(this.buttonOk);
			base.Controls.Add(this.buttonCancel);
			base.Controls.Add(this.controlFooterTextBox);
			base.Controls.Add(this.labelFooter);
			base.Controls.Add(this.controlHeaderTextBox);
			base.Controls.Add(this.labelHeader);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "PageSetupHeaderFooter";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Page Setup - Header & Footer";
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		private global::System.ComponentModel.IContainer components;

		private global::System.Windows.Forms.Label labelHeader;

		private global::System.Windows.Forms.TextBox controlHeaderTextBox;

		private global::System.Windows.Forms.TextBox controlFooterTextBox;

		private global::System.Windows.Forms.Label labelFooter;

		private global::System.Windows.Forms.Button buttonCancel;

		private global::System.Windows.Forms.Button buttonOk;
	}
}
