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
        SettingBusiness business = new SettingBusiness();
        public ucMachineList()
        {
            InitializeComponent();
        }

        public void machine_Refresh()
        {

            //DB로 값 불러오기
            DataTable pDataTable = business.Machine_Refresh(machine_name.Text);

            string equip_status = pDataTable.Rows[0]["RES_STS"].ToString();
            string conn_status = pDataTable.Rows[0]["RES_IF_STS"].ToString();


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
                    machine_proc.Text = "Down";
                    machine_proc.AppearanceItemCaption.ForeColor = Color.Red;
                    //알람 보내기 -> Main Form 에서 처리
                    break;
            }

            //생산실적



        }

        public void Change_conn(string machine_name)
        {
            business.Change_Connection(machine_name);

            //switch (machine_conn.Text) // 연결상태
            //{
            //    case "On-Line":

            //        //db로 업데이트
            //        machine_conn.Text = "Off-Line";
            //        machine_conn.AppearanceItemCaption.ForeColor = Color.Crimson;
            //        break;

            //    case "Off-Line":

            //        //db로 업데이트
            //        machine_conn.Text = "On-Line";
            //        machine_conn.AppearanceItemCaption.ForeColor = Color.MediumBlue;
            //        break;
            //}

        }

    }
}
