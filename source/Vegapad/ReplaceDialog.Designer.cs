namespace Vegapad
{
	public partial class ReplaceDialog : global::System.Windows.Forms.Form
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
			this.buttonReplace = new global::System.Windows.Forms.Button();
			this.buttonReplaceAll = new global::System.Windows.Forms.Button();
			this.buttonCancel = new global::System.Windows.Forms.Button();
			this.labelFindWhat = new global::System.Windows.Forms.Label();
			this.controlFindWhatTextBox = new global::System.Windows.Forms.TextBox();
			this.controlReplaceWithTextBox = new global::System.Windows.Forms.TextBox();
			this.labelReplaceWith = new global::System.Windows.Forms.Label();
			this.controlMatchCaseCheckBox = new global::System.Windows.Forms.CheckBox();
			base.SuspendLayout();
			this.buttonFindNext.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.buttonFindNext.Location = new global::System.Drawing.Point(253, 8);
			this.buttonFindNext.Name = "buttonFindNext";
			this.buttonFindNext.Size = new global::System.Drawing.Size(75, 23);
			this.buttonFindNext.TabIndex = 0;
			this.buttonFindNext.Text = "&Find Next";
			this.buttonFindNext.UseVisualStyleBackColor = true;
			this.buttonFindNext.Click += new global::System.EventHandler(this.buttonFindNext_Click);
			this.buttonReplace.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.buttonReplace.Location = new global::System.Drawing.Point(253, 37);
			this.buttonReplace.Name = "buttonReplace";
			this.buttonReplace.Size = new global::System.Drawing.Size(75, 23);
			this.buttonReplace.TabIndex = 0;
			this.buttonReplace.Text = "&Replace";
			this.buttonReplace.UseVisualStyleBackColor = true;
			this.buttonReplace.Click += new global::System.EventHandler(this.buttonReplace_Click);
			this.buttonReplaceAll.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.buttonReplaceAll.Location = new global::System.Drawing.Point(253, 66);
			this.buttonReplaceAll.Name = "buttonReplaceAll";
			this.buttonReplaceAll.Size = new global::System.Drawing.Size(75, 23);
			this.buttonReplaceAll.TabIndex = 0;
			this.buttonReplaceAll.Text = "Replace &All";
			this.buttonReplaceAll.UseVisualStyleBackColor = true;
			this.buttonReplaceAll.Click += new global::System.EventHandler(this.buttonReplaceAll_Click);
			this.buttonCancel.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.buttonCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new global::System.Drawing.Point(253, 95);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new global::System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 0;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new global::System.EventHandler(this.buttonCancel_Click);
			this.labelFindWhat.AutoSize = true;
			this.labelFindWhat.Location = new global::System.Drawing.Point(4, 16);
			this.labelFindWhat.Name = "labelFindWhat";
			this.labelFindWhat.Size = new global::System.Drawing.Size(56, 13);
			this.labelFindWhat.TabIndex = 1;
			this.labelFindWhat.Text = "Fi&nd what:";
			this.controlFindWhatTextBox.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.controlFindWhatTextBox.Location = new global::System.Drawing.Point(82, 12);
			this.controlFindWhatTextBox.Name = "controlFindWhatTextBox";
			this.controlFindWhatTextBox.Size = new global::System.Drawing.Size(165, 20);
			this.controlFindWhatTextBox.TabIndex = 2;
			this.controlFindWhatTextBox.TextChanged += new global::System.EventHandler(this.controlFindWhatTextBox_TextChanged);
			this.controlFindWhatTextBox.Enter += new global::System.EventHandler(this.controlFindWhatTextBox_Enter);
			this.controlReplaceWithTextBox.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.controlReplaceWithTextBox.Location = new global::System.Drawing.Point(82, 42);
			this.controlReplaceWithTextBox.Name = "controlReplaceWithTextBox";
			this.controlReplaceWithTextBox.Size = new global::System.Drawing.Size(165, 20);
			this.controlReplaceWithTextBox.TabIndex = 4;
			this.controlReplaceWithTextBox.Enter += new global::System.EventHandler(this.controlReplaceWithTextBox_Enter);
			this.labelReplaceWith.AutoSize = true;
			this.labelReplaceWith.Location = new global::System.Drawing.Point(4, 45);
			this.labelReplaceWith.Name = "labelReplaceWith";
			this.labelReplaceWith.Size = new global::System.Drawing.Size(72, 13);
			this.labelReplaceWith.TabIndex = 3;
			this.labelReplaceWith.Text = "Re&place with:";
			this.controlMatchCaseCheckBox.AutoSize = true;
			this.controlMatchCaseCheckBox.Location = new global::System.Drawing.Point(7, 108);
			this.controlMatchCaseCheckBox.Name = "controlMatchCaseCheckBox";
			this.controlMatchCaseCheckBox.Size = new global::System.Drawing.Size(82, 17);
			this.controlMatchCaseCheckBox.TabIndex = 5;
			this.controlMatchCaseCheckBox.Text = "Match &case";
			this.controlMatchCaseCheckBox.UseVisualStyleBackColor = true;
			base.AcceptButton = this.buttonFindNext;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = this.buttonCancel;
			base.ClientSize = new global::System.Drawing.Size(337, 155);
			base.Controls.Add(this.controlMatchCaseCheckBox);
			base.Controls.Add(this.controlReplaceWithTextBox);
			base.Controls.Add(this.labelReplaceWith);
			base.Controls.Add(this.controlFindWhatTextBox);
			base.Controls.Add(this.labelFindWhat);
			base.Controls.Add(this.buttonCancel);
			base.Controls.Add(this.buttonReplaceAll);
			base.Controls.Add(this.buttonReplace);
			base.Controls.Add(this.buttonFindNext);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "ReplaceDialog";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Replace";
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.ReplaceDialog_FormClosing);
			base.Load += new global::System.EventHandler(this.ReplaceDialog_Load);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		private global::System.ComponentModel.IContainer components;

		private global::System.Windows.Forms.Button buttonFindNext;

		private global::System.Windows.Forms.Button buttonReplace;

		private global::System.Windows.Forms.Button buttonReplaceAll;

		private global::System.Windows.Forms.Button buttonCancel;

		private global::System.Windows.Forms.Label labelFindWhat;

		private global::System.Windows.Forms.TextBox controlFindWhatTextBox;

		private global::System.Windows.Forms.TextBox controlReplaceWithTextBox;

		private global::System.Windows.Forms.Label labelReplaceWith;

		private global::System.Windows.Forms.CheckBox controlMatchCaseCheckBox;
	}
}
