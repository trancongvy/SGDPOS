using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CDTDatabase;
using System.Data.SqlClient;
namespace CusAccounting
{
    public partial class CoPhanBoCtrinh : DevExpress.XtraEditors.XtraForm
    {
        public CoPhanBoCtrinh()
        {
            InitializeComponent();
            GetData4Lookup();
        }
        Database dbData = Database.NewDataDatabase();
        private void GetData4Lookup()
        {
            string s = "select Tk, Tentk from dmtk";
            DataTable dmtkN = dbData.GetDataTable(s);
            gTkNguon.Properties.DataSource = dmtkN;
            gTkNguon.Properties.DisplayMember = "Tk";
            gTkNguon.Properties.ValueMember= "Tk";
            s = "select Tk, Tentk from dmtk where tk not in (select tkMe from dmtk where tkMe is not null)";
            DataTable dmtkD = dbData.GetDataTable(s);
            gTkDich.Properties.DataSource = dmtkD;
            gTkDich.Properties.DisplayMember = "Tk";
            gTkDich.Properties.ValueMember = "Tk";

            gTkChitieu.Properties.DataSource = dmtkN;
            gTkChitieu.Properties.DisplayMember = "Tk";
            gTkChitieu.Properties.ValueMember = "Tk";

            s = "select MaVT, TenVT,MaDVT, Nhom from dmVt";
            DataTable dmvt = dbData.GetDataTable(s);
            gVtChitieu.Properties.DataSource = dmvt;
            gVtChitieu.Properties.DisplayMember = "MaVT";
            gVtChitieu.Properties.ValueMember = "MaVT";

             s = "select MaNhomVT, TenNhom from dmnhomVt";
            DataTable dmnhomvt = dbData.GetDataTable(s);
            gNhomChitieu.Properties.DataSource = dmnhomvt;
            gNhomChitieu.Properties.DisplayMember = "MaNhomVT";
            gNhomChitieu.Properties.ValueMember = "MaNhomVT";
        }
        string sqlChitieu;
        DateTime Ngayct1;
        DateTime Ngayct2;
        string tkNguon;
        string tkDich;
        DataTable tbDich;
        DataTable tbPhanbo;
        private void sOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(sOption.SelectedIndex)
            {
                case 0 : 
                case 1:
                    gTkChitieu.Enabled = true;
                    gVtChitieu.Enabled = false;
                    gNhomChitieu.Enabled = false;
                    gTkChitieu_EditValueChanged(sender, e);
                    break;
                case 2:
                case 3:
                    gTkChitieu.Enabled = false;
                    gVtChitieu.Enabled = true;
                    gNhomChitieu.Enabled = false;
                    gVtChitieu_EditValueChanged(sender, e);
                    break;
                case 4:
                case 5:
                    gTkChitieu.Enabled = false;
                    gVtChitieu.Enabled = false;
                    gNhomChitieu.Enabled = true;
                    gNhomChitieu_EditValueChanged(sender, e);
                    break;
                case 6:
                    gTkChitieu.Enabled = false;
                    gVtChitieu.Enabled = false;
                    gNhomChitieu.Enabled = false;
                    break;

            }
        }

        private void gTkChitieu_EditValueChanged(object sender, EventArgs e)
        {
            if (gTkChitieu.EditValue == null) return;
            string tkChitieu = gTkChitieu.EditValue.ToString();
            if (Ngayct1 == null || Ngayct2 == null) return;
            switch (sOption.SelectedIndex)
            {
                case 0:
                    sqlChitieu = "select MaCongtrinh, sum(psno) as Ps from bltk where tk like '" + tkChitieu + "%' and ngayct between '" + Ngayct1.ToShortDateString() + "' and '" + Ngayct2.ToShortDateString() + "' and MaCongtrinh is not null  group by MaCongtrinh";
                    break;
                case 1:
                    sqlChitieu = "select MaCongtrinh, sum(psco) as Ps from bltk where tk like '" + tkChitieu + "%' and ngayct between '" + Ngayct1.ToShortDateString() + "' and '" + Ngayct2.ToShortDateString() + "' and MaCongtrinh is not null  group by MaCongtrinh";
                    break;
            }
        }

