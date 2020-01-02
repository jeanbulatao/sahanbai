using clsDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VBlibrary;
namespace EstimateProcessing
{
    public partial class frmMITMR010 : Form
    {

        private int EditMode;
        private Boolean IfEditFlag;
        private Control BefCtl;
        private struct TypeArray
        {
            private int Deltime;
            private string ItemNo;
        }
        private string[] strArrData;

        public frmMITMR010()
        {
            InitializeComponent();
        }




        #region Functiontions

        private void loadThis()
        {
            string sqltext;
            DspMopdeProc();
            clsMITMR010.stmSetItemDivid(this);
            cmdFunc_1.Text = "(F1)" + Environment.NewLine + "ADD.";//            'INSERT 2014/02/04 AOKI
            cmdFunc_2.Text = "(F2)" + Environment.NewLine + "REVISE";  //   'INSERT 2014/02/04 AOKI
            cmdFunc_3.Text = "(F3)" + Environment.NewLine + "DELETE";

            cmdFunc_4.Text = "(F4)" + Environment.NewLine + "COPY";//        'INSERT 2017/03/29 AOKI

            cmdFunc_5.Text = "(F5)ISSUE" + Environment.NewLine + "QUOTATION";//

            cmdFunc_6.Text = "(F6)INVOICE" + Environment.NewLine + "PROFORMA";//   'INSERT 2014/06/12 AOKI

            cmdFunc_7.Text = "(F7)PAC ++" + Environment.NewLine + "DEL CHARGE";//    'INSERT 2016/05/10 AOKI
            cmdFunc_8.Text = "(F8)CONTROL" + Environment.NewLine + "LINE FEED";

            cmdFunc_9.Text = "(F9)" + Environment.NewLine + "LINE COPY";

            cmdFunc_10.Text = "(F10)" + Environment.NewLine + "SAVE";

            cmdFunc_11.Text = "(F11)" + Environment.NewLine + "DELETE ALL";

            cmdFunc_12.Text = "(F12)" + Environment.NewLine + "QUIT";

            modHanbai.GetCompanyInfo();

            lblCompany.Text = modHanbai.Company.NAME;
            statclsMITMR010.FlgF6 = false;
            datMitsuYMD.Focus();
        }
        private void EditClear(int viMode = 0)
        {
            if (viMode == 0)
            {
                // todo : add timer events
                timTimer.Interval = 0;
                timTimer.Enabled = false;
                lblJoutai.Visible = false;
                setDateTimePickerBlank(datMitsuYMD, DateTime.Now);
                setDateTimePickerBlank(datMtHakko, DateTime.MinValue); //means to set this as blank
                setDateTimePickerBlank(datPIHakko, DateTime.MinValue); //means to set this as blank
                txtIraiNo.Clear();
                txtOrderNo.Clear();
                txtMitsuNo.Text = "";
                numTokCode.Text = "0";
                numOCode.Text = "0";
                optCountry_1.Checked = true;
                txtTokName.Text = "";
                txtTokTanto.Text = "";
                txtVessel.Text = "";
                txtDoc.Text = "";
                txtShipNo.Text = "";
                txtOName.Text = "";
                txtOrigin.Text = "";
                cboCountry.SelectedIndex = -1;
                cboManila.SelectedIndex = -1;
                txtTekiyo.Clear();
                numMitsuYuko.Clear();
                numLastSEQ.Text = "0";
                numSEQ.Clear();
            }
            txtUnit.Text = ""; //       'UNIT
            txtMaker.Text = "";//'MAKER
            txtType.Text = "";//'TYPE
            txtSerNo.Clear();//'SER/NO
            txtDwgNo.Clear();// 'DWG NO
            txtAdditional.Clear(); //'ADDITIONAL DETAILS
            txtComment1.Clear(); //'COMMENT1
            txtComment2.Clear();// 'COMMENT2
            txtComment3.Clear();// 'COMMENT3
            txtComment4.Clear();// 'COMMENT4

            numMSuryo.Text = "0";//  'Œ©Ï”—Ê
            numMKingaku.Text = "0";//'Œ©Ï‹àŠz
            numJSuryo.Text = "0";//'Žó’”—Ê
            numJKingaku.Text = "0";//'Žó’‹àŠz
            numHSuryo.Text = "0";//'”­’”—Ê
            numHKingaku.Text = "0";//'”­’‹àŠz
            numSSuryo.Text = "0";//'Žd“ü”—Ê
            numSKingaku.Text = "0";//'Žd“ü‹àŠz
            numUSuryo.Text = "0";//'”„ã”—Ê
            numUKingaku.Text = "0";//'”„ã‹àŠz
            optMeisai_0.Checked = true;

            spdData.DataSource = null;
            spdData.Refresh();
            cmdFunc_1.Enabled = true;//            'INSERT 2014/02/24 AOKI
            cmdFunc_2.Enabled = true;//            'INSERT 2014/02/24 AOKI
            cmdFunc_3.Enabled = true;//            'INSERT 2014/02/24 AOKI
            cmdFunc_4.Enabled = true;//            'INSERT 2017/07/19 AOKI
            cmdFunc_5.Enabled = true;//            'INSERT 2014/02/24 AOKI
            cmdFunc_6.Enabled = true;


            ;//          'INSERT 2014/06/12 AOKI



        }
        private void setDateTimePickerBlank(DateTimePicker dtpicker, DateTime value)
        {
            if (value == DateTime.MinValue)
            {
                dtpicker.Format = DateTimePickerFormat.Custom;
                dtpicker.CustomFormat = " ";
            }
            else
            {
                dtpicker.Format = DateTimePickerFormat.Short;
                dtpicker.Value = value;
            }
        }

