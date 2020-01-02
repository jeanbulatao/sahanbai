using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstimateProcessing
{
    public static class clsSpdDataContent
    {
        public const int spdcol_Jisseki =     0       ; // = 1      '実績
        public const int spdcol_CdNo =1            ; // = 2      'CODE NO.
        public const int spdcol_NoS =  2          ; // = 3      'NAME OF SUPPLIER
        public const int spdcol_Sansyo1 =3            ; // = 4      '参照１
        public const int spdcol_Case =    4        ; // = 5      'ｹｰｽ case
        public const int spdcol_Seq =     5       ; // = 6      'SEQ
        public const int spdcol_ItemNo =  6          ; // = 7      '項目item
        public const int spdcol_HinNm =    7        ; // = 8      'DESCRIPTION
        public const int spdcol_Sansyo2 =  8          ; // = 9      '参照２
        public const int spdcol_HinNo =    9        ; // = 10     'Part No
        public const int spdcol_MSuryo =    10        ; // = 11     'QTY
        public const int spdcol_MTani =      11      ; // = 12     'UNIT
        public const int spdcol_MTanka =      12      ; // = 13     'UnitPrice
        public const int spdcol_Origin =       13     ; // = 14     'ORIGIN
        public const int spdcol_DelTime =     14       ; // = 15     'Delivery Time              'INSERT 2016/02/10 AOKI
        public const int spdcol_MKinG =  15          ; // = 16     'Amount
        public const int spdcol_STanka =   16         ; // = 17     '仕入単価Purchase unit price
        public const int spdcol_SRitsu =   17         ; // = 18     '掛率MultiplyRate
        public const int spdcol_SNet =      18      ; // = 19     '仕入単価NET                Purchase price NET
        public const int spdcol_SKinG =    19        ; // = 20     '仕入金額                Purchase amount
        public const int spdcol_Arari =      20      ; // = 21     '粗利                    Gross margin
        public const int spdcol_HDate =        21    ; // = 22     '発注日                  Order date
        public const int spdcol_SDate = 22           ; // = 23     '仕入日                  Purchase date
        public const int spdcol_UDate =  23          ; // = 24     '売上日                  Sales date
        public const int spdcol_SeDate = 24           ; // = 25     '請求日                  Invoice date
        public const int spdcol_SirNm =    25        ; // = 26     '仕入先名                Vendor name
        public const int spdcol_SMTanka = 26           ; // = 27     '仕入先見積原価          Vendor estimated cost
        public const int spdcol_InDate =    27        ; // = 28     '入力日付                Input date
        public const int spdcol_Code =        28    ; // = 29  
    }
}
