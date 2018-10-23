using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CDTDatabase;
using CDTLib;
using System.Threading;
namespace CusPOS
{
    public partial class fBep : XtraForm
    {
        Database db = Database.NewDataDatabase();
        DataTable tb;
        List<iBep> lBep = new List<iBep>();
        public fBep()
        {
            InitializeComponent();
        }
        bool flag = false;
        private void TaoBep()
        {
            if (tb == null) return;
            foreach (iBep i in lBep)
            {
                DataRow[] ldr = tb.Select("CTPOSID='" + i.ID + "'");
                try
                {
                    if (ldr.Length == 0)
                        mypanel.Controls.Remove(i);
                }
                catch { }
            }
            foreach (DataRow dr in tb.Rows)
            {
                iBep i = lBep.Find(m => m.ID == dr["CTPOSID"].ToString());
                if (i == null)
                {
                    i = new iBep(dr["CTPOSID"].ToString(), dr["MaMon"].ToString(), dr["TenMon"].ToString(), double.Parse(dr["Soluong"].ToString()), dr["MaBan"].ToString());
                    mypanel.Controls.Add(i);
                }
                else
                {
                    i.Soluong = double.Parse(dr["Soluong"].ToString());
                }
            }
            lBep.Clear();
            int top = 0;
            foreach (Control i in mypanel.Controls)
            {
                try
                {
                    i.Top = (top / 2 ) * (i.Height+3);
                    i.Left = (top % 2) * (i.Width + 3);
                    lBep.Add(i as iBep);
                    top++;
                }
                catch { }
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (flag) return;
            Thread get = new Thread(getiBep);
            get.Start();

            TaoBep();
        }

        private void fBep_Load(object sender, EventArgs e)
        {
            mypanel.AutoScroll = false;
            mypanel.HorizontalScroll.Enabled = false;
            mypanel.HorizontalScroll.Visible = false;
            mypanel.HorizontalScroll.Maximum = 0;
            mypanel.AutoScroll = true;
            timer1_Tick(this, e);
        }
        private void getiBep()
        {
            flag = true;
            string sql = "select a.*, b.TenMon from ctpos a inner join dmmon b on a.mamon=b.mamon where ibep=0 or ibep is null order by stt";
            tb = db.GetDataTable(sql);
            flag = false;
            
        }

        private void mypanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
