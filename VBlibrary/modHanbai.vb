Imports System.Windows.Forms
Imports clswinApi
Imports globalcls.modHanbai

Public Module modHanbai

    'ƒo[ƒWƒ‡ƒ“î•ñ
    Public stvVersionNumber As String
    Public stvVersionTitle As String

    '‹âsƒ}ƒXƒ^ŽQÆ—pƒOƒ[ƒoƒ‹•Ï”
    Public pviGMode As Integer  ' 0:‹âsŒŸõ 1:Žx“XŒŸõ
    Public pviGCode As Integer  ' ‹âsº°ÄÞ

    'ƒRƒ“ƒgƒ[ƒ‹ƒ}ƒXƒ^(‰ïŽÐî•ñ)
    Public Structure CompanyInfo
        Public NAME As String      '‰ïŽÐ–¼
        Public POST As String      '—X•Ö”Ô†
        Public ADDRESS1 As String      'ZŠ‚P
        Public ADDRESS2 As String      'ZŠ‚Q
        Public TEL As String      '“d˜b”Ô†
        Public FAX As String      'FAX”Ô†
        Public MAIL As String      'Ò°Ù±ÄÞÚ½
        Public HP As String      'Î°ÑÍß°¼Þ
        Public LEADER As String      '‘ã•\ŽÒ–¼
    End Structure
    Public Company As CompanyInfo  '‰ïŽÐî•ñ

    'ƒRƒ“ƒgƒ[ƒ‹ƒ}ƒXƒ^ƒŒƒCƒAƒEƒg(‘S‚Ä)
    Public Structure ConMstInfo
        Public Con_001 As Integer      'ƒL[
        Public Con_002 As String       '‰ïŽÐ–¼(Š¿Žš)
        Public Con_003 As String       '—X•Ö”Ô†
        Public Con_004 As String       '‰ïŽÐZŠ1
        Public Con_005 As String       '‰ïŽÐZŠ2
        Public Con_006 As String       '“d˜b”Ô†
        Public Con_007 As String       'FAX”Ô†
        Public Con_008 As String       'Ò°Ù±ÄÞÚ½
        Public Con_009 As String       'Î°ÑÍß°¼Þ±ÄÞÚ½
        Public Con_010 As String       '‘ã•\ŽÒŽ–¼
        Public Con_011 As String       '
        Public Con_012 As String       '
        Public Con_013 As Integer      '‹æ•ª01
        Public Con_014 As Integer      '‹æ•ª02
        Public Con_015 As Integer      '‹æ•ª03
        Public Con_016 As Integer      '‹æ•ª04
        Public Con_017 As Integer      '‹æ•ª05
        Public Con_018 As Integer      '‹æ•ª06
        Public Con_019 As Integer      '‹æ•ª07
        Public Con_020 As Integer      '‹æ•ª08
        Public Con_021 As Integer      '‹æ•ª09
        Public Con_022 As Integer      '‹æ•ª10
        Public Con_023 As Decimal     '”„ãŠÇ—”Ô†
        Public Con_024 As Decimal     '“ü‹àŠÇ—”Ô†
        Public Con_025 As Decimal     'Žd“üŠÇ—”Ô†
        Public Con_026 As Decimal     'Žx•¥ŠÇ—”Ô†
        Public Con_027 As Decimal     '¿‹ŠÇ—”Ô†
        Public Con_028 As Decimal     '”„Š|ŠÇ—”Ô†
        Public Con_029 As Decimal     '”ƒŠ|ŠÇ—”Ô†
        Public Con_030 As Decimal     '—\”õŠÇ—”Ô†1
        Public Con_031 As Decimal     '—\”õŠÇ—”Ô†2
        Public Con_032 As Decimal     '—\”õŠÇ—”Ô†3
        Public Con_033 As Decimal     'Á”ïÅ—¦1
        Public Con_034 As Decimal     'Á”ïÅ—¦2
        Public Con_035 As String       'ŠúŽñ”N“x
        Public Con_036 As String       'ŠúŽñ”NŒŽ“ú
        Public Con_037 As String       'Šú––”NŒŽ“ú
        Public Con_038 As String       'Á”ïÅ—¦1‚Ì“ú•t
        Public Con_039 As String       'Á”ïÅ—¦2‚Ì“ú•t
        Public Con_040 As Integer      '‹âsƒR[ƒh
        Public Con_041 As Integer      'Žx“XƒR[ƒh
        Public Con_042 As Integer      'ŒûÀŽí•Ê
        Public Con_043 As String       'ŒûÀ”Ô†
        Public Con_044 As String       'ˆË—ŠlƒR[ƒh
        Public Con_045 As String       'ˆË—Šl–¼Ì
        Public Con_046 As String      'ÅIÊÞ¯¸±¯ÌßŽÀs“ú•t
        Public Con_047 As String        '—\”õ“ú•t1
        Public Con_048 As String       '—\”õ“ú•t2
    End Structure

    '“¾ˆÓæƒ}ƒXƒ^ƒŒƒCƒAƒEƒg
    Public Structure TokMstInfo
        Public Tok_001 As Decimal     '“¾ˆÓæº°ÄÞ
        Public Tok_002 As Long         '‰c‹ÆŠº°ÄÞ
        Public Tok_003 As String       '“¾ˆÓæ–¼‚PiŠ¿Žšj
        Public Tok_004 As String       '“¾ˆÓæ–¼‚QiŠ¿Žšj
        Public Tok_005 As String       '“¾ˆÓæ–¼i—ªÌj
        Public Tok_006 As String       '“¾ˆÓæ–¼iƒJƒij
        Public Tok_007 As String       '—X•Ö”Ô†
        Public Tok_008 As String       'ZŠ‚PiŠ¿Žšj
        Public Tok_009 As String       'ZŠ‚QiŠ¿Žšj
        Public Tok_010 As String       '“d˜b”Ô†
        Public Tok_011 As String       'FAX”Ô†
        Public Tok_012 As String       '’S“–ŽÒ–¼‚PiŠ¿Žšj
        Public Tok_013 As String       '’S“–ŽÒ–¼‚QiŠ¿Žšj
        Public Tok_014 As String       'Ò°Ù±ÄÞÚ½
        Public Tok_0141 As String       '±¶³ÝÄÒ°Ù±ÄÞÚ½          'INSERT 2018/10/30 AOKI
        Public Tok_0142 As String       '±¶³ÝÄ’S“–ŽÒ–¼          'INSERT 2018/10/31 AOKI
        Public Tok_015 As String       'Œg‘Ñ”Ô†
        Public Tok_016 As String       '
        Public Tok_017 As String       '
        Public Tok_018 As Integer      '‹æ•ª01 ¬”“_‹æ•ª(ŽlŽÌŒÜ“ü“™)
        Public Tok_019 As Integer      '‹æ•ª02 Á”ïÅ‹æ•ª(“àÅEŠOÅ“™)
        Public Tok_020 As Integer      '‹æ•ª03 Á”ïÅŒvŽZ‹æ•ª(ŽlŽÌŒÜ“ü“™)
        Public Tok_021 As Integer      '‹æ•ª04 Á”ïÅŒvŽZ’PˆÊ‹æ•ª(“`•[’PˆÊE¿‹’PˆÊ“™)
        Public Tok_022 As Integer      '‹æ•ª05 ¿‹‘ˆóŽš‹æ•ª(‚·‚éE‚µ‚È‚¢“™)
        Public Tok_023 As Integer      '‹æ•ª06 ¿‹‘ŽcˆóŽš‹æ•ª(‚·‚éE‚µ‚È‚¢“™)
        Public Tok_024 As Integer      '‹æ•ª07 ƒJƒXƒ^ƒ€ƒCƒ“ƒ{ƒCƒXˆóŽš‹æ•ª(‚·‚éE‚µ‚È‚¢“™)
        Public Tok_025 As Integer      '‹æ•ª08 ŒhÌ‹æ•ª(—lEŒä’†“™)
        Public Tok_026 As Integer      '‹æ•ª09
        Public Tok_027 As Integer      '‹æ•ª10 ’÷‹æ•ª1(“–ŒŽE—‚ŒŽ“™)
        Public Tok_028 As Integer      '‹æ•ª11 ’÷‹æ•ª2(“–ŒŽE—‚ŒŽ“™)
        Public Tok_029 As Integer      '‹æ•ª12 ’÷‹æ•ª3(“–ŒŽE—‚ŒŽ“™)
        Public Tok_030 As Integer      '‹æ•ª13 ‰ñŽû‹æ•ª1(UžEW‹à“™)
        Public Tok_031 As Integer      '‹æ•ª14 ‰ñŽû‹æ•ª2(UžEW‹à“™)
        Public Tok_032 As Integer      '‹æ•ª15 ‰ñŽû‹æ•ª3(UžEW‹à“™)
        Public Tok_033 As Integer      '’÷“ú1
        Public Tok_034 As Integer      '’÷“ú2
        Public Tok_035 As Integer      '’÷“ú3
        Public Tok_036 As Integer      '‰ñŽû“ú1
        Public Tok_037 As Integer      '‰ñŽû“ú2
        Public Tok_038 As Integer      '‰ñŽû“ú3
        Public Tok_039 As String       'ÅI”„ã“ú
        Public Tok_040 As String       'ÅI¿‹‘”­s“ú
        Public Tok_041 As String       '
        Public Tok_042 As Decimal     '¿‹Žc‹àŠz
        Public Tok_043 As Decimal     '”„Š|Žc‹àŠz
        Public Tok_044 As Decimal     '
        Public Tok_045 As Decimal     '
        Public Tok_046 As Decimal     '
        Public Tok_047 As String       '
        Public Tok_048 As String       '
        Public Tok_049 As String       '
        Public Tok_050 As String       '
        Public Tok_051 As String       '“–ŽÐ’S“–ŽÒ         'INSERT 2014/01/31 AOKI
        Public Tok_052 As String       'Žd–ó“E—v—“—p       'INSERT 2014/02/28 AOKI
        Public Tok_053 As Decimal     '—˜‰v—¦             'INSERT 2014/04/04 AOKI
        Public Tok_054 As String       '‘–¼               'INSERT 2014/12/12 AOKI
        Public Tok_055 As String       '                   'INSERT 2015/11/13 AOKI
        Public Tok_056 As String       'ŽæˆøŠJŽn”NŒŽ“ú     'INSERT 2015/11/13 AOKI
        Public Tok_057 As Decimal     '”„Š|ãŒÀ‹àŠz       'INSERT 2019/01/25 AOKI
    End Structure

    '“¾ˆÓæ’S“–ŽÒƒ}ƒXƒ^ƒŒƒCƒAƒEƒg
    Public Structure TokTMstInfo
        Public TokT_001 As Decimal     '“¾ˆÓæº°ÄÞ
        Public TokT_002 As Long         '‰c‹ÆŠº°ÄÞ
        Public TokT_003 As String       '’S“–ŽÒ01
        Public TokT_004 As String       '’S“–ŽÒ02
        Public TokT_005 As String       '’S“–ŽÒ03
        Public TokT_006 As String       '’S“–ŽÒ04
        Public TokT_007 As String       '’S“–ŽÒ05
        Public TokT_008 As String       '’S“–ŽÒ06
        Public TokT_009 As String       '’S“–ŽÒ07
        Public TokT_010 As String       '’S“–ŽÒ08
        Public TokT_011 As String       '’S“–ŽÒ09
        Public TokT_012 As String       '’S“–ŽÒ10
        Public TokT_013 As String       '’S“–ŽÒ11
        Public TokT_014 As String       '’S“–ŽÒ12
        Public TokT_015 As String       '’S“–ŽÒ13
        Public TokT_016 As String       '’S“–ŽÒ14
        Public TokT_017 As String       '’S“–ŽÒ15
        Public TokT_018 As String       '’S“–ŽÒ16
        Public TokT_019 As String       '’S“–ŽÒ17
        Public TokT_020 As String       '’S“–ŽÒ18
        Public TokT_021 As String       '’S“–ŽÒ19
        Public TokT_022 As String       '’S“–ŽÒ20
        Public TokT_023 As String       '
        Public TokT_024 As String       '
        Public TokT_025 As String       '
        Public TokT_026 As String       '
        Public TokT_027 As String       '
    End Structure

    'Žd“üæƒ}ƒXƒ^ƒŒƒCƒAƒEƒg
    Public Structure SirMstInfo
        Public Sir_001 As Long         'Žd“üæº°ÄÞ
        Public Sir_002 As Long         '‰c‹ÆŠº°ÄÞ
        Public Sir_003 As String       'Žd“üæ–¼‚PiŠ¿Žšj
        Public Sir_004 As String       'Žd“üæ–¼‚QiŠ¿Žšj
        Public Sir_005 As String       'Žd“üæ–¼i—ªÌj
        Public Sir_006 As String       'Žd“üæ–¼iƒJƒij
        Public Sir_007 As String       '—X•Ö”Ô†
        Public Sir_008 As String       'ZŠ‚PiŠ¿Žšj
        Public Sir_009 As String       'ZŠ‚QiŠ¿Žšj
        Public Sir_010 As String       '“d˜b”Ô†
        Public Sir_011 As String       'FAX”Ô†
        Public Sir_012 As String       '’S“–ŽÒ–¼‚PiŠ¿Žšj
        Public Sir_013 As String       '’S“–ŽÒ–¼‚QiŠ¿Žšj
        Public Sir_014 As String       'Ò°Ù±ÄÞÚ½
        Public Sir_015 As String       'Œg‘Ñ”Ô†
        Public Sir_016 As String       '
        Public Sir_017 As String       '
        Public Sir_018 As Integer      '‹æ•ª01 ¬”“_‹æ•ª(ŽlŽÌŒÜ“ü“™)
        Public Sir_019 As Integer      '‹æ•ª02 Á”ïÅ‹æ•ª(“àÅEŠOÅ“™)
        Public Sir_020 As Integer      '‹æ•ª03 Á”ïÅŒvŽZ‹æ•ª(ŽlŽÌŒÜ“ü“™)
        Public Sir_021 As Integer      '‹æ•ª04 Á”ïÅŒvŽZ’PˆÊ‹æ•ª(“`•[’PˆÊE¿‹’PˆÊ“™)
        Public Sir_022 As Integer      '‹æ•ª05
        Public Sir_023 As Integer      '‹æ•ª06
        Public Sir_024 As Integer      '‹æ•ª07
        Public Sir_025 As Integer      '‹æ•ª08
        Public Sir_026 As Integer      '‹æ•ª09
        Public Sir_027 As Integer      '‹æ•ª10 ’÷‹æ•ª1(“–ŒŽE—‚ŒŽ“™)
        Public Sir_028 As Integer      '‹æ•ª11 ’÷‹æ•ª2(“–ŒŽE—‚ŒŽ“™)
        Public Sir_029 As Integer      '‹æ•ª12 ’÷‹æ•ª3(“–ŒŽE—‚ŒŽ“™)
        Public Sir_030 As Integer      '‹æ•ª13 Žx•¥‹æ•ª1(UžEW‹à“™)
        Public Sir_031 As Integer      '‹æ•ª14 Žx•¥‹æ•ª2(UžEW‹à“™)
        Public Sir_032 As Integer      '‹æ•ª15 Žx•¥‹æ•ª3(UžEW‹à“™)
        Public Sir_033 As Integer      '’÷“ú1
        Public Sir_034 As Integer      '’÷“ú2
        Public Sir_035 As Integer      '’÷“ú3
        Public Sir_036 As Integer      'Žx•¥“ú1
        Public Sir_037 As Integer      'Žx•¥“ú2
        Public Sir_038 As Integer      'Žx•¥“ú3
        Public Sir_039 As String       'ÅI”„ã“ú
        Public Sir_040 As String       '
        Public Sir_041 As String       '
        Public Sir_042 As Decimal     '
        Public Sir_043 As Decimal     '
        Public Sir_044 As Decimal     '‹âsƒR[ƒh
        Public Sir_045 As Decimal     'Žx“XƒR[ƒh
        Public Sir_046 As Decimal     'ŒûÀŽí•Ê
        Public Sir_047 As String       'ŒûÀ”Ô†
        Public Sir_048 As String       'Užl–¼Ì
        Public Sir_049 As String       '
        Public Sir_050 As String       '
    End Structure

    '”[•iæƒ}ƒXƒ^ƒŒƒCƒAƒEƒg
    Public Structure NouMstInfo
        Public Nou_001 As Long         '”[•iæº°ÄÞ
        Public Nou_002 As Long         '‰c‹ÆŠº°ÄÞ
        Public Nou_003 As String       '”[•iæ–¼‚PiŠ¿Žšj
        Public Nou_004 As String       '”[•iæ–¼‚QiŠ¿Žšj
        Public Nou_005 As String       '”[•iæ–¼i—ªÌj
        Public Nou_006 As String       '”[•iæ–¼iƒJƒij
        Public Nou_007 As String       '—X•Ö”Ô†
        Public Nou_008 As String       'ZŠ‚PiŠ¿Žšj
        Public Nou_009 As String       'ZŠ‚QiŠ¿Žšj
        Public Nou_010 As String       '“d˜b”Ô†
        Public Nou_011 As String       'FAX”Ô†
        Public Nou_012 As String       '’S“–ŽÒ–¼‚PiŠ¿Žšj
        Public Nou_013 As String       '’S“–ŽÒ–¼‚QiŠ¿Žšj
        Public Nou_014 As String       'Ò°Ù±ÄÞÚ½
        Public Nou_015 As String       'Œg‘Ñ”Ô†
    End Structure

    '¤•iƒ}ƒXƒ^ƒŒƒCƒAƒEƒg
    Public Structure SyoMstInfo
        Public Syo_001 As Long         '¤•iº°ÄÞ
        Public Syo_002 As Long         '»ÌÞº°ÄÞ
        Public Syo_003 As String       '¤•i–¼Ì‚PiŠ¿Žšj
        Public Syo_004 As String       '¤•i–¼Ì‚QiŠ¿Žšj
        Public Syo_005 As String       '¤•i–¼ÌiƒJƒij
        Public Syo_006 As String       '‹L†
        Public Syo_007 As String       '•ª—Þ
        Public Syo_008 As String       '‹KŠi
        Public Syo_009 As String       '
        Public Syo_010 As Decimal     '“ü”
        Public Syo_011 As Decimal     '
        Public Syo_012 As String       'JANƒR[ƒh
        Public Syo_013 As String       '
        Public Syo_014 As String       '
        Public Syo_015 As String       '’PˆÊ–¼Ì‚P
        Public Syo_016 As String       '’PˆÊ–¼Ì‚Q
        Public Syo_017 As String       '
        Public Syo_018 As Decimal     'ã‘ã’P‰¿    (Å”²)
        Public Syo_019 As Decimal     'ã‘ã’P‰¿    (Å”²)
        Public Syo_020 As Decimal     'ÅIŽd“ü’P‰¿(Å”²)
        Public Syo_021 As Decimal     'ÅIŽd“ü’P‰¿(Åž)
        Public Syo_022 As Decimal     'ÅI”„ã’P‰¿(Å”²)
        Public Syo_023 As Decimal     'ÅI”„ã’P‰¿(Åž)
        Public Syo_024 As Decimal     '
        Public Syo_025 As Decimal     '
        Public Syo_026 As Decimal     'ÝŒÉŽc”—Ê(’PˆÊ‚P)
        Public Syo_027 As Decimal     '“üŒÉ—ÝŒv”(’PˆÊ‚P)
        Public Syo_028 As Decimal     'oŒÉ—ÝŒv”(’PˆÊ‚P)
        Public Syo_029 As Decimal     'ÝŒÉ’²®”(’PˆÊ‚P)
        Public Syo_030 As Decimal     'ŽÀÝŒÉ”—Ê(’PˆÊ‚P)
        Public Syo_031 As Decimal     '
        Public Syo_032 As Decimal     'ÝŒÉŽc”—Ê(’PˆÊ‚Q)
        Public Syo_033 As Decimal     '“üŒÉ—ÝŒv”(’PˆÊ‚Q)
        Public Syo_034 As Decimal     'oŒÉ—ÝŒv”(’PˆÊ‚Q)
        Public Syo_035 As Decimal     'ÝŒÉ’²®”(’PˆÊ‚Q)
        Public Syo_036 As Decimal     'ŽÀÝŒÉ”—Ê(’PˆÊ‚Q)
        Public Syo_037 As Decimal     '
        Public Syo_038 As Decimal     '
        Public Syo_039 As String       'ÅIŽd“ü“ú
        Public Syo_040 As String       'ÅI”„ã“ú
        Public Syo_041 As String       '
    End Structure

    '‹âsƒ}ƒXƒ^ƒŒƒCƒAƒEƒg
    Public Structure GinMstInfo
        Public Gin_001 As Long         '‹âsº°ÄÞ
        Public Gin_002 As Long         'Žx“Xº°ÄÞ
        Public Gin_003 As String       '‹âs–¼iŠ¿Žšj
        Public Gin_004 As String       'Žx“X–¼iŠ¿Žšj
        Public Gin_005 As String       '‹âs–¼i¶Åj
        Public Gin_006 As String       'Žx“X–¼i¶Åj
    End Structure

    '‹æ•ª–¼Ìƒ}ƒXƒ^ƒŒƒCƒAƒEƒg
    Public Structure KbnMstInfo
        Public Kbn_001 As Long         '•ª—Þº°ÄÞ
        Public Kbn_002 As String       '‹æ•ª–¼
        Public Kbn_003 As Integer      'Ž}”Ô
        Public Kbn_004 As String       '‹æ•ª–¼Ì(‰æ–Ê—p)
        Public Kbn_005 As String       '‹æ•ª–¼Ì(ˆóü—p)
        Public Kbn_006 As String       '
        Public Kbn_007 As String       '
    End Structure


    '■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
    '               メッセージ情報
    '■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
    Public Const gstGUIDE_M001 As String = "を入力して下さい。"
    Public Const gstGUIDE_M002 As String = "を選択して下さい。"
    Public Const gstGUIDE_Q001 As String = "を終了します。よろしいですか？"
    Public Const gstGUIDE_Q002 As String = "データの追加を行います。よろしいですか？"
    Public Const gstGUIDE_Q003 As String = "データの訂正を行います。よろしいですか？"
    Public Const gstGUIDE_Q004 As String = "データの削除を行います。よろしいですか？"
    Public Const gstGUIDE_Q010 As String = "のプレビューを行います。よろしいですか？"
    Public Const gstGUIDE_Q011 As String = "の印刷を行います。よろしいですか？"
    Public Const gstGUIDE_Q012 As String = "取消しを行います。よろしいですか？"
    Public Const gstGUIDE_Q013 As String = "画面をクリアします。よろしいですか？"
    Public Const gstGUIDE_E001 As String = "モード選択されていません。"
    Public Const gstGUIDE_E002 As String = "データの追加に失敗しました。"
    Public Const gstGUIDE_E003 As String = "データの訂正に失敗しました。"
    Public Const gstGUIDE_E004 As String = "データの削除に失敗しました。"
    Public Const gstGUIDE_E005 As String = "対象データが存在しません。"
    Public Const gstGUIDE_E006 As String = "既にデータが存在します。"
    Public Const gstGUIDE_E011 As String = "が入力されていません。"
    Public Const gstGUIDE_E012 As String = "が選択されていません。"
    Public Const gstGUIDE_E013 As String = "の入力に誤りがあります。"
    Public Const gstGUIDE_E014 As String = "の大小関係に誤りがあります。"


    '***************************************************************
    '**  名称    : Function stComboSetKubun() As Boolean
    '**  機能    : 区分名称マスタからコンボデータを設定する。
    '**  戻り値  : True;正常終了 , False;エラー
    '**  引数    : voCBctl  : コンボボックスコントロール
    '**            viGyomu  : 分類
    '**            vsKbnNm  : 区分名
    '**  備考    :
    '***************************************************************
    Public Function stComboSetKubun(voCBctl As ComboBox, viGyomu As Integer,
                                    vsKbnNm As String) As Boolean

        Dim SQLtxt As String

        '区分名称検索SQL作成
        SQLtxt = "SELECT Kbn_003, Kbn_004"
        SQLtxt = SQLtxt & "  FROM Kbn_Mst"
        SQLtxt = SQLtxt & " WHERE Kbn_001 = " & viGyomu
        SQLtxt = SQLtxt & "   AND Kbn_002 ='" & vsKbnNm & "'"
        SQLtxt = SQLtxt & " ORDER BY Kbn_003"
        'コンボに設定
        stComboSetKubun = stComboSetData(voCBctl, SQLtxt)

    End Function


    '***************************************************************
    '**  名称    : Public Sub GetCompanyInfo()
    '**  機能    : 会社情報(コントロールマスタ)の取得
    '**  戻り値  :
    '**  引数    :
    '**  備考    :
    '***************************************************************
    Public Sub GetCompanyInfo()

        Dim SQLtxt As String

        '== コントロールマスター(会社情報)読込みSQL文作成 ==============
        SQLtxt = ""
        SQLtxt = SQLtxt & "SELECT * FROM Con_Mst"
        SQLtxt = SQLtxt & " WHERE Con_001 = 1"

        '== コントロールマスター(会社情報)読込み =======================
        Dim dt As DataTable

        Dim dbsvc As New clsDB.DBService()
        dt = dbsvc.GetDatafromDB(SQLtxt)


        If dt.Rows.Count() > 0 Then
            With Company
                'データセット
                .NAME = NCnvN(dt.Rows(0)("Con_002").ToString())      ' 会社名
                .POST = NCnvN(dt.Rows(0)("Con_003").ToString())     ' 郵便番号
                .ADDRESS1 = NCnvN(dt.Rows(0)("Con_004").ToString())  ' 住所１
                .ADDRESS2 = NCnvN(dt.Rows(0)("Con_005").ToString()) ' 住所２
                .TEL = NCnvN(dt.Rows(0)("Con_006").ToString())      ' 電話番号
                .FAX = NCnvN(dt.Rows(0)("Con_007").ToString())    ' FAX番号
                .MAIL = NCnvN(dt.Rows(0)("Con_008").ToString())     ' ﾒｰﾙｱﾄﾞﾚｽ
                .HP = NCnvN(dt.Rows(0)("Con_009").ToString())     ' ﾎｰﾑﾍﾟｰｼﾞ
                .LEADER = NCnvN(dt.Rows(0)("Con_010").ToString())   ' 代表者氏名
            End With
        End If


    End Sub
    Public Function NCnvN(buf As Object) As String
        If IsDBNull(buf) Then
            NCnvN = ""
        ElseIf buf.ToString() = "" Then
            NCnvN = ""
        Else
            NCnvN = buf.ToString()
        End If

    End Function
    Public Function NCnvZ(buf As Object) As String
        Dim tempout As Decimal
        If IsDBNull(buf) Then
            NCnvZ = 0
        ElseIf buf.ToString() = "" Then
            NCnvZ = 0
        Else
            If Decimal.TryParse(buf.ToString, tempout) Then
                NCnvZ = Decimal.Parse(buf.ToString()).ToString("G29")
            Else
                NCnvZ = buf.ToString()
            End If

        End If

    End Function



    '***************************************************************
    '**  名称    : Function GetConMstInfo()
    '**  機能    : コントロールマスタの読込み処理
    '**  戻り値  :
    '**  引数    : ConMst : コントロールマスタ情報
    '**  備考    :
    '***************************************************************
    Public Function GetConMstInfo(ByRef ConMst As ConMstInfo) As Boolean

        Dim SQLtxt As String

        GetConMstInfo = False

        '== コントロールマスタ読込み用SQL文作成 ========================
        SQLtxt = ""
        SQLtxt = SQLtxt & "SELECT * FROM Con_Mst"
        SQLtxt = SQLtxt & " WHERE Con_001 = 1"

        '== コントロールマスタの読込み =================================
        Dim dt As DataTable

        Dim dbsvc As New clsDB.DBService()
        dt = dbsvc.GetDatafromDB(SQLtxt)

        If dt.Rows.Count() > 0 Then
            With ConMst
                .Con_001 = NCnvZ(dt.Rows(0)("Con_001").ToString())     'キー
                .Con_002 = NCnvN(dt.Rows(0)("Con_002").ToString())     '会社名(漢字)
                .Con_003 = NCnvN(dt.Rows(0)("Con_003").ToString())     '郵便番号
                .Con_004 = NCnvN(dt.Rows(0)("Con_004").ToString())     '会社住所1
                .Con_005 = NCnvN(dt.Rows(0)("Con_005").ToString())     '会社住所2
                .Con_006 = NCnvN(dt.Rows(0)("Con_006").ToString())     '電話番号
                .Con_007 = NCnvN(dt.Rows(0)("Con_007").ToString())     'FAX番号
                .Con_008 = NCnvN(dt.Rows(0)("Con_008").ToString())     'ﾒｰﾙｱﾄﾞﾚｽ
                .Con_009 = NCnvN(dt.Rows(0)("Con_009").ToString())     'ﾎｰﾑﾍﾟｰｼﾞｱﾄﾞﾚｽ
                .Con_010 = NCnvN(dt.Rows(0)("Con_010").ToString())     '代表者氏名
                .Con_011 = NCnvN(dt.Rows(0)("Con_011").ToString())     '
                .Con_012 = NCnvN(dt.Rows(0)("Con_012").ToString())     '
                .Con_013 = NCnvZ(dt.Rows(0)("Con_013").ToString())     '区分01
                .Con_014 = NCnvZ(dt.Rows(0)("Con_014").ToString())     '区分02
                .Con_015 = NCnvZ(dt.Rows(0)("Con_015").ToString())     '区分03
                .Con_016 = NCnvZ(dt.Rows(0)("Con_016").ToString())     '区分04
                .Con_017 = NCnvZ(dt.Rows(0)("Con_017").ToString())     '区分05
                .Con_018 = NCnvZ(dt.Rows(0)("Con_018").ToString())     '区分06
                .Con_019 = NCnvZ(dt.Rows(0)("Con_019").ToString())     '区分07
                .Con_020 = NCnvZ(dt.Rows(0)("Con_020").ToString())     '区分08
                .Con_021 = NCnvZ(dt.Rows(0)("Con_021").ToString())     '区分09
                .Con_022 = NCnvZ(dt.Rows(0)("Con_022").ToString())     '区分10
                .Con_023 = NCnvZ(dt.Rows(0)("Con_023").ToString())     '売上管理番号
                .Con_024 = NCnvZ(dt.Rows(0)("Con_024").ToString())     '入金管理番号
                .Con_025 = NCnvZ(dt.Rows(0)("Con_025").ToString())     '仕入管理番号
                .Con_026 = NCnvZ(dt.Rows(0)("Con_026").ToString())     '支払管理番号
                .Con_027 = NCnvZ(dt.Rows(0)("Con_027").ToString())     '請求管理番号
                .Con_028 = NCnvZ(dt.Rows(0)("Con_028").ToString())     '売掛管理番号
                .Con_029 = NCnvZ(dt.Rows(0)("Con_029").ToString())     '買掛管理番号
                .Con_030 = NCnvZ(dt.Rows(0)("Con_030").ToString())     '予備管理番号1
                .Con_031 = NCnvZ(dt.Rows(0)("Con_031").ToString())     '予備管理番号2
                .Con_032 = NCnvZ(dt.Rows(0)("Con_032").ToString())     '予備管理番号3
                .Con_033 = NCnvZ(dt.Rows(0)("Con_033").ToString())     '消費税率1
                .Con_034 = NCnvZ(dt.Rows(0)("Con_034").ToString())     '消費税率2
                .Con_035 = NCnvN(dt.Rows(0)("Con_035").ToString())     '期首年度
                .Con_036 = NCnvN(dt.Rows(0)("Con_036").ToString())     '期首年月日
                .Con_037 = NCnvN(dt.Rows(0)("Con_037").ToString())     '期末年月日
                .Con_038 = NCnvN(dt.Rows(0)("Con_038").ToString())     '消費税率1の日付
                .Con_039 = NCnvN(dt.Rows(0)("Con_039").ToString())     '消費税率2の日付
                .Con_040 = NCnvZ(dt.Rows(0)("Con_040").ToString())     '銀行コード
                .Con_041 = NCnvZ(dt.Rows(0)("Con_041").ToString())     '支店コード
                .Con_042 = NCnvZ(dt.Rows(0)("Con_042").ToString())     '口座種別
                .Con_043 = NCnvN(dt.Rows(0)("Con_043").ToString())     '口座番号
                .Con_044 = NCnvN(dt.Rows(0)("Con_044").ToString())     '依頼人コード
                .Con_045 = NCnvN(dt.Rows(0)("Con_045").ToString())     '依頼人名称
                .Con_046 = NCnvN(dt.Rows(0)("Con_046").ToString())     '最終ﾊﾞｯｸｱｯﾌﾟ実行日付
                .Con_047 = NCnvN(dt.Rows(0)("Con_047").ToString())     '予備日付1
                .Con_048 = NCnvN(dt.Rows(0)("Con_048").ToString())     '予備日付2
            End With
        Else
            GoTo GetConMstInfo_Exit
        End If

        GetConMstInfo = True

