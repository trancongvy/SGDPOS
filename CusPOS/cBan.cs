using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CDTDatabase;
namespace CusPOS
{
    public partial class cBan :DevExpress.XtraEditors.XtraUserControl
    {
       public DataTable tb;

        Database db = Database.NewDataDatabase();
        public string tSoBan = "";
        public double tTienH=0;
        public double tTien = 0;
        public string id;
        private double ptckmt = 0;
        public double ptCkMT
        {
            get { return ptckmt; }
            set
            {
                ptckmt = value;
                foreach (DataRow dr in tb.Rows)
                {
                    if (dr["isCK"] != DBNull.Value && bool.Parse(dr["isCK"].ToString()))
                    {
                        dr["ptckct"] = ptckmt;
                    }
                }
            }
        }
        public double Ck = 0;
        public string MaKH = "";
        public cBan(string soban)
        {
            InitializeComponent();
            tSoBan = soban;
            this.Width = 146;
            this.Height = 110;
            this.BorderStyle = BorderStyle.FixedSingle;
            this.MouseMove += new MouseEventHandler(cBan_MouseHover);
            this.MouseLeave += new EventHandler(cBan_MouseLeave);
            this.MouseHover += new EventHandler(cBan_MouseHover);
            this.MouseDown += new MouseEventHandler(cBan_MouseDown);
            this.MouseUp += new MouseEventHandler(cBan_MouseUp);
            this.Click += new EventHandler(cBan_Click);
            //this.TienChange += CBan_TienChange;
            getdata();
        }

