Imports System.Drawing
Imports System.Windows.Forms

Public Module modSac_Com

    'マスタで使用する戻り値----------------------
    Public RetCode As Object              'コード
    Public RetCode2 As Object              'コード         'INSERT 2014/04/22 AOKI
    Public RetName1 As String               '名称
    Public RetName2 As String               '文字2
    Public RetName3 As String               '文字3
    Public RetName4 As String               '
    Public RetName5 As String               '
    Public RetName6 As String               '造船所         'INSERT 2013/05/16 AOKI
    Public RetName7 As String               '船番           'INSERT 2013/05/16 AOKI
    Public RetName8 As String               '当社担当者     'INSERT 2014/02/05 AOKI
    Public RetCurr1 As Decimal            '数値1
    Public RetCurr2 As Decimal            '数値2
    Public RetCurr3 As Decimal            '
    Public RetCurr4 As Decimal            '
    Public RetKubun As Integer              '区分
    Public RetTel As String               'Tel
    Public RetBiko As String               '備考
    Public RetMode As Byte                 '処理ﾓｰﾄﾞｾｯﾄ(実行=0)
    Public SETMODE As Byte                 '処理ﾓｰﾄﾞｾｯﾄ(例：見積=0　受注=1)
    '----------
    Public SetKey1                    '
    Public SetKey2                    '
    Public SetKey3                    '

    'マスタで使用する引数　----------------------



    '画面編集モード関連
    Public Const stIntADD As Integer = 0          '追加モード
    Public Const stIntDEL As Integer = 1          '削除モード
    Public Const stIntMOD As Integer = 2          '訂正モード
    Public Const stIntDSP As Integer = 3          '表示モード
    Public Const stIntAMD As Integer = 4          '追加・訂正モード

    'UPDATE 2013/07/11 alpha char AOKI START ---------------------------------------------------------------------
    'Public Const stStrADDNM         As String = "追加"
    'Public Const stStrDELNM         As String = "削除"
    'Public Const stStrMODNM         As String = "訂正"
    'Public Const stStrDSPNM         As String = "表示"
    'Public Const stStrAMDNM         As String = "追加・訂正"
    Public Const stStrADDNM As String = "ADD."
    Public Const stStrDELNM As String = "DELETE"
    Public Const stStrMODNM As String = "REVISE"
    Public Const stStrDSPNM As String = "DISPLAY"
    Public Const stStrAMDNM As String = "ADD.・REVISE"
    'UPDATE 2013/07/11 alpha char AOKI E N D ---------------------------------------------------------------------

    Public Const stStrADDCLR As Long = &HFFFF00
    Public Const stStrDELCLR As Long = &HFF&
    Public Const stStrMODCLR As Long = &HFF00&
    Public Const stStrDSPCLR As Long = &HFFFFC0
    Public Const stStrAMDCLR As Long = &HFF80FF
    'ファンクションキー列挙定数
    'Public Enum enmFKEY
    '    F_F1 = 1            'F1キー
    '    F_F2 = 2            'F2キー
    '    F_F3 = 3            'F3キー
    '    F_F4 = 4            'F4キー
    '    F_F5 = 5            'F5キー
    '    F_F6 = 6            'F6キー
    '    F_F7 = 7            'F7キー
    '    F_F8 = 8            'F8キー
    '    F_F9 = 9            'F9キー
    '    F_F10 = 10          'F10キー
    '    F_F11 = 11          'F11キー
    '    F_F12 = 12          'F12キー
    'End Enum

    '***************************************************************
    '**  名称    : Function ksExecuteSQL() As Boolean
    '**  機能    : ＳＱＬ文を実行し、結果のデータセットを返す。
    '**  戻り値  : True;正常終了 , False;エラー
    '**  引数    : vsSqlText   ; 実行するSQL文字列
    '**            vlErrcode   ; エラー時のエラーコード
    '**            vsErrmsg    ; エラー時のエラーメッセージ
    '**  備考    :
    '***************************************************************

    '***************************************************************
    '**  名称    : Function ksExpMsgBox() As Integer
    '**  機能    : 拡張用メッセージボックス。通常のメッセージ表示用。
    '**  戻り値  : -1       ; 異常
    '**            vbYes    ; 「はい」ボタンが押された
    '**            vbNo     ; 「いいえ」ボタンが押された
    '**            vbCancel ; 「ｷｬﾝｾﾙ」ボタンが押された
    '**  引数    : vsMsg  ; 表示メッセージ
    '**            vsCode ; メッセージボックススタイルコード
    '**  備考    :
    '***************************************************************
    Public Function stComboDispDataKomoku(voCBctl As ComboBox, vsKomoku As String) As Boolean

        Dim liIdx As Long
        Dim lsWork As String

        With voCBctl
            If .Items.Count > 0 Then
                For liIdx = 0 To .Items.Count - 1
                    If .Items(liIdx) <> "" Then
                        lsWork = Right(.Items(liIdx), Len(.Items(liIdx)) - InStr(1, .Items(liIdx), ":"))
                        If Trim$(lsWork) = Trim$(vsKomoku) Then
                            .SelectedIndex = liIdx
                            stComboDispDataKomoku = True
                            Exit Function
                        End If
                    End If
                Next liIdx

                .SelectedIndex = -1                 'INSERT 2013/02/03 AOKI

            End If
        End With

        stComboDispDataKomoku = False

    End Function




    Public Function ksExpMsgBox(vsMsg As String, vsCode As String) As Integer

        Dim Title As String
        Dim Style As Integer

        On Error GoTo ksExpMsgBox_Err

        'メッセージボックスのスタイル設定
        Select Case vsCode
            Case "E"
                Style = vbOKOnly + vbExclamation + vbDefaultButton1
                Title = "エラー"
            Case "Q"
                Style = vbYesNo + vbQuestion + vbDefaultButton1
                Title = "確認"
            Case "I"
                Style = vbOKOnly + vbInformation + vbDefaultButton1
                Title = "案内"
            Case "W"
                ''            Style = vbYesNoCancel + vbQuestion + vbDefaultButton1
                ''            Title = "警告"
                Style = vbOKOnly + vbExclamation + vbDefaultButton1
                Title = "警告"
            Case Else
                GoTo ksExpMsgBox_Err
        End Select

        'メッセージボックスの表示
        ksExpMsgBox = MsgBox(vsMsg, Style, Title)

        Exit Function

