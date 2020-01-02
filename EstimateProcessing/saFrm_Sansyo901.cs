using clsDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VBlibrary;

namespace EstimateProcessing
{
    public partial class saFrm_Sansyo901 : Form
    {


        private string L_TNAME;       // 引数(得意先名称)
        private string L_TCODE;         // 引数(得意先コード)
        private string L_TANTO;       // 引数(得意先担当者)
        private string L_VESSEL;       // 引数(船名)
        private string L_OWNER;       // 引数(オーナー名称)
        private string L_OCODE;         // 引数(オーナーコード)
        private string L_DOC;       // 引数(造船所)
        private string L_SNO;       // 引数(船番)
        private string L_PERSON;       // 引数(当社担当者)       'INSERT 2014/02/04 AOKI
        private string L_COUNTRY;       // 引数(国内/海外)        'INSERT 2014/04/04 AOKI
        private string L_FormName;       // 引数(画面名称)         'INSERT 2015/09/14 AOKI

        public saFrm_Sansyo901()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }


        private void refreshTokMstInfo()
        {
            txtTName.Text = "";
            txtTTanto.Text = "";
            txtVessel.Text = "";
            txtOwner.Text = "" ;
            numTCode.Text = "0";
            numOCode.Text = "0";
            SetTokMstInfo();
        }


        private void saFrm_Sansyo901_Load(object sender, EventArgs e)
        {
 
            //this.Move(Screen.Width - this.Width); /* TODO ERROR: Skipped SkippedTokensTrivia *//* TODO ERROR: Skipped SkippedTokensTrivia */

            EditClear();      // フォームクリア

            if (L_COUNTRY == "0")
                optCountry_0.Checked = true;
            else
                optCountry_1.Checked = true;
            txtTName.Text = L_TNAME;
            txtTTanto.Text = L_TANTO;
            txtVessel.Text = L_VESSEL;
            txtOwner.Text = L_OWNER;
            numTCode.Text = L_TCODE.ToString();
            numOCode.Text = L_OCODE.ToString();
            txtDoc.Text = L_DOC;
            txtShipNo.Text = L_SNO;
            txtPerson.Text = L_PERSON;

            SetTokMstInfo();

            for (int i = 0; i < spdTokMstInfo.Rows.Count-1; i++)
            {
                if (Convert.ToInt16(spdTokMstInfo.Rows[i].Cells["Tok_001"].Value) == Convert.ToInt16(numTCode.Text))
                {

                    spdTokMstInfo.CurrentCell = spdTokMstInfo.Rows[i].Cells[1];
                    spdTokMstInfo.Rows[i].Selected = true;
                    SetTokTMstInfo();
                    SetVesTblInfo();
                    SetOwnTblInfo();

                    break;
                }
            }


            cmdFunc_9.Text = "(F9)Ship" + System.Environment.NewLine + "Mentenace";

            cmdFunc_10.Text = "(F10)" +System.Environment.NewLine  + "ENTER";
            cmdFunc_11.Text = "(F11)" +System.Environment.NewLine  + "BACK";
            cmdFunc_12.Text = "(F12)" + System.Environment.NewLine + "SET";

            if (!File.Exists(Application.StartupPath + @"\TBLMR010.exe"))
                cmdFunc_9.Visible = false;
        }

