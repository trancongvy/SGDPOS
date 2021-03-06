using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CDTLib;
using CDTDatabase;
namespace CusPOS
{
    public partial class fThanhtoan : DevExpress.XtraEditors.XtraForm
    {
        Database _db = Database.NewDataDatabase();
        DataTable dmphong;
        DataTable dmtk;
        public int returnValue = -1;
        public string maphong = "";
        public string tk = "";
        public fThanhtoan()
        {
            InitializeComponent();
            string sql;

            sql = "select TK, tentk from dmtk where TK like '1121%' and tk not in (select tkme from dmtk where tkme is not null)";
            dmtk = _db.GetDataTable(sql);
            gridLookUpEdit2.Properties.DataSource = dmtk;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (radioGroup1.SelectedIndex == 0)
            {
                returnValue = 0;
                this.Dispose();
            }
            else if (radioGroup1.SelectedIndex == 1)
            {
                if (gridLookUpEdit2.EditValue != null)
                {
                    tk = gridLookUpEdit2.EditValue.ToString();
                    this.returnValue = 1;
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("Chưa chọn tài khoản");
                }

            }
            
            else if (radioGroup1.SelectedIndex == 3)
            {
                returnValue = 3;
                this.Dispose();
            }
        }

        private void fThanhtoan_Load(object sender, EventArgs e)
        {

        }
    }
}