ksExpMsgBox_Err:
        ksExpMsgBox = -1

    End Function

    '***************************************************************
    '**  名称    : Function gksGetNowDate() As String
    '**  機能    : データベース共通情報用日付を設定する。
    '**  戻り値  : True;正常終了 , False;エラー
    '**  引数    :
    '**  備考    :
    '***************************************************************
    Public Function gksGetNowDate() As String

        gksGetNowDate = Format$(Now, "YYYY年MM月DD日")

    End Function




    '***************************************************************
    '**  名称    : Sub stSetActiveControl()
    '**  機能    : アクティブなコントロールのフォアカラーを変更する。
    '**  戻り値  :
    '**  引数    : voControl ; 対象のコントロール
    '              vbStatus  ; ステータス True  = フォーカスイン時
    '                                     False = フォーカスアウト時
    '**  備考    :
    '***************************************************************
    Public Sub stSetActiveControl(voControl As Control, vbStatus As Boolean)

        Select Case vbStatus
            Case True
                voControl.ForeColor = Color.FromArgb(&HFF0000)

            Case False
                voControl.ForeColor = Color.FromArgb(&H80000012)

        End Select

    End Sub

    '***************************************************************
    '**  名称    : Sub stSetActiveControl()
    '**  機能    : アクティブなコントロールのバックカラーを変更する。
    '**  戻り値  :
    '**  引数    : voControl ; 対象のコントロール
    '              vbStatus  ; ステータス True  = フォーカスイン時
    '                                     False = フォーカスアウト時
    '**  備考    :
    '***************************************************************
    Public Sub stSetActiveControl_C(voControl As Control, vbStatus As Boolean)

        Select Case vbStatus
            Case True
                voControl.BackColor = Color.FromArgb(&HFF&)

            Case False
                voControl.BackColor = Color.FromArgb(&H80000012)

        End Select

    End Sub

    '***************************************************************
    '**  名称    : Sub stSetActiveControl()
    '**  機能    : アクティブなコントロールのバックカラーを変更する。
    '**  戻り値  :
    '**  引数    : voControl ; 対象のコントロール
    '              vbStatus  ; ステータス True  = フォーカスイン時
    '                                     False = フォーカスアウト時
    '**  備考    :
    '***************************************************************
    Public Sub stSetActiveControlB(voControl As Control, vbStatus As Boolean)

        Select Case vbStatus
            Case True
                voControl.BackColor = Color.FromArgb(&HFFFF80)

            Case False
                voControl.BackColor = Color.FromArgb(&HFFFFFF)

        End Select

    End Sub

    Public Function stComboGetKomoku(selectedValue As String) As String
        Return Right(selectedValue, Len(selectedValue) - InStr(1, selectedValue, ":"))
    End Function

    '***************************************************************
    '**  名称    :  Sub stKeyInNext()
    '**  機能    ： 入力されたキーをチェックし動作設定する。
    '**  戻り値  ：
    '**  引数    ： KeyCode ; 入力キーコード
    '**  備考    ：
    '***************************************************************


    '***************************************************************
    '**  名称    :  Function stCreateFileCol() As Boolean
    '**  機能    ： 指定されたファイル名からファイルコレクションを作成する。
    '**  戻り値  ： True;正常終了 , False;エラー
    '**  引数    ： vsFname ; ファイル名
    '**             voCol   ; 作成コレクション
    '**  備考    ：
    '***************************************************************
    Public Function stCreateFileCol(vsFName As String, ByRef voCol As Collection) As Boolean

        Dim loObjFs As Object       'ファイルシステムオブジェクト
        Dim loObjTs As Object       'テキストストリームオブジェクト
        Dim lsWorks As String

        stCreateFileCol = False

        On Error GoTo stCreateFileCol_Err

        'コレクション作成
        voCol = New Collection

        'FileSystemObjectの生成
        loObjFs = CreateObject("Scripting.FileSystemObject")
        'オープン
        loObjTs = loObjFs.OpenTextFile(vsFName, 1)

        '各行読込み
        Do Until loObjTs.AtEndOfStream
            lsWorks = loObjTs.ReadLine  '１行読込み
            Call voCol.Add(lsWorks)     'コレクションに追加
        Loop

        'クローズ
        Call loObjTs.Close

        stCreateFileCol = True

