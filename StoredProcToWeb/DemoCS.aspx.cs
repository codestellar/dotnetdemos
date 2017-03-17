using System;
using System.Data;
using System.Drawing;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class DemoCS : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Sprocs.DataBind();
            UpdateParameterDisplay();
        }
    }

    protected void Sprocs_SelectedIndexChanged(object sender, EventArgs e)
    {
        UpdateParameterDisplay();
    }

    private void UpdateParameterDisplay()
    {
        // Get the parameters for the selected stored procedure
        using (SqlConnection myConnection = new SqlConnection())
        {
            myConnection.ConnectionString = ConfigurationManager.ConnectionStrings["TCubeContext"].ConnectionString;

            SqlCommand myCommand = new SqlCommand();
            myCommand.Connection = myConnection;
            myCommand.CommandText = Sprocs.SelectedValue;
            myCommand.CommandType = CommandType.StoredProcedure;

            myConnection.Open();
            SqlCommandBuilder.DeriveParameters(myCommand);
            myConnection.Close();

            blInputParameters.Items.Clear();
            blOutputParameters.Items.Clear();

            List<SqlParameter> inputParamList = new List<SqlParameter>();

            foreach (SqlParameter param in myCommand.Parameters)
            {
                if (param.Direction == ParameterDirection.Input || param.Direction == ParameterDirection.InputOutput)
                {
                    blInputParameters.Items.Add(param.ParameterName + " - " + param.SqlDbType.ToString());
                    inputParamList.Add(param);
                }
                else
                {
                    blOutputParameters.Items.Add(param.ParameterName + " - " + param.SqlDbType.ToString());
                }
            }

            // Bind the list of input parameters to the GridView
            gvParameters.DataSource = inputParamList;
            gvParameters.DataBind();
        }

        // Hide the results (until they click the Execute button
        SprocResults.Visible = false;
    }

    protected void btnExecSproc_Click(object sender, EventArgs e)
    {
        // Show the results
        SprocResults.Visible = true;

        // Execute the sproc w/the parameter values
        using (SqlConnection myConnection = new SqlConnection())
        {
            myConnection.ConnectionString = ConfigurationManager.ConnectionStrings["TCubeContext"].ConnectionString;

            SqlCommand myCommand = new SqlCommand();
            myCommand.Connection = myConnection;
            myCommand.CommandText = Sprocs.SelectedValue;
            myCommand.CommandType = CommandType.StoredProcedure;

            // Get the parameter values from the grid
            foreach (GridViewRow gvRow in gvParameters.Rows)
            {
                // Determine the parameter name
                string paramName = gvParameters.DataKeys[gvRow.RowIndex].Value.ToString();
                object paramValue = DBNull.Value;

                // Get the TextBox in the row
                TextBox paramValueTextBox = gvRow.FindControl("ParameterValue") as TextBox;
                if (!String.IsNullOrEmpty(paramValueTextBox.Text))
                    paramValue = paramValueTextBox.Text;


                // Add the parameter name/value pair to the SqlCommand
                myCommand.Parameters.AddWithValue(paramName, paramValue);
            }

            myConnection.Open();
            gvResults.DataSource = myCommand.ExecuteReader();
            gvResults.DataBind();
            myConnection.Close();
        }
    }

    protected void ExportToExcel(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            //To Export all pages
            gvResults.AllowPaging = false;
            //this.BindGrid();

            gvResults.HeaderRow.BackColor = Color.White;
            foreach (TableCell cell in gvResults.HeaderRow.Cells)
            {
                cell.BackColor = gvResults.HeaderStyle.BackColor;
            }
            foreach (GridViewRow row in gvResults.Rows)
            {
                row.BackColor = Color.White;
                foreach (TableCell cell in row.Cells)
                {
                    if (row.RowIndex % 2 == 0)
                    {
                        cell.BackColor = gvResults.AlternatingRowStyle.BackColor;
                    }
                    else
                    {
                        cell.BackColor = gvResults.RowStyle.BackColor;
                    }
                    cell.CssClass = "textmode";
                }
            }

            gvResults.RenderControl(hw);

            //style to format numbers to string
            string style = @"<style> .textmode { } </style>";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }

}