        private void DspMopdeProc()
        {
            EditMode = 0;
            lblModeTitle.Text = modSac_Com.stStrDSPNM;

            txtMitsuNo.ReadOnly = false;
            cmdNewNo.Visible = false;

        }

        #endregion

        private void frmMITMR010_Load_1(object sender, EventArgs e)
        {

            loadThis();
            clearGridView();
        }

        private void clearGridView()
        {
            spdData.Rows.Clear();
            for (int i = 0; i < 1000; i++)
            {
                spdData.Rows.Add();
            }
        }

        private void datPIHakko_ValueChanged(object sender, EventArgs e)
        {

        }

        private void datMitsuYMD_ValueChanged(object sender, EventArgs e)
        {

        }

        private void datMtHakko_ValueChanged(object sender, EventArgs e)
        {

        }

        private void spdData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            saFrm_Sansyo906 frm = new saFrm_Sansyo906();
            frm.SETMODE(0);
            frm.ShowDialog(this);
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void cmdNewNo_Click(object sender, EventArgs e)
        {
            txtMitsuNo.Text = modMITMR010.GetNewEstimateNo(long.Parse(datMitsuYMD.Value.ToString("yyyyMMddHHmmss")));
            if (modMITMR010.UpdateEstimateNo(txtMitsuNo.Text) == false)
            {
                modSac_Com.ksExpMsgBox("Update failed", "E");
            }
            numSEQ.Text = "1";
            cmdFunc_1.Enabled = false;
            cmdFunc_2.Enabled = false;
            cmdFunc_3.Enabled = false;
            cmdFunc_4.Enabled = false;
            cmdFunc_5.Enabled = false;
            cmdFunc_6.Enabled = false;
            txtIraiNo.Focus();
        }

        private void cmdFunc_1_Click(object sender, EventArgs e)
        {
            AddModeProc();

        }

        private void AddModeProc()
        {
            EditMode = 1;
            lblModeTitle.Text = modSac_Com.stStrADDNM;
            lblModeTitle.BackColor = Color.LightGreen;
            txtMitsuNo.ReadOnly = true;
            txtMitsuNo.Text = "";
            cmdNewNo.Visible = true;
            cmdNewNo.Focus();



        }

