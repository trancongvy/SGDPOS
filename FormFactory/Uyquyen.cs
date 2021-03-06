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
namespace FormFactory
{
    public partial class Uyquyen : DevExpress.XtraEditors.XtraForm
    {
        private Database _dbData = Database.NewDataDatabase();
        protected Database _dbStruct = Database.NewStructDatabase();
        private DataTable tbUser;
        private DataTable tbUyQuyen;
        int id;
        private BindingSource bs=new BindingSource();
        public Uyquyen(int sysTableID)
        {
            id = sysTableID;
            InitializeComponent();
            this.KeyPreview = true;
            string sql = "select sysUserID,UserName from sysUser";
            tbUser = _dbStruct.GetDataTable(sql);
            repositoryItemGridLookUpEdit1.DataSource = tbUser;
            sql = "select * from sysUyquyen where sysTableID=" + sysTableID.ToString();
            tbUyQuyen = _dbStruct.GetDataTable(sql);
            bs.DataSource = tbUyQuyen;
            gridControl1.DataSource = bs;
            gridControl1.DataMember = tbUyQuyen.TableName;
            gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            repositoryItemGridLookUpEdit1.ValueMember = "sysUserID";
            repositoryItemGridLookUpEdit1.DisplayMember = "UserName";
            gridControl1.KeyUp += new KeyEventHandler(gridControl1_KeyUp);
        }

        void gridControl1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F8)
            {
                bs.RemoveCurrent();
            }
        }

        private void Uyquyen_Load(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string sql = "delete sysUyquyen where sysTableID=" + id.ToString();
            _dbStruct.UpdateByNonQuery(sql);
            foreach(DataRow dr in tbUyQuyen.Rows)
            {
                if (dr.RowState == DataRowState.Deleted) continue;
                sql = " insert into sysUyQuyen(systableid, sysUserid) values(" + id + "," + dr["sysUserID"].ToString() + ")";
                _dbStruct.UpdateByNonQuery(sql);
            }
            MessageBox.Show("Cập nhật thành công");
            this.Dispose();
        }
    }
}