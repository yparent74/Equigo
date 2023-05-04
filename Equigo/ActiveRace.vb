Imports System.IO

'Imports BaseLibS
'Imports iTextSharp.text
'Imports Microsoft.Office.Interop.Word

Public Class ActiveRace
    Public Shared ldt As DataTable
    Public Shared ldtStart As DataTable
    Private ldtStartStatic As DataTable
    Private isLoaded As Boolean
    Dim a As DataTable
    Private lTractorFrequency As Integer
    Private resetTractor As Boolean
    Private ReadOnly lHasScratch As Boolean
    'Private ReadOnly lDoublePoints As Boolean
    Private timeToRecord As Integer

    'Beginning of "Ordre de passage" variables
    Private raceTitle As String ' TITRE DE LA CLASSE (String);
    Private userLanguage As String ' "fr_ca" ou "en_us" (String);
    Private raceTeamType As String ' race Teamtype (String)
    Private tractorFrequency As String ' tractor frequency (int)
    Private tractorOffset As String ' si la classe choisie est une 2e Go, trouver le nombre d'inscription qui ne sont pas des rollovers dont le raceId as stringas stringas string cette classe.De ce nombre (appelons le rrCount) effectuer un modulo, c'est-à-dire : rrCount % currentRace.tractorfrequency
    ' Si la classe n'est pas une 2e Go, mettre tout simplement la valeur de 0 (int)
    Private position As String ' rr position (int)
    ' Private lBibNumber As String ' rr bib number (String)
    Private rider1FirstName As String ' rr rider1 first name (String)
    Private rider1LastName As String ' rr rider1 last name (String)
    Private rider2FirstName As String ' rider2 first name (String)
    Private rider2LastName As String ' rider2 last name (String)
    Private horse1Name As String ' rr horse1 name (String)
    Private horse2Name As String ' rr horse2 name (String)
    Private finalFileUnavailable As Boolean
    Private lAwardStructureType As String
    Private lHasStruct As String
    Private lCashMathManipulation As String
    Private lparticipationPoints As Integer
    Private lPathJsonLabel As String

    Private calcDt As New DataTable

    Public Sub New(raceName As String, tractorFrequency As Integer, HasScratch As Boolean, awardStructureType As String, cashMathManipulation As String, hasStruct As String, participationPoints As Integer, pathJson As String)
        InitializeComponent()
        uxCourseActiveLabel.Text = raceName
        lTractorFrequency = tractorFrequency
        lHasScratch = HasScratch
        lAwardStructureType = awardStructureType
        lCashMathManipulation = cashMathManipulation
        lHasStruct = hasStruct
        lparticipationPoints = participationPoints
        lPathJsonLabel = pathJson
        '  lBibNumber = bibNumber
        With calcDt
            .Columns.Add("NameD", GetType(String))
            .Columns.Add("CashAm", GetType(Decimal))
            .Columns.Add("PotPercent", GetType(Decimal))
            .Columns.Add("StartTime", GetType(Decimal))
            .Columns.Add("Rank", GetType(Integer))
            .Columns.Add("Points", GetType(Decimal))
            .Columns.Add("SubPotPerc", GetType(Decimal))
            .Columns.Add("CalcCash", GetType(Decimal))
            .Columns.Add("NameDRank", GetType(String))
            .Columns.Add("Distributed", GetType(Boolean))
            .Columns.Add("TimeLimit", GetType(Decimal))
            .Columns.Add("OrderN", GetType(Integer))
            .Columns.Add("NumberOfPos", GetType(Integer))
        End With

    End Sub

    Private Sub uxOrdreDePassageButton_Click(sender As Object, e As EventArgs) Handles uxOrdreDePassageButton.Click 'todo
        If ldt.Rows.Count < 1 Then
            MessageBox.Show("Il n'y a rien à imprimer.")
            Exit Sub
        End If

        Dim hTMLData = "`<!DOCTYPE html>
                <html lang = ""en"" >
                <head>
                    <meta charset=""UTF-8"">
                        <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                            <title>Ordre de passage : </title>
                            <style>
                        table, th, td {
                            border: 2px solid;
                            text-align: center;
                            font-size: 19px;
                            font-family: Helvetica, sans-serif;
                        }

        th{
            font - size:  24px;
                    padding 6px;
                }

                table {
                    border - collapse: collapse;
                    width: 100%;
                }

                td{
                    padding:  4px;
                    white-space: pre;
                }

                tr{
                    page - break - inside: avoid; 
                    page-break - after: auto;
                }

#tractor{
        background-color: rgb(187, 187, 187);
                    font-weight: bold;
                }

                img{
                     margin: auto;
                    display: block;
                    max-width:  60%;
                    height: auto;
                }

                h1{
                    text - align: center;
                    margin-bottom:  20px;
                    font-size:  30px;
                }

            </style>
        </head>
        <body>
            <div id = ""main"" >
            <img id = ""header image"" src=""https://s3.amazonaws.com/appforest_uf/f1662736904535x460699868596440770/image_2022-09-09_112144378.png"" width=""800"" height=""237"">
                
                <h1 style=""text-align:center""><span style=""font-size:28px""><strong>Ordre de passages : " + uxCourseActiveLabel.Text + "</strong></span></h1>
   <h1 style=""text-align:center""  </h1> 
            </div>

<table align=""center"" border=""1"" cellpadding=""0"" cellspacing=""0"" style=""width:100%"">
	<caption>
	<h1 style=""text-align:center""><span style=""font-size:18px""><strong></strong></span></h1>

	<p>&nbsp;</p>
	</caption>
	<thead>
		<tr>
			<th scope=""col"" style=""text-align: center;""><span style=""font-size:24px""><strong>Position</strong></span></th>
			<th scope=""col"">
			<p style=""text-align:center""><span style=""font-size:24px""><strong>Dossards</strong></span></p>

			<p style=""text-align:center""><span style=""font-size:24px""><strong>(&eacute;quipe)</strong></span></p>
			</th>
			<th scope=""col"" style=""text-align: center;""><span style=""font-size:24px""><strong>Cavalier(&egrave;res)</strong></span></th>
			<th scope=""col"" style=""text-align: center;""><span style=""font-size:24px""><strong>Chevaux</strong></span></th>
			<th scope=""col"" style=""text-align: center;""><span style=""font-size:24px""><strong>R&eacute;sultats</strong></span></th>
		</tr>
	</thead>
	<tbody>"

        Dim dataView
        If lAwardStructureType.ToLower = "time" Then
            dataView = New DataView(ldt) With {
                .Sort = " Position ASC"
            }
        Else
            dataView = New DataView(ldt) With {
                .Sort = " Position Desc"
            }
        End If

        Dim dataTable As DataTable = dataView.ToTable()
        ldt = dataTable

        Dim n As Integer
        For Each row As DataRow In ldt.rows

            hTMLData += "
		<tr>"
            If row("Rider1 full name").ToString.ToLower.Trim = "tracteur" Then
                hTMLData += "<td><strong>Tracteur</strong></td>
                <td>&nbsp;</td>
                			<td>&nbsp;</td>
			<td>&nbsp;</td>"

            Else
                n += 1
                hTMLData += "<td>" + CStr(n) + "</td>
                <td>" + row("BibNumber") + "</td>
                <td>" + row("Rider1 full name").ToString() + " " + row("Rider2 full name").ToString() + "</td>
      		    <td>" + row("Horse1 name").ToString() + " " + row("Horse2 name").ToString() + "</td>
    			<td>&nbsp;</td>"
            End If
            hTMLData += "
	

			 
		</tr>"
        Next
        hTMLData += "
	</tbody>
