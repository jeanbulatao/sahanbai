using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using clsDB;

namespace EstimateProcessing
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strmsg;
            DBService db = new DBService();
            db.BeginTrans();
            db.ExecuteSql("insert into testtbl1 values('1')",out strmsg);
            db.ExecuteSql("insert into testtbl1 values('2')",out strmsg);
            DataTable dt = new DataTable();     
            db.RollbackTran();
            dt = db.GetDatafromDB("select * from testtbl1");
        }
    }
}
