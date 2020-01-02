Imports System.Windows.Forms

Public Module modSinseiMarin
    Public Structure OrdHDatInfo
        Public OrdH_001 As String       '契約№
        Public OrdH_002 As String       '契約日付
        Public OrdH_003 As String       '得意先名(CUSTOMER)
        Public OrdH_0031 As Decimal
        '得意先ｺｰﾄﾞ
        Public OrdH_0032 As String       '得意先名2              'INSERT 2014/04/04 AOKI
        Public OrdH_004 As String       '得意先担当者(ATTN)
        Public OrdH_005 As String       '客先依頼No(YOUR NO)
        Public OrdH_006 As String       '船名(VESSEL NAME)
        Public OrdH_007 As String       '造船所
        Public OrdH_008 As String       '当社担当(OUR PERSON)
        Public OrdH_0081 As String       'マニラ担当             'INSERT 2013/08/19 Manila AOKI\
        Public OrdH_0082 As String       '
        Public OrdH_009 As String       '見積No(OUR REF NO)
        Public OrdH_010 As String       '見積日付
        Public OrdH_011 As String       '見積時納期(DELIVERY TIME)
        Public OrdH_012 As String       'ｿｰｽ(SOURCE)
        Public OrdH_013 As String       '国(CONTRY)
        Public OrdH_014 As String       '適用
        Public OrdH_015 As Integer      '支払期間(Payment terms)
        Public OrdH_016 As Integer      '見積有効期間
        Public OrdH_017 As String       '受)客先注文番号(YOUR REF NO)
        Public OrdH_018 As String       '受)入荷予定日
        Public OrdH_019 As String       '受)入荷場所
        Public OrdH_020 As String       '受)受渡場所
        Public OrdH_021 As String       '受)指定納期
        Public OrdH_022 As String       '住所関連項目) 1.オーナ
        Public OrdH_023 As String       '住所関連項目) 2.得意先
        Public OrdH_024 As String       '住所関連項目) 3.住所
        Public OrdH_025 As String       '住所関連項目) 4.電話他
        Public OrdH_026 As String       '住所関連項目) 5.備考
        Public OrdH_027 As Integer      'データ区分(0:見積ﾃﾞｰﾀ 1:見積ﾃﾞｰﾀ)
        Public OrdH_028 As String       '見積書発行日
        Public OrdH_0281 As String       'PROFORMA INVOICE発行日             'INSERT 2014/06/12 AOKI
        Public OrdH_029 As String       '注文請書発行日
        Public OrdH_030 As String       '契約台帳発行日
        Public OrdH_031 As String       '納品書発行日
        Public OrdH_032 As String       '受領書発行日
        Public OrdH_033 As String       'ｶｽﾀﾑｲﾝﾎﾞｲｽ発行日
        Public OrdH_034 As String       '最終売上日
        Public OrdH_035 As String       'オーナーコード
        Public OrdH_036 As String       '請求住所                           'INSERT 2014/10/10 AOKI
        'INSERT 2013/05/16 AOKI START -----------------------------------------------------------------------------
        Public OrdH_037 As String       '造船所
        Public OrdH_038 As String       '船番
        'INSERT 2013/05/16 AOKI E N D -----------------------------------------------------------------------------
    End Structure

    '見積データ(中ヘッダー(SEQ))情報
    Public Structure OrdMDatInfo
        Public OrdM_001 As String       '契約№
        Public OrdM_002 As String       '見積№
        Public OrdM_003 As Integer      'SEQ
        Public OrdM_004 As String       'UNIT
        Public OrdM_005 As String       'MAKER
        Public OrdM_006 As String       'TYPE
        Public OrdM_007 As String       'SER/NO
        Public OrdM_008 As String       'DWG/NO
        Public OrdM_025 As String       'ADDITIONAL DETAILS
        Public OrdM_009 As String       'COMMENT1
        Public OrdM_010 As String       'COMMENT2
        Public OrdM_011 As String       'COMMENT3
        Public OrdM_012 As String       'COMMENT4
        Public OrdM_013 As Decimal     '見積数量
        Public OrdM_014 As Decimal     '見積金額
        Public OrdM_015 As Decimal     '受注数量
        Public OrdM_016 As Decimal     '受注金額
        Public OrdM_017 As Decimal     '発注数量
        Public OrdM_018 As Decimal     '発注金額
        Public OrdM_019 As Decimal     '仕入数量
        Public OrdM_020 As Decimal     '仕入金額
        Public OrdM_021 As Decimal     '売上数量
        Public OrdM_022 As Decimal     '売上金額
        Public OrdM_023 As String       '請求日付
        Public OrdM_027 As String       '見積SEQ                'INSERT 2015/09/15 AOKI
        Public OrdM_028 As String       'YourRefNo              'INSERT 2015/09/15 AOKI
    End Structure

    '見積データ(明細)情報
    Public Structure OrdDDatInfo
        Public OrdD_001 As String       '契約№
        Public OrdD_002 As String       '見積№
        Public OrdD_003 As Integer      'SEQ
        Public OrdD_004 As String       '項目
        Public OrdD_005 As String       '品名
        Public OrdD_006 As String       '品番
        Public OrdD_007 As String       '仕入先名称
        Public OrdD_0071 As Decimal     '仕入先ｺｰﾄﾞ
        Public OrdD_008 As String       '見積数量
        Public OrdD_009 As String       '単位
        Public OrdD_010 As String       '見積販売単価
        Public OrdD_011 As String       '見積販売金額
        Public OrdD_012 As String       '(見積原価単価)
        Public OrdD_013 As Decimal     '掛け率
        Public OrdD_014 As Decimal     '見積原価単価NET
        Public OrdD_015 As Decimal     '(見積原価金額)
        Public OrdD_016 As Decimal     '(粗利益)
        Public OrdD_017 As String       '仕入先名
        Public OrdD_018 As Decimal     '受注数量
        Public OrdD_019 As String       '受注単位
        Public OrdD_020 As Decimal     '受注販売単価
        Public OrdD_021 As Decimal     '(受注販売金額)
        Public OrdD_022 As Decimal     '発注数量
        Public OrdD_023 As String       '発注日付
        Public OrdD_024 As Decimal     '仕入数量
        Public OrdD_0241 As Decimal     '仕入金額
        Public OrdD_025 As String       '仕入日付
        Public OrdD_026 As Decimal     '売上数量
        Public OrdD_0262 As Decimal     '売上単価
        Public OrdD_0261 As Decimal     '売上金額
        Public OrdD_027 As String       '売上日付
        Public OrdD_028 As Decimal     '請求数量
        Public OrdD_029 As String       '請求日付
        Public OrdD_030 As Decimal     '(見積残数量)
        Public OrdD_031 As Decimal     '(発注残数量)
        Public OrdD_032 As Decimal     '発注済フラグ
        Public OrdD_033 As String       '仕入済フラグ(完納)
        Public OrdD_034 As Decimal     '売上済フラグ(完納)
        Public OrdD_035 As Decimal     '請求済フラグ(完納)
        '--public - INSERT 2011/11/01 青木 START --------------------------------------------------------------------------
        Public OrdD_038 As String       '仕入先名
        Public OrdD_039 As Decimal     '仕入先見積単価
        Public OrdD_040 As String       '入力日付
        '--public - INSERT 2011/11/01 青木 E N D --------------------------------------------------------------------------
        '--public - INSERT 2011/11/09 青木 START --------------------------------------------------------------------------
        Public OrdD_0381 As String       '仕入先コード
        '--public - INSERT 2011/11/09 青木 E N D --------------------------------------------------------------------------
        Public OrdD_041 As String       'ORIGIN                 'INSERT 2016/02/05 AOKI
        Public OrdD_042 As String       'DELIVERY TIME          'INSERT 2016/02/09 AOKI
    End Structure

    '受注データ(ヘッダー)情報
    Public Structure JyuHDatInfo
        Public JyuH_001 As String       '契約№
        Public JyuH_002 As String       '契約日付
        Public JyuH_003 As String       '得意先名(CUSTOMER)
        Public JyuH_0031 As Decimal     '得意先ｺｰﾄﾞ
        Public JyuH_004 As String       '得意先担当者(ATTN)
        Public JyuH_005 As String       '客先依頼No(YOUR NO)
        Public JyuH_006 As String       '船名(VESSEL NAME)
        Public JyuH_007 As String       '造船所
        Public JyuH_008 As String       '当社担当(OUR PERSON)
        Public JyuH_0081 As String       'Manila PIC             'INSERT 2013/10/21 Manila AOKI
        Public JyuH_009 As String       '見積No(OUR REF NO)
        Public JyuH_010 As String       '見積日付
        Public JyuH_011 As String       '見積時納期(DELIVERY TIME)
        Public JyuH_012 As String       'ｿｰｽ(SOURCE)
        Public JyuH_013 As String       '国(CONTRY)
        Public JyuH_014 As String       '適用
        Public JyuH_015 As Integer      '支払期間(Payment terms)
        Public JyuH_016 As Integer      '見積有効期間
        Public JyuH_017 As String       '受)客先注文番号(YOUR REF NO)
        Public JyuH_018 As String       '受)入荷予定日
        Public JyuH_019 As String       '受)入荷場所
        Public JyuH_020 As String       '受)受渡場所
        Public JyuH_021 As String       '受)指定納期
        Public JyuH_022 As String       '住所関連項目) 1.オーナ
        Public JyuH_023 As String       '住所関連項目) 2.得意先
        Public JyuH_024 As String       '住所関連項目) 3.住所
        Public JyuH_025 As String       '住所関連項目) 4.電話他
        Public JyuH_026 As String       '住所関連項目) 5.備考
        Public JyuH_027 As Integer      'データ区分(0:見積ﾃﾞｰﾀ 1:受注ﾃﾞｰﾀ)
        Public JyuH_028 As String       '見積書発行日
        Public JyuH_029 As String       '注文請書発行日
        Public JyuH_030 As String       '契約台帳発行日
        Public JyuH_031 As String       '納品書発行日
        Public JyuH_032 As String       '受領書発行日
        Public JyuH_033 As String       'ｶｽﾀﾑｲﾝﾎﾞｲｽ発行日
        Public JyuH_034 As String       '最終売上日
        Public JyuH_035 As String       'オーナーコード
        Public JyuH_036 As String       '請求住所               'INSERT 2013/02/13 請求住所 AOKI
        Public SeiD_001 As String       '請求№

        Public JyuH_037 As String       '造船所
        Public JyuH_038 As String       '船番

        Public JyuH_IMO As Long         'IMO                    'INSERT 2017/04/05 AOKI

        '    JyuH_041        As Integer      '削除フラグ             'INSERT 2015/12/02 AOKI

    End Structure





    '受注データ(中ヘッダー(SEQ))情報
    Public Structure JyuMDatInfo
        Public JyuM_001 As String       '契約№
        Public JyuM_002 As String       '見積№
        Public JyuM_003 As Integer      'SEQ
        Public JyuM_004 As String       'UNIT
        Public JyuM_005 As String       'MAKER
        Public JyuM_006 As String       'TYPE
        Public JyuM_007 As String       'SER/NO
        Public JyuM_008 As String       'DWG/NO
        Public JyuM_025 As String       'ADDITIONAL DETAILS
        Public JyuM_009 As String       'COMMENT1
        Public JyuM_010 As String       'COMMENT2
        Public JyuM_011 As String       'COMMENT3
        Public JyuM_012 As String       'COMMENT4
        Public JyuM_0121 As String       'COMMENT5               'INSERT 2014/01/30 AOKI
        Public JyuM_013 As Decimal     '見積数量
        Public JyuM_014 As Decimal     '見積金額
        Public JyuM_015 As Decimal     '受注数量
        Public JyuM_016 As Decimal     '受注金額
        Public JyuM_017 As Decimal     '発注数量
        Public JyuM_018 As Decimal     '発注金額
        Public JyuM_019 As Decimal     '仕入数量
        Public JyuM_020 As Decimal     '仕入金額

        Public JyuM_021 As Decimal     '売上数量
        Public JyuM_022 As Decimal     '売上金額

        Public JyuM_023 As String       '請求日付
    End Structure

    '受注データ(明細)情報
    Public Structure JyuDDatInfo
        Public JyuD_001 As String       '契約№
        Public JyuD_002 As String       '見積№
        Public JyuD_003 As Integer      'SEQ
        Public JyuD_004 As String       '項目
        Public JyuD_005 As String       '品名
        Public JyuD_006 As String       '品番
        Public JyuD_007 As String       '仕入先名称
        Public JyuD_0071 As Decimal     '仕入先ｺｰﾄﾞ
        Public JyuD_008 As String       '見積数量
        Public JyuD_009 As String       '単位
        Public JyuD_010 As String       '見積販売単価
        Public JyuD_011 As String       '見積販売金額
        Public JyuD_012 As String       '(見積原価単価)
        Public JyuD_013 As Decimal     '掛け率
        Public JyuD_014 As Decimal     '見積原価単価NET
        Public JyuD_015 As Decimal     '(見積原価金額)
        Public JyuD_016 As Decimal     '(粗利益)
        Public JyuD_017 As String       '仕入先名
        Public JyuD_018 As Decimal     '受注数量
        Public JyuD_019 As String       '単位
        Public JyuD_020 As Decimal     '販売単価
        Public JyuD_021 As Decimal     '(販売金額)
        Public JyuD_022 As Decimal     '発注数量
        Public JyuD_023 As String       '発注日付
        Public JyuD_024 As Decimal     '仕入数量
        Public JyuD_0241 As Decimal     '仕入金額
        Public JyuD_025 As String       '仕入日付

        Public JyuD_026 As Decimal     '売上数量
        Public JyuD_0262 As Decimal     '売上単価
        Public JyuD_0261 As Decimal     '売上金額
        Public JyuD_027 As String       '売上日付

        Public JyuD_028 As Decimal     '請求数量
        Public JyuD_029 As String       '請求日付
        Public JyuD_0291 As String       '請求番号
        Public JyuD_030 As Decimal     '(受注残数量)
        Public JyuD_031 As Decimal     '(発注残数量)
        Public JyuD_032 As Decimal     '発注済フラグ
        Public JyuD_033 As String       '仕入済フラグ(完納)
        Public JyuD_034 As Decimal     '売上済フラグ(完納)
        Public JyuD_035 As Decimal     '請求済フラグ(完納)
        Public JyuD_Flg As Byte         '更新フラグ
        Public JyuD_042 As String       'Delivery Time          'INSERT 2016/06/23 AOKI
    End Structure

    '発注データ情報
    Public Structure HatDDatInfo
        Public HatD_001 As String       '契約№
        Public HatD_002 As Integer      '契約SEQ
        Public HatD_003 As Integer      '項目
        Public HatD_004 As Integer      '発注SEQ
        Public HatD_005 As String       '発注番号
        Public HatD_006 As Decimal     '仕入先ｺｰﾄﾞ
        Public HatD_007 As String       '仕入先名称
        Public HatD_008 As String       '発注日付
        Public HatD_009 As String       '品名
        Public HatD_010 As String       '品番
        Public HatD_011 As Decimal     '発注数量
        Public HatD_012 As String       '発注単位
        Public HatD_013 As Decimal     '発注単価
        Public HatD_0131 As Decimal     '掛率
        Public HatD_0132 As Decimal     '発注単価NET
        Public HatD_014 As Decimal     '発注金額
        Public HatD_015 As String       '入荷予定日
        Public HatD_016 As String       '入荷日
        Public HatD_017 As Decimal     '仕入数量
        Public HatD_018 As String       '仕入単位
        Public HatD_019 As Decimal     '仕入単価
        Public HatD_020 As Decimal     '掛率
        Public HatD_021 As Decimal     '仕入単価NET
        Public HatD_022 As Decimal     '仕入金額
        Public HatD_023 As Decimal     '売上数量
        Public HatD_024 As Decimal     '売上単価
        Public HatD_025 As Decimal     '売上金額
        Public HatD_026 As String       '売上日付
        Public HatD_027 As String       '納品書発行日
        Public HatD_028 As String       '受領書発行日
        Public HatD_029 As String       'カスタムインボイス発行日
        Public HatD_030 As Integer      '仕入完了チェック
        Public HatD_031 As String       '仕入日付
        Public HatD_032 As String       'Yanmar No.     'INSERT 2016/03/24 AOKI
    End Structure

    Public Structure JDHDDatInfo                 'INSERT 2014/12/04 AOKI
        Public JyuD As JyuDDatInfo      'INSERT 2014/12/04 AOKI
        Public HatD As HatDDatInfo      'INSERT 2014/12/04 AOKI
    End Structure                                'INSERT 2014/12/04 AOKI

    '梱包データ情報
    Public Structure KnpDDatInfo
        Public KnpD_001 As String       '契約№
        Public KnpD_002 As Integer      'SEQ
        Public KnpD_003 As Integer      '項目
        Public KnpD_004 As Integer      '梱包SEQ
        Public KnpD_005 As Integer      '出荷№
        Public KnpD_006 As Integer      'ケース№
        Public KnpD_007 As String       '品名
        Public KnpD_008 As String       '品番
        Public KnpD_009 As Decimal     '数量
        Public KnpD_010 As String       '単位
        Public KnpD_011 As Decimal     '単価
        Public KnpD_012 As Decimal     '金額
        Public KnpD_013 As Decimal     '重量
        Public KnpD_014 As String       '置き場所
        Public KnpD_015 As String       '梱包日
        Public KnpD_016 As String       '出荷方法
        Public KnpD_017 As String       '備考１
        Public KnpD_018 As String       '出荷日
        Public KnpD_019 As String       '当社担当者
        Public KnpD_020 As String       '最終出荷先
        Public KnpD_021 As Decimal     '縦
        Public KnpD_022 As Decimal     '横
        Public KnpD_023 As Decimal     '高さ
        Public KnpD_024 As Decimal     '容量
    End Structure

    '船名テーブルレイアウト
    Public Structure VesTblInfo
        Public Ves_001 As Decimal     'コード
        Public Ves_002 As String       '船名
        Public Ves_003 As Decimal     '得意先コード
        Public Ves_004 As String       '造船所
        Public Ves_005 As String       '船番
        Public Ves_006 As String       'Shipmanager
        Public Ves_007 As String       'IMO
        Public Ves_008 As String       '建造年月
        Public Ves_009 As String       '要注意船       'INSERT 2018/06/22 AOKI
    End Structure

    'INSERT 2017/06/22 AOKI START -----------------------------------------------------------------------------------------
    'ヤンマーエンジン登録テーブルレイアウト
    Public Structure YnmTblInfo
        Public YT_KeyNo As Integer          'コード
        Public YT_ShipName As String           '船名
        Public YT_IMO As Decimal         'IMO
        Public YT_EngineType As String           'Engine Type
        Public YT_EngineNo As String           'Engine No
        Public YT_ShipName_O As String           '【発注】船名
        Public YT_IMO_O As Decimal         '【発注】IMO
        Public YT_EngineType_O As String           '【発注】Engine Type
        Public YT_EngineNo_O As String           '【発注】Engine No
        Public YT_JyuDate As String           '受注日
        Public YT_HatName As String           '発注先
        Public YT_QuoDate As String           '見積依頼日
        Public YT_HatDate As String           '発注日
        Public YT_TorokuDate As String           '登録完了
        Public YT_BuiltYard As String           '造船所
        Public YT_ShipNo As String           '船番
        Public YT_YearBuilt As String           '建造年月
        Public YT_KeiyakuNo As String           '契約番号
        Public YT_Tokuisaki As String           '得意先
        Public YT_Eikyu As Integer          '永久
    End Structure
    'INSERT 2017/06/22 AOKI E N D -----------------------------------------------------------------------------------------

    'メーカーテーブルレイアウト
    Public Structure MakTblInfo
        Public Mak_001 As Decimal     'コード
        Public Mak_002 As String       'メーカー
        Public Mak_003 As Decimal     '
        Public Mak_004 As String       '
        Public Mak_005 As String       '
    End Structure

    '入荷場所テーブルレイアウト
    Public Structure NyuTblInfo
        Public Nyu_001 As Decimal     'コード
        Public Nyu_002 As String       '入荷場所名
        Public Nyu_003 As Decimal     '
        Public Nyu_004 As String       '
        Public Nyu_005 As String       '
    End Structure

    '発送先テーブルレイアウト
    Public Structure HasTblInfo
        Public Has_001 As Decimal     'コード
        Public Has_002 As String       '発送先名
        Public Has_003 As Decimal     '
        Public Has_004 As String       '
        Public Has_005 As String       '
    End Structure

    '置き場所テーブルレイアウト
    Public Structure Oki_TblInfo
        Public Oki_001 As Decimal     'コード
        Public Oki_002 As String       '置き場所名
        Public Oki_003 As Decimal     '
        Public Oki_004 As String       '
        Public Oki_005 As String       '
    End Structure

    '出荷方法　テーブルレイアウト
    Public Structure Shu_TblInfo
        Public Shu_001 As Decimal     'コード
        Public Shu_002 As String       '出荷方法名
        Public Shu_003 As Decimal     '
        Public Shu_004 As String       '
        Public Shu_005 As String       '
    End Structure

    'INSERT 2014/07/24 AOKI START ----------------------------------------------------------------------------------------
    '最終出荷先　テーブルレイアウト
    Public Structure Sai_TblInfo
        Public Sai_001 As Decimal     'コード
        Public Sai_002 As String       '最終出荷先名
        Public Sai_003 As Decimal     '
        Public Sai_004 As String       '
        Public Sai_005 As String       '
    End Structure
    'INSERT 2014/07/24 AOKI E N D ----------------------------------------------------------------------------------------

    'INSERT 2018/01/19 AOKI START ----------------------------------------------------------------------------------------
    '空港　テーブルレイアウト
    Public Structure AirP_TblInfo
        '    AirP_001         as Decimal    'コード        'DELETE 2018/03/14
        Public AirP_001 As String      'コード         'INSERT 2018/03/14
        Public AirP_002 As String      '空港名
        Public AirP_003 As Decimal    '
        Public AirP_004 As String      '
        Public AirP_005 As String      '
    End Structure
    'INSERT 2018/01/19 AOKI E N D ----------------------------------------------------------------------------------------

    'INSERT 2018/02/20 AOKI START ----------------------------------------------------------------------------------------
    '送金人　テーブルレイアウト
    Public Structure Sokin_TblInfo
        Public Sokin_001 As Decimal     'コード
        Public Sokin_002 As String       '送金人
        Public Sokin_003 As String       '
        Public Sokin_004 As String       '
        Public Sokin_005 As String       '
    End Structure
    'INSERT 2018/02/20 AOKI E N D ----------------------------------------------------------------------------------------

    'Unitテーブルレイアウト
    Public Structure UniTblInfo
        Public Uni_001 As Decimal     'コード
        Public Uni_002 As String       'Unit名
        Public Uni_003 As Decimal     '
        Public Uni_004 As String       '
        Public Uni_005 As String       '
    End Structure

    'Structureテーブルレイアウト
    Public Structure TypTblInfo
        Public Typ_001 As Decimal     'コード
        Public Typ_002 As String       'Structure名
        Public Typ_003 As Decimal     '
        Public Typ_004 As String       '
        Public Typ_005 As String       '
    End Structure

    '商品テーブルレイアウト
    Public Structure SyoTblInfo
        Public Syo_001 As Decimal     'コード
        Public Syo_002 As String       '品名
        Public Syo_003 As String       '品番
        Public Syo_004 As String       '
        Public Syo_005 As String       '単位
        Public Syo_006 As String       '
        Public Syo_007 As String       '
        Public Syo_008 As String       '
        Public Syo_009 As Decimal     '得意先ｺｰﾄﾞ
        Public Syo_010 As Decimal     '船名ｺｰﾄﾞ
        Public Syo_011 As Decimal     '
        Public Syo_012 As Decimal     '
        Public Syo_013 As Decimal     '
        Public Syo_014 As Decimal     '
        Public Syo_015 As Decimal     '
        Public Syo_016 As Decimal     '
        Public Syo_017 As Decimal     '
        Public Syo_018 As Decimal     '
    End Structure

    'オーナーテーブルレイアウト
    Public Structure OwnTblInfo
        Public Own_001 As Decimal     'コード
        Public Own_002 As String       'オーナー名
        Public Own_003 As Decimal     '得意先コード
        Public Own_004 As String       '得意先名           'UPDATE 2014/04/08 AOKI
        Public Own_005 As Decimal     '船名コード         'UPDATE 2014/04/08 AOKI
        Public Own_006 As String       '船名               'UPDATE 2014/04/08 AOKI
        Public Own_007 As String       '
        Public Own_008 As String       '
    End Structure


    'INSERT 2013/01/30 請求住所 AOKI START ----------------------------------------------------------------------------------
    '請求住所テーブルレイアウト
    Public Structure SAddTblInfo
        Public SAdd_001 As Decimal     'コード
        Public SAdd_002 As String       '請求住所
        Public SAdd_003 As Decimal     '得意先コード
        Public SAdd_004 As Decimal     'オーナー
        Public SAdd_005 As String       '
        Public SAdd_006 As String       '
        Public SAdd_007 As String       '
        Public SAdd_008 As String       '
        Public SAdd_Cnt As Integer      'レコード数
    End Structure
    'INSERT 2013/01/30 請求住所 AOKI E N D ----------------------------------------------------------------------------------

    'INSERT 2015/02/26 AOKI START -----------------------------------------------------------------------------------------
    '残高一覧表用
    Public Structure ZanDataInfo
        Public Zan_HojoCd As Integer      '補助科目コード
        Public Zan_HojoNm As String       '補助科目名
        Public Zan_SeiG As Decimal     '請求金額
        Public Zan_NyuG As Decimal     '入金額
        Public Zan_ZanG As Decimal     '残金額
        Public Zan_Kbn As Integer      '国内/海外区分
    End Structure
    'INSERT 2015/02/26 AOKI E N D -----------------------------------------------------------------------------------------


    '***************************************************************
    '**  名称    : Sub GetVesTblInfo()
    '**  機能    : 船名テーブルの読込み処理
    '**  戻り値  :
    '**  引数    : KbnMst : 船名テーブル情報
    '**          : viMode : 0 コード検索
    '**          :        : 1 船名検索
    '**  備考    :
    '***************************************************************
    Public Function GetVesTblInfo(VesTbl As VesTblInfo,
                              viMode As Integer) As Boolean

        Dim SQLtxt As String


        GetVesTblInfo = False

        With VesTbl

            '===船名テーブル読込み用SQL文作成===================================

            SQLtxt = ""
            SQLtxt = SQLtxt & "SELECT * FROM Ves_Tbl"
            Select Case viMode
                Case 0 'コード検索
                    SQLtxt = SQLtxt & " WHERE Ves_001 = " & .Ves_001
                    SQLtxt = SQLtxt & " ORDER BY Ves_001,Ves_002"
                Case 1 '船名検索
                    SQLtxt = SQLtxt & " WHERE Ves_002 ='" & .Ves_002 & "'"
                    SQLtxt = SQLtxt & " ORDER BY Ves_002"
            End Select

            '===船名テーブルの読込み============================================
            Dim dt As DataTable

            Dim dbsvc As New clsDB.DBService()
            dt = dbsvc.GetDatafromDB(SQLtxt)

            If dt.Rows.Count() > 0 Then
                .Ves_001 = NCnvZ(dt.Rows(0)("Ves_001"))     'コード
                .Ves_002 = NCnvN(dt.Rows(0)("Ves_002"))     '船名
                .Ves_003 = NCnvZ(dt.Rows(0)("Ves_003"))     '
                .Ves_004 = NCnvN(dt.Rows(0)("Ves_004"))     '
                .Ves_005 = NCnvN(dt.Rows(0)("Ves_005"))     '
                .Ves_006 = NCnvN(dt.Rows(0)("Ves_006"))     '
                .Ves_007 = NCnvN(dt.Rows(0)("Ves_007"))     '
                .Ves_008 = NCnvN(dt.Rows(0)("Ves_008"))     '
                .Ves_009 = NCnvN(dt.Rows(0)("Ves_009"))     '要注意船        'INSERT 2018/06/22 AOKI
            Else
                GoTo GetVesTblInfo_Exit
            End If
        End With

        GetVesTblInfo = True