</table>

           </body>
           </html>`"


        File.WriteAllText(My.Computer.FileSystem.SpecialDirectories.Desktop + "\Ordre_de_passage.htm", hTMLData)

        Dim p As New Process
        p.StartInfo.UseShellExecute = True
        p.StartInfo.FileName = My.Computer.FileSystem.SpecialDirectories.Desktop + "\Ordre_de_passage.htm"
        p.Start()
    End Sub
    Private Function CreateRiderText(teamType, rider1FirstName, rider1LastName, rider2FirstName, rider2LastName)
        Text = rider1FirstName + " " + rider1LastName
        If (teamType = "Duo") Then
            Text += "\n" + rider2FirstName + " " + rider2LastName
        End If
        Return Text
    End Function

    Private Function CreateHorseText(teamType, horse1Name, horse2Name)
        Text = horse1Name
        If (teamType = "Quatuor") Then
            Text += "\n" + horse2Name
        End If
        Return Text
    End Function
    Private Sub AddTractorFrequency()
        If resetTractor Then
            For Each row As DataRow In ldt.Rows
                '   MessageBox.Show(row("Horse1 Name").ToString)
                If Not IsNothing(row("Rider1 full name")) AndAlso row("Rider1 full name").ToString = "Tracteur" Then
                    row.Delete()
                    Exit For
                End If
            Next row
        End If

        If lTractorFrequency < 1 Then Exit Sub

        Dim dataView As New DataView(ldt) With {
            .Sort = " Position ASC"
        }
        Dim dataTable As DataTable = dataView.ToTable()
        ldt = dataTable

        Dim dr As DataRow
        dr = ldt.NewRow()
        dr(1) = "Tracteur"
        dr(5) = lTractorFrequency + 0.5

        ldt.Rows.InsertAt(dr, lTractorFrequency - 1)

        'If resetTractor Then
        '    For Each row As DataRow In ldtStart.Rows
        '        '   MessageBox.Show(row("Horse1 Name").ToString)
        '        If Not IsNothing(row("Rider1 full name")) AndAlso row("Rider1 full name").ToString = "Tracteur" Then
        '            row.Delete()
        '            Exit For
        '        End If
        '    Next row
        'End If

        'If lTractorFrequency < 1 Then Exit Sub

        'dataView = New DataView(ldtStart) With {
        '    .Sort = " Position ASC"
        '}
        'dataTable = dataView.ToTable()
        'ldtStart = dataTable

        'dr = ldtStart.NewRow()
        'dr(1) = "Tracteur"
        'dr(5) = lTractorFrequency + 0.5

        'ldtStart.Rows.InsertAt(dr, lTractorFrequency - 1)
    End Sub
    Private Sub ActiveRace_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BackColor = System.Drawing.ColorTranslator.FromHtml("#2596be")
        ldt.Columns.Add("Time", GetType(Decimal))
        ldt.Columns.Add("Penalite", GetType(Decimal))
        ldt.Columns.Add("TimePenalite", GetType(Decimal))
        ldt.Columns.Add("hasScratch", GetType(Boolean))
        ldt.Columns.Add("Ranking", GetType(String))
        ldt.Columns.Add("Disqualified", GetType(Boolean))
        ldt.Columns.Add("DivisionRank", GetType(String))
        ldt.Columns.Add("Grant", GetType(Decimal))
        ldt.Columns.Add("Points", GetType(Decimal))
        ldt.Columns.Add("CalcPoints", GetType(Decimal))
        ldt.Columns.Add("Scratched", GetType(Boolean))

        ldtStart.Columns.Add("Time", GetType(Decimal))
        ldtStart.Columns.Add("Penalite", GetType(Decimal))
        ldtStart.Columns.Add("TimePenalite", GetType(Decimal))
        ldtStart.Columns.Add("hasScratch", GetType(Boolean))
        ldtStart.Columns.Add("Ranking", GetType(String))
        ldtStart.Columns.Add("Disqualified", GetType(Boolean))
        ldtStart.Columns.Add("DivisionRank", GetType(String))
        ldtStart.Columns.Add("Grant", GetType(Decimal))
        ldtStart.Columns.Add("Points", GetType(Decimal))
        ldtStart.Columns.Add("CalcPoints", GetType(Decimal))
        ldtStart.Columns.Add("Division", GetType(String))
        ldtStart.Columns.Add("Scratched", GetType(Boolean))
        ldtStart.Columns.Add("Distributed", GetType(Boolean))

        resetTractor = True

        Dim originalRowsCount As Integer = ldt.Rows.Count
        Dim originalTractorFrequency As Integer = lTractorFrequency
        Do While lTractorFrequency < originalRowsCount And lTractorFrequency <> 0
            AddTractorFrequency()
            lTractorFrequency += originalTractorFrequency
            resetTractor = False
        Loop

        DataGridView1.DataSource = ldt
        DataGridViewStartUpRace.DataSource = ldtStart

        DataGridView1.Columns("Race id").Visible = False
        DataGridView1.Columns("TimePenalite").HeaderText = "Temps total"
        DataGridView1.Columns("Race registration id").Visible = False
        DataGridView1.Columns("Horse1 name").HeaderText = "Nom du premier cheval"
        DataGridView1.Columns("Horse2 name").HeaderText = "Nom du deuxième cheval"
        DataGridView1.Columns("Rider1 full name").HeaderText = "Nom du premier cavalier"
        DataGridView1.Columns("Rider2 full name").HeaderText = "Nom du deuxième cavalier"
        DataGridView1.Columns("BibNumber").Visible = False

        DataGridViewStartUpRace.Columns("BibNumber").Visible = False
        DataGridViewStartUpRace.Columns("CalcPoints").Visible = False
        DataGridViewStartUpRace.Columns("Division").Visible = False
        DataGridViewStartUpRace.Columns("Grant").Visible = False

        DataGridViewStartUpRace.Columns("Ranking").Visible = False
        DataGridViewStartUpRace.Columns("Race id").Visible = False
        DataGridViewStartUpRace.Columns("TimePenalite").HeaderText = "Temps total"
        DataGridViewStartUpRace.Columns("Race registration id").Visible = False
        DataGridViewStartUpRace.Columns("Horse1 name").HeaderText = "Nom du premier cheval"
        DataGridViewStartUpRace.Columns("Horse2 name").HeaderText = "Nom du deuxième cheval"
        DataGridViewStartUpRace.Columns("Rider1 full name").HeaderText = "Nom du premier cavalier"
        DataGridViewStartUpRace.Columns("Rider2 full name").HeaderText = "Nom du deuxième cavalier"

        Dim buttonColumn As New DataGridViewButtonColumn With {
            .Name = "Button",
            .Text = "Modifier",
            .UseColumnTextForButtonValue = True
        }

        DataGridView1.Columns.Add(buttonColumn)

        DataGridView1.Columns("Button").DisplayIndex = 1
        DataGridView1.Columns("Button").MinimumWidth = 52
        DataGridView1.Columns("Button").HeaderText = ""
        buttonColumn.FlatStyle = FlatStyle.Flat

        buttonColumn.DefaultCellStyle.BackColor = Color.LightGray

        'DataGridView1.Sort(DataGridView1.Columns("TimePenalite"), System.ComponentModel.ListSortDirection.Ascending)

        DataGridViewStartUpRace.DataSource = ldtStart

        DataGridViewStartUpRace.Columns("Race id").Visible = False
        DataGridViewStartUpRace.Columns("TimePenalite").HeaderText = "Temps total"

        DataGridViewStartUpRace.Columns("Time").Visible = False
        DataGridViewStartUpRace.Columns("Penalite").Visible = False

        DataGridViewStartUpRace.Columns("Race registration id").Visible = False
        DataGridViewStartUpRace.Columns("Horse1 name").HeaderText = "Nom du premier cheval"
        DataGridViewStartUpRace.Columns("Horse2 name").HeaderText = "Nom du deuxième cheval"
        DataGridViewStartUpRace.Columns("Rider1 full name").HeaderText = "Nom du premier cavalier"
        DataGridViewStartUpRace.Columns("Rider2 full name").HeaderText = "Nom du deuxième cavalier"

        DataGridViewStartUpRace.Sort(DataGridViewStartUpRace.Columns("TimePenalite"), System.ComponentModel.ListSortDirection.Ascending)

        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        HideBlankColumns()
        ResizeColumns()

        ReadFinalFile()
        'If ReadFinalFile() = False Then Close()

        For Each row As DataRow In ActiveRace.ldt.Rows
            If row("Time").ToString.EndsWith(",") OrElse row("Time").ToString.EndsWith(".") Then
                row("Time") = row("Time").ToString.Length - 1
            End If
            If row("Penalite").ToString.EndsWith(",") OrElse row("Penalite").ToString.EndsWith(".") Then
                row("Penalite") = row("Penalite").ToString.Length - 1
            End If
            If row("TimePenalite").ToString.EndsWith(",") OrElse row("TimePenalite").ToString.EndsWith(".") Then
                row("TimePenalite") = row("TimePenalite").ToString.Length - 1
            End If
        Next row

        For Each row As DataRow In ActiveRace.ldtStart.Rows
            If row("Time").ToString.EndsWith(",") OrElse row("Time").ToString.EndsWith(".") Then
                row("Time") = row("Time").ToString.Length - 1
            End If
            If row("Penalite").ToString.EndsWith(",") OrElse row("Penalite").ToString.EndsWith(".") Then
                row("Penalite") = row("Penalite").ToString.Length - 1
            End If
            If row("TimePenalite").ToString.EndsWith(",") OrElse row("TimePenalite").ToString.EndsWith(".") Then
                row("TimePenalite") = row("TimePenalite").ToString.Length - 1
            End If
        Next row

        Dim distinct As DataTable = ldt.DefaultView.ToTable(True, "Position")
        Do While distinct.Rows.Count <> ldt.Rows.Count
            renumDup(True)
            distinct = ldt.DefaultView.ToTable(True, "Position")
        Loop

        distinct.Clear()
        distinct = ldtStart.DefaultView.ToTable(True, "Position")
        Do While distinct.Rows.Count <> ldtStart.Rows.Count
            renumDup(False)
            distinct = ldtStart.DefaultView.ToTable(True, "Position")
        Loop


        'Dim dupFound As Integer
        'Dim dups = From row In ldt.AsEnumerable()
        '           Let position = row.Field(Of Decimal)("Position")
        '           Group row By position Into DupPosition = Group
        '           Where DupPosition.Count() > 1
        '           Select DupPosition
        'For Each dupPositionRows In dups
        '    For Each row In dupPositionRows
        '        dupFound += 1
        '        row("Position") = row.Field(Of Decimal)("Position") + dupFound
        '        Exit For
        '    Next
        'Next


        'dups = From row In ldt.AsEnumerable()
        '       Let position = row.Field(Of Decimal)("Position")
        '       Group row By position Into DupPosition = Group
        '       Where DupPosition.Count() > 1
        '       Select DupPosition
        'For Each dupPositionRows In dups
        '    For Each row In dupPositionRows
        '        row("Position") = row.Field(Of Decimal)("Position") + dupFound
        '        Exit For
        '    Next
        'Next

        DataGridView1.Sort(DataGridView1.Columns("Position"), System.ComponentModel.ListSortDirection.Ascending)
        DataGridViewStartUpRace.Columns("TimePenalite").Width = 30
        DataGridViewStartUpRace.Sort(DataGridViewStartUpRace.Columns("TimePenalite"), System.ComponentModel.ListSortDirection.Ascending)
    End Sub
    Private Sub renumDup(isLdt As Boolean)
        Dim dupFound As Integer
        If isLdt Then
            Dim dups = From row In ldt.AsEnumerable()
                       Let position = row.Field(Of Decimal)("Position")
                       Group row By position Into DupPosition = Group
                       Where DupPosition.Count() > 1
                       Select DupPosition
            For Each dupPositionRows In dups
                For Each row In dupPositionRows
                    dupFound += 1
                    row("Position") = row.Field(Of Decimal)("Position") + dupFound
                    Exit For
                Next
            Next
        Else
            Dim dups = From row In ldtStart.AsEnumerable()
                       Let position = row.Field(Of Decimal)("Position")
                       Group row By position Into DupPosition = Group
                       Where DupPosition.Count() > 1
                       Select DupPosition
            For Each dupPositionRows In dups
                For Each row In dupPositionRows
                    dupFound += 1
                    row("Position") = row.Field(Of Decimal)("Position") + dupFound
                    Exit For
                Next
            Next
        End If
    End Sub
    Private Sub ResizeColumns()
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
        DataGridViewStartUpRace.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
    End Sub
    Private Function ReadFinalFile() As Boolean
        If Not My.Computer.FileSystem.FileExists(My.Computer.FileSystem.SpecialDirectories.Desktop + "\Final.csv") Then Return False

        If finalFileUnavailable Then Return False

        Dim strArr() As String
        Dim d As String = ""

        For Each row As DataRow In ldt.Rows
            If Not IsDBNull(row("Race registration id")) AndAlso row("Race registration id") <> "" Then
                If finalFileUnavailable Then Return False
                'Dim d As String = ReadTime(row("Race registration id"), False, False)
                d = ReadTime(row("Race registration id"))
                If d <> "" AndAlso d <> "0" Then
                    If d.EndsWith(".") Then
                        d = d.Substring(0, d.Length - 1)
                    End If

                    strArr = d.Split(",")

                    If lAwardStructureType.ToLower = "point" OrElse lAwardStructureType.ToLower = "double points" Then
                        row("CalcPoints") = strArr(4)
                    ElseIf lAwardStructureType.ToLower = "ranking" Then
                        row("Ranking") = strArr(5)

                    ElseIf lAwardStructureType.ToLower = "time" Then
                        row("Time") = strArr(1)
                    End If

                    '  row(col) = strArr(starr) + Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator + strArr(starr)
                    If lAwardStructureType.ToLower = "time" Then
                        row("TimePenalite") = CDbl(row("Time"))
                    End If
                    row("Disqualified") = strArr(6)
                    row("Scratched") = strArr(7)
                End If
            End If
        Next row

        For Each row As DataRow In ldtStart.Rows
            If Not IsDBNull(row("Race registration id")) AndAlso row("Race registration id") <> "" Then
                If finalFileUnavailable Then Return False
                'Dim d As String = ReadTime(row("Race registration id"), False, False)
                d = ReadTime(row("Race registration id"))
                If d <> "" AndAlso d <> "0" Then
                    If d.EndsWith(".") Then
                        d = d.Substring(0, d.Length - 1)
                    End If

                    strArr = d.Split(",")

                    If lAwardStructureType.ToLower = "point" OrElse lAwardStructureType.ToLower = "double points" Then
                        row("CalcPoints") = strArr(4)
                    ElseIf lAwardStructureType.ToLower = "ranking" Then
                        row("Ranking") = strArr(5)

                    ElseIf lAwardStructureType.ToLower = "time" Then
                        row("Time") = strArr(1)
                    End If

                    '  row(col) = strArr(starr) + Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator + strArr(starr)
                    If lAwardStructureType.ToLower = "time" Then
                        row("TimePenalite") = CDbl(row("Time"))
                    End If
                    row("Disqualified") = strArr(6)
                    row("Scratched") = strArr(7)
                End If
            End If
        Next row

        Return True
    End Function

    Private Function ReadTime(lRaceRegistrationId As String) As String
        Try
            Dim inText As String
            Dim inTexts() As String

            inText = File.ReadAllText(My.Computer.FileSystem.SpecialDirectories.Desktop + "\Final.csv")
            inTexts = inText.Split(vbCrLf)

            For i = 0 To UBound(inTexts)
                If inTexts(i).StartsWith(lRaceRegistrationId) Then
                    Return inTexts(i)
                End If
            Next

            Return "0"
        Catch ex As Exception
            If ex.HResult = -2147024864 Then
                MessageBox.Show("Le fichier Final.csv est déjà ouvert, pour continuer veuiller le fermer et réessayer")
                finalFileUnavailable = True
            End If
            Return "0"
        End Try
    End Function
    Private Sub HideBlankColumns()
        For Each row As DataRow In ldt.Rows
            If Not IsDBNull(row("Horse2 name")) AndAlso row("Horse2 name") <> "" Then
                Exit Sub
            End If
        Next row
        DataGridView1.Columns("Horse2 name").Visible = False
        DataGridViewStartUpRace.Columns("Horse2 name").Visible = False
        HideRider()
    End Sub
    Private Sub HideRider()
        For Each row As DataRow In ldt.Rows
            If Not IsDBNull(row("Rider2 full name")) AndAlso row("Rider2 full name") <> "" Then
                Exit Sub
            End If
        Next row
        DataGridView1.Columns("Rider2 full name").Visible = False
        DataGridViewStartUpRace.Columns("Rider2 full name").Visible = False
    End Sub
    Private Sub UxStartRaceButton_Click(sender As Object, e As EventArgs) Handles uxStartRaceButton.Click
        Dim rider1FullName, horse1Name, rider2FullName, horse2Name, raceId, raceRegistrationId, rTimer, rPenalite As String
        rider1FullName = ""
        rTimer = ""
        rider2FullName = ""
        horse2Name = ""
        raceRegistrationId = ""
        raceId = ""
        rPenalite = ""
        horse1Name = ""
        Dim fScratched As Boolean
        Dim fDisqualified As Boolean
        Dim fHasScratch As Boolean
        Dim lowestPosition As Integer
        timeToRecord = 0
        For Each row As DataRow In ldtStart.Rows
            If IsDBNull(row("TimePenalite")) OrElse CStr(row("TimePenalite")).Trim = "" OrElse CStr(row("TimePenalite")).Trim = "0" Then
                If CStr(row("Rider1 full name")) <> "Tracteur" Then
                    timeToRecord += 1
                    If lowestPosition = 0 Or CInt(row("Position")) < lowestPosition Then
                        lowestPosition = CInt(row("Position"))
                    End If
                End If
            End If
        Next row

        Dim ind As Integer
        For Each row As DataRow In ldtStart.Rows
            ind += 1

            If lowestPosition = CDec(row("Position")) Then
                rider1FullName = row("Rider1 full name").ToString
                horse1Name = row("Horse1 name").ToString
                rider2FullName = row("Rider2 full name").ToString
                horse2Name = row("Horse2 name").ToString
                raceId = row("Race id").ToString
                raceRegistrationId = row("Race registration id").ToString
                rTimer = row("Time").ToString
                rPenalite = row("Penalite").ToString
                fScratched = FTimeRecorder.PrepSQLBoolean(row("Scratched"))
                fDisqualified = FTimeRecorder.PrepSQLBoolean(row("Disqualified"))
                fHasScratch = FTimeRecorder.PrepSQLBoolean(row("hasScratch"))
                Exit For
            End If
        Next row

        If lowestPosition = 0 OrElse timeToRecord < 1 Then
            MessageBox.Show("Il n'a pas de temps à enregistrer")
            Exit Sub
        End If
        Dim objForm As New FTimeRecorder(lowestPosition, rider1FullName, horse1Name, rider2FullName, horse2Name, raceId, raceRegistrationId, rTimer, rPenalite, uxCourseActiveLabel.Text, lHasScratch, timeToRecord, fScratched, fDisqualified)
        objForm.ShowDialog()
    End Sub
    Private Sub ActiveRace_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        isLoaded = True
        'uxResultatsButton.PerformClick()
    End Sub

    Private Sub UxRetourClassesButton_Click(sender As Object, e As EventArgs) Handles uxRetourClassesButton.Click
        Close()
    End Sub


    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If isLoaded = False Then Exit Sub
        If IsNothing(DataGridView1.CurrentRow.Cells("Rider1 full name").Value) OrElse DataGridView1.CurrentRow.Cells("Rider1 full name").Value.ToString.Trim = "" OrElse DataGridView1.CurrentRow.Cells("Rider1 full name").Value.ToString.Trim = "Tracteur" Then Exit Sub
        If e.ColumnIndex = 19 Then
            Dim objForm As New FTimeRecorder(CInt(DataGridView1.CurrentRow.Cells("Position").Value), DataGridView1.CurrentRow.Cells("Rider1 full name").Value.ToString, DataGridView1.CurrentRow.Cells("Horse1 name").Value.ToString, DataGridView1.CurrentRow.Cells("Rider2 full name").Value.ToString, DataGridView1.CurrentRow.Cells("Horse2 name").Value.ToString, DataGridView1.CurrentRow.Cells("Race id").Value.ToString, DataGridView1.CurrentRow.Cells("Race registration id").Value.ToString, DataGridView1.CurrentRow.Cells("Time").Value.ToString, DataGridView1.CurrentRow.Cells("Penalite").Value.ToString, uxCourseActiveLabel.Text, lHasScratch, timeToRecord, FTimeRecorder.PrepSQLBoolean(DataGridView1.CurrentRow.Cells("Scratched").Value), FTimeRecorder.PrepSQLBoolean(DataGridView1.CurrentRow.Cells("Disqualified").Value))
            objForm.ShowDialog()
        End If
    End Sub

    Private Sub calculPointsDivGrant()

        calcDt.Rows.Clear()

        ''''''''''''''''''''''''''''deb
        '''
        Dim content As String = IO.File.ReadAllText(lPathJsonLabel)
        Dim a As String() = content.Split(",")
        Dim lengthCache As Integer = a.Length - 1
        Dim splitter() As String


        Dim dr As DataRow = calcDt.NewRow

        'dr(1) = "Tracteur"
        'dr(5) = lTractorFrequency + 0.5

        Dim raceIdFound As Boolean

        Dim prevNameD As String = ""
        Dim prevCashAm As Decimal
        Dim prevStartTime As Decimal
        Dim prevPotPercent As Decimal
        Dim orderN As Integer

        'ldt.Rows.InsertAt(dr, lTractorFrequency - 1)
        For i As Integer = 0 To lengthCache

            splitter = a(i).Split(":")

            a(i) = Trim(Replace(a(i), vbLf, ""))
            a(i) = Trim(Replace(a(i), "&", ""))
            a(i) = Trim(Replace(a(i), vbLf, ""))

            If raceIdFound AndAlso a(i).ToLower.Contains("race id") Then
                prevNameD = ""
                prevCashAm = 0D
                prevStartTime = 0D
                prevPotPercent = 0D

                calcDt.Rows.Add(dr)
                Exit For
            End If

            If a(i).ToLower.Contains("race id") Then
                If (DataGridView1.CurrentRow.Cells("race id").Value) = FMain.RemoveDelimiters(splitter(splitter.Length - 1)) Then
                    raceIdFound = True
                    dr = calcDt.NewRow()
                End If
            End If
            If raceIdFound AndAlso a(i).ToLower.Contains("cash amount") Then
                dr("CashAm") = FMain.RemoveDelimiters(splitter(splitter.Length - 1))
                'If prevCashAm = 0D Then
                prevCashAm = dr("CashAm")
                'End If
            End If
            If raceIdFound AndAlso a(i).ToLower.Contains("name") Then
                dr("NameD") = FMain.RemoveDelimiters(splitter(splitter.Length - 1))
                'If prevNameD = "" Then
                prevNameD = dr("NameD")
                'End If
            End If
            If raceIdFound AndAlso a(i).Contains("Pot percent") Then
                dr("PotPercent") = FMain.RemoveDelimiters(splitter(splitter.Length - 1))
                prevPotPercent = dr("PotPercent")
            End If

            If raceIdFound AndAlso a(i).ToLower.Contains("starting time") Then
                If FMain.RemoveDelimiters(splitter(splitter.Length - 1)).ToLower.Trim.Contains("null") Then
                    dr("StartTime") = 0
                Else
                    dr("StartTime") = FMain.RemoveDelimiters(splitter(splitter.Length - 1))
                End If

                'If prevStartTime = 0D Then
                prevStartTime = dr("StartTime")
                'End If
            End If

            If raceIdFound AndAlso a(i).ToLower.Contains("rank") AndAlso Not a(i).ToLower.Contains("ranking") Then
                dr("Rank") = CInt(FMain.RemoveDelimiters(splitter(splitter.Length - 1)))
            End If
            If raceIdFound AndAlso a(i).Contains("Points") Then
                dr("Points") = FMain.RemoveDelimiters(splitter(splitter.Length - 1))
            End If
            If raceIdFound AndAlso a(i).ToLower.Contains("sub pot percent") Then
                dr("SubPotPerc") = FMain.RemoveDelimiters(splitter(splitter.Length - 1))

                If IsDBNull(dr("NameD")) Then
                    dr("NameD") = prevNameD
                End If
                If IsDBNull(dr("CashAm")) Then
                    dr("CashAm") = prevCashAm
                End If
                If IsDBNull(dr("StartTime")) Then
                    dr("StartTime") = prevStartTime
                End If
                If IsDBNull(dr("PotPercent")) Then
                    dr("PotPercent") = prevPotPercent
                End If

                If IsDBNull(dr("NameD")) Then dr("NameD") = ""
                If IsDBNull(dr("Rank")) Then dr("Rank") = 0

                If IsDBNull(dr("CashAm")) Then dr("CashAm") = 0D
                If IsDBNull(dr("PotPercent")) Then dr("PotPercent") = 0D
                If IsDBNull(dr("SubPotPerc")) Then dr("SubPotPerc") = 0D

                dr("NameDRank") = dr("NameD") ' & "-" & dr("Rank")
                dr("CalcCash") = ManipulateCashEffect(dr("CashAm") * dr("PotPercent") / 100 * dr("SubPotPerc") / 100, lCashMathManipulation)
                orderN += 1
                dr("orderN") = orderN

                calcDt.Rows.Add(dr)
                dr = calcDt.NewRow()
            End If
        Next
        'calcDt.Rows.Add(dr)

        ''''''''''''''''''''''''''''fin


        If lHasStruct.ToLower.Trim = "false" Then
            For Each row As DataRow In ldtStart.Rows
                '  If lAwardStructureType Then
                If IsDBNull(row("hasScratch")) OrElse CBool(row("hasScratch")) = False Then
                    If IsDBNull(row("Disqualified")) OrElse CBool(row("Disqualified")) = False Then
                        row("Points") = 1
                    Else
                        row("Points") = 0 + lparticipationPoints
                    End If
                Else
                    row("Points") = 0
                End If
            Next
        End If
    End Sub
    Function ManipulateCashEffect(cash, mathManipulation) As Decimal
        'Manipulate the award money (floor, ceiling Or none).

        If (mathManipulation = "floor") Then
            Return Math.Floor(cash)
        ElseIf (mathManipulation = "ceiling") Then
            Return Math.Ceiling(cash)
        End If
        Return Math.Round(cash * 100) / 100
    End Function
    Private Function ReturnGrantFromCalc(divRank As String) As Decimal
        Dim calcSearchedRows As DataRow() = calcDt.Select("NameDRank='" & divRank & "'")
        If calcSearchedRows.Length > 0 Then
            Return CDec(calcSearchedRows(0)("CalcCash"))
        Else
            Return 0D
        End If
    End Function
    Private Function ReturnPointsFromCalc(divRank As String) As Decimal
        Dim calcSearchedRows As DataRow() = calcDt.Select("NameDRank='" & divRank & "'")
        If calcSearchedRows.Length > 0 Then
            Return CDec(NullnNothingToDecimal(calcSearchedRows(0)("Points")))
        Else
            Return 0D
        End If
    End Function
    Private Function ReturnAvgGrantForDup(divRank As String) As Decimal
        Dim total As Decimal
        Dim iter As Integer
        For Each row As DataRow In ldtStartStatic.Rows
            If row("DivisionRank").ToString = divRank Then
                total += CDec(NullnNothingToDecimal(row("Grant")))
                iter += 1
            End If
        Next
        If iter = 0 Then iter = 1
        Return total / iter
    End Function
    Private Function ReturnBiggestPointsForDup(divRank As String) As Decimal
        Dim total As Decimal

        For Each row As DataRow In ldtStartStatic.Rows
            If row("DivisionRank").ToString = divRank Then
                If total < NullnNothingToDecimal(row("CalcPoints")) Then
                    total = NullnNothingToDecimal(row("CalcPoints"))
                End If
            End If
        Next

        Return total
    End Function

    Private Sub uxResultatsButton_Click(sender As Object, e As EventArgs) Handles uxResultatsButton.Click
        If ldtStart.Rows.Count < 1 Then
            MessageBox.Show("Il n'y a rien à imprimer.")
            Exit Sub
        End If

        For Each row As DataRow In ldtStart.Rows
            row("DivisionRank") = ""
            row("Grant") = 0D
            row("Division") = ""
        Next

        'If lAwardStructureType.ToLower = "point" OrElse lAwardStructureType.ToLower = "double points" Then
        '    Dim dups = From row In ldtStart.AsEnumerable()
        '               Let country = row.Field(Of Decimal)("Points")
        '               Group row By country Into DupCountries = Group
        '               Where DupCountries.Count() > 1
        '               Select DupCountries
        '    If dups.Count > 0 Then
        '        dups = dups
        '    End If

        'ElseIf lAwardStructureType.ToLower = "ranking" Then

        'ElseIf lAwardStructureType.ToLower = "time" Then

        'End If

        calcDt.Columns.Add("NextTimeLimit", GetType(Decimal))

        Dim hTMLData = "`<!DOCTYPE html>
                <html lang = ""en"" >
                <head>
                    <meta charset=""UTF-8"">ç

                        <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                            <title>Résultats officiels : </title>
                            <style>
                        table, th, td {
                            border: 2px solid;
                            text-align: center;
                            font-size: 19px;
                            font-family: Helvetica, sans-serif;
                        }

        th{
            font - size:  24px;
                    padding 6px;
                }

                table {
                    border - collapse: collapse;
                    width: 100%;
                }

                td{
                    padding:  4px;
                    white-space: pre;
                }

                tr{
                    page - break - inside: avoid; 
                    page-break - after: auto;
                }