        private void SetTokMstInfo()
        {


               string SQLtxt = @"SELECT 
                                Tok_001
                                ,Tok_003
                                ,Tok_004
                                ,Tok_006
                                ,Tok_051 FROM Tok_Mst ";

                if (optCountry_1.Checked == true)
                    SQLtxt = SQLtxt + "WHERE Tok_030 = 1";
                else if (optCountry_0.Checked == true)
                    SQLtxt = SQLtxt + "WHERE Tok_030 = 0";
                // 得意先名１(曖昧検索)
                if (modHanbai.NCnvN(txtTokSerch0.Text) != "")
                    SQLtxt = SQLtxt + "  AND Tok_003 Like '%" + "" + modSinseiMarin.EditSQLAddSQuot(txtTokSerch0.Text).Trim() + "%'";
                // 得意先名２(曖昧検索)
                if (modHanbai.NCnvN(txtTokSerch1.Text) != "")
                    SQLtxt = SQLtxt + "  AND Tok_004 Like '%" + "" + modSinseiMarin.EditSQLAddSQuot(txtTokSerch1.Text).Trim() + "%'";
                // 得意先名ｶﾅ(曖昧検索)
                if (modHanbai.NCnvN(txtTokSerch2.Text) != "")
                    SQLtxt = SQLtxt + "  AND Tok_006 Like '%" + "" + modSinseiMarin.EditSQLAddSQuot(txtTokSerch2.Text).Trim() + "%'";
                SQLtxt = SQLtxt + " ORDER BY Tok_003,Tok_004,Tok_006";

            DBService db = new DBService();
            DataTable dt= new DataTable();
            dt = db.GetDatafromDB(SQLtxt);
            spdTokMstInfo.DataSource = dt;



        }

        private void  SetVesTblInfo()
        {
            int idx = spdTokMstInfo.CurrentRow.Index;

            
            string lcTCode = modHanbai.NCnvZ(spdTokMstInfo.Rows[idx].Cells["Tok_001"].Value.ToString());
            string SQLtxt = "SELECT Ves_002,Ves_004,Ves_005 FROM Ves_Tbl ";
            if (optVessel_0.Checked == true)
                SQLtxt = Convert.ToString(SQLtxt + "WHERE Ves_003 = ") + lcTCode;
            // 船名(曖昧検索)
            if (modHanbai.NCnvN(txtSVessel.Text) != "")
            {
                if (optVessel_0.Checked == true)
                    SQLtxt = SQLtxt + "  AND Ves_002 Like '%" + "" + modSinseiMarin.EditSQLAddSQuot(txtSVessel.Text).Trim() + "%'";
                else
                    SQLtxt = SQLtxt + "WHERE Ves_002 Like '%" + "" + modSinseiMarin.EditSQLAddSQuot(txtSVessel.Text).Trim() + "%'";
            }
            SQLtxt = SQLtxt + " ORDER BY Ves_002,Ves_004,Ves_005";

            DBService db = new DBService();
            DataTable dt = new DataTable();
            dt = db.GetDatafromDB(SQLtxt);
            spdVesTblInfo.DataSource = dt;


        }

        private void SetOwnTblInfo()
        {
            int idx = spdTokMstInfo.CurrentRow.Index;

            
            string lcTCode = modHanbai.NCnvZ(spdTokMstInfo.Rows[idx].Cells["Tok_001"].Value.ToString());

            string SQLtxt = "SELECT Own_001,Own_002 FROM Own_Tbl ";

            SQLtxt = Convert.ToString(SQLtxt + "WHERE Own_003 = ") + lcTCode;

            if (modHanbai.NCnvN(txtVessel.Text) != "")
                SQLtxt = Convert.ToString(SQLtxt + "  AND Own_006 = '") + modSinseiMarin.EditSQLAddSQuot(txtVessel.Text).Trim() + "'";


            SQLtxt = SQLtxt + " AND Own_006 <> ''";

            SQLtxt = SQLtxt + " ORDER BY Own_002,Own_004,Own_005";

            DBService db = new DBService();
            DataTable dt = new DataTable();
            dt = db.GetDatafromDB(SQLtxt);
            spdOwnTblInfo.DataSource = dt;

        }