GetVesTblInfo_Exit:

        Exit Function

    End Function

    '***************************************************************
    '**  名称    : Sub GetYnmTblInfo()
    '**  機能    : ヤンマーテーブルの読込み処理
    '**  戻り値  :
    '**  引数    : KbnMst : 船名テーブル情報
    '**          : viMode : 0 コード検索
    '**          :        : 1 船名検索
    '**  備考    :
    '***************************************************************
    Public Function GetYnmTblInfo(YnmTbl As YnmTblInfo,
                                  viMode As Integer) As Boolean

        Dim SQLtxt As String


        GetYnmTblInfo = False

        With YnmTbl

            '===船名テーブル読込み用SQL文作成===================================

            SQLtxt = ""
            SQLtxt = SQLtxt & "Select * FROM YE_Tbl"

            SQLtxt = SQLtxt & " LEFT JOIN  (Select   Ves_Tbl.* "
            SQLtxt = SQLtxt & "             FROM     Ves_Tbl "

            SQLtxt = SQLtxt & "             INNER JOIN   (Select   Ves_007 "
            SQLtxt = SQLtxt & "                                , MAX(Ves_Insert) As VI_Max "
            SQLtxt = SQLtxt & "                           FROM     Ves_Tbl "
            SQLtxt = SQLtxt & "                           WHERE    ISNULL(Ves_007, 0) > 0 "
            SQLtxt = SQLtxt & "                           GROUP BY Ves_007 "
            SQLtxt = SQLtxt & "                          ) As VI "
            SQLtxt = SQLtxt & "             On  Ves_Tbl.Ves_007    = VI.Ves_007 "
            SQLtxt = SQLtxt & "             And Ves_Tbl.Ves_Insert = VI.VI_Max "

            SQLtxt = SQLtxt & "            ) As Ves "

            SQLtxt = SQLtxt & " On IMO = Ves.Ves_007 "

            SQLtxt = SQLtxt & " LEFT JOIN  Tok_Mst "
            SQLtxt = SQLtxt & " On Ves_003 = Tok_001 "

            SQLtxt = SQLtxt & " WHERE KeyNo = " & .YT_KeyNo


            '===船名テーブルの読込み============================================
            Dim dt As DataTable

            Dim dbsvc As New clsDB.DBService()
            dt = dbsvc.GetDatafromDB(SQLtxt)

            If dt.Rows.Count() > 0 Then
                .YT_KeyNo = NCnvZ(dt.Rows(0)("KeyNo"))                       'コード
                .YT_ShipName = NCnvN(dt.Rows(0)("ShipName"))                 '船名
                .YT_IMO = NCnvZ(dt.Rows(0)("IMO"))                           'IMO
                .YT_EngineType = NCnvN(dt.Rows(0)("EngineType"))             'Engine Type
                .YT_EngineNo = NCnvN(dt.Rows(0)("EngineNo"))                 'Engine No.
                .YT_ShipName_O = NCnvN(dt.Rows(0)("ShipName_Order"))         '【発注】船名
                .YT_IMO_O = NCnvZ(dt.Rows(0)("IMO_Order"))                   '【発注】IMO
                .YT_EngineType_O = NCnvN(dt.Rows(0)("EngineType_Order"))     '【発注】Engine Type
                .YT_EngineNo_O = NCnvN(dt.Rows(0)("EngineNo_Order"))         '【発注】Engine No.
                .YT_JyuDate = NCnvN(dt.Rows(0)("JyuDate"))                   '受注日
                .YT_HatName = NCnvN(dt.Rows(0)("HatName"))                   '発注先
                .YT_QuoDate = NCnvN(dt.Rows(0)("QuoDate"))                   '見積依頼日
                .YT_HatDate = NCnvN(dt.Rows(0)("HatDate"))                   '発注日
                .YT_TorokuDate = NCnvN(dt.Rows(0)("TorokuDate"))             '登録完了日
                .YT_Eikyu = NCnvZ(dt.Rows(0)("Eikyu"))                       '永久

                .YT_KeiyakuNo = NCnvN(dt.Rows(0)("KEIYAKUNO"))               '契約番号
                .YT_BuiltYard = NCnvN(dt.Rows(0)("Ves_004"))                 '造船所
                .YT_ShipNo = NCnvN(dt.Rows(0)("Ves_005"))                    '船番
                .YT_YearBuilt = NCnvN(dt.Rows(0)("Ves_008"))                 '建造年月
                .YT_Tokuisaki = NCnvN(dt.Rows(0)("Tok_003"))                 '得意先
            Else
                GoTo GetYnmTblInfo_Exit
            End If
        End With

        GetYnmTblInfo = True

