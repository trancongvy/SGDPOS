using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using DevExpress.XtraBars;
using System.Configuration;
using DevExpress.XtraEditors;
using DevExpress.XtraNavBar;

using FormFactory;
using ReportFactory;
using CDTControl;
using CDTLib;
using DataFactory;
using CDTSystem;
using Plugins;
using ErrorManager;
using System.IO;
//using CustomClass;
//using CusNissan;
using CusAccounting;
using CusPOS;
namespace CDT
{
    public partial class Main : DevExpress.XtraEditors.XtraForm
    {
        private string H_KEY = Config.GetValue("H_KEY").ToString();
        string sysPackageID, dbName;
        DataTable dtMenu;
        SysMenu _sysMenu = new SysMenu();
        PluginManager pm = new PluginManager();

        public Main(DataRow drUser, DataRow drPackage)
        {
            
            InitializeComponent();
            sysPackageID = drPackage["sysPackageID"].ToString();
            dbName = drPackage["DbName"].ToString();
            _sysMenu.SynchronizeMenuWithPlugins(pm);
            _sysMenu.SynMenuforUser();
            InitializeMenu();
            if (sysPackageID == "5") DesignLog.SqlError(DateTime.Now.ToLongTimeString());
            barManagerMain.Items.Add(barSubItemHelp);
            barMainMenu.LinksPersistInfo.Add(new DevExpress.XtraBars.LinkPersistInfo(barSubItemHelp));
            barManagerMain.ItemClick += new ItemClickEventHandler(barManagerMain_ItemClick);
            
            if (Config.GetValue("Language").ToString() == "1")
            {
                DevLocalizer.Translate(this);
                TranslateForMenu();
            }
            this.Disposed += new EventHandler(Main_Disposed);
            InitializeForm(drUser, drPackage);
           // bool supported = false;
            //string RegSupport = Registry.GetValue(H_KEY, "SupportOnline", "false").ToString();
            //if (RegSupport != string.Empty)
            //    supported = Boolean.Parse(RegSupport);
            
            //if (DateTime.Today.DayOfWeek == DayOfWeek.Monday && !supported)
            //{
            //Startup frm = new Startup();
            //frm.MdiParent = this;
            //frm.Show();
            //    Registry.SetValue(H_KEY, "SupportOnline", true);
            //}
            //else
            //    if (DateTime.Today.DayOfWeek != DayOfWeek.Monday && supported)
            //        Registry.SetValue(H_KEY, "SupportOnline", false);
            
        }

        void Main_Disposed(object sender, EventArgs e)
        {
            DataMaintain dmBk = new DataMaintain();
            this.fno.notifyIcon1.Visible = false;
            dmBk.BackupData(Application.StartupPath);
            
        }

        private void TranslateForMenu()
        {
            for (int i = 0; i < barManagerMain.Items.Count; i++)
                barManagerMain.Items[i].Caption = UIDictionary.Translate(barManagerMain.Items[i].Caption);
        }

        private void InitializeForm(DataRow drUser, DataRow drPackage)
        {
            Config.NewKeyValue("FullName", drUser["FullName"].ToString());
            if (drUser["FullName"].ToString() != string.Empty)
                bsiUserName.Caption = bsiUserName.Caption + ": " + drUser["FullName"].ToString();
            else
                bsiUserName.Caption = bsiUserName.Caption + ": " + drUser["UserName"].ToString();
            if (!Boolean.Parse(drUser["CoreAdmin"].ToString()))
                iCheckData.Visibility = BarItemVisibility.Never;
            if (!Boolean.Parse(Config.GetValue("Admin").ToString()))
            {
                iViewHistory.Visibility = BarItemVisibility.Never;
                iUserTrace.Visibility = BarItemVisibility.Never;
                iCollectData.Visibility = BarItemVisibility.Never;
            }
            bsiStyle.Caption = bsiStyle.Caption + ": " + Config.GetValue("Style").ToString();
            bsiToday.Caption = bsiToday.Caption + ": " + DateTime.Today.ToString("dd/MM/yyyy");
            bsiVersion.Caption = bsiVersion.Caption + ": " + Config.GetValue("ProductName").ToString();
            bsiDatabase.Caption = bsiDatabase.Caption + Config.GetValue("DbName").ToString();
            bsiStructServer.Caption = bsiStructServer.Caption + Config.GetValue("StructServer").ToString();
            bsiDataServer.Caption = bsiDataServer.Caption + Config.GetValue("DataServer").ToString();
            bsiComputerName.Caption = bsiComputerName.Caption + Config.GetValue("ComputerName").ToString();
            this.Text = Config.GetValue("Language").ToString() == "0" ? drPackage["PackageName"].ToString() : drPackage["PackageName2"].ToString();
            if (Config.Variables.Contains("TenCN") && Config.GetValue("TenCN").ToString() != string.Empty)
                this.Text += " - " + Config.GetValue("TenCN").ToString();
            if (drPackage["Background"].ToString() != string.Empty)
                this.BackgroundImage = GetImage(drPackage["Background"] as byte[]);
            
        }

