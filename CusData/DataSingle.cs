using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CDTDatabase;

using CDTControl;
using CDTLib;

namespace CusData
{
    public class DataSingle : CDTData
    {
        public string extraWS = string.Empty;
        public string WS = string.Empty;
        public DataSingle(string sysTableID)
        {
            this._dataType = DataType.Single;
            this.GetInfor(sysTableID);
            this.GetStruct();
            this._formulaCaculator = new FormulaCaculator(_dataType, _dsStruct);
            this._customize = new Customize(_dataType, DbData, _drTable, _drTableMaster);
        }

        public DataSingle(string TableName, string sysPackageID)
        {
            this._dataType = DataType.Single;
            this.GetInfor(TableName, sysPackageID);
            this.GetStruct();
            this._formulaCaculator = new FormulaCaculator(_dataType, _dsStruct);
            this._customize = new Customize(_dataType, DbData, _drTable, _drTableMaster);
        }

        public DataSingle(DataRow drTable)
        {
            this._dataType = DataType.Single;
            this.GetInfor(drTable);
            this.GetStruct();
            this._formulaCaculator = new FormulaCaculator(_dataType, _dsStruct);
            this._customize = new Customize(_dataType, DbData, _drTable, _drTableMaster);
        }

        public override void GetInfor(string sysTableID)
        {
            base.GetInfor(sysTableID);
            DbData.MasterPk = _drTable["Pk"].ToString();
            this.DbData.QueryMaster = "select * from " + _drTable["TableName"].ToString();
        }

        public override void GetInfor(string TableName, string sysPackageID)
        {
            base.GetInfor(TableName, sysPackageID);
            DbData.MasterPk = _drTable["Pk"].ToString();
            this.DbData.QueryMaster = "select * from " + _drTable["TableName"].ToString();
        }

        public override void GetInfor(DataRow drTable)
        {
            base.GetInfor(drTable);
            DbData.MasterPk = _drTable["Pk"].ToString();
            this.DbData.QueryMaster = "select * from " + _drTable["TableName"].ToString();
        }

        public override void GetData()
        {
            ConditionForPackage();
            string extrasql = string.Empty;
            //xét trường hợp phân toàn quyền 
            //
            string extraWs = string.Empty;
            if (DrTable["sysUserID"] != null)
            {
                string adminList = DrTable["sysUserID"].ToString().Trim();
                if (adminList != string.Empty)
                {
                    if (adminList != Config.GetValue("sysUserID").ToString().Trim())
                    {
                        string dk = NotAdminListCondition();
                        extraWs = " charindex('" + Config.GetValue("sysUserID").ToString().Trim() + "_',ws)>0";
                        if (dk != string.Empty)
                            extraWs += " or " + dk;
                        extraWS = dk;
                    }
                }
            }
            //
            if (_drTable.Table.Columns.Contains("ExtraSql"))
                if (_drTable["ExtraSql"] != null)
                    extrasql = _drTable["Extrasql"].ToString();

            if (extraWs != string.Empty)
            {
                if (extrasql == string.Empty)
                {
                    extrasql = extraWs;
                }
                else
                {
                    extrasql += " and " + extraWs;
                }
            }

            string queryData = "select * from " + _drTable["TableName"].ToString();
            if (_condition != string.Empty && !(_condition.Contains("@")))
            {
                queryData += " where " + _condition;
                if (extrasql != string.Empty)
                    queryData += " and (" + extrasql + ")";
            }
            else
            {
                fullData = true;
                if (extrasql != string.Empty)
                    queryData += " where " + extrasql;
            }
            if (_drTable["SortOrder"].ToString() != string.Empty)
                queryData += " order by " + DrTable["SortOrder"].ToString();
            DsData = DbData.GetDataSet(queryData);
            if (DsData != null)
                _dsDataTmp = DsData.Copy();
        }
        public override void DataTable0_ColChanged(object sender, DataColumnChangeEventArgs e)
        {
            _dataChanged = true;
            if (WS == string.Empty) return;
            if (e.Column.ColumnName != "_Chk") return;
            if (this.DsData.Tables[0].Columns.Contains("_Chk") && this.DsData.Tables[0].Columns.Contains("ws") && this.DrTable["sysUserID"] != null)
            {
                if (e.Row["ws"] == null) e.Row["ws"] = string.Empty;
                e.Row["ws"] = e.Row["ws"].ToString().Replace(WS + "_", "");
                if (e.Row["_chk"].ToString().ToLower() == "true")
                    e.Row["ws"] = e.Row["ws"].ToString() + WS + "_";
            }
        }
        public void GetData(CDTData ParentData)
        {
            ConditionForPackage();
            string extrasql = string.Empty;

            if (_drTable.Table.Columns.Contains("ExtraSql"))
                if (_drTable["ExtraSql"] != null)
                    extrasql = _drTable["Extrasql"].ToString();

            string queryData = "select * from " + _drTable["TableName"].ToString();
            if (_condition != string.Empty && !(_condition.Contains("@")))
            {
                queryData += " where " + _condition;
                if (extrasql != string.Empty)
                    queryData += " and (" + extrasql + ")";
            }
            else
                if (extrasql != string.Empty)
                    queryData += " where " + extrasql;

            string lkCondition = GenConditionForLookup(ParentData);
            if (lkCondition != string.Empty)
            {
                if (_condition == string.Empty && extrasql == string.Empty)
                    queryData += " where " + lkCondition;
                else
                    queryData += " and ( " + lkCondition + ")";
            }

            if (_drTable["SortOrder"].ToString() != string.Empty)
                queryData += " order by " + DrTable["SortOrder"].ToString();

            DsData = DbData.GetDataSet(queryData);
            if (DsData != null)
                _dsDataTmp = DsData.Copy();
        }