GetYnmTblInfo_Exit:

        Exit Function

    End Function

    '***************************************************************
    '**  名称    : Sub GetOwnTblInfo()
    '**  機能    : オーナーテーブルの読込み処理
    '**  戻り値  :
    '**  引数    : KbnMst : オーナーテーブル情報
    '**          : viMode : 0 コード検索
    '**          :        : 1 オーナー検索
    '**  備考    :
    '***************************************************************
    Public Function GetOwnTblInfo(OwnTbl As OwnTblInfo,
                                  viMode As Integer) As Boolean

        Dim SQLtxt As String


        GetOwnTblInfo = False

        With OwnTbl

            '===オーナーテーブル読込み用SQL文作成===================================

            SQLtxt = ""
            SQLtxt = SQLtxt & "Select * FROM Own_Tbl"
            Select Case viMode
                Case 0 'コード検索
                    SQLtxt = SQLtxt & " WHERE Own_001 = " & .Own_001
                    SQLtxt = SQLtxt & " ORDER BY Own_001,Own_002"
                Case 1 'オーナー検索
                    SQLtxt = SQLtxt & " WHERE Own_002 ='" & .Own_002 & "'"
                    SQLtxt = SQLtxt & " ORDER BY Own_002"
            End Select

            '===オーナーテーブルの読込み============================================
            Dim dt As DataTable

            Dim dbsvc As New clsDB.DBService()
            dt = dbsvc.GetDatafromDB(SQLtxt)

            If dt.Rows.Count() > 0 Then
                .Own_001 = NCnvZ(dt.Rows(0)("Own_001"))     'コード
                .Own_002 = NCnvN(dt.Rows(0)("Own_002"))     'オーナー
                .Own_003 = NCnvZ(dt.Rows(0)("Own_003"))     '得意先コード        'UPDATE 2014/04/08 AOKI
                .Own_004 = NCnvN(dt.Rows(0)("Own_004"))     '得意先名            'UPDATE 2014/04/08 AOKI
                .Own_005 = NCnvZ(dt.Rows(0)("Own_005"))     '船名コード          'UPDATE 2014/04/08 AOKI
                .Own_006 = NCnvN(dt.Rows(0)("Own_006"))     '船名                'UPDATE 2014/04/08 AOKI
                .Own_007 = NCnvN(dt.Rows(0)("Own_007"))     '
                .Own_008 = NCnvN(dt.Rows(0)("Own_008"))     '
            Else
                GoTo GetOwnTblInfo_Exit
            End If
        End With

        GetOwnTblInfo = True

