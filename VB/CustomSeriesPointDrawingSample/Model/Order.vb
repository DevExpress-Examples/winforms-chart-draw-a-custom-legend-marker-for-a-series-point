Imports System.ComponentModel.DataAnnotations.Schema
Imports System.ComponentModel.DataAnnotations
Imports System

Namespace CustomSeriesPointDrawingSample.Model

    Partial Public Class Order
        <Key, Required, Column("OrderID")> _
        Public Property OrderId() As Integer


        <ForeignKey("Employee"), Column("EmployeeID")> _
        Public Property EmployeeId() As Integer?

        Public Property OrderDate() As Date

        <Column(TypeName := "smallmoney")> _
        Public Property Freight() As Decimal?

        Public Overridable Property Employee() As Employee
    End Class
End Namespace
