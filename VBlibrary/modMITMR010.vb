Imports System.Windows.Forms
Imports globalcls.modHanbai
Imports clswinApi



''all database transaction were put here , all control related
Public Module modMITMR010


    Public OrdHDat(0 To 0) As OrdHDatInfo  '見積データ(ヘッダー)
    Public OrdMDat(0 To 0) As OrdMDatInfo  '見積データ(中ヘッダー(SEQ))
    Public OrdDDat() As OrdDDatInfo  '見積データ(明細)

    Public ConMst(0 To 0) As ConMstInfo   'コントロールマスタ情報

    Public Const MITMR010_MSG001 As String = "入力または選択された見積№のデータは受注処理されています。訂正等を行う場合は受注入力にて行って下さい"
    Public Const MITMR010_MSG002 As String = "前SEQのデータが存在しません。"
    Public Const MITMR010_MSG003 As String = "次SEQのデータが存在しません。"



    Public FlgF6 As Boolean      'F6フラグ       'INSERT 2014/06/12 AOKI

    'INSERT 2016/02/05 AOKI START -----------------------------------------------------------------------------------------
    'スプレッドCOL
    Public Const spdcol_Jisseki As Integer = 1      '実績
    Public Const spdcol_CdNo As Integer = 2      'CODE NO.
    Public Const spdcol_NoS As Integer = 3      'NAME OF SUPPLIER
    Public Const spdcol_Sansyo1 As Integer = 4      '参照１
    Public Const spdcol_Case As Integer = 5      'ｹｰｽ case
    Public Const spdcol_Seq As Integer = 6      'SEQ
    Public Const spdcol_ItemNo As Integer = 7      '項目item
    Public Const spdcol_HinNm As Integer = 8      'DESCRIPTION
    Public Const spdcol_Sansyo2 As Integer = 9      '参照２
    Public Const spdcol_HinNo As Integer = 10     'Part No
    Public Const spdcol_MSuryo As Integer = 11     'QTY
    Public Const spdcol_MTani As Integer = 12     'UNIT
    Public Const spdcol_MTanka As Integer = 13     'UnitPrice
    Public Const spdcol_Origin As Integer = 14     'ORIGIN
    Public Const spdcol_DelTime As Integer = 15     'Delivery Time              'INSERT 2016/02/10 AOKI
    'UPDATE 2016/02/10 AOKI START -----------------------------------------------------------------------------------------
    Public Const spdcol_MKinG As Integer = 16     'Amount
    Public Const spdcol_STanka As Integer = 17     '仕入単価Purchase unit price
    Public Const spdcol_SRitsu As Integer = 18     '掛率MultiplyRate
    Public Const spdcol_SNet As Integer = 19     '仕入単価NET                Purchase price NET
    Public Const spdcol_SKinG As Integer = 20     '仕入金額                Purchase amount
    Public Const spdcol_Arari As Integer = 21     '粗利                    Gross margin
    Public Const spdcol_HDate As Integer = 22     '発注日                  Order date
    Public Const spdcol_SDate As Integer = 23     '仕入日                  Purchase date
    Public Const spdcol_UDate As Integer = 24     '売上日                  Sales date
    Public Const spdcol_SeDate As Integer = 25     '請求日                  Invoice date
    Public Const spdcol_SirNm As Integer = 26     '仕入先名                Vendor name
    Public Const spdcol_SMTanka As Integer = 27     '仕入先見積原価          Vendor estimated cost
    Public Const spdcol_InDate As Integer = 28     '入力日付                Input date
    Public Const spdcol_Code As Integer = 29     'ｺｰﾄﾞ                    Code
    'UPDATE 2016/02/10 AOKI E N D -----------------------------------------------------------------------------------------
    'INSERT 2016/02/05 AOKI E N D -----------------------------------------------------------------------------------------
    Private dbsvc As clsDB.DBService


    Public Function DataKousinProc() As Boolean

        Dim SQLtxt As String  'SQL文作成用
        Dim strMsg As String  'エラーメッセージ作成用
        Dim lngErr As Long    'エラー番号
        Dim Idx As Integer
        Dim lsKeiyakuNo As String  '契約№
        Dim lsMitsumoriNo As String  '見積№


        On Error GoTo Error_DataKousinProc

        DataKousinProc = False

        'セッション開始
        dbsvc = New clsDB.DBService()


        dbsvc.BeginTrans()

        '見積データ(ヘッダー)存在チェック
        If OrdHDatReadProc(OrdHDat(0).OrdH_009, 1) = False Then
            '見積データ(ヘッダー)Insert処理
            If OrdHDatInsertProc() = False Then
                GoTo Error_DataKousinProc
            End If
        Else
            '見積データ(ヘッダー)Update処理
            If OrdHDatUpdateProc() = False Then
                GoTo Error_DataKousinProc
            End If
        End If

        '見積データ(中ヘッダー)存在チェック
        If OrdMDatReadProc(OrdMDat(0).OrdM_002, OrdMDat(0).OrdM_003, 3) = False Then
            '見積データ(中ヘッダー)Insert処理
            If OrdMDatInsertProc() = False Then
                GoTo Error_DataKousinProc
            End If
        Else
            '見積データ(中ヘッダー)Update処理
            If OrdMDatUpdateProc() = False Then
                GoTo Error_DataKousinProc
            End If
        End If

        '見積データ(明細)更新(デリートインサート)処理
        If OrdDDatKousinProc() = False Then
            GoTo Error_DataKousinProc
        End If

        'コミット
        dbsvc.CommitTrans()



        '項目№並替え処理
        Call OrdDSortProc(OrdHDat(0).OrdH_009)

        DataKousinProc = True

        Exit Function

Error_DataKousinProc:
        dbsvc.RollbackTran()                                  '処理を戻す（ロールバック）
        Call ksExpMsgBox(gstGUIDE_E002 & " ERR: " & strMsg, "E") 'エラーメッセージ表示

    End Function

    '***************************************************************
    '**  名称    : Sub OrdHDatInsertProc()
    '**  機能    : 見積データ(ヘッダー)インサート処理。
    '**  戻り値  :
    '**  引数    :
    '**  備考    :
    '***************************************************************
    Public Function OrdHDatInsertProc() As Boolean

        Dim strSQL As String  'SQL文作成用
        Dim strMsg As String  'エラーメッセージ作成用
        Dim lngErr As Long    'エラー番号

        OrdHDatInsertProc = False

        '追加用SQL文作成
        '===========================================
        With OrdHDat(0)
            strSQL = ""
            strSQL = strSQL & "INSERT INTO OrdH_Dat("
            strSQL = strSQL & "OrdH_001,"       '契約№
            strSQL = strSQL & "OrdH_002,"       '契約日付
            strSQL = strSQL & "OrdH_003,"       '得意先名(CUSTOMER)
            strSQL = strSQL & "OrdH_0031,"      '得意先ｺｰﾄﾞ
            strSQL = strSQL & "OrdH_0032,"      '得意先名2              'INSERT 2014/04/04 AOKI
            strSQL = strSQL & "OrdH_004,"       '得意先担当者(ATTN)
            strSQL = strSQL & "OrdH_005,"       '客先依頼No(YOUR NO)
            strSQL = strSQL & "OrdH_006,"       '船名(VESSEL NAME)
            strSQL = strSQL & "OrdH_007,"       '造船所
            strSQL = strSQL & "OrdH_008,"       '当社担当(OUR PERSON)
            strSQL = strSQL & "OrdH_0081,"      'マニラ担当             'INSERT 2013/08/19 Manila AOKI
            strSQL = strSQL & "OrdH_0082,"      '見積担当               'INSERT 2019/04/25 AOKI
            strSQL = strSQL & "OrdH_009,"       '見積No(OUR REF NO)
            strSQL = strSQL & "OrdH_010,"       '見積日付
            strSQL = strSQL & "OrdH_011,"       '見積時納期(DELIVERY TIME)
            strSQL = strSQL & "OrdH_012,"       'ｿｰｽ(SOURCE)
            strSQL = strSQL & "OrdH_013,"       '国(CONTRY)
            strSQL = strSQL & "OrdH_014,"       '適用
            strSQL = strSQL & "OrdH_015,"       '支払期間(Payment terms)
            strSQL = strSQL & "OrdH_016,"       '見積有効期間
            strSQL = strSQL & "OrdH_017,"       '客先注文No(Your Order No)      'INSERT 2014/06/12 AOKI
            strSQL = strSQL & "OrdH_022,"       '住所関連項目) 1.オーナ
            strSQL = strSQL & "OrdH_023,"       '住所関連項目) 2.得意先
            strSQL = strSQL & "OrdH_024,"       '住所関連項目) 3.住所
            strSQL = strSQL & "OrdH_025,"       '住所関連項目) 4.電話他
            strSQL = strSQL & "OrdH_026,"       '住所関連項目) 5.備考
            strSQL = strSQL & "OrdH_027,"       'データ区分(0:見積ﾃﾞｰﾀ 1:見積ﾃﾞｰﾀ)
            strSQL = strSQL & "OrdH_035,"       'オーナーコード
            'INSERT 2013/05/16 AOKI START -----------------------------------------------------------------------------
            strSQL = strSQL & "OrdH_037,"       '造船所
            strSQL = strSQL & "OrdH_038,"       '船番
            'INSERT 2013/05/16 AOKI E N D -----------------------------------------------------------------------------
            strSQL = strSQL & "OrdH_Insert,"    '追加日時
            strSQL = strSQL & "OrdH_WsNo"       'WSNO
            strSQL = strSQL & ") VALUES ('"
            strSQL = strSQL & EditSQLAddSQuot(.OrdH_001) & "','"  '契約№
            strSQL = strSQL & EditSQLAddSQuot(.OrdH_002) & "','"  '契約日付
            strSQL = strSQL & EditSQLAddSQuot(.OrdH_003) & "',"   '得意先名(CUSTOMER)
            strSQL = strSQL & .OrdH_0031 & ",'"                   '得意先ｺｰﾄﾞ
            strSQL = strSQL & EditSQLAddSQuot(.OrdH_0032) & "','" '得意先名2                'INSERT 2014/04/04 AOKI
            strSQL = strSQL & EditSQLAddSQuot(.OrdH_004) & "','"  '得意先担当者(ATTN)
            strSQL = strSQL & EditSQLAddSQuot(.OrdH_005) & "','"  '客先依頼No(YOUR NO)
            strSQL = strSQL & EditSQLAddSQuot(.OrdH_006) & "','"  '船名(VESSEL NAME)
            strSQL = strSQL & EditSQLAddSQuot(.OrdH_007) & "','"  '造船所
            strSQL = strSQL & EditSQLAddSQuot(.OrdH_008) & "','"  '当社担当(OUR PERSON)
            strSQL = strSQL & EditSQLAddSQuot(.OrdH_0081) & "','" 'マニラ担当               'INSERT 2013/08/19 Manila AOKI
            strSQL = strSQL & EditSQLAddSQuot(.OrdH_0082) & "','" '見積担当                 'INSERT 2019/04/25 AOKI
            strSQL = strSQL & EditSQLAddSQuot(.OrdH_009) & "','"  '見積No(OUR REF NO)
            strSQL = strSQL & EditSQLAddSQuot(.OrdH_010) & "','"  '見積日付
            strSQL = strSQL & EditSQLAddSQuot(.OrdH_011) & "','"  '見積時納期(DELIVERY TIME)
            strSQL = strSQL & EditSQLAddSQuot(.OrdH_012) & "','"  'ｿｰｽ(SOURCE)
            strSQL = strSQL & EditSQLAddSQuot(.OrdH_013) & "','"  '国(CONTRY)
            strSQL = strSQL & EditSQLAddSQuot(.OrdH_014) & "',"   '適用
            strSQL = strSQL & .OrdH_015 & ","                     '支払期間(Payment terms)
            strSQL = strSQL & .OrdH_016 & ",'"                    '見積有効期間
            strSQL = strSQL & EditSQLAddSQuot(.OrdH_017) & "','"  '客先注文No(Your Order No)        'INSERT 2014/06/12 AOKI
            strSQL = strSQL & EditSQLAddSQuot(.OrdH_022) & "','"  '住所関連項目) 1.オーナ
            strSQL = strSQL & EditSQLAddSQuot(.OrdH_023) & "','"  '住所関連項目) 2.得意先
            strSQL = strSQL & EditSQLAddSQuot(.OrdH_024) & "','"  '住所関連項目) 3.住所
            strSQL = strSQL & EditSQLAddSQuot(.OrdH_025) & "','"  '住所関連項目) 4.電話他
            strSQL = strSQL & EditSQLAddSQuot(.OrdH_026) & "',"   '住所関連項目) 5.備考
            strSQL = strSQL & .OrdH_027 & ","                     'データ区分(0:見積ﾃﾞｰﾀ 1:見積ﾃﾞｰﾀ)
            strSQL = strSQL & .OrdH_035 & ",'"                    'オーナーコード
            'INSERT 2013/05/16 AOKI START -----------------------------------------------------------------------------
            strSQL = strSQL & EditSQLAddSQuot(.OrdH_037) & "','"  '造船所
            strSQL = strSQL & EditSQLAddSQuot(.OrdH_038) & "','"  '船番
            'INSERT 2013/05/16 AOKI E N D -----------------------------------------------------------------------------
            strSQL = strSQL & Now & "','"                         '追加日時
            strSQL = strSQL & "FMV001')"                  'WSNO
        End With

        'SQL文実行
        If dbsvc.ExecuteSql(strSQL, strMsg) = False Then
            GoTo Error_OrdHDatInsertProc
        End If

        '''    'コントロールマスタ見積№更新処理
        '''    If UpdateEstimateNo(OrdHdat(0).OrdH_009) = False Then
        '''        GoTo Error_OrdHDatInsertProc
        '''    End If

        OrdHDatInsertProc = True

        Exit Function