GetOwnTblInfo_Exit:

        Exit Function

    End Function

    '***************************************************************
    '**  名称    : Sub GetMakTblInfo()
    '**  機能    : メーカーテーブルの読込み処理
    '**  戻り値  :
    '**  引数    : KbnMst : メーカーテーブル情報
    '**          : viMode : 0 コード検索
    '**          :        : 1 メーカー検索
    '**  備考    :
    '***************************************************************
    Public Function GetMakTblInfo(MakTbl As MakTblInfo,
                                  viMode As Integer) As Boolean

        Dim SQLtxt As String


        GetMakTblInfo = False

        With MakTbl

            '===メーカーテーブル読込み用SQL文作成===================================

            SQLtxt = ""
            SQLtxt = SQLtxt & "SELECT * FROM Mak_Tbl"
            Select Case viMode
                Case 0 'コード検索
                    SQLtxt = SQLtxt & " WHERE Mak_001 = " & .Mak_001
                    SQLtxt = SQLtxt & " ORDER BY Mak_001,Mak_002"
                Case 1 'メーカー検索
                    SQLtxt = SQLtxt & " WHERE Mak_002 ='" & .Mak_002 & "'"
                    SQLtxt = SQLtxt & " ORDER BY Mak_002"
            End Select

            '===メーカーテーブルの読込み============================================
            Dim dt As DataTable

            Dim dbsvc As New clsDB.DBService()
            dt = dbsvc.GetDatafromDB(SQLtxt)

            If dt.Rows.Count() > 0 Then
                .Mak_001 = NCnvZ(dt.Rows(0)("Mak_001"))     'コード
                .Mak_002 = NCnvN(dt.Rows(0)("Mak_002"))     'メーカー
                .Mak_003 = NCnvZ(dt.Rows(0)("Mak_003"))     '
                .Mak_004 = NCnvN(dt.Rows(0)("Mak_004"))     '
                .Mak_005 = NCnvN(dt.Rows(0)("Mak_005"))     '
            Else
                GoTo GetMakTblInfo_Exit
            End If
        End With

        GetMakTblInfo = True

