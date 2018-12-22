using System;
using System.Windows.Forms;
using Win32Types;

namespace FileDialogExtenders
{
	public static class Extensions
	{
		public static DialogResult ShowDialog(this FileDialog fdlg, FileDialogControlBase ctrl, IWin32Window owner)
		{
			ctrl.FileDlgType = ((fdlg is SaveFileDialog) ? FileDialogType.SaveFileDlg : FileDialogType.OpenFileDlg);
			if (ctrl.ShowDialogExt(fdlg, owner) == DialogResult.OK)
			{
				return DialogResult.OK;
			}
			return DialogResult.Ignore;
		}
	}
}