        private void CBan_TienChange(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void getdata()
        {
            string sql = "select a.mamon,b.tenmon, soluong, dongia,tienh, ptckct , ckct, thanhtien, ctposid, c.mtposid, c.makh, c.ck, c.PtCK , b.isck, a.inbep,a.sldain, soluong-slDain as slIn from ctpos a inner join dmmon b on a.mamon=b.mamon inner join mtpos c on a.mtposid=c.mtposid where a.maban='" + tSoBan + "' and (c.DaTT=0 or c.daTT is null) ";
            tb = db.GetDataTable(sql);
            if (tb.Rows.Count > 0) id = tb.Rows[0]["mtposid"].ToString();
            else id = Guid.NewGuid().ToString();
            GetSum();
            tb.ColumnChanged += new DataColumnChangeEventHandler(tb_ColumnChanged);
            tb.TableNewRow += Tb_TableNewRow;
        }

        private void Tb_TableNewRow(object sender, DataTableNewRowEventArgs e)
        {
            
        }

        internal void Save()
        {
            //Kiểm tra bàn này có chưa
            db.BeginMultiTrans();
            try
            {
                string sql = "select count(mtposid) from mtpos where mtposid='" + id.ToString() + "'";
                object ex = db.GetValue(sql);
                if (tb.Rows.Count == 0) return;
                if (ex.ToString() == "" || ex.ToString() == "0") //chưa tồn tại
                {
                    sql = "insert into Mtpos (MTPOSID, ngayct, tile, Maban, TTien, TTienH, Ptck, Ck, Datt) values('";
                    sql += id.ToString() + "','" + DateTime.Now.ToShortDateString() + "',1,'" + tSoBan + "'," + tTien.ToString("#############0.##") + "," + tTien.ToString("#############0.##") +
                        "," + ptCkMT.ToString("#############0.##") + "," + Ck.ToString("#############0.##") + ",0)";

                    db.UpdateByNonQuery(sql);
                    if (db.HasErrors)
                    {
                        db.RollbackMultiTrans();
                        return;
                    }
                }
                else //đã tồn tại
                {
                    sql = "update mtpos set TTienH=" + tTien.ToString("#############0.##") + ", TTien=" + tTien.ToString("#############0.##");
                    sql += " where mtposid='" + id + "'";
                    db.UpdateByNonQuery(sql);
                    if (db.HasErrors)
                    {
                        db.RollbackMultiTrans();
                        return;
                    }
                }
                foreach (DataRow dr in tb.Rows)
                {
                    if (dr.RowState == DataRowState.Deleted)
                    {
                        dr.RejectChanges();
                        string ctid = dr["ctposid"].ToString();
                        sql = "delete ctpos where ctposid='" + ctid + "'";
                        db.UpdateByNonQuery(sql);
                        dr.Delete();
                        if (db.HasErrors)
                        {
                            db.RollbackMultiTrans();
                            return;
                        }
                    }
                    else
                    {
                        sql = "select count(ctposid) from ctpos where ctposid='" + dr["ctposid"].ToString() + "'";
                        object exct = db.GetValue(sql);
                        if (exct.ToString() == "" || exct.ToString() == "0") //chưa tồn tại
                        {
                            if (dr["ptckct"] == DBNull.Value) dr["ptckct"] = 0;
                            sql = "insert into ctpos(mtposid, ctposid,maban,mamon, soluong, dongia,tienH, ptckct, ckct, thanhtien,datt, slDain) values ('";
                            sql += id.ToString() + "','" + dr["ctposid"].ToString() + "','" + tSoBan + "','" + dr["mamon"].ToString() + "'," + dr["soluong"].ToString() + "," + dr["dongia"].ToString() +
                                "," + dr["tienH"].ToString() + "," + dr["ptckct"].ToString() + "," + dr["ckct"].ToString() +
                                "," + dr["thanhtien"].ToString() + ",0," + dr["slDain"].ToString() +")";
                            db.UpdateByNonQuery(sql);
                            if (db.HasErrors)
                            {
                                db.RollbackMultiTrans();
                                return;
                            }
                        }
                        else
                        {
                            sql = "update ctpos set soluong=" + dr["soluong"].ToString() + ", slDain=" + dr["slDain"].ToString() + ", thanhtien=" + dr["thanhtien"].ToString() + ", ckct=" + dr["ckct"].ToString() + ", tienH=" + dr["tienh"].ToString() + " where ctposid='" + dr["ctposid"].ToString() + "'";
                            db.UpdateByNonQuery(sql);
                            if (db.HasErrors)
                            {
                                db.RollbackMultiTrans();
                                return;
                            }
                        }
                    }
                }//end for
                db.EndMultiTrans();
                tb.AcceptChanges();
            }catch
            {
                MessageBox.Show("udpate không thành công");
            }
        }
        internal void Thanhtoan()
        {
            this.Save();
            fThanhtoan f = new fThanhtoan();
            f.ShowDialog();
            if (f.returnValue == -1) return;
            string sql ;
            if (f.returnValue == 0){
                sql = "Update mtpos set ngayct=getdate(),HTTT=0,DaTT=1 where MTPOSID='" + id.ToString() + "'";
            }
            else if(f.returnValue == 1)
            {
                sql = "Update mtpos set ngayct=getdate(),DaTT=1,HTTT=1, Sotk='" +f.tk+ "' where MTPOSID='" + id.ToString() + "'";
            }
            else 
            {
                sql = "Update mtpos set ngayct=getdate(),DaTT=1' where MTPOSID='" + id.ToString() + "'";
            }
            db.UpdateByNonQuery(sql);
            this.getdata();

        }
        void tb_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            try
            {
                if (e.Column.ColumnName == "soluong" || e.Column.ColumnName == "ptckct")
                {
                    e.Row["tienh"] = double.Parse(e.Row["dongia"].ToString()) * double.Parse(e.Row["soluong"].ToString());
                    e.Row["ckct"] = Math.Round(double.Parse(e.Row["tienh"].ToString()) * double.Parse(e.Row["ptckct"].ToString()) / 100, 0);
                    e.Row["thanhtien"] = double.Parse(e.Row["tienh"].ToString()) - double.Parse(e.Row["ckct"].ToString());
                    e.Row.EndEdit();
                    GetSum();
                    if (e.Column.ColumnName == "soluong")
                    {
                        e.Row["slin"] = double.Parse(e.Row["soluong"].ToString()) - double.Parse(e.Row["slDain"].ToString());
                    }

                }

            }
            catch { }
        }

        public void GetSum()
        {
            tTien = 0;
            tTienH = 0;
            Ck =0 ;
            foreach (DataRow dr in tb.Rows)
            {
                if (dr.RowState == DataRowState.Deleted) continue;
                tTienH += double.Parse(dr["tienh"].ToString());
                tTien += double.Parse(dr["thanhtien"].ToString());
                if (dr["ckct"] == DBNull.Value) dr["ckct"] = 0;
                Ck += double.Parse(dr["ckct"].ToString());
            }
            if (TienChange != null)
                TienChange(this, new EventArgs());
        }

        public event EventHandler ChonBan;
        public event EventHandler TienChange;
        void cBan_Click(object sender, EventArgs e)
        {
            ChonBan(this, e);
        }

        #region Hiệu ứng
        