GetMakTblInfo_Exit:

        Exit Function

    End Function

    '***************************************************************
    '**  名称    : Sub GetNyuTblInfo()
    '**  機能    : 入荷場所テーブルの読込み処理
    '**  戻り値  :
    '**  引数    : KbnMst : 入荷場所テーブル情報
    '**          : viMode : 0 コード検索
    '**          :        : 1 入荷場所検索
    '**  備考    :
    '***************************************************************
    Public Function GetNyuTblInfo(NyuTbl As NyuTblInfo,
                                  viMode As Integer) As Boolean

        Dim SQLtxt As String


        GetNyuTblInfo = False

        With NyuTbl

            '===入荷場所テーブル読込み用SQL文作成===================================

            SQLtxt = ""
            SQLtxt = SQLtxt & "Select * FROM Nyu_Tbl"
            Select Case viMode
                Case 0 'コード検索
                    SQLtxt = SQLtxt & " WHERE Nyu_001 = " & .Nyu_001
                    SQLtxt = SQLtxt & " ORDER BY Nyu_001, Nyu_002"
                Case 1 '入荷場所検索
                    SQLtxt = SQLtxt & " WHERE Nyu_002 ='" & .Nyu_002 & "'"
                    SQLtxt = SQLtxt & " ORDER BY Nyu_002"
            End Select

            '===入荷場所テーブルの読込み============================================
            Dim dt As DataTable

            Dim dbsvc As New clsDB.DBService()
            dt = dbsvc.GetDatafromDB(SQLtxt)

            If dt.Rows.Count() > 0 Then
                .Nyu_001 = NCnvZ(dt.Rows(0)("Nyu_001"))     'コード
                .Nyu_002 = NCnvN(dt.Rows(0)("Nyu_002"))     '入荷場所
                .Nyu_003 = NCnvZ(dt.Rows(0)("Nyu_003"))     '
                .Nyu_004 = NCnvN(dt.Rows(0)("Nyu_004"))     '
                .Nyu_005 = NCnvN(dt.Rows(0)("Nyu_005"))     '
            Else
                GoTo GetNyuTblInfo_Exit
            End If
        End With

        GetNyuTblInfo = True

