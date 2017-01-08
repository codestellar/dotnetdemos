Imports System.Data.SqlClient

Partial Class DemoVB
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Sprocs.DataBind()
            UpdateParameterDisplay()
        End If
    End Sub

    Protected Sub Sprocs_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Sprocs.SelectedIndexChanged
        UpdateParameterDisplay()
    End Sub

    Private Sub UpdateParameterDisplay()
        'Get the parameters for the selected stored procedure
        Using myConnection As New SqlConnection
            myConnection.ConnectionString = ConfigurationManager.ConnectionStrings("LawFirmConnectionString").ConnectionString

            Dim myCommand As New SqlCommand
            myCommand.Connection = myConnection
            myCommand.CommandText = Sprocs.SelectedValue
            myCommand.CommandType = Data.CommandType.StoredProcedure

            myConnection.Open()
            SqlCommandBuilder.DeriveParameters(myCommand)
            myConnection.Close()

            blInputParameters.Items.Clear()
            blOutputParameters.Items.Clear()

            Dim inputParamList As New List(Of SqlParameter)

            For Each param As SqlParameter In myCommand.Parameters
                If param.Direction = Data.ParameterDirection.Input OrElse param.Direction = Data.ParameterDirection.InputOutput Then
                    blInputParameters.Items.Add(param.ParameterName & " - " & param.SqlDbType.ToString())
                    inputParamList.Add(param)
                Else
                    blOutputParameters.Items.Add(param.ParameterName & " - " & param.SqlDbType.ToString())
                End If
            Next

            'Bind the list of input parameters to the GridView
            gvParameters.DataSource = inputParamList
            gvParameters.DataBind()
        End Using

        'Hide the results (until they click the Execute button
        SprocResults.Visible = False
    End Sub

    Protected Sub btnExecSproc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExecSproc.Click
        'Show the results
        SprocResults.Visible = True

        'Execute the sproc w/the parameter values
        Using myConnection As New SqlConnection
            myConnection.ConnectionString = ConfigurationManager.ConnectionStrings("LawFirmConnectionString").ConnectionString

            Dim myCommand As New SqlCommand
            myCommand.Connection = myConnection
            myCommand.CommandText = Sprocs.SelectedValue
            myCommand.CommandType = Data.CommandType.StoredProcedure

            'Get the parameter values from the grid
            For Each gvRow As GridViewRow In gvParameters.Rows
                'Determine the parameter name
                Dim paramName As String = gvParameters.DataKeys(gvRow.RowIndex).Value.ToString()
                Dim paramValue As Object = DBNull.Value

                'Get the TextBox in the row
                Dim paramValueTextBox As TextBox = CType(gvRow.FindControl("ParameterValue"), TextBox)
                If Not String.IsNullOrEmpty(paramValueTextBox.Text) Then
                    paramValue = paramValueTextBox.Text
                End If


                'Add the parameter name/value pair to the SqlCommand
                myCommand.Parameters.AddWithValue(paramName, paramvalue)
            Next

            myConnection.Open()
            gvResults.DataSource = myCommand.ExecuteReader()
            gvResults.DataBind()
            myConnection.Close()
        End Using
    End Sub
End Class