GetConMstInfo_Exit:
        Exit Function

    End Function

    '***************************************************************
    '**  名称    : Sub GetTokMstInfo()
    '**  機能    : 得意先マスタの読込み処理
    '**  戻り値  :
    '**  引数    : TokMst : 得意先マスタ情報
    '**          : viMode : 0 対象データ
    '**          :        : 1 次データ
    '**          :        : 2 前データ
    '**  備考    :
    '***************************************************************
    Public Function GetTokMstInfo(TokMst As TokMstInfo,
                                  viMode As Integer) As Boolean

        Dim SQLtxt As String


        GetTokMstInfo = False

        With TokMst
            '===得意先マスタ読込み用SQL文作成===================================
            SQLtxt = ""
            SQLtxt = SQLtxt & "SELECT * FROM Tok_Mst"
            Select Case viMode
                Case 0 '対象データ
                    SQLtxt = SQLtxt & " WHERE Tok_001 = " & .Tok_001.ToString()
                Case 1 '次データ
                    SQLtxt = SQLtxt & " WHERE Tok_001 = "
                    SQLtxt = SQLtxt & " ( SELECT MIN(Tok_001) FROM Tok_Mst"
                    SQLtxt = SQLtxt & "    WHERE Tok_001 > " & .Tok_001.ToString() & ")"
                Case 2 '前データ
                    SQLtxt = SQLtxt & " WHERE Tok_001 = "
                    SQLtxt = SQLtxt & " ( SELECT MAX(Tok_001) FROM Tok_Mst"
                    SQLtxt = SQLtxt & "    WHERE Tok_001 < " & .Tok_001.ToString() & ")"
            End Select
            '===得意先マスタの読込み============================================
            Dim dt As DataTable

            Dim dbsvc As New clsDB.DBService()
            dt = dbsvc.GetDatafromDB(SQLtxt)

            If dt.Rows.Count() > 0 Then
                .Tok_001 = NCnvZ(dt.Rows(0)("Tok_001").ToString())     '得意先ｺｰﾄﾞ
                .Tok_002 = NCnvZ(dt.Rows(0)("Tok_002").ToString())     '営業所ｺｰﾄﾞ
                .Tok_003 = NCnvN(dt.Rows(0)("Tok_003").ToString())     '得意先名１（漢字）
                .Tok_004 = NCnvN(dt.Rows(0)("Tok_004").ToString())     '得意先名２（漢字）
                .Tok_005 = NCnvN(dt.Rows(0)("Tok_005").ToString())     '得意先名（略称）
                .Tok_006 = NCnvN(dt.Rows(0)("Tok_006").ToString())     '得意先名（カナ）
                .Tok_007 = NCnvN(dt.Rows(0)("Tok_007").ToString())     '郵便番号
                .Tok_008 = NCnvN(dt.Rows(0)("Tok_008").ToString())     '住所１（漢字）
                .Tok_009 = NCnvN(dt.Rows(0)("Tok_009").ToString())     '住所２（漢字）
                .Tok_010 = NCnvN(dt.Rows(0)("Tok_010").ToString())     '電話番号
                .Tok_011 = NCnvN(dt.Rows(0)("Tok_011").ToString())     'FAX番号
                .Tok_012 = NCnvN(dt.Rows(0)("Tok_012").ToString())     '担当者名１（漢字）
                .Tok_013 = NCnvN(dt.Rows(0)("Tok_013").ToString())     '担当者名２（漢字）
                .Tok_014 = NCnvN(dt.Rows(0)("Tok_014").ToString())     'ﾒｰﾙｱﾄﾞﾚｽ
                .Tok_0141 = NCnvN(dt.Rows(0)("Tok_0141").ToString())   'ｱｶｳﾝﾄﾒｰﾙｱﾄﾞﾚｽ           'INSERT 2018/10/30 AOKI
                .Tok_0142 = NCnvN(dt.Rows(0)("Tok_0142").ToString())   'ｱｶｳﾝﾄ担当者名           'INSERT 2018/10/31 AOKI
                .Tok_015 = NCnvN(dt.Rows(0)("Tok_015").ToString())     '携帯番号
                .Tok_016 = NCnvN(dt.Rows(0)("Tok_016").ToString())     '
                .Tok_017 = NCnvN(dt.Rows(0)("Tok_017").ToString())     '
                .Tok_018 = NCnvZ(dt.Rows(0)("Tok_018").ToString())     '区分01 小数点区分(四捨五入等)
                .Tok_019 = NCnvZ(dt.Rows(0)("Tok_019").ToString())     '区分02 消費税区分(内税・外税等)
                .Tok_020 = NCnvZ(dt.Rows(0)("Tok_020").ToString())     '区分03 消費税計算区分(四捨五入等)
                .Tok_021 = NCnvZ(dt.Rows(0)("Tok_021").ToString())     '区分04 消費税計算単位区分(伝票単位・請求単位等)
                .Tok_022 = NCnvZ(dt.Rows(0)("Tok_022").ToString())     '区分05 請求書印字区分(する・しない等)
                .Tok_023 = NCnvZ(dt.Rows(0)("Tok_023").ToString())     '区分06 請求書残印字区分(する・しない等)
                .Tok_024 = NCnvZ(dt.Rows(0)("Tok_024").ToString())     '区分07 カスタムインボイス印字区分(する・しない等)
                .Tok_025 = NCnvZ(dt.Rows(0)("Tok_025").ToString())     '区分08 敬称区分(様・御中等)
                .Tok_026 = NCnvZ(dt.Rows(0)("Tok_026").ToString())     '区分09
                .Tok_027 = NCnvZ(dt.Rows(0)("Tok_027").ToString())     '区分10 締区分1(当月・翌月等)
                .Tok_028 = NCnvZ(dt.Rows(0)("Tok_028").ToString())     '区分11 締区分2(当月・翌月等)
                .Tok_029 = NCnvZ(dt.Rows(0)("Tok_029").ToString())     '区分12 締区分3(当月・翌月等)
                .Tok_030 = NCnvZ(dt.Rows(0)("Tok_030").ToString())     '区分13 回収区分1(振込・集金等)
                .Tok_031 = NCnvZ(dt.Rows(0)("Tok_031").ToString())     '区分14 回収区分2(振込・集金等)
                .Tok_032 = NCnvZ(dt.Rows(0)("Tok_032").ToString())     '区分15 回収区分3(振込・集金等)
                .Tok_033 = NCnvZ(dt.Rows(0)("Tok_033").ToString())     '締日1
                .Tok_034 = NCnvZ(dt.Rows(0)("Tok_034").ToString())     '締日2
                .Tok_035 = NCnvZ(dt.Rows(0)("Tok_035").ToString())     '締日3
                .Tok_036 = NCnvZ(dt.Rows(0)("Tok_036").ToString())     '回収日1
                .Tok_037 = NCnvZ(dt.Rows(0)("Tok_037").ToString())     '回収日2
                .Tok_038 = NCnvZ(dt.Rows(0)("Tok_038").ToString())     '回収日3
                .Tok_039 = NCnvN(dt.Rows(0)("Tok_039").ToString())     '最終売上日
                .Tok_040 = NCnvN(dt.Rows(0)("Tok_040").ToString())     '最終請求書発行日
                .Tok_041 = NCnvN(dt.Rows(0)("Tok_041").ToString())     '
                .Tok_042 = NCnvZ(dt.Rows(0)("Tok_042").ToString())     '請求残金額
                .Tok_043 = NCnvZ(dt.Rows(0)("Tok_043").ToString())     '売掛残金額
                .Tok_044 = NCnvZ(dt.Rows(0)("Tok_044").ToString())     '
                .Tok_045 = NCnvZ(dt.Rows(0)("Tok_045").ToString())     '
                .Tok_046 = NCnvZ(dt.Rows(0)("Tok_046").ToString())     '
                .Tok_047 = NCnvN(dt.Rows(0)("Tok_047").ToString())     '
                .Tok_048 = NCnvN(dt.Rows(0)("Tok_048").ToString())     '
                .Tok_049 = NCnvN(dt.Rows(0)("Tok_049").ToString())     '
                .Tok_050 = NCnvN(dt.Rows(0)("Tok_050").ToString())     '
                .Tok_051 = NCnvN(dt.Rows(0)("Tok_051").ToString())     '当社担当者              'INSERT 2014/01/31 AOKI
                .Tok_052 = NCnvN(dt.Rows(0)("Tok_052").ToString())     '仕訳摘要欄用            'INSERT 2014/02/28 AOKI
                .Tok_053 = NCnvZ(dt.Rows(0)("Tok_053").ToString())     '利益率                  'INSERT 2014/04/04 AOKI
                .Tok_054 = NCnvN(dt.Rows(0)("Tok_054").ToString())     '国名                    'INSERT 2014/12/12 AOKI
                .Tok_055 = NCnvN(dt.Rows(0)("Tok_055").ToString())     '                        'INSERT 2015/11/13 AOKI
                .Tok_056 = NCnvN(dt.Rows(0)("Tok_056").ToString())     '取引開始年月日          'INSERT 2015/11/13 AOKI
                .Tok_057 = NCnvZ(dt.Rows(0)("Tok_057").ToString())     '売掛上限金額            'INSERT 2019/01/25 AOKI
            Else
                GoTo GetTokMstInfo_Exit
            End If
        End With

        GetTokMstInfo = True

