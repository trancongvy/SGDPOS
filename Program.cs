using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Globalization;
using CDTLib;
using CDTSystem;
using CDTControl.CDTControl;

namespace CDT
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main(string[] args)
        {
            //args = new string[] { "CBA12" };
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.UserSkins.OfficeSkins.Register();
            DevExpress.Skins.SkinManager.EnableFormSkins();

            //tuy theo moi soft co productName khac nhau
            string productName = "CDT"; //giá trị mặc định
            if (args.Length > 0)
                productName = args[0];
            string H_KEY = "HKEY_CURRENT_USER\\Software\\Combosoft\\";
            Config.NewKeyValue("H_KEY", H_KEY);
            Config.NewKeyValue("ProductName", productName);
            
            //lay style mac dinh cho form
            string defaultStyle = Registry.GetValue(H_KEY, "Style", string.Empty).ToString();
            DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeelMain = new DevExpress.LookAndFeel.DefaultLookAndFeel();
            if (defaultStyle != string.Empty)
                defaultLookAndFeelMain.LookAndFeel.SetSkinStyle(defaultStyle);

            //RegisterNumber
            string subkey = @"Software\Combosoft\" + productName;
            string P_KEY = H_KEY + productName + "\\";
            Config.NewKeyValue("H_KEY", P_KEY);
            RegistryKey pKey = Registry.CurrentUser.OpenSubKey(subkey);
            if (pKey == null)
                Registry.CurrentUser.CreateSubKey(subkey);
            string Company = Registry.GetValue(P_KEY, "CompanyName", "").ToString();
            CPUid Cpu = new CPUid(Company + productName);
            string RegisterNumber = Registry.GetValue(P_KEY, "RegisterNumber", "").ToString();
            if (RegisterNumber != Cpu.KeyString)
            {

                Cpu = new CPUid("BanDemo" + Company + "BanDemo" + productName);
                if (RegisterNumber != Cpu.KeyString)
                {
                    RegisterF rf = new RegisterF();
                    rf.producName = productName;
                    rf.ShowDialog();
                    if (rf.DialogResult == DialogResult.Cancel)
                        return;
                }
                else
                {
                    int nCount = 0;
                    string path = System.Environment.SystemDirectory + "\\" + "Info.dat";
                    string[] contents = new string[3];
                    if (System.IO.File.Exists(path))
                    {
                        contents = System.IO.File.ReadAllLines(path);
                        nCount = Int32.Parse(contents[2]);
                    }
                    nCount++;
                    contents[2] = nCount.ToString();
                    int nRemain = 100 - nCount;
                    if (nRemain == 0)
                    {
                        MessageBox.Show("Phiên bản demo đã hết hạn sử dụng");
                        return;
                    }
                    else
                    {
                        System.IO.File.WriteAllLines(path, contents);
                        if (MessageBox.Show("Bạn đang dùng phiên bản demo - (" + nRemain.ToString() + " lần), bạn có muốn đăng ký lại không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            RegisterF rf = new RegisterF();
                            rf.producName = productName;
                            rf.ShowDialog();
                        }
                    }
                }
            }


            //kiem tra so lieu da duoc khoi tao chua, neu chua thuc hien khoi tao so lieu
            string created = Registry.GetValue(P_KEY, "Created", 0).ToString();
            if (created == "0")
            {
                CreateData frmCreateData = new CreateData();
                frmCreateData.ShowDialog();
                if (frmCreateData.DialogResult == DialogResult.Cancel)
                    return;
                Registry.SetValue(P_KEY, "Created", 1);
            }
            //da co so lieu, bat dau thuc hien dang nhap
            SetEnvironment();
            Login frmLogin = new Login();
            frmLogin.ShowDialog();

            //dang nhap thanh cong, bat dau su dung chuong trinh
            if (frmLogin.DialogResult != DialogResult.Cancel)
                Application.Run(new Main(frmLogin.drUser, frmLogin.drPackage));
        }

        private static void SetEnvironment()
        {
            System.Globalization.CultureInfo CultureInfo = System.Windows.Forms.Application.CurrentCulture.Clone() as System.Globalization.CultureInfo;
            CultureInfo = new CultureInfo("en-US");
            System.Windows.Forms.Application.CurrentCulture = CultureInfo;

            string H_KEY = Config.GetValue("H_KEY").ToString();
            //lay chuoi ket noi
            string StructConnection = Registry.GetValue(H_KEY, "StructDb", string.Empty).ToString();
            Config.NewKeyValue("StructConnection", StructConnection);
        }
    }
}