<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbPort = New System.Windows.Forms.ComboBox()
        Me.cmbBaud = New System.Windows.Forms.ComboBox()
        Me.btnConnect = New System.Windows.Forms.Button()
        Me.btnDisconnect = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CheckBoxPHlog = New System.Windows.Forms.CheckBox()
        Me.CheckBoxRTlog = New System.Windows.Forms.CheckBox()
        Me.CheckBoxWTlog = New System.Windows.Forms.CheckBox()
        Me.CheckBoxPHauto = New System.Windows.Forms.CheckBox()
        Me.CheckBoxRTauto = New System.Windows.Forms.CheckBox()
        Me.CheckBoxALLauto = New System.Windows.Forms.CheckBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.CheckBoxWTauto = New System.Windows.Forms.CheckBox()
        Me.bntReadAll = New System.Windows.Forms.Button()
        Me.btnPh = New System.Windows.Forms.Button()
        Me.btnRoomTemp = New System.Windows.Forms.Button()
        Me.btnWaterTemp = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rtbReceived = New System.Windows.Forms.RichTextBox()
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.labelWaterTemperature = New System.Windows.Forms.Label()
        Me.labelRoomTemperature = New System.Windows.Forms.Label()
        Me.labelPhReading = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(35, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Com Port:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(35, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Baud Rate:"
        '
        'cmbPort
        '
        Me.cmbPort.FormattingEnabled = True
        Me.cmbPort.Location = New System.Drawing.Point(108, 33)
        Me.cmbPort.Name = "cmbPort"
        Me.cmbPort.Size = New System.Drawing.Size(142, 21)
        Me.cmbPort.TabIndex = 2
        '
        'cmbBaud
        '
        Me.cmbBaud.FormattingEnabled = True
        Me.cmbBaud.Location = New System.Drawing.Point(108, 70)
        Me.cmbBaud.Name = "cmbBaud"
        Me.cmbBaud.Size = New System.Drawing.Size(142, 21)
        Me.cmbBaud.TabIndex = 3
        '
        'btnConnect
        '
        Me.btnConnect.Location = New System.Drawing.Point(292, 33)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(70, 23)
        Me.btnConnect.TabIndex = 4
        Me.btnConnect.Text = "Connect"
        Me.btnConnect.UseVisualStyleBackColor = True
        '
        'btnDisconnect
        '
        Me.btnDisconnect.Location = New System.Drawing.Point(292, 70)
        Me.btnDisconnect.Name = "btnDisconnect"
        Me.btnDisconnect.Size = New System.Drawing.Size(70, 23)
        Me.btnDisconnect.TabIndex = 5
        Me.btnDisconnect.Text = "Disconnect"
        Me.btnDisconnect.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CheckBoxPHlog)
        Me.GroupBox1.Controls.Add(Me.CheckBoxRTlog)
        Me.GroupBox1.Controls.Add(Me.CheckBoxWTlog)
        Me.GroupBox1.Controls.Add(Me.CheckBoxPHauto)
        Me.GroupBox1.Controls.Add(Me.CheckBoxRTauto)
        Me.GroupBox1.Controls.Add(Me.CheckBoxALLauto)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.CheckBoxWTauto)
        Me.GroupBox1.Controls.Add(Me.bntReadAll)
        Me.GroupBox1.Controls.Add(Me.btnPh)
        Me.GroupBox1.Controls.Add(Me.btnRoomTemp)
        Me.GroupBox1.Controls.Add(Me.btnWaterTemp)
        Me.GroupBox1.Enabled = False
        Me.GroupBox1.Location = New System.Drawing.Point(17, 101)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(361, 167)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Read Data"
        '
        'CheckBoxPHlog
        '
        Me.CheckBoxPHlog.AutoSize = True
        Me.CheckBoxPHlog.Location = New System.Drawing.Point(254, 91)
        Me.CheckBoxPHlog.Name = "CheckBoxPHlog"
        Me.CheckBoxPHlog.Size = New System.Drawing.Size(44, 17)
        Me.CheckBoxPHlog.TabIndex = 13
        Me.CheckBoxPHlog.Text = "Log"
        Me.CheckBoxPHlog.UseVisualStyleBackColor = True
        '
        'CheckBoxRTlog
        '
        Me.CheckBoxRTlog.AutoSize = True
        Me.CheckBoxRTlog.Location = New System.Drawing.Point(254, 62)
        Me.CheckBoxRTlog.Name = "CheckBoxRTlog"
        Me.CheckBoxRTlog.Size = New System.Drawing.Size(44, 17)
        Me.CheckBoxRTlog.TabIndex = 12
        Me.CheckBoxRTlog.Text = "Log"
        Me.CheckBoxRTlog.UseVisualStyleBackColor = True
        '
        'CheckBoxWTlog
        '
        Me.CheckBoxWTlog.AutoSize = True
        Me.CheckBoxWTlog.Location = New System.Drawing.Point(254, 31)
        Me.CheckBoxWTlog.Name = "CheckBoxWTlog"
        Me.CheckBoxWTlog.Size = New System.Drawing.Size(44, 17)
        Me.CheckBoxWTlog.TabIndex = 11
        Me.CheckBoxWTlog.Text = "Log"
        Me.CheckBoxWTlog.UseVisualStyleBackColor = True
        '
        'CheckBoxPHauto
        '
        Me.CheckBoxPHauto.AutoSize = True
        Me.CheckBoxPHauto.Location = New System.Drawing.Point(158, 91)
        Me.CheckBoxPHauto.Name = "CheckBoxPHauto"
        Me.CheckBoxPHauto.Size = New System.Drawing.Size(82, 17)
        Me.CheckBoxPHauto.TabIndex = 9
        Me.CheckBoxPHauto.Text = "Auto Polling"
        Me.CheckBoxPHauto.UseVisualStyleBackColor = True
        '
        'CheckBoxRTauto
        '
        Me.CheckBoxRTauto.AutoSize = True
        Me.CheckBoxRTauto.Location = New System.Drawing.Point(158, 62)
        Me.CheckBoxRTauto.Name = "CheckBoxRTauto"
        Me.CheckBoxRTauto.Size = New System.Drawing.Size(82, 17)
        Me.CheckBoxRTauto.TabIndex = 8
        Me.CheckBoxRTauto.Text = "Auto Polling"
        Me.CheckBoxRTauto.UseVisualStyleBackColor = True
        '
        'CheckBoxALLauto
        '
        Me.CheckBoxALLauto.AutoSize = True
        Me.CheckBoxALLauto.Location = New System.Drawing.Point(158, 121)
        Me.CheckBoxALLauto.Name = "CheckBoxALLauto"
        Me.CheckBoxALLauto.Size = New System.Drawing.Size(82, 17)
        Me.CheckBoxALLauto.TabIndex = 7
        Me.CheckBoxALLauto.TabStop = False
        Me.CheckBoxALLauto.Text = "Auto Polling"
        Me.CheckBoxALLauto.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(274, 139)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(65, 22)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Clear"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'CheckBoxWTauto
        '
        Me.CheckBoxWTauto.AutoSize = True
        Me.CheckBoxWTauto.Location = New System.Drawing.Point(158, 31)
        Me.CheckBoxWTauto.Name = "CheckBoxWTauto"
        Me.CheckBoxWTauto.Size = New System.Drawing.Size(82, 17)
        Me.CheckBoxWTauto.TabIndex = 5
        Me.CheckBoxWTauto.Text = "Auto Polling"
        Me.CheckBoxWTauto.UseVisualStyleBackColor = True
        '
        'bntReadAll
        '
        Me.bntReadAll.Location = New System.Drawing.Point(21, 117)
        Me.bntReadAll.Name = "bntReadAll"
        Me.bntReadAll.Size = New System.Drawing.Size(116, 23)
        Me.bntReadAll.TabIndex = 4
        Me.bntReadAll.Text = "Read All"
        Me.bntReadAll.UseVisualStyleBackColor = True
        '
        'btnPh
        '
        Me.btnPh.Location = New System.Drawing.Point(21, 87)
        Me.btnPh.Name = "btnPh"
        Me.btnPh.Size = New System.Drawing.Size(116, 23)
        Me.btnPh.TabIndex = 3
        Me.btnPh.Text = "PH Reading"
        Me.btnPh.UseVisualStyleBackColor = True
        '
        'btnRoomTemp
        '
        Me.btnRoomTemp.Location = New System.Drawing.Point(21, 57)
        Me.btnRoomTemp.Name = "btnRoomTemp"
        Me.btnRoomTemp.Size = New System.Drawing.Size(116, 23)
        Me.btnRoomTemp.TabIndex = 2
        Me.btnRoomTemp.Text = "Room Temperature"
        Me.btnRoomTemp.UseVisualStyleBackColor = True
        '
        'btnWaterTemp
        '
        Me.btnWaterTemp.Location = New System.Drawing.Point(21, 27)
        Me.btnWaterTemp.Name = "btnWaterTemp"
        Me.btnWaterTemp.Size = New System.Drawing.Size(116, 23)
        Me.btnWaterTemp.TabIndex = 1
        Me.btnWaterTemp.Text = "Water Temperature"
        Me.btnWaterTemp.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rtbReceived)
        Me.GroupBox2.Location = New System.Drawing.Point(17, 274)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(359, 192)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Received Data"
        '
        'rtbReceived
        '
        Me.rtbReceived.Location = New System.Drawing.Point(19, 20)
        Me.rtbReceived.Name = "rtbReceived"
        Me.rtbReceived.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.rtbReceived.Size = New System.Drawing.Size(320, 164)
        Me.rtbReceived.TabIndex = 0
        Me.rtbReceived.Text = ""
        '
        'SerialPort1
        '
        Me.SerialPort1.ReceivedBytesThreshold = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(34, 520)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Room Temperature"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(35, 487)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(99, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Water Temperature"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(35, 550)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(22, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "PH"
        '
        'labelWaterTemperature
        '
        Me.labelWaterTemperature.AutoSize = True
        Me.labelWaterTemperature.Location = New System.Drawing.Point(190, 487)
        Me.labelWaterTemperature.Name = "labelWaterTemperature"
        Me.labelWaterTemperature.Size = New System.Drawing.Size(13, 13)
        Me.labelWaterTemperature.TabIndex = 11
        Me.labelWaterTemperature.Text = "0"
        '
        'labelRoomTemperature
        '
        Me.labelRoomTemperature.AutoSize = True
        Me.labelRoomTemperature.Location = New System.Drawing.Point(190, 520)
        Me.labelRoomTemperature.Name = "labelRoomTemperature"
        Me.labelRoomTemperature.Size = New System.Drawing.Size(13, 13)
        Me.labelRoomTemperature.TabIndex = 12
        Me.labelRoomTemperature.Text = "0"
        '
        'labelPhReading
        '
        Me.labelPhReading.AutoSize = True
        Me.labelPhReading.Location = New System.Drawing.Point(190, 550)
        Me.labelPhReading.Name = "labelPhReading"
        Me.labelPhReading.Size = New System.Drawing.Size(13, 13)
        Me.labelPhReading.TabIndex = 13
        Me.labelPhReading.Text = "0"
        '
        'Timer1
        '
        Me.Timer1.Interval = 5000
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(396, 24)
        Me.MenuStrip1.TabIndex = 14
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(396, 580)
        Me.Controls.Add(Me.labelPhReading)
        Me.Controls.Add(Me.labelRoomTemperature)
        Me.Controls.Add(Me.labelWaterTemperature)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnDisconnect)
        Me.Controls.Add(Me.btnConnect)
        Me.Controls.Add(Me.cmbBaud)
        Me.Controls.Add(Me.cmbPort)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.Text = "Arduino PH Meter"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbPort As System.Windows.Forms.ComboBox
    Friend WithEvents cmbBaud As System.Windows.Forms.ComboBox
    Friend WithEvents btnConnect As System.Windows.Forms.Button
    Friend WithEvents btnDisconnect As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnWaterTemp As System.Windows.Forms.Button
    Friend WithEvents rtbReceived As System.Windows.Forms.RichTextBox
    Friend WithEvents SerialPort1 As System.IO.Ports.SerialPort
    Friend WithEvents btnRoomTemp As System.Windows.Forms.Button
    Friend WithEvents btnPh As System.Windows.Forms.Button
    Friend WithEvents bntReadAll As System.Windows.Forms.Button
    Friend WithEvents CheckBoxWTauto As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents labelWaterTemperature As System.Windows.Forms.Label
    Friend WithEvents labelRoomTemperature As System.Windows.Forms.Label
    Friend WithEvents labelPhReading As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents CheckBoxALLauto As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxRTauto As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxPHauto As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxWTlog As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxPHlog As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxRTlog As System.Windows.Forms.CheckBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip

End Class
