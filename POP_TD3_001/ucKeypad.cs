using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace POP_TD3_001
{
    public partial class ucKeypad : UserControl
    {
        TextEdit txtBox01;
        public ucKeypad()
        {
            InitializeComponent();
        }



        #region ○ 버튼 클릭시

        private void btnCmd_Click(object pSender, EventArgs pEventArgs)
        {
            SimpleButton pCmd = pSender as SimpleButton;

            string sCls = pCmd.Name.Substring(6, 2);
            switch (sCls)
            {
                case "01":
                    txtBox01.Text += "1"; txtBox01.Focus();
                    break;

                case "02":
                    txtBox01.Text += "2"; txtBox01.Focus();

                    break;

                case "03":
                    txtBox01.Text += "3"; txtBox01.Focus();
                    break;

                case "04":
                    txtBox01.Text += "4"; txtBox01.Focus();
                    break;

                case "05":
                    txtBox01.Text += "5"; txtBox01.Focus();
                    break;

                case "06":
                    txtBox01.Text += "6"; txtBox01.Focus();
                    break;

                case "07":
                    txtBox01.Text += "7"; txtBox01.Focus();
                    break;

                case "08":
                    txtBox01.Text += "8"; txtBox01.Focus();
                    break;

                case "09":
                    txtBox01.Text += "9"; txtBox01.Focus();
                    break;
                case "10":
                    txtBox01.Text += "0"; txtBox01.Focus();
                    break;
                case "00":
                    txtBox01.Text += "00"; txtBox01.Focus();
                    break;

                case "20":
                    // BS
                    if (txtBox01.Text.Length > 0)
                    {
                        txtBox01.Text = txtBox01.Text.Substring(0, txtBox01.Text.Length - 1);
                    }
                    break;



                default: break;
            }

        }

        public void SetEdit(TextEdit popup_edit)
        {
            txtBox01 = popup_edit;
        }

        #endregion
    }
}
