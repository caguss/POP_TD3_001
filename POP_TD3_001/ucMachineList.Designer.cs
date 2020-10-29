namespace POP_TD3_001
{
    partial class ucMachineList
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnIF = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.machine_conn = new DevExpress.XtraLayout.SimpleLabelItem();
            this.machine_proc = new DevExpress.XtraLayout.SimpleLabelItem();
            this.simpleLabelItem3 = new DevExpress.XtraLayout.SimpleLabelItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.machine_name = new DevExpress.XtraLayout.SimpleLabelItem();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.machine_conn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.machine_proc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.machine_name)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BorderColor = System.Drawing.Color.Black;
            this.panelControl1.Appearance.Options.UseBorderColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.panelControl1.Controls.Add(this.btnIF);
            this.panelControl1.Location = new System.Drawing.Point(213, 0);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(114, 90);
            this.panelControl1.TabIndex = 6;
            // 
            // btnIF
            // 
            this.btnIF.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIF.Appearance.BackColor = System.Drawing.Color.DarkGray;
            this.btnIF.Appearance.Options.UseBackColor = true;
            this.btnIF.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.btnIF.Location = new System.Drawing.Point(5, 18);
            this.btnIF.LookAndFeel.SkinMaskColor = System.Drawing.Color.Fuchsia;
            this.btnIF.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.btnIF.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnIF.Margin = new System.Windows.Forms.Padding(0);
            this.btnIF.Name = "btnIF";
            this.btnIF.Size = new System.Drawing.Size(104, 58);
            this.btnIF.TabIndex = 0;
            this.btnIF.Click += new System.EventHandler(this.ChangeConnection);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.AppearanceGroup.BorderColor = System.Drawing.Color.Black;
            this.layoutControlGroup1.AppearanceGroup.Options.UseBorderColor = true;
            this.layoutControlGroup1.AppearanceItemCaption.BorderColor = System.Drawing.Color.Black;
            this.layoutControlGroup1.AppearanceItemCaption.Options.UseBorderColor = true;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.machine_conn,
            this.machine_proc,
            this.simpleLabelItem3,
            this.layoutControlItem3,
            this.machine_name});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.OptionsPrint.AppearanceGroupCaption.BorderColor = System.Drawing.Color.Black;
            this.layoutControlGroup1.OptionsPrint.AppearanceGroupCaption.Options.UseBorderColor = true;
            this.layoutControlGroup1.OptionsPrint.AppearanceItemCaption.BorderColor = System.Drawing.Color.Black;
            this.layoutControlGroup1.OptionsPrint.AppearanceItemCaption.Options.UseBorderColor = true;
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(-1, -1, -1, -1);
            this.layoutControlGroup1.Size = new System.Drawing.Size(922, 90);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // machine_conn
            // 
            this.machine_conn.AllowHotTrack = false;
            this.machine_conn.AppearanceItemCaption.BorderColor = System.Drawing.Color.Black;
            this.machine_conn.AppearanceItemCaption.Font = new System.Drawing.Font("맑은 고딕", 20F, System.Drawing.FontStyle.Bold);
            this.machine_conn.AppearanceItemCaption.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.machine_conn.AppearanceItemCaption.Options.UseBorderColor = true;
            this.machine_conn.AppearanceItemCaption.Options.UseFont = true;
            this.machine_conn.AppearanceItemCaption.Options.UseTextOptions = true;
            this.machine_conn.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.machine_conn.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.machine_conn.Location = new System.Drawing.Point(327, 0);
            this.machine_conn.MinSize = new System.Drawing.Size(98, 37);
            this.machine_conn.Name = "machine_conn";
            this.machine_conn.OptionsPrint.AppearanceItemCaption.BorderColor = System.Drawing.Color.Black;
            this.machine_conn.OptionsPrint.AppearanceItemCaption.Options.UseBorderColor = true;
            this.machine_conn.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.machine_conn.Size = new System.Drawing.Size(225, 90);
            this.machine_conn.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.machine_conn.Text = "On-Line";
            this.machine_conn.TextSize = new System.Drawing.Size(100, 37);
            // 
            // machine_proc
            // 
            this.machine_proc.AllowHotTrack = false;
            this.machine_proc.AppearanceItemCaption.Font = new System.Drawing.Font("맑은 고딕", 20F, System.Drawing.FontStyle.Bold);
            this.machine_proc.AppearanceItemCaption.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.machine_proc.AppearanceItemCaption.Options.UseFont = true;
            this.machine_proc.AppearanceItemCaption.Options.UseTextOptions = true;
            this.machine_proc.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.machine_proc.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.machine_proc.Location = new System.Drawing.Point(552, 0);
            this.machine_proc.MinSize = new System.Drawing.Size(98, 37);
            this.machine_proc.Name = "machine_proc";
            this.machine_proc.OptionsPrint.AppearanceItemCaption.BorderColor = System.Drawing.Color.Black;
            this.machine_proc.OptionsPrint.AppearanceItemCaption.Options.UseBorderColor = true;
            this.machine_proc.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.machine_proc.Size = new System.Drawing.Size(185, 90);
            this.machine_proc.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.machine_proc.Text = "생산중";
            this.machine_proc.TextSize = new System.Drawing.Size(100, 37);
            // 
            // simpleLabelItem3
            // 
            this.simpleLabelItem3.AllowHotTrack = false;
            this.simpleLabelItem3.AppearanceItemCaption.BorderColor = System.Drawing.Color.Black;
            this.simpleLabelItem3.AppearanceItemCaption.Font = new System.Drawing.Font("맑은 고딕", 20F, System.Drawing.FontStyle.Bold);
            this.simpleLabelItem3.AppearanceItemCaption.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.simpleLabelItem3.AppearanceItemCaption.Options.UseBorderColor = true;
            this.simpleLabelItem3.AppearanceItemCaption.Options.UseFont = true;
            this.simpleLabelItem3.AppearanceItemCaption.Options.UseTextOptions = true;
            this.simpleLabelItem3.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.simpleLabelItem3.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.simpleLabelItem3.Location = new System.Drawing.Point(737, 0);
            this.simpleLabelItem3.MinSize = new System.Drawing.Size(98, 37);
            this.simpleLabelItem3.Name = "simpleLabelItem3";
            this.simpleLabelItem3.OptionsPrint.AppearanceItemCaption.BorderColor = System.Drawing.Color.Black;
            this.simpleLabelItem3.OptionsPrint.AppearanceItemCaption.Options.UseBorderColor = true;
            this.simpleLabelItem3.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.simpleLabelItem3.Size = new System.Drawing.Size(185, 90);
            this.simpleLabelItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.simpleLabelItem3.Text = "000";
            this.simpleLabelItem3.TextSize = new System.Drawing.Size(100, 37);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.panelControl1;
            this.layoutControlItem3.Location = new System.Drawing.Point(213, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem3.Size = new System.Drawing.Size(114, 90);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // machine_name
            // 
            this.machine_name.AllowHotTrack = false;
            this.machine_name.AppearanceItemCaption.BorderColor = System.Drawing.Color.Black;
            this.machine_name.AppearanceItemCaption.Font = new System.Drawing.Font("맑은 고딕", 20F, System.Drawing.FontStyle.Bold);
            this.machine_name.AppearanceItemCaption.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.machine_name.AppearanceItemCaption.Options.UseBorderColor = true;
            this.machine_name.AppearanceItemCaption.Options.UseFont = true;
            this.machine_name.AppearanceItemCaption.Options.UseTextOptions = true;
            this.machine_name.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.machine_name.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.machine_name.Location = new System.Drawing.Point(0, 0);
            this.machine_name.MinSize = new System.Drawing.Size(98, 37);
            this.machine_name.Name = "machine_name";
            this.machine_name.OptionsPrint.AppearanceItemCaption.BorderColor = System.Drawing.Color.Black;
            this.machine_name.OptionsPrint.AppearanceItemCaption.Options.UseBorderColor = true;
            this.machine_name.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.machine_name.Size = new System.Drawing.Size(213, 90);
            this.machine_name.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.machine_name.Text = "절단기";
            this.machine_name.TextSize = new System.Drawing.Size(100, 37);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Appearance.Control.BorderColor = System.Drawing.Color.Black;
            this.layoutControl1.Appearance.Control.Options.UseBorderColor = true;
            this.layoutControl1.Appearance.DisabledLayoutGroupCaption.BorderColor = System.Drawing.Color.Black;
            this.layoutControl1.Appearance.DisabledLayoutGroupCaption.Options.UseBorderColor = true;
            this.layoutControl1.Appearance.DisabledLayoutItem.BorderColor = System.Drawing.Color.Black;
            this.layoutControl1.Appearance.DisabledLayoutItem.Options.UseBorderColor = true;
            this.layoutControl1.Controls.Add(this.panelControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.LookAndFeel.SkinMaskColor = System.Drawing.Color.Black;
            this.layoutControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(584, 288, 650, 400);
            this.layoutControl1.OptionsView.DrawItemBorders = true;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(922, 90);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // ucMachineList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucMachineList";
            this.Size = new System.Drawing.Size(922, 90);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.machine_conn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.machine_proc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.machine_name)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnIF;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.SimpleLabelItem machine_conn;
        private DevExpress.XtraLayout.SimpleLabelItem machine_proc;
        private DevExpress.XtraLayout.SimpleLabelItem simpleLabelItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.SimpleLabelItem machine_name;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
    }
}
