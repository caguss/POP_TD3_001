
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

        System.Threading.Timer timer = null; // 타이머 선언
        delegate void TimerEventFiredDelegate(); // 타이머이벤트
        TileItem selecteditem = null; // 클릭한 아이템 변수



        #region 메인폼관련 메소드
        public Main()
        {
            InitializeComponent();
            _barcodetext.Location = new Point(-100, -100);
            timer = new System.Threading.Timer(new System.Threading.TimerCallback(CallBack));
            timer.Change(0, 500);
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
        #endregion


        #region TileBar 관련 메소드
        private void popupok_Click(object sender, EventArgs e)
        {
            PopUpOff();
            selecteditem.Text = popup_edit.Text;
            timer.Change(0, 500);

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
            Checkcode();
        }

        private void btnmaterial_Out_Click(object sender, EventArgs e)
        {

        }
        

        private bool Checkcode()
        {
            if (tilebar_order.Text == "" && tileBar_code.Text == "")
            {
                XtraMessageBoxArgs args = new XtraMessageBoxArgs();
                args.Caption = "경고";
                args.Text = "품번 또는 작업지시 중\n한개는 필수로 입력해 주세요.";
                args.Buttons = new DialogResult[] { DialogResult.OK };
                args.Showing += Args_Showing;
                XtraMessageBox.Show(args).ToString();
                return false;
            }
            else
            {
                return true;
            }
        }



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
        #endregion
      


    }
}