GetNyuTblInfo_Exit:

        Exit Function

    End Function

    '***************************************************************
    '**  名称    : Sub GetHasTblInfo()
    '**  機能    : 発送先テーブルの読込み処理
    '**  戻り値  :
    '**  引数    : KbnMst : 発送先テーブル情報
    '**          : viMode : 0 コード検索
    '**          :        : 1 発送先検索
    '**  備考    :
    '***************************************************************
    Public Function GetHasTblInfo(HasTbl As HasTblInfo,
                                  viMode As Integer) As Boolean

        Dim SQLtxt As String


        GetHasTblInfo = False

        With HasTbl

            '===発送先テーブル読込み用SQL文作成===================================

            SQLtxt = ""
            SQLtxt = SQLtxt & "Select * FROM Has_Tbl"
            Select Case viMode
                Case 0 'コード検索
                    SQLtxt = SQLtxt & " WHERE Has_001 = " & .Has_001
                    SQLtxt = SQLtxt & " ORDER BY Has_001, Has_002"
                Case 1 '発送先検索
                    SQLtxt = SQLtxt & " WHERE Has_002 ='" & .Has_002 & "'"
                    SQLtxt = SQLtxt & " ORDER BY Has_002"
            End Select

            '===発送先テーブルの読込み============================================
            Dim dt As DataTable

            Dim dbsvc As New clsDB.DBService()
            dt = dbsvc.GetDatafromDB(SQLtxt)

            If dt.Rows.Count() > 0 Then
                .Has_001 = NCnvZ(dt.Rows(0)("Has_001"))     'コード
                .Has_002 = NCnvN(dt.Rows(0)("Has_002"))     '発送先
                .Has_003 = NCnvZ(dt.Rows(0)("Has_003"))     '
                .Has_004 = NCnvN(dt.Rows(0)("Has_004"))     '
                .Has_005 = NCnvN(dt.Rows(0)("Has_005"))     '
            Else
                GoTo GetHasTblInfo_Exit
            End If
        End With

        GetHasTblInfo = True

GetHasTblInfo_Exit:

        Exit Function

    End Function

    '***************************************************************
    '**  名称    : Sub GetUniTblInfo()
    '**  機能    : Unitテーブルの読込み処理
    '**  戻り値  :
    '**  引数    : KbnMst : Unitテーブル情報
    '**          : viMode : 0 コード検索
    '**          :        : 1 Unit検索
    '**  備考    :
    '***************************************************************
    Public Function GetUniTblInfo(UniTbl As UniTblInfo,
                                  viMode As Integer) As Boolean

        Dim SQLtxt As String


        GetUniTblInfo = False

        With UniTbl

            '===Unitテーブル読込み用SQL文作成===================================

            SQLtxt = ""
            SQLtxt = SQLtxt & "Select * FROM Uni_Tbl"
            Select Case viMode
                Case 0 'コード検索
                    SQLtxt = SQLtxt & " WHERE Uni_001 = " & .Uni_001
                    SQLtxt = SQLtxt & " ORDER BY Uni_001, Uni_002"
                Case 1 'Unit検索
                    SQLtxt = SQLtxt & " WHERE Uni_002 ='" & .Uni_002 & "'"
                    SQLtxt = SQLtxt & " ORDER BY Uni_002"
            End Select

            '===Unitテーブルの読込み============================================
            Dim dt As DataTable

            Dim dbsvc As New clsDB.DBService()
            dt = dbsvc.GetDatafromDB(SQLtxt)

            If dt.Rows.Count() > 0 Then
                .Uni_001 = NCnvZ(dt.Rows(0)("Uni_001"))     'コード
                .Uni_002 = NCnvN(dt.Rows(0)("Uni_002"))     'Unit
                .Uni_003 = NCnvZ(dt.Rows(0)("Uni_003"))     '
                .Uni_004 = NCnvN(dt.Rows(0)("Uni_004"))     '
                .Uni_005 = NCnvN(dt.Rows(0)("Uni_005"))     '
            Else
                GoTo GetUniTblInfo_Exit
            End If
        End With

        GetUniTblInfo = True

GetUniTblInfo_Exit:

        Exit Function

    End Function

    '***************************************************************
    '**  名称    : Sub GetTypTblInfo()
    '**  機能    : Typeテーブルの読込み処理
    '**  戻り値  :
    '**  引数    : KbnMst : Typeテーブル情報
    '**          : viMode : 0 コード検索
    '**          :        : 1 Type検索
    '**  備考    :
    '***************************************************************
    Public Function GetTypTblInfo(TypTbl As TypTblInfo,
                                  viMode As Integer) As Boolean

        Dim SQLtxt As String


        GetTypTblInfo = False

        With TypTbl

            '===Typeテーブル読込み用SQL文作成===================================

            SQLtxt = ""
            SQLtxt = SQLtxt & "Select * FROM Typ_Tbl"
            Select Case viMode
                Case 0 'コード検索
                    SQLtxt = SQLtxt & " WHERE Typ_001 = " & .Typ_001
                    SQLtxt = SQLtxt & " ORDER BY Typ_001, Typ_002"
                Case 1 'Type検索
                    SQLtxt = SQLtxt & " WHERE Typ_002 ='" & .Typ_002 & "'"
                    SQLtxt = SQLtxt & " ORDER BY Typ_002"
            End Select

            '===Typeテーブルの読込み============================================
            Dim dt As DataTable

            Dim dbsvc As New clsDB.DBService()
            dt = dbsvc.GetDatafromDB(SQLtxt)

            If dt.Rows.Count() > 0 Then
                .Typ_001 = NCnvZ(dt.Rows(0)("Typ_001"))     'コード
                .Typ_002 = NCnvN(dt.Rows(0)("Typ_002"))     'Type
                .Typ_003 = NCnvZ(dt.Rows(0)("Typ_003"))     '
                .Typ_004 = NCnvN(dt.Rows(0)("Typ_004"))     '
                .Typ_005 = NCnvN(dt.Rows(0)("Typ_005"))     '
            Else
                GoTo GetTypTblInfo_Exit
            End If
        End With

        GetTypTblInfo = True