        private void SystemMenuClick(object sender, ItemClickEventArgs e)
        {
            switch (e.Item.Name)
            {
                case "iRestart":
                    Application.Restart();
                    break;
                case "iExit":
                    if (XtraMessageBox.Show("Vui lòng xác nhận thoát khỏi ứng dụng?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        Application.Exit();
                    break;
                case "iUserConfig":
                    UserConfigAcc frmUserConfig = new UserConfigAcc();
                    if (frmUserConfig.IsShow)
                        frmUserConfig.ShowDialog();
                    break;
                case "iCheckData":
                    CheckData frmCheckData = new CheckData(true);
                    frmCheckData.ShowDialog();
                    break;
                case "iViewHistory":
                    CheckData frmViewHistory = new CheckData(false);
                    frmViewHistory.ShowDialog();
                    break;
                case "iChangePassword":
                    ChangePassword frmChangePwd = new ChangePassword();
                    frmChangePwd.ShowDialog();
                    break;
                case "iAbout":
                    About frmAbout = new About();
                    frmAbout.ShowDialog();
                    break;
                case "iHelpOnline":
                    System.Diagnostics.Process.Start("http://www.sgd.com.vn");
                    break;
                case "iHelp":
                    string fileHelp = Config.GetValue("Package").ToString() + ".chm";
                    if (System.IO.File.Exists(fileHelp))
                        System.Diagnostics.Process.Start(fileHelp);
                    break;
                case "iBackup":
                    DataMaintain dmBk = new DataMaintain();
                    if (dmBk.BackupData(Application.StartupPath))
                    {
                        MessageBox.Show("Bakup Hoàn thành");
                    }
                    else
                    {
                    }
                    break;
                case "iDelete":
                    Xoasolieu fxoasolieu = new Xoasolieu();
                    fxoasolieu.ShowDialog();
                    break;
                case "iRestore":
                    string isAdmin = Config.GetValue("Admin").ToString();
                    if (isAdmin != "True") return;
                    DataMaintain dmRt = new DataMaintain();
                    DateTime d;
                    FrmDateSelect f = new FrmDateSelect();
                    f.ShowDialog();
                    d = f.d;
                    if (d != null)
                    {
                        if (File.Exists(Application.StartupPath + "\\Backup\\" + dbName + d.ToString("dd_MM_yyyy") + ".dat"))
                        {
                            if (MessageBox.Show("Bạn có chắc chắn phục hồi số liệu ngày " + d.ToString("dd/MM/yyyy") + " không?, Dữ liệu hiện tại sẽ bị mất sau khi phục hồi!", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                if (dmRt.RestoreData(Application.StartupPath + "\\Backup\\" + dbName + d.ToString("dd_MM_yyyy") + ".dat"))
                                {
                                    MessageBox.Show("Phục hồi số liệu hoàn thành!");
                                }
                                else
                                {
                                    MessageBox.Show("Phục hồi số liệu bị lỗi!");
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Không tồn tại file backup ngày " + d.ToString("dd/MM/yyyy"));
                        }
                    }
                    break;
                case "iRestoreAs":
                    string isAdmin1 = Config.GetValue("Admin").ToString();
                    if (isAdmin1 != "True") return;
                    DataMaintain dmRtas = new DataMaintain();
                    DateTime d1;
                    string dataAnother;
                    FrmRestoreAs fres = new FrmRestoreAs();
                    fres.ShowDialog();
                    d1 = fres.d;
                    dataAnother = fres.DataAnother;
                    if (d1 != null && dataAnother != null)
                    {
                        if (File.Exists(Application.StartupPath + "\\Backup\\" + dbName + d1.ToString("dd_MM_yyyy") + ".dat") && !File.Exists(Application.StartupPath + "\\Data2005\\" + dataAnother + ".mdf"))
                        {
                            if (MessageBox.Show("Bạn có chắc chắn phục hồi số liệu ngày " + d1.ToString("dd/MM/yyyy") + " vào dữ liệu " + dataAnother + " không?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                if (dmRtas.RestoreDataToAnother(Application.StartupPath + "\\Data2005\\", Application.StartupPath + "\\Backup\\" + dbName + d1.ToString("dd_MM_yyyy") + ".dat", dataAnother))
                                {
                                    MessageBox.Show("Tạo số liệu hoàn thành!");
                                }
                                else
                                {
                                    MessageBox.Show("Tạo số liệu bị lỗi!");
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Không tồn tại file backup ngày " + d1.ToString("dd/MM/yyyy") + " hoặc đã tồn tại database " + dataAnother);
                        }
                    }
                    break;
                case "iCollectData":
                    FrmDataCollection frmDc = new FrmDataCollection();
                    frmDc.ShowDialog();
                    break;
                case "iImportExcel":
                    CDTSystem.fImExcel frmImportEx = new CDTSystem.fImExcel();
                    frmImportEx.MdiParent = this;
                    frmImportEx.Show();
                    break;
                case "iChonNLV":
                    fChonNgayLV fChonNLV = new fChonNgayLV();
                    fChonNLV.ShowDialog();
                    break;
                case "isImportData":
                    DateFilter dfilterIm = new DateFilter();
                    //dfilter.MdiParent = this;
                    dfilterIm.ShowDialog();
                    if (dfilterIm.isAccept)
                    {
                        ImportDataFromDat I2Dat = new ImportDataFromDat(dfilterIm.TuNgay, dfilterIm.DenNgay);
                        if (!I2Dat.Import())
                            MessageBox.Show("Kết nhập dữ liệu không thành công");
                        else
                            MessageBox.Show("Kết nhập dữ liệu thành công");
                    }
                    break;
                case "isExportData":
                    DateFilter dfilterEx = new DateFilter();
                    //dfilter.MdiParent = this;
                    dfilterEx.ShowDialog();
                    if (dfilterEx.isAccept)
                    {
                        ExportData2Dat E2Dat = new ExportData2Dat(dfilterEx.TuNgay, dfilterEx.DenNgay);
                        if(!E2Dat.Export())
                            MessageBox.Show("Xuất dữ liệu không thành công");
                        else
                            MessageBox.Show("Xuất dữ liệu thành công");
                    }
                    break;

            }
        }

        void barManagerMain_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.Item.GetType() != typeof(BarSubItem))
            {
                DataRow dr = e.Item.Tag as DataRow;
                if (dr == null)
                    SystemMenuClick(sender, e);
                else
                    ExecuteCommand(dr);
            }
        }

        private void navBarControlMain_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            DataRow dr = e.Link.Item.Tag as DataRow;

            ExecuteCommand(dr);
        }

        private void treeListMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!treeListMain.FocusedNode.HasChildren)
            {
                DataRow dr = dtMenu.Rows[treeListMain.FocusedNode.Id];

                ExecuteCommand(dr);
            }
        }

        private void treeListMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (!treeListMain.FocusedNode.HasChildren)
                {
                    DataRow dr = dtMenu.Rows[treeListMain.FocusedNode.Id];

                    ExecuteCommand(dr);
                }
        }

        private void ExecuteCommand(DataRow dr)
        {
            if (dr == null)
                return;
            Config.NewKeyValue("sysMenuID", dr["SysMenuID"]);
            Config.NewKeyValue("MenuName", dr["MenuName"]);
            if (dr["sysTableID"].ToString() != string.Empty)
                ShowTable(dr);
            else
            {
                if (dr["sysReportID"].ToString() != string.Empty)
                    ShowReport(dr);
                else if (dr["PluginName"].ToString() != string.Empty)
                    ExecutePlugin(dr);
                else
                {
                    if (dr.Table.Columns.Contains("CustomClass"))
                    {
                        ExecuteCustom(dr);
                    }
                }
            }
        }

        

        private void InitializeMenu()
        {

            dtMenu = _sysMenu.GetMenu();
            if (dtMenu == null)
                return;

            treeListMain.OptionsView.EnableAppearanceEvenRow = true;

            treeListMain.DataSource = dtMenu;
            treeListMain.KeyFieldName = "sysMenuID";
            treeListMain.ParentFieldName = "sysMenuParent";
            tlcMenuName.FieldName = Config.GetValue("Language").ToString() == "0" ? "MenuName" : "MenuName2";
            if (dtMenu.Rows.Count < 20)
                treeListMain.ExpandAll();

            foreach (DataRow dr in dtMenu.Rows)
            {
                string sysMenuParent = dr["sysMenuParent"].ToString();
                if (sysMenuParent == string.Empty)  //menu cha
                {
                    string menuName = Config.GetValue("Language").ToString() == "0" ? dr["MenuName"].ToString() : dr["MenuName2"].ToString();
                    BarSubItem bsi = new BarSubItem(barManagerMain, menuName);
                    barMainMenu.LinksPersistInfo.Add(new LinkPersistInfo(bsi));
                    LoopMenu(dtMenu, dr, bsi);

                    if (dr["sysPackageID2"].ToString() != string.Empty)
                    {
                        NavBarGroup nvb = new NavBarGroup(menuName);
                        if (GetImage(dr))
                            nvb.SmallImageIndex = imageCollection1.Images.Count - 1;
                        navBarControlMain.Groups.Add(nvb);
                        LoopNavBar(dr, nvb);
                    }
                }

                _sysMenu.ModifyMenu(dr);
            }
            //navBarControlMain.Dock=DockStyle.

        }

        private void LoopNavBar(DataRow dr, NavBarGroup nvb)
        {
            foreach (DataRow drChild in dtMenu.Rows)
            {
                if (drChild["sysMenuParent"].ToString() == dr["sysMenuID"].ToString())
                {
                    string menuName = Config.GetValue("Language").ToString() == "0" ? drChild["MenuName"].ToString() : drChild["MenuName2"].ToString();
                    if (HasChild(dtMenu, drChild["sysMenuID"].ToString()))
                        LoopNavBar(drChild, nvb);
                    else
                    {
                        NavBarItem nbi = new NavBarItem(menuName);
                        nbi.Tag = drChild;
                        if (GetImage(drChild))
                            nbi.SmallImageIndex = imageCollection1.Images.Count - 1;
                        navBarControlMain.Items.Add(nbi);
                        nvb.ItemLinks.Add(nbi);
                    }
                }
            }
        }

        private Shortcut GetShortcut(string strShortcut)
        {
            Array arrShortcut = Enum.GetValues(typeof(Shortcut));
            foreach (Shortcut sctmp in arrShortcut)
                if (sctmp.ToString() == strShortcut)
                    return sctmp;
            return Shortcut.None;
        }

        private void LoopMenu(DataTable dtMenu, DataRow dr, BarSubItem bsi)
        {
            foreach (DataRow drChild in dtMenu.Rows)
            {
                if (drChild["sysMenuParent"].ToString() == dr["sysMenuID"].ToString())
                {
                    string menuName = Config.GetValue("Language").ToString() == "0" ? drChild["MenuName"].ToString() : drChild["MenuName2"].ToString();
                    if (HasChild(dtMenu, drChild["sysMenuID"].ToString()))  //vua cha vua con
                    {
                        BarSubItem bsiChild = new BarSubItem(barManagerMain, menuName);
                        if (GetImage(drChild))
                            bsiChild.ImageIndex = imageCollectionMain.Images.Count - 1;
                        //if (drChild["sysPackageID2"].ToString() == string.Empty)
                        //    barSubItemSystem.LinksPersistInfo.Add(new LinkPersistInfo(bsiChild));
                        //else
                            bsi.LinksPersistInfo.Add(new LinkPersistInfo(bsiChild));
                        LoopMenu(dtMenu, drChild, bsiChild);
                    }   
                    else
                    {   //menu con
                        BarLargeButtonItem bbi = new BarLargeButtonItem(barManagerMain, menuName);
                        bbi.Hint = menuName;
                        bbi.Tag = drChild;
                        bbi.CaptionAlignment = BarItemCaptionAlignment.Bottom;
                        string strShortcut = drChild["ShortKey"].ToString();
                        if (strShortcut != string.Empty)
                            bbi.ItemShortcut = new BarShortcut(GetShortcut(strShortcut));
                        if (GetImage(drChild))
                            bbi.ImageIndex = imageCollectionMain.Images.Count - 1;
                        //if (drChild["sysPackageID2"].ToString() == string.Empty)
                        //    barSubItemSystem.LinksPersistInfo.Add(new LinkPersistInfo(bbi));
                        //else
                            bsi.LinksPersistInfo.Add(new LinkPersistInfo(bbi));
                        if (Boolean.Parse(drChild["isToolbar"].ToString()))
                            barToolbars.LinksPersistInfo.Add(new LinkPersistInfo(BarLinkUserDefines.PaintStyle, bbi, BarItemPaintStyle.CaptionGlyph));
                    }
                }
            }
        }

        private bool HasChild(DataTable dtMenu, string sysMenuID)
        {
            foreach (DataRow dr in dtMenu.Rows)
                if (dr["sysMenuParent"].ToString() == sysMenuID)
                    return true;
            return false;
        }

        private bool GetImage(DataRow dr)
        {
            if (dr["Image"].ToString() == string.Empty)
                return false;
            Image im = GetImage(dr["Image"] as byte[]);
            if (im == null)
                return false;
            imageCollection1.AddImage(im);
            imageCollectionMain.AddImage(im);
            return true;
        }

        private Image GetImage(byte[] b)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream(b);
            if (ms == null)
                return null;
            Image im = Image.FromStream(ms);
            return (im);
        }

        private void ShowTable(DataRow drTable)
        {
            if (drTable == null)
                return;
            int bType = Int32.Parse(drTable["Type"].ToString());
            FormType formType;
            switch (bType)
            {
                case 1:
                case 2:
                    formType = FormType.Single;
                    break;
                case 3:
                    formType = FormType.MasterDetail;
                    break;
                case 4:
                case 5:
                    formType = FormType.Detail;
                    break;
                default:
                    formType = FormType.Single;
                    break;
            }
            Form frm = MdiExists(drTable["MenuName"].ToString());
            if (frm != null)
                frm.Activate();
            else
            {

                frm = FormFactory.FormFactory.Create(formType, drTable);

                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void ShowReport(DataRow drReport)
        {
            Form frm = MdiExists(drReport["MenuName"].ToString());
            if (frm != null)
                frm.Activate();
            else
            {
                frm = ReportFactory.ReportFactory.Create(drReport);
                frm.MdiParent = this;
                if (!(frm as ReportFactory.ReportFilter).isNotify)
                {
                    frm.Show();
                }
                else
                {
                    (frm as ReportFactory.ReportFilter).ShowNotify();
                    frm.Dispose();
                }

            }
        }

        private Form MdiExists(string caption)
        {
            foreach (Form frm in this.MdiChildren)
                if (frm.Text == caption)
                    return frm;
            return null;
        }

        private void ExecutePlugin(DataRow drData)
        {
            int menuID = Int32.Parse(drData["MenuPluginID"].ToString());
            string pluginName = drData["PluginName"].ToString();
            Form frm = MdiExists(pluginName);
            if (frm != null)
                frm.Activate();
            else
            {
                frm = pm.Execute(menuID, pluginName);
                if (frm != null)
                {
                    frm.Text = drData["MenuName"].ToString();
                    frm.MdiParent = this;
                    frm.Show();
                }
            }
        }

        private void iBackup_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void ExecuteCustom(DataRow dr)
        {
            switch (dr["CustomClass"].ToString())
            {
                //case "sChonNgayHethong":
                //    sChonNgayHethong f2 = new sChonNgayHethong();
                //    f2.MdiParent = this;            
                //    f2.Show();
                //    break;
                //case "fNhapChisocongter" :
                //    fNhapChisocongter f = new fNhapChisocongter();
                //    f.MdiParent = this;
                //    f.Show();
                //    break ;
                //case "fPhieuGiaohang":
                //    fPhieuGiaohang f1 = new fPhieuGiaohang();
                //    f1.MdiParent = this;
                //    f1.Show();
                //    break;
                //case"fCRManage":
                //    fCRManage fcr = new fCRManage();
                //    fcr.MdiParent = this;
                //    fcr.Show();
                //    break;
                //case "fCRQuestion":
                //    fCRQuestion fcr1 = new fCRQuestion();
                //    fcr1.MdiParent = this;
                //    fcr1.Show();
                //    break;
                //case "fImExcel":
                //    CusNissan.fImExcel fIe = new CusNissan.fImExcel();
                //    fIe.MdiParent = this;
                //    fIe.Show();
                //    break;  
                case "StartUp":
                    StartUp fstartup = new StartUp();
                    fstartup.MdiParent = this;
                    fstartup.Show();
                    break;
                case "fTaskList":
                    fTaskList fStart = new fTaskList();
                    fStart.MdiParent = this;
                    fStart.Show();
                    break;
                case "TMBCTC":
                    TMBCTCFilter fTMBCTC = new TMBCTCFilter();
                    fTMBCTC.MdiParent = this;
                    fTMBCTC.Show();
                    break;
                case "BangkeBanra":
                    ExportVatFilter fExportVatFilter = new ExportVatFilter();
                    fExportVatFilter.MdiParent = this;
                    fExportVatFilter.Show();
                    break;
                case "fDoiGia":
                    fDoiGia fdoigia = new fDoiGia();
                    fdoigia.MdiParent = this;
                    fdoigia.Show();
                    break;
                case "fImExcelto32":
                    fImExcelto32 fImexcelto32 = new fImExcelto32();
                    fImexcelto32.MdiParent = this;
                    fImexcelto32.Show();
                    break;
                case "fImExcelGTCC":
                    fImExcelGTCC fImExcelGTCC = new fImExcelGTCC();
                    fImExcelGTCC.MdiParent = this;
                    fImExcelGTCC.Show();
                    break;
                case "fCopyPackage":
                    fCopyPackage fcopyPackage;// =new fCopyPackage();
                    fcopyPackage = new fCopyPackage();
                    fcopyPackage.ShowDialog();
                    break;
                case "fTaoPTT":
                    fTaoPTT f_TaoPTT;//= new fTaoPTT();
                    f_TaoPTT = new fTaoPTT();
                    f_TaoPTT.ShowDialog();
                    break;
                case "fPQchucnang":
                    fPQchucnang f_PQchucnang = new fPQchucnang();
                    f_PQchucnang.MdiParent = this;
                    f_PQchucnang.Show();
                    break;
                case "fCoKHSX":
                    fCoKHSX f_CoKHSX = new fCoKHSX();
                    f_CoKHSX.MdiParent = this;
                    f_CoKHSX.Show();
                    break;
                case "CoPhanBoCtrinh":
                    CoPhanBoCtrinh fCoPhanBoCtrinh = new CoPhanBoCtrinh();
                    fCoPhanBoCtrinh.MdiParent = this;
                    fCoPhanBoCtrinh.Show();
                    break;
                case "fPOS":
                    fPOS fpos = new fPOS();
                    fpos.MdiParent = this;
                    fpos.Show();
                    break;
                case "fBEP":
                    fBep fbep = new fBep();
                    fbep.MdiParent = this;
                    fbep.Show();
                    break;
                case "fFastFood":
                    fFastFood ffastFood = new fFastFood();
                    //ffastFood.MdiParent = this;
                    
                    ffastFood.ShowDialog();
                    break;
            }
        }
        fNotify fno = new fNotify();
        private void Main_Load(object sender, EventArgs e)
        {
            if (Config.Variables.Contains("isUseNLV"))
                if (Config.GetValue("isUseNLV").ToString() == "1")
                {
                    fChonNgayLV f = new fChonNgayLV();
                    f.ShowDialog();
                }
            foreach (DataRow dr in dtMenu.Rows)
            {
                if (dr["notify"]!=DBNull.Value && bool.Parse(dr["notify"].ToString()))
                    ExecuteCommand(dr);
            }

                
                fno.Visible = false;
                //fno.Show();                
        }

        private void barLargeButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
           // NetSupport f = new NetSupport();
           // f.Show();
        }

        private void iCollectData_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void bsiComputerName_ItemClick(object sender, ItemClickEventArgs e)
        {

        }



    }
}