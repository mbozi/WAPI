Imports System.Data.SqlClient

Public Class DBASE
    Public Structure Pollster
        Public Property ID As Integer
        Public Property pName As String
    End Structure

    Public Structure Poll
        Public Property ID As Integer
        Public Property PollsterID As Integer
        Public Property Pollster As String
        Public Property Fieldwork As Date
        Public Property CON As Decimal
        Public Property LAB As Decimal
        Public Property LDM As Decimal
        Public Property BRX As Decimal
        Public Property SNP As Decimal
        Public Property GRN As Decimal
        Public Property PLC As Decimal
        Public Property UKP As Decimal
    End Structure
    Public Shared Function GetPollsters(Optional id As Integer = 0) As IEnumerable(Of Pollster)
        Try


            Dim output As New List(Of Pollster)
            Dim strSQl As String = "SELECT ID, Pollster FROM Pollster WHERE IsActive=1"
            If id > 0 Then strSQl &= " AND ID =" & id.ToString
            Using conn As New SqlConnection(My.Settings.CS)
                Using cmd As New SqlCommand(strSQl, conn)
                    conn.Open()
                    Using RDR = cmd.ExecuteReader()
                        If RDR.HasRows Then
                            Do While RDR.Read
                                Dim pi As New Pollster With {
                                .ID = CType(RDR.Item("ID"), Integer),
                                .pName = RDR.Item("Pollster").ToString
                            }
                                output.Add(pi)
                            Loop
                        End If
                    End Using
                End Using
            End Using
            Return output
        Catch ex As Exception
            Return Nothing
        End Try

    End Function

    Public Shared Function GetPolls(Optional PollsterID As Integer = 0) As IEnumerable(Of Poll)
        Try
            Dim output As New List(Of Poll)
            Dim strSQl As String = "SELECT p.ID, p.PollsterID, ps.Pollster, p.Fieldwork, p.CON, p.LAB, p.LIB, p.BRX, p.SNP, p.GRN, p.PLC, p.UKP FROM dbo.Polls AS p LEFT OUTER JOIN dbo.Pollster AS ps ON p.PollsterID = ps.ID"
            Dim strFilter As String = ""
            If PollsterID > 0 Then strFilter &= " WHERE PollsterID =" & PollsterID.ToString
            strSQl &= strFilter
            Using conn As New SqlConnection(My.Settings.CS)
                Using cmd As New SqlCommand(strSQl, conn)
                    conn.Open()
                    Using RDR = cmd.ExecuteReader()
                        If RDR.HasRows Then
                            Do While RDR.Read
                                Dim pi As New Poll With {
                                .ID = CType(RDR.Item("ID"), Integer),
                                .PollsterID = CType(RDR.Item("PollsterID"), Integer),
                                .Pollster = RDR.Item("Pollster").ToString,
                                .Fieldwork = CType(RDR.Item("Fieldwork"), Date),
                                .CON = CType(RDR.Item("CON"), Decimal),
                                .LAB = CType(RDR.Item("LAB"), Decimal),
                                .LDM = CType(RDR.Item("LIB"), Decimal),
                                .BRX = CType(RDR.Item("BRX"), Decimal),
                                .SNP = CType(RDR.Item("SNP"), Decimal),
                                .GRN = CType(RDR.Item("GRN"), Decimal),
                                .PLC = CType(RDR.Item("PLC"), Decimal),
                                .UKP = CType(RDR.Item("UKP"), Decimal)
                            }
                                output.Add(pi)
                            Loop
                        End If
                    End Using
                End Using
            End Using
            Return output
        Catch ex As Exception
            Return Nothing
        End Try

    End Function
End Class