GetTokMstInfo_Exit:

        Exit Function

    End Function

    '***************************************************************
    '**  名称    : Sub GetTokTMstInfo()
    '**  機能    : 得意先担当者マスタの読込み処理
    '**  戻り値  :
    '**  引数    : TokTMst : 得意先マスタ情報
    '**          : viMode : 0 対象データ
    '**  備考    :
    '***************************************************************
    Public Function GetTokTMstInfo(TokTMst As TokTMstInfo,
                                   viMode As Integer) As Boolean

        Dim SQLtxt As String

        GetTokTMstInfo = False

        With TokTMst
            '===得意先担当者マスタ読込み用SQL文作成===================================
            SQLtxt = ""
            SQLtxt = SQLtxt & "SELECT * FROM TokT_Mst"
            Select Case viMode
                Case 0 '対象データ
                    SQLtxt = SQLtxt & " WHERE TokT_001 = " & .TokT_001.ToString()
            End Select
            '===得意先担当者マスタの読込み============================================
            Dim dt As DataTable

            Dim dbsvc As New clsDB.DBService()
            dt = dbsvc.GetDatafromDB(SQLtxt)

            If dt.Rows.Count() > 0 Then
                .TokT_001 = NCnvZ(dt.Rows(0)("TTokT_001").ToString())     '得意先ｺｰﾄﾞ
                .TokT_002 = NCnvZ(dt.Rows(0)("TTokT_002").ToString())     '営業所ｺｰﾄﾞ
                .TokT_003 = NCnvN(dt.Rows(0)("TTokT_003").ToString())     '担当者01
                .TokT_004 = NCnvN(dt.Rows(0)("TTokT_004").ToString())     '担当者02
                .TokT_005 = NCnvN(dt.Rows(0)("TTokT_005").ToString())     '担当者03
                .TokT_006 = NCnvN(dt.Rows(0)("TTokT_006").ToString())     '担当者04
                .TokT_007 = NCnvN(dt.Rows(0)("TTokT_007").ToString())     '担当者05
                .TokT_008 = NCnvN(dt.Rows(0)("TTokT_008").ToString())     '担当者06
                .TokT_009 = NCnvN(dt.Rows(0)("TTokT_009").ToString())     '担当者07
                .TokT_010 = NCnvN(dt.Rows(0)("TTokT_010").ToString())     '担当者08
                .TokT_011 = NCnvN(dt.Rows(0)("TTokT_011").ToString())     '担当者09
                .TokT_012 = NCnvN(dt.Rows(0)("TTokT_012").ToString())     '担当者10
                .TokT_013 = NCnvN(dt.Rows(0)("TTokT_013").ToString())     '担当者11
                .TokT_014 = NCnvN(dt.Rows(0)("TTokT_014").ToString())     '担当者12
                .TokT_015 = NCnvN(dt.Rows(0)("TTokT_015").ToString())     '担当者13
                .TokT_016 = NCnvN(dt.Rows(0)("TTokT_016").ToString())     '担当者14
                .TokT_017 = NCnvN(dt.Rows(0)("TTokT_017").ToString())     '担当者15
                .TokT_018 = NCnvN(dt.Rows(0)("TTokT_018").ToString())     '担当者16
                .TokT_019 = NCnvN(dt.Rows(0)("TTokT_019").ToString())     '担当者17
                .TokT_020 = NCnvN(dt.Rows(0)("TTokT_020").ToString())     '担当者18
                .TokT_021 = NCnvN(dt.Rows(0)("TTokT_021").ToString())     '担当者19
                .TokT_022 = NCnvN(dt.Rows(0)("TTokT_022").ToString())     '担当者20
                .TokT_023 = NCnvN(dt.Rows(0)("TTokT_023").ToString())     '
                .TokT_024 = NCnvN(dt.Rows(0)("TTokT_024").ToString())     '
                .TokT_025 = NCnvN(dt.Rows(0)("TTokT_025").ToString())     '
                .TokT_026 = NCnvN(dt.Rows(0)("TTokT_026").ToString())     '
                .TokT_027 = NCnvN(dt.Rows(0)("TTokT_027").ToString())     '
            Else
                GoTo GetTokTMstInfo_Exit
            End If
        End With

        GetTokTMstInfo = True

