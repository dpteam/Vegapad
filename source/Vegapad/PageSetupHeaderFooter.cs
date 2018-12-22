using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Vegapad
{
	public partial class PageSetupHeaderFooter : Form
	{
		public PageSetupHeaderFooter()
		{
			this.InitializeComponent();
		}

		public string Header
		{
			get
			{
				return this.controlHeaderTextBox.Text;
			}
			set
			{
				this.controlHeaderTextBox.Text = value;
			}
		}

		public string Footer
		{
			get
			{
				return this.controlFooterTextBox.Text;
			}
			set
			{
				this.controlFooterTextBox.Text = value;
			}
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		private void buttonOk_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
			base.Close();
		}
	}
}
