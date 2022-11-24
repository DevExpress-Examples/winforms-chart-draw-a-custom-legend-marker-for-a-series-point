Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Namespace CustomSeriesPointDrawingSample.Model

    Public Partial Class Employee

        <Key>
        <Required>
        <Column("EmployeeID")>
        Public Property EmployeeId As Integer

        <Required>
        <StringLength(20)>
        Public Property LastName As String

        <Required>
        <StringLength(10)>
        Public Property FirstName As String

        <Column(TypeName:="image")>
        Public Property Photo As Byte()

        Public ReadOnly Property FullName As String
            Get
                Return FirstName & " " & LastName
            End Get
        End Property

        Public Overridable Property Orders As ICollection(Of Order)
    End Class
End Namespace