Error_OrdHDatInsertProc:
        'エラーメッセージ表示
        Call ksExpMsgBox(gstGUIDE_E003 & " ERR: " & strMsg, "E")

    End Function

    '***************************************************************
    '**  名称    : Sub OrdHDatUpdateProc()
    '**  機能    : 見積データ(ヘッダー)アップデート処理。
    '**  戻り値  :
    '**  引数    :
    '**  備考    :
    '***************************************************************
    Public Function OrdHDatUpdateProc() As Boolean

        Dim strSQL As String  'SQL文作成用
        Dim strMsg As String  'エラーメッセージ作成用
        Dim lngErr As Long    'エラー番号

        OrdHDatUpdateProc = False

        '更新用SQL文作成
        '=====================================================================
        With OrdHDat(0)
            strSQL = ""
            strSQL = " UPDATE OrdH_Dat"
            strSQL = strSQL & "   SET OrdH_003    ='" & EditSQLAddSQuot(.OrdH_003) & "'"    '得意先名(CUSTOMER)
            strSQL = strSQL & "     , OrdH_0031   = " & .OrdH_0031                          '得意先ｺｰﾄﾞ
            strSQL = strSQL & "     , OrdH_0032   ='" & EditSQLAddSQuot(.OrdH_0032) & "'"   '得意先名2          'INSERT 2014/04/04 AOKI
            strSQL = strSQL & "     , OrdH_004    ='" & EditSQLAddSQuot(.OrdH_004) & "'"    '得意先担当者(ATTN)
            strSQL = strSQL & "     , OrdH_005    ='" & EditSQLAddSQuot(.OrdH_005) & "'"    '客先依頼No(YOUR NO)
            strSQL = strSQL & "     , OrdH_006    ='" & EditSQLAddSQuot(.OrdH_006) & "'"    '船名(VESSEL NAME)
            strSQL = strSQL & "     , OrdH_007    ='" & EditSQLAddSQuot(.OrdH_007) & "'"    '造船所
            strSQL = strSQL & "     , OrdH_008    ='" & EditSQLAddSQuot(.OrdH_008) & "'"    '当社担当(OUR PERSON)
            strSQL = strSQL & "     , OrdH_0081   ='" & EditSQLAddSQuot(.OrdH_0081) & "'"   'マニラ担当         'INSERT 2013/08/19 Manila AOKI
            strSQL = strSQL & "     , OrdH_0082   ='" & EditSQLAddSQuot(.OrdH_0082) & "'"   '見積担当           'INSERT 2019/04/25 AOKI
            strSQL = strSQL & "     , OrdH_010    ='" & EditSQLAddSQuot(.OrdH_010) & "'"    '見積日付
            strSQL = strSQL & "     , OrdH_011    ='" & EditSQLAddSQuot(.OrdH_011) & "'"    '見積時納期(DELIVERY TIME)
            strSQL = strSQL & "     , OrdH_012    ='" & EditSQLAddSQuot(.OrdH_012) & "'"    'ｿｰｽ(SOURCE)
            strSQL = strSQL & "     , OrdH_013    ='" & EditSQLAddSQuot(.OrdH_013) & "'"    '国(CONTRY)
            strSQL = strSQL & "     , OrdH_014    ='" & EditSQLAddSQuot(.OrdH_014) & "'"    '適用
            strSQL = strSQL & "     , OrdH_015    = " & .OrdH_015                           '支払期間(Payment terms)
            strSQL = strSQL & "     , OrdH_016    = " & .OrdH_016                           '見積有効期間
            strSQL = strSQL & "     , OrdH_017    ='" & EditSQLAddSQuot(.OrdH_017) & "'"    '客先注文No(Your Order No)      'INSERT 2014/06/12 AOKI
            strSQL = strSQL & "     , OrdH_022    ='" & EditSQLAddSQuot(.OrdH_022) & "'"    '住所関連項目) 1.オーナ
            strSQL = strSQL & "     , OrdH_023    ='" & EditSQLAddSQuot(.OrdH_023) & "'"    '住所関連項目) 2.得意先
            strSQL = strSQL & "     , OrdH_024    ='" & EditSQLAddSQuot(.OrdH_024) & "'"    '住所関連項目) 3.住所
            strSQL = strSQL & "     , OrdH_025    ='" & EditSQLAddSQuot(.OrdH_025) & "'"    '住所関連項目) 4.電話他
            strSQL = strSQL & "     , OrdH_026    ='" & EditSQLAddSQuot(.OrdH_026) & "'"    '住所関連項目) 5.備考
            strSQL = strSQL & "     , OrdH_027    = " & .OrdH_027                           'データ区分(0:見積ﾃﾞｰﾀ 1:見積ﾃﾞｰﾀ)
            strSQL = strSQL & "     , OrdH_035    = " & .OrdH_035                           'オーナーコード
            'INSERT 2013/05/16 AOKI START -----------------------------------------------------------------------------
            strSQL = strSQL & "     , OrdH_037    ='" & EditSQLAddSQuot(.OrdH_037) & "'"    '造船所
            strSQL = strSQL & "     , OrdH_038    ='" & EditSQLAddSQuot(.OrdH_038) & "'"    '船番
            'INSERT 2013/05/16 AOKI E N D -----------------------------------------------------------------------------
            strSQL = strSQL & "     , OrdH_Update ='" & Now & "'"
            strSQL = strSQL & "     , OrdH_WsNo   ='" & StaticWinApi.Wsnumber & "'"
            strSQL = strSQL & " WHERE OrdH_009    ='" & EditSQLAddSQuot(.OrdH_009) & "'"
        End With
        '=====================================================================

        'SQL文実行
        If dbsvc.ExecuteSql(strSQL, strMsg) = False Then
            GoTo Error_OrdHDatUpdateProc
        End If

        OrdHDatUpdateProc = True

        Exit Function

