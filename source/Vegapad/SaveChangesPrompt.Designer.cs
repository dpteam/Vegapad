namespace Vegapad
{
	public partial class SaveChangesPrompt : global::System.Windows.Forms.Form
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
			global::System.ComponentModel.ComponentResourceManager resources = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Vegapad.SaveChangesPrompt));
			this.buttonSave = new global::System.Windows.Forms.Button();
			this.buttonDontSave = new global::System.Windows.Forms.Button();
			this.buttonCancel = new global::System.Windows.Forms.Button();
			this.labelMessage = new global::System.Windows.Forms.Label();
			base.SuspendLayout();
			this.buttonSave.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.buttonSave.Location = new global::System.Drawing.Point(105, 82);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new global::System.Drawing.Size(75, 23);
			this.buttonSave.TabIndex = 0;
			this.buttonSave.Text = "Save";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new global::System.EventHandler(this.buttonSave_Click);
			this.buttonDontSave.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.buttonDontSave.Location = new global::System.Drawing.Point(186, 82);
			this.buttonDontSave.Name = "buttonDontSave";
			this.buttonDontSave.Size = new global::System.Drawing.Size(75, 23);
			this.buttonDontSave.TabIndex = 1;
			this.buttonDontSave.Text = "Don't Save";
			this.buttonDontSave.UseVisualStyleBackColor = true;
			this.buttonDontSave.Click += new global::System.EventHandler(this.buttonDontSave_Click);
			this.buttonCancel.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.buttonCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new global::System.Drawing.Point(267, 82);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new global::System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 1;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new global::System.EventHandler(this.buttonCancel_Click);
			this.labelMessage.AutoSize = true;
			this.labelMessage.Location = new global::System.Drawing.Point(12, 12);
			this.labelMessage.Name = "labelMessage";
			this.labelMessage.Size = new global::System.Drawing.Size(220, 13);
			this.labelMessage.TabIndex = 2;
			this.labelMessage.Text = "Do you want to save changes to {Filename}?";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = this.buttonCancel;
			base.ClientSize = new global::System.Drawing.Size(354, 117);
			base.Controls.Add(this.labelMessage);
			base.Controls.Add(this.buttonCancel);
			base.Controls.Add(this.buttonDontSave);
			base.Controls.Add(this.buttonSave);
			base.Icon = (global::System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "SaveChangesPrompt";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Vegapad";
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		private global::System.ComponentModel.IContainer components;

		private global::System.Windows.Forms.Button buttonSave;

		private global::System.Windows.Forms.Button buttonDontSave;

		private global::System.Windows.Forms.Button buttonCancel;

		private global::System.Windows.Forms.Label labelMessage;
	}
}