        private string GenConditionForLookup(CDTData ParentData)
        {
            string s = string.Empty;
            string tableName = _drTable["TableName"].ToString().ToUpper();
            foreach (DataRow drField in ParentData.DsStruct.Tables[0].Rows)
            {
                string refTable = drField["RefTable"].ToString().ToUpper();
                if (refTable == string.Empty || tableName != refTable)
                    continue;
                if (s == string.Empty)
                    s = drField["refField"].ToString() + " in (";
                string fieldName = drField["FieldName"].ToString();
                //if (fieldName.ToUpper() == "REFTABLE" || fieldName.ToUpper() == "REFFIELD")
                //    continue;
                int n = ParentData.DsData.Tables[0].Rows.Count;
                for (int i = 0; i < n; i++)
                {
                    DataRow drData = ParentData.DsData.Tables[0].Rows[i];
                    if (drData[fieldName].ToString() == string.Empty)
                        continue;
                    string newValue = "'" + drData[fieldName].ToString() + "'";
                    if (!s.Contains(newValue))
                    {
                        s += newValue + ",";
                    }
                }
            }
            if (s.EndsWith(","))
                s = s.Remove(s.Length - 1);
            if (ParentData.DsData.Tables.Count == 1 || ParentData.DsData.Tables[1].Rows.Count == 0)
            {
                if (s.EndsWith("(") || s == string.Empty)
                    s = "1 = 0";
                else
                    s += ")";
                return s;
            }
            bool first = true;
            foreach (DataRow drField in ParentData.DsStruct.Tables[1].Rows)
            {
                string refTable = drField["RefTable"].ToString().ToUpper();
                if (refTable == string.Empty || tableName != refTable)
                    continue;
                if (s == string.Empty)
                    s = drField["refField"].ToString() + " in (";
                string fieldName = drField["FieldName"].ToString();
                //if (fieldName.ToUpper() == "REFTABLE" || fieldName.ToUpper() == "REFFIELD")
                //    continue;
                int n = ParentData.DsData.Tables[1].Rows.Count;
                if (first && n > 0 && !s.EndsWith("("))
                {
                    s += ",";
                }
                first = false;
                for (int i = 0; i < n; i++)
                {
                    DataRow drData = ParentData.DsData.Tables[1].Rows[i];
                    if (drData[fieldName].ToString() == string.Empty)
                        continue;
                    string newValue = "'" + drData[fieldName].ToString() + "'";
                    if (!s.Contains(newValue))
                    {
                        s += newValue + ",";
                    }
                }
            }
            if (s.EndsWith(","))
                s = s.Remove(s.Length - 1);
            if (s.EndsWith("(") || s == string.Empty)
                s = "1 = 0";
            else
                s += ")";
            return s;
        }