Error_OrdHDatUpdateProc:
        'エラーメッセージ表示
        Call ksExpMsgBox(gstGUIDE_E003 & ":" & strMsg, "E")

    End Function

    '***************************************************************
    '**  名称    : Sub OrdMDatInsertProc()
    '**  機能    : 見積データ(中ヘッダー)インサート処理。
    '**  戻り値  :
    '**  引数    :
    '**  備考    :
    '***************************************************************
    Public Function OrdMDatInsertProc() As Boolean

        Dim strSQL As String  'SQL文作成用
        Dim strMsg As String  'エラーメッセージ作成用
        Dim lngErr As Long    'エラー番号

        OrdMDatInsertProc = False

        '追加用SQL文作成
        '===========================================
        With OrdMDat(0)
            strSQL = ""
            strSQL = strSQL & "INSERT INTO OrdM_Dat("
            strSQL = strSQL & "OrdM_001,"       '契約№
            strSQL = strSQL & "OrdM_002,"       '見積№
            strSQL = strSQL & "OrdM_003,"       'SEQ
            strSQL = strSQL & "OrdM_004,"       'UNIT
            strSQL = strSQL & "OrdM_005,"       'MAKER
            strSQL = strSQL & "OrdM_006,"       'TYPE
            strSQL = strSQL & "OrdM_007,"       'SER/NO
            strSQL = strSQL & "OrdM_008,"       'DWG/NO
            strSQL = strSQL & "OrdM_025,"       'ADDITIONAL DETAILS
            strSQL = strSQL & "OrdM_009,"       'COMMENT1
            strSQL = strSQL & "OrdM_010,"       'COMMENT2
            strSQL = strSQL & "OrdM_011,"       'COMMENT3
            strSQL = strSQL & "OrdM_012,"       'COMMENT4
            strSQL = strSQL & "OrdM_013,"       '見積数量
            strSQL = strSQL & "OrdM_014,"       '見積金額
            strSQL = strSQL & "OrdM_015,"       '見積数量
            strSQL = strSQL & "OrdM_016,"       '見積金額
            strSQL = strSQL & "OrdM_Insert,"    '追加日時
            strSQL = strSQL & "OrdM_WsNo"       'WSNO
            strSQL = strSQL & ") VALUES ('"
            strSQL = strSQL & EditSQLAddSQuot(.OrdM_001) & "','"  '契約№
            strSQL = strSQL & EditSQLAddSQuot(.OrdM_002) & "',"   '見積№
            strSQL = strSQL & .OrdM_003 & ",'"                    'SEQ
            strSQL = strSQL & EditSQLAddSQuot(.OrdM_004) & "','"  'UNIT
            strSQL = strSQL & EditSQLAddSQuot(.OrdM_005) & "','"  'MAKER
            strSQL = strSQL & EditSQLAddSQuot(.OrdM_006) & "','"  'TYPE
            strSQL = strSQL & EditSQLAddSQuot(.OrdM_007) & "','"  'SER/NO
            strSQL = strSQL & EditSQLAddSQuot(.OrdM_008) & "','"  'DWG/NO
            strSQL = strSQL & EditSQLAddSQuot(.OrdM_025) & "','"  'ADDITIONAL DETAILS
            strSQL = strSQL & EditSQLAddSQuot(.OrdM_009) & "','"  'COMMENT1
            strSQL = strSQL & EditSQLAddSQuot(.OrdM_010) & "','"  'COMMENT2
            strSQL = strSQL & EditSQLAddSQuot(.OrdM_011) & "','"  'COMMENT3
            strSQL = strSQL & EditSQLAddSQuot(.OrdM_012) & "',"   'COMMENT4
            strSQL = strSQL & .OrdM_013 & ","                     '見積数量
            strSQL = strSQL & .OrdM_014 & ","                     '見積金額
            strSQL = strSQL & .OrdM_015 & ","                     '見積数量
            strSQL = strSQL & .OrdM_016 & ",'"                    '見積金額
            strSQL = strSQL & Now & "','"                         '追加日時
            strSQL = strSQL & StaticWinApi.Wsnumber & "')"                  'WSNO
        End With

        'SQL文実行
        If dbsvc.ExecuteSql(strSQL, strMsg) = False Then
            GoTo Error_OrdMDatInsertProc
        End If

        OrdMDatInsertProc = True

        Exit Function

Error_OrdMDatInsertProc:
        'エラーメッセージ表示
        Call ksExpMsgBox(gstGUIDE_E003, "E")

    End Function

    '***************************************************************
    '**  名称    : Sub OrdMDatUpdateProc()
    '**  機能    : 見積データ(中ヘッダー)インサート処理。
    '**  戻り値  :
    '**  引数    :
    '**  備考    :
    '***************************************************************
    Public Function OrdMDatUpdateProc() As Boolean

        Dim strSQL As String  'SQL文作成用
        Dim strMsg As String  'エラーメッセージ作成用
        Dim lngErr As Long    'エラー番号

        OrdMDatUpdateProc = False

        '更新用SQL文作成
        '=====================================================================
        With OrdMDat(0)
            strSQL = ""
            strSQL = " UPDATE OrdM_Dat"
            strSQL = strSQL & "   SET OrdM_004    ='" & EditSQLAddSQuot(.OrdM_004) & "'"   'UNIT
            strSQL = strSQL & "     , OrdM_005    ='" & EditSQLAddSQuot(.OrdM_005) & "'"   'MAKER
            strSQL = strSQL & "     , OrdM_006    ='" & EditSQLAddSQuot(.OrdM_006) & "'"   'TYPE
            strSQL = strSQL & "     , OrdM_007    ='" & EditSQLAddSQuot(.OrdM_007) & "'"   'SER/NO
            strSQL = strSQL & "     , OrdM_008    ='" & EditSQLAddSQuot(.OrdM_008) & "'"   'DWG/NO
            strSQL = strSQL & "     , OrdM_025    ='" & EditSQLAddSQuot(.OrdM_025) & "'"   'ADDITIONAL DETAILS
            strSQL = strSQL & "     , OrdM_009    ='" & EditSQLAddSQuot(.OrdM_009) & "'"   'COMMENT1
            strSQL = strSQL & "     , OrdM_010    ='" & EditSQLAddSQuot(.OrdM_010) & "'"   'COMMENT2
            strSQL = strSQL & "     , OrdM_011    ='" & EditSQLAddSQuot(.OrdM_011) & "'"         'COMMENT3
            strSQL = strSQL & "     , OrdM_012    ='" & EditSQLAddSQuot(.OrdM_012) & "'"   'COMMENT4
            strSQL = strSQL & "     , OrdM_013    = " & .OrdM_013                          '見積数量
            strSQL = strSQL & "     , OrdM_014    = " & .OrdM_014                          '見積金額
            strSQL = strSQL & "     , OrdM_015    = " & .OrdM_015                          '見積数量
            strSQL = strSQL & "     , OrdM_016    = " & .OrdM_016                          '見積金額
            strSQL = strSQL & "     , OrdM_Update ='" & Now & "'"                          '追加日時
            strSQL = strSQL & "     , OrdM_WsNo   ='" & StaticWinApi.Wsnumber & "'"                  'WSNO
            strSQL = strSQL & " WHERE OrdM_002    ='" & EditSQLAddSQuot(.OrdM_002) & "'"
            strSQL = strSQL & "   AND OrdM_003    = " & .OrdM_003
        End With
        '=====================================================================

        'SQL文実行
        If dbsvc.ExecuteSql(strSQL, strMsg) = False Then
            GoTo Error_OrdMDatUpdateProc
        End If

        OrdMDatUpdateProc = True

        Exit Function

