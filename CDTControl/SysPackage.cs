using System;
using System.Collections.Generic;
using System.Data;
using CDTDatabase;
using CDTLib;

namespace CDTControl
{
    public class SysPackage
    {
        public Database _dbStruct = Database.NewStructDatabase();
        public string StructServer = "";
        public DataTable GetPackageForUser(SysUser user)
        {
            string queryPackage;
            //sẽ kiểm tra core admin bằng cách khác
            if (Boolean.Parse(user.DrUser["CoreAdmin"].ToString()))
                queryPackage = "select b.sysDBID,a.sysPackageID,a.Package,a.Background, a.Copyright, a.Version,  b.DBName as PackageName,b.DBPath,b.DBPathRemote, b.DBName2 as PackageName2, b.DatabaseName AS DbName, c.isAdmin, c.sysUserPackageID from syspackage a inner join sysdb b on a.syspackageid=b.syspackageid inner join sysuserPackage c on b.sysDBID=c.sysDBID inner join sysUser d on c.sysUserGroupID=d.sysUserGroupID";
            else
                queryPackage = "select b.sysDBID,a.sysPackageID,a.Package,a.Background, a.Copyright, a.Version,  b.DBName as PackageName,b.DBPath,b.DBPathRemote, b.DBName2 as PackageName2, b.DatabaseName AS DbName, c.isAdmin, c.sysUserPackageID from syspackage a inner join sysdb b on a.syspackageid=b.syspackageid inner join sysuserPackage c on b.sysDBID=c.sysDBID inner join sysUser d on c.sysUserGroupID=d.sysUserGroupID  where d.sysUserID = " + user.DrUser["sysUserID"].ToString();
            DataTable dt1 = _dbStruct.GetDataTable(queryPackage);
            StructServer = _dbStruct.Connection.DataSource;
            return dt1;
            
        }

        public void InitSysvar(string sysPackageID, string sysDBID)
        {
            DataTable dtConfig = _dbStruct.GetDataTable("select * from sysConfig where (sysPackageID is null or sysPackageID = " + sysPackageID + ") and (sysDBID is null or sysDBID=" + sysDBID + ")");
            if (dtConfig != null)
                Config.InitData(dtConfig);
        }
        public DateTime ngayht()
        {
            try
            {
                string sql = "select convert(date,getdate())";
                object o = _dbStruct.GetValue(sql);
                if (o == null) 
                    return DateTime.Parse(DateTime.Now.ToShortDateString());
                return DateTime.Parse(o.ToString());
            }
            catch { return DateTime.Now; }
        }
        public DateTime LastUpdate()
        {
            try
            {
                string sql = "select max(Ngay) from sysupdate";
                object o = _dbStruct.GetValue(sql);
                if (o != null)
                    return DateTime.Parse(o.ToString());
            }
            catch
            {
                
            }
            return DateTime.Parse("01/01/2000");
        }
        public void InitDictionary()
        {
            if (UIDictionary.Contents.Count > 0)
                return;
            DataTable dtDictionary = _dbStruct.GetDataTable("select * from Dictionary");
            if (dtDictionary != null)
                UIDictionary.InitData(dtDictionary);
        }
    }
}
