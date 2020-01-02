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
    public partial class saFrm_Sansyo902 : Form
    {

        private Boolean WK_Mode      ;
        private decimal WK_SirCode  ;
        private String   WK_SirName  ;
        private String   WK_Hinmei   ;
        private String   WK_Hinban   ;
        private decimal WK_JSuryo   ;
        private String   WK_Tani     ;
        private decimal WK_JTanka   ;
        private decimal WK_JKingaku ;
        private decimal WK_MTanka   ;
        private decimal WK_Kakeritu ;
        private decimal WK_MTankaNet ;
        private decimal WK_MKingaku;

        public saFrm_Sansyo902()
        {
            InitializeComponent();
        }


        private Boolean DataInsertProc()
        {
            return true;
            //todo
            //if(VBlibrary.modHanbai.NCnvN(()
        }

        private void saFrm_Sansyo902_Load(object sender, EventArgs e)
        {

        }


        public string STM_STATUS()
        {
            return WK_Mode.ToString();

        }
        public string STM_SIRNAME()
        {
            return WK_SirCode.ToString();

        }


        public string STM_HINMEI()
        {
            return WK_Hinmei.ToString();

        }
        public string STM_HINBAN()
        {
            return WK_Hinban.ToString();

        }
        public string STM_JSURYO()
        {
            return WK_JSuryo.ToString();
        }





        public string STM_TANI()
        {
            return WK_Tani.ToString();

        }
        public string STM_JTANKA()
        {
            return WK_JTanka.ToString();

        }
        public string STM_JKINGAKU()
        {
            return WK_JKingaku.ToString();
        }

        public string STM_MTANKA()
        {
            return WK_MTanka.ToString();

        }
        public string STM_KAKERITU()
        {
            return WK_Kakeritu.ToString();

        }
        public string STM_MTANKANET()
        {
            return WK_MTankaNet.ToString();
        }
        public string STM_MKINGAKU()
        {
            return WK_MKingaku.ToString();
        }

        private void cmdFunc_10_Click(object sender, EventArgs e)
        {
            if (DataInsertProc() == true)
            {
                modSac_Com.ksExpMsgBox("正常に登録されました", "E");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void saFrm_Sansyo902_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode != Keys.Shift)
            {
                switch (e.KeyCode)
                {
                    case Keys.F10:
                        {
                            cmdFunc_10_Click(sender, e);
                            break;
                        }
                    case Keys.F11:
                        {
                            cmdFunc_11_Click(sender, e);
                            break;
                        }
                    case Keys.F12:
                        {
                            cmdFunc_11_Click(sender, e);
                            break;
                        }
                }
            }

        }

        private void cmdFunc_11_Click(object sender, EventArgs e)
        {
            WK_Mode = false;
            this.Close();

        }

        private void cmdFunc_12_Click(object sender, EventArgs e)
        {
            WK_Mode = true;

        }
    }
}
