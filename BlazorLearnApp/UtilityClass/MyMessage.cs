//using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Windows.Forms;

namespace BlazorLearnApp.UtilityClass
{
    public static class MyMessage
    {
        public static void Message(string message, string type="", string caption = "")
        {
            if (caption=="" && type !="")
            {
                caption = type;
            }
            else if (caption == "")
            {
                caption = "Information";
            }

            if(type =="")
            {
                //Speak.speakAsync(message);
            }
            else
            {
                //Speak.speakAsync(type + ", " + message);
            }

            if (type.ToLower()=="success")
            {
                //XtraMessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (type.ToLower() == "warning")
            {
                //XtraMessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (type.ToLower() == "danger")
            {
                //XtraMessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (type.ToLower() == "error")
            {
                //XtraMessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //XtraMessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public static bool Confirm(string message)
        {

            //Speak.speakAsync(message);

            //DialogResult dialogResult = XtraMessageBox.Show(message, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (dialogResult.ToString() == "No")
            //{
            //    return false;
            //}
            return true;
        }

    }
}
