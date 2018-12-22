using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Vegapad
{
	public partial class GoToLinePrompt : Form
	{
		public GoToLinePrompt(int pLineNumber)
		{
			this.InitializeComponent();
			this.LineNumber = pLineNumber;
			this.controlLineNumberTextBox.Text = this.LineNumber.ToString();
		}

		private void GoToLinePrompt_Load(object sender, EventArgs e)
		{
			this.controlLineNumberTextBox.SelectAll();
		}

		private void buttonGoTo_Click(object sender, EventArgs e)
		{
			if (this.controlLineNumberTextBox.Text.IsEmpty())
			{
				MessageBox.Show(this, "You must enter a value.", "Vegapad - Goto Line");
				return;
			}
			int PotentialLineNumber = int.Parse(this.controlLineNumberTextBox.Text);
			if (PotentialLineNumber == 0)
			{
				MessageBox.Show(this, "Zero (0) is not a valid line number, line numbers start at 1.", "Vegapad - Goto Line");
				return;
			}
			this.LineNumber = PotentialLineNumber;
			base.DialogResult = DialogResult.OK;
			base.Close();
		}

		private void controlLineNumberTextBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsDigit(e.KeyChar))
			{
				TextBox Sender = (TextBox)sender;
				this.controlToolTip.Show("Unacceptable Charater - You can only type a number here.", Sender);
				e.Handled = true;
			}
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		public int LineNumber;
	}
}
