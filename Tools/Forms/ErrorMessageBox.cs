using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;

namespace DLC.Tools.Forms
{
    public class ErrorMessageBox
    {
        static ErrorMessageBox()
        {
            // Empty constructor
        }

        public static DialogResult Show( string Message, string Title, Exception ee )
        {
            ErrorMessageBox_Internal showError = new ErrorMessageBox_Internal(Message, Title, ee);
            return showError.ShowDialog();
        }

        public static DialogResult Show(string Message, string Title)
        {
            return Show(Message, Title, null);
        }

        public static DialogResult Show(string Message)
        {
            return Show(Message, String.Empty, null);
        }

    }
}
