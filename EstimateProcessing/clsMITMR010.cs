using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VBlibrary;

namespace EstimateProcessing
{
    public static class statclsMITMR010
    {
        public static Boolean FlgF6;
    }
    public static class clsMITMR010
    {
        //all form-updates related functions should be here
        public static Boolean stmSetItemDivid(frmMITMR010 frm)
        {

            modHanbai.stComboSetKubun(frm.cboCountry, 0, "Country");
            modHanbai.stComboSetKubun(frm.cboTanto, 0, "担当者");
            modHanbai.stComboSetKubun(frm.cboManila, 0, "マニラ担当");
            modHanbai.stComboSetKubun(frm.cboMitsumori, 0, "担当者");
            return true;
        }

        public static Boolean stmSetFucntion(frmMITMR010 frm)
        {
            frm.cmdFunc_1.Enabled = true;
            frm.cmdFunc_2.Enabled = true;
            frm.cmdFunc_3.Enabled = true;
            frm.cmdFunc_4.Enabled = true;
            frm.cmdFunc_5.Enabled = true;
            frm.cmdFunc_6.Enabled = false;
            frm.cmdFunc_7.Enabled = true;
            frm.cmdFunc_8.Enabled = true;
            frm.cmdFunc_9.Enabled = true;
            frm.cmdFunc_10.Enabled = true;
            frm.cmdFunc_11.Enabled = true;
            frm.cmdFunc_12.Enabled = true;
            return true;

        }
        public static string getnewEstimateNo(long strnumber)
        {
            string retstr;
            retstr = modMITMR010.GetNewEstimateNo(strnumber);
            return retstr;
        }
        public static void OrdHDatReadProcIraiNo(string vsIraiNo,int viMode)
        {
            //todo if  needed
            //bool retbool;
            //if (viMode == 0)
            //    modMITMR010.OrdHDat = null;
            //retbool = false;

            //clsDB.DBService db = new clsDB.DBService();

            //DataTable dt = new DataTable();

            //string SQLtxt;

            //SQLtxt = "";
            //SQLtxt = SQLtxt + " SELECT * FROM OrdH_Dat";
            //SQLtxt = SQLtxt + " WHERE OrdH_005 ='" + vsIraiNo + "'";

            //dt = db.GetDatafromDB(SQLtxt);
            //modSinseiMarin.OrdHDatInfo ord = new modSinseiMarin.OrdHDatInfo();
            //modMITMR010.OrdHDat.



        }

    }
}
