Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Namespace CustomSeriesPointDrawingSample.Model

    Public Partial Class Order

        <Key>
        <Required>
        <Column("OrderID")>
        Public Property OrderId As Integer

        <ForeignKey("Employee")>
        <Column("EmployeeID")>
        Public Property EmployeeId As Integer?

        Public Property OrderDate As Date

        <Column(TypeName:="smallmoney")>
        Public Property Freight As Decimal?

        Public Overridable Property Employee As Employee
    End Class
End Namespace
