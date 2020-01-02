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
    public partial class saFrm_Sansyo906 : Form
    {
        String MitNoWk      ; // 'Œ©Ï‡‚ƒ[ƒN
        String MitDateWk    ; // 'Œ©Ï“ú•tƒ[ƒN
        String KeiyakuNoWk  ; // 'Œ_–ñ‡‚ƒ[ƒN
        String KeiyakuDateWk; // 'Œ_–ñ“ú•tƒ[ƒN
        int DataJoutai   ; // 'ó‘Ô 0:Œ©Ï 1:Žó’
        String TokuiNmWk    ; // '“¾ˆÓæ–¼Ìƒ[ƒN
        String VesNmWk      ; // '‘D–¼ƒ[ƒN
        int iMode        ; // 'Žó‚¯“n‚µˆø”(0:Œ©Ï 1:Žó’)
        public saFrm_Sansyo906()
        {
            InitializeComponent();
        }

        private void EditClear()
        {
            modSac_Com.RetMode = 0;

            if (iMode == 0)
            {
                label1.Text = "見積";
                chkData_0.Checked = true;
                chkData_1.Checked = false;
            }
            else
            {
                label1.Text = "受注";
                chkData_0.Checked = false;
                chkData_1.Checked = true;
            }

            // ƒNƒŠƒA
            optCountry_0.Checked = true;
            txtTName.Clear();
            txtVessel.Clear();
            datMDate.Value = DateTime.Today.AddDays(-30);
            datKDate.Value = DateTime.Today.AddDays(-30);

            {
                //var withBlock = spdDataInfo;
                //withBlock.Row = -1;
                //withBlock.Col = -1;
                //withBlock.Action = 12;
                //withBlock.MaxRows = 9999;
            }

            MitNoWk = "";
            MitDateWk = "";
            KeiyakuNoWk = "";
            KeiyakuDateWk = "";
            TokuiNmWk = "";
            VesNmWk = "";
            DataJoutai = 0;
        }

        private void saFrm_Sansyo906_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        public void SETMODE(int value)
        {
            iMode = value;
        }
        public byte Status()
        {
            return VBlibrary.modSac_Com.RetMode;
        }
        public string MITNO()
        {
            return MitNoWk;
        }
        public string MITDATE()
        {
            return MitDateWk;
        }
        public string TOKUINM()
        {
            return TokuiNmWk;
        }
        public string KEIYAKUNO()
        {
            return KeiyakuNoWk;   
        }
        public string KEIYAKUDATE()
        {
            return KeiyakuDateWk;

        }
        public string JOUTAI()
        {
            return DataJoutai.ToString();
        }

        private void cmdFunc_11_Click(object sender, EventArgs e)
        {
            modSac_Com.RetMode = 0;
            this.Close();

        }

        private void setdataLoad()
        {
            DBService db = new DBService();

            string sqltxt;

            sqltxt = "SELECT distinct ";
            sqltxt = sqltxt + @" case OrdH_027 when 0 then '見積' 
                 else '受注' end as [Quotation],
                 case isnull(OrdH_009, '') when 'M' then ''
                 else OrdH_009 end as  [Estimate No],
                 isnull(OrdH_010, '') as [Quote Date],
                 case isnull(OrdH_001, '') when 'J' then ''
                 else OrdH_001 end as  [Our Ref No],
                 isnull(OrdH_002, '') as [Order Date],
                 isnull(OrdH_003, '') as [Messrs],
                 isnull(OrdH_006, '') as [Vessels Name],
                 isnull(OrdH_005, '') as [Your Refno],
                 isnull(OrdH_027, '') as [Status]
                 FROM OrdH_Dat, Tok_Mst";

            if (chkData_0.Checked && chkData_1.Checked)
                sqltxt = sqltxt + " WHERE ( OrdH_027 = 0 OR OrdH_027 = 1 ) ";
            else if (chkData_0.Checked)
                sqltxt = sqltxt + "  WHERE OrdH_027 = 0 ";
            else if (chkData_1.Checked)
                sqltxt = sqltxt + "  WHERE OrdH_027 = 1 ";
            else
                sqltxt = sqltxt + " WHERE ( OrdH_027 = 0 OR OrdH_027 = 1 ) ";

            if (optCountry_0.Checked)
                sqltxt = sqltxt + " AND Tok_030 = 1";
            else
                sqltxt = sqltxt + " AND Tok_030 = 0";

            if (txtMitNo.Text.Trim() != "")
                sqltxt = sqltxt + "   AND OrdH_009 Like '%" + "" + txtMitNo.Text.Trim() + "%'";

            if (txtTName.Text.Trim() != "")
                sqltxt = sqltxt + "   AND OrdH_003 Like '%" + txtTName.Text.Trim() + "%'";

            if (txtVessel.Text.Trim() != "")
                sqltxt = sqltxt + "   AND OrdH_006 Like '%" + txtVessel.Text.Trim() + "%'";

            if (datKDate.Value != null)
            {
                sqltxt = sqltxt + " AND (OrdH_002 >='" + datKDate.Value + "'";
                sqltxt = sqltxt + "  OR  OrdH_002 IS NULL OR OrdH_002 = '1900/01/01') ";
            }
            if (datMDate.Value != null)
            {
                sqltxt = sqltxt + " AND (OrdH_010 >='" + datMDate.Value + "'";
                sqltxt = sqltxt + "  OR  OrdH_010 IS NULL OR OrdH_010 = '1900/01/01') ";
            }



            if (modHanbai.NCnvN(txtTName.Text) != "")
                sqltxt = sqltxt + " AND OrdH_003 Like '%" + modSinseiMarin.EditSQLAddSQuot(modHanbai.NCnvN(txtTName.Text)) + "%'";

            DataTable dt = new DataTable();
            dt = db.GetDatafromDB(sqltxt);
            dataGridView1.DataSource = dt;

        }

        private void txtMitNo_TextChanged(object sender, EventArgs e)
        {
            setdataLoad();
        }

        private void cmdFunc_12_Click(object sender, EventArgs e)
        {
            //RetMode = True                     '処理モードセット(実行)
            //With spdDataInfo
            //    If.DataRowCnt > 0 Then
            //       .GetText 2, .ActiveRow, ssTXT  '見積№
            //        MitNoWk = NCnvN(ssTXT)
            //        .GetText 3, .ActiveRow, ssTXT  '見積日付
            //        MitDateWk = NCnvN(ssTXT)
            //        .GetText 4, .ActiveRow, ssTXT  '契約№
            //        KeiyakuNoWk = NCnvN(ssTXT)
            //        .GetText 5, .ActiveRow, ssTXT  '契約日付
            //        KeiyakuDateWk = NCnvN(ssTXT)
            //        .GetText 6, .ActiveRow, ssTXT  '得意先名
            //        TokuiNmWk = NCnvN(ssTXT)
            //        .GetText 7, .ActiveRow, ssTXT  '船名
            //        VesNmWk = NCnvN(ssTXT)
            //        .GetText 9, .ActiveRow, ssTXT  '状態
            //        DataJoutai = NCnvZ(ssTXT)
            //    End If
            //End With
            //Unload Me
            if (dataGridView1.SelectedCells.Count > 0)
            {
                modSac_Com.RetMode = 1;


    
                    int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                    MitNoWk = Convert.ToString(selectedRow.Cells[1].Value);
                    MitDateWk = Convert.ToString(selectedRow.Cells[2].Value);
                    KeiyakuNoWk = Convert.ToString(selectedRow.Cells[3].Value);
                    KeiyakuDateWk = Convert.ToString(selectedRow.Cells[4].Value);
                    TokuiNmWk = Convert.ToString(selectedRow.Cells[5].Value);
                    VesNmWk = Convert.ToString(selectedRow.Cells[6].Value);
                    DataJoutai = Convert.ToInt16(selectedRow.Cells[8].Value);

                }
            this.Close();


    
        }

        private void txtVessel_TextChanged(object sender, EventArgs e)
        {
            setdataLoad();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count == 1)
            cmdFunc_12_Click(sender, e);

        }
    }
}
