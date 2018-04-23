<%-- BeginRegion Page setup --%>
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="ASPxperience_DataView_ItemCommand" %>

<%@ Register Assembly="DevExpress.Web.v8.1" Namespace="DevExpress.Web.ASPxDataView" TagPrefix="dxdv" %>
<%-- EndRegion --%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Dispatch item command in the ASPxDataView</title>
</head>
<body>
    <form id="form1" runat="server">
    
    <div>
        <asp:Label ID="lblExternalLabel" runat="server"></asp:Label>

        <dxdv:ASPxDataView ID="dvDataView" runat="server" DataSourceID="dsSampleDataSource" OnItemCommand="OnItemCommand" RowPerPage="2">
            <ItemTemplate>
                <asp:LinkButton ID="btnCommandSender" runat="server" Text="Send command" CommandName="SimpleCommand" 
                    CommandArgument='<%# Eval("EmployeeID") %>' />
                <br />
                <br />
                <asp:Label ID="TitleLabel" runat="server" Font-Bold="true" 
                    Text='<%# string.Format("{0} {1} ({2})", Eval("FirstName"), Eval("LastName"), Eval("Country")) %>'>
                </asp:Label>
            </ItemTemplate>
            <ItemStyle Height="110px" Width="160px" />
        </dxdv:ASPxDataView>
        
        <asp:AccessDataSource ID="dsSampleDataSource" runat="server" DataFile="~/App_Data/nwind.mdb"
            SelectCommand="SELECT [EmployeeID], [FirstName], [LastName], [Country] FROM [Employees]">
        </asp:AccessDataSource>
    </div>
    </form>
</body>
</html>
