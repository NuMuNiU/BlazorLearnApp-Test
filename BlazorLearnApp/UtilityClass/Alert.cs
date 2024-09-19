using System;
//using System.Windows.Forms;
//using System.Speech.Synthesis;

namespace BlazorLearnApp.UtilityClass
{
    public class Alert
    {
        public string Message { get; set; }
        public string Type { get; set; }
        public string Color { get; set; }

        public Alert()
        {

        }
        public Alert(string type, string message)
        {
            Message = message;
            Type = type;
            if (type == "warning")
            {
                Color = "red";
            }
            if (type == "success")
            {
                Color = "green";
            }
            if (type == "danger")
            {
                Color = "red";
            }
        }

        public void Show()
        {
            //Speak.speakAsync(Type + ", " + Message);

            if (Type == "success")
            {
                //DevExpress.XtraEditors.XtraMessageBox.Show(Message, Type, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (Type == "warning")
            {
                //DevExpress.XtraEditors.XtraMessageBox.Show(Message, Type, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (Type == "danger")
            {
                //DevExpress.XtraEditors.XtraMessageBox.Show(Message, Type, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}