using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Vegapad
{
	public partial class FindDialog : Form
	{
		public FindDialog(Main pMain)
		{
			this.InitializeComponent();
			this._Main = pMain;
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			base.Hide();
		}

		private void FindDialog_FormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = true;
			base.Hide();
		}

		private void controlTextBox_TextChanged(object sender, EventArgs e)
		{
			this.UpdateFindNextButton();
		}

		private void UpdateFindNextButton()
		{
			this.buttonFindNext.Enabled = (this.controlTextBox.Text.Length > 0);
		}

		private void FindDialog_Load(object sender, EventArgs e)
		{
			this.UpdateFindNextButton();
		}

		private void buttonFindNext_Click(object sender, EventArgs e)
		{
			string SearchText = this.controlTextBox.Text;
			bool MatchCase = this.controlMatchCaseCheckbox.Checked;
			bool bSearchDown = this.controlDownRadioButton.Checked;
			if (!this._Main.FindAndSelect(SearchText, MatchCase, bSearchDown))
			{
				MessageBox.Show(this, "Cannot find \"{SearchText}\"".FormatUsingObject(new
				{
					SearchText
				}), "Vegapad");
			}
		}

		public void Triggered()
		{
			this.controlTextBox.Focus();
		}

		private void controlTextBox_Enter(object sender, EventArgs e)
		{
			((TextBox)sender).SelectAll();
		}

		public new void Show(IWin32Window window = null)
		{
			this.controlTextBox.Focus();
			this.controlTextBox.SelectAll();
			if (window == null)
			{
				base.Show();
				return;
			}
			base.Show(window);
		}

		private readonly Main _Main;
	}
}