        public override bool UpdateData(DataAction dataAction)
        {
            if (!_dataChanged)
                return true;
            bool isNew = _drCurrentMaster.RowState == DataRowState.Added;
            //kiểm tra Record trước khi update có thỏa điều kiện phân quyền không
            Boolean chkOk = false;
            if (extraWS != string.Empty)
            {
                object pkValue = null;

                string fieldName = string.Empty;

                bool isDelete = false;
                bool isModify = false;
                DataView vOrg = new DataView(_drCurrentMaster.Table);

                if (_drCurrentMaster.RowState == DataRowState.Deleted)
                {
                    _drCurrentMaster.RejectChanges();
                    isDelete = true;
                }
                if (_drCurrentMaster.RowState == DataRowState.Modified)
                {
                    vOrg.RowStateFilter = DataViewRowState.ModifiedOriginal;
                    vOrg.RowFilter = extraWS;
                    isModify = true;
                }

                pkValue = _drCurrentMaster[PkMaster.FieldName];
                DataRow[] DRowtmp = DsData.Tables[0].Select(extraWS);
                foreach (DataRow drtmp in DRowtmp)
                {
                    if (pkValue == drtmp[PkMaster.FieldName])
                    {
                        if (isModify)
                        {
                            if (vOrg.Count > 0) chkOk = true;
                        }
                        else
                        {
                            chkOk = true;
                        }
                    }
                }
                if (isDelete) _drCurrentMaster.Delete();
            }
            else
            {
                chkOk = true;
            }
            if (!chkOk)
                return false;
            //----
            DbData.BeginMultiTrans();
            int index = DsData.Tables[0].Rows.IndexOf(_drCurrentMaster);

            if (!_customize.BeforeUpdate(index, DsData))
            {
                DbData.EndMultiTrans();
                return false;
            }

            if (Update(_drCurrentMaster))
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

        public override DataTable GetDataForPrint(int index)
        {
            return (this.DsData.Tables[0]);
        }
        private string NotAdminListCondition()
        {
            string dk = string.Empty;
            string ws = Config.GetValue("sysUserID").ToString().Trim();
            string tableid = DrTable["sysTableID"].ToString().Trim();
            string sql = "select condition from sysAdminDM where sysUserID=" + ws + " and systableid=" + tableid;
            DataTable tbCon = this._dbStruct.GetDataTable(sql);
            if (tbCon.Rows.Count > 0)
            {
                dk = tbCon.Rows[0]["condition"].ToString();
            }
            else
            {
                dk = "1=0";
            }
            return dk;
        }
        public void updateWS()
        {
            DbData.BeginMultiTrans();
            string sql = "update " + _drTable["TableName"].ToString() + " set ws=null ";
            if (extraWS != string.Empty)
                sql += " where " + extraWS;
            DbData.UpdateByNonQuery(sql);
            DataRow[] drQ;
            if (extraWS != string.Empty)
                drQ = DsData.Tables[0].Select(extraWS + " and not (ws is null or ws='')");
            else
                drQ = DsData.Tables[0].Select(" not (ws is null or ws='')");
            string extraForType = string.Empty;
            if (PkMaster.DbType == SqlDbType.VarChar || PkMaster.DbType == SqlDbType.UniqueIdentifier)
                extraForType = "'";

            foreach (DataRow dr in drQ)
            {
                sql = "update " + _drTable["TableName"].ToString() + " set ws='" + dr["ws"].ToString() + "' where " + PkMaster.FieldName + "=" + extraForType + dr[PkMaster.FieldName] + extraForType;
                DbData.UpdateByNonQuery(sql);
            }
            if (DbData.HasErrors)
                DbData.RollbackMultiTrans();
            else

                DbData.EndMultiTrans();

        }
        public void ChangeCode(DataRow OldRow, DataRow NewRow)
        {
            string pk = _drTable["pk"].ToString();
            string OldCode = OldRow[pk].ToString();
            string NewCode = NewRow[pk].ToString();
            DbData.BeginMultiTrans();
            try
            {
                string sql = "select * from systable where systableid in(select systableid from sysfield where RootTable='" + _drTable["TableName"].ToString() + "' group by systableid) and Collecttype<>-1";
                DataTable dsTable = _dbStruct.GetDataTable(sql);
                sql = "select * from sysfield where RootTable='" + _drTable["TableName"].ToString() + "'";
                DataTable dsField = _dbStruct.GetDataTable(sql);

                foreach (DataRow dr in dsTable.Rows)
                {
                    DataRow[] lstField = dsField.Select("sysTableID=" + dr["sysTableID"].ToString());
                    foreach (DataRow drField in lstField)
                    {
                        sql = "Update " + dr["TableName"] + " set " + drField["FieldName"].ToString() + " ='" + NewCode + "' where " + drField["FieldName"].ToString() + " ='" + OldCode + "'";
                        DbData.UpdateByNonQuery(sql);
                    }
                }
                DbData.EndMultiTrans();
            }
            catch (Exception ex)
            {
                DbData.RollbackMultiTrans();
            }

        }
    }
}
