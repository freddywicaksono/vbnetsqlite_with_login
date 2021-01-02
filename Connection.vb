Imports System.Data.SQLite
Public Class Connection
    Private _version As Integer = 3
    Private _filepath As String
    Private _new As Boolean = False
    Private _pwd As String
    Private _found As Boolean
    Private _connected As Boolean = False

    Public Property DataSource()
        Get
            Return _filepath
        End Get
        Set(ByVal value)
            _filepath = value
        End Set
    End Property

    Public Property Password()
        Get
            Return _pwd
        End Get
        Set(ByVal value)
            _pwd = value
        End Set
    End Property

    Public Property NewFile()
        Get
            Return _new
        End Get
        Set(ByVal value)
            _new = value
        End Set
    End Property

    Public Property RecordFound() As Boolean
        Get
            Return _found
        End Get
        Set(ByVal value As Boolean)
            _found = value
        End Set
    End Property

    ''' <summary>
    ''' Proses menyambungkan koneksi (SQL Server Express with Integrated Security = True without Username or Password)
    ''' </summary>
    Public Sub Connect()
        Try
            conn.Close()
            conn = New SQLiteConnection("Data Source=" & _filepath & ";Version=" & _version.ToString & ";New=" & _new & ";")

            conn.Open()

        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        Finally
            If (conn.State = True) Then
                _connected = True
            Else
                _connected = False
            End If
        End Try
    End Sub

    ''' <summary>
    ''' Proses memutuskan koneksi
    ''' </summary>
    Public Sub Disconnect()
        If (conn.State = True) Then
            conn.Close()
            conn.Dispose()
            _connected = False
        End If
    End Sub
End Class
