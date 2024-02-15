<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TicketInfoDashboard.aspx.cs" Inherits="syndicate.Pages.TempDesign.TicketInfoDashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="../../Content/bootstrap.css" rel="stylesheet" />
    <script src="../../Scripts/jquery-3.4.1.js"></script>
    <script src="../../Scripts/jquery.signalR-2.2.2.js"></script>
    <script src="/signalR/hubs"></script>
    <script src="../../Scripts/bootstrap.js"></script>
    <script src="../../Scripts/TicketInfod/Table.js"></script>
    <script src="../../Scripts/TicketInfod/refresh.js"></script>
    <title>Ticket Dashboard</title>
</head>
<body style="background-color: #4A678E" onload="refresh();">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
         <%--  Modal2--%>
        <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">Sell Tickets</h5>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close" onclick="removesession()"></button>
                    </div>
                    <div class="modal-body">
                        <table>
                            <tr>
                                <td>Ticket Number</td>
                                <td id="modalticketsTicketNo"></td>
                            </tr>
                            <tr>
                                <td>Full Sheet :</td>
                                <td>
                                    <asp:Label ID="LabelmodalFullSheet" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>Half Sheet :</td>
                                <td> <asp:Label ID="LabelmodalHalfSheet" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>Name</td>
                                <td>
                                    <asp:TextBox ID="TextBoxmodalName" runat="server" CssClass="form-control form-control-sm"></asp:TextBox></td>
                            </tr>
                              <tr>
                                <td>Number</td>
                                <td>
                                    <asp:TextBox ID="TextBoxmodalNumber" runat="server" TextMode="Number" class="form-control form-control-sm"></asp:TextBox></td>
                            </tr>
                        </table>
                    </div>
                     <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                    <ContentTemplate>
                    <div class="modal-footer">
                                  <button type="button" class="btn btn-secondary btn-sm" data-bs-dismiss="modal" onclick="removesession();">Close</button>
                       <%-- <button type="button" id="modalsell" class="btn btn-primary btn-sm" data-bs-dismiss="modal" onclick="passTicketData(); return true;">Sell</button>--%>
                        <asp:Button ID="modalsell" runat="server" Text="sell" class="btn btn-primary btn-sm" data-bs-dismiss="modal" OnClick="modalsell_Click" />
                    </div>
                   </ContentTemplate>
                 </asp:UpdatePanel>
                </div>
            </div>
        </div>
        <div>
            
            <h2 class="text-center text-light p-1 header-site" style="background-color: #432F6A"></h2>
            <table class="table table-sm text-center" style="background: #3C5A82">
                <tbody>
                    <tr>
                        <td><a href="/admin" style="color: white; text-decoration: none;">Home</a> </td>
                        <td><a href="../TempDesign/ManageTickets.aspx" style="color: white; text-decoration: none;">Manage Tickets</a> </td>
                        <td><a href="../Agent/AddAgent.aspx" style="color: white; text-decoration: none;">Manage Agents</a> </td>
                    </tr>
                </tbody>
            </table>
            <div class="container">
                <h6 class="text-center text-light">Tickets Information</h6>

                <table class="table table-sm text-center table-primary">
                    <tbody>
                        <tr>
                            <td style="font-size: 13px; font-weight: bold">Ticket on sale</td>
                            <td style="font-size: 13px; font-weight: bold">Total Tickets sold</td>
                            <td style="font-size: 13px; font-weight: bold">Total Ticket left</td>
                            <td style="font-size: 13px; font-weight: bold">Total Ticket price</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="LabeltotalTicket" runat="server" Text="Label"></asp:Label></td>
                            <td>
                                <asp:Label ID="Labeltotalsold" runat="server" Text="Label"></asp:Label></td>
                            <td>
                                <asp:Label ID="Labelleftt" runat="server" Text="Label"></asp:Label></td>
                            <td>
                                <asp:Label ID="LabelPrice" runat="server" Text="Label"></asp:Label></td>
                        </tr>
                    </tbody>
                </table>

                 <asp:UpdatePanel ID="UpdatePanelT" runat="server">
                     <ContentTemplate>
                 <div class="container">
                     <asp:Button ID="ButtoMyTickets" runat="server" Text="My Tickets" style="background:#ee6c4d" CssClass=" text-light form-control form-control-sm" OnClick="ButtoMyTickets_Click" />
                     <div class="container-body mt-2">
                              <input type="button" id="stickyButton" value="sell" class="mb-4 btn btn-sm btn-primary m-4 fixed-bottom" data-bs-toggle="modal" data-bs-target="#exampleModal" onclick="setArray();" style="width:10%;" />
                         <div class="text-center">
                              <table id="WholeTable" class="table fw-bold text-dark text-center table-sm table-bordered border-2 border-primary mb-4" style="width:80%;margin-left:auto;margin-right:auto;">
                         </table>
                         </div>
                     </div>
                 </div>    
                    </ContentTemplate>
                 </asp:UpdatePanel>
            </div>
        </div>
    </form>
</body>
</html>
