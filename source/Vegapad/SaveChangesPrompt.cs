using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Vegapad
{
	public partial class SaveChangesPrompt : Form
	{
		public SaveChangesPrompt(string Filename)
		{
			this.InitializeComponent();
			this.labelMessage.Text = this.labelMessage.Text.FormatUsingObject(new
			{
				Filename = (Filename ?? "Untitled")
			});
		}

		private void buttonSave_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Yes;
			base.Close();
		}

		private void buttonDontSave_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.No;
			base.Close();
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
			base.Close();
		}
	}
}
