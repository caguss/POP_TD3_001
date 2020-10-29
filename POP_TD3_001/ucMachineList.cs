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
            machine_Refresh();
        }

        private void machine_Refresh()
        {
            //DB로 값 불러오기
            string equip_status = machine_proc.Text;
            string conn_status = machine_conn.Text;


            switch (conn_status) // 연결상태
            {
                case "Off-Line": // Off-Line
                    machine_conn.Text = "Off-Line";
                    machine_conn.AppearanceItemCaption.ForeColor = Color.Crimson;
                    break;
                case "On-Line":// On-Line
                    machine_conn.Text = "On-Line";
                    machine_conn.AppearanceItemCaption.ForeColor = Color.MediumBlue;
                    break;
            }

            switch (equip_status) // 설비상태
            {
                case "생산중": // 생산중
                    machine_proc.Text = "생산중";
                    machine_proc.AppearanceItemCaption.ForeColor = Color.ForestGreen;
                    break;
                case "대기중":// 대기중
                    machine_proc.Text = "대기중";
                    machine_proc.AppearanceItemCaption.ForeColor = Color.LimeGreen;
                    break;
                case "Down":// down
                    machine_proc.Text = "생산중";
                    machine_proc.AppearanceItemCaption.ForeColor = Color.Red;
                    break;
            }
        }
        #region 메세지 메소드
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
        #endregion


        private void btnIF_Click(object sender, EventArgs e)
        {
            
            switch (machine_conn.Text) // 연결상태
            {
                case "On-Line":
                    try
                    {
                        //db로 업데이트
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
                        //db로 업데이트
                        machine_conn.Text = "On-Line";
                        machine_conn.AppearanceItemCaption.ForeColor = Color.MediumBlue;
                    }
                    catch (Exception ex)
                    {
                        ShowErrorMessage(ex);

                    }

                    break;
            }


            machine_Refresh();
        }
    }
}
