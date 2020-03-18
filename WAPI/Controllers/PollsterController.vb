Imports System.Net
Imports System.Web.Http
Imports WAPI.DBASE

Namespace Controllers
    Public Class PollsterController
        Inherits ApiController

        ' GET: api/Pollster
        Public Function GetValues() As IEnumerable(Of Pollster)
            Return GetPollsters()
        End Function

        ' GET: api/Pollster/5
        Public Function GetValue(ByVal id As Integer) As IEnumerable(Of Pollster)
            Return GetPollsters(id)
        End Function

        ' POST: api/Pollster
        Public Sub PostValue(<FromBody()> ByVal value As String)

        End Sub

        ' PUT: api/Pollster/5
        Public Sub PutValue(ByVal id As Integer, <FromBody()> ByVal value As String)

        End Sub

        ' DELETE: api/Pollster/5
        Public Sub DeleteValue(ByVal id As Integer)

        End Sub
    End Class
End Namespace