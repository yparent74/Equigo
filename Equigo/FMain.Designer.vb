<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FMain))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.OpenFileDialogJson = New System.Windows.Forms.OpenFileDialog()
        Me.OpenFileDialogcsv = New System.Windows.Forms.OpenFileDialog()
        Me.uxPathJsonLabel = New System.Windows.Forms.Label()
        Me.uxPathcsvLabel = New System.Windows.Forms.Label()
        Me.SearchJsonButton = New System.Windows.Forms.Button()
        Me.SearchCsvButton = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(273, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(102, 38)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Label1"
        '
        'OpenFileDialogJson
        '
        Me.OpenFileDialogJson.DefaultExt = "json"
        Me.OpenFileDialogJson.Filter = """Json files (*.json)|*.json|Text files (*.txt)|*.txt"""
        '
        'OpenFileDialogcsv
        '
        Me.OpenFileDialogcsv.FileName = "OpenFileDialogcsv"
        Me.OpenFileDialogcsv.Filter = """csv files (*.csv)|*.csv|Text files (*.txt)|*.txt"""
        '
        'uxPathJsonLabel
        '
        Me.uxPathJsonLabel.AutoSize = True
        Me.uxPathJsonLabel.BackColor = System.Drawing.Color.Transparent
        Me.uxPathJsonLabel.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.uxPathJsonLabel.ForeColor = System.Drawing.Color.White
        Me.uxPathJsonLabel.Location = New System.Drawing.Point(25, 46)
        Me.uxPathJsonLabel.Name = "uxPathJsonLabel"
        Me.uxPathJsonLabel.Size = New System.Drawing.Size(600, 23)
        Me.uxPathJsonLabel.TabIndex = 3
        Me.uxPathJsonLabel.Text = "Veuillez cliquez sur le bouton pour sélectionner l'emplacement du fichier json"
        '
        'uxPathcsvLabel
        '
        Me.uxPathcsvLabel.AutoSize = True
        Me.uxPathcsvLabel.BackColor = System.Drawing.Color.Transparent
        Me.uxPathcsvLabel.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.uxPathcsvLabel.ForeColor = System.Drawing.Color.White
        Me.uxPathcsvLabel.Location = New System.Drawing.Point(25, 83)
        Me.uxPathcsvLabel.Name = "uxPathcsvLabel"
        Me.uxPathcsvLabel.Size = New System.Drawing.Size(592, 23)
        Me.uxPathcsvLabel.TabIndex = 4
        Me.uxPathcsvLabel.Text = "Veuillez cliquez sur le bouton pour sélectionner l'emplacement du fichier csv"
        '
        'SearchJsonButton
        '
        Me.SearchJsonButton.BackColor = System.Drawing.Color.Transparent
        Me.SearchJsonButton.Location = New System.Drawing.Point(631, 44)
        Me.SearchJsonButton.Name = "SearchJsonButton"
        Me.SearchJsonButton.Size = New System.Drawing.Size(203, 29)
        Me.SearchJsonButton.TabIndex = 5
        Me.SearchJsonButton.Text = "Parcourir emplacement json"
        Me.SearchJsonButton.UseVisualStyleBackColor = False
        '
        'SearchCsvButton
        '
        Me.SearchCsvButton.BackColor = System.Drawing.Color.Transparent
        Me.SearchCsvButton.Location = New System.Drawing.Point(631, 79)
        Me.SearchCsvButton.Name = "SearchCsvButton"
        Me.SearchCsvButton.Size = New System.Drawing.Size(203, 29)
        Me.SearchCsvButton.TabIndex = 6
        Me.SearchCsvButton.Text = "Parcourir emplacement csv"
        Me.SearchCsvButton.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(840, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(436, 116)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 10
        Me.PictureBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(-1, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(191, 20)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Version du 3 avril 2023 # 43"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(12, 128)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.RowTemplate.Height = 29
        Me.DataGridView1.Size = New System.Drawing.Size(1458, 558)
        Me.DataGridView1.TabIndex = 15
        '
        'FMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Cyan
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(1482, 698)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.SearchCsvButton)
        Me.Controls.Add(Me.SearchJsonButton)
        Me.Controls.Add(Me.uxPathcsvLabel)
        Me.Controls.Add(Me.uxPathJsonLabel)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(1500, 745)
        Me.Name = "FMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Equi-Go"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents OpenFileDialogJson As OpenFileDialog
    Friend WithEvents OpenFileDialogcsv As OpenFileDialog
    Friend WithEvents uxPathJsonLabel As Label
    Friend WithEvents uxPathcsvLabel As Label
    Friend WithEvents SearchJsonButton As Button
    Friend WithEvents SearchCsvButton As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents DataGridView1 As DataGridView
End Class
