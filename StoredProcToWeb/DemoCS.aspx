<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DemoCS.aspx.cs" Inherits="DemoCS" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Retrieving a Stored Procedure's Parameters</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>Retrieving a Stored Procedure's Parameters</h2>
        <p>
            <b>Stored Procedure: </b>
            <asp:DropDownList ID="Sprocs" AutoPostBack="True" runat="server" 
                DataSourceID="StoredProceduresDataSource" DataTextField="Name" 
                DataValueField="Name" onselectedindexchanged="Sprocs_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:SqlDataSource ID="StoredProceduresDataSource" runat="server" 
                ConnectionString="<%$ ConnectionStrings:LawFirmConnectionString %>" 
                
                SelectCommand="SELECT Name FROM sysobjects WHERE type = @type ORDER BY name">
                <SelectParameters>
                    <asp:Parameter DefaultValue="P" Name="type" />
                </SelectParameters>
            </asp:SqlDataSource>
        </p>
        <table cellpadding="8">
            <tr>
                <td style="width:50%; vertical-align: top;">
                    <b>Input Parameters:</b>
                    <asp:BulletedList ID="blInputParameters" runat="server">
                    </asp:BulletedList>
                </td>
                <td style="width:50%; vertical-align: top;">
                    <b>Output Parameters:</b>
                    <asp:BulletedList ID="blOutputParameters" runat="server">
                    </asp:BulletedList>
                </td>
            </tr>
        </table>
        <hr />
        <h3>Execute the Selected Stored Procedure</h3>
        <p>Enter values for the following input parameters and click "Execute" to run the sproc.
        Please note that there is no input validation being performed on your input values. 
            (Note: leaving a TextBox blank sends a database NULL value as the input 
            parameter value.)</p>
        <p>
            <asp:GridView ID="gvParameters" runat="server" AutoGenerateColumns="False" 
                DataKeyNames="ParameterName">
                <Columns>
                    <asp:BoundField DataField="ParameterName" HeaderText="Parameter" />
                    <asp:TemplateField HeaderText="Value">
                        <ItemTemplate>
                            <asp:TextBox ID="ParameterValue" runat="server" Columns="40"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </p>
        <p>
            <asp:Button ID="btnExecSproc" runat="server" Text="Execute Stored Procedure" 
                onclick="btnExecSproc_Click" />
        </p>
        
        <asp:Panel runat="server" ID="SprocResults" Visible="false">
            <asp:Button ID="btnExport" runat="server" Text="Export To Excel" OnClick = "ExportToExcel" /><br />
            <asp:GridView ID="gvResults" runat="server" 
                EmptyDataText="There were no results returned by the stored procedure for the given input parameters.">
            </asp:GridView>
        </asp:Panel>
    </div>
    </form>
</body>
</html>
