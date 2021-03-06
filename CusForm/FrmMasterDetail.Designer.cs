namespace CusForm
{
    partial class FrmMasterDetail
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
            this.lciDelete = new DevExpress.XtraLayout.LayoutControlItem();
            this.simpleButtonDelete = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            this.simpleButtonCopy = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonPreview = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonSearch = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonEdit = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonNew = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonCancel2 = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciNew = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciEdit = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lciSearch = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciPrint = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciCopy = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this._bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).BeginInit();
            this.layoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCopy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            this.SuspendLayout();
            // 
            // lciDelete
            // 
            this.lciDelete.Control = this.simpleButtonDelete;
            this.lciDelete.CustomizationFormText = "layoutControlItem5";
            this.lciDelete.Location = new System.Drawing.Point(344, 0);
            this.lciDelete.Name = "lciDelete";
            this.lciDelete.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.lciDelete.Size = new System.Drawing.Size(85, 38);
            this.lciDelete.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.lciDelete.Text = "lciDelete";
            this.lciDelete.TextSize = new System.Drawing.Size(0, 0);
            this.lciDelete.TextToControlDistance = 0;
            this.lciDelete.TextVisible = false;
            // 
            // simpleButtonDelete
            // 
            this.simpleButtonDelete.Location = new System.Drawing.Point(351, 7);
            this.simpleButtonDelete.Name = "simpleButtonDelete";
            this.simpleButtonDelete.Size = new System.Drawing.Size(74, 22);
            this.simpleButtonDelete.StyleController = this.layoutControl2;
            this.simpleButtonDelete.TabIndex = 6;
            this.simpleButtonDelete.Text = "F4-Xóa";
            this.simpleButtonDelete.Click += new System.EventHandler(this.simpleButtonDelete_Click);
            // 
            // layoutControl2
            // 
            this.layoutControl2.Controls.Add(this.simpleButtonCopy);
            this.layoutControl2.Controls.Add(this.simpleButtonPreview);
            this.layoutControl2.Controls.Add(this.simpleButtonSearch);
            this.layoutControl2.Controls.Add(this.simpleButtonDelete);
            this.layoutControl2.Controls.Add(this.simpleButtonEdit);
            this.layoutControl2.Controls.Add(this.simpleButtonNew);
            this.layoutControl2.Controls.Add(this.simpleButtonCancel2);
            this.layoutControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.layoutControl2.Location = new System.Drawing.Point(0, 526);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.Root = this.layoutControlGroup3;
            this.layoutControl2.Size = new System.Drawing.Size(792, 40);
            this.layoutControl2.TabIndex = 3;
            this.layoutControl2.Text = "layoutControl2";
            // 
            // simpleButtonCopy
            // 
            this.simpleButtonCopy.Location = new System.Drawing.Point(436, 7);
            this.simpleButtonCopy.Name = "simpleButtonCopy";
            this.simpleButtonCopy.Size = new System.Drawing.Size(79, 22);
            this.simpleButtonCopy.StyleController = this.layoutControl2;
            this.simpleButtonCopy.TabIndex = 10;
            this.simpleButtonCopy.Text = "F5-Sao chép";
            this.simpleButtonCopy.Click += new System.EventHandler(this.simpleButtonCopy_Click);
            // 
            // simpleButtonPreview
            // 
            this.simpleButtonPreview.Location = new System.Drawing.Point(610, 7);
            this.simpleButtonPreview.Name = "simpleButtonPreview";
            this.simpleButtonPreview.Size = new System.Drawing.Size(65, 22);
            this.simpleButtonPreview.StyleController = this.layoutControl2;
            this.simpleButtonPreview.TabIndex = 9;
            this.simpleButtonPreview.Text = "F7-In";
            this.simpleButtonPreview.Click += new System.EventHandler(this.simpleButtonPreview_Click);
            // 
            // simpleButtonSearch
            // 
            this.simpleButtonSearch.Location = new System.Drawing.Point(526, 7);
            this.simpleButtonSearch.Name = "simpleButtonSearch";
            this.simpleButtonSearch.Size = new System.Drawing.Size(73, 22);
            this.simpleButtonSearch.StyleController = this.layoutControl2;
            this.simpleButtonSearch.TabIndex = 8;
            this.simpleButtonSearch.Text = "F6-Tìm kiếm";
            this.simpleButtonSearch.Click += new System.EventHandler(this.simpleButtonSearch_Click);
            // 
            // simpleButtonEdit
            // 
            this.simpleButtonEdit.Location = new System.Drawing.Point(273, 7);
            this.simpleButtonEdit.Name = "simpleButtonEdit";
            this.simpleButtonEdit.Size = new System.Drawing.Size(67, 22);
            this.simpleButtonEdit.StyleController = this.layoutControl2;
            this.simpleButtonEdit.TabIndex = 5;
            this.simpleButtonEdit.Text = "F3-Sửa";
            this.simpleButtonEdit.Click += new System.EventHandler(this.simpleButtonEdit_Click);
            // 
            // simpleButtonNew
            // 
            this.simpleButtonNew.Location = new System.Drawing.Point(187, 7);
            this.simpleButtonNew.Name = "simpleButtonNew";
            this.simpleButtonNew.Size = new System.Drawing.Size(75, 22);
            this.simpleButtonNew.StyleController = this.layoutControl2;
            this.simpleButtonNew.TabIndex = 4;
            this.simpleButtonNew.Text = "F2-Thêm";
            this.simpleButtonNew.Click += new System.EventHandler(this.simpleButtonNew_Click);
            // 
            // simpleButtonCancel2
            // 
            this.simpleButtonCancel2.Location = new System.Drawing.Point(686, 7);
            this.simpleButtonCancel2.Name = "simpleButtonCancel2";
            this.simpleButtonCancel2.Size = new System.Drawing.Size(100, 22);
            this.simpleButtonCancel2.StyleController = this.layoutControl2;
            this.simpleButtonCancel2.TabIndex = 7;
            this.simpleButtonCancel2.Text = "ESC-Thoát";
            this.simpleButtonCancel2.Click += new System.EventHandler(this.simpleButtonCancel2_Click);
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.CustomizationFormText = "layoutControlGroup3";
            this.layoutControlGroup3.DefaultLayoutType = DevExpress.XtraLayout.Utils.LayoutType.Horizontal;
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciNew,
            this.lciEdit,
            this.lciDelete,
            this.emptySpaceItem3,
            this.lciSearch,
            this.lciPrint,
            this.lciCopy,
            this.layoutControlItem6});
            this.layoutControlGroup3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup3.Size = new System.Drawing.Size(792, 40);
            this.layoutControlGroup3.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup3.Text = "layoutControlGroup3";
            this.layoutControlGroup3.TextVisible = false;
            // 
            // lciNew
            // 
            this.lciNew.Control = this.simpleButtonNew;
            this.lciNew.CustomizationFormText = "layoutControlItem3";
            this.lciNew.Location = new System.Drawing.Point(180, 0);
            this.lciNew.Name = "lciNew";
            this.lciNew.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.lciNew.Size = new System.Drawing.Size(86, 38);
            this.lciNew.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.lciNew.Text = "lciNew";
            this.lciNew.TextSize = new System.Drawing.Size(0, 0);
            this.lciNew.TextToControlDistance = 0;
            this.lciNew.TextVisible = false;
            // 
            // lciEdit
            // 
            this.lciEdit.Control = this.simpleButtonEdit;
            this.lciEdit.CustomizationFormText = "layoutControlItem4";
            this.lciEdit.Location = new System.Drawing.Point(266, 0);
            this.lciEdit.Name = "lciEdit";
            this.lciEdit.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.lciEdit.Size = new System.Drawing.Size(78, 38);
            this.lciEdit.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.lciEdit.Text = "lciEdit";
            this.lciEdit.TextSize = new System.Drawing.Size(0, 0);
            this.lciEdit.TextToControlDistance = 0;
            this.lciEdit.TextVisible = false;
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.CustomizationFormText = "emptySpaceItem3";
            this.emptySpaceItem3.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.emptySpaceItem3.Size = new System.Drawing.Size(180, 38);
            this.emptySpaceItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.emptySpaceItem3.Text = "emptySpaceItem3";
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lciSearch
            // 
            this.lciSearch.Control = this.simpleButtonSearch;
            this.lciSearch.CustomizationFormText = "layoutControlItem1";
            this.lciSearch.Location = new System.Drawing.Point(519, 0);
            this.lciSearch.Name = "lciSearch";
            this.lciSearch.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.lciSearch.Size = new System.Drawing.Size(84, 38);
            this.lciSearch.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.lciSearch.Text = "lciSearch";
            this.lciSearch.TextSize = new System.Drawing.Size(0, 0);
            this.lciSearch.TextToControlDistance = 0;
            this.lciSearch.TextVisible = false;
            // 
            // lciPrint
            // 
            this.lciPrint.Control = this.simpleButtonPreview;
            this.lciPrint.CustomizationFormText = "layoutControlItem2";
            this.lciPrint.Location = new System.Drawing.Point(603, 0);
            this.lciPrint.Name = "lciPrint";
            this.lciPrint.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.lciPrint.Size = new System.Drawing.Size(76, 38);
            this.lciPrint.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.lciPrint.Text = "lciPrint";
            this.lciPrint.TextSize = new System.Drawing.Size(0, 0);
            this.lciPrint.TextToControlDistance = 0;
            this.lciPrint.TextVisible = false;
            // 
            // lciCopy
            // 
            this.lciCopy.Control = this.simpleButtonCopy;
            this.lciCopy.CustomizationFormText = "layoutControlItem7";
            this.lciCopy.Location = new System.Drawing.Point(429, 0);
            this.lciCopy.Name = "lciCopy";
            this.lciCopy.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.lciCopy.Size = new System.Drawing.Size(90, 38);
            this.lciCopy.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.lciCopy.Text = "lciCopy";
            this.lciCopy.TextSize = new System.Drawing.Size(0, 0);
            this.lciCopy.TextToControlDistance = 0;
            this.lciCopy.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.simpleButtonCancel2;
            this.layoutControlItem6.CustomizationFormText = "layoutControlItem6";
            this.layoutControlItem6.Location = new System.Drawing.Point(679, 0);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem6.Size = new System.Drawing.Size(111, 38);
            this.layoutControlItem6.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem6.Text = "layoutControlItem6";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextToControlDistance = 0;
            this.layoutControlItem6.TextVisible = false;
            // 
            // FrmMasterDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.layoutControl2);
            this.KeyPreview = true;
            this.Name = "FrmMasterDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmMasterDetail";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmMasterDetail_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this._bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).EndInit();
            this.layoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCopy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControlItem lciDelete;
        private DevExpress.XtraEditors.SimpleButton simpleButtonDelete;
        private DevExpress.XtraLayout.LayoutControl layoutControl2;
        private DevExpress.XtraEditors.SimpleButton simpleButtonCopy;
        private DevExpress.XtraEditors.SimpleButton simpleButtonPreview;
        private DevExpress.XtraEditors.SimpleButton simpleButtonSearch;
        private DevExpress.XtraEditors.SimpleButton simpleButtonCancel2;
        private DevExpress.XtraEditors.SimpleButton simpleButtonEdit;
        private DevExpress.XtraEditors.SimpleButton simpleButtonNew;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraLayout.LayoutControlItem lciNew;
        private DevExpress.XtraLayout.LayoutControlItem lciEdit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraLayout.LayoutControlItem lciSearch;
        private DevExpress.XtraLayout.LayoutControlItem lciPrint;
        private DevExpress.XtraLayout.LayoutControlItem lciCopy;
    }
}