Error_OrdMDatUpdateProc:
        'エラーメッセージ表示
        Call ksExpMsgBox(gstGUIDE_E003, "E")

    End Function

    '***************************************************************
    '**  名称    : OrdDDatKousinProc()
    '**  機能    : データインサート処理。
    '**  戻り値  :
    '**  引数    :
    '**  備考    :
    '***************************************************************
    Public Function OrdDDatKousinProc() As Boolean

        Dim strSQL As String  'SQL文作成用
        Dim strMsg As String  'エラーメッセージ作成用
        Dim lngErr As Long    'エラー番号
        Dim Idx As Integer

        OrdDDatKousinProc = False

        '削除用SQL文作成
        '========================================================
        With OrdMDat(0)
            strSQL = ""
            strSQL = strSQL & "DELETE FROM OrdD_Dat "
            strSQL = strSQL & " WHERE OrdD_002 ='" & EditSQLAddSQuot(.OrdM_002) & "'"
            strSQL = strSQL & "   AND OrdD_003 = " & .OrdM_003
        End With
        '========================================================

        '
        If dbsvc.ExecuteSql(strSQL, strMsg) = False Then
            GoTo Error_OrdDDatKousinProc
        End If

        For Idx = LBound(OrdDDat) To UBound(OrdDDat)

            '追加用SQL文作成
            '===========================================
            With OrdDDat(Idx)
                strSQL = ""
                strSQL = strSQL & "INSERT INTO OrdD_Dat("
                strSQL = strSQL & "OrdD_001,"            '契約№
                strSQL = strSQL & "OrdD_002,"            '見積№
                strSQL = strSQL & "OrdD_003,"            'SEQ
                strSQL = strSQL & "OrdD_004,"            '項目
                strSQL = strSQL & "OrdD_005,"            '品名
                strSQL = strSQL & "OrdD_006,"            '品番
                strSQL = strSQL & "OrdD_007,"            '仕入先名称
                strSQL = strSQL & "OrdD_0071,"           '仕入先ｺｰﾄﾞ
                strSQL = strSQL & "OrdD_008,"            '見積数量
                strSQL = strSQL & "OrdD_009,"            '単位
                strSQL = strSQL & "OrdD_010,"            '見積販売単価
                strSQL = strSQL & "OrdD_011,"            '見積販売金額
                strSQL = strSQL & "OrdD_012,"            '(見積原価単価)
                strSQL = strSQL & "OrdD_013,"            '掛け率
                strSQL = strSQL & "OrdD_014,"            '見積原価単価NET
                strSQL = strSQL & "OrdD_015,"            '(見積原価金額)
                strSQL = strSQL & "OrdD_016,"            '(粗利益)
                strSQL = strSQL & "OrdD_Insert,"         '追加日時
                '--- UPDATE 2011/11/01 青木 START --------------------------------------------------------------------------
                'strSQL = strSQL & "OrdD_WsNo"            'WSNO
                strSQL = strSQL & "OrdD_WsNo,"           'WSNO
                '--- UPDATE 2011/11/01 青木 E N D --------------------------------------------------------------------------
                '--- INSERT 2011/11/01 青木 START --------------------------------------------------------------------------
                strSQL = strSQL & "OrdD_038,"            '仕入先名
                '--- INSERT 2011/11/09 青木 START --------------------------------------------------------------------------
                strSQL = strSQL & "OrdD_0381,"           '仕入先コード
                '--- INSERT 2011/11/09 青木 E N D --------------------------------------------------------------------------
                strSQL = strSQL & "OrdD_039,"            '仕入先見積単価
                '            strSQL = strSQL & "OrdD_040"             '入力日付                         'DELETE 2016/02/05 AOKI
                strSQL = strSQL & "OrdD_040,"            '入力日付                          'INSERT 2016/02/05 AOKI
                '            strSQL = strSQL & "OrdD_041"             'ORIGIN                            'INSERT 2016/02/05 AOKI
                strSQL = strSQL & "OrdD_041,"            'ORIGIN                            'INSERT 2016/04/05 AOKI
                strSQL = strSQL & "OrdD_042"             'Delivery Time                     'INSERT 2016/04/05 AOKI
                '--- INSERT 2011/11/01 青木 E N D --------------------------------------------------------------------------
                strSQL = strSQL & ") VALUES ('"
                strSQL = strSQL & EditSQLAddSQuot(.OrdD_001) & "','"   '契約№
                strSQL = strSQL & EditSQLAddSQuot(.OrdD_002) & "',"    '見積№
                strSQL = strSQL & .OrdD_003 & ","                      'SEQ
                strSQL = strSQL & .OrdD_004 & ",'"                     '項目
                strSQL = strSQL & EditSQLAddSQuot(.OrdD_005) & "','"   '品名
                strSQL = strSQL & EditSQLAddSQuot(.OrdD_006) & "','"   '品番
                strSQL = strSQL & EditSQLAddSQuot(.OrdD_007) & "',"    '仕入先名称
                strSQL = strSQL & .OrdD_0071 & ","                     '仕入先ｺｰﾄﾞ
                strSQL = strSQL & .OrdD_008 & ",'"                     '見積数量
                strSQL = strSQL & EditSQLAddSQuot(.OrdD_009) & "',"    '単位
                strSQL = strSQL & .OrdD_010 & ","                      '見積販売単価
                strSQL = strSQL & .OrdD_011 & ","                      '見積販売金額
                strSQL = strSQL & .OrdD_012 & ","                      '(見積原価単価)
                strSQL = strSQL & .OrdD_013 & ","                      '掛け率
                strSQL = strSQL & .OrdD_014 & ","                      '見積原価単価NET
                strSQL = strSQL & .OrdD_015 & ","                      '(見積原価金額)
                strSQL = strSQL & .OrdD_016 & ",'"                     '(粗利益)
                strSQL = strSQL & Now & "','"                          '追加日時
                '--- UPDATE 2011/11/01 青木 START --------------------------------------------------------------------------
                'strSQL = strSQL & KS.WsNumber & "')"                   'WSNO
                strSQL = strSQL & StaticWinApi.Wsnumber & "','"                  'WSNO
                '--- UPDATE 2011/11/01 青木 E N D --------------------------------------------------------------------------
                '--- INSERT 2011/11/01 青木 START --------------------------------------------------------------------------
                '--- UPDATE 2011/11/09 青木 START --------------------------------------------------------------------------
                '            strSQL = strSQL & EditSQLAddSQuot(.OrdD_038) & "',"    '仕入先名
                strSQL = strSQL & EditSQLAddSQuot(.OrdD_038) & "','"   '仕入先名
                '--- UPDATE 2011/11/09 青木 E N D --------------------------------------------------------------------------
                '--- INSERT 2011/11/09 青木 START --------------------------------------------------------------------------
                strSQL = strSQL & EditSQLAddSQuot(.OrdD_0381) & "',"   '仕入先コード
                '--- INSERT 2011/11/09 青木 E N D --------------------------------------------------------------------------
                strSQL = strSQL & .OrdD_039 & ",'"                     '仕入先見積単価
                '            strSQL = strSQL & .OrdD_040 & "')"                     '入力日付           'DELETE 2016/02/05 AOKI
                '--- INSERT 2011/11/01 青木 E N D --------------------------------------------------------------------------
                strSQL = strSQL & .OrdD_040 & "',"                                          'INSERT 2016/02/05 AOKI

                'INSERT 2016/02/05 AOKI START -----------------------------------------------------------------------------------------
                If .OrdD_041 = "" Then
                    '                strSQL = strSQL & "null" & ")"                 'DELETE 2016/04/05 AOKI
                    strSQL = strSQL & "null" & ","                  'INSERT 2016/04/05 AOKI
                Else
                    '                strSQL = strSQL & .OrdD_041 & ")"              'DELETE 2016/04/05 AOKI
                    strSQL = strSQL & .OrdD_041 & ","               'INSERT 2016/04/05 AOKI
                End If
                '        End With                                               'DELETE 2016/04/05 AOKI
                'INSERT 2016/02/05 AOKI E N D -----------------------------------------------------------------------------------------
                'INSERT 2016/04/05 AOKI START -----------------------------------------------------------------------------------------
                If .OrdD_042 = "" Then
                    strSQL = strSQL & "null" & ")"
                Else
                    strSQL = strSQL & .OrdD_042 & ")"
                End If
            End With
            'INSERT 2016/04/05 AOKI E N D -----------------------------------------------------------------------------------------


            '===========================================

            'SQL文実行
            If dbsvc.ExecuteSql(strSQL, strMsg) = False Then
                GoTo Error_OrdDDatKousinProc
            End If

        Next Idx

        OrdDDatKousinProc = True

        Exit Function

Error_OrdDDatKousinProc:
        'エラーメッセージ表示
        Call ksExpMsgBox(gstGUIDE_E002 & " ERR: " & strMsg, "E")

    End Function

    '***************************************************************
    '**  名称    : DataDeleteProc()
    '**  機能    : データデリート処理。
    '**  戻り値  :
    '**  引数    :
    '**  備考    :
    '***************************************************************
    Public Function DataDeleteProc(vsMitsumoriNo As String,
                               viSEQ As Integer) As Boolean

        Dim strSQL As String  'SQL文作成用
        Dim strMsg As String  'エラーメッセージ作成用
        Dim lngErr As Long    'エラー番号
        Dim Idx As Integer

        DataDeleteProc = False

        'セッション開始
        dbsvc.BeginTrans()

        '見積(中ヘッダー)データ削除用SQL文作成
        '========================================================
        strSQL = ""
        strSQL = strSQL & "DELETE FROM OrdM_Dat "
        strSQL = strSQL & " WHERE OrdM_002 ='" & EditSQLAddSQuot(vsMitsumoriNo) & "'"
        strSQL = strSQL & "   AND OrdM_003 = " & viSEQ
        '========================================================

        'SQL文実行
        If dbsvc.ExecuteSql(strSQL, strMsg) = False Then
            GoTo Error_DataDeleteProc
        End If

        '見積(明細)データ削除用SQL文作成
        '========================================================
        strSQL = ""
        strSQL = strSQL & "DELETE FROM OrdD_Dat "
        strSQL = strSQL & " WHERE OrdD_002 ='" & EditSQLAddSQuot(vsMitsumoriNo) & "'"
        strSQL = strSQL & "   AND OrdD_003 = " & viSEQ
        '========================================================

        'SQL文実行
        If dbsvc.ExecuteSql(strSQL, strMsg) = False Then
            GoTo Error_DataDeleteProc
        End If

        'SEQデータ読み込み処理
        If OrdMDatReadProc(vsMitsumoriNo, 0, 2) = False Then
            If ksExpMsgBox("見積№：" & vsMitsumoriNo & " のSEQデータはありません、ヘッダーデータの削除を行いますか？", "Q") = vbYes Then
                '見積(ヘッダー)データ削除用SQL文作成
                '========================================================
                strSQL = ""
                strSQL = strSQL & "DELETE FROM OrdH_Dat "
                strSQL = strSQL & " WHERE OrdH_009 ='" & EditSQLAddSQuot(vsMitsumoriNo) & "'"
                '========================================================
                'SQL文実行
                If dbsvc.ExecuteSql(strSQL, strMsg) = False Then
                    GoTo Error_DataDeleteProc
                End If
            End If
        End If

        'コミット
        dbsvc.CommitTrans()

        DataDeleteProc = True

        Exit Function

