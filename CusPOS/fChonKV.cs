using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CDTDatabase;
using DataFactory;
using CDTLib;
using CDTControl;
namespace CusPOS
{
    public partial class fChonKV : Form
    {
        Database db = Database.NewDataDatabase();
        DataTable tb;
        public string MaKV = "";
       public string PrinterPos = "";
        public string PrinterBep = "";
        public int loai = 0;
        public fChonKV(int _loai)
        {
            InitializeComponent();
            loai = _loai;
            
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (gridLookUpEdit1.EditValue != null)
            {
                MaKV = gridLookUpEdit1.EditValue.ToString();
                tb.PrimaryKey = new DataColumn[] { tb.Columns["MaPosArea"] };
                DataRow dr= tb.Rows.Find(MaKV);
                if(dr!=null)
                {
                    if (dr["MayInPOS"] != DBNull.Value) PrinterPos = dr["MayInPOS"].ToString();
                    if (dr["MayInBEP"] != DBNull.Value) PrinterBep = dr["MayInBEP"].ToString();
                }
                this.Close();
            }
        }

        private void fChonKV_Load(object sender, EventArgs e)
        {
            string sql = "select * from dmPOSArea where isFastFood=" + loai.ToString();
            tb = db.GetDataTable(sql);
            if (tb == null) return;
            gridLookUpEdit1.Properties.DataSource = tb;
        }
    }
}
