using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CDTLib;
using CDTControl;

namespace CusData
{
    public class DataMasterDetail : CDTData
    {
        public DataMasterDetail(string sysTableID)
        {
            this._dataType = DataType.MasterDetail;
            this.GetInfor(sysTableID);
            this.GetStruct();
            this._formulaCaculator = new FormulaCaculator(_dataType, _dsStruct);
            this._customize = new Customize(_dataType, DbData, _drTable, _drTableMaster);
        }

        public DataMasterDetail(string TableName, string sysPackageID)
        {
            this._dataType = DataType.MasterDetail;
            this.GetInfor(TableName, sysPackageID);
            this.GetStruct();
            this._formulaCaculator = new FormulaCaculator(_dataType, _dsStruct);
            this._customize = new Customize(_dataType, DbData, _drTable, _drTableMaster);
        }

        public DataMasterDetail(DataRow drTable)
        {
            this._dataType = DataType.MasterDetail;
            this.GetInfor(drTable);
            this.GetStruct();
            this._formulaCaculator = new FormulaCaculator(_dataType, _dsStruct);
            this._customize = new Customize(_dataType, DbData, _drTable, _drTableMaster);
        }

        private void GetInforForMaster()
        {
            string mtTableName = this._drTable["MasterTable"].ToString();
            string sysPackageID = Config.GetValue("sysPackageID").ToString();
            DataTable dt = _dbStruct.GetDataTable("select * from sysTable t, sysUserTable ut where t.sysTableID *= ut.sysTableID and t.TableName = '" + mtTableName + "' and t.sysPackageID = " + sysPackageID);
            if (dt != null && dt.Rows.Count > 0)
            {
                this._drTableMaster = dt.Rows[0];
                DbData.MasterPk = _drTableMaster["Pk"].ToString();
            }
            else
            {   //trường hợp dữ liệu nằm ở CDT
                dt = _dbStruct.GetDataTable("select * from sysTable t, sysUserTable ut where t.sysTableID *= ut.sysTableID and t.TableName = '" + mtTableName + "' and t.sysPackageID = 5");
                if (dt != null && dt.Rows.Count > 0)
                {
                    this._drTableMaster = dt.Rows[0];
                    DbData.MasterPk = _drTableMaster["Pk"].ToString();
                }
            }
        }

        public override void GetInfor(string sysTableID)
        {
            base.GetInfor(sysTableID);
            DbData.DetailPk = _drTable["Pk"].ToString();
            GetInforForMaster();
        }

        public override void GetInfor(DataRow drTable)
        {
            base.GetInfor(drTable);
            DbData.DetailPk = _drTable["Pk"].ToString();
            GetInforForMaster();

        }

        public override void GetInfor(string TableName, string sysPackageID)
        {
            base.GetInfor(TableName, sysPackageID);
            DbData.DetailPk = _drTable["Pk"].ToString();
            GetInforForMaster();
        }

        public override void GetStruct()
        {
            string sysTableID = _drTableMaster["SysTableID"].ToString();
            string queryString = "select * from sysField f, sysUserField uf where f.sysFieldID *= uf.sysFieldID " +
                " and f.sysTableID = " + sysTableID + " order by TabIndex";
            DataTable dtStruct = _dbStruct.GetDataTable(queryString);
            if (dtStruct != null)
                _dsStruct.Tables.Add(dtStruct);
            base.GetStruct();
        }