Error_DataDeleteProc:
        '処理を戻す（ロールバック）
        Call dbsvc.RollbackTran()
        'エラーメッセージ表示
        Call ksExpMsgBox(gstGUIDE_E002 & " ERR: " & strMsg, "E")

    End Function

    '***************************************************************
    '**  名称    : Sub OrdHDatReadProc()
    '**  機能    : 見積データ(ヘッダー)の読込み処理
    '**  戻り値  :
    '**  引数    : vsMitsumoriNo : 見積№
    '**          : viMode  0:データ読み込み
    '**          :         1:存在チェック
    '**  備考    :
    '***************************************************************
    Public Function OrdHDatReadProc(vsMitsumoriNo As String,
                                viMode As Integer) As Boolean


        Dim SQLtxt As String


        If viMode = 0 Then
            'Erase OrdHDat '見積データ(ヘッダー)内部変数クリア
        End If

        OrdHDatReadProc = False

        '見積データ(ヘッダー)読込み用SQL文作成
        '================================================================
        With OrdHDat(0)
            SQLtxt = ""
            SQLtxt = SQLtxt & " SELECT * FROM OrdH_Dat"
            SQLtxt = SQLtxt & " WHERE OrdH_009 ='" & vsMitsumoriNo & "'"
        End With
        '================================================================

        '見積データ(ヘッダー)の読込み
        Dim dt As DataTable = New DataTable()
        dbsvc = New clsDB.DBService()

        dt = dbsvc.GetDatafromDB(SQLtxt)

        If dt.Rows.Count() > 0 Then
            If viMode = 0 Then
                With OrdHDat(0)
                    .OrdH_001 = NCnvN(dt.Rows(0)("OrdH_001"))      ' 契約№
                    .OrdH_002 = NCnvN(dt.Rows(0)("OrdH_002"))      ' 契約日付
                    .OrdH_003 = NCnvN(dt.Rows(0)("OrdH_003"))      ' 得意先名(CUSTOMER)
                    .OrdH_0031 = NCnvZ(dt.Rows(0)("OrdH_0031"))    ' 得意先ｺｰﾄﾞ
                    .OrdH_0032 = NCnvN(dt.Rows(0)("OrdH_0032"))    ' 得意先名2               'INSERT 2014/04/04 AOKI
                    .OrdH_004 = NCnvN(dt.Rows(0)("OrdH_004"))      ' 得意先担当者(ATTN)
                    .OrdH_005 = NCnvN(dt.Rows(0)("OrdH_005"))      ' 客先依頼No(YOUR NO)
                    .OrdH_006 = NCnvN(dt.Rows(0)("OrdH_006"))      ' 船名(VESSEL NAME)
                    .OrdH_007 = NCnvN(dt.Rows(0)("OrdH_007"))      ' 造船所
                    .OrdH_008 = NCnvN(dt.Rows(0)("OrdH_008"))      ' 当社担当(OUR PERSON)
                    .OrdH_0081 = NCnvN(dt.Rows(0)("OrdH_0081"))    ' マニラ担当          'INSERT 2013/08/19 Manila AOKI
                    .OrdH_0082 = NCnvN(dt.Rows(0)("OrdH_0082"))    ' 見積担当            'INSERT 2019/04/25 AOKI
                    .OrdH_009 = NCnvN(dt.Rows(0)("OrdH_009"))      ' 見積No(OUR REF NO)
                    .OrdH_010 = NCnvN(dt.Rows(0)("OrdH_010"))      ' 見積日付
                    .OrdH_010 = IIf(.OrdH_010 = "1900/01/01", "", .OrdH_010)
                    '                .OrdH_011 = NCnvZ(dt.Rows(0)("OrdH_011"))      ' 見積時納期(DELIVERY TIME)      'DELETE 2016/04/05 AOKI
                    .OrdH_011 = NCnvN(dt.Rows(0)("OrdH_011"))      ' 見積時納期(DELIVERY TIME)       'INSERT 2016/04/05 AOKI
                    .OrdH_012 = NCnvN(dt.Rows(0)("OrdH_012"))      ' ｿｰｽ(SOURCE)
                    .OrdH_013 = NCnvN(dt.Rows(0)("OrdH_013"))      ' 国(CONTRY)
                    .OrdH_014 = NCnvN(dt.Rows(0)("OrdH_014"))      ' 適用
                    .OrdH_015 = NCnvZ(dt.Rows(0)("OrdH_015"))      ' 支払期間(Payment terms)
                    .OrdH_016 = NCnvZ(dt.Rows(0)("OrdH_016"))      ' 見積有効期間
                    .OrdH_017 = NCnvN(dt.Rows(0)("OrdH_017"))      ' 受)客先注文番号(YOUR REF NO)
                    .OrdH_018 = NCnvN(dt.Rows(0)("OrdH_018"))      ' 受)入荷予定日
                    .OrdH_019 = NCnvN(dt.Rows(0)("OrdH_019"))      ' 受)入荷場所
                    .OrdH_020 = NCnvN(dt.Rows(0)("OrdH_020"))      ' 受)受渡場所
                    .OrdH_021 = NCnvN(dt.Rows(0)("OrdH_021"))      ' 受)指定納期
                    .OrdH_022 = NCnvN(dt.Rows(0)("OrdH_022"))      ' 住所関連項目) 1.オーナ
                    .OrdH_023 = NCnvN(dt.Rows(0)("OrdH_023"))      ' 住所関連項目) 2.得意先
                    .OrdH_024 = NCnvN(dt.Rows(0)("OrdH_024"))      ' 住所関連項目) 3.住所
                    .OrdH_025 = NCnvN(dt.Rows(0)("OrdH_025"))      ' 住所関連項目) 4.電話他
                    .OrdH_026 = NCnvN(dt.Rows(0)("OrdH_026"))      ' 住所関連項目) 5.備考
                    .OrdH_027 = NCnvZ(dt.Rows(0)("OrdH_027"))      ' データ区分(0:見積ﾃﾞｰﾀ 1:見積ﾃﾞｰﾀ)
                    .OrdH_028 = NCnvN(dt.Rows(0)("OrdH_028"))      ' 見積書発行日
                    .OrdH_0281 = NCnvN(dt.Rows(0)("OrdH_0281"))    ' PROFORMA INVOICE発行日      'INSERT 2014/06/12 AOKI
                    .OrdH_029 = NCnvN(dt.Rows(0)("OrdH_029"))      ' 注文請書発行日
                    .OrdH_030 = NCnvN(dt.Rows(0)("OrdH_030"))      ' 契約台帳発行日
                    .OrdH_031 = NCnvN(dt.Rows(0)("OrdH_031"))      ' 納品書発行日
                    .OrdH_035 = NCnvZ(dt.Rows(0)("OrdH_035"))      ' オーナーコード
                    'INSERT 2013/05/16 AOKI START -----------------------------------------------------------------------------
                    .OrdH_037 = NCnvN(dt.Rows(0)("OrdH_037"))      ' 造船所
                    .OrdH_038 = NCnvN(dt.Rows(0)("OrdH_038"))      ' 船番
                    'INSERT 2013/05/16 AOKI E N D -----------------------------------------------------------------------------
                End With
            End If
        Else
            GoTo Exit_OrdHDatReadProc
        End If

        OrdHDatReadProc = True

Exit_OrdHDatReadProc:

        Exit Function

    End Function

    '***************************************************************
    '**  名称    : Sub OrdHDatReadProcIraiNo()
    '**  機能    : 見積データ(ヘッダー)の読込み処理(依頼№にて検索)
    '**  戻り値  :
    '**  引数    : vsIraiNo : 見積№
    '**          : viMode  0:データ読み込み
    '**          :         1:存在チェック
    '**  備考    :
    '***************************************************************
    ''Public Function OrdHDatReadProcIraiNo(vsIraiNo As String,viMode As Integer) As Boolean


    '***************************************************************
    '**  名称    : Sub OrdMDatReadProc()
    '**  機能    : 見積データ(中ヘッダー(SEQ))情報の読込み処理
    '**  戻り値  :
    '**  引数    : vsMitsumoriNo : 見積№
    '**          : viSEQ         : SEQ
    '**          : viMode        : 0 対象データ
    '**          :               : 1 前データ
    '**          :               : 2 次データ
    '**          :               : 3 存在チェックのみ
    '**  備考    :
    '***************************************************************
    Public Function OrdMDatReadProc(vsMitsumoriNo As String,
                                viSEQ As Integer,
                                Optional viMode As Integer = 0) As Boolean

        Dim SQLtxt As String

        Dim DCount As Integer

        OrdMDatReadProc = False

        If viMode <> 3 Then
            'Erase OrdMDat '見積データ(中ヘッダー(SEQ))内部変数クリア
        End If

        '見積データ(中ヘッダー(SEQ))情報読込み用SQL文作成
        '================================================================
        SQLtxt = ""
        SQLtxt = SQLtxt & " SELECT TOP 1 * FROM OrdM_Dat"
        SQLtxt = SQLtxt & " WHERE OrdM_002 ='" & vsMitsumoriNo & "'"
        Select Case viMode
            Case 0, 3 '対象データ
                SQLtxt = SQLtxt & "   AND OrdM_003 = " & viSEQ
                SQLtxt = SQLtxt & " ORDER BY OrdM_001,OrdM_002,OrdM_003"
            Case 1    '前データ
                SQLtxt = SQLtxt & "   AND OrdM_003 < " & viSEQ
                SQLtxt = SQLtxt & " ORDER BY OrdM_003 DESC"
            Case 2    '次データ
                SQLtxt = SQLtxt & "   AND OrdM_003 > " & viSEQ
                SQLtxt = SQLtxt & " ORDER BY OrdM_003"
        End Select
        '================================================================

        '見積データ(中ヘッダー(SEQ))の読込み
        Dim dt As DataTable = New DataTable()

        dt = dbsvc.GetDatafromDB(SQLtxt)

        If dt.Rows.Count() <= 0 Then
            GoTo Exit_OrdMDatReadProc
        End If

        DCount = 0

        'データ設定

        If viMode <> 3 Then
            With OrdMDat(0)
                .OrdM_001 = NCnvN(dt.Rows(0)("OrdM_001"))      ' 契約№
                .OrdM_002 = NCnvZ(dt.Rows(0)("OrdM_002"))      ' 見積№
                .OrdM_003 = NCnvZ(dt.Rows(0)("OrdM_003"))      ' SEQ
                .OrdM_004 = NCnvN(dt.Rows(0)("OrdM_004"))      ' UNIT
                .OrdM_005 = NCnvN(dt.Rows(0)("OrdM_005"))      ' MAKER
                .OrdM_006 = NCnvN(dt.Rows(0)("OrdM_006"))      ' TYPE
                .OrdM_007 = NCnvN(dt.Rows(0)("OrdM_007"))      ' SER/NO
                .OrdM_008 = NCnvN(dt.Rows(0)("OrdM_008"))      ' DWG/NO
                .OrdM_025 = NCnvN(dt.Rows(0)("OrdM_025"))      ' ADDITIONAL DETAILS
                .OrdM_009 = NCnvN(dt.Rows(0)("OrdM_009"))      ' COMMENT1
                .OrdM_010 = NCnvN(dt.Rows(0)("OrdM_010"))      ' COMMENT2
                .OrdM_011 = NCnvN(dt.Rows(0)("OrdM_011"))      ' COMMENT3
                .OrdM_012 = NCnvN(dt.Rows(0)("OrdM_012"))      ' COMMENT4
                .OrdM_013 = NCnvZ(dt.Rows(0)("OrdM_013"))      ' 見積数量
                .OrdM_014 = NCnvZ(dt.Rows(0)("OrdM_014"))      ' 見積金額
                .OrdM_015 = NCnvZ(dt.Rows(0)("OrdM_015"))      ' 見積数量
                .OrdM_016 = NCnvZ(dt.Rows(0)("OrdM_016"))      ' 見積金額
                .OrdM_017 = NCnvZ(dt.Rows(0)("OrdM_017"))      ' 発注数量
                .OrdM_018 = NCnvZ(dt.Rows(0)("OrdM_018"))      ' 発注金額
                .OrdM_019 = NCnvZ(dt.Rows(0)("OrdM_019"))      ' 仕入数量
                .OrdM_020 = NCnvZ(dt.Rows(0)("OrdM_020"))      ' 仕入金額
                .OrdM_021 = NCnvZ(dt.Rows(0)("OrdM_021"))      ' 売上数量
                .OrdM_022 = NCnvZ(dt.Rows(0)("OrdM_022"))      ' 売上金額
                .OrdM_023 = NCnvN(dt.Rows(0)("OrdM_023"))      ' 請求日付
            End With
        End If
        DCount = DCount + 1


        OrdMDatReadProc = True

