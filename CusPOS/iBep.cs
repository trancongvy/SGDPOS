using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CusPOS
{
    public partial class iBep : UserControl
    {
        string _Mamon;string _tenmon; string _maban; public string ID;double _sl;
        public double Soluong
        {
            get { return _sl; }
            set { _sl = value; tSl.Text= _sl.ToString("### ### ##0.##"); }
        }
        public iBep(string _ID, string Mamon, string tenmon, double soluong, string maban)
        {
            InitializeComponent();
            _Mamon = Mamon; ID = _ID;
            ttenmon.Text = tenmon; _tenmon = tenmon;
            tSl.Text = soluong.ToString("### ### ##0.##"); _sl = soluong;
            tBan.Text = maban; _maban = maban;
        }

        private void iBep_Load(object sender, EventArgs e)
        {
           
        }


    }
}
