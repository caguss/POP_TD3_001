
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace POP_TD3_001
{

    public partial class Main : Form
    {
        int nowmin = 0; // 현재시각 판별
        System.Threading.Timer timer = null; // 타이머 선언
        SettingBusiness business = new SettingBusiness();
        delegate void TimerEventFiredDelegate(); // 타이머이벤트
        TileItem selecteditem = null; // 클릭한 아이템 변수
        ucMachineList[] machineList = null;
        DataTable list;


        #region 메인폼관련 메소드
        public Main()
        {
            InitializeComponent();
            ucKeypad1.SetEdit(popup_edit);
            machineList = new ucMachineList[3] { ucMachineList1, ucMachineList2, ucMachineList3 };
            _barcodetext.Location = new Point(-100, -100);
            timer = new System.Threading.Timer(new System.Threading.TimerCallback(CallBack));

            #region uc 동적으로 생성


            list = business.Machine_List();

            if (list.Rows.Count <= 3)
            {
                int i = 0;
                for (i = 0; i < list.Rows.Count; i++)
                {

                    machineList[i].machine_name.Text = list.Rows[i]["RES_ID"].ToString();
                    machineList[i].machine_conn.Text = list.Rows[i]["RES_IF_STS"].ToString();
                    machineList[i].machine_proc.Text = list.Rows[i]["RES_STS"].ToString();
                    machineList[i].machine_amount.Text = Math.Round(decimal.Parse(list.Rows[i]["PROD_QTY"].ToString()), 0).ToString().PadLeft(4, '0');
                    machineList[i].btnIF.Click += BtnIF_Click;
                }

                for (i = list.Rows.Count; i < 3; i++)
                {
                    machineList[i].Controls.Clear();
                }
                timer.Change(20, 500);
                timer_time.Start();

            }
            else
            {
                Message_Red("사용중인 설비가 3개 초과입니다. 데이터 베이스를 확인해 주세요 ");
            }

            #endregion

        }


        private void btn_number_Click(object sender, EventArgs e)
        {
            if (ucKeypad1.Visible)
            {
                ucKeypad1.Visible = false;
            }
            else
            {
                ucKeypad1.Visible = true;
            }
        }

        private void BtnIF_Click(object sender, EventArgs e)
        {
            try
            {
                //연결 끊기 
                ucMachineList clicked = ((ucMachineList)((SimpleButton)sender).Parent.Parent.Parent);
                clicked.Change_conn(clicked.machine_name.Text);
                Message_blue(clicked.machine_name.Text + " 설비의 연결 상태를 변경하였습니다.");
            }
            catch (Exception ex)
            {
                Message_Red(ex.ToString());
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Change(Timeout.Infinite, Timeout.Infinite);
        }

        #endregion


        #region 타이머 관련 메소드
        void CallBack(Object state)
        {
            BeginInvoke(new TimerEventFiredDelegate(barcode_ready));
        }
        private void barcode_ready()
        {


            if (_barcodetext.Text.Length != 13)
            {
                _barcodetext.Text = "";
            }
            else
            {
                tileBar_code.Text = _barcodetext.Text;
                _barcodetext.Text = "";

            }
            _barcodetext.Focus();
            this.ActiveControl = _barcodetext;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bool downcheck = false;

            //time
            CSafeSetText(lbl_time, DateTime.Now.ToString());
            if (DateTime.Now.Minute != nowmin)
            {
                nowmin = DateTime.Now.Minute;
            }

            if (downcheck) // db조회 Term을 늘리고싶어서 
            {
                downcheck = false;
            }
            else
            {
                downcheck = true;
            }

            if (downcheck)
            {
                for (int i = 0; i < list.Rows.Count; i++)
                {
                    try
                    {
                        //설비와 통신
                        machineList[i].machine_Refresh();
                    }
                    catch (Exception ex)
                    {
                        Message_Red(ex.ToString());
                    }

                    if (machineList[i].machine_proc.Text == "Down")
                    {
                        //알람발생
                        machineList[i].machine_name.AppearanceItemCaption.BackColor = Color.FromArgb(255, 192, 192);
                        Message_Red(machineList[i].machine_name.Text + "설비 Down! 설비를 확인해주세요.");
                    }
                    else
                    {
                        machineList[i].machine_name.AppearanceItemCaption.BackColor = Color.Empty;
                    }
                }
            }
        }

        delegate void CrossThreadSafetySetText(Control ctl, String text);

        private void CSafeSetText(Control ctl, String text)
        {
            if (ctl.InvokeRequired)
                ctl.Invoke(new CrossThreadSafetySetText(CSafeSetText), ctl, text);
            else
                ctl.Text = text;

        }

        #endregion


        #region TileBar 관련 메소드
        private void popupok_Click(object sender, EventArgs e)
        {

            if (selecteditem.Tag.ToString() == "수     량")
            {
                if (popup_edit.Text != "")
                {
                    int value;
                    if (!int.TryParse(popup_edit.Text, out value)) // 숫자가 아닐경우
                    {
                        Error_Message("수량은 숫자로만 입력 가능합니다.");
                        Message_Red("수량은 숫자로만 입력 가능합니다.");
                        return;
                    }

                }
            }

            selecteditem.Text = popup_edit.Text;
            PopUpOff();

            timer.Change(20, 500);


        }

        private void tileBar_process_ItemClick(object sender, TileItemEventArgs e)
        {
            PopUpOff();
        }
        private void PopUpOff()
        {
            ucKeypad1.Visible = false;
            itemselectedpopup.Visible = false;
            btnmaterial_In.Enabled = true;
            btnmaterial_Out.Enabled = true;
            btnproduct_out.Enabled = true;
            btnwork_Finish.Enabled = true;
            _barcodetext.Focus();
        }


        private void tileBarItem_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            timer.Change(Timeout.Infinite, Timeout.Infinite);


            PopupClear();
            popup_label.Text = e.Item.Tag.ToString();
            popup_edit.Text = e.Item.Text;
            PopupOn();




            selecteditem = e.Item;
            this.ActiveControl = popup_edit;
        }

        private void PopupOn()
        {
            itemselectedpopup.Visible = true;
            btnmaterial_In.Enabled = false;
            btnmaterial_Out.Enabled = false;
            btnproduct_out.Enabled = false;
            btnwork_Finish.Enabled = false;
            if (popup_label.Text == "수     량" || popup_label.Text == "작업지시")
            {
                btn_number.Visible = true;
            }
            else
            {
                btn_number.Visible = false;
            }
            popup_edit.Focus();
        }

        private void PopupClear()
        {
            popup_edit.Text = "";
        }

        private void tileBar1_DropDownShowing(object sender, DevExpress.XtraBars.Navigation.TileBarDropDownShowingEventArgs e)
        {
            PopUpOff();
        }
        private void tileBarItem_ItemClick_Child(object sender, TileItemEventArgs e)
        {
            tileBar_process.Text = e.Item.Text;
            tileBar1.HideDropDownWindow();
        }
        private void popup_edit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                popupok_Click(sender, e);
            }

        }

        #endregion

        #region 4개버튼 이벤트


        //자재입고
        private void btnmaterial_In_Click(object sender, EventArgs e)
        {
            if (Checkcode())
            {
                try
                {
                    OrderEntity entity = new OrderEntity();
                    entity.Order_id = tilebar_order.Text;
                    entity.Prod_num = tileBar_code.Text;
                    entity.Amount = int.Parse( tileBar_amount.Text);

                    switch (tileBar_process.Text)
                    {
                        case "절단":
                            entity.Process = "CUT001";
                            break;
                        case "절곡(노컷)":
                            entity.Process = "BEND001";
                            break;
                        case "절곡(V컷)":
                            entity.Process = "BEND002";
                            break;
                        case "용접/조립":
                            entity.Process = "ASSY001";
                            break;
                        case "도장":
                            entity.Process = "PAINT001";
                            break;
                    }

                    
                    entity.Worker = tileBar_worker.Text;
                    entity.Product_type = "RM";
                    entity.Remark = txt_remark.Text;
                    //실행
                    business.Resource_In(entity);

                    Message_blue("자재가 입고되었습니다.");
                }
                catch (Exception ex)
                {
                    Message_Red(ex.ToString());
                }


            }
        }

        //자재출고
        private void btnmaterial_Out_Click(object sender, EventArgs e)
        {
            if (Checkcode())
            {
                OrderEntity entity = new OrderEntity();
                entity.Order_id = tilebar_order.Text;
                entity.Prod_num = tileBar_code.Text;
                entity.Amount = int.Parse(tileBar_amount.Text);

                switch (tileBar_process.Text)
                {
                    case "절단":
                        entity.Process = "CUT001";
                        break;
                    case "절곡(노컷)":
                        entity.Process = "BEND001";
                        break;
                    case "절곡(V컷)":
                        entity.Process = "BEND002";
                        break;
                    case "용접/조립":
                        entity.Process = "ASSY001";
                        break;
                    case "도장":
                        entity.Process = "PAINT001";
                        break;
                }


                entity.Worker = tileBar_worker.Text;
                entity.Product_type = "RM";
                entity.Remark = txt_remark.Text;
                //실행
                business.Resource_Out(entity);
                //실행
                Message_blue("자재가 출고되었습니다.");

            }
        }


        private bool Checkcode()
        {
            if (tilebar_order.Text == "" && tileBar_code.Text == "")
            {
                Error_Message("품번 또는 작업지시 중\n한개는 필수로 입력해 주세요.");
                Message_Red("품번 또는 작업지시 중 한개는 필수로 입력해 주세요.");

                return false;
            }
            else
            {
                return true;
            }
        }


        //제품출하
        private void btnproduct_out_Click(object sender, EventArgs e)
        {
            //실행
            try
            {


                OrderEntity entity = new OrderEntity();
                entity.Order_id = tilebar_order.Text;
                entity.Prod_num = tileBar_code.Text;
                entity.Amount = int.Parse(tileBar_amount.Text);

                switch (tileBar_process.Text)
                {
                    case "절단":
                        entity.Process = "CUT001";
                        break;
                    case "절곡(노컷)":
                        entity.Process = "BEND001";
                        break;
                    case "절곡(V컷)":
                        entity.Process = "BEND002";
                        break;
                    case "용접/조립":
                        entity.Process = "ASSY001";
                        break;
                    case "도장":
                        entity.Process = "PAINT001";
                        break;
                }


                entity.Worker = tileBar_worker.Text;
                entity.Product_type = "FG";
                entity.Remark = txt_remark.Text;
                //실행
                business.Product_Out_I10(entity);


                Message_blue("제품출하가 완료되었습니다.");

            }
            catch (Exception ex)
            {
                Message_Red(ex.ToString());
            }
        }


        private void btnwork_Finish_Click(object sender, EventArgs e)
        {
            try
            {

                OrderEntity entity = new OrderEntity();
                entity.Order_id = tilebar_order.Text;
                entity.Prod_num = tileBar_code.Text;
                entity.Amount = int.Parse(tileBar_amount.Text);

                switch (tileBar_process.Text)
                {
                    case "절단":
                        entity.Process = "CUT001";
                        break;
                    case "절곡(노컷)":
                        entity.Process = "BEND001";
                        break;
                    case "절곡(V컷)":
                        entity.Process = "BEND002";
                        break;
                    case "용접/조립":
                        entity.Process = "ASSY001";
                        break;
                    case "도장":
                        entity.Process = "PAINT001";
                        break;
                }


                entity.Worker = tileBar_worker.Text;
                entity.Product_type = "FG";
                entity.Remark = txt_remark.Text;
                //실행
                business.Work_Finish_I10(entity);
                
                Message_blue("작업완료 처리되었습니다.");
            }
            catch (Exception ex)
            {
                Message_Red(ex.ToString());

            }
        }



        #endregion

        #region 메세지 메소드
        private void Args_Showing(object sender, XtraMessageShowingArgs e)
        {
            e.Form.Appearance.FontStyleDelta = FontStyle.Bold;
            e.Form.Appearance.Font = new Font(new FontFamily("맑은 고딕"), 40);

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

        public void Error_Message(string msg)
        {
            XtraMessageBoxArgs args = new XtraMessageBoxArgs();
            args.Caption = "경고";
            args.Text = msg;
            args.Buttons = new DialogResult[] { DialogResult.OK };
            args.Showing += Args_Showing;
            XtraMessageBox.Show(args).ToString();
        }

        public void Message_blue(string msg)
        {
            lbl_message.ForeColor = Color.RoyalBlue;
            lbl_message.Text = msg;
            lbl_message.Visible = true;
        }
        public void Message_Red(string msg)
        {
            lbl_message.ForeColor = Color.OrangeRed;
            lbl_message.Text = msg;
            lbl_message.Visible = true;
        }

        #endregion

        #region 비고 관련 메소드
        private void remark_Click(object sender, EventArgs e)
        {
            timer.Change(Timeout.Infinite, Timeout.Infinite);
        }

        private void txt_remark_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _barcodetext.Focus();
                this.ActiveControl = _barcodetext;
                timer.Change(20, 500);

            }
        }

        #endregion


    }
}