Exit_OrdMDatReadProc:

        Exit Function

    End Function

    '***************************************************************
    '**  名称    : Sub OrdDDatReadProc()
    '**  機能    : 受注データ(明細)情報の読込み処理
    '**  戻り値  :
    '**  引数    : vsMitsumoriNo : 見積№
    '**          : viSEQ         : SEQ
    '**  備考    :
    '***************************************************************
    Public Function OrdDDatReadProc(vsMitsumoriNo As String,
                                viSEQ As Integer) As Boolean

        Dim SQLtxt As String

        Dim DCount As Integer

        OrdDDatReadProc = False

        'Erase OrdDDat '受注データ(明細)内部変数クリア

        '受注データ(明細)情報読込み用SQL文作成
        '================================================================
        SQLtxt = ""
        SQLtxt = SQLtxt & " SELECT * FROM OrdD_Dat"
        SQLtxt = SQLtxt & " WHERE OrdD_002 = '" & vsMitsumoriNo & "'"
        SQLtxt = SQLtxt & "   AND OrdD_003 =  " & viSEQ
        SQLtxt = SQLtxt & " ORDER BY OrdD_004"
        '================================================================

        '受注データ(明細)の読込み
        Dim dt As DataTable = New DataTable()

        dt = dbsvc.GetDatafromDB(SQLtxt)

        If dt.Rows.Count < 1 Then
            GoTo Exit_OrdDDatReadProc
        End If

        DCount = 0

        'データ設定
        For Each dr As DataRow In dt.Rows
            ReDim Preserve OrdDDat(DCount)
            With OrdDDat(DCount)
                .OrdD_001 = NCnvN(dt.Rows(0)("OrdD_001"))      ' 契約№
                .OrdD_002 = NCnvN(dt.Rows(0)("OrdD_002"))      ' 見積№
                .OrdD_003 = NCnvZ(dt.Rows(0)("OrdD_003"))      ' SEQ
                .OrdD_004 = NCnvZ(dt.Rows(0)("OrdD_004"))      ' 項目
                .OrdD_005 = NCnvN(dt.Rows(0)("OrdD_005"))      ' 品名
                .OrdD_006 = NCnvN(dt.Rows(0)("OrdD_006"))      ' 品番
                .OrdD_007 = NCnvN(dt.Rows(0)("OrdD_007"))      ' 仕入先名称
                .OrdD_0071 = NCnvZ(dt.Rows(0)("OrdD_0071"))    ' 仕入先ｺｰﾄﾞ
                .OrdD_008 = NCnvZ(dt.Rows(0)("OrdD_008"))      ' 見積数量
                .OrdD_009 = NCnvN(dt.Rows(0)("OrdD_009"))      ' 単位
                .OrdD_010 = NCnvZ(dt.Rows(0)("OrdD_010"))      ' 見積販売単価
                .OrdD_011 = NCnvZ(dt.Rows(0)("OrdD_011"))      ' 見積販売金額
                .OrdD_012 = NCnvZ(dt.Rows(0)("OrdD_012"))      ' (見積原価単価)
                .OrdD_013 = NCnvZ(dt.Rows(0)("OrdD_013"))      ' 掛け率
                .OrdD_014 = NCnvZ(dt.Rows(0)("OrdD_014"))      ' 見積原価単価NET
                .OrdD_015 = NCnvZ(dt.Rows(0)("OrdD_015"))      ' (見積原価金額)
                .OrdD_016 = NCnvZ(dt.Rows(0)("OrdD_016"))      ' (粗利益)
                .OrdD_017 = NCnvN(dt.Rows(0)("OrdD_017"))      ' 仕入先名
                .OrdD_018 = NCnvZ(dt.Rows(0)("OrdD_018"))      ' 受注数量
                .OrdD_019 = NCnvN(dt.Rows(0)("OrdD_019"))      ' 単位
                .OrdD_020 = NCnvZ(dt.Rows(0)("OrdD_020"))      ' 販売単価
                .OrdD_021 = NCnvZ(dt.Rows(0)("OrdD_021"))      ' (販売金額)
                .OrdD_022 = NCnvZ(dt.Rows(0)("OrdD_022"))      ' 発注数量
                .OrdD_023 = NCnvN(dt.Rows(0)("OrdD_023"))      ' 発注日付
                .OrdD_023 = IIf(.OrdD_023 = "1900/01/01", "", .OrdD_023)
                .OrdD_024 = NCnvZ(dt.Rows(0)("OrdD_024"))      ' 仕入数量
                .OrdD_025 = NCnvN(dt.Rows(0)("OrdD_025"))      ' 仕入日付
                .OrdD_025 = IIf(.OrdD_025 = "1900/01/01", "", .OrdD_025)
                .OrdD_026 = NCnvZ(dt.Rows(0)("OrdD_026"))      ' 売上数量
                .OrdD_027 = NCnvN(dt.Rows(0)("OrdD_027"))      ' 売上日付
                .OrdD_027 = IIf(.OrdD_027 = "1900/01/01", "", .OrdD_027)
                .OrdD_028 = NCnvZ(dt.Rows(0)("OrdD_028"))      ' 請求数量
                .OrdD_029 = NCnvN(dt.Rows(0)("OrdD_029"))      ' 請求日付
                .OrdD_029 = IIf(.OrdD_029 = "1900/01/01", "", .OrdD_029)
                .OrdD_030 = NCnvZ(dt.Rows(0)("OrdD_030"))      ' (受注残数量)
                .OrdD_031 = NCnvZ(dt.Rows(0)("OrdD_031"))      ' (発注残数量)
                .OrdD_032 = NCnvZ(dt.Rows(0)("OrdD_032"))      ' 発注済フラグ
                .OrdD_033 = NCnvZ(dt.Rows(0)("OrdD_033"))      ' 仕入済フラグ(完納)
                .OrdD_034 = NCnvZ(dt.Rows(0)("OrdD_034"))      ' 売上済フラグ(完納)
                .OrdD_035 = NCnvZ(dt.Rows(0)("OrdD_035"))      ' 請求済フラグ(完納)
                '--- INSERT 2011/11/01 青木 START --------------------------------------------------------------------------
                .OrdD_038 = NCnvN(dt.Rows(0)("OrdD_038"))      ' 仕入先名
                .OrdD_039 = NCnvZ(dt.Rows(0)("OrdD_039"))      ' 仕入先見積単価
                .OrdD_040 = NCnvN(dt.Rows(0)("OrdD_040"))      ' 売上日付
                .OrdD_040 = IIf(.OrdD_040 = "1900/01/01", "", .OrdD_040)
                '--- INSERT 2011/11/01 青木 E N D --------------------------------------------------------------------------
                '--- INSERT 2011/11/09 青木 START --------------------------------------------------------------------------
                .OrdD_0381 = NCnvN(dt.Rows(0)("OrdD_0381"))    ' 仕入先コード
                '--- INSERT 2011/11/09 青木 E N D --------------------------------------------------------------------------
                .OrdD_041 = NCnvN(dt.Rows(0)("OrdD_041"))      ' ORIGIN                  'INSERT 2016/02/05 AOKI
                .OrdD_042 = NCnvN(dt.Rows(0)("OrdD_042"))      ' Delivery Time           'INSERT 2016/04/05 AOKI
            End With
            DCount = DCount + 1
        Next

        OrdDDatReadProc = True

