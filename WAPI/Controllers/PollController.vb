Imports System.Net
Imports System.Web.Http
Imports WAPI.DBASE

Namespace Controllers
    Public Class PollController
        Inherits ApiController

        ' GET: api/Poll
        Public Function GetValues() As IEnumerable(Of Poll)
            Return GetPolls()
        End Function

        ' GET: api/Poll/5
        Public Function GetValue(PollsterID As Integer) As IEnumerable(Of Poll)
            Return GetPolls(PollsterID)
        End Function

        ' POST: api/Poll
        Public Sub PostValue(<FromBody()> ByVal value As String)

        End Sub

        ' PUT: api/Poll/5
        Public Sub PutValue(ByVal id As Integer, <FromBody()> ByVal value As String)

        End Sub

        ' DELETE: api/Poll/5
        Public Sub DeleteValue(ByVal id As Integer)

        End Sub
    End Class
End Namespace