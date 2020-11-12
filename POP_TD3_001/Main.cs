
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

namespace POP_TD3_001
{
    public partial class Main : Form
    {
        int nowmin = 0; // 현재시각 판별
        System.Threading.Timer timer = null; // 타이머 선언
        delegate void TimerEventFiredDelegate(); // 타이머이벤트
        TileItem selecteditem = null; // 클릭한 아이템 변수
        int blinkcount = 11; // 10 이하면 안내메세지 blink


        #region 메인폼관련 메소드
        public Main()
        {
            InitializeComponent();
            _barcodetext.Location = new Point(-100, -100);
            timer = new System.Threading.Timer(new System.Threading.TimerCallback(CallBack));
            timer.Change(20, 500);
            timer_time.Start();

            #region 추후 uc 동적으로 생성

            ucMachineList1.btnIF.Click += BtnIF_Click;
            ucMachineList2.btnIF.Click += BtnIF_Click;
            ucMachineList2.machine_name.Text = "절곡기";

            ucMachineList3.btnIF.Click += BtnIF_Click;
            ucMachineList3.machine_name.Text = "Load/Unload";

            ucMachineList4.btnIF.Click += BtnIF_Click;
            ucMachineList4.machine_name.Text = "Test_Machine";

            #endregion 


        }

        private void BtnIF_Click(object sender, EventArgs e)
        {
            try
            {
                ucMachineList clicked = ((ucMachineList)((SimpleButton)sender).Parent.Parent.Parent);
                clicked.Change_conn();
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
            ucMachineList[] machineList = new ucMachineList[4] { ucMachineList1, ucMachineList2, ucMachineList3, ucMachineList4 };

            //blink
            if (blinkcount < 10)
            {
                if (lbl_message.Visible == true)
                {
                    lbl_message.Visible = false;
                }
                else
                {
                    lbl_message.Visible = true;
                }

                blinkcount++;
            }

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
                foreach (ucMachineList item in machineList)
                {
                    if (item.machine_proc.Text == "Down")
                    {
                        //알람발생
                        item.machine_name.AppearanceItemCaption.BackColor = Color.FromArgb(255, 192, 192);

                        Message_Red(item.machine_name.Text + "설비 Down! 설비를 확인해주세요.");
                    }
                    else
                    {
                        item.machine_name.AppearanceItemCaption.BackColor = Color.Empty;

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

            if (selecteditem.Tag.ToString() == "수    량")
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

        private void PopUpOff()
        {
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
            PopupOn();




            popup_label.Text = e.Item.Tag.ToString();
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
        }

        private void PopupClear()
        {
            popup_edit.Text = "";
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
        private void btnmaterial_In_Click(object sender, EventArgs e)
        {
            if (Checkcode())
            {
                try
                {
                    //실행
                    Message_blue("자재가 입고되었습니다.");
                }
                catch (Exception ex)
                {
                    Message_Red(ex.ToString());
                }


            }
        }

        private void btnmaterial_Out_Click(object sender, EventArgs e)
        {
            if (Checkcode())
            {

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



        private void btnproduct_out_Click(object sender, EventArgs e)
        {
            //실행
            try
            {
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
                //실행
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
            blinkcount = 11;
            lbl_message.ForeColor = Color.RoyalBlue;
            lbl_message.Text = msg;
            lbl_message.Visible = true;
        }
        public void Message_Red(string msg)
        {
            lbl_message.ForeColor = Color.OrangeRed;
            lbl_message.Text = msg;
            blinkcount = 0;
            lbl_message.Visible = true;
        }
        #endregion


    }
}
