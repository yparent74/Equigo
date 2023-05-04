<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FResults
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.uxActiveRaceTitleLabel = New System.Windows.Forms.Label()
        Me.uxDataGridView1 = New System.Windows.Forms.DataGridView()
        Me.uxStructureDePrixLabel = New System.Windows.Forms.Label()
        CType(Me.uxDataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'uxActiveRaceTitleLabel
        '
        Me.uxActiveRaceTitleLabel.Font = New System.Drawing.Font("Segoe UI", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.uxActiveRaceTitleLabel.Location = New System.Drawing.Point(-1, 0)
        Me.uxActiveRaceTitleLabel.Name = "uxActiveRaceTitleLabel"
        Me.uxActiveRaceTitleLabel.Size = New System.Drawing.Size(1483, 48)
        Me.uxActiveRaceTitleLabel.TabIndex = 9
        Me.uxActiveRaceTitleLabel.Text = "Le nom de cette course"
        Me.uxActiveRaceTitleLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'uxDataGridView1
        '
        Me.uxDataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.uxDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.uxDataGridView1.DefaultCellStyle = DataGridViewCellStyle1
        Me.uxDataGridView1.Location = New System.Drawing.Point(12, 120)
        Me.uxDataGridView1.Name = "uxDataGridView1"
        Me.uxDataGridView1.RowHeadersWidth = 51
        Me.uxDataGridView1.RowTemplate.Height = 29
        Me.uxDataGridView1.Size = New System.Drawing.Size(1458, 667)
        Me.uxDataGridView1.TabIndex = 10
        '
        'uxStructureDePrixLabel
        '
        Me.uxStructureDePrixLabel.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.uxStructureDePrixLabel.Location = New System.Drawing.Point(-1, 48)
        Me.uxStructureDePrixLabel.Name = "uxStructureDePrixLabel"
        Me.uxStructureDePrixLabel.Size = New System.Drawing.Size(1483, 33)
        Me.uxStructureDePrixLabel.TabIndex = 11
        Me.uxStructureDePrixLabel.Text = "Structure de prix"
        Me.uxStructureDePrixLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'FResults
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1482, 853)
        Me.Controls.Add(Me.uxStructureDePrixLabel)
        Me.Controls.Add(Me.uxDataGridView1)
        Me.Controls.Add(Me.uxActiveRaceTitleLabel)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FResults"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Les résultats"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.uxDataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents uxActiveRaceTitleLabel As Label
    Friend WithEvents uxDataGridView1 As DataGridView
    Friend WithEvents uxStructureDePrixLabel As Label
End Class
