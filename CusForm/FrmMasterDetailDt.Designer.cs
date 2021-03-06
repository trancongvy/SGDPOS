namespace CusForm
{
    partial class FrmMasterDetailDt
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dxErrorProviderMain = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.dataNavigatorMain = new DevExpress.XtraEditors.DataNavigator();
            ((System.ComponentModel.ISupportInitialize)(this._bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProviderMain)).BeginInit();
            this.SuspendLayout();
            // 
            // dxErrorProviderMain
            // 
            this.dxErrorProviderMain.ContainerControl = this;
            // 
            // dataNavigatorMain
            // 
            this.dataNavigatorMain.Buttons.Append.Visible = false;
            this.dataNavigatorMain.Buttons.CancelEdit.Hint = "ESC - Bỏ qua";
            this.dataNavigatorMain.Buttons.EndEdit.Hint = "F12 - Lưu";
            this.dataNavigatorMain.Buttons.First.Hint = "Ctrl+PageUp - Mục đầu tiên";
            this.dataNavigatorMain.Buttons.Last.Hint = "Ctrl+PageDown - Mục sau cùng";
            this.dataNavigatorMain.Buttons.Next.Hint = "PageDown - Mục tiếp theo";
            this.dataNavigatorMain.Buttons.NextPage.Visible = false;
            this.dataNavigatorMain.Buttons.Prev.Hint = "PageUp - Mục trước";
            this.dataNavigatorMain.Buttons.PrevPage.Visible = false;
            this.dataNavigatorMain.Buttons.Remove.Visible = false;
            this.dataNavigatorMain.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataNavigatorMain.Location = new System.Drawing.Point(0, 542);
            this.dataNavigatorMain.Name = "dataNavigatorMain";
            this.dataNavigatorMain.ShowToolTips = true;
            this.dataNavigatorMain.Size = new System.Drawing.Size(792, 24);
            this.dataNavigatorMain.TabIndex = 2;
            this.dataNavigatorMain.Text = "dataNavigator1";
            this.dataNavigatorMain.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.Center;
            this.dataNavigatorMain.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.dataNavigatorMain_ButtonClick);
            // 
            // FrmMasterDetailDt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.dataNavigatorMain);
            this.KeyPreview = true;
            this.Name = "FrmMasterDetailDt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmMasterDetailCt";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMasterDetailDt_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmMasterDetailDt_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this._bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProviderMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProviderMain;
        private DevExpress.XtraEditors.DataNavigator dataNavigatorMain;
    }
}