        public override void CheckRules(DataAction dataAction)
        {
            base.CheckRules(dataAction);
            
            foreach (DataRow drField in _dsStruct.Tables[1].Rows)
            {
                if (!Boolean.Parse(drField["Visible"].ToString()))
                    continue;
                string fieldName = drField["FieldName"].ToString();
                int pType = Int32.Parse(drField["Type"].ToString());
                if (pType == 3 || pType == 6)
                    continue;
                foreach (DataRow drData in _lstDrCurrentDetails)
                {
                    if (drData.RowState == DataRowState.Deleted || drData.RowState == DataRowState.Detached)
                        continue;
                    string fieldValue = drData[fieldName].ToString();
                    if (!Boolean.Parse(drField["AllowNull"].ToString()))
                    {
                        if (fieldValue == string.Empty)
                            drData.SetColumnError(fieldName, "Phải nhập");
                        else
                            drData.SetColumnError(fieldName, string.Empty);
                    }
                    if (fieldValue == string.Empty)
                        continue;
                    if (Boolean.Parse(drField["IsUnique"].ToString()))
                    {
                        string tableName = _drTable["TableName"].ToString();
                        string pk = _drTable["Pk"].ToString();
                        string pkValue = drData[pk].ToString();
                        if (IsUnique(dataAction, fieldValue, fieldName, tableName, pk, pkValue))
                        {
                            _drCurrentMaster.SetColumnError(fieldName, string.Empty);
                        }
                        else
                        {
                            _drCurrentMaster.SetColumnError(fieldName, "Đã có số liệu trùng");
                        }
                    }
                    int value = 0;
                    if (!Int32.TryParse(drData[fieldName].ToString(), out value))
                        continue;
                    if (drField["MinValue"].ToString() != string.Empty)
                    {
                        int minValue = Int32.Parse(drField["MinValue"].ToString());
                        if (minValue > value)
                        {
                            drData.SetColumnError(fieldName, "Phải lớn hơn hoặc bằng " + minValue.ToString());
                            continue;
                        }
                        else
                            drData.SetColumnError(fieldName, string.Empty);
                    }
                    if (drField["MaxValue"].ToString() != string.Empty)
                    {
                        int maxValue = Int32.Parse(drField["MaxValue"].ToString());
                        if (maxValue < value)
                            drData.SetColumnError(fieldName, "Phải nhỏ hơn hoặc bằng " + maxValue.ToString());
                        else
                            drData.SetColumnError(fieldName, string.Empty);
                    }
                }
            }
        }

