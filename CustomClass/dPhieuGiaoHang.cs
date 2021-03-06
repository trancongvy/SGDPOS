using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using System.Collections;
using CDTLib;
using CDTDatabase;
using CDTControl;
namespace CustomClass
{   
    public class dPhieuGiaoHang : CustomClass.CustomData
    {
        public FormAction FAction;
        
        public DataTable dmKH;
        public DataTable dmXe;
        public DataTable dmVT;
        public DataTable dmDVT;
        
        public dPhieuGiaoHang()
        {
            getStruct();
            getData4Rep();
            _Condition = " DBO.DATEFORMAT(ngayct)=DBO.DATEFORMAT('" + Config.GetValue("NgayHethong").ToString() + "')";
            getdata();
        }

        private void getStruct()
        {

            string sql = "select * from systable where TableName='MT81' and syspackageid=" + Config.GetValue("sysPackageID").ToString() ;
            sql += "; select * from systable where tableName='DT81' and syspackageid=" + Config.GetValue("sysPackageID").ToString();
            sql += ";select * from sysField where systableid in (select systableid from systable where TableName='MT81' and syspackageid=" + Config.GetValue("sysPackageID").ToString() + ")";
            sql += ";select * from sysField where systableid in (    select systableid from systable where TableName='DT81' and syspackageid=" + Config.GetValue("sysPackageID").ToString() + ")";
            dsStr = _dbSt.GetDataSet(sql);
            if(dsStr.Tables[0].Rows.Count==0) return;
                

        }
        
        public DataRow mtCur
        {
            get { return _mtCur; }
            set
            {
                if (value == null) { lstDtCr.RemoveRange(0, lstDtCr.Count); }
                else
                {
                    _mtCur = value;
                    getdtCr();
                }
            }
        }

        private void getdtCr()
        {
            lstDtCr.RemoveRange(0, lstDtCr.Count);
            foreach (DataRow dr in ds.Tables[1].Rows)
            {
                try
                {
                    if (dr["MT81ID"].ToString() == _mtCur["MT81ID"].ToString()) lstDtCr.Add(dr);
                }
                catch { }
            }
        }
        private void getData4Rep()
        {
            string sql = "select [MaXe], [DienGiai], [TaiXe], [MaKH] from dmxe";
            dmXe = _db.GetDataTable(sql);
            dmXe.PrimaryKey = new DataColumn[] { dmXe.Columns["MaXe"] };
            sql = "select [MaKH], [TenKH], [TenKH2], [DiaChi], [DoiTac], [MST], [SDT], [Mobile], [Email], [Fax], [TKNganHang], [NganHang], [HanTinDung], [KHCN] from dmKH";
            dmKH = _db.GetDataTable(sql);
            dmKH.PrimaryKey = new DataColumn[] { dmKH.Columns["MaKH"] };
            sql = "select [MaVT], [TenVT], [TenVT2], [PNo], [MaDVT], [Tonkho], [TKkho], [TKgv], [TKdt], [TonMax], [TonMin], [Nhom], [LoaiVt],  [MaDVT2], [Heso], [GiaBan],  [Phi], [GiaBan2] from dmVT where giaban is not null ";
            dmVT = _db.GetDataTable(sql);
            dmVT.PrimaryKey = new DataColumn[] { dmVT.Columns["MaVT"] };
            sql = "select * from dmDVT";
            dmDVT = _db.GetDataTable(sql);
            dmDVT.PrimaryKey = new DataColumn[] { dmDVT.Columns["MaDVT"] };

        }