stCreateFileCol_Err:
        loObjFs = Nothing
        loObjTs = Nothing

    End Function

    '***************************************************************
    '**  名称    :  Function stCreateColFile() As Boolean
    '**  機能    ： 指定されたファイルコレクションからファイル名を作成する。
    '**  戻り値  ： True;正常終了 , False;エラー
    '**  引数    ： vsFname ; ファイル名
    '**             voCol   ; 作成コレクション
    '**  備考    ：
    '***************************************************************
    Public Function stCreateColFile(vsFName As String, ByRef voCol As Collection) As Boolean

        '        Dim loObjFs As Object       'ファイルシステムオブジェクト
        '        Dim loObjTs As Object       'テキストストリームオブジェクト
        '        Dim lvData As Object


        '        stCreateColFile = False

        '        On Local Error GoTo stCreateColFile_Err

        '    'コレクション作成
        '    Set voCol = New Collection

        '    'FileSystemObjectの生成
        '    Set loObjFs = CreateObject("Scripting.FileSystemObject")
        '    'オープン
        '    Set loObjTs = loObjFs.OpenTextFile(vsFName, 1)

        '    '各行読込み
        '    For Each lvData In voCol
        '            Call loObjTs.Add(lvData)     'ファイルに出力
        '        Next lvData

        '        'クローズ
        '        Call loObjTs.Close

        '        stCreateColFile = True

        'stCreateColFile_Err:
        '    Set loObjFs = Nothing
        '    Set loObjTs = Nothing

    End Function

    '***************************************************************
    '**  名称    :  Sub stDeleteFile()
    '**  機能    ： 指定されたファイル(存在チェックあり)を削除する。
    '**  戻り値  ：
    '**  引数    ： vsFName As String
    '**  備考    ：
    '***************************************************************
    Public Sub stDeleteFile(vsFName As String)

        'ファイルの存在チェック
        If Dir(vsFName) <> "" Then
            Call Kill(vsFName)        '削除
        End If

    End Sub

    '***************************************************************
    '**  名称    :  Function stSetCsvString() As String
    '**  機能    ： CSV文字列を編集する。
    '**  戻り値  ： 編集された文字列
    '**  引数    ： vsStr ; 編集する文字列
    '**  備考    ：
    '***************************************************************
    Public Function stSetCsvString(vsStr As String) As String

        stSetCsvString = Chr(34) & vsStr & Chr(34)

    End Function


    '***************************************************************
    '**  名称    : Sub stSetActiveMode()
    '**  機能    : 画面上の編集モードに対応したラベル設定を行う。
    '**  戻り値  :
    '**  引数    : voLbl  ; 表示するラベルコントロール
    '**            viMode ; 編集モード
    '**  備考    :
    '***************************************************************
    Public Sub stSetActiveMode(voLbl As Label, viMode As Integer)

        With voLbl
            Select Case viMode
                Case stIntADD   '追加モード
                    .Text = stStrADDNM
                    .BackColor = Color.FromArgb(stStrADDCLR)
                    .Font = New Font(voLbl.Font, FontStyle.Italic)


                Case stIntDEL   '削除モード
                    .Text = stStrDELNM
                    .BackColor = Color.FromArgb(stStrDELCLR)
                    .Font = New Font(voLbl.Font, FontStyle.Italic)

                Case stIntMOD   '訂正モード
                    .Text = stStrMODNM
                    .BackColor = Color.FromArgb(stStrMODCLR)
                    .Font = New Font(voLbl.Font, FontStyle.Italic)

                Case stIntDSP   '表示モード
                    .Text = stStrDSPNM
                    .BackColor = Color.FromArgb(stStrDSPCLR)
                    .Font = New Font(voLbl.Font, FontStyle.Italic)

                Case stIntAMD   '追加・訂正モード
                    .Text = stStrAMDNM
                    .BackColor = Color.FromArgb(stStrAMDCLR)
                    .Font = New Font(voLbl.Font, FontStyle.Italic)

            End Select
        End With

    End Sub


    '***************************************************************
    '**  名称    : Function stSelectSQL() As Boolean
    '**  機能    : ＳＱＬ文(Select)を実行し、結果のデータセットを返す。
    '**  戻り値  : True;正常終了 , False;エラー
    '**  引数    : vsSqlText   ; 実行するSQL文字列
    '**            voRecordset ; レコードセットオブジェクト
    '**            vlErrcode   ; エラー時のエラーコード
    '**            vsErrmsg    ; エラー時のエラーメッセージ
    '**  備考    :
    '**************************

    '***************************************************************
    '**  名称    :  Function gstStringSepCode() As String
    '**  機能    ： 指定セパレータにより指定文字列の最初コード部分を返す。
    '**  戻り値  ： 区切られた文字列
    '**  引数    ： vsStr ; 文字列
    '**             vsSep ; 区切り文字
    '**  備考    ：
    '***************************************************************
    Public Function gstStringSepCode(vsStr As String, vsSep As String) As String

        If vsStr <> "" Then
            gstStringSepCode = Left(vsStr, InStr(1, vsStr, vsSep, vbTextCompare) - 1)
        Else
            gstStringSepCode = vsStr
        End If

    End Function

    '***************************************************************
    '**  名称    : Function gksGetDateToAge() As Integer
    '**  機能    : 年齢計算基準月日と生年月日から年齢を計算する。
    '**  戻り値  : 計算された年齢
    '**  引数    : vlDBase ; 基準年月日(YYYYMMDD)
    '**            vlDBirth ; 計算する生年月日
    '**  備考    :
    '***************************************************************
    Public Function DateConv(vsDForm As String, viMode As Integer) As String

        '変換処理
        Select Case viMode
            Case 0
                DateConv = Mid(vsDForm, 1, 4) & "/" & Mid(vsDForm, 5, 2) & "/" &
                       Mid(vsDForm, 7, 2)
            Case 1
                DateConv = Format(CDate(vsDForm), "YYYYMMDD")
        End Select

    End Function
    Public Function gksGetDateToAge(vlDBase As String, vlDBirth As String) As Integer

        Dim BsDate As Date
        Dim BtDate As Date
        Dim lsWorks As String
        Dim liYear As Integer

        '基準日の設定
        BsDate = CDate(DateConv(Format(Now, "yyyy") & vlDBase, 0))  '現在年から
        '生年月日の設定
        BtDate = CDate(DateConv(vlDBirth, 0))

        '年の計算
        liYear = Math.Abs(DateDiff("yyyy", BsDate, BtDate))
        Select Case (Month(BsDate) - Month(BtDate))
            Case 0          '同じ場合
                '日付が基準日より後の場合
                If (Convert.ToInt32(Format(BsDate, "dd")) - Convert.ToInt32(Format(BtDate, "dd"))) < 0 Then
                    liYear = liYear - 1
                End If
            Case Is < 0     '基準日より後
                liYear = liYear - 1
        End Select

        gksGetDateToAge = liYear

    End Function

    '***************************************************************
    '**  名称    : Function stComboSetData() As Boolean
    '**  機能    : 指定ＳＱＬでコンボボックスにデータを設定する。
    '**            表示形式は "(Code)-(Name)"
    '**  戻り値  : True;正常終了 , False;エラー
    '**  引数    : voCBctl ;  コンボボックスコントロール
    '**            vsSql   ; ＳＱＬ文字列
    '**  備考    :
    '***************************************************************
    Public Function stComboSetData(voCBctl As ComboBox, vsSql As String) As Boolean


        Dim lsErrcode As Long
        Dim lsErrmsg As String

        On Error GoTo stComboSetData_Err
        Dim dt As DataTable




        'ＳＱＬの実行
        Dim dbsvc As New clsDB.DBService()
        dt = dbsvc.GetDatafromDB(vsSql)
        voCBctl.Items.Clear()


        For index As Integer = 1 To dt.Rows.Count

            voCBctl.Items.Add(dt.Rows(index - 1)(0) & " : " & dt.Rows(index - 1)(1))
        Next



        stComboSetData = True