        private void GetQuery(ref string queryMain, ref string queryDetail)
        {
            string mtTableName = this._drTableMaster["TableName"].ToString();
            string dtTableName = this._drTable["TableName"].ToString();
            string mtSortOrder = this._drTableMaster["SortOrder"].ToString();
            string dtSortOrder = this._drTable["SortOrder"].ToString();
            string maCT = this._drTable["MaCT"].ToString();
            string mtPk = this._drTableMaster["Pk"].ToString();
            string dtPk = this._drTable["Pk"].ToString();
            string extrasql = string.Empty;
            if (_drTable.Table.Columns.Contains("Extrasql"))
            {
                if (_drTable["Extrasql"] != null)
                {
                    extrasql = _drTable["Extrasql"].ToString();
                }

            }
            string extraWs = string.Empty;
            if (_drTableMaster["sysUserID"] != null)
            {
                string adminList = _drTableMaster["sysUserID"].ToString().Trim();
                if (adminList != string.Empty)
                {
                    if (adminList != Config.GetValue("sysUserID").ToString().Trim())
                    {
                        extraWs = " ltrim(ws)= '" + Config.GetValue("sysUserID").ToString().Trim() + "'";
                    }
                    else
                    { extraWs = "1=1"; }
                }
                else
                {
                    extraWs = "1=1";
                }
            }
            if (maCT != string.Empty && mtSortOrder != string.Empty && !mtSortOrder.ToUpper().Contains("DESC"))
            {
                mtSortOrder = mtSortOrder.Replace(",", " desc ,");
                mtSortOrder += " desc";
            }
            queryMain = "select * from " + mtTableName;
            queryMain += " where " + extraWs;
            if (extrasql != string.Empty)
                queryMain += " and " + extrasql;
            
            queryDetail = "select * from " + dtTableName;
            if (this._conditionMaster == string.Empty && this._condition == string.Empty)   //truong hop mac dinh
            {
                if (maCT == string.Empty)
                {                    
                    if (mtSortOrder != string.Empty)
                        queryMain += " order by " + mtSortOrder;

                }
                else
                {
                    int rowCount = 30;
                    object oRowCount = Config.GetValue("RowCount");
                    if (oRowCount != null)
                        rowCount = Int32.Parse(oRowCount.ToString());
                    queryMain = "select top " + rowCount.ToString() + " * from " + mtTableName;
                    //Thêm vào điều kiện ws
                    queryMain += " where " + extraWs;
                    if (extrasql != string.Empty)
                        queryMain += " and " + extrasql;
                                       
                    if (mtSortOrder != string.Empty)
                        queryMain += " order by " + mtSortOrder;
                    else
                        queryMain += " order by " + mtPk + " desc";
                    string subQuery = queryMain.Replace("*", mtPk);
                    queryDetail += " where " + mtPk + " in (" + subQuery + ")";
                    
                }
                if (dtSortOrder != string.Empty)
                    queryDetail += " order by " + dtSortOrder;
            }
            if (this._conditionMaster != string.Empty)  //truong hop tim kiem theo bang master
            {
                queryMain += " and " + this._conditionMaster;

                string subQuery = queryMain.Replace("*", mtPk);
                queryDetail += " where " + mtPk + " in (" + subQuery + ")";
                if (mtSortOrder != string.Empty)
                    queryMain += " order by " + mtSortOrder;
                if (dtSortOrder != string.Empty)
                    queryDetail += " order by " + dtSortOrder;
            }
            if (this._condition != string.Empty)    //truong hop tim kiem theo bang detail
            {
                string subQuery = queryDetail + " where " + this._condition;
                subQuery = subQuery.Replace("*", mtPk);
                queryMain += " and " + mtPk + " in (" + subQuery + ")";
                queryDetail += " where " + mtPk + " in (" + queryMain.Replace("*", mtPk) + ")";
                if (mtSortOrder != string.Empty)
                    queryMain += " order by " + mtSortOrder;
                if (dtSortOrder != string.Empty)
                    queryDetail += " order by " + dtSortOrder;
            }
        }

        public override void GetData()
        {
            ConditionForPackage();
            string query = string.Empty, queryMaster = string.Empty;
            this.GetQuery(ref queryMaster, ref query);
            DsData = DbData.GetDataSetMasterDetail(queryMaster, query);

            if (DsData == null)
                return;
            string fkName = _drTableMaster["Pk"].ToString();
            DataColumn pk = DsData.Tables[0].Columns[fkName];
            DataColumn fk = DsData.Tables[1].Columns[fkName];
            if (pk != null && fk != null)
            {
                DataRelation dr = new DataRelation(_drTable["TableName"].ToString(), pk, fk, true);
                DsData.Relations.Add(dr);
            }

            _dsDataTmp = DsData.Copy();
        }

