using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CDTDatabase;
using CDTLib;
namespace CusPOS
{

    public partial class fPOS : DevExpress.XtraEditors.XtraForm
    {
        Database db = Database.NewDataDatabase();
        int TrangThai = 0;//0: Bình thường; 1: gộp bàn; 2: Tách bàn

        public fPOS()
        {
            InitializeComponent();
        }

        private void fPOS_Load(object sender, EventArgs e)
        {
            fChonKV fchonkv = new fChonKV(0);
            fchonkv.ShowDialog();
            if (fchonkv.MaKV != "")
            {
                MaKV = fchonkv.MaKV;
                KhoiTaoKhuVuc();
                this.Resize += new EventHandler(fPOS_Resize);
            }
        }

        string MaKV = "";
        DataTable tbA;
        private void KhoiTaoKhuVuc()
        {
            string sql = "select * from dmPOSArea where MaPosArea='" + MaKV + "'";
            tbA = db.GetDataTable(sql);
            int x = 0;
            foreach (DataRow drA in tbA.Rows)
            {
                SimpleButton bt = new SimpleButton();
                bt.Text = drA["TenPOSArea"].ToString();
                bt.Tag = drA["MaPOSArea"].ToString();
                panelControl1.Controls.Add(bt);
                bt.Left = x;
                bt.Top = 45;
                bt.Size = new Size(150, 100);
                bt.Visible = true;
                x += 151;
                bt.Click += new EventHandler(bt_Click);
                KhoiTaoBan(bt.Tag.ToString());
            }
        }
        List<PanelControl> lPan = new List<PanelControl>();
        void fPOS_Resize(object sender, EventArgs e)
        {
            //Sapsep
                foreach (PanelControl p1 in lPan)
                {
                    int x = 0; int y = 0;
                    foreach (Control cb in p1.Controls)
                    {
                        cb.Top = y;
                        cb.Left = x;
                        if (x > this.Width - 2 * cb.Width)
                        {
                            x = 0;
                            y += cb.Height + 2;
                        }
                        else
                        {
                            x += cb.Width + 2;
                        }
                    }

                }
        }
        private void KhoiTaoBan(string MaKV)
        {
            PanelControl p1 = new PanelControl();
            p1.Text = MaKV;
            p1.Dock = DockStyle.Fill;
            p1.Visible = true;
            this.Controls.Add(p1);
            lPan.Add(p1);
            p1.BringToFront();
            string sql = "select * from dmban where MaPOSArea='" + MaKV + "'";
            DataTable tb = db.GetDataTable(sql);
            int x = 0; int y = 0;
            foreach (DataRow dr in tb.Rows)
            {
                cBan cb = new cBan(dr["MaBan"].ToString());
                cb.Top = y;
                cb.Left = x;
                cb.Visible = true;
                p1.Controls.Add(cb);
                cb.ChonBan += new EventHandler(cb_ChonBan);
                if (x > this.Width - 2 * cb.Width)
                {
                    x = 0;
                    y += cb.Height + 2;
                }
                else
                {
                    x += cb.Width + 2;
                }
            }
        }



        void bt_Click(object sender, EventArgs e)
        {
            foreach (PanelControl c in lPan)
            {
                if (c.Text == (sender as SimpleButton).Tag.ToString())
                    c.BringToFront();
            }
            //Khởi tạo bàn
        }

        fMoban fMoBan;
        void cb_ChonBan(object sender, EventArgs e)
        {
            if (TrangThai == 0)
            {
                cBan cb = sender as cBan;
                if (fMoBan == null) fMoBan = new fMoban();
                fMoBan.Ban = cb;
                fMoBan.ShowDialog();
            }
        }
    }
}