#tractor{
        background-color: rgb(187, 187, 187);
                    font-weight: bold;
                }

                img{
                     margin: auto;
                    display: block;
                    max-width:  60%;
                    height: auto;
                }

                h1{
                    text - align: center;
                    margin-bottom:  20px;
                    font-size:  30px;
                }

            </style>
        </head>
        <body>
            <div id = ""main"" >
            <img id = ""header image"" src=""https://s3.amazonaws.com/appforest_uf/f1662736904535x460699868596440770/image_2022-09-09_112144378.png"" width=""800"" height=""237"">
                
                <h1 style=""text-align:center""><span style=""font-size:28px""><strong>Résultats officiels : " + uxCourseActiveLabel.Text + "</strong></span></h1>
   <h1 style=""text-align:center""  </h1> 
            </div>

<table align=""center"" border=""1"" cellpadding=""0"" cellspacing=""0"" style=""width:100%"">
	<caption>
	<h1 style=""text-align:center""><span style=""font-size:18px""><strong></strong></span></h1>

	<p>&nbsp;</p>
	</caption>
	<thead>
		<tr>
			<th scope=""col"" style=""text-align: center;""><span style=""font-size:24px""><strong>Cavalier(&egrave;res)</strong></span></th>
			<th scope=""col"" style=""text-align: center;""><span style=""font-size:24px""><strong>Chevaux</strong></span></th>
			<th scope=""col"">
			<p style=""text-align:center""><span style=""font-size:24px""><strong>Dossards</strong></span></p>
			<p style=""text-align:center""><span style=""font-size:24px""><strong>(&Eacute;quipe)</strong></span></p>
			</th>

			<th scope=""col"">
			<p style=""text-align:center""><span style=""font-size:24px""><strong>Division</strong></span></p>
			<p style=""text-align:center""><span style=""font-size:24px""><strong> / Rang</strong></span></p>
			</th>"

        If lAwardStructureType.ToLower = "point" OrElse lAwardStructureType.ToLower = "double points" Then
            hTMLData += "<th scope=""col"" style=""text-align: center;""><span style=""font-size:24px""><strong>Scores</strong></span></th>"
        ElseIf lAwardStructureType.ToLower = "ranking" Then
            hTMLData += "<th scope=""col"" style=""text-align: center;""><span style=""font-size:24px""><strong>Classement</strong></span></th>"
        ElseIf lAwardStructureType.ToLower = "time" Then
            hTMLData += "<th scope=""col"" style=""text-align: center;""><span style=""font-size:24px""><strong>Temps</strong></span></th>"
        End If

        hTMLData += "<th scope=""col"" style=""text-align: center;""><span style=""font-size:24px""><strong>Bourses</strong></span></th>
			<th scope=""col"" style=""text-align: center;""><span style=""font-size:24px""><strong>Points</strong></span></th>			
		</tr>
	</thead>
	<tbody>"


        Dim dataView
        If lAwardStructureType.ToLower = "time" Then
            dataView = New DataView(ldtStart) With {
            .Sort = " TimePenalite ASC"
        }
        ElseIf lAwardStructureType.ToLower = "ranking" Then
            dataView = New DataView(ldtStart) With {
            .Sort = " Ranking ASC"
        }

        Else
            dataView = New DataView(ldtStart) With {
            .Sort = " Points Desc"
            }
        End If
        Dim dataTable As DataTable = dataView.ToTable()
        ldtStart = dataTable

        '  Dim n As Integer

        Dim isDisq As Boolean
        Dim isScratch As Boolean

        calculPointsDivGrant()

        Dim bestTime As Decimal

        Dim disqTable As DataTable
        Dim scratchTable As DataTable

        For Each row As DataRow In ldtStart.Rows 'Get Best time
            If Not IsDBNull(row("Time")) Then
                If CDec(row("Time")) > 0D Then
                    bestTime = CDec(row("Time"))
                    Exit For
                End If
            End If
        Next

        For Each row As DataRow In calcDt.Rows
            If Not IsDBNull(row("StartTime")) AndAlso CDec(row("StartTime")) > 0 Then
                row("TimeLimit") = bestTime + CDec(row("StartTime"))
            Else
                row("TimeLimit") = 0D
            End If
        Next

        Dim actualValue As Decimal
        Dim previousValue As Decimal
        Dim previousNextLimit As Decimal

        dataView = New DataView(calcDt) With {
            .Sort = " OrderN DESC"
            }

        Dim notFirstPass As Boolean
        'Dim notFirstPreVactDiff As Boolean
        For Each row As DataRowView In dataView
            If notFirstPass = False Then
                notFirstPass = True
                row("NextTimeLimit") = 99999999D
                previousNextLimit = 99999999D
                actualValue = row("TimeLimit")
                previousValue = actualValue
            Else
                actualValue = row("TimeLimit")
                If previousValue <> actualValue Then
                    row("NextTimeLimit") = previousValue
                    previousNextLimit = previousValue
                    previousValue = actualValue
                Else
                    row("NextTimeLimit") = previousNextLimit
                End If
            End If
        Next

        dataView = New DataView(calcDt) With {
            .Sort = " OrderN ASC"
            }
        Dim dataTable2 As DataTable = dataView.ToTable()
        calcDt = dataTable2
        For Each row As DataRow In calcDt.Rows
            If IsDBNull(row("OrderN")) Then
                row.Delete()
                Exit For
            End If
        Next
        calcDt.Columns.Remove("TimeLimit")

        calcDt.Columns("NextTimeLimit").ColumnName = "TimeLimit"

        'Dim curr_index As Integer

        disqTable = ldtStart.Clone
        scratchTable = ldtStart.Clone

        Dim tempTable As DataTable = ldtStart.Clone

        For Each row As DataRow In ldtStart.Rows
            If Not IsDBNull(row("Disqualified")) AndAlso CBool(row("Disqualified")) Then
                disqTable.ImportRow(row)
            ElseIf Not IsDBNull(row("Scratched")) AndAlso CBool(row("Scratched")) Then
                scratchTable.ImportRow(row)
            Else
                tempTable.ImportRow(row)
            End If
        Next
        ldtStart = tempTable

        For Each row As DataRow In disqTable.Rows 'Lets put all the disqualified at the end
            ldtStart.ImportRow(row)
        Next
        For Each row As DataRow In scratchTable.Rows 'Lets put all the scratched at the end
            ldtStart.ImportRow(row)
        Next
        '        Dim previousRankDuplicate As String = ""
        Dim previousRank As String = ""
        'Dim previousVal As Double
        Dim rankIter As Integer
        'Dim previousGrant As Decimal
        Dim previousNameD As String = ""
        For Each row As DataRow In ldtStart.Rows
            If row("Rider1 full name").ToString.ToLower.Trim <> "tracteur" Then
                If IsDBNull(row("Disqualified")) OrElse CBool(row("Disqualified")) = False Then
                    isDisq = False
                Else
                    isDisq = True
                End If
                If IsDBNull(row("hasScratch")) OrElse CBool(row("hasScratch")) = False Then
                    isScratch = False
                Else
                    isScratch = True
                End If
                If isDisq = False AndAlso isScratch = False Then
                    rankIter += 1
                End If

                If lAwardStructureType.ToLower = "time" Then
                    If isDisq = False AndAlso isScratch = False Then
                        For Each rowC As DataRow In calcDt.Rows
                            If CDec(rowC("TimeLimit")) = 0 Then
                                row("DivisionRank") = rowC("NameDRank")
                                row("Grant") = rowC("CalcCash")
                                row("CalcPoints") = rowC("Points")
                                rowC("Distributed") = True
                                Exit For
                            ElseIf Not IsDBNull(row("Time")) AndAlso CDec(row("Time")) < CDec(rowC("TimeLimit")) Then
                                If previousRank <> CStr(rowC("NameDRank")) Then
                                    previousRank = CStr(rowC("NameDRank"))
                                    rankIter = 1
                                End If
                                row("DivisionRank") = rowC("NameDRank") + "-" + CStr(rankIter)
                                Exit For
                            End If
                        Next
                    End If
                ElseIf lAwardStructureType.ToLower = "ranking" Then
                    If isDisq = False AndAlso isScratch = False Then
                        For Each rowC As DataRow In calcDt.Rows
                            If Not IsDBNull(row("Ranking")) AndAlso row("Ranking") <> "" AndAlso IsDBNull(rowC("Distributed")) Then
                                If previousNameD <> rowC("NameDRank") Then
                                    previousNameD = rowC("NameDRank")
                                    rankIter = 1
                                End If
                                row("DivisionRank") = rowC("NameDRank")
                                row("Grant") = rowC("CalcCash")
                                row("CalcPoints") = rowC("Points")
                                rowC("Distributed") = True
                                row("DivisionRank") = NullnNothingToString(rowC("NameDRank")).ToString + "-" + CStr(rankIter)
                                Exit For
                            End If
                        Next
                    End If
                Else 'Points or double points
                    If isDisq = False AndAlso isScratch = False Then
                        For Each rowC As DataRow In calcDt.Rows
                            If IsDBNull(rowC("Distributed")) Then
                                row("DivisionRank") = rowC("NameDRank")
                                row("Grant") = rowC("CalcCash")
                                row("CalcPoints") = rowC("Points")
                                rowC("Distributed") = True
                                Exit For
                            End If
                        Next
                    End If
                End If
            End If
        Next

        For Each row As DataRow In calcDt.Rows
            row("NameDRank") = NullnNothingToString(row("NameD")) + "-" + NullnNothingToString(row("Rank"))
        Next

        For Each row As DataRow In ldtStart.Rows
            row("Grant") = ReturnGrantFromCalc(NullnNothingToString(row("DivisionRank")).ToString)
        Next
        For Each row As DataRow In ldtStart.Rows
            row("CalcPoints") = ReturnGrantFromCalc(NullnNothingToString(row("DivisionRank")).ToString)
        Next

        Dim previousDivRank As String = ""
        Dim previousTimePen As Decimal
        If lAwardStructureType.ToLower <> "ranking" Then
            For Each row As DataRow In ldtStart.Rows
                If previousDivRank = "" Then
                    previousDivRank = NullnNothingToString(row("DivisionRank"))
                    previousTimePen = NullnNothingToDecimal(row("TimePenalite"))
                ElseIf previousTimePen = NullnNothingToDecimal(row("TimePenalite")) Then
                    row("DivisionRank") = previousDivRank
                End If
                previousTimePen = NullnNothingToDecimal(row("TimePenalite"))
                previousDivRank = row("DivisionRank")
            Next
        End If

        ldtStartStatic = ldtStart.Copy
        For Each row As DataRow In ldtStart.Rows
            row("Grant") = ReturnAvgGrantForDup(row("DivisionRank").ToString)
        Next
        For Each row As DataRow In ldtStart.Rows
            row("CalcPoints") = ReturnBiggestPointsForDup(row("DivisionRank").ToString)
        Next

        If lAwardStructureType.ToLower = "ranking" Then
            Dim prevRank As String = "" '1
            Dim prevDivRank As String = "" '1d-1

            For Each row As DataRow In ldtStart.Rows
                If prevDivRank = "" Then
                    prevDivRank = CStr(row("DivisionRank"))
                    prevRank = CStr(row("Ranking"))
                ElseIf prevRank = CStr(row("Ranking")) Then
                    row("DivisionRank") = prevDivRank
                End If
                prevRank = CStr(row("Ranking"))
                prevDivRank = CStr(row("DivisionRank"))
            Next
            ldtStartStatic.Clear()
            ldtStartStatic = ldtStart.Copy
            For Each row As DataRow In ldtStart.Rows
                row("Grant") = ReturnAvgGrantForDup(row("DivisionRank").ToString)
            Next
            For Each row As DataRow In ldtStart.Rows
                row("CalcPoints") = ReturnBiggestPointsForDup(row("DivisionRank").ToString)
            Next
        End If

        If lAwardStructureType.ToLower = "point" OrElse lAwardStructureType.ToLower = "double points" Then
            Dim iter As Integer
            Dim iterCalc As Integer

            For Each row As DataRow In ldtStart.Rows
                row("Ranking") = 0
                row("DivisionRank") = ""
                row("Grant") = 0
                row("CalcPoints") = 0
            Next

            For Each row As DataRow In ldtStart.Rows
                iter += 1
                iterCalc = 0
                For Each rows As DataRow In calcDt.Rows
                    iterCalc += 1
                    If iter = iterCalc Then
                        row("Ranking") = rows("Rank")
                        row("DivisionRank") = rows("NameDRank")
                        row("Grant") = rows("CalcCash")
                        row("CalcPoints") = rows("Points")

                        iterCalc = 0
                        Exit For
                    End If
                Next
            Next

            Dim prevpoints As Decimal
            Dim prevDivRa As String = ""
            For Each row As DataRow In ldtStart.Rows
                If prevDivRa = "" Then
                    prevDivRa = row("DivisionRank")
                    prevpoints = row("Points")
                ElseIf prevpoints = row("Points") Then
                    row("DivisionRank") = prevDivRa
                End If
            Next

            ldtStartStatic.Clear()
            ldtStartStatic = ldtStart.Copy
            For Each row As DataRow In ldtStart.Rows
                row("Grant") = ReturnAvgGrantForDup(row("DivisionRank").ToString)
            Next
            For Each row As DataRow In ldtStart.Rows
                row("CalcPoints") = ReturnBiggestPointsForDup(row("DivisionRank").ToString)
            Next

        End If

        For Each row As DataRow In ldtStart.Rows
            If IsDBNull(row("Disqualified")) OrElse CBool(row("Disqualified")) = False Then
                isDisq = False
            Else
                isDisq = True
            End If
            If IsDBNull(row("hasScratch")) OrElse CBool(row("hasScratch")) = False Then
                isScratch = False
            Else
                isScratch = True
            End If


            hTMLData += "
		<tr>"

            hTMLData += "<td>" + row("Rider1 full name").ToString() + " " + row("Rider2 full name").ToString() + "</td>
                                                          <td>" + row("Horse1 name").ToString() + " " + row("Horse2 name").ToString() + "</td>"

            If IsDBNull(row("BibNumber")) OrElse CStr(row("BibNumber")).Trim = "" Then
                hTMLData += "<td>&nbsp;</td>"
            Else
                hTMLData += "<td>" + row("BibNumber") + "</td>"
            End If

            If IsDBNull(row("DivisionRank")) OrElse CStr(row("DivisionRank")).Trim = "" Then
                hTMLData += "<td>&nbsp;</td>"
            Else
                hTMLData += "<td>" + row("DivisionRank") + "</td>"
            End If
            If isDisq OrElse isScratch Then
                If isDisq Then
                    hTMLData += "<td><font color="" Red"">Disqualifiée</font></td>"
                Else
                    hTMLData += "<td><font color="" Red"">Scratch</font></td>"
                End If
            Else
                If lAwardStructureType.ToLower = "point" OrElse lAwardStructureType.ToLower = "double points" Then
                    If IsDBNull(row("Points")) OrElse CStr(row("Points")).Trim = "" Then
                        hTMLData += "<td>&nbsp;</td>"
                    Else
                        hTMLData += "<td>" + CStr(row("Points")) + "</td>"
                    End If
                ElseIf lAwardStructureType.ToLower = "ranking" Then
                    If IsDBNull(row("ranking")) OrElse CStr(row("ranking")).Trim = "" Then
                        hTMLData += "<td>&nbsp;</td>"
                    Else
                        hTMLData += "<td>" + row("ranking") + "</td>"
                    End If
                ElseIf lAwardStructureType.ToLower = "time" Then
                    If IsDBNull(row("TimePenalite")) OrElse CStr(row("TimePenalite")).Trim = "" Then
                        hTMLData += "<td>&nbsp;</td>"
                    Else
                        hTMLData += "<td>" + FormatNumber(CDbl(row("TimePenalite")).ToString, 3) + "</td>"
                    End If
                End If
            End If
            If IsDBNull(row("Grant")) OrElse CStr(row("Grant")).Trim = "" Then
                hTMLData += "<td>&nbsp;</td>"
            Else
                hTMLData += "<td>" + Convert.ToDecimal(row("Grant")).ToString("c") + "</td>"
            End If

            If isDisq OrElse isScratch Then
                If isDisq Then
                    hTMLData += "<td>0</td>"
                Else
                    hTMLData += "<td>0</td>"
                End If
            Else
                If IsDBNull(row("CalcPoints")) OrElse CStr(row("CalcPoints")).Trim = "" Then
                    hTMLData += "<td>&nbsp;</td>"
                Else
                    hTMLData += "<td>" + CStr(row("CalcPoints")) + "</td>"
                End If
            End If

        Next
        hTMLData += "
	</tbody>
                                                  </table>
           </body>
           </html>`"

        File.WriteAllText(My.Computer.FileSystem.SpecialDirectories.Desktop + "\Ordre_de_passage.htm", hTMLData)

        Dim p As New Process
        p.StartInfo.UseShellExecute = True
        p.StartInfo.FileName = My.Computer.FileSystem.SpecialDirectories.Desktop + "\Ordre_de_passage.htm"
        p.Start()
    End Sub
    Public Shared Function PrepSQLVarChar(ByVal str As Object) As String
        If str Is DBNull.Value Then Return "''"
        If str Is Nothing Then Return "''"
        Return "'" & str.ToString.Replace("'", "''") & "'"
    End Function
    Public Shared Function NullnNothingToString(ByVal str As Object) As String
        If str Is DBNull.Value Then Return ""
        If str Is Nothing Then Return ""
        Return str.ToString
    End Function
    Public Shared Function NullnNothingToDecimal(ByVal str As Object) As String
        If str Is DBNull.Value Then Return 0D
        If str Is Nothing Then Return 0D
        Return CDec(str)
    End Function
End Class