        private void gVtChitieu_EditValueChanged(object sender, EventArgs e)
        {
            if (gVtChitieu.EditValue == null) return;
            string vtChitieu = gVtChitieu.EditValue.ToString();
            if (Ngayct1 == null || Ngayct2 == null) return;
            switch (sOption.SelectedIndex)
            {
                case 2:
                    sqlChitieu = "select MaCongtrinh, sum(soluong) as Ps from blvt where mavt = '" + vtChitieu + "' and ngayct between '" + Ngayct1.ToShortDateString() + "' and '" + Ngayct2.ToShortDateString() + "' and MaCongtrinh is not null  group by MaCongtrinh";
                    break;
                case 3:
                    sqlChitieu = "select MaCongtrinh, sum(soluong_x) as Ps from blvt where mavt = '" + vtChitieu + "' and ngayct between '" + Ngayct1.ToShortDateString() + "' and '" + Ngayct2.ToShortDateString() + "' and MaCongtrinh is not null  group by MaCongtrinh";
                    break;
            }
        }

        private void gNhomChitieu_EditValueChanged(object sender, EventArgs e)
        {
            if (Ngayct1 == null || Ngayct2 == null || gNhomChitieu.EditValue==null) return;
                string nhomChitieu = gNhomChitieu.EditValue.ToString();
            switch (sOption.SelectedIndex)
            {
                case 4:
                    sqlChitieu = "select MaCongtrinh, sum(soluong) as Ps from blvt where mavt in (select mavt from dmvt where nhom='" + nhomChitieu + "') and ngayct between '" + Ngayct1.ToShortDateString() + "' and '" + Ngayct2.ToShortDateString() + "' and MaCongtrinh is not null group by MaCongtrinh";
                    break;
                case 5:
                    sqlChitieu = "select MaCongtrinh, sum(soluong_x) as Ps from blvt where mavt in (select mavt from dmvt where nhom='" + nhomChitieu + "') and ngayct between '" + Ngayct1.ToShortDateString() + "' and '" + Ngayct2.ToShortDateString() + "' and MaCongtrinh is not null  group by MaCongtrinh";
                    break;
            }
        }

