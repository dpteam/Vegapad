using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Vegapad
{
	public partial class ReplaceDialog : Form
	{
		public ReplaceDialog(Main pMain)
		{
			this.InitializeComponent();
			this._Main = pMain;
		}

		private void controlFindWhatTextBox_Enter(object sender, EventArgs e)
		{
			((TextBox)sender).SelectAll();
		}

		private void controlReplaceWithTextBox_Enter(object sender, EventArgs e)
		{
			((TextBox)sender).SelectAll();
		}

		private void controlFindWhatTextBox_TextChanged(object sender, EventArgs e)
		{
			this.UpdateButtons();
		}

		private void ReplaceDialog_Load(object sender, EventArgs e)
		{
			this.UpdateButtons();
		}

		private void UpdateButtons()
		{
			this.buttonFindNext.Enabled = (this.buttonReplace.Enabled = (this.buttonReplaceAll.Enabled = (this.controlFindWhatTextBox.Text.Length > 0)));
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			base.Hide();
		}

		private void ReplaceDialog_FormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = true;
			base.Hide();
		}

		public void Triggered()
		{
			this.controlFindWhatTextBox.Focus();
		}

		private void buttonFindNext_Click(object sender, EventArgs e)
		{
			string SearchText = this.controlFindWhatTextBox.Text;
			bool MatchCase = this.controlMatchCaseCheckBox.Checked;
			bool bSearchDown = true;
			if (!this._Main.FindAndSelect(SearchText, MatchCase, bSearchDown))
			{
				MessageBox.Show(this, "Cannot find \"{SearchText}\"".FormatUsingObject(new
				{
					SearchText
				}), "Vegapad");
			}
		}

		private void buttonReplace_Click(object sender, EventArgs e)
		{
			string SearchText = this.controlFindWhatTextBox.Text;
			string ReplaceWithText = this.controlReplaceWithTextBox.Text;
			bool MatchCase = this.controlMatchCaseCheckBox.Checked;
			bool bSearchDown = true;
			if (this._Main.SelectedText.Equals(SearchText))
			{
				this._Main.SelectedText = ReplaceWithText;
			}
			if (!this._Main.FindAndSelect(SearchText, MatchCase, bSearchDown))
			{
				MessageBox.Show(this, "Cannot find \"{SearchText}\"".FormatUsingObject(new
				{
					SearchText
				}), "Vegapad");
			}
		}

		private void buttonReplaceAll_Click(object sender, EventArgs e)
		{
			string Content = this._Main.Content;
			string SearchText = this.controlFindWhatTextBox.Text;
			bool MatchCase = this.controlMatchCaseCheckBox.Checked;
			List<int> Indexes = Helper.GetIndexes(Content, SearchText, MatchCase);
			if (!Indexes.Any<int>())
			{
				MessageBox.Show(this, "Cannot find \"{SearchText}\"".FormatUsingObject(new
				{
					SearchText
				}), "Vegapad");
				return;
			}
			StringBuilder Builder = new StringBuilder();
			string ReplaceWith = this.controlReplaceWithTextBox.Text;
			int LastIndex = -1;
			foreach (int Index in Indexes)
			{
				if (Index != 0)
				{
					int TakeStart;
					if (LastIndex == -1)
					{
						TakeStart = 0;
					}
					else
					{
						TakeStart = LastIndex + SearchText.Length;
					}
					int Length = Index - 1 - TakeStart + 1;
					string InBetween = Content.Substring(TakeStart, Length);
					Builder.Append(InBetween);
				}
				Builder.Append(ReplaceWith);
				LastIndex = Index;
			}
			int TakeStart2;
			if (LastIndex == -1)
			{
				TakeStart2 = 0;
			}
			else
			{
				TakeStart2 = LastIndex + SearchText.Length;
			}
			int Length2 = Content.Length - 1 - TakeStart2 + 1;
			Builder.Append(Content.Substring(TakeStart2, Length2));
			this._Main.Content = Builder.ToString();
		}

		private Main _Main;
	}
}