Exit_OrdDDatReadProc:

        Exit Function

    End Function

    '***************************************************************
    '**  名称    : Sub OrdDSortProc()
    '**  機能    : 受注データ(明細)情報の項目№並び替え処理
    '**  戻り値  :
    '**  引数    : vsMitsumoriNo : 見積№
    '**  備考    :
    '***************************************************************
    Public Function OrdDSortProc(vsMitsumoriNo As String) As Boolean

        Dim SQLtxt As String

        Dim strMsg As String  'エラーメッセージ作成用
        Dim lngErr As Long    'エラー番号
        Dim DCount As Integer
        Dim i As Integer
        Dim k1 As Integer     '項目ワーク1
        Dim liBefF As Integer     '前行フラグ(0:前行が通常行 1:前行がコメント行)
        Dim iKoumoku As Integer

        OrdDSortProc = False

        'セッション開始
        dbsvc.BeginTrans()

        Erase OrdDDat '受注データ(明細)内部変数クリア

        '受注データ(明細)情報読込み用SQL文作成
        '================================================================
        SQLtxt = ""
        SQLtxt = SQLtxt & " SELECT * FROM OrdD_Dat"
        SQLtxt = SQLtxt & " WHERE OrdD_002 = '" & vsMitsumoriNo & "'"
        SQLtxt = SQLtxt & " ORDER BY OrdD_003,OrdD_004"
        '================================================================

        '受注データ(明細)の読込み

        Dim dt As DataTable = New DataTable()

        dt = dbsvc.GetDatafromDB(SQLtxt)

        If dt.Rows.Count <= 1 Then
            GoTo Exit_OrdDSortProc
        End If

        DCount = 0

        'データ設定
        For Each dr As DataRow In dt.Rows
            ReDim Preserve OrdDDat(DCount)
            With OrdDDat(DCount)
                .OrdD_001 = NCnvN(dt.Rows(0)("OrdD_001"))      ' 契約№
                .OrdD_002 = NCnvN(dt.Rows(0)("OrdD_002"))      ' 見積№
                .OrdD_003 = NCnvZ(dt.Rows(0)("OrdD_003"))      ' SEQ
                .OrdD_004 = NCnvZ(dt.Rows(0)("OrdD_004"))      ' 項目
                .OrdD_005 = NCnvN(dt.Rows(0)("OrdD_005"))      ' 品名
                .OrdD_006 = NCnvN(dt.Rows(0)("OrdD_006"))      ' 品番
                .OrdD_007 = NCnvN(dt.Rows(0)("OrdD_007"))      ' 仕入先名称
                .OrdD_0071 = NCnvZ(dt.Rows(0)("OrdD_0071"))    ' 仕入先ｺｰﾄﾞ
                .OrdD_008 = NCnvZ(dt.Rows(0)("OrdD_008"))      ' 見積数量
                .OrdD_009 = NCnvN(dt.Rows(0)("OrdD_009"))      ' 単位
                .OrdD_010 = NCnvZ(dt.Rows(0)("OrdD_010"))      ' 見積販売単価
                .OrdD_011 = NCnvZ(dt.Rows(0)("OrdD_011"))      ' 見積販売金額
                .OrdD_012 = NCnvZ(dt.Rows(0)("OrdD_012"))      ' (見積原価単価)
                .OrdD_013 = NCnvZ(dt.Rows(0)("OrdD_013"))      ' 掛け率
                .OrdD_014 = NCnvZ(dt.Rows(0)("OrdD_014"))      ' 見積原価単価NET
                .OrdD_015 = NCnvZ(dt.Rows(0)("OrdD_015"))      ' (見積原価金額)
                .OrdD_016 = NCnvZ(dt.Rows(0)("OrdD_016"))      ' (粗利益)
                '--- INSERT 2011/11/01 青木 START --------------------------------------------------------------------------
                .OrdD_038 = NCnvN(dt.Rows(0)("OrdD_038"))      ' 仕入先名
                .OrdD_039 = NCnvZ(dt.Rows(0)("OrdD_039"))      ' 仕入先見積単価
                .OrdD_040 = NCnvN(dt.Rows(0)("OrdD_040"))      ' 入力日付
                '--- INSERT 2011/11/01 青木 E N D --------------------------------------------------------------------------
                '--- INSERT 2011/11/09 青木 START --------------------------------------------------------------------------
                .OrdD_0381 = NCnvN(dt.Rows(0)("OrdD_0381"))      ' 仕入先コード
                '--- INSERT 2011/11/09 青木 E N D --------------------------------------------------------------------------
                .OrdD_041 = NCnvN(dt.Rows(0)("OrdD_041"))      ' ORIGIN                  'INSERT 2016/02/05 AOKI
                .OrdD_042 = NCnvN(dt.Rows(0)("OrdD_042"))      ' Delivery Time           'INSERT 2016/04/05 AOKI
            End With

            DCount = DCount + 1
        Next

        If OrdDUBound(OrdDDat) > -1 Then

            '削除用SQL文作成
            '========================================================
            SQLtxt = ""
            SQLtxt = SQLtxt & "DELETE FROM OrdD_Dat "
            SQLtxt = SQLtxt & " WHERE OrdD_002 ='" & EditSQLAddSQuot(vsMitsumoriNo) & "'"
            '========================================================

            'SQL文実行
            If dbsvc.ExecuteSql(SQLtxt, strMsg) = False Then
                GoTo Exit_OrdDSortProc
            End If

            k1 = 1
            liBefF = 0

            For i = LBound(OrdDDat) To UBound(OrdDDat)

                '追加用SQL文作成
                '===========================================
                With OrdDDat(i)

                    '項目算出
                    '通常行の場合は 　　"0011,0021,0031..."
                    'コメント行の場合は "0010,0020,0030..."
                    If .OrdD_008 > 0 Or .OrdD_009 <> "" Or .OrdD_011 > 0 Then
                        '通常行の場合(数量か単位か金額が入力されていれば通常行として扱う)
                        iKoumoku = CInt(Format(k1, "0000") & "1")
                        .OrdD_004 = NCnvZ(iKoumoku)
                        k1 = k1 + 1
                        liBefF = 0
                    Else
                        'コメント行の場合
                        If liBefF = 1 Then
                            '前行がコメント行ならば、＋１
                            k1 = k1 + 1
                        End If
                        iKoumoku = CInt(Format(k1, "0000") & "0")
                        .OrdD_004 = NCnvZ(iKoumoku)
                        liBefF = 1
                    End If

                    SQLtxt = ""
                    SQLtxt = SQLtxt & "INSERT INTO OrdD_Dat("
                    SQLtxt = SQLtxt & "OrdD_001,"           '契約№
                    SQLtxt = SQLtxt & "OrdD_002,"           '見積№
                    SQLtxt = SQLtxt & "OrdD_003,"           'SEQ
                    SQLtxt = SQLtxt & "OrdD_004,"           '項目
                    SQLtxt = SQLtxt & "OrdD_005,"           '品名
                    SQLtxt = SQLtxt & "OrdD_006,"           '品番
                    SQLtxt = SQLtxt & "OrdD_007,"           '仕入先名称
                    SQLtxt = SQLtxt & "OrdD_0071,"          '仕入先ｺｰﾄﾞ
                    SQLtxt = SQLtxt & "OrdD_008,"           '見積数量
                    SQLtxt = SQLtxt & "OrdD_009,"           '単位
                    SQLtxt = SQLtxt & "OrdD_010,"           '見積販売単価
                    SQLtxt = SQLtxt & "OrdD_011,"           '見積販売金額
                    SQLtxt = SQLtxt & "OrdD_012,"           '(見積原価単価)
                    SQLtxt = SQLtxt & "OrdD_013,"           '掛け率
                    SQLtxt = SQLtxt & "OrdD_014,"           '見積原価単価NET
                    SQLtxt = SQLtxt & "OrdD_015,"           '(見積原価金額)
                    SQLtxt = SQLtxt & "OrdD_016,"           '(粗利益)
                    SQLtxt = SQLtxt & "OrdD_Insert,"        '追加日時
                    '--- UPDATE 2011/11/01 青木 START --------------------------------------------------------------------------
                    'SQLtxt = SQLtxt & "OrdD_WsNo"           'WSNO
                    SQLtxt = SQLtxt & "OrdD_WsNo,"          'WSNO
                    '--- UPDATE 2011/11/01 青木 E N D --------------------------------------------------------------------------
                    '--- INSERT 2011/11/01 青木 START --------------------------------------------------------------------------
                    SQLtxt = SQLtxt & "OrdD_038,"           '仕入先名
                    '--- INSERT 2011/11/09 青木 START --------------------------------------------------------------------------
                    SQLtxt = SQLtxt & "OrdD_0381,"          '仕入先コード
                    '--- INSERT 2011/11/09 青木 E N D --------------------------------------------------------------------------
                    SQLtxt = SQLtxt & "OrdD_039,"           '仕入先見積単価
                    '                SQLtxt = SQLtxt & "OrdD_040"            '入力日付                          'DELETE 2016/02/05 AOKI
                    SQLtxt = SQLtxt & "OrdD_040,"           '入力日付                           'INSERT 2016/02/05 AOKI
                    '                SQLtxt = SQLtxt & "OrdD_041"            'ORIGIN                            'INSERT 2016/02/05 AOKI 'DELETE 2016/04/05 AOKI
                    SQLtxt = SQLtxt & "OrdD_041,"           'ORIGIN                             'INSERT 2016/04/05 AOKI
                    SQLtxt = SQLtxt & "OrdD_042"            'Delivery Time                      'INSERT 2016/04/05 AOKI
                    '--- INSERT 2011/11/01 青木 E N D --------------------------------------------------------------------------
                    SQLtxt = SQLtxt & ") VALUES ('"
                    SQLtxt = SQLtxt & EditSQLAddSQuot(.OrdD_001) & "','"    '契約№
                    SQLtxt = SQLtxt & EditSQLAddSQuot(.OrdD_002) & "',"     '見積№
                    SQLtxt = SQLtxt & .OrdD_003 & ","                       'SEQ
                    SQLtxt = SQLtxt & .OrdD_004 & ",'"                      '項目
                    SQLtxt = SQLtxt & EditSQLAddSQuot(.OrdD_005) & "','"    '品名
                    SQLtxt = SQLtxt & EditSQLAddSQuot(.OrdD_006) & "','"    '品番
                    SQLtxt = SQLtxt & EditSQLAddSQuot(.OrdD_007) & "',"     '仕入先名称
                    SQLtxt = SQLtxt & .OrdD_0071 & ","                      '仕入先ｺｰﾄﾞ
                    SQLtxt = SQLtxt & .OrdD_008 & ",'"                      '見積数量
                    SQLtxt = SQLtxt & EditSQLAddSQuot(.OrdD_009) & "',"     '単位
                    SQLtxt = SQLtxt & .OrdD_010 & ","                       '見積販売単価
                    SQLtxt = SQLtxt & .OrdD_011 & ","                       '見積販売金額
                    SQLtxt = SQLtxt & .OrdD_012 & ","                       '(見積原価単価)
                    SQLtxt = SQLtxt & .OrdD_013 & ","                       '掛け率
                    SQLtxt = SQLtxt & .OrdD_014 & ","                       '見積原価単価NET
                    SQLtxt = SQLtxt & .OrdD_015 & ","                       '(見積原価金額)
                    SQLtxt = SQLtxt & .OrdD_016 & ",'"                      '(粗利益)
                    SQLtxt = SQLtxt & Now & "','"                           '追加日時
                    '--- UPDATE 2011/11/01 青木 START --------------------------------------------------------------------------
                    'SQLtxt = SQLtxt & KS.WsNumber & "')"                    'WSNO
                    SQLtxt = SQLtxt & StaticWinApi.Wsnumber & "','"                   'WSNO
                    '--- UPDATE 2011/11/01 青木 E N D --------------------------------------------------------------------------
                    '--- INSERT 2011/11/01 青木 START --------------------------------------------------------------------------
                    '--- UPDATE 2011/11/09 青木 START --------------------------------------------------------------------------
                    '                SQLtxt = SQLtxt & EditSQLAddSQuot(.OrdD_038) & "',"     '仕入先名
                    SQLtxt = SQLtxt & EditSQLAddSQuot(.OrdD_038) & "','"    '仕入先名
                    '--- UPDATE 2011/11/09 青木 E N D --------------------------------------------------------------------------
                    '--- INSERT 2011/11/09 青木 START --------------------------------------------------------------------------
                    SQLtxt = SQLtxt & EditSQLAddSQuot(.OrdD_0381) & "',"    '仕入先コード
                    '--- INSERT 2011/11/09 青木 E N D --------------------------------------------------------------------------
                    SQLtxt = SQLtxt & .OrdD_039 & ",'"                      '仕入先見積単価
                    '                SQLtxt = SQLtxt & .OrdD_040 & "')"                      '入力日付          'DELETE 2016/02/05 AOKI
                    SQLtxt = SQLtxt & .OrdD_040 & "',"                      '入力日付           'INSERT 2016/02/05 AOKI
                    'INSERT 2016/02/05 AOKI START -----------------------------------------------------------------------------------------
                    If .OrdD_041 = "" Then
                        '                    SQLtxt = SQLtxt & "null" & ")"                      'ORIGIN            'DELETE 2016/04/05 AOKI
                        SQLtxt = SQLtxt & "null" & ","                      'ORIGIN             'INSERT 2016/04/05 AOKI
                    Else
                        '                    SQLtxt = SQLtxt & .OrdD_041 & ")"                   'ORIGIN            'DELETE 2016/04/05 AOKI
                        SQLtxt = SQLtxt & .OrdD_041 & ","                   'ORIGIN             'INSERT 2016/04/05 AOKI
                    End If
                    'INSERT 2016/02/05 AOKI E N D -----------------------------------------------------------------------------------------
                    'INSERT 2016/04/05 AOKI START -----------------------------------------------------------------------------------------
                    If .OrdD_042 = "" Then
                        SQLtxt = SQLtxt & "null" & ")"                      'Delivery Time
                    Else
                        SQLtxt = SQLtxt & .OrdD_042 & ")"                   'Delivery Time
                    End If
                    'INSERT 2016/04/05 AOKI E N D -----------------------------------------------------------------------------------------
                    '--- INSERT 2011/11/01 青木 E N D --------------------------------------------------------------------------
                End With
                '===========================================

                'SQL文実行
                If dbsvc.ExecuteSql(SQLtxt, strMsg) = False Then
                    GoTo Exit_OrdDSortProc
                End If


            Next i

        End If

        'コミット
        Call dbsvc.CommitTrans()

        OrdDSortProc = True

        Exit Function

