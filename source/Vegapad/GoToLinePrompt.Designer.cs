namespace Vegapad
{
	public partial class GoToLinePrompt : global::System.Windows.Forms.Form
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
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager resources = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Vegapad.GoToLinePrompt));
			this.labelLineNumber = new global::System.Windows.Forms.Label();
			this.controlLineNumberTextBox = new global::System.Windows.Forms.TextBox();
			this.buttonGoTo = new global::System.Windows.Forms.Button();
			this.buttonCancel = new global::System.Windows.Forms.Button();
			this.controlToolTip = new global::System.Windows.Forms.ToolTip(this.components);
			base.SuspendLayout();
			this.labelLineNumber.AutoSize = true;
			this.labelLineNumber.Location = new global::System.Drawing.Point(12, 9);
			this.labelLineNumber.Name = "labelLineNumber";
			this.labelLineNumber.Size = new global::System.Drawing.Size(68, 13);
			this.labelLineNumber.TabIndex = 0;
			this.labelLineNumber.Text = "&Line number:";
			this.controlLineNumberTextBox.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.controlLineNumberTextBox.Location = new global::System.Drawing.Point(12, 25);
			this.controlLineNumberTextBox.Name = "controlLineNumberTextBox";
			this.controlLineNumberTextBox.Size = new global::System.Drawing.Size(216, 20);
			this.controlLineNumberTextBox.TabIndex = 1;
			this.controlLineNumberTextBox.KeyPress += new global::System.Windows.Forms.KeyPressEventHandler(this.controlLineNumberTextBox_KeyPress);
			this.buttonGoTo.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.buttonGoTo.Location = new global::System.Drawing.Point(72, 56);
			this.buttonGoTo.Name = "buttonGoTo";
			this.buttonGoTo.Size = new global::System.Drawing.Size(75, 23);
			this.buttonGoTo.TabIndex = 2;
			this.buttonGoTo.Text = "Go To";
			this.buttonGoTo.UseVisualStyleBackColor = true;
			this.buttonGoTo.Click += new global::System.EventHandler(this.buttonGoTo_Click);
			this.buttonCancel.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.buttonCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new global::System.Drawing.Point(153, 56);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new global::System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 3;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new global::System.EventHandler(this.buttonCancel_Click);
			base.AcceptButton = this.buttonGoTo;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = this.buttonCancel;
			base.ClientSize = new global::System.Drawing.Size(240, 91);
			base.Controls.Add(this.buttonCancel);
			base.Controls.Add(this.buttonGoTo);
			base.Controls.Add(this.controlLineNumberTextBox);
			base.Controls.Add(this.labelLineNumber);
			base.Icon = (global::System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "GoToLinePrompt";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Go To Line";
			base.Load += new global::System.EventHandler(this.GoToLinePrompt_Load);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		private global::System.ComponentModel.IContainer components;

		private global::System.Windows.Forms.Label labelLineNumber;

		private global::System.Windows.Forms.TextBox controlLineNumberTextBox;

		private global::System.Windows.Forms.Button buttonGoTo;

		private global::System.Windows.Forms.Button buttonCancel;

		private global::System.Windows.Forms.ToolTip controlToolTip;
	}
}
