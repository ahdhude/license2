Imports System.Data

Partial Class databaseDataSet
    Partial Public Class customerDataTable

        Private Sub checklastname(row As customerRow)
            If row.IsNull("Name") OrElse row.Name = "" Then
                row.SetColumnError(Me.NameColumn, "please enter a Name")
            Else
                row.SetColumnError(Me.NameColumn, "")
            End If
        End Sub

        Private Sub customerDataTable_ColumnChanged(sender As Object, e As DataColumnChangeEventArgs) Handles Me.ColumnChanged
            If e.Column Is Me.NameColumn Then
                Me.checklastname(CType(e.Row, customerRow))

            End If
        End Sub

        Private Sub customerDataTable_TableNewRow(sender As Object, e As DataTableNewRowEventArgs) Handles Me.TableNewRow
            Me.checklastname(CType(e.Row, customerRow))
        End Sub
    End Class
End Class
