Option Strict On
Option Explicit On
Public Class DomainConnectWatcher
    Implements System.IDisposable
    Public Event ConnectChanged As System.EventHandler
    Private Const SLEEPINMAINLOOP As Integer = 500

    Private m_Thread As System.Threading.Thread = Nothing
    Private m_IsConnect As Boolean = False
    Private m_Domain As Uri = Nothing
    Private m_Disposed As Boolean = False

#Region " Properties "

    Public ReadOnly Property IsConnect() As Boolean
        Get
            Return Me.m_IsConnect
        End Get
    End Property

    Public Overridable Property Domain() As Uri
        Get
            Return Me.m_Domain
        End Get
        Set(ByVal value As Uri)
            Me.m_Domain = value
        End Set
    End Property

    Public Overridable Property Work() As Boolean
        Get
            Return Me.m_Thread IsNot Nothing
        End Get
        Set(ByVal value As Boolean)
            If value = (Me.m_Thread IsNot Nothing) Then Return
            '------------------------------------------------------------
            If value Then
                Me.m_Thread = New System.Threading.Thread(AddressOf Me.MainLooping)
                Me.m_Thread.Priority = Threading.ThreadPriority.Lowest
                Me.m_Thread.IsBackground = True
                Me.m_Thread.Start()
            Else
                Dim thread As System.Threading.Thread = Me.m_Thread
                Me.m_Thread = Nothing
                System.Threading.Thread.Sleep(2 * SLEEPINMAINLOOP)

                Try
                    If (Me.m_Thread.ThreadState And (Threading.ThreadState.Aborted Or Threading.ThreadState.AbortRequested Or Threading.ThreadState.Unstarted)) = 0 Then
                        Me.m_Thread.Abort()
                    End If
                Catch
                End Try

            End If
        End Set
    End Property

#End Region

    Private Sub MainLooping()
        Do While (Me.m_Thread IsNot Nothing)
            If Me.m_IsConnect <> DomainConnectWatcher.ConnectTest(Me.m_Domain) Then
                Me.m_IsConnect = Not Me.m_IsConnect
                Me.OnConnectChanged(EventArgs.Empty)
            End If
            '------------------------------------------------------------
            Try
                System.Threading.Thread.Sleep(SLEEPINMAINLOOP)
            Catch
            End Try
        Loop
    End Sub

    Private Shared Function ConnectTest(ByVal sDomain As Uri) As Boolean
        If (sDomain Is Nothing) Then Return False
        '------------------------------------------------------------
        Dim arrip() As System.Net.IPAddress = DnsName(sDomain)
        If (arrip Is Nothing) Then Return False

        Dim iport As Integer = sDomain.Port
        For Each ip As System.Net.IPAddress In arrip
            Try
                If _
                    (ip.Equals(System.Net.IPAddress.None) = False) AndAlso ( _
                    (ip.AddressFamily = Net.Sockets.AddressFamily.InterNetwork) OrElse _
                    (ip.AddressFamily = Net.Sockets.AddressFamily.InterNetworkV6)) _
                    Then

                    Using socket As New System.Net.Sockets.Socket(ip.AddressFamily, System.Net.Sockets.SocketType.Stream, System.Net.Sockets.ProtocolType.Tcp)
                        socket.Connect(ip, iport)
                        If socket.Connected Then
                            socket.Close(5)
                            Return True
                        End If
                    End Using
                End If
            Catch
            End Try
        Next
        Return False
    End Function

    Private Shared Function DnsName(ByVal url As Uri) As System.Net.IPAddress()
        Try
            If (url.HostNameType = UriHostNameType.IPv4) OrElse (url.HostNameType = UriHostNameType.IPv6) Then
                Return New System.Net.IPAddress() {System.Net.IPAddress.Parse(url.DnsSafeHost)}
            End If

            Return System.Net.Dns.GetHostEntry(url.DnsSafeHost).AddressList
        Catch
            Return Nothing
        End Try
    End Function

    Protected Overridable Sub OnConnectChanged(ByVal e As EventArgs)
        RaiseEvent ConnectChanged(Me, e)
    End Sub

#Region " IDisposable Support "

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Me.m_Disposed Then Return
        Me.m_Disposed = True
        '------------------------------------------------------------
        Try
            Me.Work = False
        Catch
        End Try
    End Sub

    Public Overridable Sub Dispose() Implements IDisposable.Dispose
        Me.Dispose(True)
        System.GC.SuppressFinalize(Me)
    End Sub

    Protected Overrides Sub Finalize()
        Try
            Me.Dispose(False)
        Catch
        Finally
            MyBase.Finalize()
        End Try
    End Sub

#End Region

End Class