stComboSetData_Exit:

        Exit Function

stComboSetData_Err:
        stComboSetData = False
        Resume stComboSetData_Exit

    End Function

    '***************************************************************
    '**  名称    : Function stComboSetDataName() As Boolean
    '**  機能    : 指定ＳＱＬでコンボボックスにデータを設定する。
    '**            表示形式は "(Name)"
    '**  戻り値  : True;正常終了 , False;エラー
    '**  引数    : voCBctl ;  コンボボックスコントロール
    '**            vsSql   ; ＳＱＬ文字列
    '**  備考    :
    '***************************************************************
    Public Function stComboSetDataName(voCBctl As ComboBox, vsSql As String) As Boolean

        Dim lsErrcode As Long
        Dim lsErrmsg As String

        On Error GoTo stComboSetData_Err
        Dim dt As DataTable




        'ＳＱＬの実行
        Dim dbsvc As New clsDB.DBService()
        dt = dbsvc.GetDatafromDB(vsSql)
        voCBctl.Items.Clear()


        For index As Integer = 1 To dt.Rows.Count

            voCBctl.Items.Add(dt.Rows(index - 1)(0))
        Next



        stComboSetDataName = True

stComboSetData_Exit:

        Exit Function

stComboSetData_Err:
        stComboSetDataName = False
        Resume stComboSetData_Exit

    End Function

    '***************************************************************
    '**  名称    : Function stComboDispData() as boolean
    '**  機能    : コンボボックスの指定コードインデックスを表示する。
    '**  戻り値  : True;インデックス設定 , False;インデックス無し
    '**  引数    : voCBctl ; コンボボックスコントロール
    '**            vsCode  ; 指定コード
    '**  備考    :
    '***************************************************************


End Module
