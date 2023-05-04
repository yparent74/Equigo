<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ActiveRace
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ActiveRace))
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.uxCourseActiveLabel = New System.Windows.Forms.Label()
        Me.uxOrdreDePassageButton = New System.Windows.Forms.Button()
        Me.uxStartRaceButton = New System.Windows.Forms.Button()
        Me.DataGridViewStartUpRace = New System.Windows.Forms.DataGridView()
        Me.uxRetourClassesButton = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.UxResultsButton = New System.Windows.Forms.Button()
        Me.uxResultatsButton = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridViewStartUpRace, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeight = 29
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DataGridView1.Location = New System.Drawing.Point(12, 228)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.RowTemplate.Height = 29
        Me.DataGridView1.Size = New System.Drawing.Size(830, 614)
        Me.DataGridView1.TabIndex = 0
        '
        'uxCourseActiveLabel
        '
        Me.uxCourseActiveLabel.AutoSize = True
        Me.uxCourseActiveLabel.BackColor = System.Drawing.Color.Transparent
        Me.uxCourseActiveLabel.Font = New System.Drawing.Font("Segoe UI", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.uxCourseActiveLabel.Location = New System.Drawing.Point(12, 14)
        Me.uxCourseActiveLabel.Name = "uxCourseActiveLabel"
        Me.uxCourseActiveLabel.Size = New System.Drawing.Size(243, 38)
        Me.uxCourseActiveLabel.TabIndex = 3
        Me.uxCourseActiveLabel.Text = "Ordre de passage"
        '
        'uxOrdreDePassageButton
        '
        Me.uxOrdreDePassageButton.BackColor = System.Drawing.Color.Transparent
        Me.uxOrdreDePassageButton.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.uxOrdreDePassageButton.Location = New System.Drawing.Point(1313, 68)
        Me.uxOrdreDePassageButton.Name = "uxOrdreDePassageButton"
        Me.uxOrdreDePassageButton.Size = New System.Drawing.Size(157, 29)
        Me.uxOrdreDePassageButton.TabIndex = 4
        Me.uxOrdreDePassageButton.Text = "Ordre de passage"
        Me.uxOrdreDePassageButton.UseVisualStyleBackColor = False
        '
        'uxStartRaceButton
        '
        Me.uxStartRaceButton.BackColor = System.Drawing.Color.Transparent
        Me.uxStartRaceButton.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.uxStartRaceButton.Location = New System.Drawing.Point(1121, 23)
        Me.uxStartRaceButton.Name = "uxStartRaceButton"
        Me.uxStartRaceButton.Size = New System.Drawing.Size(157, 29)
        Me.uxStartRaceButton.TabIndex = 5
        Me.uxStartRaceButton.Text = "Démarrer la course"
        Me.uxStartRaceButton.UseVisualStyleBackColor = False
        '
        'DataGridViewStartUpRace
        '
        Me.DataGridViewStartUpRace.ColumnHeadersHeight = 29
        Me.DataGridViewStartUpRace.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DataGridViewStartUpRace.Location = New System.Drawing.Point(852, 228)
        Me.DataGridViewStartUpRace.Name = "DataGridViewStartUpRace"
        Me.DataGridViewStartUpRace.ReadOnly = True
        Me.DataGridViewStartUpRace.RowHeadersWidth = 51
        Me.DataGridViewStartUpRace.RowTemplate.Height = 29
        Me.DataGridViewStartUpRace.Size = New System.Drawing.Size(618, 614)
        Me.DataGridViewStartUpRace.TabIndex = 6
        '
        'uxRetourClassesButton
        '
        Me.uxRetourClassesButton.BackColor = System.Drawing.Color.Transparent
        Me.uxRetourClassesButton.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.uxRetourClassesButton.Location = New System.Drawing.Point(1313, 23)
        Me.uxRetourClassesButton.Name = "uxRetourClassesButton"
        Me.uxRetourClassesButton.Size = New System.Drawing.Size(157, 29)
        Me.uxRetourClassesButton.TabIndex = 7
        Me.uxRetourClassesButton.Text = "Retour aux classes"
        Me.uxRetourClassesButton.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.Label2.Location = New System.Drawing.Point(750, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(135, 38)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Résultats"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(270, 58)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(879, 151)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 9
        Me.PictureBox1.TabStop = False
        '
        'UxResultsButton
        '
        Me.UxResultsButton.BackColor = System.Drawing.Color.Transparent
        Me.UxResultsButton.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.UxResultsButton.Location = New System.Drawing.Point(1155, 193)
        Me.UxResultsButton.Name = "UxResultsButton"
        Me.UxResultsButton.Size = New System.Drawing.Size(157, 29)
        Me.UxResultsButton.TabIndex = 11
        Me.UxResultsButton.Text = "Voir les résultats"
        Me.UxResultsButton.UseVisualStyleBackColor = False
        Me.UxResultsButton.Visible = False
        '
        'uxResultatsButton
        '
        Me.uxResultatsButton.BackColor = System.Drawing.Color.Transparent
        Me.uxResultatsButton.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.uxResultatsButton.Location = New System.Drawing.Point(1313, 103)
        Me.uxResultatsButton.Name = "uxResultatsButton"
        Me.uxResultatsButton.Size = New System.Drawing.Size(157, 29)
        Me.uxResultatsButton.TabIndex = 12
        Me.uxResultatsButton.Text = "Résultats"
        Me.uxResultatsButton.UseVisualStyleBackColor = False
        '
        'ActiveRace
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(1482, 853)
        Me.Controls.Add(Me.uxResultatsButton)
        Me.Controls.Add(Me.UxResultsButton)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.uxRetourClassesButton)
        Me.Controls.Add(Me.DataGridViewStartUpRace)
        Me.Controls.Add(Me.uxStartRaceButton)
        Me.Controls.Add(Me.uxOrdreDePassageButton)
        Me.Controls.Add(Me.uxCourseActiveLabel)
        Me.Controls.Add(Me.DataGridView1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ActiveRace"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Course active"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridViewStartUpRace, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents uxCourseActiveLabel As Label
    Friend WithEvents uxOrdreDePassageButton As Button
    Friend WithEvents uxResultatsButton As Button
    Friend WithEvents DataGridViewStartUpRace As DataGridView
    Friend WithEvents uxStartRaceButton As Button
    Friend WithEvents uxRetourClassesButton As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents UxResultsButton As Button
End Class