        private void SetTokTMstInfo()
        {
            int idx = spdTokMstInfo.CurrentRow.Index;
            spdTokTMstInfo.Rows.Clear();
            string lcTCode = modHanbai.NCnvZ(spdTokMstInfo.Rows[idx].Cells["Tok_001"].Value.ToString());

            string SQLtxt = " SELECT * FROM TokT_Mst ";
            SQLtxt = Convert.ToString(SQLtxt + "WHERE TokT_001 = ") + lcTCode;
            SQLtxt = SQLtxt + " ORDER BY TokT_001";

            DBService db = new DBService();
            DataTable dt = new DataTable();
            dt = db.GetDatafromDB(SQLtxt);

            if (dt.Rows.Count >= 1)
            {
                for (int i = 2; i < 26; i++)
                {
                    if(dt.Rows[0][i] == null || dt.Rows[0][i].ToString()=="")
                    {
                        break;
                    }
                    string[] row = new string[] { dt.Rows[0][i].ToString() };
            
                    spdTokTMstInfo.Rows.Add(row);
                }
            }





        }

        private  void EditClear(string p001 = "D")
        {
           VBlibrary.modSac_Com.RetName1 = "";
           VBlibrary.modSac_Com.RetName2 = "";
           VBlibrary.modSac_Com.RetName3 = "";
           VBlibrary.modSac_Com.RetName4 = "";
           VBlibrary.modSac_Com.RetName6 = "";
           VBlibrary.modSac_Com.RetName7 = "";
           VBlibrary.modSac_Com.RetCode = 0;
           VBlibrary.modSac_Com.RetCurr1 = 0;
           VBlibrary.modSac_Com.RetCurr2 = 0;
           VBlibrary.modSac_Com.RetMode = 0;

            txtTName.Clear();
            txtTTanto.Clear();
            txtVessel.Clear();
            numTCode.Clear();

            optCountry_1.Checked = true;
            txtTokSerch0.Clear();
            txtTokSerch1.Clear();
            txtTokSerch2.Clear();
            


            optVessel_0.Checked = true;
            txtSVessel.Clear();
        }

        private void txtTokSerch_Click(object sender, EventArgs e)
        {

        }

        private void txtDoc_TextChanged(object sender, EventArgs e)
        {

        }

        private void spdVesTblInfo_Click(object sender, EventArgs e)
        {

        }



        public void SET_TNAME(String value)
        {
            L_TNAME = value;
        }

        public void SET_TCODE(string value)
        {
            L_TCODE = value;
        }
        public void SET_TANTO(string value)
        {
            L_TANTO = value;
        }
        public void SET_VESSEL(string value)
        {
            L_VESSEL = value;
        }
        public void SET_OWNER(string value)
        {
            L_OWNER = value;
        }
        public void SET_OCODE(string value)
        {
            L_OCODE = value;
        }

        public byte Status()
        {
            return VBlibrary.modSac_Com.RetMode;
        }
        public string STM_TCODE()
        {
            return VBlibrary.modSac_Com.RetCode.ToString();
        }
        public string STM_TNAME()
        {
            return VBlibrary.modSac_Com.RetName1;
        }
        public string STM_TANTO()
        {
            return VBlibrary.modSac_Com.RetName2;
        }
        public string STM_VESSEL()
        {
            return VBlibrary.modSac_Com.RetName3;
        }
        public decimal STM_COUNTRY()
        {
            return VBlibrary.modSac_Com.RetCurr1;
        }
        public String STM_OWNER()
        {
            return VBlibrary.modSac_Com.RetName4;
        }
        public decimal STM_OCODE()
        {
            return VBlibrary.modSac_Com.RetCurr2;
        }
        public string STM_DOC()
        {
            return VBlibrary.modSac_Com.RetName6;
        }
        public string STM_SHIPNO()
        {
            return VBlibrary.modSac_Com.RetName7;
        }
        public void SET_PERSON(string value)
        {
            L_PERSON = value;
        }
        public string STM_PERSON()
        {
            return VBlibrary.modSac_Com.RetName8;
        }
        public void SET_DOC(string value)
        {
            L_DOC = value;
        }
        public void SET_SNO(string value)
        {
            L_SNO = value;
        }
        public void SET_COUNTRY(string value)
        {
            L_COUNTRY = value;
        }
        public void SET_FormName(string value)
        {
            L_FormName = value;
        }



        private void on_Click(object sender, EventArgs e)
        {
            refreshTokMstInfo();
        }
        private void on_key(object sender, KeyEventArgs e)
        {
            refreshTokMstInfo();
        }

