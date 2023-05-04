Imports Newtonsoft.Json.Linq
Imports Equigo.ActiveRace
Public Class FResults
    Private Award_structure_type As String
    Private HasAwardStructure As String
    Private lActiveRaceTitle As String
    Public Sub New(ActiveRaceTitle As String)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        lActiveRaceTitle = ActiveRaceTitle
    End Sub
    Private Sub FResults_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim fileReader As String

        fileReader = My.Computer.FileSystem.ReadAllText(FMain.PathJsonLabel)
        uxActiveRaceTitleLabel.Text = lActiveRaceTitle

        Dim a = Split(fileReader, ldt(0)("Race id"))
        Dim b = Split(a(1), "Race id")
        Dim activeRace As String = b(0)
        Award_structure_type = activeRace.Substring(activeRace.IndexOf("Award structure type") + 22, 100)
        Award_structure_type = Award_structure_type.Substring(2, Award_structure_type.IndexOf(vbLf) - 4)
        uxStructureDePrixLabel.Text = Award_structure_type

        ldt.DefaultView.Sort = "TimePenalite"
        ldt = ldt.DefaultView.ToTable()

        Dim ResultsDt As New DataTable
        HasAwardStructure = activeRace.Substring(activeRace.IndexOf("Has award structure") + 22, 100)
        HasAwardStructure = HasAwardStructure.Substring(0, HasAwardStructure.IndexOf(","))

        ResultsDt = ldt
        ldt.Columns.Remove("Race Id")
        ldt.Columns.Remove("Time")
        ldt.Columns.Remove("Penalite")
        ldt.Columns.Remove("hasScratch")

        If HasAwardStructure.ToLower.Contains("false") Then
            ldt.Columns.Remove("Race Registration Id")
        End If

        uxDataGridView1.DataSource = ResultsDt



        uxDataGridView1.Columns("TimePenalite").HeaderText = "Temps total"

        uxDataGridView1.Columns("Horse1 name").HeaderText = "Nom du premier cheval"
        uxDataGridView1.Columns("Horse2 name").HeaderText = "Nom du deuxième cheval"
        uxDataGridView1.Columns("Rider1 full name").HeaderText = "Nom du premier cavalier"
        uxDataGridView1.Columns("Rider2 full name").HeaderText = "Nom du deuxième cavalier"
        uxDataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
        'Else
        '    MessageBox.Show("")
        'End If
    End Sub
End Class