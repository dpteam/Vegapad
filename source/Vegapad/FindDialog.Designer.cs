namespace Vegapad
{
	public partial class FindDialog : global::System.Windows.Forms.Form
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
			this.buttonFindNext = new global::System.Windows.Forms.Button();
			this.buttonCancel = new global::System.Windows.Forms.Button();
			this.labelFindWhat = new global::System.Windows.Forms.Label();
			this.controlMatchCaseCheckbox = new global::System.Windows.Forms.CheckBox();
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.controlDownRadioButton = new global::System.Windows.Forms.RadioButton();
			this.controlUpRadioButton = new global::System.Windows.Forms.RadioButton();
			this.controlTextBox = new global::System.Windows.Forms.TextBox();
			this.groupBox1.SuspendLayout();
			base.SuspendLayout();
			this.buttonFindNext.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.buttonFindNext.Location = new global::System.Drawing.Point(273, 12);
			this.buttonFindNext.Name = "buttonFindNext";
			this.buttonFindNext.Size = new global::System.Drawing.Size(75, 23);
			this.buttonFindNext.TabIndex = 4;
			this.buttonFindNext.Text = "&Find Next";
			this.buttonFindNext.UseVisualStyleBackColor = true;
			this.buttonFindNext.Click += new global::System.EventHandler(this.buttonFindNext_Click);
			this.buttonCancel.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.buttonCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new global::System.Drawing.Point(273, 41);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new global::System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 5;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new global::System.EventHandler(this.buttonCancel_Click);
			this.labelFindWhat.AutoSize = true;
			this.labelFindWhat.Location = new global::System.Drawing.Point(8, 18);
			this.labelFindWhat.Name = "labelFindWhat";
			this.labelFindWhat.Size = new global::System.Drawing.Size(56, 13);
			this.labelFindWhat.TabIndex = 0;
			this.labelFindWhat.Text = "Fi&nd what:";
			this.controlMatchCaseCheckbox.AutoSize = true;
			this.controlMatchCaseCheckbox.Location = new global::System.Drawing.Point(11, 71);
			this.controlMatchCaseCheckbox.Name = "controlMatchCaseCheckbox";
			this.controlMatchCaseCheckbox.Size = new global::System.Drawing.Size(82, 17);
			this.controlMatchCaseCheckbox.TabIndex = 2;
			this.controlMatchCaseCheckbox.Text = "Match &case";
			this.controlMatchCaseCheckbox.UseVisualStyleBackColor = true;
			this.groupBox1.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.groupBox1.Controls.Add(this.controlDownRadioButton);
			this.groupBox1.Controls.Add(this.controlUpRadioButton);
			this.groupBox1.Location = new global::System.Drawing.Point(151, 42);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new global::System.Drawing.Size(109, 47);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Direction";
			this.controlDownRadioButton.AutoSize = true;
			this.controlDownRadioButton.Checked = true;
			this.controlDownRadioButton.Location = new global::System.Drawing.Point(51, 19);
			this.controlDownRadioButton.Name = "controlDownRadioButton";
			this.controlDownRadioButton.Size = new global::System.Drawing.Size(53, 17);
			this.controlDownRadioButton.TabIndex = 1;
			this.controlDownRadioButton.TabStop = true;
			this.controlDownRadioButton.Text = "&Down";
			this.controlDownRadioButton.UseVisualStyleBackColor = true;
			this.controlUpRadioButton.AutoSize = true;
			this.controlUpRadioButton.Location = new global::System.Drawing.Point(6, 19);
			this.controlUpRadioButton.Name = "controlUpRadioButton";
			this.controlUpRadioButton.Size = new global::System.Drawing.Size(39, 17);
			this.controlUpRadioButton.TabIndex = 0;
			this.controlUpRadioButton.TabStop = true;
			this.controlUpRadioButton.Text = "&Up";
			this.controlUpRadioButton.UseVisualStyleBackColor = true;
			this.controlTextBox.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.controlTextBox.Location = new global::System.Drawing.Point(78, 16);
			this.controlTextBox.Name = "controlTextBox";
			this.controlTextBox.Size = new global::System.Drawing.Size(182, 20);
			this.controlTextBox.TabIndex = 1;
			this.controlTextBox.TextChanged += new global::System.EventHandler(this.controlTextBox_TextChanged);
			this.controlTextBox.Enter += new global::System.EventHandler(this.controlTextBox_Enter);
			base.AcceptButton = this.buttonFindNext;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = this.buttonCancel;
			base.ClientSize = new global::System.Drawing.Size(360, 101);
			base.Controls.Add(this.controlTextBox);
			base.Controls.Add(this.groupBox1);
			base.Controls.Add(this.controlMatchCaseCheckbox);
			base.Controls.Add(this.labelFindWhat);
			base.Controls.Add(this.buttonCancel);
			base.Controls.Add(this.buttonFindNext);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "FindDialog";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Find";
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.FindDialog_FormClosing);
			base.Load += new global::System.EventHandler(this.FindDialog_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		private global::System.ComponentModel.IContainer components;

		private global::System.Windows.Forms.Button buttonFindNext;

		private global::System.Windows.Forms.Button buttonCancel;

		private global::System.Windows.Forms.Label labelFindWhat;

		private global::System.Windows.Forms.CheckBox controlMatchCaseCheckbox;

		private global::System.Windows.Forms.GroupBox groupBox1;

		private global::System.Windows.Forms.RadioButton controlDownRadioButton;

		private global::System.Windows.Forms.RadioButton controlUpRadioButton;

		private global::System.Windows.Forms.TextBox controlTextBox;
	}
}
