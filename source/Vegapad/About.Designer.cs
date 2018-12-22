namespace Vegapad
{
	public partial class About : global::System.Windows.Forms.Form
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
			global::System.ComponentModel.ComponentResourceManager resources = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Vegapad.About));
			this.label2 = new global::System.Windows.Forms.Label();
			this.buttonOk = new global::System.Windows.Forms.Button();
			this.label3 = new global::System.Windows.Forms.Label();
			this.controlDartPowerTeamLinkLabel = new global::System.Windows.Forms.LinkLabel();
			this.label1 = new global::System.Windows.Forms.Label();
			base.SuspendLayout();
			this.label2.Location = new global::System.Drawing.Point(16, 46);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(601, 26);
			this.label2.TabIndex = 1;
			this.label2.Text = "Vegapad written in .NET WinForms";
			this.label2.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonOk.Anchor = global::System.Windows.Forms.AnchorStyles.None;
			this.buttonOk.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.buttonOk.Location = new global::System.Drawing.Point(542, 90);
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.Size = new global::System.Drawing.Size(75, 23);
			this.buttonOk.TabIndex = 2;
			this.buttonOk.Text = "OK";
			this.buttonOk.UseVisualStyleBackColor = true;
			this.buttonOk.Click += new global::System.EventHandler(this.buttonOk_Click);
			this.label3.Location = new global::System.Drawing.Point(12, 72);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(605, 15);
			this.label3.TabIndex = 4;
			this.label3.Text = "by DartPower Team";
			this.label3.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.controlDartPowerTeamLinkLabel.AutoSize = true;
			this.controlDartPowerTeamLinkLabel.Location = new global::System.Drawing.Point(16, 100);
			this.controlDartPowerTeamLinkLabel.Name = "controlDartPowerTeamLinkLabel";
			this.controlDartPowerTeamLinkLabel.Size = new global::System.Drawing.Size(168, 13);
			this.controlDartPowerTeamLinkLabel.TabIndex = 5;
			this.controlDartPowerTeamLinkLabel.TabStop = true;
			this.controlDartPowerTeamLinkLabel.Text = "https://dpteam.github.io/vegapad";
			this.controlDartPowerTeamLinkLabel.LinkClicked += new global::System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.controlDartPowerTeamLinkLabel_LinkClicked);
			this.label1.Font = new global::System.Drawing.Font("Press Start 2P", 27.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
			this.label1.Location = new global::System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(605, 37);
			this.label1.TabIndex = 6;
			this.label1.Text = "Vegapad";
			this.label1.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			base.AcceptButton = this.buttonOk;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = this.buttonOk;
			base.ClientSize = new global::System.Drawing.Size(629, 128);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.controlDartPowerTeamLinkLabel);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.buttonOk);
			base.Controls.Add(this.label2);
			base.Icon = (global::System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "About";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "About Vegapad";
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		private global::System.ComponentModel.IContainer components;

		private global::System.Windows.Forms.Label label2;

		private global::System.Windows.Forms.Button buttonOk;

		private global::System.Windows.Forms.Label label3;

		private global::System.Windows.Forms.LinkLabel controlDartPowerTeamLinkLabel;

		private global::System.Windows.Forms.Label label1;
	}
}