GetTokTMstInfo_Exit:

        Exit Function

    End Function

    '***************************************************************
    '**  名称    : Sub GetSirMstInfo()
    '**  機能    : 仕入先マスタの読込み処理
    '**  戻り値  :
    '**  引数    : SirMst : 仕入先マスタ情報
    '**          : viMode : 0 対象データ
    '**          :        : 1 次データ
    '**          :        : 2 前データ
    '**  備考    :
    '***************************************************************
    Public Function GetSirMstInfo(SirMst As SirMstInfo,
                                  viMode As Integer) As Boolean

        Dim SQLtxt As String


        GetSirMstInfo = False

        With SirMst
            '===仕入先マスタ読込み用SQL文作成===================================
            SQLtxt = ""
            SQLtxt = SQLtxt & "Select * FROM Sir_Mst"
            Select Case viMode
                Case 0 '対象データ
                    SQLtxt = SQLtxt & " WHERE Sir_001 = " & .Sir_001
                Case 1 '次データ
                    SQLtxt = SQLtxt & " WHERE Sir_001 = "
                    SQLtxt = SQLtxt & " ( Select MIN(Sir_001) FROM Sir_Mst"
                    SQLtxt = SQLtxt & "    WHERE Sir_001 > " & .Sir_001 & ")"
                Case 2 '前データ
                    SQLtxt = SQLtxt & " WHERE Sir_001 = "
                    SQLtxt = SQLtxt & " ( Select MAX(Sir_001) FROM Sir_Mst"
                    SQLtxt = SQLtxt & "    WHERE Sir_001 < " & .Sir_001 & ")"
            End Select
            '===仕入先マスタの読込み============================================
            Dim dt As DataTable

            Dim dbsvc As New clsDB.DBService()
            dt = dbsvc.GetDatafromDB(SQLtxt)

            If dt.Rows.Count() > 0 Then
                .Sir_001 = NCnvZ(dt.Rows(0)("Sir_001").ToString())     '仕入先ｺｰﾄﾞ
                .Sir_002 = NCnvZ(dt.Rows(0)("Sir_002").ToString())     '営業所ｺｰﾄﾞ
                .Sir_003 = NCnvN(dt.Rows(0)("Sir_003").ToString())     '仕入先名１（漢字）
                .Sir_004 = NCnvN(dt.Rows(0)("Sir_004").ToString())     '仕入先名２（漢字）
                .Sir_005 = NCnvN(dt.Rows(0)("Sir_005").ToString())     '仕入先名（略称）
                .Sir_006 = NCnvN(dt.Rows(0)("Sir_006").ToString())     '仕入先名（カナ）
                .Sir_007 = NCnvN(dt.Rows(0)("Sir_007").ToString())     '郵便番号
                .Sir_008 = NCnvN(dt.Rows(0)("Sir_008").ToString())     '住所１（漢字）
                .Sir_009 = NCnvN(dt.Rows(0)("Sir_009").ToString())     '住所２（漢字）
                .Sir_010 = NCnvN(dt.Rows(0)("Sir_010").ToString())     '電話番号
                .Sir_011 = NCnvN(dt.Rows(0)("Sir_011").ToString())     'FAX番号
                .Sir_012 = NCnvN(dt.Rows(0)("Sir_012").ToString())     '担当者名１（漢字）
                .Sir_013 = NCnvN(dt.Rows(0)("Sir_013").ToString())     '担当者名２（漢字）
                .Sir_014 = NCnvN(dt.Rows(0)("Sir_014").ToString())     'ﾒｰﾙｱﾄﾞﾚｽ
                .Sir_015 = NCnvN(dt.Rows(0)("Sir_015").ToString())     '携帯番号
                .Sir_016 = NCnvN(dt.Rows(0)("Sir_016").ToString())     '
                .Sir_017 = NCnvN(dt.Rows(0)("Sir_017").ToString())     '
                .Sir_018 = NCnvZ(dt.Rows(0)("Sir_018").ToString())     '区分01 小数点区分(四捨五入等)
                .Sir_019 = NCnvZ(dt.Rows(0)("Sir_019").ToString())     '区分02 消費税区分(内税・外税等)
                .Sir_020 = NCnvZ(dt.Rows(0)("Sir_020").ToString())     '区分03 消費税計算区分(四捨五入等)
                .Sir_021 = NCnvZ(dt.Rows(0)("Sir_021").ToString())     '区分04 消費税計算単位区分(伝票単位・請求単位等)
                .Sir_022 = NCnvZ(dt.Rows(0)("Sir_022").ToString())     '区分05
                .Sir_023 = NCnvZ(dt.Rows(0)("Sir_023").ToString())     '区分06
                .Sir_024 = NCnvZ(dt.Rows(0)("Sir_024").ToString())     '区分07
                .Sir_025 = NCnvZ(dt.Rows(0)("Sir_025").ToString())     '区分08
                .Sir_026 = NCnvZ(dt.Rows(0)("Sir_026").ToString())     '区分09
                .Sir_027 = NCnvZ(dt.Rows(0)("Sir_027").ToString())     '区分10 締区分1(当月・翌月等)
                .Sir_028 = NCnvZ(dt.Rows(0)("Sir_028").ToString())     '区分11 締区分2(当月・翌月等)
                .Sir_029 = NCnvZ(dt.Rows(0)("Sir_029").ToString())     '区分12 締区分3(当月・翌月等)
                .Sir_030 = NCnvZ(dt.Rows(0)("Sir_030").ToString())     '区分13 支払区分1(振込・集金)
                .Sir_031 = NCnvZ(dt.Rows(0)("Sir_031").ToString())     '区分14 支払区分2(振込・集金)
                .Sir_032 = NCnvZ(dt.Rows(0)("Sir_032").ToString())     '区分15 支払区分3(振込・集金)
                .Sir_033 = NCnvZ(dt.Rows(0)("Sir_033").ToString())     '締日1
                .Sir_034 = NCnvZ(dt.Rows(0)("Sir_034").ToString())     '締日2
                .Sir_035 = NCnvZ(dt.Rows(0)("Sir_035").ToString())     '締日3
                .Sir_036 = NCnvZ(dt.Rows(0)("Sir_036").ToString())     '支払日1
                .Sir_037 = NCnvZ(dt.Rows(0)("Sir_037").ToString())     '支払日2
                .Sir_038 = NCnvZ(dt.Rows(0)("Sir_038").ToString())     '支払日3
                .Sir_039 = NCnvN(dt.Rows(0)("Sir_039").ToString())     '最終売上日
                .Sir_040 = NCnvN(dt.Rows(0)("Sir_040").ToString())     '最終請求書発行日
                .Sir_041 = NCnvN(dt.Rows(0)("Sir_041").ToString())     '
                .Sir_042 = NCnvZ(dt.Rows(0)("Sir_042").ToString())     '
                .Sir_043 = NCnvZ(dt.Rows(0)("Sir_043").ToString())     '
                .Sir_044 = NCnvZ(dt.Rows(0)("Sir_044").ToString())     '銀行コード
                .Sir_045 = NCnvZ(dt.Rows(0)("Sir_045").ToString())     '支店コード
                .Sir_046 = NCnvZ(dt.Rows(0)("Sir_046").ToString())     '口座種別
                .Sir_047 = NCnvN(dt.Rows(0)("Sir_047").ToString())     '口座番号
                .Sir_048 = NCnvN(dt.Rows(0)("Sir_048").ToString())     '振込人名称
                .Sir_049 = NCnvN(dt.Rows(0)("Sir_049").ToString())     '
                .Sir_050 = NCnvN(dt.Rows(0)("Sir_050").ToString())     '
            Else
                GoTo GetSirMstInfo_Exit
            End If
        End With

        GetSirMstInfo = True