GetTypTblInfo_Exit:

        Exit Function

    End Function

    '***************************************************************
    '**  名称    : Sub GetSyoTblInfo()
    '**  機能    : 商品テーブルの読込み処理
    '**  戻り値  :
    '**  引数    : SyoTbl : 商品テーブル情報
    '**          : viMode : 0 コード検索
    '**          :        : 1 品名検索
    '**          :        : 2 品番検索
    '**          :        : 3 品名、品番検索
    '**  備考    :
    '***************************************************************
    Public Function GetSyoTblInfo(SyoTbl As SyoTblInfo,
                                  viMode As Integer) As Boolean

        Dim SQLtxt As String


        GetSyoTblInfo = False

        With SyoTbl

            '===Syoeテーブル読込み用SQL文作成===================================

            SQLtxt = ""
            SQLtxt = SQLtxt & "Select * FROM Syo_Tbl"
            Select Case viMode
                Case 0 'コード検索
                    SQLtxt = SQLtxt & " WHERE Syo_001 = " & .Syo_001
                    SQLtxt = SQLtxt & " ORDER BY Syo_001, Syo_002"
                Case 1 '品名検索
                    SQLtxt = SQLtxt & " WHERE Syo_002 ='" & EditSQLAddSQuot(.Syo_002) & "'"
                    SQLtxt = SQLtxt & " ORDER BY Syo_002"
                Case 2 '品番検索
                    SQLtxt = SQLtxt & " WHERE Syo_003 ='" & EditSQLAddSQuot(.Syo_003) & "'"
                    SQLtxt = SQLtxt & " ORDER BY Syo_003"
                Case 3 '品名、品番検索
                    SQLtxt = SQLtxt & " WHERE Syo_002 ='" & EditSQLAddSQuot(.Syo_002) & "'"
                    SQLtxt = SQLtxt & "   AND Syo_003 ='" & EditSQLAddSQuot(.Syo_003) & "'"
                    SQLtxt = SQLtxt & " ORDER BY Syo_002,Syo_003"
            End Select

            '===Syoeテーブルの読込み============================================
            Dim dt As DataTable

            Dim dbsvc As New clsDB.DBService()
            dt = dbsvc.GetDatafromDB(SQLtxt)

            If dt.Rows.Count() > 0 Then
                .Syo_001 = NCnvZ(dt.Rows(0)("Syo_001"))     'コード
                .Syo_002 = NCnvN(dt.Rows(0)("Syo_002"))     '品名
                .Syo_003 = NCnvN(dt.Rows(0)("Syo_003"))     '品番
                .Syo_004 = NCnvN(dt.Rows(0)("Syo_004"))     '
                .Syo_005 = NCnvN(dt.Rows(0)("Syo_005"))     '単位
                .Syo_006 = NCnvN(dt.Rows(0)("Syo_006"))     '
                .Syo_007 = NCnvN(dt.Rows(0)("Syo_007"))     '
                .Syo_008 = NCnvN(dt.Rows(0)("Syo_008"))     '
                .Syo_009 = NCnvZ(dt.Rows(0)("Syo_009"))     '得意先ｺｰﾄﾞ
                .Syo_010 = NCnvZ(dt.Rows(0)("Syo_010"))     '船ｺｰﾄﾞ
                .Syo_011 = NCnvZ(dt.Rows(0)("Syo_011"))     '
                .Syo_012 = NCnvZ(dt.Rows(0)("Syo_012"))     '
                .Syo_013 = NCnvZ(dt.Rows(0)("Syo_013"))     '
                .Syo_014 = NCnvZ(dt.Rows(0)("Syo_014"))     '
                .Syo_015 = NCnvZ(dt.Rows(0)("Syo_015"))     '
                .Syo_016 = NCnvZ(dt.Rows(0)("Syo_016"))     '
                .Syo_017 = NCnvZ(dt.Rows(0)("Syo_017"))     '
                .Syo_018 = NCnvZ(dt.Rows(0)("Syo_018"))     '
            Else
                GoTo GetSyoTblInfo_Exit
            End If
        End With

        GetSyoTblInfo = True

GetSyoTblInfo_Exit:

        Exit Function

    End Function

    '***************************************************************
    '**  名称    : Sub GetNewCode()
    '**  機能    : 各種テーブルの新コード取得
    '**  戻り値  :
    '**  引数    : viMode 0:船名テーブル
    '**          :        1:メーカーテーブル
    '**          :        2:入荷場所テーブル
    '**          :        3:発送先テーブル
    '**          :        4:Unitテーブル
    '**          :        5:Pyteテーブル
    '**          :        6:品名テーブル
    '**          :        7:オーナーテーブル
    '**          :        8:出荷ファイル出荷№
    '**          :        9:出荷ファイル出荷№
    '**          :       10:出荷ファイル出荷№
    '**          :       11:請求住所テーブル        'INSERT 2013/02/13 請求住所 AOKI
    '**  備考    :
    '***************************************************************
    Public Function GetNewCode(viMode As Integer) As Decimal

        Dim SQLtxt As String


        GetNewCode = 0

        SQLtxt = ""
        Select Case viMode

            Case 0  '船名テーブルの最終コード取得
                SQLtxt = SQLtxt & "SELECT Ves_001 As LastCode FROM Ves_Tbl"
                SQLtxt = SQLtxt & " ORDER BY Ves_001 DESC"

            Case 1  'メーカーテーブルの最終コード取得
                SQLtxt = SQLtxt & "SELECT Mak_001 As LastCode FROM Mak_Tbl"
                SQLtxt = SQLtxt & " ORDER BY Mak_001 DESC"

            Case 2  '入荷場所テーブルの最終コード取得
                SQLtxt = SQLtxt & "SELECT Nyu_001 As LastCode FROM Nyu_Tbl"
                SQLtxt = SQLtxt & " ORDER BY Nyu_001 DESC"

            Case 3  '発送先テーブルの最終コード取得
                SQLtxt = SQLtxt & "SELECT Has_001 As LastCode FROM Has_Tbl"
                SQLtxt = SQLtxt & " ORDER BY Has_001 DESC"

            Case 4  'Unitテーブルの最終コード取得
                SQLtxt = SQLtxt & "SELECT Uni_001 As LastCode FROM Uni_Tbl"
                SQLtxt = SQLtxt & " ORDER BY Uni_001 DESC"

            Case 5  'Typeテーブルの最終コード取得
                SQLtxt = SQLtxt & "SELECT Typ_001 As LastCode FROM Typ_Tbl"
                SQLtxt = SQLtxt & " ORDER BY Typ_001 DESC"

            Case 6  '商品テーブルの最終コード取得
                SQLtxt = SQLtxt & "SELECT Syo_001 As LastCode FROM Syo_Tbl"
                SQLtxt = SQLtxt & " ORDER BY Syo_001 DESC"

            Case 7  'オーナーテーブルの最終コード取得
                SQLtxt = SQLtxt & "SELECT Own_001 As LastCode FROM Own_Tbl"
                SQLtxt = SQLtxt & " ORDER BY Own_001 DESC"

            Case 8  '出荷ファイルの最終出荷№
                SQLtxt = SQLtxt & "SELECT ShuD_001 As LastCode FROM ShuD_Dat"
                SQLtxt = SQLtxt & " ORDER BY ShuD_001 DESC"

            Case 9  '置き場所テーブルの最終出荷№
                SQLtxt = SQLtxt & "SELECT Oki_001 As LastCode FROM Oki_Tbl"
                SQLtxt = SQLtxt & " ORDER BY Oki_001 DESC"

            Case 10  '出荷方法テーブルの最終出荷№
                SQLtxt = SQLtxt & "SELECT Shu_001 As LastCode FROM Shu_Tbl"
                SQLtxt = SQLtxt & " ORDER BY Shu_001 DESC"