        void cBan_MouseUp(object sender, MouseEventArgs e)
        {
            Graphics g = this.CreateGraphics();
            LinearGradientBrush myBrush = null;
            myBrush = new LinearGradientBrush(ClientRectangle, Color.AliceBlue, Color.CornflowerBlue, LinearGradientMode.ForwardDiagonal);
            g.FillRectangle(myBrush, ClientRectangle);
            Brush brush = new SolidBrush(Color.Navy);

            g.DrawString("Bàn số", new Font("Times New Roman", 10), brush, new PointF(20, 17));
            g.DrawString(tSoBan, new Font("Times New Roman", 15, FontStyle.Bold), brush, new PointF(60, 13));
            g.DrawString("Số tiền", new Font("Times New Roman", 10), brush, new PointF(20, 41));
            brush = new SolidBrush(Color.Red);
            g.DrawString(tTien.ToString("### ### ### ###"), new Font("Times New Roman", 15, FontStyle.Bold), brush, new PointF(20, 64));

        }

        void cBan_MouseDown(object sender, MouseEventArgs e)
        {
            Graphics g = this.CreateGraphics();
            LinearGradientBrush myBrush = null;
            myBrush = new LinearGradientBrush(ClientRectangle,   Color.AliceBlue, Color.CornflowerBlue,LinearGradientMode.BackwardDiagonal);
            g.FillRectangle(myBrush, ClientRectangle);
            Brush brush = new SolidBrush(Color.Navy);

            g.DrawString("Bàn số", new Font("Times New Roman", 10), brush, new PointF(20, 17));
            g.DrawString(tSoBan, new Font("Times New Roman", 15, FontStyle.Bold), brush, new PointF(60, 13));
            g.DrawString("Số tiền", new Font("Times New Roman", 10), brush, new PointF(20, 41));
            brush = new SolidBrush(Color.Red);
            g.DrawString(tTien.ToString("### ### ### ###"), new Font("Times New Roman", 15, FontStyle.Bold), brush, new PointF(20, 64));

        }

        void cBan_MouseHover(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            LinearGradientBrush myBrush = null;
            myBrush = new LinearGradientBrush(ClientRectangle, Color.CornflowerBlue, Color.AliceBlue,  LinearGradientMode.ForwardDiagonal);
            g.FillRectangle(myBrush, ClientRectangle);
             Brush brush = new SolidBrush(Color.Navy);
            
            g.DrawString("Bàn số", new Font("Times New Roman", 10), brush, new PointF(20, 17));
            g.DrawString(tSoBan, new Font("Times New Roman", 15,FontStyle.Bold), brush, new PointF(60, 13));
            g.DrawString("Số tiền", new Font("Times New Roman", 10), brush, new PointF(20, 41));
            brush = new SolidBrush(Color.Red);
            g.DrawString(tTien.ToString("### ### ### ###"), new Font("Times New Roman", 15, FontStyle.Bold), brush, new PointF(20, 64));

        }

        void cBan_MouseLeave(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            LinearGradientBrush myBrush = null;
            myBrush = new LinearGradientBrush(ClientRectangle, Color.AliceBlue, Color.CornflowerBlue, LinearGradientMode.ForwardDiagonal);
            g.FillRectangle(myBrush, ClientRectangle);
            Brush brush = new SolidBrush(Color.Navy);
           
            g.DrawString("Bàn số", new Font("Times New Roman", 10), brush, new PointF(20, 17));
            g.DrawString(tSoBan, new Font("Times New Roman", 12), brush, new PointF(76, 13));
            g.DrawString("Số tiền", new Font("Times New Roman", 10), brush, new PointF(20, 41));
            brush = new SolidBrush(Color.Red);
            g.DrawString(tTien.ToString("### ### ### ###"), new Font("Times New Roman", 15, FontStyle.Bold), brush, new PointF(20, 64));

        }
        
        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            LinearGradientBrush myBrush = null;
            myBrush = new LinearGradientBrush(ClientRectangle, Color.AliceBlue, Color.CornflowerBlue, LinearGradientMode.ForwardDiagonal);
            pevent.Graphics.FillRectangle(myBrush, ClientRectangle);
            Brush brush = new SolidBrush(Color.Navy);
            Graphics g = this.CreateGraphics();
            g.DrawString("Bàn số", new Font("Times New Roman", 10), brush, new PointF(20, 17));
            g.DrawString(tSoBan, new Font("Times New Roman", 12), brush, new PointF(76, 13));
            g.DrawString("Số tiền", new Font("Times New Roman", 10), brush, new PointF(20, 41));
            brush = new SolidBrush(Color.Red);
            g.DrawString(tTien.ToString("### ### ### ###"), new Font("Times New Roman", 15, FontStyle.Bold), brush, new PointF(20, 64));

        }








        #endregion

        private void cBan_Load(object sender, EventArgs e)
        {

        }
    }
}