        private bool UpdateDetail()
        {
            if (_sInsertDetail == string.Empty)
                GenSqlString();
            bool success = false;
            foreach (DataRow drDetail in _lstDrCurrentDetails)
            {
                List<SqlField> tmp = new List<SqlField>();
                List<string> paraNames = new List<string>();
                List<object> paraValues = new List<object>();
                List<SqlDbType> paraTypes = new List<SqlDbType>(); 
                string sql = string.Empty;
                bool isDeleteDt = false, isDelete = false, updateIdentity = false;
                success = false;
                switch (drDetail.RowState)
                {
                    case DataRowState.Added:
                        if (_identityPkDt)
                            updateIdentity = true;
                        if (_identityPk)
                        {
                            string pk = _drTableMaster["Pk"].ToString();
                            if (drDetail.Table.Columns.Contains(pk))
                                drDetail[pk] = _drCurrentMaster[pk];
                        }
                        tmp = _vInsertDetail;
                        sql = _sInsertDetail;
                        break;
                    case DataRowState.Modified:
                        tmp = _vUpdateDetail;
                        sql = _sUpdateDetail;
                        break;
                    case DataRowState.Deleted:
                        tmp = _vDeleteDetail;
                        sql = _sDeleteDetail;
                        if (_drCurrentMaster.RowState == DataRowState.Deleted)
                        {
                            isDelete = true;
                            _drCurrentMaster.RejectChanges();
                        }
                        drDetail.RejectChanges();
                        isDeleteDt = true;
                        break;
                }
                if (sql != string.Empty)
                {
                    foreach (SqlField sqlField in tmp)
                    {
                        string fieldName = sqlField.FieldName;
                        paraNames.Add(fieldName);
                        if (drDetail[fieldName].ToString() != string.Empty)
                            paraValues.Add(drDetail[fieldName]);
                        else
                            paraValues.Add(DBNull.Value);
                        paraTypes.Add(sqlField.DbType);
                    }
                    if (isDelete)
                        _drCurrentMaster.Delete();
                    if (isDeleteDt)
                        drDetail.Delete();
                    success = DbData.UpdateData(sql, paraNames.ToArray(), paraValues.ToArray(), paraTypes.ToArray());
                    if (success && updateIdentity)
                    {
                        string pk = _drTable["Pk"].ToString();
                        object o = DbData.GetValue("select @@identity");
                        if (o != null)
                            drDetail[pk] = o;
                    }
                    if (!success)
                        break;
                }
                else
                    success = true;
            }
            return success;
        }


        public override bool UpdateData(DataAction dataAction)
        {
            if (!_dataChanged)
                return true;
            DbData.BeginMultiTrans();
            int index = DsData.Tables[0].Rows.IndexOf(_drCurrentMaster);
            if (index == -1) return false;
            if (!_customize.BeforeUpdate(index, DsData))
            {
                DbData.RollbackMultiTrans();
                return false;
            }

            DataRow[] arrDrCurrentDetails = new DataRow[_lstDrCurrentDetails.Count];
            _lstDrCurrentDetails.CopyTo(arrDrCurrentDetails);
            bool isNew = _drCurrentMaster.RowState == DataRowState.Added;
            if ((dataAction != DataAction.Delete && Update(_drCurrentMaster) && UpdateDetail())
                || (dataAction == DataAction.Delete && UpdateDetail() && Update(_drCurrentMaster)))
            {
                TransferData(dataAction, index);
                _customize.AfterUpdate();
            }
            bool isError = DbData.HasErrors;
            if (!isError)
                DbData.EndMultiTrans();
            else
                DbData.RollbackMultiTrans();

            if (isNew && !isError)
                _autoIncreValues.UpdateNewStruct(_drCurrentMaster);
            if (!isError)
            {
                base.InsertHistory(dataAction, DsData);
                DsData.AcceptChanges();
                _dsDataTmp = DsData.Copy();
            }
            return (!isError);
        }

        private void CreatePrintVoucher()
        {
            string mtTableID = this._drTableMaster["sysTableID"].ToString();
            string dtTableID = this._drTable["sysTableID"].ToString();
            this._printData = new DataMasterDetailPrint(mtTableID, dtTableID);
        }

        public override DataTable GetDataForPrint(int index)
        {
            string pk = _drTableMaster["Pk"].ToString();
            string dataID = DsData.Tables[0].Rows[index][pk].ToString();
            if (_printData == null)
                CreatePrintVoucher();
            return (_printData.GetData(dataID));
        }
        public DataTable  GetReportFile(string TableIDid)
        {
            string sql = "select RDes, RFile from sysReportFile where sysTableID=" + TableIDid + " order by stt";
            DataTable tbMau = _dbStruct.GetDataTable(sql);
            return tbMau;
        }
    }
}
