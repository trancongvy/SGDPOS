using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using CDTLib;
namespace CusAccounting
{
    public partial class fTaoPTT : DevExpress.XtraEditors.XtraForm
    {

        BindingSource bs = new BindingSource();
        DbTaoPTT db = new DbTaoPTT();
        double TongCong = 0;
        double Conlai = 0;
        public fTaoPTT()
        {
            InitializeComponent();
            spinEdit1.Value = decimal.Parse(Config.GetValue("Tile").ToString());
            designCol4Rep();
            this.repositoryItemGridLookUpEdit2.DataSource = db.dmVt1;
            this.repositoryItemGridLookUpEdit4.DataSource = db.dmVt2;
            gridControl2.KeyUp += new KeyEventHandler(gridControl2_KeyUp);
            gridControl3.KeyUp += new KeyEventHandler(gridControl3_KeyUp);
            db.Getdata();
            db.TileTU = double.Parse(spinEdit1.Value.ToString());
            bs.DataSource = db.MT31;
            
            bs.CurrentChanged += new EventHandler(bs_CurrentChanged);
            
            gridControl1.DataSource = bs;
            
            gridControl2.DataSource = db.DtThucUong;
            gridView2.OptionsNavigation.EnterMoveNextColumn = true;
            gridControl3.DataSource = db.DtThucAn;
            gridView3.OptionsNavigation.EnterMoveNextColumn = true;
            db.sumChange += new EventHandler(db_sumChange);
            
            
            bs_CurrentChanged(bs,new EventArgs());
        }

        void gridControl3_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F8)          
            {
                gridView3.DeleteSelectedRows();
            }
        }

        void gridControl2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F8)            {
               
                gridView2.DeleteSelectedRows();
            }
        }

        void db_sumChange(object sender, EventArgs e)
        {
            tSumTA.Text = db.SumPNTA.ToString("### ### ### ###");
            tTileTA.Text = "Tỉ lệ: " + db.CurTileTA.ToString("### ### ### ###.##");
            tSumTU.Text = db.SumPNTU.ToString("### ### ### ###");
            tTileTU.Text = "Tỉ lệ: " + db.CurTileTU.ToString("### ### ### ###.##");
            TongCong = db.SumPNTA + db.SumPNTU;
            Conlai = double.Parse(db.drMaster["Conlai"].ToString()) - TongCong;
            tTongCong.Text = TongCong.ToString("### ### ### ###");
            tConlai.Text = Conlai.ToString("### ### ### ###");
            tileTA.Text = "Tỉ lệ tương đối: " + db.tileTA.ToString("### ### ### ###.##");
            tileTU.Text = "Tỉ lệ tương đối: " + db.tileTU.ToString("### ### ### ###.##");
            TongtileTA.Text = "Cộng Tỉ lệ: " + db.TongtileTA.ToString("### ### ### ###.##");
            TongtileTU.Text = "Cộng Tỉ lệ: " + db.TongtileTU.ToString("### ### ### ###.##");
            if (Conlai < 0) tConlai.ForeColor = Color.Red;
            else tConlai.ForeColor = Color.DarkGreen;
            if (db.TileTU < db.tileTU) tileTU.ForeColor = Color.Red;
            else tileTU.ForeColor = Color.DarkGreen;
            if (db.TileTU < db.TongtileTU) TongtileTU.ForeColor = Color.Red;
            else TongtileTU.ForeColor = Color.DarkGreen;

        }

      
        private void designCol4Rep()
        {
            GridColumn col = new GridColumn();
            col.Caption = "Mã";
            col.FieldName = "MaVT";
            col.Visible = true;
            col.VisibleIndex = 0;
            col.Width = 204;

            GridColumn col1 = new GridColumn();
            col1.Caption = "Tên";
            col1.FieldName = "TenVT";
            col1.Visible = true;
            col1.VisibleIndex = 1;
            col1.Width = 300;
            GridColumn col2 = new GridColumn();
            col2.Caption = "Giá";
            col2.FieldName = "GiaBan";
            col2.DisplayFormat.FormatString = "### ### ### ###";
           col2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            col2.Visible = true;
            col2.VisibleIndex = 2;
            col2.Width = 204;
            GridColumn col0 = new GridColumn();
            col0.Caption = "Số lượng tồn";
            col0.FieldName = "slTon";
            col0.DisplayFormat.FormatString = "### ### ### ###";
            col0.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            col0.Visible = true;
            col0.VisibleIndex = 3;
            col0.Width = 204;
            repositoryItemGridLookUpEdit2View.Columns.AddRange(new GridColumn[] { col, col1, col2,col0 });
            repositoryItemGridLookUpEdit2.EndInit();
            GridColumn col3 = new GridColumn();
            col3.Caption = "Mã";
            col3.FieldName = "MaVT";
            col3.Visible = true;
            col3.VisibleIndex = 0;
            col3.Width = 204;

            GridColumn col4 = new GridColumn();
            col4.Caption = "Tên";
            col4.FieldName = "TenVT";
            col4.Visible = true;
            col4.VisibleIndex = 1;
            col4.Width = 300;
            GridColumn col5 = new GridColumn();
            col5.Caption = "Giá";
            col5.FieldName = "GiaBan";
            col5.Visible = true;
            col5.VisibleIndex = 2;
            col5.DisplayFormat.FormatString = "### ### ### ###";
            col5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            col5.Width = 204;
            gridView5.Columns.AddRange(new GridColumn[] { col3, col4, col5 });
            gridView5.EndInit();
        }
        void bs_CurrentChanged(object sender, EventArgs e)
        {
            
            if (db.DtThucUong.Rows.Count > 0 || db.DtThucAn.Rows.Count > 0)
            {
                if (MessageBox.Show( "Bạn có lưu phiếu tính tiền này không","Cảnh báo ", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    db.CreatePTT();
                }
                else
                {
                    db.DtThucUong.Rows.Clear();
                    db.DtThucAn.Rows.Clear();
                    db.SumPNTA = 0;
                    db.SumPNTU = 0;
                    db.tinhTile();
                }
            }
            if (bs.Current == null)
            {
                db.drMaster = null;
                return;
            }
            db.drMaster = (bs.Current as DataRowView).Row;
            if (bool.Parse(db.drMaster["Banle"].ToString()))
            {
                panelControl8.Visible = true;
                panelControl9.Visible = true;
                panelControl6.Visible = false;
                panelControl7.Visible = false;
            }
            else
            {
                panelControl8.Visible = false;
                panelControl9.Visible = false;
                panelControl6.Visible = true;
                panelControl7.Visible = true;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (db.drMaster == null) return;
            if (checkRule())
            {
                if (db.CreatePTT())
                {
                    MessageBox.Show("Cập nhật thành công");
                    db.DtThucAn.Rows.Clear();
                    db.DtThucUong.Rows.Clear();
                    db.SumPNTA = 0;
                    db.SumPNTU = 0;
                    db.tinhTile();
                    if (double.Parse(db.drMaster["Conlai"].ToString()) == 0)
                    {
                        gridView1.DeleteSelectedRows();
                    }
                    
                }
                else
                {
                    MessageBox.Show("Cập nhật không thành công");
                }
            }
            else
            {
                MessageBox.Show("Dữ liệu chưa hợp lệ!");
            }
        }
        
        private bool checkRule()
        {
            return db.checkRule();
        }

        private void spinEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (db != null) db.TileTU = double.Parse(spinEdit1.Value.ToString());
        }

        

       
    }
}