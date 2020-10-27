
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POP_TD3_001
{
    public partial class Main : Form
    {
        TileItem selecteditem = null;
        public Main()
        {
            InitializeComponent();
        }

        private void popupok_Click(object sender, EventArgs e)
        {
            PopUpOn();
            selecteditem.Text = popup_edit.Text;
        }

        private void PopUpOn()
        {
            itemselectedpopup.Visible = false;
            btnmaterial_In.Enabled = true;
            btnmaterial_Out.Enabled = true;
            btnproduct_out.Enabled = true;
            btnwork_Finish.Enabled = true;
        }

        private void tileBarItem_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            PopupOff();

            PopupClear();
            PopupOff();

            popup_label.Text = e.Item.Tag.ToString();
            selecteditem = e.Item;
        }

        private void PopupOff()
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
    }
}
