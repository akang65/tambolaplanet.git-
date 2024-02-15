<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyTickets.aspx.cs" Inherits="syndicate.Pages.TempDesign.MyTickets" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="../../Content/bootstrap.css" rel="stylesheet" />
    <title>Agent Ticket list</title>
</head>
<body style="background-color:#9CC7DA">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <h2 class="text-center text-light p-1 header-site" style="background-color:#432F6A"> </h2>
                <table class="table table-sm bg-success">
                <tbody class="text-center text-light">
                    <tr>
                        <td><a href="/admin" style="color:white; text-decoration: none;">Home</a> </td>
                        <td><a href="ManageTickets.aspx" style="color:white; text-decoration: none;">Manage Tickets</a> </td>
                        <td><a href="../Agent/AddAgent.aspx" style="color:white; text-decoration: none;">Manage Agents</a> </td>
                    </tr>
                </tbody>
            </table>
            <div class="container">
                <div class=" Text-center">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="GridViewMyTickets" CssClass="table table-sm table-dark" runat="server" OnRowDataBound="GridViewMyTickets_RowDataBound1">
                                <HeaderStyle Font-Size="13px" />
                                <RowStyle Font-Size="12px" />
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
    </form>
</body>
</html>
