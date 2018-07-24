using System;
using System.Collections.Generic;
using System.Text;

namespace CDTControl
{
    public class Log
    {
        public string log(string companyName, string Product, string code, string _user, string _pass)
        {
            try
            {
                com.sgdsoft.Service a = new com.sgdsoft.Service();
                string k = a.GetKeyDirect(companyName, Product, code, _user, _pass);
                return k;
            }
            catch (Exception ex)
            {
                return "Lỗi";
            }
        }
        public bool Check(string user, string pass)
        {
            try
            {
                //Comboserver.Service a = new Comboserver.Service();
                com.sgdsoft.Service a = new com.sgdsoft.Service();
                bool k = a.CheckUserLogin(user, pass);
                return k;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
