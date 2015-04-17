'Serial Port Interfacing with VB.net 2010 Express Edition
'Copyright (C) 2010  Richard Myrick T. Arellaga
'
'This program is free software: you can redistribute it and/or modify
'it under the terms of the GNU General Public License as published by
'the Free Software Foundation, either version 3 of the License, or
'(at your option) any later version.
'
'This program is distributed in the hope that it will be useful,
'but WITHOUT ANY WARRANTY; without even the implied warranty of
'MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
'GNU General Public License for more details.
'
' You should have received a copy of the GNU General Public License
' along with this program.  If not, see <http://www.gnu.org/licenses/>.


Imports System
Imports System.ComponentModel
Imports System.Threading
Imports System.IO.Ports
Public Class frmMain
    Dim myPort As Array  'COM Ports detected on the system will be stored here
    Delegate Sub SetTextCallback(ByVal [text] As String) 'Added to prevent threading errors during receiveing of data

    Dim Buffer(4) As Byte
    Dim CommandSend As String
    Dim AllIndex As String



    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'When our form loads, auto detect all serial ports in the system and populate the cmbPort Combo box.
        myPort = IO.Ports.SerialPort.GetPortNames() 'Get all com ports available
        cmbBaud.Items.Add(9600)     'Populate the cmbBaud Combo box to common baud rates used   

        For i = 0 To UBound(myPort)
            cmbPort.Items.Add(myPort(i))
        Next
        cmbPort.Text = cmbPort.Items.Item(0)    'Set cmbPort text to the first COM port detected
        cmbBaud.Text = cmbBaud.Items.Item(0)    'Set cmbBaud text to the first Baud rate on the list

        btnDisconnect.Enabled = False           'Initially Disconnect Button is Disabled

        Me.Text =
        System.Reflection.Assembly.GetExecutingAssembly().GetName().Name.ToString() & " " & _
        System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString()

    End Sub

    Private Sub btnConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnect.Click
        SerialPort1.PortName = cmbPort.Text         'Set SerialPort1 to the selected COM port at startup
        SerialPort1.BaudRate = cmbBaud.Text         'Set Baud rate to the selected value on 

        'Other Serial Port Property
        SerialPort1.Parity = IO.Ports.Parity.None
        SerialPort1.StopBits = IO.Ports.StopBits.One
        SerialPort1.DataBits = 8            'Open our serial port
        SerialPort1.Open()

        btnConnect.Enabled = False          'Disable Connect button
        btnDisconnect.Enabled = True        'and Enable Disconnect button
        GroupBox1.Enabled = True


    End Sub

    Private Sub btnDisconnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisconnect.Click
        SerialPort1.Close()             'Close our Serial Port

        btnConnect.Enabled = True
        btnDisconnect.Enabled = False
        GroupBox1.Enabled = False
        Timer1.Enabled = False
        CheckBoxWTauto.Checked = False
        CheckBoxRTauto.Checked = False
        CheckBoxPHauto.Checked = False
        CheckBoxALLauto.Checked = False
    End Sub

    Private Sub btnWaterTemp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWaterTemp.Click

        'AA 01 01 BB , Enquiry DS18B20 temperature
        'AA 01 02 BB , Enquiry LM35 temperature
        'AA 01 03 BB , Enquiry PH reading
        'AA 01 04 BB , Enqyiry DS18B20 , LM35 and Ph
        Buffer(0) = &HAA
        Buffer(1) = &H1
        Buffer(2) = &H1
        Buffer(3) = &HBB
        SerialPort1.Write(Buffer, 0, 3)
        CommandSend = "WT" 'Enquiry Water Temperature Command Send

    End Sub

    Private Sub SerialPort1_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
        'ReceivedText(SerialPort1.ReadExisting())    'Automatically called every time a data is received at the serialPort
        ReceivedText(SerialPort1.ReadTo(Chr(10)))       ' Read until New Line Char(10)
    End Sub
    Private Sub ReceivedText(ByVal [text] As String)
        'compares the ID of the creating Thread to the ID of the calling Thread
        If Me.rtbReceived.InvokeRequired Then
            Dim x As New SetTextCallback(AddressOf ReceivedText)
            Me.Invoke(x, New Object() {(text)})
        Else
            'Me.rtbReceived.Text &= [text]
            Dim newString As String = [text].Replace(vbCr, "")  'Remove Carriage Return
            Dim y As String
            Select Case CommandSend
                Case "WT"
                    y = " Water Temperature : "
                    Me.labelWaterTemperature.Text = newString
                    If CheckBoxWTlog.Checked = True Then
                        Dim file As System.IO.StreamWriter
                        file = My.Computer.FileSystem.OpenTextFileWriter("c:\temp\water.csv", True)
                        file.WriteLine(Format(TimeOfDay, "HH:mm:ss") + "," + newString)
                        file.Close()
                    End If
                Case "RT"
                    y = " Room Temperature : "
                    Me.labelRoomTemperature.Text = newString
                    If CheckBoxWTlog.Checked = True Then
                        Dim file As System.IO.StreamWriter
                        file = My.Computer.FileSystem.OpenTextFileWriter("c:\temp\room.csv", True)
                        file.WriteLine(Format(TimeOfDay, "HH:mm:ss") + "," + newString)
                        file.Close()
                    End If
                Case "PH"
                    y = " PH : "
                    If CheckBoxWTlog.Checked = True Then
                        Dim file As System.IO.StreamWriter
                        file = My.Computer.FileSystem.OpenTextFileWriter("c:\temp\ph.csv", True)
                        file.WriteLine(Format(TimeOfDay, "HH:mm:ss") + "," + newString)
                        file.Close()
                    End If
                    Me.labelPhReading.Text = newString
                Case "ALL"
                    Select Case AllIndex
                        Case "1"
                            y = " Water Temperature : "
                            Me.labelWaterTemperature.Text = newString
                            If CheckBoxWTlog.Checked = True Then
                                Dim file As System.IO.StreamWriter
                                file = My.Computer.FileSystem.OpenTextFileWriter("c:\temp\water.csv", True)
                                file.WriteLine(Format(TimeOfDay, "HH:mm:ss") + "," + newString)
                                file.Close()
                            End If
                            AllIndex = "2"
                        Case "2"
                            y = " Room Temperature : "
                            Me.labelRoomTemperature.Text = newString
                            If CheckBoxWTlog.Checked = True Then
                                Dim file As System.IO.StreamWriter
                                file = My.Computer.FileSystem.OpenTextFileWriter("c:\temp\room.csv", True)
                                file.WriteLine(Format(TimeOfDay, "HH:mm:ss") + "," + newString)
                                file.Close()
                            End If
                            AllIndex = "3"
                        Case "3"
                            y = " PH : "
                            Me.labelPhReading.Text = newString
                            If CheckBoxWTlog.Checked = True Then
                                Dim file As System.IO.StreamWriter
                                file = My.Computer.FileSystem.OpenTextFileWriter("c:\temp\ph.csv", True)
                                file.WriteLine(Format(TimeOfDay, "HH:mm:ss") + "," + newString)
                                file.Close()
                            End If
                            AllIndex = ""
                        Case Else
                            y = " Invaild Command Send "
                    End Select
                Case Else
                    y = " Invaild Command Send "
            End Select


            Me.rtbReceived.AppendText(Format(TimeOfDay, "HH:mm:ss") + y + newString + vbCrLf)
            Me.rtbReceived.ScrollToCaret()


            End If

    End Sub

    Private Sub cmbPort_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPort.SelectedIndexChanged
        If SerialPort1.IsOpen = False Then
            SerialPort1.PortName = cmbPort.Text         'pop a message box to user if he is changing ports
        Else                                            'without disconnecting first.
            MsgBox("Valid only if port is Closed", vbCritical)
        End If
    End Sub

    Private Sub cmbBaud_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBaud.SelectedIndexChanged
        If SerialPort1.IsOpen = False Then
            SerialPort1.BaudRate = cmbBaud.Text         'pop a message box to user if he is changing baud rate
        Else                                            'without disconnecting first.
            MsgBox("Valid only if port is Closed", vbCritical)
        End If
    End Sub

    Private Sub txtTransmit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub


    Private Sub btnRoomTemp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRoomTemp.Click
        'AA 01 01 BB , Enquiry DS18B20 temperature
        'AA 01 02 BB , Enquiry LM35 temperature
        'AA 01 03 BB , Enquiry PH reading
        'AA 01 04 BB , Enqyiry DS18B20 , LM35 and Ph
        Buffer(0) = &HAA
        Buffer(1) = &H1
        Buffer(2) = &H2
        Buffer(3) = &HBB
        SerialPort1.Write(Buffer, 0, 3)
        CommandSend = "RT" 'Enquiry Room Temperature Command Send
    End Sub

    Private Sub btnPh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPh.Click
        'AA 01 01 BB , Enquiry DS18B20 temperature
        'AA 01 02 BB , Enquiry LM35 temperature
        'AA 01 03 BB , Enquiry PH reading
        'AA 01 04 BB , Enqyiry DS18B20 , LM35 and Ph
        Buffer(0) = &HAA
        Buffer(1) = &H1
        Buffer(2) = &H3
        Buffer(3) = &HBB
        SerialPort1.Write(Buffer, 0, 3)
        CommandSend = "PH" 'Enquiry PH Command Send
    End Sub

    Private Sub bntReadAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bntReadAll.Click
        'AA 01 01 BB , Enquiry DS18B20 temperature
        'AA 01 02 BB , Enquiry LM35 temperature
        'AA 01 03 BB , Enquiry PH reading
        'AA 01 04 BB , Enqyiry DS18B20 , LM35 and Ph
        Buffer(0) = &HAA
        Buffer(1) = &H1
        Buffer(2) = &H4
        Buffer(3) = &HBB
        SerialPort1.Write(Buffer, 0, 3)
        CommandSend = "ALL" 'Enquiry All Command Send
        AllIndex = "1"
    End Sub

    Private Sub rtbReceived_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rtbReceived.TextChanged

    End Sub

    Private Sub CheckBoxWTauto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxWTauto.CheckedChanged
        If CheckBoxWTauto.Checked = True Then
            CheckBoxRTauto.Checked = False
            CheckBoxPHauto.Checked = False
            Timer1.Enabled = True
        Else
            Timer1.Enabled = False
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        'AA 01 01 BB , Enquiry DS18B20 temperature
        'AA 01 02 BB , Enquiry LM35 temperature
        'AA 01 03 BB , Enquiry PH reading
        'AA 01 04 BB , Enqyiry DS18B20 , LM35 and Ph

        If CheckBoxWTauto.Checked = True Then
            Buffer(0) = &HAA
            Buffer(1) = &H1
            Buffer(2) = &H1
            Buffer(3) = &HBB
            SerialPort1.Write(Buffer, 0, 3)
            CommandSend = "WT" 'Enquiry Water Temperature Command Send
        End If

        If CheckBoxRTauto.Checked = True Then
            Buffer(0) = &HAA
            Buffer(1) = &H1
            Buffer(2) = &H2
            Buffer(3) = &HBB
            SerialPort1.Write(Buffer, 0, 3)
            CommandSend = "RT" 'Enquiry Room Temperature Command Send
        End If

        If CheckBoxPHauto.Checked = True Then
            Buffer(0) = &HAA
            Buffer(1) = &H1
            Buffer(2) = &H3
            Buffer(3) = &HBB
            SerialPort1.Write(Buffer, 0, 3)
            CommandSend = "PH" 'Enquiry PH Command Send
        End If

        If CheckBoxALLauto.Checked = True Then
            Buffer(0) = &HAA
            Buffer(1) = &H1
            Buffer(2) = &H4
            Buffer(3) = &HBB
            SerialPort1.Write(Buffer, 0, 3)
            CommandSend = "ALL" 'Enquiry All Command Send
            AllIndex = "1"
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.rtbReceived.Text = ""
    End Sub

    Private Sub CheckBoxALLauto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxALLauto.CheckedChanged
        If CheckBoxALLauto.Checked = True Then
            CheckBoxWTauto.Checked = False
            CheckBoxWTauto.Enabled = False
            CheckBoxRTauto.Checked = False
            CheckBoxRTauto.Enabled = False
            CheckBoxPHauto.Checked = False
            CheckBoxPHauto.Enabled = False
            Timer1.Enabled = True
        Else
            CheckBoxWTauto.Enabled = True
            CheckBoxRTauto.Enabled = True
            CheckBoxPHauto.Enabled = True
            Timer1.Enabled = False
        End If
    End Sub

    Private Sub CheckBoxRTauto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxRTauto.CheckedChanged

        If CheckBoxRTauto.Checked = True Then
            CheckBoxWTauto.Checked = False
            CheckBoxPHauto.Checked = False
            Timer1.Enabled = True
        Else
            Timer1.Enabled = False
        End If
    End Sub

    Private Sub CheckBoxPHauto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxPHauto.CheckedChanged

        If CheckBoxPHauto.Checked = True Then
            CheckBoxWTauto.Checked = False
            CheckBoxRTauto.Checked = False
            Timer1.Enabled = True
        Else
            Timer1.Enabled = False
        End If
    End Sub


End Class