        private void spdTokMstInfo_DoubleClick(object sender, EventArgs e)
        {
            txtTTanto.Text = "";
            txtVessel.Text = "";
            txtOwner.Text = "";
            numOCode.Text = "0";

            int idx = spdTokMstInfo.CurrentRow.Index;

            numTCode.Text = modHanbai.NCnvZ(spdTokMstInfo.Rows[idx].Cells[0].Value).ToString();
            txtTName.Text = modHanbai.NCnvN(spdTokMstInfo.Rows[idx].Cells[1].Value.ToString()).ToString();
            txtPerson.Text =modHanbai.NCnvN(spdTokMstInfo.Rows[idx].Cells[2].Value.ToString()).ToString();

            SetTokTMstInfo();
            SetVesTblInfo();
            SetOwnTblInfo();
        }

        private void txtSVessel_KeyUp(object sender, KeyEventArgs e)
        {
            SetVesTblInfo();
        }

        private void spdVesTblInfo_DoubleClick(object sender, EventArgs e)
        {

            int idx = spdVesTblInfo.CurrentRow.Index;

            txtVessel.Text = modHanbai.NCnvN(spdVesTblInfo.Rows[idx].Cells[0].Value).ToString();
            txtDoc.Text = modHanbai.NCnvN(spdVesTblInfo.Rows[idx].Cells[1].Value.ToString()).ToString();
            txtShipNo.Text = modHanbai.NCnvN(spdVesTblInfo.Rows[idx].Cells[2].Value.ToString()).ToString();
            SetOwnTblInfo();

            if(spdOwnTblInfo.Rows.Count>=1)
            {
                if(L_FormName == null || L_FormName=="")
                {
                    int selindex = 0;
                    numOCode.Text = modHanbai.NCnvZ(spdOwnTblInfo.Rows[selindex].Cells[0].Value).ToString();
                    txtOwner.Text = modHanbai.NCnvN(spdOwnTblInfo.Rows[selindex].Cells[1].Value.ToString()).ToString();

                }
                else
                {
                    numOCode.Text = "0";
                    txtOwner.Text = "";
                }
            }

        }

        private void spdOwnTblInfo_DoubleClick(object sender, EventArgs e)
        {
            int idx = spdOwnTblInfo.CurrentRow.Index;
            numOCode.Text= modHanbai.NCnvZ(spdOwnTblInfo.Rows[idx].Cells[0].Value).ToString();
            txtOwner.Text = modHanbai.NCnvN(spdOwnTblInfo.Rows[idx].Cells[1].Value.ToString()).ToString();
        }

        private void cmdFunc_12_Click(object sender, EventArgs e)
        {
            modSac_Com.RetMode = 1;
             modSac_Com.RetCode = numTCode.Text    ;
             modSac_Com.RetName1 = txtTName.Text   ;
             modSac_Com.RetName2 = txtTTanto.Text  ;
             modSac_Com.RetName3 = txtVessel.Text  ;
             modSac_Com.RetName4 = txtOwner.Text   ;
             modSac_Com.RetCurr2 = Convert.ToDecimal(numOCode.Text)   ;
             modSac_Com.RetName6 = txtDoc.Text     ;
             modSac_Com.RetName7 = txtShipNo.Text  ;
            modSac_Com.RetName8 = txtPerson.Text;


            if (optCountry_1.Checked == true)
                modSac_Com.RetCurr1 = 1;
            this.Close();



        }

        private void cmdFunc_11_Click(object sender, EventArgs e)
        {
            modSac_Com.RetMode = 0;
            this.Close();
        }

        private void spdTokTMstInfo_DoubleClick(object sender, EventArgs e)
        {
            int idx = spdTokTMstInfo.CurrentRow.Index;
            txtTTanto.Text = modHanbai.NCnvN(spdTokTMstInfo.Rows[idx].Cells[0].Value.ToString()).ToString();
        }
    }
}