        private void cmdSansyo_1_Click(object sender, EventArgs e)
        {
            modHanbai.TokMstInfo TokMst = new modHanbai.TokMstInfo();
            
            saFrm_Sansyo901 frm = new saFrm_Sansyo901();
            frm.SET_TNAME(modHanbai.NCnvN(txtTokName.Text));
            frm.SET_TCODE(modHanbai.NCnvZ(numTokCode.Text));
            frm.SET_TANTO(modHanbai.NCnvN(txtTokTanto.Text));
            frm.SET_VESSEL(modHanbai.NCnvN(txtVessel.Text));
            frm.SET_OWNER(modHanbai.NCnvN(txtOName.Text));
            frm.SET_OCODE(modHanbai.NCnvZ(numOCode.Text));
            frm.SET_DOC(modHanbai.NCnvN(txtDoc.Text));
            frm.SET_SNO(modHanbai.NCnvN(txtShipNo.Text));
            frm.SET_PERSON(modSac_Com.stComboGetKomoku(cboTanto.SelectedIndex > 0 ? cboTanto.Text : ""));
            if (optCountry_0.Checked == true)
                frm.SET_COUNTRY("0");
            else
                frm.SET_COUNTRY("1");
            frm.ShowDialog(this);
            if (frm.Status() == 1)
            {
                numTokCode.Text = frm.STM_TCODE();
                txtTokName.Text = frm.STM_TNAME();
                txtTokTanto.Text = frm.STM_TANTO();
                txtVessel.Text = frm.STM_VESSEL();
                numOCode.Text = frm.STM_OCODE().ToString();
                txtOName.Text = frm.STM_OWNER();
                if (frm.STM_VESSEL() == "")
                {
                    txtDoc.Text = "";
                    txtShipNo.Text = "";
                    }
                else
                    {
                    txtDoc.Text = frm.STM_DOC();
                    txtShipNo.Text = frm.STM_SHIPNO();
                    }
                if (frm.STM_COUNTRY() == 0)
                    optCountry_0.Checked = true;
                else
                    optCountry_1.Checked = true;
                modSac_Com.stComboDispDataKomoku(cboTanto, frm.STM_PERSON());
            }
            TokMst.Tok_001 = Convert.ToDecimal(numTokCode.Text);
            if(modHanbai.GetTokMstInfo(TokMst, 0)==true)
            {
                numMitsuYuko.Text=TokMst.Tok_038.ToString();
            }
            txtUnit.Focus();


        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void cmdSansyo_0_Click(object sender, EventArgs e)
        {
            saFrm_Sansyo906 frm = new saFrm_Sansyo906();
            frm.ShowDialog(this);
            txtMitsuNo.Text = frm.MITNO();    //    '見積№
            datMitsuYMD.Value = Convert.ToDateTime(frm.MITDATE());    //   '見積日
            txtMitsuNo_KeyDown(sender, null);//
            txtIraiNo.Focus();
        }

        private void timTimer_Tick(object sender, EventArgs e)
        {
            if (lblJoutai.Visible)
                lblJoutai.Visible = false;
            else
                lblJoutai.Visible = true;
        }

        private void txtMitsuNo_KeyDown(object sender, KeyEventArgs e)
        {
            string lsMitsuNo = modHanbai.NCnvN(txtMitsuNo.Text);
            ;

            if (e != null && e.KeyCode == Keys.Return)
            {
                return;
            }

            lsMitsuNo = modHanbai.NCnvN(txtMitsuNo.Text);

            if (lsMitsuNo != "")
            {
                if (modMITMR010.OrdHDatReadProc(lsMitsuNo, 0) == false)
                {
                    timTimer.Interval = 0;
                    timTimer.Enabled = false;
                    lblJoutai.Visible = false;
                }
                if (modMITMR010.OrdMDatReadProc(lsMitsuNo, 1, 0) == false)
                {
                }
                if (modMITMR010.OrdDDatReadProc(lsMitsuNo, 1) == false)
                {
                }

                OrdHInfoSetProc();
                OrdMInfoSetProc();
                OrdDInfoSetProc();
            }

        }
        private void OrdHInfoSetProc()
        {
            var tmpHeaderOrder = modMITMR010.OrdHDat[0];
            //var tmpMasterOrder = modMITMR010.OrdMDat;
            //var tmpDetailOrder = modMITMR010.OrdDDat;

            if (tmpHeaderOrder.OrdH_027 != 0)
            {
                lblJoutai.Visible = true;
                timTimer.Enabled = true;
                timTimer.Interval = 600;
            }

            datMitsuYMD.Value = Convert.ToDateTime(modHanbai.NCnvN(tmpHeaderOrder.OrdH_010));
            txtMitsuNo.Text = modHanbai.NCnvN(tmpHeaderOrder.OrdH_009).ToString().ToString();
            txtIraiNo.Text = modHanbai.NCnvN(tmpHeaderOrder.OrdH_005).ToString();
            txtOrderNo.Text = modHanbai.NCnvN(tmpHeaderOrder.OrdH_017).ToString();
            txtTokName.Text = modHanbai.NCnvN(tmpHeaderOrder.OrdH_003).ToString();
            numTokCode.Text = modHanbai.NCnvN(tmpHeaderOrder.OrdH_0031).ToString();
            numOCode.Text = modHanbai.NCnvN(tmpHeaderOrder.OrdH_035).ToString();
            txtTokTanto.Text = modHanbai.NCnvN(tmpHeaderOrder.OrdH_004).ToString();
            txtVessel.Text = modHanbai.NCnvN(tmpHeaderOrder.OrdH_006).ToString();
            txtOName.Text = modHanbai.NCnvN(tmpHeaderOrder.OrdH_022).ToString();
            txtOrigin.Text = modHanbai.NCnvN(tmpHeaderOrder.OrdH_012).ToString();
            modSac_Com.stComboDispDataKomoku(cboCountry, modHanbai.NCnvN(tmpHeaderOrder.OrdH_013)).ToString();
            txtMitsuNouki.Text = modHanbai.NCnvN(tmpHeaderOrder.OrdH_011).ToString();
            modSac_Com.stComboDispDataKomoku(cboTanto, modHanbai.NCnvN(tmpHeaderOrder.OrdH_008)).ToString();
            modSac_Com.stComboDispDataKomoku(cboManila, modHanbai.NCnvN(tmpHeaderOrder.OrdH_0081)).ToString();
            modSac_Com.stComboDispDataKomoku(cboMitsumori, modHanbai.NCnvN(tmpHeaderOrder.OrdH_0082)).ToString();
            txtTekiyo.Text = modHanbai.NCnvN(tmpHeaderOrder.OrdH_014).ToString();
            numMitsuYuko.Text = modHanbai.NCnvZ(tmpHeaderOrder.OrdH_016).ToString();

            if (Convert.ToDecimal(modHanbai.NCnvZ(tmpHeaderOrder.OrdH_007)) == 0)
                optCountry_0.Checked = true;
            else
                optCountry_1.Checked = true;

            numLastSEQ.Text = modMITMR010.GetLastSEQ(modHanbai.NCnvN(tmpHeaderOrder.OrdH_009)).ToString();
            SetGoukeiArea(modHanbai.NCnvN(tmpHeaderOrder.OrdH_009).ToString());

            if (modHanbai.NCnvN(tmpHeaderOrder.OrdH_028) != "" && Convert.ToDateTime(modHanbai.NCnvN(tmpHeaderOrder.OrdH_028)) > Convert.ToDateTime("01/01/1900"))
            {
                datMtHakko.Value = Convert.ToDateTime(modHanbai.NCnvN(tmpHeaderOrder.OrdH_028).ToString());
            }

            if (modHanbai.NCnvN(tmpHeaderOrder.OrdH_0281) != "" && Convert.ToDateTime(modHanbai.NCnvN(tmpHeaderOrder.OrdH_0281)) > Convert.ToDateTime("01/01/1900"))
            {
                datPIHakko.Value = Convert.ToDateTime(modHanbai.NCnvN(tmpHeaderOrder.OrdH_0281).ToString());
            }

            txtDoc.Text = modHanbai.NCnvN(tmpHeaderOrder.OrdH_037).ToString();
            txtShipNo.Text = modHanbai.NCnvN(tmpHeaderOrder.OrdH_038).ToString();
        }


        private void OrdMInfoSetProc()
        {
            //var tmpHeaderOrder = modMITMR010.OrdHDat[0];
            var tmpMasterOrder = modMITMR010.OrdMDat[0];
            //var tmpDetailOrder = modMITMR010.OrdDDat;




            numSEQ.Text = modHanbai.NCnvZ(tmpMasterOrder.OrdM_003).ToString();
            txtUnit.Text = modHanbai.NCnvN(tmpMasterOrder.OrdM_004).ToString();
            txtMaker.Text = modHanbai.NCnvN(tmpMasterOrder.OrdM_005).ToString();
            txtType.Text = modHanbai.NCnvN(tmpMasterOrder.OrdM_006).ToString();
            txtSerNo.Text = modHanbai.NCnvN(tmpMasterOrder.OrdM_007).ToString();
            txtDwgNo.Text = modHanbai.NCnvN(tmpMasterOrder.OrdM_008).ToString();
            txtAdditional.Text = modHanbai.NCnvN(tmpMasterOrder.OrdM_025).ToString();
            txtComment1.Text = modHanbai.NCnvN(tmpMasterOrder.OrdM_009).ToString();
            txtComment2.Text = modHanbai.NCnvN(tmpMasterOrder.OrdM_010).ToString();
            txtComment3.Text = modHanbai.NCnvN(tmpMasterOrder.OrdM_011).ToString();
            txtComment4.Text = modHanbai.NCnvN(tmpMasterOrder.OrdM_012).ToString();


        }


        private void OrdDInfoSetProc()
        {
            clearGridView();
            //var tmpHeaderOrder = modMITMR010.OrdHDat[0];
            //var tmpMasterOrder = modMITMR010.OrdMDat[0];
            var tmpDetailOrder = modMITMR010.OrdDDat;
            int rowctr = 0;
            for (int i = 0; i < tmpDetailOrder.Count(); i++)
            {
                spdData.Rows[rowctr].Cells[modMITMR010.spdcol_Seq].Value = modHanbai.NCnvZ(tmpDetailOrder[i].OrdD_003).ToString();
                spdData.Rows[rowctr].Cells[modMITMR010.spdcol_ItemNo].Value = modHanbai.NCnvZ(tmpDetailOrder[i].OrdD_004).ToString();
                spdData.Rows[rowctr].Cells[modMITMR010.spdcol_HinNm].Value = modHanbai.NCnvN(tmpDetailOrder[i].OrdD_005).ToString();
                spdData.Rows[rowctr].Cells[modMITMR010.spdcol_HinNo].Value = modHanbai.NCnvN(tmpDetailOrder[i].OrdD_006).ToString();

                if (Convert.ToDecimal(modHanbai.NCnvZ(tmpDetailOrder[i].OrdD_008)) != 0)
                {

                    if (Convert.ToDecimal(modHanbai.NCnvZ(tmpDetailOrder[i].OrdD_0071)) > 0)
                    {
                        spdData.Rows[rowctr].Cells[modMITMR010.spdcol_CdNo].Value = modHanbai.NCnvZ(tmpDetailOrder[i].OrdD_0071).ToString();
                    }

                    spdData.Rows[rowctr].Cells[modMITMR010.spdcol_NoS].Value = modHanbai.NCnvN(tmpDetailOrder[i].OrdD_007).ToString();
                    spdData.Rows[rowctr].Cells[modMITMR010.spdcol_MSuryo].Value = modHanbai.NCnvN(tmpDetailOrder[i].OrdD_008).ToString();
                    spdData.Rows[rowctr].Cells[modMITMR010.spdcol_MTani].Value = modHanbai.NCnvN(tmpDetailOrder[i].OrdD_009).ToString();
                    spdData.Rows[rowctr].Cells[modMITMR010.spdcol_MTanka].Value = modHanbai.NCnvN(tmpDetailOrder[i].OrdD_010).ToString();
                    spdData.Rows[rowctr].Cells[modMITMR010.spdcol_Origin].Value = modHanbai.NCnvN(tmpDetailOrder[i].OrdD_041).ToString();
                    spdData.Rows[rowctr].Cells[modMITMR010.spdcol_DelTime].Value = modHanbai.NCnvN(tmpDetailOrder[i].OrdD_042).ToString();

                    spdData.Rows[rowctr].Cells[modMITMR010.spdcol_MKinG].Value = modHanbai.NCnvN(tmpDetailOrder[i].OrdD_011).ToString();
                    spdData.Rows[rowctr].Cells[modMITMR010.spdcol_STanka].Value = modHanbai.NCnvN(tmpDetailOrder[i].OrdD_012).ToString();
                    spdData.Rows[rowctr].Cells[modMITMR010.spdcol_SRitsu].Value = modHanbai.NCnvN(tmpDetailOrder[i].OrdD_013).ToString();
                    spdData.Rows[rowctr].Cells[modMITMR010.spdcol_SNet].Value = modHanbai.NCnvN(tmpDetailOrder[i].OrdD_014).ToString();
                    spdData.Rows[rowctr].Cells[modMITMR010.spdcol_SKinG].Value = modHanbai.NCnvN(tmpDetailOrder[i].OrdD_015).ToString();
                    spdData.Rows[rowctr].Cells[modMITMR010.spdcol_Arari].Value = modHanbai.NCnvN(tmpDetailOrder[i].OrdD_016).ToString();
                    spdData.Rows[rowctr].Cells[modMITMR010.spdcol_HDate].Value = modHanbai.NCnvN(tmpDetailOrder[i].OrdD_023).ToString();
                    spdData.Rows[rowctr].Cells[modMITMR010.spdcol_SDate].Value = modHanbai.NCnvN(tmpDetailOrder[i].OrdD_025).ToString();
                    spdData.Rows[rowctr].Cells[modMITMR010.spdcol_UDate].Value = modHanbai.NCnvN(tmpDetailOrder[i].OrdD_027).ToString();
                    spdData.Rows[rowctr].Cells[modMITMR010.spdcol_SeDate].Value = modHanbai.NCnvN(tmpDetailOrder[i].OrdD_029).ToString();
                    spdData.Rows[rowctr].Cells[modMITMR010.spdcol_SirNm].Value = modHanbai.NCnvN(tmpDetailOrder[i].OrdD_038).ToString();
                    spdData.Rows[rowctr].Cells[modMITMR010.spdcol_SMTanka].Value = modHanbai.NCnvN(tmpDetailOrder[i].OrdD_039).ToString();
                    spdData.Rows[rowctr].Cells[modMITMR010.spdcol_InDate].Value = modHanbai.NCnvN(tmpDetailOrder[i].OrdD_040).ToString();
                    spdData.Rows[rowctr].Cells[modMITMR010.spdcol_Code].Value = modHanbai.NCnvN(tmpDetailOrder[i].OrdD_0381).ToString();



                }


                rowctr++;
            }




        }



        private Boolean SetGoukeiArea(string vsMitsumoriNo)
        {
            DBService db = new DBService();
            Boolean retbool;
            string SQLtxt;

            SQLtxt = "    SELECT SUM(OrdM_013) AS OrdM_013";
            SQLtxt = SQLtxt + " ,SUM(OrdM_014) AS OrdM_014";
            SQLtxt = SQLtxt + "  FROM OrdM_Dat";
            SQLtxt = SQLtxt + " WHERE OrdM_002 ='" + vsMitsumoriNo + "'";
            SQLtxt = SQLtxt + " GROUP BY OrdM_002";




            DataTable dt = new DataTable();
            dt = db.GetDatafromDB(SQLtxt);
            if (dt.Rows.Count >= 1)
            {
                DataRow dr = dt.Rows[0];
                numMSuryo.Text = modHanbai.NCnvZ(dr["OrdM_013"].ToString());
                numMKingaku.Text = modHanbai.NCnvZ(dr["OrdM_014"].ToString());
            }

            SQLtxt = "    SELECT SUM(OrdM_015) AS OrdM_015";
            SQLtxt = SQLtxt + " ,SUM(OrdM_016) AS OrdM_016";
            SQLtxt = SQLtxt + " ,SUM(OrdM_017) AS OrdM_017";
            SQLtxt = SQLtxt + " ,SUM(OrdM_018) AS OrdM_018";
            SQLtxt = SQLtxt + " ,SUM(OrdM_019) AS OrdM_019";
            SQLtxt = SQLtxt + " ,SUM(OrdM_020) AS OrdM_020";
            SQLtxt = SQLtxt + " ,SUM(OrdM_021) AS OrdM_021";
            SQLtxt = SQLtxt + " ,SUM(OrdM_022) AS OrdM_022";
            SQLtxt = SQLtxt + "  FROM OrdM_Dat";
            SQLtxt = SQLtxt + " WHERE OrdM_002 ='" + vsMitsumoriNo + "'";
            SQLtxt = SQLtxt + " AND   OrdM_001 <> ''";
            SQLtxt = SQLtxt + " GROUP BY OrdM_001";

            dt = db.GetDatafromDB(SQLtxt);
            if (dt.Rows.Count >= 1)
            {
                DataRow dr = dt.Rows[0];
                numJSuryo.Text = modHanbai.NCnvZ(dr["OrdM_015"].ToString());
                numJKingaku.Text = modHanbai.NCnvZ(dr["OrdM_016"].ToString());

                numHSuryo.Text = modHanbai.NCnvZ(dr["OrdM_017"].ToString());
                numHKingaku.Text = modHanbai.NCnvZ(dr["OrdM_018"].ToString());

                numSSuryo.Text = modHanbai.NCnvZ(dr["OrdM_019"].ToString());
                numSKingaku.Text = modHanbai.NCnvZ(dr["OrdM_020"].ToString());

                numUSuryo.Text = modHanbai.NCnvZ(dr["OrdM_021"].ToString());
                numUKingaku.Text = modHanbai.NCnvZ(dr["OrdM_022"].ToString());
            }

            retbool = true;

            return retbool;




        }

        private void cmdFunc_2_Click(object sender, EventArgs e)
        {

        }


    }
}