'INSERT 2013/02/13 請求住所 AOKI START -------------------------------------------------------------------------------
            Case 11  '請求住所テーブルの最終コード取得
                SQLtxt = SQLtxt & "SELECT SAdd_001 As LastCode FROM SAdd_Tbl"
                SQLtxt = SQLtxt & " ORDER BY SAdd_001 DESC"
'INSERT 2013/02/13 請求住所 AOKI E N D -------------------------------------------------------------------------------

'INSERT 2014/07/24 AOKI START ----------------------------------------------------------------------------------------
            Case 12  '最終出荷先の最終コード取得
                SQLtxt = SQLtxt & "SELECT Sai_001 As LastCode FROM Sai_Tbl"
                SQLtxt = SQLtxt & " ORDER BY Sai_001 DESC"
'INSERT 2014/07/24 AOKI E N D ----------------------------------------------------------------------------------------

'INSERT 2017/06/20 AOKI START ----------------------------------------------------------------------------------------
            Case 13  'ヤンマーエンジン登録の最終コード取得
                SQLtxt = SQLtxt & "SELECT KeyNo As LastCode FROM YE_Tbl"
                SQLtxt = SQLtxt & " ORDER BY KeyNo DESC"
'INSERT 2017/06/20 AOKI E N D ----------------------------------------------------------------------------------------

'INSERT 2017/08/15 AOKI START ----------------------------------------------------------------------------------------
            Case 14  '出荷管理No.の最終コード取得
                SQLtxt = SQLtxt & "SELECT Shipping_No As LastCode FROM AwbH_Dat"
                SQLtxt = SQLtxt & " ORDER BY Shipping_No DESC"
'INSERT 2017/08/15 AOKI E N D ----------------------------------------------------------------------------------------

'INSERT 2018/01/19 AOKI START ----------------------------------------------------------------------------------------
            Case 15  '空港の最終コード取得
                SQLtxt = SQLtxt & "SELECT AirP_001 As LastCode FROM AirP_Tbl"
                SQLtxt = SQLtxt & " ORDER BY AirP_001 DESC"
'INSERT 2018/01/19 AOKI E N D ----------------------------------------------------------------------------------------

'INSERT 2018/02/20 AOKI START ----------------------------------------------------------------------------------------
            Case 16  '送金人の最終コード取得
                SQLtxt = SQLtxt & "SELECT Sokin_001 As LastCode FROM Sokin_Tbl"
                SQLtxt = SQLtxt & " ORDER BY Sokin_001 DESC"
                'INSERT 2018/02/20 AOKI E N D ----------------------------------------------------------------------------------------
        End Select

        '===テーブルの読込み============================================
        Dim dt As DataTable

        Dim dbsvc As New clsDB.DBService()
        dt = dbsvc.GetDatafromDB(SQLtxt)

        If dt.Rows.Count() > 0 Then
            If viMode = 14 Then
                GetNewCode = NCnvZ(Mid(dt.Rows(0)("LastCode"), 5, 5)) + 1
            Else
                GetNewCode = NCnvZ(dt.Rows(0)("LastCode")) + 1
            End If
        Else
            GetNewCode = 1
        End If

GetNewCode_Exit:

        Exit Function

    End Function

    'INSERT 2013/02/13 請求住所 AOKI START ----------------------------------------------------------------------------------
    '***************************************************************
    '**  名称    : Sub GetSAddTblInfo()
    '**  機能    : 請求住所テーブルの読込み処理
    '**  戻り値  :
    '**  引数    : KbnMst : 請求住所テーブル情報
    '**          : viMode : 0 コード検索
    '**          :        : 1 船名検索
    '**  備考    :
    '***************************************************************
    Public Function GetSAddTblInfo(SAddTbl As SAddTblInfo, viMode As Integer) As Boolean

        Dim SQLtxt As String


        GetSAddTblInfo = False

        With SAddTbl

            '===請求住所テーブル読込み用SQL文作成===================================

            SQLtxt = ""
            SQLtxt = SQLtxt & "Select * FROM SAdd_Tbl"
            Select Case viMode
                Case 0 'コード検索
                    SQLtxt = SQLtxt & " WHERE SAdd_001 = " & .SAdd_001
                    SQLtxt = SQLtxt & " ORDER BY SAdd_001, SAdd_002"
                Case 1 '請求住所検索
                    '                SQLtxt = SQLtxt & " WHERE SAdd_002 ='" & Replace(.SAdd_002, vbCrLf, "*") & "'"                         'DELETE 2014/05/26 AOKI
                    SQLtxt = SQLtxt & " WHERE SAdd_002 ='" & Replace(EditSQLAddSQuot(.SAdd_002), vbCrLf, "*") & "'"         'INSERT 2014/05/26 AOKI
                    SQLtxt = SQLtxt & " AND   SAdd_003 = " & .SAdd_003
                    SQLtxt = SQLtxt & " AND   SAdd_004 ='" & .SAdd_004 & "'"
            End Select

            '===請求住所テーブルの読込み============================================
            Dim dt As DataTable

            Dim dbsvc As New clsDB.DBService()
            dt = dbsvc.GetDatafromDB(SQLtxt)

            If dt.Rows.Count() > 0 Then
                .SAdd_001 = NCnvZ(dt.Rows(0)("SAdd_001"))     'コード
                .SAdd_002 = NCnvN(dt.Rows(0)("SAdd_002"))     '請求住所
                .SAdd_003 = NCnvZ(dt.Rows(0)("SAdd_003"))     '得意先コード
                .SAdd_004 = NCnvN(dt.Rows(0)("SAdd_004"))     'オーナー
                .SAdd_005 = NCnvN(dt.Rows(0)("SAdd_005"))     '
                .SAdd_006 = NCnvN(dt.Rows(0)("SAdd_006"))     '
                .SAdd_007 = NCnvN(dt.Rows(0)("SAdd_007"))     '
                .SAdd_008 = NCnvN(dt.Rows(0)("SAdd_008"))     '
                .SAdd_Cnt = NCnvZ(dt.Rows.Count)    'レコード数
            Else
                GoTo GetSAddTblInfo_Exit
            End If
        End With

        GetSAddTblInfo = True

GetSAddTblInfo_Exit:

        Exit Function

    End Function
    Function EditSQLAddSQuot(pItem As String) As String

        Dim wWork As String
        Dim i As Integer

        If Val(InStr(pItem, "'")) = 0 Then
            EditSQLAddSQuot = pItem
        Else
            wWork = Left(pItem, Val(InStr(pItem, "'"))) & "'"
            For i = Val(InStr(pItem, "'")) + 1 To Len(pItem)
                If Mid(pItem, i, 1) = "'" Then
                    wWork = wWork & "'"
                End If
                wWork = wWork & Mid(pItem, i, 1)
            Next i
            EditSQLAddSQuot = wWork
        End If

        EditSQLAddSQuot = Replace(EditSQLAddSQuot, vbCr, "")        'INSERT 2014/01/30 AOKI
        EditSQLAddSQuot = Replace(EditSQLAddSQuot, vbLf, "")        'INSERT 2014/01/30 AOKI

    End Function
End Module
