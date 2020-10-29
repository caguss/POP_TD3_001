using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace POP_TD3_001
{
    public partial class ucMachineList : DevExpress.XtraEditors.XtraUserControl
    {
        public ucMachineList()
        {
            InitializeComponent();
        }

        private void ChangeConnection(object sender, EventArgs e)
        {

            switch (machine_conn.Text)
            {
                case "On-Line":
                    try
                    {

                        //db로 offline으로 변경 

                        machine_conn.Text = "Off-Line";
                        machine_conn.AppearanceItemCaption.ForeColor = Color.Crimson;

                    }
                    catch (Exception ex)
                    {
                        ShowErrorMessage(ex);
                    }

                    break;

                case "Off-Line":
                    try
                    {
                        //db로 online으로 변경 


                        machine_conn.Text = "On-Line";
                        machine_conn.AppearanceItemCaption.ForeColor = Color.MediumBlue;
                    }
                    catch (Exception ex)
                    {
                        ShowErrorMessage(ex);
                    }

                    break;
            }


        }

        private void ShowErrorMessage(Exception ex)
        {
            XtraMessageBoxArgs args = new XtraMessageBoxArgs();
            args.Caption = "ERROR";
            args.Text = "에러 : 잠시 후 다시 시도해 주세요. 에러내용 : " + ex;
            args.Buttons = new DialogResult[] { DialogResult.OK };
            args.Showing += Args_Showing;
            XtraMessageBox.Show(args).ToString();
        }

        private void Args_Showing(object sender, XtraMessageShowingArgs e)
        {
            e.Form.Appearance.FontStyleDelta = FontStyle.Bold;
            e.Form.Appearance.Font = new Font(new FontFamily("맑은 고딕"), 20);

            MessageButtonCollection buttons = e.Buttons as MessageButtonCollection;
            SimpleButton btn = buttons[System.Windows.Forms.DialogResult.OK] as SimpleButton;
            btn.Text = "확인";

            if (btn != null)
            {
                btn.Appearance.FontSizeDelta = 20;
                btn.Height -= 200;
                btn.Size = new Size(200, 100);
            }
        }
    }
}
