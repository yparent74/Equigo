Imports System.IO
Imports Equigo.ActiveRace

Public Class FTimeRecorder
    Private field1 As Double
    Private field2 As Double

    Private lPosition As Integer
    Private ReadOnly lRider1 As String
    Private ReadOnly lHorse1 As String
    Private ReadOnly lRider2 As String
    Private ReadOnly lHorse2 As String
    Private ReadOnly lRaceId As String
    Private lRaceRegistrationId As String
    Private ReadOnly lTime As String
    Private ReadOnly lPenalite As String
    Private ReadOnly lraceName As String
    Private ReadOnly lScratched As Boolean
    Private ReadOnly lDisqualified As Boolean
    Private lhasScratch As String
    Private participationPoint As String
    Private timeToRecord As Integer
    Private awardStruct As String
    Private Sub RecordRanking()
        If uxTempsTextBox.Text = "" Then uxTempsTextBox.Text = "0"

        For Each row As DataRow In ActiveRace.ldt.Rows
            If CDec(row("position")) = lPosition Then
                row("Ranking") = CDbl(uxTempsTextBox.Text)
                Exit For
            End If
        Next row

        For Each row As DataRow In ActiveRace.ldtStart.Rows
            If CDec(row("position")) = lPosition Then
                row("Ranking") = CDbl(uxTempsTextBox.Text)
                Exit For
            End If
        Next row
        'uxTempsTextBox.Text = "0"
        'uxPenaliteTextBox.Text = "0"
    End Sub

    Private Sub recordTime()
        If uxTempsTextBox.Text = "" Then uxTempsTextBox.Text = "0"
        If uxPenaliteTextBox.Text = "" Then uxPenaliteTextBox.Text = "0"

        For Each row As DataRow In ActiveRace.ldtStart.Rows
            If CDec(row("position")) = lPosition Then
                row("Time") = CDbl(uxTempsTextBox.Text)
                row("Penalite") = CDbl(uxPenaliteTextBox.Text)
                If uxPenaliteTextBox.Text.Trim = "" Then
                    row("TimePenalite") = CDbl(uxTempsTextBox.Text)
                Else
                    row("TimePenalite") = CDbl(uxTempsTextBox.Text) + CDbl(uxPenaliteTextBox.Text)
                End If

                Exit For
            End If
        Next row

        For Each row As DataRow In ActiveRace.ldt.Rows
            If CDec(row("position")) = lPosition Then
                row("Time") = CDbl(uxTempsTextBox.Text)
                row("Penalite") = CDbl(uxPenaliteTextBox.Text)
                If uxPenaliteTextBox.Text.Trim = "" Then
                    row("TimePenalite") = CDbl(uxTempsTextBox.Text)
                Else
                    row("TimePenalite") = CDbl(uxTempsTextBox.Text) + CDbl(uxPenaliteTextBox.Text)
                End If

                Exit For
            End If
        Next row

        'uxTempsTextBox.Text = "0"
        'uxPenaliteTextBox.Text = "0"

    End Sub
    Private Sub recordPoint()
        If uxTempsTextBox.Text = "" Then uxTempsTextBox.Text = "0"

        For Each row As DataRow In ActiveRace.ldtStart.Rows
            If CDec(row("position")) = lPosition Then
                row("Points") = CDbl(uxTempsTextBox.Text)
                Exit For
            End If
        Next row

        For Each row As DataRow In ActiveRace.ldt.Rows
            If CDec(row("position")) = lPosition Then
                row("Points") = CDbl(uxTempsTextBox.Text)
                Exit For
            End If
        Next row
    End Sub
    Private Sub recordDoublePoints()
        If uxTempsTextBox.Text = "" Then uxTempsTextBox.Text = "0"
        If uxPenaliteTextBox.Text = "" Then uxPenaliteTextBox.Text = "0"

        For Each row As DataRow In ActiveRace.ldtStart.Rows
            If CDec(row("position")) = lPosition Then
                row("Points") = CDbl(uxTempsTextBox.Text) + CDbl(uxPenaliteTextBox.Text)
                Exit For
            End If
        Next row

        For Each row As DataRow In ActiveRace.ldt.Rows
            If CDec(row("position")) = lPosition Then
                row("Points") = CDbl(uxTempsTextBox.Text) + CDbl(uxPenaliteTextBox.Text)
                Exit For
            End If
        Next row
    End Sub

    Private Sub StructHandler()
        If awardStruct.ToLower = ("double points") Then
            recordDoublePoints()
        ElseIf awardStruct.ToLower.Contains("point") Then
            recordPoint()
        ElseIf awardStruct.ToLower.Contains("time") Then
            recordTime()
        ElseIf awardStruct.ToLower.Contains("ranking") Then
            RecordRanking()
        End If
    End Sub
    Public Shared Function PrepSQLBoolean(ByVal val As Object) As Boolean
        If val Is DBNull.Value Then Return False
        If CBool(val) Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Sub UxSuivantButton_Click(sender As Object, e As EventArgs) Handles uxSuivantButton.Click

        If uxTempsTextBox.Text.Trim = "" Then uxTempsTextBox.Text = "0"
        If uxPenaliteTextBox.Text.Trim = "" Then uxPenaliteTextBox.Text = "0"

        field1 = CDbl(uxTempsTextBox.Text)
        field2 = CDbl(uxPenaliteTextBox.Text)

        WriteCsv(uxTeamHasBeenDisqLabel.Visible, uxTeamHasBeenScratchedLabel.Visible, uxDisqualifierButton.Text.Contains("1"c))
        StructHandler()

        Dim dataView As New DataView(ActiveRace.ldtStart) With {
            .Sort = " Position ASC"
        }
        Dim dRow As DataRow = Nothing
        Dim foundActualPos As Boolean

        For Each rowView As DataRowView In dataView
            dRow = rowView.Row

            If foundActualPos Then
                Exit For
            End If
            If dRow("Position") >= lPosition Then
                lPosition = dRow("Position")
                foundActualPos = True
                uxTempsTextBox.Enabled = False = PrepSQLBoolean(dRow("Disqualified")) OrElse PrepSQLBoolean(dRow("Scratched"))
                uxPenaliteTextBox.Enabled = uxTempsTextBox.Enabled
            End If
        Next

        Dim lastRow As DataRow = Nothing
        For Each rowView As DataRowView In dataView
            lastRow = Nothing
            lastRow = rowView.Row
        Next

        lPosition += 1

        If IsNothing(dRow("Time")) OrElse dRow("Time").Equals(DBNull.Value) Then dRow("Time") = "0"
        If IsNothing(dRow("Penalite")) OrElse dRow("Penalite").Equals(DBNull.Value) Then dRow("Penalite") = "0"

        uxPenaliteTextBox.Text = dRow("Penalite")
        uxTempsTextBox.Text = dRow("Time")

        Reload(dRow("Race registration id"), dRow("position"), dRow("Rider1 full name"), dRow("Rider2 full name"), dRow("Horse1 name"), dRow("Horse2 name"), dRow("Time"), dRow("Penalite"), PrepSQLBoolean(dRow("Disqualified")), PrepSQLBoolean(dRow("HasScratch")), PrepSQLBoolean(dRow("Scratched")))

        uxSuivantButton.Enabled = lPosition <> lastRow("Position")
        uxPrecedentButton.Enabled = True
    End Sub

    Private Sub UxTerminerButton_Click(sender As Object, e As EventArgs) Handles uxTerminerButton.Click
        If uxTempsTextBox.Text.Trim = "" Then uxTempsTextBox.Text = "0"
        If uxPenaliteTextBox.Text.Trim = "" Then uxPenaliteTextBox.Text = "0"

        field1 = CDbl(uxTempsTextBox.Text)
        field2 = CDbl(uxPenaliteTextBox.Text)
        WriteCsv(uxTeamHasBeenDisqLabel.Visible, uxTeamHasBeenScratchedLabel.Visible, uxDisqualifierButton.Text.Contains("1"c))
        StructHandler()
        Close()
    End Sub

    Private Sub UxPrecedentButton_Click(sender As Object, e As EventArgs) Handles uxPrecedentButton.Click
        uxTempsTextBox.Enabled = True
        uxPenaliteTextBox.Enabled = True

        If uxTempsTextBox.Text.Trim = "" Then uxTempsTextBox.Text = "0"
        If uxPenaliteTextBox.Text.Trim = "" Then uxPenaliteTextBox.Text = "0"

        field1 = CDbl(uxTempsTextBox.Text)
        field2 = CDbl(uxPenaliteTextBox.Text)
        WriteCsv(uxTeamHasBeenDisqLabel.Visible, uxTeamHasBeenScratchedLabel.Visible, uxDisqualifierButton.Text.Contains("1"c))
        StructHandler()

        'For Each row As DataRow In ActiveRace.ldtStart.Rows
        '    If CInt(row("position")) = lPosition Then
        '        row("Time") = CDbl(uxTempsTextBox.Text)
        '        row("Penalite") = CDbl(uxPenaliteTextBox.Text)
        '        If uxPenaliteTextBox.Text.Trim = "" Then
        '            row("TimePenalite") = CDbl(uxTempsTextBox.Text)
        '        Else
        '            row("TimePenalite") = CDbl(uxTempsTextBox.Text) + CDbl(uxPenaliteTextBox.Text)
        '        End If

        '        Exit For
        '    End If
        'Next row

        uxTempsTextBox.Text = "0"
        uxPenaliteTextBox.Text = "0"

        Dim dataView As New DataView(ActiveRace.ldtStart) With {
            .Sort = " Position DESC"
        }
        Dim dRow As DataRow = Nothing
        Dim foundActualPos As Boolean

        For Each rowView As DataRowView In dataView
            dRow = rowView.Row

            If foundActualPos Then
                Exit For
            End If
            If dRow("Position") <= lPosition Then
                lPosition = dRow("Position")
                foundActualPos = True
                uxTempsTextBox.Enabled = False = PrepSQLBoolean(dRow("Disqualified")) OrElse PrepSQLBoolean(dRow("Scratched"))
                uxPenaliteTextBox.Enabled = uxTempsTextBox.Enabled
            End If
        Next

        'Dim lastRow As DataRow = Nothing
        'For Each rowView As DataRowView In dataView
        '    lastRow = Nothing
        '    lastRow = rowView.Row
        'Next

        lPosition -= 1

        If IsNothing(dRow("Time")) OrElse dRow("Time").Equals(DBNull.Value) Then dRow("Time") = "0"
        If IsNothing(dRow("Penalite")) OrElse dRow("Penalite").Equals(DBNull.Value) Then dRow("Penalite") = "0"

        uxPenaliteTextBox.Text = dRow("Penalite")
        uxTempsTextBox.Text = dRow("Time")

        Reload(dRow("Race registration id"), dRow("position"), dRow("Rider1 full name"), dRow("Rider2 full name"), dRow("Horse1 name"), dRow("Horse2 name"), dRow("Time"), dRow("Penalite"), PrepSQLBoolean(dRow("Disqualified")), PrepSQLBoolean(dRow("HasScratch")), PrepSQLBoolean(dRow("Scratched")))

        Dim dataView2 As New DataView(ActiveRace.ldtStart) With {
            .Sort = " Position ASC"
        }

        uxPrecedentButton.Enabled = lPosition <> dataView2(0)("Position")
        uxSuivantButton.Enabled = True
    End Sub

    Private Sub Reload(raceRegistrationId As String, position As String, rider1 As String, rider2 As String, horse1 As String, horse2 As String, fTime As String, fPenalite As String, disqualified As Boolean, HasScratch As Boolean, Scratched As Boolean)
        lRaceRegistrationId = raceRegistrationId
        uxPositionLabel.Text = position
        uxRider1Label.Text = rider1
        uxRider2Label.Text = rider2
        uxHorse1Label.Text = horse1
        uxHorse2Label.Text = horse2
        uxTempsTextBox.Text = fTime
        uxPenaliteTextBox.Text = fPenalite
        uxTempsTextBox.Enabled = False = disqualified OrElse Scratched
        uxPenaliteTextBox.Enabled = uxTempsTextBox.Enabled
        uxDisqualifierButton.Enabled = uxTempsTextBox.Enabled
        uxScratchButton.Enabled = uxTempsTextBox.Enabled
        SetScratchedLabelsNFields(disqualified, Scratched)
    End Sub

    Private Sub UxPenaliteTextBox_Leave(sender As Object, e As EventArgs) Handles uxPenaliteTextBox.Leave
        If uxPenaliteTextBox.Text.Trim = "" Then Exit Sub

        If uxPenaliteTextBox.Text.Trim = "."c OrElse uxPenaliteTextBox.Text.Trim = ","c Then
            uxPenaliteTextBox.Text = ""
            Exit Sub
        End If

        uxPenaliteTextBox.Text = uxPenaliteTextBox.Text.Replace(",", Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator)
        uxPenaliteTextBox.Text = uxPenaliteTextBox.Text.Replace(".", Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator)
        uxPenaliteTextBox.Text = Math.Round(CDec(uxPenaliteTextBox.Text), 3)
        If Not uxPenaliteTextBox.Text.Contains(Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator) Then
            uxPenaliteTextBox.Text = uxPenaliteTextBox.Text + Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator + "000"
        ElseIf uxPenaliteTextBox.Text.Substring(uxPenaliteTextBox.Text.Length - 1, 1) = Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator Then
            uxPenaliteTextBox.Text = uxPenaliteTextBox.Text + "000"
        ElseIf uxPenaliteTextBox.Text.Substring(uxPenaliteTextBox.Text.Length - 2, 1) = Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator Then
            uxPenaliteTextBox.Text = uxPenaliteTextBox.Text + "00"
        ElseIf uxPenaliteTextBox.Text.Substring(uxPenaliteTextBox.Text.Length - 3, 1) = Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator Then
            uxPenaliteTextBox.Text = uxPenaliteTextBox.Text + "0"
        End If
    End Sub
    Private Sub UxTempsTextBox_Leave(sender As Object, e As EventArgs) Handles uxTempsTextBox.Leave
        If uxTempsTextBox.Text.Trim = "" OrElse uxTempsTextBox.Text.Trim = "."c OrElse uxTempsTextBox.Text.Trim = ","c Then
            uxTempsTextBox.Text = ""
            Exit Sub
        End If

        uxTempsTextBox.Text = uxTempsTextBox.Text.Replace(","c, Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator)
        uxTempsTextBox.Text = uxTempsTextBox.Text.Replace("."c, Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator)
        uxTempsTextBox.Text = Math.Round(CDec(uxTempsTextBox.Text), 3)
    End Sub

    Private Sub UxMultiplesTextBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles uxTempsTextBox.KeyPress, uxPenaliteTextBox.KeyPress
        If e.KeyChar = "."c OrElse e.KeyChar = ","c Then
            If sender.Text.Contains(","c) OrElse sender.Text.Contains("."c) Then
                e.Handled = True
                Exit Sub
            End If
        End If

        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) AndAlso Not (e.KeyChar) = "." AndAlso Not (e.KeyChar) = "," Then
            e.Handled = True
        End If
    End Sub

    Public Sub New(position As String, Rider1 As String, Horse1 As String, Rider2 As String, Horse2 As String, raceId As String, raceRegistrationId As String, pTime As String, pPenalite As String, raceName As String, HasScratch As Boolean, timeToRecord As Integer, Scratched As Boolean, Disqualified As Boolean)
        lhasScratch = HasScratch
        lRaceId = raceId
        lPosition = position
        lRider1 = Rider1
        lRider2 = Rider2
        lHorse1 = Horse1
        lHorse2 = Horse2
        lRaceRegistrationId = raceRegistrationId

        lTime = pTime
        lPenalite = pPenalite
        lraceName = raceName
        lScratched = Scratched
        lDisqualified = Disqualified
        InitializeComponent()
    End Sub
    Private Sub WriteCsv(isDisqualified As Boolean, isScratched As Boolean, isDisqualifiedOnePoint As Boolean)

        Dim inText As String
        Dim inTexts() As String
        If My.Computer.FileSystem.FileExists(My.Computer.FileSystem.SpecialDirectories.Desktop + "\Final.csv") Then
            inText = File.ReadAllText(My.Computer.FileSystem.SpecialDirectories.Desktop + "\Final.csv")
            inTexts = inText.Split(vbCrLf)


            If awardStruct.ToLower = "double points" Then
                recordDoublePoints()
            ElseIf awardStruct.ToLower.Contains("point") Then
                recordPoint()
            ElseIf awardStruct.ToLower.Contains("time") Then
                recordTime()
            ElseIf awardStruct.ToLower.Contains("ranking") Then
                RecordRanking()
            End If

            Dim found As Boolean
            For i = 0 To UBound(inTexts)
                If inTexts(i).StartsWith(lRaceRegistrationId) Then
                    If awardStruct.ToLower.Contains("point") Then 'This will do point or double points score
                        inTexts(i) = lRaceRegistrationId & ",," & field1 & "," & field2 & "," & (field1 + field2).ToString & ",," & isDisqualified.ToString.ToUpper & "," & isScratched.ToString.ToUpper
                    ElseIf awardStruct.ToLower.Contains("time") Then
                        inTexts(i) = lRaceRegistrationId & "," & (field1 + field2).ToString & ",,,,," & isDisqualified.ToString.ToUpper & "," & isScratched.ToString.ToUpper
                    ElseIf awardStruct.ToLower.Contains("ranking") Then
                        inTexts(i) = lRaceRegistrationId & ",,,,," & (field1 + field2).ToString & "," & isDisqualified.ToString.ToUpper & "," & isScratched.ToString.ToUpper
                    End If

                    found = True
                End If
            Next

            If found = False Then
                ReDim Preserve inTexts(inTexts.Length)
                If isDisqualified OrElse isScratched Then
                    If isDisqualifiedOnePoint Then
                        inTexts(inTexts.Length - 1) = lRaceRegistrationId & ",,1,,1,," & isDisqualified.ToString.ToUpper & "," & isScratched.ToString.ToUpper   '& vbCrLf
                    Else
                        inTexts(inTexts.Length - 1) = lRaceRegistrationId & ",,0,,0,," & isDisqualified.ToString.ToUpper & "," & isScratched.ToString.ToUpper   '& vbCrLf
                    End If
                Else
                    'Race registration id,Time,Score1,Score2,ScoreTotal,Ranking,Is disqualified,Is scratched
                    If awardStruct.ToLower.Contains("point") Then 'This will do point or double points score
                        inTexts(inTexts.Length - 1) = lRaceRegistrationId & ",," & field1 & "," & field2 & "," & (field1 + field2).ToString & ",," & isDisqualified.ToString.ToUpper & "," & isScratched.ToString.ToUpper
                    ElseIf awardStruct.ToLower.Contains("time") Then
                        inTexts(inTexts.Length - 1) = lRaceRegistrationId & "," & (field1 + field2).ToString & ",,,,," & isDisqualified.ToString.ToUpper & "," & isScratched.ToString.ToUpper
                    ElseIf awardStruct.ToLower.Contains("ranking") Then
                        inTexts(inTexts.Length - 1) = lRaceRegistrationId & ",,,,," & (field1 + field2).ToString & "," & isDisqualified.ToString.ToUpper & "," & isScratched.ToString.ToUpper
                    End If
                End If
            End If
            WriteAllLinesBetter(My.Computer.FileSystem.SpecialDirectories.Desktop + "\Final.csv", inTexts)
        Else
            'Race registration id,Time,Score1,Score2,ScoreTotal,Ranking,Is disqualified,Is scratched
            If awardStruct.ToLower.Contains("point") Then 'This will do point or double points score
                File.WriteAllText(My.Computer.FileSystem.SpecialDirectories.Desktop + "\Final.csv", lRaceRegistrationId & ",," & field1 & "," & field2 & "," & (field1 + field2).ToString & ",," & isDisqualified.ToString.ToUpper & "," & isScratched.ToString.ToUpper)
            ElseIf awardStruct.ToLower.Contains("time") Then
                File.WriteAllText(My.Computer.FileSystem.SpecialDirectories.Desktop + "\Final.csv", lRaceRegistrationId & "," & (field1 + field2).ToString & ",,,,," & isDisqualified.ToString.ToUpper & "," & isScratched.ToString.ToUpper)
            ElseIf awardStruct.ToLower.Contains("ranking") Then
                File.WriteAllText(My.Computer.FileSystem.SpecialDirectories.Desktop + "\Final.csv", lRaceRegistrationId & ",,,,," & (field1 + field2).ToString & "," & isDisqualified.ToString.ToUpper & "," & isScratched.ToString.ToUpper)
            End If
        End If
    End Sub

    Public Shared Sub WriteAllLinesBetter(ByVal path As String, ParamArray lines As String())
        If path Is Nothing Then Throw New ArgumentNullException(NameOf(path))
        If lines Is Nothing Then Throw New ArgumentNullException(NameOf(lines))

        Using stream = File.OpenWrite(path)
            stream.SetLength(0)

            Using writer = New StreamWriter(stream)

                If lines.Length > 0 Then

                    For i = 0 To lines.Length - 1 - 1
                        writer.WriteLine(lines(i))
                    Next

                    writer.Write(lines(lines.Length - 1))
                End If
            End Using
        End Using
    End Sub

    Private Sub FTimeRecorder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BackColor = System.Drawing.ColorTranslator.FromHtml("#2596be")
        uxPositionLabel.Text = lPosition
        uxRider1Label.Text = lRider1
        uxRider2Label.Text = lRider2
        uxHorse1Label.Text = lHorse1
        uxHorse2Label.Text = lHorse2
        uxPrecedentButton.Enabled = lPosition > 1
        uxSuivantButton.Enabled = lPosition < ldtStart.Rows.Count
        uxTempsTextBox.Text = lTime
        uxPenaliteTextBox.Text = lPenalite
        uxNomDeCourseLabel.Text = lraceName
        uxScratchButton.Visible = lhasScratch

        Dim fileReader As String = My.Computer.FileSystem.ReadAllText(FMain.PathJsonLabel)
        Dim a = Split(fileReader, ldtStart(0)("Race id"))
        Dim b = Split(a(1), "Race id")
        Dim activeRace As String = b(0)

        awardStruct = activeRace.Substring(activeRace.IndexOf("Award structure type") + 22, 100)
        awardStruct = awardStruct.Substring(2, awardStruct.IndexOf(vbLf) - 4)

        lhasScratch = activeRace.Substring(activeRace.IndexOf("Has scratch") + 10, 100)
        lhasScratch = lhasScratch.Substring(2, lhasScratch.IndexOf(vbLf) - 4)

        If awardStruct.ToLower = ("double points") Then
            uxTempsLabel.Text = "Score 1:"
            uxTempsPenaliteLabel.Text = "Score 2:"
        ElseIf awardStruct.ToLower.Contains("point") Then
            uxTempsLabel.Text = "Score 1:"
            uxTempsPenaliteLabel.Visible = False
            uxPenaliteTextBox.Visible = False
        ElseIf awardStruct.ToLower.Contains("time") Then
            uxTempsLabel.Text = "Temps:"
            uxTempsPenaliteLabel.Text = "Pénalité:"
        ElseIf awardStruct.ToLower.Contains("ranking") Then
            uxTempsPenaliteLabel.Visible = False
            uxPenaliteTextBox.Visible = False
            uxTempsLabel.Text = "Rang:"
        End If

        participationPoint = activeRace.Substring(activeRace.IndexOf("Participation point") + 19, 20)
        participationPoint = System.Text.RegularExpressions.Regex.Replace(participationPoint, "[^\d]", " ").Trim
        If participationPoint = "0" Then
            uxDisqualifierButton.Text = "Disqualifier"
        Else
            uxDisqualifierButton.Text = "Disqualifier (1 point)"
        End If

        SetScratchedLabelsNFields(lDisqualified, lScratched)
    End Sub

    Private Sub UxDisqualifierButton_Click(sender As Object, e As EventArgs) Handles uxDisqualifierButton.Click
        If MessageBox.Show("Voulez-vous vraiment disqualifier?", "", MessageBoxButtons.YesNoCancel) <> DialogResult.Yes Then Exit Sub
        WriteCsv(True, False, uxDisqualifierButton.Text.Contains("1"c))

        For Each row As DataRow In ActiveRace.ldtStart.Rows
            If CDec(row("position")) = lPosition Then
                row("Disqualified") = True
                If uxDisqualifierButton.Text.Contains("1"c) Then
                    row("Points") = "1"
                Else
                    row("Points") = "0"
                End If
            End If
        Next row

        For Each row As DataRow In ActiveRace.ldt.Rows
            If CDec(row("position")) = lPosition Then
                row("Disqualified") = True
                If uxDisqualifierButton.Text.Contains("1"c) Then
                    row("Points") = "1"
                Else
                    row("Points") = "0"
                End If
            End If
        Next row
        SetScratchedLabelsNFields(True, False)
    End Sub

    Private Sub UxScratchButton_Click(sender As Object, e As EventArgs) Handles uxScratchButton.Click
        If MessageBox.Show("Voulez-vous vraiment ""scratcher""?", "", MessageBoxButtons.YesNoCancel) <> DialogResult.Yes Then Exit Sub

        If uxTempsTextBox.Text.Trim <> "" Then
            If uxPenaliteTextBox.Text.Trim = "" Then
                field1 = CDbl(uxTempsTextBox.Text.Trim)
                field2 = 0
            Else
                field1 = CDbl(uxTempsTextBox.Text.Trim)
                field2 = CDbl(uxPenaliteTextBox.Text.Trim)
            End If
            WriteCsv(uxTeamHasBeenDisqLabel.Visible, uxTeamHasBeenScratchedLabel.Visible, uxDisqualifierButton.Text.Contains("1"c))

            For Each row As DataRow In ActiveRace.ldtStart.Rows
                If CDec(row("position")) = lPosition Then
                    row("Time") = 0
                    row("Penalite") = 0D
                    row("TimePenalite") = 0
                    row("Scratched") = True
                    row("Points") = "0"
                    Exit For
                End If
            Next row

            For Each row As DataRow In ActiveRace.ldt.Rows
                If CDec(row("position")) = lPosition Then
                    row("Time") = 0
                    row("Penalite") = 0D
                    row("TimePenalite") = 0
                    row("Scratched") = True
                    row("Points") = "0"
                    Exit For
                End If
            Next row
        End If
        SetScratchedLabelsNFields(False, True)
    End Sub

    Private Sub SetScratchedLabelsNFields(disqualified As Boolean, scratched As Boolean)
        uxTempsTextBox.Enabled = disqualified = False AndAlso scratched = False
        uxPenaliteTextBox.Enabled = uxTempsTextBox.Enabled
        uxTeamHasBeenScratchedLabel.Visible = scratched
        uxTeamHasBeenDisqLabel.Visible = disqualified
    End Sub
End Class