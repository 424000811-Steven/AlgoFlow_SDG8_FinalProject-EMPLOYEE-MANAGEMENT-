

Imports System.Data.SqlClient

Public Class Form2

    Dim connString As String =
        "Data Source=.\SQLEXPRESS;Initial Catalog=AttendanceDB;Integrated Security=True;TrustServerCertificate=True"

    ' LOGGED IN EMPLOYEE
    Public Shared currentLoggedInEmpID As String = ""

    ' ================================
    ' FORM LOAD
    ' ================================
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        LoadAttendanceLogs()

    End Sub

    ' ================================
    ' TIME IN
    ' ================================
    Private Sub btnTimeIn_Click(sender As Object, e As EventArgs) Handles btnTimeIn.Click

        Try

            Using conn As New SqlConnection(connString)

                conn.Open()


                Dim checkQuery As String =
                    "SELECT COUNT(*) FROM Attendance 
                     WHERE EmpID = @EmpID 
                     AND TimeOut IS NULL"

                Using checkCmd As New SqlCommand(checkQuery, conn)

                    checkCmd.Parameters.AddWithValue("@EmpID", currentLoggedInEmpID)

                    Dim count As Integer =
                        Convert.ToInt32(checkCmd.ExecuteScalar())

                    If count > 0 Then

                        MessageBox.Show("Already Timed In!")
                        Exit Sub

                    End If

                End Using


                Dim insertQuery As String =
                    "INSERT INTO Attendance
                    (EmpID, TimeIn, Status)
                    VALUES
                    (@EmpID, @TimeIn, @Status)"

                Using cmd As New SqlCommand(insertQuery, conn)

                    cmd.Parameters.AddWithValue("@EmpID", currentLoggedInEmpID)
                    cmd.Parameters.AddWithValue("@TimeIn", DateTime.Now)
                    cmd.Parameters.AddWithValue("@Status", "Present")

                    cmd.ExecuteNonQuery()

                End Using

            End Using

            MessageBox.Show("Time-In Successful!")

            LoadAttendanceLogs()

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try

    End Sub

    ' ================================
    ' TIME OUT
    ' ================================
    Private Sub btnTimeOut_Click(sender As Object, e As EventArgs) Handles btnTimeOut.Click

        Try

            Using conn As New SqlConnection(connString)

                conn.Open()

                Dim updateQuery As String =
                    "UPDATE Attendance
                     SET TimeOut = @TimeOut
                     WHERE EmpID = @EmpID
                     AND TimeOut IS NULL"

                Using cmd As New SqlCommand(updateQuery, conn)

                    cmd.Parameters.AddWithValue("@TimeOut", DateTime.Now)
                    cmd.Parameters.AddWithValue("@EmpID", currentLoggedInEmpID)

                    Dim rowsAffected As Integer =
                        cmd.ExecuteNonQuery()

                    If rowsAffected > 0 Then

                        MessageBox.Show("Time-Out Successful!")

                    Else

                        MessageBox.Show("No active Time-In found!")

                    End If

                End Using

            End Using

            LoadAttendanceLogs()

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try

    End Sub

    ' ================================
    ' LOAD ATTENDANCE LOGS
    ' ================================
    Public Sub LoadAttendanceLogs()

        Try

            Using conn As New SqlConnection(connString)

                conn.Open()

                Dim query As String =
                    "SELECT
                        e.FullName AS [Employee Name],
                        a.TimeIn AS [Time In],
                        a.TimeOut AS [Time Out],
                        a.Status AS [Status]
                     FROM Attendance a
                     INNER JOIN Employees e
                     ON a.EmpID = e.EmpID
                     WHERE a.EmpID = @EmpID
                     ORDER BY a.ID DESC"

                Dim da As New SqlDataAdapter(query, conn)

                da.SelectCommand.Parameters.AddWithValue("@EmpID", currentLoggedInEmpID)

                Dim dt As New DataTable()

                da.Fill(dt)

                dgvAttendance.DataSource = dt

                dgvAttendance.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill

            End Using

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try

    End Sub
    Private Sub btnViewReport_Click(sender As Object, e As EventArgs) Handles btnViewReport.Click
        Dim reportForm As New ReportForm()
        reportForm.ShowDialog()
    End Sub

End Class