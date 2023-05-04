<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FTimeRecorder
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FTimeRecorder))
        Me.uxNomDeCourseLabel = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.uxHorse2Label = New System.Windows.Forms.Label()
        Me.uxRider2Label = New System.Windows.Forms.Label()
        Me.uxHorse1Label = New System.Windows.Forms.Label()
        Me.uxRider1Label = New System.Windows.Forms.Label()
        Me.uxPositionLabel = New System.Windows.Forms.Label()
        Me.uxTempsLabel = New System.Windows.Forms.Label()
        Me.uxTempsTextBox = New System.Windows.Forms.TextBox()
        Me.uxPenaliteTextBox = New System.Windows.Forms.TextBox()
        Me.uxTempsPenaliteLabel = New System.Windows.Forms.Label()
        Me.uxPrecedentButton = New System.Windows.Forms.Button()
        Me.uxSuivantButton = New System.Windows.Forms.Button()
        Me.uxDisqualifierButton = New System.Windows.Forms.Button()
        Me.uxScratchButton = New System.Windows.Forms.Button()
        Me.uxTerminerButton = New System.Windows.Forms.Button()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.uxTeamHasBeenDisqLabel = New System.Windows.Forms.Label()
        Me.uxTeamHasBeenScratchedLabel = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'uxNomDeCourseLabel
        '
        Me.uxNomDeCourseLabel.BackColor = System.Drawing.Color.Transparent
        Me.uxNomDeCourseLabel.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.uxNomDeCourseLabel.Location = New System.Drawing.Point(9, 103)
        Me.uxNomDeCourseLabel.Name = "uxNomDeCourseLabel"
        Me.uxNomDeCourseLabel.Size = New System.Drawing.Size(302, 32)
        Me.uxNomDeCourseLabel.TabIndex = 4
        Me.uxNomDeCourseLabel.Text = "Équipe en cours"
        Me.uxNomDeCourseLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.uxHorse2Label)
        Me.Panel1.Controls.Add(Me.uxRider2Label)
        Me.Panel1.Controls.Add(Me.uxHorse1Label)
        Me.Panel1.Controls.Add(Me.uxRider1Label)
        Me.Panel1.Controls.Add(Me.uxPositionLabel)
        Me.Panel1.Location = New System.Drawing.Point(9, 164)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(305, 125)
        Me.Panel1.TabIndex = 5
        '
        'uxHorse2Label
        '
        Me.uxHorse2Label.AutoSize = True
        Me.uxHorse2Label.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.uxHorse2Label.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.uxHorse2Label.Location = New System.Drawing.Point(80, 96)
        Me.uxHorse2Label.Name = "uxHorse2Label"
        Me.uxHorse2Label.Size = New System.Drawing.Size(59, 20)
        Me.uxHorse2Label.TabIndex = 4
        Me.uxHorse2Label.Text = "Horse2"
        '
        'uxRider2Label
        '
        Me.uxRider2Label.AutoSize = True
        Me.uxRider2Label.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.uxRider2Label.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.uxRider2Label.Location = New System.Drawing.Point(80, 66)
        Me.uxRider2Label.Name = "uxRider2Label"
        Me.uxRider2Label.Size = New System.Drawing.Size(55, 20)
        Me.uxRider2Label.TabIndex = 3
        Me.uxRider2Label.Text = "Rider2"
        '
        'uxHorse1Label
        '
        Me.uxHorse1Label.AutoSize = True
        Me.uxHorse1Label.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.uxHorse1Label.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.uxHorse1Label.Location = New System.Drawing.Point(80, 33)
        Me.uxHorse1Label.Name = "uxHorse1Label"
        Me.uxHorse1Label.Size = New System.Drawing.Size(59, 20)
        Me.uxHorse1Label.TabIndex = 2
        Me.uxHorse1Label.Text = "Horse1"
        '
        'uxRider1Label
        '
        Me.uxRider1Label.AutoSize = True
        Me.uxRider1Label.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.uxRider1Label.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.uxRider1Label.Location = New System.Drawing.Point(80, 3)
        Me.uxRider1Label.Name = "uxRider1Label"
        Me.uxRider1Label.Size = New System.Drawing.Size(55, 20)
        Me.uxRider1Label.TabIndex = 1
        Me.uxRider1Label.Text = "Rider1"
        '
        'uxPositionLabel
        '
        Me.uxPositionLabel.AutoSize = True
        Me.uxPositionLabel.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.uxPositionLabel.ForeColor = System.Drawing.Color.DeepSkyBlue
        Me.uxPositionLabel.Location = New System.Drawing.Point(8, 3)
        Me.uxPositionLabel.Name = "uxPositionLabel"
        Me.uxPositionLabel.Size = New System.Drawing.Size(66, 20)
        Me.uxPositionLabel.TabIndex = 0
        Me.uxPositionLabel.Text = "Position"
        '
        'uxTempsLabel
        '
        Me.uxTempsLabel.AutoSize = True
        Me.uxTempsLabel.BackColor = System.Drawing.Color.Transparent
        Me.uxTempsLabel.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.uxTempsLabel.Location = New System.Drawing.Point(24, 312)
        Me.uxTempsLabel.Name = "uxTempsLabel"
        Me.uxTempsLabel.Size = New System.Drawing.Size(77, 28)
        Me.uxTempsLabel.TabIndex = 6
        Me.uxTempsLabel.Text = "Temps:"
        '
        'uxTempsTextBox
        '
        Me.uxTempsTextBox.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.uxTempsTextBox.Location = New System.Drawing.Point(107, 309)
        Me.uxTempsTextBox.Name = "uxTempsTextBox"
        Me.uxTempsTextBox.Size = New System.Drawing.Size(206, 34)
        Me.uxTempsTextBox.TabIndex = 7
        '
        'uxPenaliteTextBox
        '
        Me.uxPenaliteTextBox.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.uxPenaliteTextBox.Location = New System.Drawing.Point(107, 361)
        Me.uxPenaliteTextBox.Name = "uxPenaliteTextBox"
        Me.uxPenaliteTextBox.Size = New System.Drawing.Size(206, 34)
        Me.uxPenaliteTextBox.TabIndex = 9
        '
        'uxTempsPenaliteLabel
        '
        Me.uxTempsPenaliteLabel.AutoSize = True
        Me.uxTempsPenaliteLabel.BackColor = System.Drawing.Color.Transparent
        Me.uxTempsPenaliteLabel.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.uxTempsPenaliteLabel.Location = New System.Drawing.Point(8, 361)
        Me.uxTempsPenaliteLabel.Name = "uxTempsPenaliteLabel"
        Me.uxTempsPenaliteLabel.Size = New System.Drawing.Size(93, 28)
        Me.uxTempsPenaliteLabel.TabIndex = 8
        Me.uxTempsPenaliteLabel.Text = "Pénalité:"
        '
        'uxPrecedentButton
        '
        Me.uxPrecedentButton.BackColor = System.Drawing.Color.Transparent
        Me.uxPrecedentButton.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.uxPrecedentButton.Location = New System.Drawing.Point(9, 499)
        Me.uxPrecedentButton.Name = "uxPrecedentButton"
        Me.uxPrecedentButton.Size = New System.Drawing.Size(150, 38)
        Me.uxPrecedentButton.TabIndex = 10
        Me.uxPrecedentButton.Text = "Précédent"
        Me.uxPrecedentButton.UseVisualStyleBackColor = False
        '
        'uxSuivantButton
        '
        Me.uxSuivantButton.BackColor = System.Drawing.Color.Transparent
        Me.uxSuivantButton.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.uxSuivantButton.Location = New System.Drawing.Point(163, 499)
        Me.uxSuivantButton.Name = "uxSuivantButton"
        Me.uxSuivantButton.Size = New System.Drawing.Size(150, 38)
        Me.uxSuivantButton.TabIndex = 11
        Me.uxSuivantButton.Text = "Suivant"
        Me.uxSuivantButton.UseVisualStyleBackColor = False
        '
        'uxDisqualifierButton
        '
        Me.uxDisqualifierButton.BackColor = System.Drawing.Color.Red
        Me.uxDisqualifierButton.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.uxDisqualifierButton.ForeColor = System.Drawing.Color.White
        Me.uxDisqualifierButton.Location = New System.Drawing.Point(9, 401)
        Me.uxDisqualifierButton.Name = "uxDisqualifierButton"
        Me.uxDisqualifierButton.Size = New System.Drawing.Size(305, 43)
        Me.uxDisqualifierButton.TabIndex = 12
        Me.uxDisqualifierButton.Text = "Disqualifier (1 point)"
        Me.uxDisqualifierButton.UseVisualStyleBackColor = False
        '
        'uxScratchButton
        '
        Me.uxScratchButton.BackColor = System.Drawing.Color.Red
        Me.uxScratchButton.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.uxScratchButton.ForeColor = System.Drawing.Color.White
        Me.uxScratchButton.Location = New System.Drawing.Point(9, 450)
        Me.uxScratchButton.Name = "uxScratchButton"
        Me.uxScratchButton.Size = New System.Drawing.Size(305, 43)
        Me.uxScratchButton.TabIndex = 13
        Me.uxScratchButton.Text = "Scratch"
        Me.uxScratchButton.UseVisualStyleBackColor = False
        '
        'uxTerminerButton
        '
        Me.uxTerminerButton.BackColor = System.Drawing.Color.Transparent
        Me.uxTerminerButton.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.uxTerminerButton.Location = New System.Drawing.Point(7, 543)
        Me.uxTerminerButton.Name = "uxTerminerButton"
        Me.uxTerminerButton.Size = New System.Drawing.Size(304, 38)
        Me.uxTerminerButton.TabIndex = 14
        Me.uxTerminerButton.Text = "Terminer"
        Me.uxTerminerButton.UseVisualStyleBackColor = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(33, 4)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(268, 96)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 16
        Me.PictureBox2.TabStop = False
        '
        'uxTeamHasBeenDisqLabel
        '
        Me.uxTeamHasBeenDisqLabel.BackColor = System.Drawing.Color.Transparent
        Me.uxTeamHasBeenDisqLabel.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.uxTeamHasBeenDisqLabel.Location = New System.Drawing.Point(8, 138)
        Me.uxTeamHasBeenDisqLabel.Name = "uxTeamHasBeenDisqLabel"
        Me.uxTeamHasBeenDisqLabel.Size = New System.Drawing.Size(302, 23)
        Me.uxTeamHasBeenDisqLabel.TabIndex = 17
        Me.uxTeamHasBeenDisqLabel.Text = "Cette Équipe a été disqualifiée"
        Me.uxTeamHasBeenDisqLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.uxTeamHasBeenDisqLabel.Visible = False
        '
        'uxTeamHasBeenScratchedLabel
        '
        Me.uxTeamHasBeenScratchedLabel.BackColor = System.Drawing.Color.Transparent
        Me.uxTeamHasBeenScratchedLabel.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.uxTeamHasBeenScratchedLabel.Location = New System.Drawing.Point(7, 138)
        Me.uxTeamHasBeenScratchedLabel.Name = "uxTeamHasBeenScratchedLabel"
        Me.uxTeamHasBeenScratchedLabel.Size = New System.Drawing.Size(302, 23)
        Me.uxTeamHasBeenScratchedLabel.TabIndex = 18
        Me.uxTeamHasBeenScratchedLabel.Text = "Cette Équipe a été ""scratchée"""
        Me.uxTeamHasBeenScratchedLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.uxTeamHasBeenScratchedLabel.Visible = False
        '
        'FTimeRecorder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(329, 590)
        Me.Controls.Add(Me.uxTeamHasBeenScratchedLabel)
        Me.Controls.Add(Me.uxTeamHasBeenDisqLabel)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.uxTerminerButton)
        Me.Controls.Add(Me.uxScratchButton)
        Me.Controls.Add(Me.uxDisqualifierButton)
        Me.Controls.Add(Me.uxSuivantButton)
        Me.Controls.Add(Me.uxPrecedentButton)
        Me.Controls.Add(Me.uxPenaliteTextBox)
        Me.Controls.Add(Me.uxTempsPenaliteLabel)
        Me.Controls.Add(Me.uxTempsTextBox)
        Me.Controls.Add(Me.uxTempsLabel)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.uxNomDeCourseLabel)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(547, 923)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(347, 523)
        Me.Name = "FTimeRecorder"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Équi-Go"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents uxNomDeCourseLabel As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents uxPositionLabel As Label
    Friend WithEvents uxTempsLabel As Label
    Friend WithEvents uxTempsTextBox As TextBox
    Friend WithEvents uxPenaliteTextBox As TextBox
    Friend WithEvents uxTempsPenaliteLabel As Label
    Friend WithEvents uxPrecedentButton As Button
    Friend WithEvents uxSuivantButton As Button
    Friend WithEvents uxDisqualifierButton As Button
    Friend WithEvents uxScratchButton As Button
    Friend WithEvents uxHorse1Label As Label
    Friend WithEvents uxRider1Label As Label
    Friend WithEvents uxHorse2Label As Label
    Friend WithEvents uxRider2Label As Label
    Friend WithEvents uxTerminerButton As Button
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents uxTeamHasBeenDisqLabel As Label
    Friend WithEvents uxTeamHasBeenScratchedLabel As Label
End Class