GetSirMstInfo_Exit:

        Exit Function

    End Function

    '***************************************************************
    '**  名称    : Sub GetNouMstInfo()
    '**  機能    : 納品先マスタの読込み処理
    '**  戻り値  :
    '**  引数    : NouMst : 納品先マスタ情報
    '**          : viMode : 0 対象データ
    '**          :        : 1 次データ
    '**          :        : 2 前データ
    '**  備考    :
    '***************************************************************
    Public Function GetNouMstInfo(NouMst As NouMstInfo,
                                  viMode As Integer) As Boolean

        Dim SQLtxt As String


        GetNouMstInfo = False

        With NouMst
            '===納品先マスタ読込み用SQL文作成===================================
            SQLtxt = ""
            SQLtxt = SQLtxt & "Select * FROM Nou_Mst"
            Select Case viMode
                Case 0 '対象データ
                    SQLtxt = SQLtxt & " WHERE Nou_001 = " & .Nou_001
                Case 1 '次データ
                    SQLtxt = SQLtxt & " WHERE Nou_001 = "
                    SQLtxt = SQLtxt & " ( Select MIN(Nou_001) FROM Nou_Mst"
                    SQLtxt = SQLtxt & "    WHERE Nou_001 > " & .Nou_001 & ")"
                Case 2 '前データ
                    SQLtxt = SQLtxt & " WHERE Nou_001 = "
                    SQLtxt = SQLtxt & " ( Select MAX(Nou_001) FROM Nou_Mst"
                    SQLtxt = SQLtxt & "    WHERE Nou_001 < " & .Nou_001 & ")"
            End Select
            '===納品先マスタの読込み============================================
            Dim dt As DataTable

            Dim dbsvc As New clsDB.DBService()
            dt = dbsvc.GetDatafromDB(SQLtxt)

            If dt.Rows.Count() > 0 Then

                .Nou_001 = NCnvZ(dt.Rows(0)("Nou_001").ToString())     '納品先ｺｰﾄﾞ
                .Nou_002 = NCnvZ(dt.Rows(0)("Nou_002").ToString())     '営業所ｺｰﾄﾞ
                .Nou_003 = NCnvN(dt.Rows(0)("Nou_003").ToString())     '納品先名１（漢字）
                .Nou_004 = NCnvN(dt.Rows(0)("Nou_004").ToString())     '納品先名２（漢字）
                .Nou_005 = NCnvN(dt.Rows(0)("Nou_005").ToString())     '納品先名（略称）
                .Nou_006 = NCnvN(dt.Rows(0)("Nou_006").ToString())     '納品先名（カナ）
                .Nou_007 = NCnvN(dt.Rows(0)("Nou_007").ToString())     '郵便番号
                .Nou_008 = NCnvN(dt.Rows(0)("Nou_008").ToString())     '住所１（漢字）
                .Nou_009 = NCnvN(dt.Rows(0)("Nou_009").ToString())     '住所２（漢字）
                .Nou_010 = NCnvN(dt.Rows(0)("Nou_010").ToString())     '電話番号
                .Nou_011 = NCnvN(dt.Rows(0)("Nou_011").ToString())     'FAX番号
                .Nou_012 = NCnvN(dt.Rows(0)("Nou_012").ToString())     '担当者名１（漢字）
                .Nou_013 = NCnvN(dt.Rows(0)("Nou_013").ToString())     '担当者名２（漢字）
                .Nou_014 = NCnvN(dt.Rows(0)("Nou_014").ToString())     'ﾒｰﾙｱﾄﾞﾚｽ
                .Nou_015 = NCnvN(dt.Rows(0)("Nou_015").ToString())     '携帯番号
            Else
                GoTo GetNouMstInfo_Exit
            End If
        End With

        GetNouMstInfo = True

