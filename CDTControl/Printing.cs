using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CDTLib;
using CDTDatabase;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraLayout;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.UserDesigner;
using System.Collections;
using System.IO;
using System.Management;
using System.Drawing.Printing;
namespace CDTControl
{
  public  class Printing
    {
        object db;
        string FileName;
        string path;
        DevExpress.XtraReports.UI.XtraReport rptTmp = null;
        public Printing(object tb,string fileName)
        {
            db = tb;
            FileName = fileName;
            
            if (Config.GetValue("DuongDanBaoCao") != null)
                path = Config.GetValue("DuongDanBaoCao").ToString() + "\\" + Config.GetValue("Package").ToString() + "\\" + FileName + ".repx";
            else
                path = Application.StartupPath + "\\Reports\\" + Config.GetValue("Package").ToString() + "\\" + FileName + ".repx";
            string pathTmp;
            if (Config.GetValue("DuongDanBaoCao") != null)
                pathTmp = Config.GetValue("DuongDanBaoCao").ToString() + "\\" + Config.GetValue("Package").ToString() + "\\" + FileName + ".repx";
            else
                pathTmp = Application.StartupPath + "\\" + Config.GetValue("Package").ToString() + "\\Reports\\template.repx";
            if (System.IO.File.Exists(path))
                rptTmp = DevExpress.XtraReports.UI.XtraReport.FromFile(path, true);
            else if (System.IO.File.Exists(pathTmp))
                rptTmp = DevExpress.XtraReports.UI.XtraReport.FromFile(pathTmp, true);
            else
                rptTmp = new DevExpress.XtraReports.UI.XtraReport();
            
            
        }
        void designForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Alt && e.KeyCode == Keys.X)
                (sender as XRDesignFormEx).Close();
        }
       ManagementObjectCollection  getPrinter()
      {
          //string printerName = "YourPrinterName";
          string query = string.Format("SELECT * from Win32_Printer ");
          ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
          ManagementObjectCollection coll = searcher.Get();
          return coll;
          //foreach (ManagementObject printer in coll)
          //{
          //    foreach (PropertyData property in printer.Properties)
          //    {
          //       // Console.WriteLine(string.Format("{0}: {1}", property.Name, property.Value));
          //    }
          //}
      }
      bool ExitPrinter(string PrinterName)
      {
          //string printerName = "YourPrinterName";
          string query = string.Format("SELECT * from Win32_Printer ");

          ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
          ManagementObjectCollection coll = searcher.Get();

          foreach (ManagementObject printer in coll)
          {

              foreach (PropertyData property in printer.Properties)
              {
                  if (property.Name == "DeviceID")
                  {
                      if (property.Value.ToString().ToUpper() == PrinterName.ToUpper())
                          return true;
                  }

              }

          }
          return false;
      }
        public bool Print()
        {
            if (rptTmp == null) return false;
            SetVariables(rptTmp);
            rptTmp.ScriptReferences = new string[] { Application.StartupPath + "\\CDTLib.dll" };
            rptTmp.DataSource = db;
           
            if (ExitPrinter(Config.GetValue("PrinterName").ToString()))
            {
               
                rptTmp.Print(Config.GetValue("PrinterName").ToString());
                return true;
            }
            else
            {
                MessageBox.Show("Không tìm thấy máy in!");
                return false;
            }
        }
        public void Preview()
        {
            if (rptTmp == null) return;
            SetVariables(rptTmp);
            rptTmp.ScriptReferences = new string[] { Application.StartupPath + "\\CDTLib.dll" };
            rptTmp.DataSource = db;

            rptTmp.ShowPreview();
        }
        public void EditForm()
        {
            if (rptTmp != null)
            {
                rptTmp.DataSource = db;
                XRDesignFormEx designForm = new XRDesignFormEx();
                designForm.OpenReport(rptTmp);
                if (System.IO.File.Exists(path))
                    designForm.FileName = path;
                designForm.KeyPreview = true;
                designForm.KeyDown += new KeyEventHandler(designForm_KeyDown);
                designForm.Show();
            }
        }
        private void SetVariables(DevExpress.XtraReports.UI.XtraReport rptTmp)
        {
            foreach (DictionaryEntry de in Config.Variables)
            {
                string key = de.Key.ToString();
                if (key.Contains("@"))
                    key = key.Remove(0, 1);
                XRControl xrc = rptTmp.FindControl(key, true);
                if (xrc != null)
                {
                    string value = de.Value.ToString();
                    if (value.Contains("/"))
                        xrc.Text = DateTime.Parse(value).ToShortDateString();
                    else
                        xrc.Text = value;
                    xrc = null;
                }
            }
        }

    }
}