        private void gTkNguon_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                tkNguon = gTkNguon.EditValue.ToString();
                if (tkNguon.Substring(0, 3) == "621")
                {
                    sOption.SelectedIndex = 6;
                }
            }
            catch { }
        }

        private void gTkDich_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                tkDich = gTkDich.EditValue.ToString();
            }
            catch { }
        }

        private void dNgayCt1_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
               Ngayct1 =DateTime.Parse(dNgayCt1.EditValue.ToString());
            }
            catch { }
        }

        private void dNgayCt2_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                Ngayct2 = DateTime.Parse(dNgayCt2.EditValue.ToString());
            }
            catch { }
        }

        private void sbChapNhan_Click(object sender, EventArgs e)
        {
            DataTable tbChitieu;
            DataTable tbNguon;
            sOption_SelectedIndexChanged(sender,e);
            if (sOption.SelectedIndex == 6)
            {
                if (tkNguon.Substring(0, 3) != "621") return;
                DataSet dsPB = dbData.GetDataSetByStore1("GetPhanBoVattuCongtrinh", new string[] { "@ngayct1", "@ngayct2" }, new object[] { Ngayct1, Ngayct2 });
                if (dsPB == null) return;
                tbChitieu = dsPB.Tables[0];
                tbNguon = dsPB.Tables[1];
                tbDich = dsPB.Tables[2];
                tbPhanbo = dsPB.Tables[3];
                //DataColumn dctk = new DataColumn("tk", typeof(string));
                //dctk.DefaultValue = tkNguon;
                DataColumn dctkDich = new DataColumn("tkDich", typeof(string));
                dctkDich.DefaultValue = tkDich;
                //tbDich.Columns.Add(dctk);
                tbDich.Columns.Add(dctkDich);
                gridControl1.DataSource = tbChitieu;
                gridControl2.DataSource = tbNguon;
                gridControl3.DataSource = tbDich;
                cmavt1.Visible = true;
                cmavt2.Visible = true;
                cTsl.Visible = true;
                return;
            }
            else
            {
                cmavt1.Visible = true;
                cmavt2.Visible = true;
                cTsl.Visible = true;
            }
            if (sqlChitieu == null) return;
            tbPhanbo = null;
            tbChitieu= dbData.GetDataTable(sqlChitieu);
            double TongChitieu=0;
            foreach(DataRow drctieu in tbChitieu.Rows)
                TongChitieu+=double.Parse(drctieu["ps"].ToString());
            
            gridControl1.DataSource = tbChitieu;
            if (TongChitieu == 0) return;
            if (tkNguon == null) return;
            string sql ="select tk, sum(psno-psco) as Tps, 0.0 as ps,  Null as tkDich ";
            string group = " group by tk";
            if (isMaPhi.Checked)
            {
                sql += ",maphi"; group += ",maphi";
                gcBP.Visible = true;
                gcBphan.Visible = true;
            }
            else { gcBP.Visible = false; gcBphan.Visible = false; }
            if (isVuviec.Checked)
            {
                sql += ",mavv "; group += ",mavv";
                gcVV.Visible = true;
                gcVviec.Visible = true;
            }
            else { gcVV.Visible = false; gcVviec.Visible = false; }
            sql+= " from bltk where tk like '" + tkNguon + "%'  and ngayct between '" + Ngayct1.ToShortDateString() + "' and '" + Ngayct2.ToShortDateString() + "' and macongtrinh is Null ";
            sql += group;
            tbNguon = dbData.GetDataTable(sql);
            gridControl2.DataSource = tbNguon;
            tbDich = tbNguon.Clone();
            tbDich.Columns.Add(new DataColumn("MaCongtrinh",typeof(string)));
            foreach (DataRow drNguon in tbNguon.Rows)
            {
                foreach (DataRow drChitieu in tbChitieu.Rows)
                {
                    DataRow drDich = tbDich.NewRow();
                    drDich["tk"] = drNguon["tk"];
                    drDich["tkDich"] = tkDich;
                    drDich["ps"] =Math.Round( double.Parse(drChitieu["ps"].ToString()) * double.Parse(drNguon["Tps"].ToString()) / TongChitieu,0);
                    drDich["MaCongtrinh"] = drChitieu["MaCongtrinh"];
                    if (isMaPhi.Checked) drDich["MaPhi"] = drNguon["MaPhi"];
                    if (isVuviec.Checked) drDich["MaVV"] = drNguon["MaVV"];
                    tbDich.Rows.Add(drDich);
                }

            }
            gridControl3.DataSource = tbDich;
        }

        private void bTaobt_Click(object sender, EventArgs e)
        {
            if (tbDich == null)
            {
                MessageBox.Show("Số liệu phân bổ chưa khởi tạo");
                return;
            }
            string sql = "select mact, mtid,Mtiddt, soct, ngayct, diengiai, makh, tk, tkdu, psno, psco, psnont, pscont, nhomdk, mavv, maphi, ongba, mant, tygia, macongtrinh from bltk where 1=0";
            DataTable bltk = dbData.GetDataTable(sql);
            List<string> fieldName=new List<string>();
            foreach(DataColumn drC in bltk.Columns)
                fieldName.Add(drC.ColumnName);
            bool result = false;
            foreach (DataRow drDich in tbDich.Rows)
            {
                List<string> fieldValue=new List<string>();
                fieldValue.Add("'PBCT'");
                fieldValue.Add("'" + Guid.NewGuid().ToString()+"'");
                fieldValue.Add("'" + Guid.NewGuid().ToString() + "'");
                fieldValue.Add("'PBCT/" + Ngayct2.Month.ToString("00") + "'");
                fieldValue.Add("'" + Ngayct2.ToShortDateString() + "'");
                fieldValue.Add("N'Phân bổ chi phí cho công trình'");
                fieldValue.Add("'CONGTY'");
                fieldValue.Add("'" + drDich["tk"].ToString() + "'");
                fieldValue.Add("'" + drDich["tkDich"].ToString() + "'");
                fieldValue.Add("0");
                fieldValue.Add( (double.Parse(drDich["ps"].ToString())).ToString("##############0.######"));
                fieldValue.Add("0");
                fieldValue.Add((double.Parse(drDich["ps"].ToString())).ToString("##############0.######"));
                fieldValue.Add("'PBCT1'");
                fieldValue.Add((isVuviec.Checked) ? "'" + drDich["mavv"].ToString() + "'" : "null");
                fieldValue.Add((isMaPhi.Checked) ? "'" + drDich["maphi"].ToString() + "'" : "null");
                fieldValue.Add("N'Bút toán phân bổ tự động'");
                fieldValue.Add("'VND'");
                fieldValue.Add("1");
                fieldValue.Add("'" + drDich["MaCongtrinh"].ToString() + "'");
                result= dbData.insertRow("bltk", fieldName, fieldValue);
                //Đối ứng
                fieldValue.Clear();
                fieldValue.Add("'PBCT'");
                fieldValue.Add("'" + Guid.NewGuid().ToString() + "'");
                fieldValue.Add("'" + Guid.NewGuid().ToString() + "'");
                fieldValue.Add("'PBCT/" + Ngayct2.Month.ToString("00") + "'");
                fieldValue.Add("'" + Ngayct2.ToShortDateString() + "'");
                fieldValue.Add("N'Phân bổ chi phí cho công trình'");
                fieldValue.Add("'CONGTY'");
                fieldValue.Add("'" + drDich["tkDich"].ToString() + "'");
                fieldValue.Add("'" + drDich["tk"].ToString() + "'");
                fieldValue.Add((double.Parse(drDich["ps"].ToString())).ToString("##############0.######"));
                fieldValue.Add("0");
                fieldValue.Add((double.Parse(drDich["ps"].ToString())).ToString("##############0.######"));
                fieldValue.Add("0");
                
                fieldValue.Add("'PBCT2'");
                fieldValue.Add((isVuviec.Checked) ? "'" + drDich["mavv"].ToString() + "'" : "null");
                fieldValue.Add((isMaPhi.Checked) ? "'" + drDich["maphi"].ToString() + "'" : "null");
                fieldValue.Add("N'Bút toán phân bổ tự động'");
                fieldValue.Add("'VND'");
                fieldValue.Add("1");
                fieldValue.Add("'" + drDich["MaCongtrinh"].ToString() + "'");
                result = result && dbData.insertRow("bltk", fieldName, fieldValue);
                if (!result) 
                    break;
            }
            if (result)
            {
                //INsert giá trị phân bổ vào bảng lưu trữ
                if (sOption.SelectedIndex == 6 && tbPhanbo != null)
                {
                    string sqlDelete = "delete coPhanboVT where ngayct between '" + Ngayct1.ToShortDateString() + "' and '" + Ngayct2.ToShortDateString() + "'";
                    dbData.UpdateByNonQuery(sqlDelete);
                    string sqlInsert = "insert into coPhanboVT (ngayct,MaSP, MaVT, MaCongtrinh,tk, tkDich, slPb, TienPB) values(";
                    foreach (DataRow drPB in tbPhanbo.Rows)
                    {
                        string sValue = "'" + Ngayct2.ToShortDateString() + "',";
                        sValue += "'" + drPB["MaSP"].ToString() + "',";
                        sValue += "'" + drPB["MaVt"].ToString() + "',";
                        sValue += "'" + drPB["MaCongtrinh"].ToString() + "',";
                        sValue += "'" + drPB["tk"].ToString() + "',";
                        sValue += "'" + tkDich + "',";
                        sValue += drPB["slPb"].ToString() + ",";
                        sValue += drPB["tienPb"].ToString() + ")";
                        dbData.UpdateByNonQuery(sqlInsert + sValue);

                    }
                }
                MessageBox.Show("Hoàn thành");
            }
            else
            {
                MessageBox.Show("Tạo số liệu bị lỗi");
            }
        }

        private void bXoabt_Click(object sender, EventArgs e)
        {
            if (tkNguon == null) return;
            string sql = "delete bltk where mact='PBCT' and (tk like '" + tkNguon + "%' or  tkdu like '" + tkNguon + "') and ngayct between '" + Ngayct1.ToShortDateString() + "' and '" + Ngayct2.ToShortDateString() + "'";

            dbData.UpdateByNonQuery(sql);
            if (sOption.SelectedIndex == 6 )
            {
                string sqlDelete = "delete coPhanboVT where ngayct between '" + Ngayct1.ToShortDateString() + "' and '" + Ngayct2.ToShortDateString() + "'";
                dbData.UpdateByNonQuery(sqlDelete);
            }
            MessageBox.Show("Hoàn thành");
        }
    }
}