        public void getdata()
        {
            DateTime today = DateTime.Parse(_db.GetValue("select getdate()").ToString());
            
            string sql = "select [MT81ID], [MaKH], [MaXe], [OngBa], [TTienH], [TThue], [TPhi], [TTien], [ws], [NgayCt],SoCt from mt81 where " + _Condition + " order by soct desc;";
            sql += sql = "SELECT [DT81ID], [MaVT], [Soluong],[Soluong2],MaDVT,MaDVT2,Heso, [DonGia],[DonGia2], [Ps], [Thue], [Phi], [TienCC], [TienPhi], [Stt], [MT81ID] FROM [DT81] ";
            sql += " where MT81ID in (select MT81ID from mt81 where " + _Condition + ") order by stt";
            ds = _db.GetDataSet(sql);
            mt = ds.Tables[0];
            mt.TableName = "MT";
            mt.PrimaryKey = new DataColumn[] { mt.Columns["MT81ID"] };
            mt.Columns["NgayCT"].DefaultValue = Config.GetValue("NgayHethong");
            mt.Columns["TTienH"].DefaultValue = 0;
            mt.Columns["TThue"].DefaultValue = 0;
            mt.Columns["TPhi"].DefaultValue = 0;
            mt.Columns["TTien"].DefaultValue = 0;
            mt.ColumnChanged += new DataColumnChangeEventHandler(mt_ColumnChanged);
            mt.TableNewRow += new DataTableNewRowEventHandler(mt_TableNewRow);
            //DataRow dr = mt.NewRow();
            //mt.Rows.Add(dr);
            //dr["MT81ID"] = Guid.NewGuid();
            dt = ds.Tables[1];
            dt.TableName = "DT";
            dt.PrimaryKey = new DataColumn[] { dt.Columns["DT81ID"] };
            dt.Columns["ps"].DefaultValue = 0;
            dt.Columns["Thue"].DefaultValue = 0;
            dt.Columns["TienPhi"].DefaultValue = 0;
            dt.Columns["TienCC"].DefaultValue = 0;

            dt.Columns["Heso"].DefaultValue = 1;
            dt.TableNewRow += new DataTableNewRowEventHandler(dt_TableNewRow);
            dt.ColumnChanged += new DataColumnChangeEventHandler(dt_ColumnChanged);
            dt.RowDeleted += new DataRowChangeEventHandler(dt_RowDeleted);
            DataRelation dre = new DataRelation("MT81", mt.Columns["MT81ID"], dt.Columns["MT81ID"]);
            ds.Relations.Clear();
            ds.Relations.Add(dre);
            dsTmp = ds.Copy();

        }

        void mt_TableNewRow(object sender, DataTableNewRowEventArgs e)
        {
            e.Row["MT81ID"] = Guid.NewGuid();
            e.Row["SoCT"] = AutoIncreateSoCt();
            mtCur = e.Row;
            _datachange = true;         
        }