Exit_OrdDSortProc:

        dbsvc.RollbackTran()

        Exit Function

    End Function

    '***************************************************************
    '**  名称    : Sub SetGoukeiArea()
    '**  機能    : 各合計情報の取得＆表示
    '**  戻り値  :
    '**  引数    : vfForm        : フォーム
    '**          : vsMitsumoriNo : 見積№
    '**  備考    :
    '***************************************************************
    ' Public Function SetGoukeiArea(vfForm As Form, vsMitsumoriNo As String) As Boolean



    '***************************************************************
    '**  名称    : Sub GetLastSEQ()
    '**  機能    : 最終SEQの取得
    '**  戻り値  :
    '**  引数    : vsMitsumoriNo : 見積№
    '**  備考    :
    '***************************************************************
    Public Function GetLastSEQ(vsMitsumoriNo As String) As Decimal

        Dim SQLtxt As String


        GetLastSEQ = 0

        '見積データ(中ヘッダー(SEQ))情報読込み用SQL文作成
        '================================================================
        SQLtxt = ""
        SQLtxt = SQLtxt & " SELECT TOP 1 * FROM OrdM_Dat"
        SQLtxt = SQLtxt & " WHERE OrdM_002 ='" & vsMitsumoriNo & "'"
        SQLtxt = SQLtxt & " ORDER BY OrdM_003 DESC"
        '================================================================

        '見積データ(中ヘッダー(SEQ))の読込み
        Dim dt As DataTable = New DataTable()

        dt = dbsvc.GetDatafromDB(SQLtxt)

        'データ設定
        If dt.Rows.Count() > 0 Then
            GetLastSEQ = NCnvZ(dt.Rows(0)("OrdM_003"))
        End If

Exit_GetLastSEQ:

        Exit Function

    End Function
    '***************************************************************
    '**  名称    : Function NouhinDataUpdateSQL()
    '**  機能    : データ追加ＳＱＬを作成
    '**  戻り値  :
    '**  引数    :
    '**  備考    :
    '***************************************************************
    Public Function GetNewEstimateNo(ByVal strnumber As Long) As String
        Dim ConMst(0 To 0) As ConMstInfo
        Dim lsYY As String
        Dim lsSEQ As String

        GetNewEstimateNo = ""

        'Erase ConMst

        '== コントロールマスタより最終見積番号取得 ========================
        If GetConMstInfo(ConMst(0)) = True Then
            '--- UPDATE 2012/11/22 AOKI START --------------------------------------------------------------
            'If ConMst(1).Con_025 = 9999 Then
            '            lsSEQ = "0001"
            '        Else
            '            lsSEQ = Format(ConMst(1).Con_025 + 1, "0000")
            '        End If

            If ConMst(0).Con_025 = 99999 Then
                lsSEQ = "00001"
            Else
                lsSEQ = Format(ConMst(0).Con_025 + 1, "00000")
            End If
            '--- UPDATE 2012/11/22 AOKI E N D --------------------------------------------------------------
        End If

        lsYY = Mid(Format(strnumber, "00000000"), 3, 2)

        GetNewEstimateNo = lsYY & "E-" & lsSEQ

    End Function

    '***************************************************************
    '**  名称    : Function UpdateEstimateNo()
    '**  機能    : コントロールマスタの最終見積№を更新する
    '**  戻り値  :
    '**  引数    :
    '**  備考    :
    '***************************************************************
    Public Function UpdateEstimateNo(vsEstimateNo As String) As Boolean

        Dim strSQL As String   'SQL文作成用
        Dim strMsg As String   'エラーメッセージ作成用
        Dim lngErr As Long     'エラー番号
        Dim lcEstimate As Decimal '見積№

        UpdateEstimateNo = False

        '見積№算出
        lcEstimate = Convert.ToDecimal(Right(vsEstimateNo, Len(vsEstimateNo) - InStr(1, vsEstimateNo, "-")))


        Dim dbsvc As New clsDB.DBService()


        '更新用SQL文作成
        '=====================================================================
        strSQL = "UPDATE Con_Mst SET "
        strSQL = strSQL & "Con_025 = " & lcEstimate
        strSQL = strSQL & "  WHERE Con_001 = 1"
        '=====================================================================

        'SQL文実行
        If dbsvc.ExecuteSql(strSQL, strMsg) = False Then
            GoTo Error_UpdateEstimateNo
        End If

        UpdateEstimateNo = True

        Exit Function

Error_UpdateEstimateNo:

        Call ksExpMsgBox(gstGUIDE_E003 & " ERR: " & strMsg, "E") 'エラーメッセージ表示

    End Function

    '***************************************************************
    '**  名称    : Sub OrdDUBound()
    '**  機能    : 受注明細データ配列の要素数を返す
    '**  戻り値  : 配列数 -1は配列無し
    '**  引数    : 対象動的配列
    '**  備考    :
    '***************************************************************
    Public Function OrdDUBound(strAr() As OrdDDatInfo) As Long

        On Error GoTo OrdDUBound_ERR

        OrdDUBound = UBound(strAr)

        Exit Function


OrdDUBound_ERR:

        If Err.Number = 9 Then
            OrdDUBound = -1
        End If

    End Function

End Module
