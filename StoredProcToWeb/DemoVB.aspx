<%@ Page Language="VB" AutoEventWireup="false" CodeFile="DemoVB.aspx.vb" Inherits="DemoVB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Retrieving a Stored Procedure's Parameters</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>Retrieving a Stored Procedure's Parameters</h2>
        <p>This demo illustrates how to programmatically retrieve a stored procedure's parameters.
        It starts by listing the input and output parameters and then has a user interface where you
        can provide values for the input parameters and execute the stored procedure.</p>
        <p><i><b>Note:</b> The stored procedures I created in this database have a @CustomerID input parameter. Use the following
        value: <b>a7127eaf-ac80-48ae-8d18-d2a73552b0f2</b>. Many of the Membership-related sprocs 
            have an @ApplicationId or @ApplicationName parameter. Use 
            <b>c319c766-0d8c-493e-9cb4-1051d19b0526</b> for @ApplicationId and <b>DynamicUIDemo</b> for 
            @ApplicationName.</i></p>
        <p>
            <b>Stored Procedure: </b>
            <asp:DropDownList ID="Sprocs" AutoPostBack="True" runat="server" 
                DataSourceID="StoredProceduresDataSource" DataTextField="Name" 
                DataValueField="Name">
            </asp:DropDownList>
            <asp:SqlDataSource ID="StoredProceduresDataSource" runat="server" 
                ConnectionString="<%$ ConnectionStrings:TCubeContext %>" 
                
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
            <asp:Button ID="btnExecSproc" runat="server" Text="Execute Stored Procedure" />
        </p>
        
        <asp:Panel runat="server" ID="SprocResults" Visible="false">
            <asp:GridView ID="gvResults" runat="server" 
                EmptyDataText="There were no results returned by the stored procedure for the given input parameters.">
            </asp:GridView>
        </asp:Panel>
    </div>
    </form>
</body>
</html>