GetNouMstInfo_Exit:

        Exit Function

    End Function

    '***************************************************************
    '**  名称    : Sub GetSyoMstInfo()
    '**  機能    : 商品マスタの読込み処理
    '**  戻り値  :
    '**  引数    : SyoMst : 商品マスタ情報
    '**          : viMode : 0 対象データ
    '**          :        : 1 次データ
    '**          :        : 2 前データ
    '**  備考    :
    '***************************************************************
    Public Function GetSyoMstInfo(SyoMst As SyoMstInfo,
                                  viMode As Integer) As Boolean

        Dim SQLtxt As String


        GetSyoMstInfo = False

        With SyoMst
            '===商品マスタ読込み用SQL文作成===================================
            SQLtxt = ""
            SQLtxt = SQLtxt & "Select * FROM Syo_Mst"
            Select Case viMode
                Case 0 '対象データ
                    SQLtxt = SQLtxt & " WHERE Syo_001 = " & .Syo_001
                Case 1 '次データ
                    SQLtxt = SQLtxt & " WHERE Syo_001 = "
                    SQLtxt = SQLtxt & " ( Select MIN(Syo_001) FROM Syo_Mst"
                    SQLtxt = SQLtxt & "    WHERE Syo_001 > " & .Syo_001 & ")"
                Case 2 '前データ
                    SQLtxt = SQLtxt & " WHERE Syo_001 = "
                    SQLtxt = SQLtxt & " ( Select MAX(Syo_001) FROM Syo_Mst"
                    SQLtxt = SQLtxt & "    WHERE Syo_001 < " & .Syo_001 & ")"
            End Select
            '===商品マスタの読込み============================================
            Dim dt As DataTable

            Dim dbsvc As New clsDB.DBService()
            dt = dbsvc.GetDatafromDB(SQLtxt)

            If dt.Rows.Count() > 0 Then

                .Syo_001 = NCnvZ(dt.Rows(0)("Syo_001").ToString())     '商品ｺｰﾄﾞ
                .Syo_002 = NCnvZ(dt.Rows(0)("Syo_002").ToString())     'ｻﾌﾞｺｰﾄﾞ
                .Syo_003 = NCnvN(dt.Rows(0)("Syo_003").ToString())     '商品名称１（漢字）
                .Syo_004 = NCnvN(dt.Rows(0)("Syo_004").ToString())     '商品名称２（漢字）
                .Syo_005 = NCnvN(dt.Rows(0)("Syo_005").ToString())     '商品名称（カナ）
                .Syo_006 = NCnvN(dt.Rows(0)("Syo_006").ToString())     '記号
                .Syo_007 = NCnvN(dt.Rows(0)("Syo_007").ToString())     '分類
                .Syo_008 = NCnvN(dt.Rows(0)("Syo_008").ToString())     '規格
                .Syo_009 = NCnvN(dt.Rows(0)("Syo_009").ToString())     '
                .Syo_010 = NCnvZ(dt.Rows(0)("Syo_010").ToString())     '入数
                .Syo_011 = NCnvZ(dt.Rows(0)("Syo_011").ToString())     '
                .Syo_012 = NCnvN(dt.Rows(0)("Syo_012").ToString())     'JANコード
                .Syo_013 = NCnvN(dt.Rows(0)("Syo_013").ToString())     '
                .Syo_014 = NCnvN(dt.Rows(0)("Syo_014").ToString())     '
                .Syo_015 = NCnvN(dt.Rows(0)("Syo_015").ToString())     '単位名称１
                .Syo_016 = NCnvN(dt.Rows(0)("Syo_016").ToString())     '単位名称２
                .Syo_017 = NCnvN(dt.Rows(0)("Syo_017").ToString())     '
                .Syo_018 = NCnvZ(dt.Rows(0)("Syo_018").ToString())     '上代単価    (税抜)
                .Syo_019 = NCnvZ(dt.Rows(0)("Syo_019").ToString())     '上代単価    (税抜)
                .Syo_020 = NCnvZ(dt.Rows(0)("Syo_020").ToString())     '最終仕入単価(税抜)
                .Syo_021 = NCnvZ(dt.Rows(0)("Syo_021").ToString())     '最終仕入単価(税込)
                .Syo_022 = NCnvZ(dt.Rows(0)("Syo_022").ToString())     '最終売上単価(税抜)
                .Syo_023 = NCnvZ(dt.Rows(0)("Syo_023").ToString())     '最終売上単価(税込)
                .Syo_024 = NCnvZ(dt.Rows(0)("Syo_024").ToString())     '等)
                .Syo_025 = NCnvZ(dt.Rows(0)("Syo_025").ToString())     '
                .Syo_026 = NCnvZ(dt.Rows(0)("Syo_026").ToString())     '在庫残数量(単位１)
                .Syo_027 = NCnvZ(dt.Rows(0)("Syo_027").ToString())     '入庫累計数(単位１)
                .Syo_028 = NCnvZ(dt.Rows(0)("Syo_028").ToString())     '出庫累計数(単位１)
                .Syo_029 = NCnvZ(dt.Rows(0)("Syo_029").ToString())     '在庫調整数(単位１)
                .Syo_030 = NCnvZ(dt.Rows(0)("Syo_030").ToString())     '実在庫数量(単位１)
                .Syo_031 = NCnvZ(dt.Rows(0)("Syo_031").ToString())     '
                .Syo_032 = NCnvZ(dt.Rows(0)("Syo_032").ToString())     '在庫残数量(単位２)
                .Syo_033 = NCnvZ(dt.Rows(0)("Syo_033").ToString())     '入庫累計数(単位２)
                .Syo_034 = NCnvZ(dt.Rows(0)("Syo_034").ToString())     '出庫累計数(単位２)
                .Syo_035 = NCnvZ(dt.Rows(0)("Syo_035").ToString())     '在庫調整数(単位２)
                .Syo_036 = NCnvZ(dt.Rows(0)("Syo_036").ToString())     '実在庫数量(単位２)
                .Syo_037 = NCnvZ(dt.Rows(0)("Syo_037").ToString())     '
                .Syo_038 = NCnvZ(dt.Rows(0)("Syo_038").ToString())     '
                .Syo_039 = NCnvN(dt.Rows(0)("Syo_039").ToString())     '最終仕入日
                .Syo_040 = NCnvN(dt.Rows(0)("Syo_040").ToString())     '最終売上日
                .Syo_041 = NCnvN(dt.Rows(0)("Syo_041").ToString())     '
            Else
                GoTo GetSyoMstInfo_Exit
            End If
        End With

        GetSyoMstInfo = True

