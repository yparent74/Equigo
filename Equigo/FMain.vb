'Imports System.Windows.Forms
'Imports System.ComponentModel
'Imports Equigo.ClassUtilities
Public Class FMain
    Private Race_id As String
    Private Race_registration_id As String
    Private Table1 As New DataTable()
    Private bibNumber As String
    Public Shared PathJsonLabel As String
    Private awardStruct As String
    Private participation_point As Integer
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub
    Private Sub LoadGrid()
        Dim content As String = IO.File.ReadAllText(uxPathJsonLabel.Text)
        Dim a As String() = content.Split(",")

        Dim Race_title As String
        Dim Has_scratch As Boolean
        Dim Participation_point As Integer
        Dim Cash_amount As String
        Dim Has_award_Structure As String
        Dim Award_Structure_type As String
        Dim Cash_math_manipulation As String

        Dim team_type As String
        Dim positions As String = "0"
        Dim lengthCache As Integer = a.Length - 1
        Dim splitter() As String
        Dim tractor_frequency As Integer
        Dim numberOfParticipants As Integer

        Race_id = ""
        Race_title = ""
        Has_scratch = False
        Participation_point = 0
        Cash_amount = ""
        Has_award_Structure = ""
        Award_Structure_type = ""
        Cash_math_manipulation = ""
        tractor_frequency = 0
        Race_registration_id = ""
        'bibNumber = ""

        For i As Integer = 0 To lengthCache
            splitter = a(i).Split(":")

            a(i) = Trim(Replace(a(i), vbLf, ""))
            a(i) = Trim(Replace(a(i), "&", ""))
            a(i) = Trim(Replace(a(i), vbLf, ""))

            If a(i).ToLower.Contains("event title") Then
                Label1.Text = RemoveDelimiters(splitter(1))
            ElseIf a(i).ToLower.Contains("race id") Then
                Race_id = RemoveDelimiters(splitter(splitter.Length - 1))
            ElseIf a(i).ToLower.Contains("Race registration id") Then
                Race_registration_id = RemoveDelimiters(splitter(splitter.Length - 1))
            ElseIf a(i).ToLower.Contains("race title") Then
                Race_title = RemoveDelimiters(splitter(splitter.Length - 1))
            ElseIf a(i).ToLower.Contains("has scratch") Then
                Has_scratch = RemoveDelimiters(IIf(splitter(1).Trim = "true", True, False))
            ElseIf a(i).ToLower.Contains("participation_point") Then
                Participation_point = RemoveDelimiters(splitter(1))
            ElseIf a(i).ToLower.Contains("cash amount") Then
                Cash_amount = RemoveDelimiters(splitter(1))
            ElseIf a(i).ToLower.Contains("has award structure") Then
                Has_award_Structure = RemoveDelimiters(splitter(1))
            ElseIf a(i).ToLower.Contains("award structure type") Then
                Award_Structure_type = RemoveDelimiters(splitter(1))
            ElseIf a(i).ToLower.Contains("cash math manipulation") Then
                Cash_math_manipulation = RemoveDelimiters(splitter(1))
            ElseIf a(i).ToLower.Contains("tractor frequency") Then
                tractor_frequency = RemoveDelimiters(CInt(splitter(1)))
            ElseIf a(i).ToLower.Contains("Positions") Then
                Positions = RemoveDelimiters(CInt(splitter(1)))
            ElseIf a(i).ToLower.Contains("team type") Then
                Team_type = RemoveDelimiters(splitter(1))
                numberOfParticipants = CalcNShowContestantsCount()
                Table1.Rows.Add(Race_id, Race_title, Has_scratch, Participation_point, Cash_amount, Has_award_Structure, Award_Structure_type, Cash_math_manipulation, tractor_frequency, team_type, Race_registration_id, numberOfParticipants, 0) ', bibNumber)
                Race_id = ""
                Race_title = ""
                Has_scratch = False
                Participation_point = 0
                Cash_amount = ""
                Has_award_Structure = ""
                Award_Structure_type = ""
                Cash_math_manipulation = ""
                tractor_frequency = 0
                Team_type = ""
                '    bibNumber = ""
            End If
        Next

        '   Dim r = DataGridView1.TabIndex

        DataGridView1.DataSource = Table1

        DataGridView1.Columns("Race id").HeaderText = "ID de la course"
        DataGridView1.Columns("Race registration id").Visible = False
        DataGridView1.Columns("Race id").Visible = False

        DataGridView1.Columns("Participation point").HeaderText = "Point de participation"
        DataGridView1.Columns("Participation point").Visible = False

        DataGridView1.Columns("Cash amount").HeaderText = "Montant $$$"
        DataGridView1.Columns("Has award structure").HeaderText = "Structure de prix spécifiée?"
        DataGridView1.Columns("Has award structure").Visible = False

        DataGridView1.Columns("Award structure type").HeaderText = "Type de Structure de prix"
        DataGridView1.Columns("Award structure type").Visible = False

        DataGridView1.Columns("Cash math manipulation").HeaderText = "Manipulation mathématique"
        DataGridView1.Columns("Cash math manipulation").Visible = False

        'DataGridView1.Columns("bibNumber").HeaderText = "Bib #"
        'DataGridView1.Columns("bibNumber").Visible = False

        DataGridView1.Columns("Has Scratch").Visible = True

        DataGridView1.Columns("Tractor frequency").HeaderText = "Fréquence tracteur"
        DataGridView1.Columns("Team type").HeaderText = "Type d'équipe"

        DataGridView1.Columns("Race id").ReadOnly = True

        DataGridView1.Columns("Race title").MinimumWidth = 195


        If DataGridView1.Columns.Contains("Button") Then Exit Sub

        Dim buttonColumn As New DataGridViewButtonColumn With {
            .Name = "Button",
            .Text = "Modifier",
            .UseColumnTextForButtonValue = True
        }

        DataGridView1.Columns.Add(buttonColumn)

        DataGridView1.Columns("Button").DisplayIndex = 1
        DataGridView1.Columns("Button").HeaderText = "Liste des classes"

        buttonColumn.FlatStyle = FlatStyle.Flat
        buttonColumn.DefaultCellStyle.BackColor = Color.LightGray
    End Sub
    Private Function CalcNShowContestantsCount() As Integer
        Dim sline As String
        Dim thereader As New IO.StreamReader(uxPathcsvLabel.Text, System.Text.Encoding.Default)
        Dim homManyContestants As Integer
        For Each row As DataRow In Table1.Rows
            If Not IsNothing(row("Race id")) Then
                homManyContestants = 0
                thereader.Close()
                thereader = New IO.StreamReader(uxPathcsvLabel.Text, System.Text.Encoding.Default)
                Do
                    sline = thereader.ReadLine
                    If sline Is Nothing Then Exit Do

                    Dim thecolumns() As String = sline.Split(",")

                    If row("Race id") = thecolumns(1) Then
                        homManyContestants += 1
                    End If
                Loop

            End If
            row("Nombre de participants") = homManyContestants
        Next row
        Return homManyContestants
    End Function
    Public Shared Function RemoveDelimiters(toRemove As String) As String
        toRemove = toRemove.Trim
        Do While toRemove.StartsWith("\") OrElse toRemove.StartsWith("""") OrElse toRemove.StartsWith(" ") OrElse toRemove.StartsWith("&") OrElse toRemove.StartsWith(vbLf) OrElse toRemove.StartsWith("{")
            toRemove = toRemove.Remove(0, 1)
        Loop
        Do While toRemove.EndsWith(vbLf) OrElse toRemove.EndsWith(vbCrLf) OrElse toRemove.EndsWith(" \ ") OrElse toRemove.EndsWith("""") OrElse toRemove.EndsWith(" ") OrElse toRemove.EndsWith("}") OrElse toRemove.EndsWith("\n") OrElse toRemove.EndsWith("]")
            toRemove = Trim(toRemove.Remove(toRemove.Length - 1, 1))
        Loop
        Return toRemove
    End Function
    Private Sub SearchJsonButton_Click(sender As Object, e As EventArgs) Handles SearchJsonButton.Click
        OpenFileDialogJson.FileName = ""
        Dim result As DialogResult = OpenFileDialogJson.ShowDialog()

        If result = Windows.Forms.DialogResult.OK Then
            uxPathJsonLabel.Text = OpenFileDialogJson.FileName

            '  loadGrid()
            If uxPathcsvLabel.Text <> "Veuillez cliquez sur le bouton pour sélectionner l'emplacement du fichier csv" Then
                LoadGrid()
            End If
        Else
            uxPathJsonLabel.Text = "Veuillez cliquez sur le bouton pour sélectionner l'emplacement du fichier json"
            DataGridView1.DataSource = Nothing
        End If
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles SearchCsvButton.Click
        OpenFileDialogcsv.FileName = ""
        Dim result As DialogResult = OpenFileDialogcsv.ShowDialog()
        If result = Windows.Forms.DialogResult.OK Then
            uxPathcsvLabel.Text = OpenFileDialogcsv.FileName
            If uxPathJsonLabel.Text <> "Veuillez cliquez sur le bouton pour sélectionner l'emplacement du fichier json" Then
                LoadGrid()
            End If
        Else
            uxPathcsvLabel.Text = "Veuillez cliquez sur le bouton pour sélectionner l'emplacement du fichier csv"
            DataGridView1.DataSource = Nothing
        End If
    End Sub
    Private Sub SearchCsv(raceIdToSearch As String, tractorFrequency As String, hasScratch As String, Award_structure_type As String, cashMani As String, hasStruct As String, Participation_point As Integer)
        Dim thereader As New IO.StreamReader(uxPathcsvLabel.Text, System.Text.Encoding.Default)
        Dim db As New DataTable
        With db
            .Columns.Add("Race id", System.Type.GetType("System.String"))
            .Columns.Add("Rider1 full name", System.Type.GetType("System.String"))
            .Columns.Add("Horse1 name", System.Type.GetType("System.String"))
            .Columns.Add("Rider2 full name", System.Type.GetType("System.String"))
            .Columns.Add("Horse2 name", System.Type.GetType("System.String"))
            .Columns.Add("Position", System.Type.GetType("System.Decimal"))
            .Columns.Add("Race registration id", System.Type.GetType("System.String"))
            .Columns.Add("BibNumber", System.Type.GetType("System.String"))

        End With
        Dim sline As String = ""

        Dim selectedRaceName As String = ""
        Dim foundInCSV As Boolean
        Do
            sline = thereader.ReadLine
            If sline Is Nothing Then Exit Do

            Dim thecolumns() As String = sline.Split(",")
            Dim newrow As DataRow = db.NewRow
            If raceIdToSearch = thecolumns(1) Then
                awardStruct = thecolumns(3)
                foundInCSV = True
                selectedRaceName = thecolumns(0)
                newrow("Race id") = thecolumns(1)
                newrow("Horse1 name") = thecolumns(9)
                newrow("Horse2 name") = thecolumns(10)
                newrow("Rider1 full name") = thecolumns(11)
                newrow("Rider2 full name") = thecolumns(12)
                newrow("Position") = thecolumns(8)
                newrow("Race registration id") = thecolumns(4)
                newrow("BibNumber") = thecolumns(13)
                db.Rows.Add(newrow)
            End If
        Loop
        If foundInCSV = False Then
            MessageBox.Show("Il n'y a aucune inscription dans cette course.")
            Exit Sub
        End If
        ActiveRace.ldt = db
        ActiveRace.ldtStart = db.Copy
        Dim hascratch As Boolean
        If hasScratch <> "False" Then
            hascratch = True
        End If
        PathJsonLabel = uxPathJsonLabel.Text
        Dim objForm As New ActiveRace(selectedRaceName, tractorFrequency, hascratch, awardStruct, cashMani, hasStruct, Participation_point, uxPathJsonLabel.Text)
        objForm.ShowDialog()
    End Sub
    Private Sub FMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BackColor = System.Drawing.ColorTranslator.FromHtml("#2596be")


        SearchJsonButton.BackColor = System.Drawing.ColorTranslator.FromHtml("#ebecf0")
        SearchCsvButton.BackColor = System.Drawing.ColorTranslator.FromHtml("#ebecf0")

        Table1.Columns.Add("Race id", GetType(String))

        Table1.Columns.Add("Race title", GetType(String))

        Table1.Columns.Add("Has scratch", GetType(Boolean))
        Table1.Columns.Add("Participation point", GetType(Int32))
        Table1.Columns.Add("Cash amount", GetType(String))
        Table1.Columns.Add("Has award structure", GetType(String))
        Table1.Columns.Add("Award structure type", GetType(String))
        Table1.Columns.Add("Cash math manipulation", GetType(String))
        Table1.Columns.Add("Tractor frequency", GetType(Int32))
        Table1.Columns.Add("Team type", GetType(String))
        Table1.Columns.Add("Race registration id", GetType(String))
        Table1.Columns.Add("Nombre de participants", GetType(String))
        Table1.Columns.Add("dStartingTime", GetType(Decimal))
        'Table1.Columns.Add("bibNumber", GetType(String))

        Label1.Text = ""
        uxPathcsvLabel.Text = "C:\ee\Test offline avec Yan.csv"
        uxPathJsonLabel.Text = "C:\ee\Test offline avec Yan.JSON"
        LoadGrid()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If Not IsNothing(DataGridView1.CurrentRow) Then
            If uxPathcsvLabel.Text = "Veuillez cliquez sur le bouton pour sélectionner l'emplacement du fichier csv" Then
                MessageBox.Show("Sélectionnez d'abord le fichier csv")
                Exit Sub
            End If
            If DataGridView1.CurrentCell.OwningColumn.Name = "Button" Then
                SearchCsv(DataGridView1.CurrentRow.Cells(0).Value.ToString, DataGridView1.CurrentRow.Cells("Tractor frequency").Value.ToString, DataGridView1.CurrentRow.Cells("Has scratch").Value.ToString, DataGridView1.CurrentRow.Cells("Award structure type").Value.ToString, DataGridView1.CurrentRow.Cells("Cash math manipulation").Value.ToString, DataGridView1.CurrentRow.Cells("Has award Structure").Value.ToString, CInt(DataGridView1.CurrentRow.Cells("Participation point").Value.ToString))
            End If
        End If
    End Sub
End Class