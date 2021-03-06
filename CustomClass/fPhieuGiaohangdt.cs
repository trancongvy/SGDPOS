using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CDTLib;
using DevExpress.XtraGrid;

namespace CustomClass
{
    public partial class fPhieuGiaohangdt : DevExpress.XtraEditors.XtraForm
    {
        public fPhieuGiaohangdt( BindingSource _bs,dPhieuGiaoHang _d)
        {
            InitializeComponent();
            _db = _d;
            bs = _bs;
            this.gridControl1.DataSource = bs;
        }

        public dPhieuGiaoHang _db;
        BindingSource bs;
        private void fPhieuGiaohang_Load(object sender, EventArgs e)
        {

            
            if(_db.FAction==FormAction.New) bs.MoveLast();
            this.gridControl1.DataMember = _db.ds.Relations[0].RelationName;
            this.repositoryItemGridLookUpEdit1.DataSource = _db.dmVT;
            this.repositoryItemGridLookUpEdit2.DataSource = _db.dmDVT;
            BindingData();
            dxErrorProvider1.DataSource = bs;
            cMaXe.LostFocus += new EventHandler(cMaXe_LostFocus);
            cMaKH.LostFocus+=new EventHandler(cMaXe_LostFocus);
            cOngBa.Leave += new EventHandler(cOngBa_Leave);
            this.KeyDown += new KeyEventHandler(fPhieuGiaohangdt_KeyDown);
            this.gridControl1.KeyDown += new KeyEventHandler(gridControl1_KeyDown);
        }

        void gridControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                GridControl gcMain = sender as GridControl;
                DevExpress.XtraGrid.Views.Grid.GridView gvMain = gridControl1.Views[0] as DevExpress.XtraGrid.Views.Grid.GridView;
                gvMain.DeleteSelectedRows();
            }
        }



        void cOngBa_Leave(object sender, EventArgs e)
        {
            gridControl1.Focus();
        }
        void cMaXe_LostFocus(object sender, EventArgs e)
        {
            bs.EndEdit();
        }
        private void BindingData()
        {
            //_db.mt.TableName = "MT";

            if (this.cNgay.DataBindings.Count==0)
            {
                cNgay.DataBindings.Add(new Binding("EditValue", bs, "NgayCT", true, DataSourceUpdateMode.OnValidation));
                cMaXe.DataBindings.Add(new Binding("EditValue", bs, "MaXe", true, DataSourceUpdateMode.OnValidation));
                cMaKH.DataBindings.Add(new Binding("EditValue", bs, "MaKH", true, DataSourceUpdateMode.OnValidation));
                cTenKH.DataBindings.Add(new Binding("EditValue", bs, "MaKH", true, DataSourceUpdateMode.OnValidation));
                cOngBa.DataBindings.Add(new Binding("Text", bs, "OngBa", true, DataSourceUpdateMode.OnValidation));

                cTTienH.DataBindings.Add(new Binding("Value", bs, "TTienH", true, DataSourceUpdateMode.OnValidation));
                cTTienCC.DataBindings.Add(new Binding("Value", bs, "TTien", true, DataSourceUpdateMode.OnValidation));
                cTThue.DataBindings.Add(new Binding("EditValue", bs, "TThue", true, DataSourceUpdateMode.OnValidation));
                cTPhi.DataBindings.Add(new Binding("EditValue", bs, "TPhi", true, DataSourceUpdateMode.OnValidation));
                cSoct.DataBindings.Add(new Binding("Text", bs, "SoCt", true, DataSourceUpdateMode.OnValidation));
                cMaXe.Properties.DataSource = _db.dmXe;
                cMaXe.Properties.View.BestFitColumns();
                cMaKH.Properties.DataSource = _db.dmKH;
                cMaKH.Properties.View.BestFitColumns();
                cTenKH.Properties.DataSource = _db.dmKH;
                cTenKH.Properties.View.BestFitColumns();
            }
        }
        private void btSave_Click(object sender, EventArgs e)
        {
            this.cNgay.Focus();
            this.UpdateData();
            
        }
        private void Cancel()
        {
            _db.CancelUpdate();
            bs.ResetBindings(false);
            bs.DataSource = _db.ds;
            this.DialogResult = DialogResult.Cancel;
        }
        private void UpdateData()
        {
            bs.EndEdit();
            _db.CheckRule();
            if (!dxErrorProvider1.HasErrors && !_db.dt.HasErrors)
            {
                if (_db.UpdateData())
                    this.DialogResult = DialogResult.OK;
                else
                {
                    MessageBox.Show("Kiểm tra lại Hạn mức công nợ");
                }
            }
            
        }

        void fPhieuGiaohangdt_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F12:
                    this.UpdateData();
                    break;
                case Keys.Escape:
                    this.Cancel();

                    break;

            }

        }
       
    }
}