        void dt_TableNewRow(object sender, DataTableNewRowEventArgs e)
            {
            e.Row["DT81ID"] = Guid.NewGuid();
            e.Row["MT81ID"] = _mtCur["MT81ID"];
            //lstDt.Add(e.Row);
            lstDtCr.Add(e.Row);
            _datachange = true;
        }
        void dt_RowDeleted(object sender, DataRowChangeEventArgs e)
        {
            //lstDt.Remove(e.Row);
            if (!lstDtCr.Contains(e.Row))
                lstDtCr.Add(e.Row);

            _datachange = true;
        }
        void mt_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            _datachange = true;
            DataRow ldr;
            DataRow dr = e.Row;
            switch (e.Column.ColumnName.ToLower())
            {
                case "makh":
                    ldr = dmKH.Rows.Find(dr["MaKH"]);
                    if (ldr != null)
                    {
                        dr["OngBa"] = ldr["DoiTac"].ToString();

                    }
                    break;
                case "maxe":
                    ldr = dmXe.Rows.Find(dr["MaXE"]);
                    if (ldr != null)
                    {
                        dr["MaKH"] = ldr["MaKH"].ToString();
                        dr["OngBa"] = ldr["TaiXe"].ToString();

                    }
                    break;

            }
           
        }
        void dt_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            _datachange = true;
            try
            {
                DataRow dr = e.Row;

                switch (e.Column.ColumnName.ToLower())
                {
                    case "mavt":
                        DataRow ldr = dmVT.Rows.Find(dr["MaVT"]);
                        if (ldr != null)
                        {
                            dr["MaDVT2"] = ldr["MaDVT2"];
                            dr["MaDVT"] = ldr["MaDVT"];

                            if (dr["Heso"].ToString() != string.Empty)
                                dr["HeSo"] = ldr["HeSo"];
                            else
                                dr["HeSo"] = 1;
                            dr["Phi"] = ldr["Phi"];
                            dr["DonGia"] = ldr["GiaBan"];
                            dr["DonGia2"] = double.Parse(dr["DonGia"].ToString()) / double.Parse(dr["HeSo"].ToString());
                            if (e.Row.RowState == DataRowState.Detached)
                                dt.Rows.Add(e.Row);
                        }
                        break;
                    case "madvt2":
                        if (dr["MaDVT2"].ToString() == string.Empty || dr["MaDVT2"].ToString() == dr["MaDVT"].ToString())
                        {
                            dr["DonGia2"] = dr["DonGia"];
                            dr["HeSo"] = 1;
                            
                        }
                        else
                        {
                            DataRow ldr1 = dmVT.Rows.Find(dr["MaVT"]);
                            if (ldr1 != null)
                            {
                                if (dr["Heso"].ToString() != string.Empty)
                                {
                                    dr["DonGia2"] = ldr1["GiaBan2"];
                                    dr["HeSo"] = ldr1["HeSo"];                                     
                                }
                                else
                                {
                                    dr["DonGia2"] = ldr1["GiaBan"];
                                    dr["HeSo"] = 1;                                     
                                }
                            }
                        }
                        break;

                    case "heso":
                        if (dr["Heso"].ToString() != string.Empty)
                            if (double.Parse(dr["Heso"].ToString()) != 0)
                            {
                                dr["soluong"] = Math.Round(double.Parse(dr["soluong2"].ToString()) / double.Parse(dr["HeSo"].ToString()), 6);
                                dr["TienCC"] = double.Parse(dr["Soluong2"].ToString()) * double.Parse(dr["DonGia2"].ToString());
                            }
                        break;

                    case "soluong2":
                        if (dr["Heso"].ToString() != string.Empty)
                            if (double.Parse(dr["Heso"].ToString()) != 0)
                            {
                                dr["soluong"] = Math.Round(double.Parse(dr["soluong2"].ToString()) / double.Parse(dr["HeSo"].ToString()), 6);
                                dr["TienCC"] = double.Parse(dr["Soluong2"].ToString()) * double.Parse(dr["DonGia2"].ToString());
                            }
                        break;

                    case "tiencc":
                        if (dr["Soluong2"].ToString() != string.Empty)
                        {
                            if (double.Parse(dr["DonGia"].ToString()) != 0)
                                if (double.Parse(dr["soluong2"].ToString()) != Math.Round(double.Parse(dr["tiencc"].ToString()) / double.Parse(dr["DonGia2"].ToString()), 6))
                                    dr["soluong2"] = Math.Round(double.Parse(dr["tiencc"].ToString()) / double.Parse(dr["DonGia2"].ToString()), 6);
                        }
                        else
                        {
                            dr["soluong2"] = Math.Round(double.Parse(dr["tiencc"].ToString()) / double.Parse(dr["DonGia2"].ToString()), 6);
                        }
                        if (double.Parse(dr["soluong2"].ToString()) != 0)
                        {
                            dr["TienPhi"] = double.Parse(dr["soluong"].ToString()) * double.Parse(dr["Phi"].ToString());
                            dr["ps"] = Math.Round((double.Parse(dr["tiencc"].ToString()) - double.Parse(dr["tienPhi"].ToString())) / 1.1,0);
                            dr["Thue"] = double.Parse(dr["tiencc"].ToString()) - double.Parse(dr["tienPhi"].ToString())-double.Parse(dr["Ps"].ToString());
                            TinhTongTien();
                        }
                        break;
                }
            }
            catch { }
        }

        private void TinhTongTien()
        {
            _datachange = true;
            mtCur["TTienH"] = 0;
            mtCur["TThue"] = 0;
            mtCur["TTien"] = 0;
            mtCur["TPhi"] = 0;

            foreach (DataRow dr in lstDtCr)
            {
                if (dr.RowState != DataRowState.Deleted)
                {
                    mtCur["TTienH"] = double.Parse(mtCur["TTienH"].ToString()) + double.Parse(dr["Ps"].ToString());
                    mtCur["TThue"] = double.Parse(mtCur["TThue"].ToString()) + double.Parse(dr["thue"].ToString());
                    mtCur["TTien"] = double.Parse(mtCur["TTien"].ToString()) + double.Parse(dr["TienCC"].ToString());
                    mtCur["TPhi"] = double.Parse(mtCur["TPhi"].ToString()) + double.Parse(dr["TienPhi"].ToString());
                }
            }
            mtCur.EndEdit();
        }
        
        
        //---Tao tac tren form
        // tra lai  neu Cancel
        public void CheckRule()
        {
            //Check Data
            //Master
            
            foreach (DataRow drField in dsStr.Tables[2].Rows)
            {
                string fieldName = drField["FieldName"].ToString();
                int pType = Int32.Parse(drField["Type"].ToString());
                if (pType == 3 || pType == 6)
                    continue;
                string fieldValue = _mtCur[fieldName].ToString();
                //Check null
                if (!Boolean.Parse(drField["AllowNull"].ToString()))
                {
                    if (fieldValue == string.Empty)
                        _mtCur.SetColumnError(fieldName, "Phải nhập");
                    else
                        _mtCur.SetColumnError(fieldName, string.Empty);
                }
                if (fieldValue == string.Empty)
                    continue;
                //Check Duy nhất
                if (Boolean.Parse(drField["IsUnique"].ToString()))
                {
                    string sql="select " + fieldName + " from mt81 where " + fieldName + " = '" + fieldValue + "'";
                    if(FAction==FormAction.Edit)
                    {
                        sql += " and mt81id<>'" + _mtCur["Mt81ID"].ToString() + "'";
                    }
                    DataTable dtData = _db.GetDataTable(sql);
                    if (dtData != null && dtData.Rows.Count > 0)
                    {
                        _mtCur.SetColumnError(fieldName, "Giá trị đã bị trùng");
                    }
                }
            }
             //Detail
            foreach (DataRow _drdt in lstDtCr)
            {
                if (_drdt.RowState != DataRowState.Deleted)
                {
                    foreach (DataRow drField in dsStr.Tables[3].Rows)
                    {
                        string fieldName = drField["FieldName"].ToString();
                        int pType = Int32.Parse(drField["Type"].ToString());
                        if (pType == 3 || pType == 6)
                            continue;
                        string fieldValue = _drdt[fieldName].ToString();
                        //Check null
                        if (!Boolean.Parse(drField["AllowNull"].ToString()))
                        {
                            if (fieldValue == string.Empty)
                                _drdt.SetColumnError(fieldName, "Phải nhập");
                            else
                                _drdt.SetColumnError(fieldName, string.Empty);
                        }
                    }
                }
            }
            //Check Công nợ         để sau khi update xong rồi mới checkc

        }
        public void CancelUpdate()
        {
            ds.RejectChanges();
            _datachange = false;
        }
        //Update data
        public bool UpdateData()
        {
            if(_datachange == false) return true;
            string sql;
            List<string> paraNames = new List<string>();
            List<object> paraValues = new List<object>();
            List<SqlDbType> paraTypes = new List<SqlDbType>();
            List<string> paraNamesdt = new List<string>();
            List<object> paraValuesdt = new List<object>();
            List<SqlDbType> paraTypesdt = new List<SqlDbType>();
            bool succ;
            paraNames.AddRange(new string[] { "mt81id", "ngayct", "soct", "maxe", "makh", "ongba", "TTienH", "TThue", "TPhi", "TTien", "ws" });
            paraValues.AddRange(new object[] { mtCur["mt81id"], mtCur["ngayct"], mtCur["soct"], mtCur["maxe"], mtCur["makh"], mtCur["ongba"], mtCur["TTienH"], mtCur["TThue"], mtCur["TPhi"], mtCur["TTien"], Config.GetValue("sysUserID") });
            paraTypes.AddRange(new SqlDbType[] { SqlDbType.UniqueIdentifier, SqlDbType.DateTime, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.Decimal, SqlDbType.Decimal, SqlDbType.Decimal, SqlDbType.Decimal, SqlDbType.NVarChar });

            paraNamesdt.AddRange(new string[] { "DT81ID", "MaVT", "Soluong", "DonGia", "Ps", "Thue", "Phi", "TienCC", "TienPhi", "MT81ID", "Soluong2", "MaDVT", "MaDVT2", "Heso", "DonGia2" });
            paraTypesdt.AddRange(new SqlDbType[] { SqlDbType.UniqueIdentifier, SqlDbType.VarChar, SqlDbType.Decimal, SqlDbType.Decimal, SqlDbType.Decimal, SqlDbType.Decimal, SqlDbType.Decimal, SqlDbType.Decimal, SqlDbType.Decimal,
                                                                        SqlDbType.UniqueIdentifier,SqlDbType.Decimal,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.Decimal,SqlDbType.Decimal });
            _db.BeginMultiTrans();
            if (FAction == FormAction.New)
            {
                sql = "insert into mt81(mt81id, ngayct, soct, maxe, makh, ongba,TTienH, TThue, TPhi, TTien,ws) values (";
                sql += "@mt81id, @ngayct, @soct, @maxe, @makh, @ongba,@TTienH, @TThue, @TPhi, @TTien,@ws)";
                succ = _db.UpdateData(sql, paraNames.ToArray(), paraValues.ToArray(), paraTypes.ToArray());
                if (_db.HasErrors)
                {
                    _db.RollbackMultiTrans();
                    return false;
                }

                sql = "INSERT INTO DT81(DT81ID, MaVT, Soluong, DonGia, Ps, Thue, Phi, TienCC, TienPhi,  MT81ID, Soluong2, MaDVT, MaDVT2, Heso, DonGia2) values(";
                sql += "@DT81ID,@MaVT, @Soluong, @DonGia, @Ps, @Thue, @Phi, @TienCC, @TienPhi,  @MT81ID, @Soluong2, @MaDVT, @MaDVT2, @Heso, @DonGia2)";
                foreach (DataRow dr in lstDtCr)
                {
                    paraValuesdt.Clear();
                    paraValuesdt.AddRange(new object[] { dr["DT81ID"], dr["MaVT"], dr["Soluong"], dr["DonGia"], dr["Ps"], dr["Thue"], dr["Phi"], dr["TienCC"], dr["TienPhi"], dr["MT81ID"], dr["Soluong2"], dr["MaDVT"], dr["MaDVT2"], dr["Heso"], dr["DonGia2"] });
                    succ = succ && _db.UpdateData(sql, paraNamesdt.ToArray(), paraValuesdt.ToArray(), paraTypesdt.ToArray());
                    if (_db.HasErrors)
                    {
                        _db.RollbackMultiTrans();
                        return false;
                    }
                    
                }
                if (succ)
                {
                    if (checkCongno())
                    {
                        _db.EndMultiTrans();
                    }
                    else
                    {
                        _db.RollbackMultiTrans();
                        return false;
                    }

                }

                _AutoCreate.UpdateNewStruct(mtCur);
            }
            else if(FAction==FormAction.Edit)
            {                
                sql = "update  mt81 set  ngayct=@ngayct, soct=@soct, maxe=@maxe, makh=@makh, ongba=@ongba,";
                sql += " TTienH=@TTienH, TThue=@TThue, TPhi=@TPhi, TTien=@TTien,ws=@ws where mt81id =@mt81id";
                succ = _db.UpdateData(sql, paraNames.ToArray(), paraValues.ToArray(), paraTypes.ToArray());
                if (_db.HasErrors)
                {
                    _db.RollbackMultiTrans();
                    return false;
                }
                foreach (DataRow dr in lstDtCr)
                {
                    switch (dr.RowState)
                    {
                        case DataRowState.Added:
                            sql = "INSERT INTO DT81(DT81ID, MaVT, Soluong, DonGia, Ps, Thue, Phi, TienCC, TienPhi,  MT81ID, Soluong2, MaDVT, MaDVT2, Heso, DonGia2) values(";
                            sql += "@DT81ID,@MaVT, @Soluong, @DonGia, @Ps, @Thue, @Phi, @TienCC, @TienPhi,  @MT81ID, @Soluong2, @MaDVT, @MaDVT2, @Heso, @DonGia2)";
                            paraValuesdt.Clear();
                            paraValuesdt.AddRange(new object[] { dr["DT81ID"], dr["MaVT"], dr["Soluong"], dr["DonGia"], dr["Ps"], dr["Thue"], dr["Phi"], dr["TienCC"], dr["TienPhi"], dr["MT81ID"], dr["Soluong2"], dr["MaDVT"], dr["MaDVT2"], dr["Heso"], dr["DonGia2"] });
                            succ = succ && _db.UpdateData(sql, paraNamesdt.ToArray(), paraValuesdt.ToArray(), paraTypesdt.ToArray());
                            break;
                        case DataRowState.Modified:
                            sql = "update DT81 set MaVT=@MaVT, Soluong=@Soluong, DonGia= @DonGia, Ps=@Ps, Thue=@Thue, Phi=@Phi, TienCC=@TienCC, TienPhi=@TienPhi,   Soluong2=@Soluong2, MaDVT=@MaDVT, MaDVT2=@MaDVT2, Heso=@Heso, DonGia2=@DonGia2";
                            sql += " where DT81ID=@DT81ID  ";
                            paraValuesdt.Clear();
                            paraValuesdt.AddRange(new object[] { dr["DT81ID"], dr["MaVT"], dr["Soluong"], dr["DonGia"], dr["Ps"], dr["Thue"], dr["Phi"], dr["TienCC"], dr["TienPhi"], dr["MT81ID"], dr["Soluong2"], dr["MaDVT"], dr["MaDVT2"], dr["Heso"], dr["DonGia2"] });
                            succ = succ && _db.UpdateData(sql, paraNamesdt.ToArray(), paraValuesdt.ToArray(), paraTypesdt.ToArray());
                            break;
                        case DataRowState.Deleted:
                            dr.RejectChanges();
                            sql = "delete dt81 where dt81id='" + dr["DT81ID"].ToString() + "'";
                            succ = succ && _db.UpdateByNonQuery(sql);
                            dt.Rows.Remove(dr);
                            break;
                    }
                    if (_db.HasErrors)
                    {
                        _db.RollbackMultiTrans();
                        return false;
                    }
                }
                if (_db.HasErrors)
                {
                    _db.RollbackMultiTrans();
                    return false;
                }
                else
                {
                    if (checkCongno())
                    {
                        _db.EndMultiTrans();
                    }else
                    {
                        _db.RollbackMultiTrans();
                        return false;
                    }
                }
            }

            _datachange = false;             
            ds.AcceptChanges();
            dsTmp = ds.Copy();
            return true;
        }

        private bool checkCongno()
        {
            double o = _db.GetValueByStore("CheckCongno", new string[] { "@ngayct", "@Makh", "@checksl", "@kq" }, new object[] { mtCur["NgayCT"], mtCur["MaKH"], 1, 0 }, new ParameterDirection[] { ParameterDirection.Input, ParameterDirection.Input, ParameterDirection.Input, ParameterDirection.Output },3);
            if (o == 1)
                return true;
            else
                return false;
        
        }
        public bool DeleteData(DataRow dataRow)
        {
            string sql = "delete dt81 where mt81ID='" + dataRow["Mt81id"].ToString() + "'";
            bool suc = _db.UpdateByNonQuery(sql);
            sql = "delete mt81 where mt81ID='" + dataRow["Mt81id"].ToString() + "'";
            suc = suc && _db.UpdateByNonQuery(sql);
            return suc;
            _datachange = false;
        }
    }
}

