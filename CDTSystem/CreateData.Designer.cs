using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using System.ComponentModel;
using System;
using System.Drawing;
using System.Windows.Forms;
namespace CDTSystem
{
    partial class CreateData
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.ckUpdateRemote = new DevExpress.XtraEditors.CheckEdit();
            this.txtRemoteServer = new DevExpress.XtraEditors.TextEdit();
            this.txtCDTOld = new DevExpress.XtraEditors.TextEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.cEis2005 = new DevExpress.XtraEditors.CheckEdit();
            this.txtCDT = new DevExpress.XtraEditors.TextEdit();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.radioGroupCnnType = new DevExpress.XtraEditors.RadioGroup();
            this.simpleButtonOk = new DevExpress.XtraEditors.SimpleButton();
            this.textEditPassword = new DevExpress.XtraEditors.TextEdit();
            this.textEditUser = new DevExpress.XtraEditors.TextEdit();
            this.textEditServer = new DevExpress.XtraEditors.TextEdit();
            this.simpleButtonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.radioGroupType = new DevExpress.XtraEditors.RadioGroup();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem5 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem6 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemProgress = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem7 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem13 = new DevExpress.XtraLayout.LayoutControlItem();
            this.dxErrorProviderMain = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.CkUpdateLocal = new DevExpress.XtraEditors.CheckEdit();
            this.tlo = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ckUpdateRemote.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemoteServer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCDTOld.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cEis2005.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCDT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupCnnType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditServer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemProgress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProviderMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CkUpdateLocal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tlo)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.CkUpdateLocal);
            this.layoutControl1.Controls.Add(this.ckUpdateRemote);
            this.layoutControl1.Controls.Add(this.txtRemoteServer);
            this.layoutControl1.Controls.Add(this.txtCDTOld);
            this.layoutControl1.Controls.Add(this.simpleButton1);
            this.layoutControl1.Controls.Add(this.cEis2005);
            this.layoutControl1.Controls.Add(this.txtCDT);
            this.layoutControl1.Controls.Add(this.textEdit1);
            this.layoutControl1.Controls.Add(this.radioGroupCnnType);
            this.layoutControl1.Controls.Add(this.simpleButtonOk);
            this.layoutControl1.Controls.Add(this.textEditPassword);
            this.layoutControl1.Controls.Add(this.textEditUser);
            this.layoutControl1.Controls.Add(this.textEditServer);
            this.layoutControl1.Controls.Add(this.simpleButtonCancel);
            this.layoutControl1.Controls.Add(this.radioGroupType);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(638, 459);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // ckUpdateRemote
            // 
            this.ckUpdateRemote.Location = new System.Drawing.Point(411, 101);
            this.ckUpdateRemote.Name = "ckUpdateRemote";
            this.ckUpdateRemote.Properties.Caption = "Cập nhật máy chủ từ xa";
            this.ckUpdateRemote.Size = new System.Drawing.Size(162, 19);
            this.ckUpdateRemote.StyleController = this.layoutControl1;
            this.ckUpdateRemote.TabIndex = 16;
            // 
            // txtRemoteServer
            // 
            this.txtRemoteServer.EditValue = "192.168.0.104\\SQLSGD2005";
            this.txtRemoteServer.EnterMoveNextControl = true;
            this.txtRemoteServer.Location = new System.Drawing.Point(153, 101);
            this.txtRemoteServer.Name = "txtRemoteServer";
            this.txtRemoteServer.Size = new System.Drawing.Size(248, 20);
            this.txtRemoteServer.StyleController = this.layoutControl1;
            this.txtRemoteServer.TabIndex = 6;
            // 
            // txtCDTOld
            // 
            this.txtCDTOld.Location = new System.Drawing.Point(153, 225);
            this.txtCDTOld.Name = "txtCDTOld";
            this.txtCDTOld.Size = new System.Drawing.Size(420, 20);
            this.txtCDTOld.StyleController = this.layoutControl1;
            this.txtCDTOld.TabIndex = 15;
            this.txtCDTOld.Visible = false;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(447, 163);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(126, 22);
            this.simpleButton1.StyleController = this.layoutControl1;
            this.simpleButton1.TabIndex = 14;
            this.simpleButton1.Text = "Mở rộng>>";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // cEis2005
            // 
            this.cEis2005.EditValue = true;
            this.cEis2005.Location = new System.Drawing.Point(72, 255);
            this.cEis2005.Name = "cEis2005";
            this.cEis2005.Properties.Caption = "Database server 2005";
            this.cEis2005.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.cEis2005.Size = new System.Drawing.Size(501, 19);
            this.cEis2005.StyleController = this.layoutControl1;
            this.cEis2005.TabIndex = 13;
            // 
            // txtCDT
            // 
            this.txtCDT.EditValue = "CDTT";
            this.txtCDT.Location = new System.Drawing.Point(153, 195);
            this.txtCDT.Name = "txtCDT";
            this.txtCDT.Size = new System.Drawing.Size(420, 20);
            this.txtCDT.StyleController = this.layoutControl1;
            this.txtCDT.TabIndex = 12;
            this.txtCDT.TabStop = false;
            this.txtCDT.EditValueChanged += new System.EventHandler(this.txtCDT_EditValueChanged);
            // 
            // textEdit1
            // 
            this.textEdit1.EditValue = "Vui lòng chờ...";
            this.textEdit1.Location = new System.Drawing.Point(72, 402);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.textEdit1.Properties.ReadOnly = true;
            this.textEdit1.Size = new System.Drawing.Size(501, 18);
            this.textEdit1.StyleController = this.layoutControl1;
            this.textEdit1.TabIndex = 11;
            // 
            // radioGroupCnnType
            // 
            this.radioGroupCnnType.Location = new System.Drawing.Point(153, 284);
            this.radioGroupCnnType.Name = "radioGroupCnnType";
            this.radioGroupCnnType.Properties.Columns = 2;
            this.radioGroupCnnType.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Thông qua SQL"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Thông qua Windows")});
            this.radioGroupCnnType.Size = new System.Drawing.Size(420, 48);
            this.radioGroupCnnType.StyleController = this.layoutControl1;
            this.radioGroupCnnType.TabIndex = 10;
            this.radioGroupCnnType.SelectedIndexChanged += new System.EventHandler(this.radioGroupCnnType_SelectedIndexChanged);
            // 
            // simpleButtonOk
            // 
            this.simpleButtonOk.Location = new System.Drawing.Point(210, 131);
            this.simpleButtonOk.Name = "simpleButtonOk";
            this.simpleButtonOk.Size = new System.Drawing.Size(89, 22);
            this.simpleButtonOk.StyleController = this.layoutControl1;
            this.simpleButtonOk.TabIndex = 8;
            this.simpleButtonOk.Text = "Chấp nhận";
            this.simpleButtonOk.Click += new System.EventHandler(this.simpleButtonOk_Click);
            // 
            // textEditPassword
            // 
            this.textEditPassword.EditValue = "passwordcongtysgd";
            this.textEditPassword.EnterMoveNextControl = true;
            this.textEditPassword.Location = new System.Drawing.Point(153, 372);
            this.textEditPassword.Name = "textEditPassword";
            this.textEditPassword.Properties.PasswordChar = '*';
            this.textEditPassword.Size = new System.Drawing.Size(420, 20);
            this.textEditPassword.StyleController = this.layoutControl1;
            this.textEditPassword.TabIndex = 7;
            // 
            // textEditUser
            // 
            this.textEditUser.EditValue = "sa";
            this.textEditUser.EnterMoveNextControl = true;
            this.textEditUser.Location = new System.Drawing.Point(153, 342);
            this.textEditUser.Name = "textEditUser";
            this.textEditUser.Size = new System.Drawing.Size(420, 20);
            this.textEditUser.StyleController = this.layoutControl1;
            this.textEditUser.TabIndex = 6;
            this.textEditUser.EditValueChanged += new System.EventHandler(this.textEditUser_EditValueChanged);
            // 
            // textEditServer
            // 
            this.textEditServer.EditValue = ".\\SQLSGD2005";
            this.textEditServer.EnterMoveNextControl = true;
            this.textEditServer.Location = new System.Drawing.Point(153, 71);
            this.textEditServer.Name = "textEditServer";
            this.textEditServer.Size = new System.Drawing.Size(249, 20);
            this.textEditServer.StyleController = this.layoutControl1;
            this.textEditServer.TabIndex = 5;
            this.textEditServer.EditValueChanged += new System.EventHandler(this.textEditServer_EditValueChanged);
            // 
            // simpleButtonCancel
            // 
            this.simpleButtonCancel.Location = new System.Drawing.Point(309, 131);
            this.simpleButtonCancel.Name = "simpleButtonCancel";
            this.simpleButtonCancel.Size = new System.Drawing.Size(92, 22);
            this.simpleButtonCancel.StyleController = this.layoutControl1;
            this.simpleButtonCancel.TabIndex = 9;
            this.simpleButtonCancel.Text = "Bỏ qua";
            this.simpleButtonCancel.Click += new System.EventHandler(this.simpleButtonCancel_Click);
            // 
            // radioGroupType
            // 
            this.radioGroupType.Location = new System.Drawing.Point(153, 16);
            this.radioGroupType.Name = "radioGroupType";
            this.radioGroupType.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Tạo số liệu trên máy này"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Kết nối với số liệu có sẵn")});
            this.radioGroupType.Size = new System.Drawing.Size(420, 45);
            this.radioGroupType.StyleController = this.layoutControl1;
            this.radioGroupType.TabIndex = 4;
            this.radioGroupType.SelectedIndexChanged += new System.EventHandler(this.radioGroupType_SelectedIndexChanged);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.emptySpaceItem1,
            this.emptySpaceItem2,
            this.emptySpaceItem5,
            this.emptySpaceItem6,
            this.layoutControlItem7,
            this.layoutControlItemProgress,
            this.layoutControlItem2,
            this.layoutControlItem8,
            this.layoutControlItem9,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.emptySpaceItem3,
            this.emptySpaceItem4,
            this.layoutControlItem10,
            this.emptySpaceItem7,
            this.layoutControlItem11,
            this.layoutControlItem12,
            this.layoutControlItem13,
            this.tlo});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Size = new System.Drawing.Size(638, 459);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.radioGroupType;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(66, 10);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem1.Size = new System.Drawing.Size(511, 55);
            this.layoutControlItem1.Text = "Cách khởi tạo";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(78, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.textEditUser;
            this.layoutControlItem3.CustomizationFormText = "Tên đăng nhập";
            this.layoutControlItem3.Location = new System.Drawing.Point(66, 336);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem3.Size = new System.Drawing.Size(511, 30);
            this.layoutControlItem3.Text = "Tên đăng nhập";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(78, 13);
            this.layoutControlItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.textEditPassword;
            this.layoutControlItem4.CustomizationFormText = "Mật khẩu";
            this.layoutControlItem4.Location = new System.Drawing.Point(66, 366);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem4.Size = new System.Drawing.Size(511, 30);
            this.layoutControlItem4.Text = "Mật khẩu";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(78, 13);
            this.layoutControlItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(66, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.emptySpaceItem1.Size = new System.Drawing.Size(511, 10);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(66, 424);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.emptySpaceItem2.Size = new System.Drawing.Size(511, 33);
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem5
            // 
            this.emptySpaceItem5.AllowHotTrack = false;
            this.emptySpaceItem5.CustomizationFormText = "emptySpaceItem5";
            this.emptySpaceItem5.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem5.Name = "emptySpaceItem5";
            this.emptySpaceItem5.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.emptySpaceItem5.Size = new System.Drawing.Size(66, 457);
            this.emptySpaceItem5.Text = "emptySpaceItem5";
            this.emptySpaceItem5.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem6
            // 
            this.emptySpaceItem6.AllowHotTrack = false;
            this.emptySpaceItem6.CustomizationFormText = "emptySpaceItem6";
            this.emptySpaceItem6.Location = new System.Drawing.Point(577, 0);
            this.emptySpaceItem6.Name = "emptySpaceItem6";
            this.emptySpaceItem6.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.emptySpaceItem6.Size = new System.Drawing.Size(59, 457);
            this.emptySpaceItem6.Text = "emptySpaceItem6";
            this.emptySpaceItem6.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.radioGroupCnnType;
            this.layoutControlItem7.CustomizationFormText = "Loại số liệu";
            this.layoutControlItem7.Location = new System.Drawing.Point(66, 278);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem7.Size = new System.Drawing.Size(511, 58);
            this.layoutControlItem7.Text = "Loại kết nối";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(78, 13);
            this.layoutControlItem7.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // layoutControlItemProgress
            // 
            this.layoutControlItemProgress.Control = this.textEdit1;
            this.layoutControlItemProgress.CustomizationFormText = "layoutControlItemProgress";
            this.layoutControlItemProgress.Location = new System.Drawing.Point(66, 396);
            this.layoutControlItemProgress.Name = "layoutControlItemProgress";
            this.layoutControlItemProgress.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItemProgress.Size = new System.Drawing.Size(511, 28);
            this.layoutControlItemProgress.Text = "layoutControlItemProgress";
            this.layoutControlItemProgress.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemProgress.TextToControlDistance = 0;
            this.layoutControlItemProgress.TextVisible = false;
            this.layoutControlItemProgress.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.textEditServer;
            this.layoutControlItem2.CustomizationFormText = "Tên máy chủ SQL";
            this.layoutControlItem2.Location = new System.Drawing.Point(66, 65);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem2.Size = new System.Drawing.Size(340, 30);
            this.layoutControlItem2.Text = "Tên máy chủ";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(78, 13);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.txtCDT;
            this.layoutControlItem8.CustomizationFormText = "Dữ liệu Struct";
            this.layoutControlItem8.Location = new System.Drawing.Point(66, 189);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem8.Size = new System.Drawing.Size(511, 30);
            this.layoutControlItem8.Text = "Dữ liệu Struct";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(78, 13);
            this.layoutControlItem8.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.cEis2005;
            this.layoutControlItem9.CustomizationFormText = "layoutControlItem9";
            this.layoutControlItem9.Location = new System.Drawing.Point(66, 249);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem9.Size = new System.Drawing.Size(511, 29);
            this.layoutControlItem9.Text = "layoutControlItem9";
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextToControlDistance = 0;
            this.layoutControlItem9.TextVisible = false;
            this.layoutControlItem9.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.simpleButtonOk;
            this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
            this.layoutControlItem5.Location = new System.Drawing.Point(204, 125);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem5.Size = new System.Drawing.Size(99, 32);
            this.layoutControlItem5.Text = "layoutControlItem5";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextToControlDistance = 0;
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.simpleButtonCancel;
            this.layoutControlItem6.CustomizationFormText = "layoutControlItem6";
            this.layoutControlItem6.Location = new System.Drawing.Point(303, 125);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem6.Size = new System.Drawing.Size(102, 32);
            this.layoutControlItem6.Text = "layoutControlItem6";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextToControlDistance = 0;
            this.layoutControlItem6.TextVisible = false;
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.CustomizationFormText = "emptySpaceItem3";
            this.emptySpaceItem3.Location = new System.Drawing.Point(66, 125);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.emptySpaceItem3.Size = new System.Drawing.Size(138, 32);
            this.emptySpaceItem3.Text = "emptySpaceItem3";
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem4
            // 
            this.emptySpaceItem4.AllowHotTrack = false;
            this.emptySpaceItem4.CustomizationFormText = "emptySpaceItem4";
            this.emptySpaceItem4.Location = new System.Drawing.Point(405, 125);
            this.emptySpaceItem4.Name = "emptySpaceItem4";
            this.emptySpaceItem4.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.emptySpaceItem4.Size = new System.Drawing.Size(172, 32);
            this.emptySpaceItem4.Text = "emptySpaceItem4";
            this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.simpleButton1;
            this.layoutControlItem10.CustomizationFormText = "layoutControlItem10";
            this.layoutControlItem10.Location = new System.Drawing.Point(441, 157);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem10.Size = new System.Drawing.Size(136, 32);
            this.layoutControlItem10.Text = "layoutControlItem10";
            this.layoutControlItem10.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem10.TextToControlDistance = 0;
            this.layoutControlItem10.TextVisible = false;
            // 
            // emptySpaceItem7
            // 
            this.emptySpaceItem7.AllowHotTrack = false;
            this.emptySpaceItem7.CustomizationFormText = "emptySpaceItem7";
            this.emptySpaceItem7.Location = new System.Drawing.Point(66, 157);
            this.emptySpaceItem7.Name = "emptySpaceItem7";
            this.emptySpaceItem7.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.emptySpaceItem7.Size = new System.Drawing.Size(375, 32);
            this.emptySpaceItem7.Text = "emptySpaceItem7";
            this.emptySpaceItem7.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.Control = this.txtCDTOld;
            this.layoutControlItem11.CustomizationFormText = "Dữ liệu struct cũ";
            this.layoutControlItem11.Location = new System.Drawing.Point(66, 219);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem11.Size = new System.Drawing.Size(511, 30);
            this.layoutControlItem11.Text = "Dữ liệu struct cũ";
            this.layoutControlItem11.TextSize = new System.Drawing.Size(78, 13);
            // 
            // layoutControlItem12
            // 
            this.layoutControlItem12.Control = this.txtRemoteServer;
            this.layoutControlItem12.CustomizationFormText = "Máy chủ từ xa";
            this.layoutControlItem12.Location = new System.Drawing.Point(66, 95);
            this.layoutControlItem12.Name = "layoutControlItem12";
            this.layoutControlItem12.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem12.Size = new System.Drawing.Size(339, 30);
            this.layoutControlItem12.Text = "Máy chủ từ xa";
            this.layoutControlItem12.TextSize = new System.Drawing.Size(78, 13);
            // 
            // layoutControlItem13
            // 
            this.layoutControlItem13.Control = this.ckUpdateRemote;
            this.layoutControlItem13.CustomizationFormText = "layoutControlItem13";
            this.layoutControlItem13.Location = new System.Drawing.Point(405, 95);
            this.layoutControlItem13.Name = "layoutControlItem13";
            this.layoutControlItem13.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem13.Size = new System.Drawing.Size(172, 30);
            this.layoutControlItem13.Text = "layoutControlItem13";
            this.layoutControlItem13.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem13.TextToControlDistance = 0;
            this.layoutControlItem13.TextVisible = false;
            // 
            // dxErrorProviderMain
            // 
            this.dxErrorProviderMain.ContainerControl = this;
            // 
            // CkUpdateLocal
            // 
            this.CkUpdateLocal.Location = new System.Drawing.Point(409, 68);
            this.CkUpdateLocal.Name = "CkUpdateLocal";
            this.CkUpdateLocal.Properties.Caption = "Cập nhật máy chủ local";
            this.CkUpdateLocal.Size = new System.Drawing.Size(167, 19);
            this.CkUpdateLocal.StyleController = this.layoutControl1;
            this.CkUpdateLocal.TabIndex = 17;
            // 
            // tlo
            // 
            this.tlo.Control = this.CkUpdateLocal;
            this.tlo.CustomizationFormText = "tlo";
            this.tlo.Location = new System.Drawing.Point(406, 65);
            this.tlo.Name = "tlo";
            this.tlo.Size = new System.Drawing.Size(171, 30);
            this.tlo.Text = "tlo";
            this.tlo.TextSize = new System.Drawing.Size(0, 0);
            this.tlo.TextToControlDistance = 0;
            this.tlo.TextVisible = false;
            // 
            // CreateData
            // 
            this.ClientSize = new System.Drawing.Size(638, 459);
            this.Controls.Add(this.layoutControl1);
            this.MaximizeBox = false;
            this.Name = "CreateData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Khởi tạo số liệu";
            this.Load += new System.EventHandler(this.CreateData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ckUpdateRemote.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemoteServer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCDTOld.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cEis2005.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCDT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupCnnType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditServer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemProgress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProviderMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CkUpdateLocal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tlo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProviderMain;
        private EmptySpaceItem emptySpaceItem1;
        private EmptySpaceItem emptySpaceItem2;
        private EmptySpaceItem emptySpaceItem3;
        private EmptySpaceItem emptySpaceItem4;
        private EmptySpaceItem emptySpaceItem5;
        private EmptySpaceItem emptySpaceItem6;
        private EmptySpaceItem emptySpaceItem7;
        
        private LayoutControl layoutControl1;
        private LayoutControlGroup layoutControlGroup1;
        private LayoutControlItem layoutControlItem1;
        private LayoutControlItem layoutControlItem10;
        private LayoutControlItem layoutControlItem2;
        private LayoutControlItem layoutControlItem3;
        private LayoutControlItem layoutControlItem4;
        private LayoutControlItem layoutControlItem5;
        private LayoutControlItem layoutControlItem6;
        private LayoutControlItem layoutControlItem7;
        private LayoutControlItem layoutControlItem8;
        private LayoutControlItem layoutControlItem9;
        private LayoutControlItem layoutControlItemProgress;
        private RadioGroup radioGroupCnnType;
        private RadioGroup radioGroupType;
        private SimpleButton simpleButton1;
        private SimpleButton simpleButtonCancel;
        private SimpleButton simpleButtonOk;
        private TextEdit textEdit1;
        private TextEdit textEditPassword;
        private TextEdit textEditServer;
        private TextEdit textEditUser;
        private TextEdit txtCDT;
        private TextEdit txtCDTOld;
        private LayoutControlItem layoutControlItem11;
        private TextEdit txtRemoteServer;
        private LayoutControlItem layoutControlItem12;
        private CheckEdit ckUpdateRemote;
        private LayoutControlItem layoutControlItem13;
        private CheckEdit CkUpdateLocal;
        private LayoutControlItem tlo;

    }
}