using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Vegapad
{
	public partial class About : Form
	{
		public About()
		{
			this.InitializeComponent();
		}

		private void buttonOk_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		private void controlDartPowerTeamLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("https://dpteam.github.io/vegapad");
		}
	}
}