GetSyoMstInfo_Exit:

        Exit Function

    End Function

    '***************************************************************
    '**  名称    : Sub GetGinMstInfo()
    '**  機能    : 銀行マスタの読込み処理
    '**  戻り値  :
    '**  引数    : GinMst : 銀行マスタ情報
    '**          : viMode : 0 対象データ
    '**          :        : 1 次データ
    '**          :        : 2 前データ
    '**  備考    :
    '***************************************************************
    Public Function GetGinMstInfo(GinMst As GinMstInfo,
                                  viMode As Integer) As Boolean

        Dim SQLtxt As String


        GetGinMstInfo = False

        With GinMst
            '===銀行マスタ読込み用SQL文作成===================================
            SQLtxt = ""
            SQLtxt = SQLtxt & "Select * FROM Gin_Mst"
            Select Case viMode
                Case 0 '対象データ
                    SQLtxt = SQLtxt & " WHERE Gin_001 = " & .Gin_001
                    SQLtxt = SQLtxt & "   And Gin_002 = " & .Gin_002
                    '''            Case 1 '次データ(銀行、支店)
                    '''                SQLtxt = SQLtxt & " WHERE  RIGHT('0000'+ CONVERT(VARCHAR,Gin_001),4) + RIGHT('0000'+ CONVERT(VARCHAR,Gin_002),4)"
                    '''                SQLtxt = SQLtxt & "     > " & Format(CStr(.Gin_001), "0000") & Format(CStr(.Gin_002), "0000")
                    '''                SQLtxt = SQLtxt & " ORDER BY Gin_001 ASC,Gin_002 ASC"
                    '''            Case 2 '前データ(銀行、支店)
                    '''                SQLtxt = SQLtxt & " WHERE  RIGHT('0000'+ CONVERT(VARCHAR,Gin_001),4) + RIGHT('0000'+ CONVERT(VARCHAR,Gin_002),4)"
                    '''                SQLtxt = SQLtxt & "     < " & Format(CStr(.Gin_001), "0000") & Format(CStr(.Gin_002), "0000")
                    '''                SQLtxt = SQLtxt & " ORDER BY Gin_001 DESC,Gin_002 DESC"
                Case 1 '次データ(銀行)
                    SQLtxt = SQLtxt & " WHERE  Gin_001 > " & .Gin_001
                    SQLtxt = SQLtxt & " ORDER BY Gin_001 ASC"
                Case 2 '前データ(銀行)
                    SQLtxt = SQLtxt & " WHERE  Gin_001 < " & .Gin_001
                    SQLtxt = SQLtxt & " ORDER BY Gin_001 DESC"
                Case 3 '次データ(支店)
                    SQLtxt = SQLtxt & " WHERE  Gin_001 = " & .Gin_001
                    SQLtxt = SQLtxt & "   AND  Gin_002 > " & .Gin_002
                    SQLtxt = SQLtxt & " ORDER BY Gin_002 ASC"
                Case 4 '前データ(支店)
                    SQLtxt = SQLtxt & " WHERE  Gin_001 = " & .Gin_001
                    SQLtxt = SQLtxt & "   AND  Gin_002 < " & .Gin_002
                    SQLtxt = SQLtxt & " ORDER BY Gin_002 DESC"
            End Select
            '===銀行マスタの読込み============================================
            Dim dt As DataTable

            Dim dbsvc As New clsDB.DBService()
            dt = dbsvc.GetDatafromDB(SQLtxt)

            If dt.Rows.Count() > 0 Then

                .Gin_001 = NCnvZ(dt.Rows(0)("Gin_001").ToString())   '銀行ｺｰﾄﾞ
                .Gin_002 = NCnvZ(dt.Rows(0)("Gin_002").ToString())   '支店ｺｰﾄﾞ
                .Gin_003 = NCnvN(dt.Rows(0)("Gin_003").ToString())   '銀行名（漢字）
                .Gin_004 = NCnvN(dt.Rows(0)("Gin_004").ToString())   '支店名（漢字）
                .Gin_005 = NCnvN(dt.Rows(0)("Gin_005").ToString())   '銀行名（ｶﾅ）
                .Gin_006 = NCnvN(dt.Rows(0)("Gin_006").ToString())   '支店名（ｶﾅ）
            Else
                GoTo GetGinMstInfo_Exit
            End If
        End With

        GetGinMstInfo = True

GetGinMstInfo_Exit:

        Exit Function

    End Function

    '***************************************************************
    '**  名称    : Sub GetKbnMstInfo()
    '**  機能    : 区分名称マスタの読込み処理
    '**  戻り値  :
    '**  引数    : KbnMst : 区分名称マスタ情報
    '**          : viMode : 0 分類
    '**          :        : 1 分類、区分名
    '**          :        : 2 分類、区分名、枝番
    '**  備考    :
    '***************************************************************
    Public Function GetKbnMstInfo(KbnMst As KbnMstInfo,
                                  viMode As Integer) As Boolean

        Dim SQLtxt As String


        GetKbnMstInfo = False

        With KbnMst
            '===区分名称マスタ読込み用SQL文作成===================================
            SQLtxt = ""
            SQLtxt = SQLtxt & "SELECT * FROM Kbn_Mst"
            Select Case viMode
                Case 0 '分類
                    SQLtxt = SQLtxt & " WHERE Kbn_001 = " & .Kbn_001
                    SQLtxt = SQLtxt & " ORDER BY Kbn_001,Kbn_002,Kbn_003 "
                Case 1 '分類、区分名
                    SQLtxt = SQLtxt & " WHERE Kbn_001 = " & .Kbn_001
                    SQLtxt = SQLtxt & "   AND Kbn_002 ='" & .Kbn_002 & "'"
                    SQLtxt = SQLtxt & " ORDER BY Kbn_001,Kbn_002,Kbn_003 "
                Case 2 '分類、区分名、枝番
                    SQLtxt = SQLtxt & " WHERE Kbn_001 = " & .Kbn_001
                    SQLtxt = SQLtxt & "   AND Kbn_002 ='" & .Kbn_002 & "'"
                    SQLtxt = SQLtxt & "   AND Kbn_003 = " & .Kbn_003
                    SQLtxt = SQLtxt & " ORDER BY Kbn_001,Kbn_002,Kbn_003 "
            End Select
            '===区分名称マスタの読込み============================================
            Dim dt As DataTable

            Dim dbsvc As New clsDB.DBService()
            dt = dbsvc.GetDatafromDB(SQLtxt)

            If dt.Rows.Count() > 0 Then

                .Kbn_001 = NCnvZ(dt.Rows(0)("Kbn_001").ToString())     '分類ｺｰﾄﾞ
                .Kbn_002 = NCnvN(dt.Rows(0)("Kbn_002").ToString())     '区分名
                .Kbn_003 = NCnvZ(dt.Rows(0)("Kbn_003").ToString())     '枝番
                .Kbn_004 = NCnvN(dt.Rows(0)("Kbn_004").ToString())     '区分名称（画面用）
                .Kbn_005 = NCnvN(dt.Rows(0)("Kbn_005").ToString())     '区分名称（印刷用）
                .Kbn_006 = NCnvN(dt.Rows(0)("Kbn_006").ToString())     '予備
                .Kbn_007 = NCnvN(dt.Rows(0)("Kbn_007").ToString())     '予備
            Else
                GoTo GetKbnMstInfo_Exit
            End If
        End With

        GetKbnMstInfo = True

GetKbnMstInfo_Exit:

        Exit Function

    End Function

    '--- INSERT 2013/09/06 AOKI START --------------------------------------------------------------------------------
    '***************************************************************
    '**  名称    : Sub GetKbnMstInfo2()
    '**  機能    : 区分名称マスタの読込み処理
    '**  戻り値  :
    '**  引数    : KbnMst : 区分名称マスタ情報
    '**          : viMode : 0 分類
    '**          :        : 1 分類、区分名
    '**          :        : 2 分類、区分名、枝番
    '**  備考    :
    '***************************************************************
    Public Function GetKbnMstInfo2(ByRef KbnMst As KbnMstInfo) As Boolean

        Dim SQLtxt As String

        GetKbnMstInfo2 = False

        With KbnMst
            '===区分名称マスタ読込み用SQL文作成===================================
            SQLtxt = ""
            SQLtxt = SQLtxt & " SELECT * FROM Kbn_Mst "
            SQLtxt = SQLtxt & " WHERE 1 = 1 "

            '分類
            If .Kbn_001 > -1 Then
                SQLtxt = SQLtxt & " And Kbn_001 = " & .Kbn_001
            End If

            '区分名
            If .Kbn_002 <> "" Then
                SQLtxt = SQLtxt & " And Kbn_002 ='" & .Kbn_002 & "'"
            End If

            '枝番
            If .Kbn_003 > -1 Then
                SQLtxt = SQLtxt & " AND Kbn_003 = " & .Kbn_003
            End If

            '区分名称（画面用）
            If .Kbn_004 <> "" Then
                SQLtxt = SQLtxt & " AND Kbn_004 ='" & .Kbn_004 & "'"
            End If

            '区分名称（印刷用）
            If .Kbn_005 <> "" Then
                SQLtxt = SQLtxt & " AND Kbn_005 ='" & .Kbn_005 & "'"
            End If

            SQLtxt = SQLtxt & " ORDER BY Kbn_001,Kbn_002,Kbn_003 "

            '===区分名称マスタの読込み============================================
            Dim dt As DataTable

            Dim dbsvc As New clsDB.DBService()
            dt = dbsvc.GetDatafromDB(SQLtxt)

            If dt.Rows.Count() > 0 Then

                .Kbn_001 = NCnvZ(dt.Rows(0)("Kbn_001").ToString()) '分類ｺｰﾄﾞ
                .Kbn_002 = NCnvN(dt.Rows(0)("Kbn_002").ToString()) '区分名
                .Kbn_003 = NCnvZ(dt.Rows(0)("Kbn_003").ToString()) '枝番
                .Kbn_004 = NCnvN(dt.Rows(0)("Kbn_004").ToString()) '区分名称（画面用）
                .Kbn_005 = NCnvN(dt.Rows(0)("Kbn_005").ToString()) '区分名称（印刷用）
                .Kbn_006 = NCnvN(dt.Rows(0)("Kbn_006").ToString()) '予備
                .Kbn_007 = NCnvN(dt.Rows(0)("Kbn_007").ToString()) '予備
            Else
                GoTo GetKbnMstInfo2_Exit
            End If
        End With

        GetKbnMstInfo2 = True

GetKbnMstInfo2_Exit:


    End Function
    '--- INSERT 2013/09/06 AOKI E N D --------------------------------------------------------------------------------

    '***************************************************************
    '**  名称    : Function GetNewDenNo() As Decimal
    '**  機能    : 新規の伝票番号を取得する
    '**  戻り値  : 取得した伝票番号
    '**  引数    : vlMode   0:売上管理番号
    '**          :          1:入金管理番号
    '**          :          2:仕入管理番号
    '**          :          3:支払管理番号
    '**          :          4:請求書管理番号
    '**          :          5:売掛管理番号
    '**          :          6:買掛管理番号
    '**          :          7:予備管理番号1
    '**          :          8:予備管理番号2
    '**          :          9:予備管理番号3
    '**  備考    :
    '***************************************************************
    Public Function GetNewDenNo(viMode As Integer) As Decimal

        Dim loConMst As ConMstInfo     'コントロールマスタ情報
        Dim lcWork As Decimal

        Call GetConMstInfo(loConMst)     'コントロールマスタ読込み処理

        Select Case viMode
            Case 0  '売上管理番号
                lcWork = loConMst.Con_023 + 1
            Case 1  '入金管理番号
                lcWork = loConMst.Con_024 + 1
            Case 2  '仕入管理番号
                lcWork = loConMst.Con_025 + 1
            Case 3  '支払管理番号
                lcWork = loConMst.Con_026 + 1
            Case 4  '請求管理番号
                lcWork = loConMst.Con_027 + 1
            Case 5  '売掛管理番号
                lcWork = loConMst.Con_028 + 1
            Case 6  '買掛管理番号
                lcWork = loConMst.Con_029 + 1
            Case 7  '予備管理番号1
                lcWork = loConMst.Con_030 + 1
            Case 8  '予備管理番号2
                lcWork = loConMst.Con_031 + 1
            Case 9  '予備管理番号3
                lcWork = loConMst.Con_032 + 1
        End Select

        GetNewDenNo = lcWork

    End Function

    '***************************************************************
    '**  名称    : Function UpdateDenNo() As Boolean
    '**  機能    : コントロールマスタの伝票番号を+1する
    '**  戻り値  : True : 正常   False : エラー
    '**  引数    : vcDenNo  更新する伝票番号
    '**  引数    : vlMode   0:売上管理番号
    '**          :          1:入金管理番号
    '**          :          2:仕入管理番号
    '**          :          3:支払管理番号
    '**          :          4:請求書管理番号
    '**          :          5:売掛管理番号
    '**          :          6:買掛管理番号
    '**          :          7:予備管理番号1
    '**          :          8:予備管理番号2
    '**          :          9:予備管理番号3
    '**  備考    :
    '***************************************************************
    Public Function UpdateDenNo(vcDenNo As Decimal, viMode As Integer) As Boolean

        Dim strSQL As String         'SQL文作成用
        Dim strMsg As String         'エラーメッセージ作成用
        Dim lngErr As Long           'エラー番号

        UpdateDenNo = False

        strSQL = ""
        Select Case viMode
            Case 0  '売上管理番号
                strSQL = " UPDATE Con_Mst"
                strSQL = strSQL & "   Set Con_023  = " & vcDenNo
                strSQL = strSQL & "     , Con_UPDATE ='" & Now & "'"
                strSQL = strSQL & "     , Con_WSNO   ='FMV001'"
                strSQL = strSQL & " WHERE Con_001    = " & 1
            Case 1  '入金管理番号
                strSQL = " UPDATE Con_Mst"
                strSQL = strSQL & "   SET Con_024  = " & vcDenNo
                strSQL = strSQL & "     , Con_UPDATE ='" & Now & "'"
                strSQL = strSQL & "     , Con_WSNO   ='FMV001'"
                strSQL = strSQL & " WHERE Con_001    = " & 1
            Case 2  '仕入管理番号
                strSQL = " UPDATE Con_Mst"
                strSQL = strSQL & "   SET Con_025  = " & vcDenNo
                strSQL = strSQL & "     , Con_UPDATE ='" & Now & "'"
                strSQL = strSQL & "     , Con_WSNO   ='FMV001'"
                strSQL = strSQL & " WHERE Con_001    = " & 1
            Case 3  '支払管理番号
                strSQL = " UPDATE Con_Mst"
                strSQL = strSQL & "   SET Con_026  = " & vcDenNo
                strSQL = strSQL & "     , Con_UPDATE ='" & Now & "'"
                strSQL = strSQL & "     , Con_WSNO   ='FMV001'"
                strSQL = strSQL & " WHERE Con_001    = " & 1
            Case 4  '請求書管理番号
                strSQL = " UPDATE Con_Mst"
                strSQL = strSQL & "   SET Con_027  = " & vcDenNo
                strSQL = strSQL & "     , Con_UPDATE ='" & Now & "'"
                strSQL = strSQL & "     , Con_WSNO   ='FMV001'"
                strSQL = strSQL & " WHERE Con_001    = " & 1
            Case 5  '売掛管理番号
                strSQL = " UPDATE Con_Mst"
                strSQL = strSQL & "   SET Con_028  = " & vcDenNo
                strSQL = strSQL & "     , Con_UPDATE ='" & Now & "'"
                strSQL = strSQL & "     , Con_WSNO   ='FMV001'"
                strSQL = strSQL & " WHERE Con_001    = " & 1
            Case 6  '買掛管理番号
                strSQL = " UPDATE Con_Mst"
                strSQL = strSQL & "   SET Con_029  = " & vcDenNo
                strSQL = strSQL & "     , Con_UPDATE ='" & Now & "'"
                strSQL = strSQL & "     , Con_WSNO   ='FMV001'"
                strSQL = strSQL & " WHERE Con_001    = " & 1
            Case 7  '予備管理番号1
                strSQL = " UPDATE Con_Mst"
                strSQL = strSQL & "   SET Con_030  = " & vcDenNo
                strSQL = strSQL & "     , Con_UPDATE ='" & Now & "'"
                strSQL = strSQL & "     , Con_WSNO   ='FMV001'"
                strSQL = strSQL & " WHERE Con_001    = " & 1
            Case 8  '予備管理番号2
                strSQL = " UPDATE Con_Mst"
                strSQL = strSQL & "   SET Con_031  = " & vcDenNo
                strSQL = strSQL & "     , Con_UPDATE ='" & Now & "'"
                strSQL = strSQL & "     , Con_WSNO   ='FMV001'"
                strSQL = strSQL & " WHERE Con_001    = " & 1
            Case 9  '予備管理番号3
                strSQL = " UPDATE Con_Mst"
                strSQL = strSQL & "   SET Con_032  = " & vcDenNo
                strSQL = strSQL & "     , Con_UPDATE ='" & Now & "'"
                strSQL = strSQL & "     , Con_WSNO   =" & StaticWinApi.Wsnumber
                strSQL = strSQL & " WHERE Con_001    = " & 1
        End Select

        'セッション開始

        'SQL文実行


        Dim dbsvc As New clsDB.DBService()
        dbsvc.BeginTrans()

        If (dbsvc.ExecuteSql(strSQL, strMsg)) Then
            GoTo Error_UpdateDenNo
        End If

        dbsvc.CommitTrans()

        'コミット

        UpdateDenNo = True

        Exit Function

Error_UpdateDenNo:
        '処理を戻す（ロールバック）
        dbsvc.RollbackTran()

        'エラーメッセージ表示
        Call ksExpMsgBox("伝票番号の更新に失敗しました。", "E")

    End Function

    '***************************************************************
    '**  名称    : Function stDateCtrlSet() As Boolean
    '**  機能    : 日付コントロールを設定する。
    '**  戻り値  : True;正常終了 , False;エラー
    '**  引数    : voCtrl   : 日付コントロール
    '**            viSWKbn  : 0:和暦 1:西暦
    '**            viYMDKbn : Y:年 YM:年月 YMD:年月日
    '**  備考    :
    '***************************************************************
    Public Function stDateCtrlSet(voCtrl As Control,
                                  viSWKbn As Integer,
                                  viYMDKbn As String) As Boolean

        Select Case viSWKbn

            Case 0   '和暦

                Select Case viYMDKbn
                    Case "Y"   '年
                        voCtrl.Text = Format(voCtrl, "gggee年")

                    Case "YM"  '年月
                        voCtrl.Text = Format(voCtrl, "gggee年mm月")

                    Case "YMD" '年月日
                        voCtrl.Text = Format(voCtrl, "gggee年mm月dd日")
                End Select

            Case 1   '西暦

                Select Case viYMDKbn
                    Case "Y"   '年
                        voCtrl.Text = Format(voCtrl, "yyyy年")

                    Case "YM"  '年月
                        voCtrl.Text = Format(voCtrl, "yyyy年mm月")

                    Case "YMD" '年月日
                        voCtrl.Text = Format(voCtrl, "yyyy年mm月dd日")

                End Select

        End Select


        stDateCtrlSet = True

    End Function

    '***************************************************************
    '**  名称    : Function stDateCheck() As integer
    '**  機能    : 日付のチェックを行う。
    '**  戻り値  : エラーならば""を返す
    '**  引数    : vsDate ; 日付を表す文字列
    '**  備考    :
    '***************************************************************
    Public Function stDateCheck(vsDate As String) As String

        stDateCheck = vsDate

        If IsDate(vsDate) = False Then
            stDateCheck = ""
        End If

    End Function

    '***************************************************************
    '**  名称    : Function stDateCheck2() As integer
    '**  機能    : 日付のチェックを行う。
    '**  戻り値  : 1900/01/01ならば""を返す
    '**  引数    : vsDate ; 日付を表す文字列
    '**  備考    :
    '***************************************************************
    Public Function stDateCheck2(vsDate As String) As String

        stDateCheck2 = vsDate

        If IsDate(vsDate) = True And vsDate = "1900/01/01" Then
            stDateCheck2 = ""
        End If

    End Function
End Module
