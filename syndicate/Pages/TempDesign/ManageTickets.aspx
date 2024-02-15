<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageTickets.aspx.cs" Inherits="syndicate.Pages.TempDesign.ManageTickets" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="../../Content/bootstrap.css" rel="stylesheet" />
    <script src="../../Scripts/jquery-3.4.1.js"></script>
    <script src="../../Scripts/bootstrap.js"></script>
    <script src="../../Scripts/ManageTicket/manageTicket.js"></script>
    <title>Manage ticket</title>
</head>
<body style="background-color:#4A678E">
    <form id="form1" runat="server">
           
        <h2 class="text-center text-light p-1 header-site" style="background-color:#432F6A"> </h2>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
       
                <table class="table table-sm bg-success mb-1">
                <tbody class="text-center text-light">
                    <tr>
                        <td><a href="/admin" style="color:white; text-decoration: none;">Home</a> </td>
                        <td><a href="../TempDesign/ManageTickets.aspx" style="color:white; text-decoration: none;">Manage Tickets</a> </td>
                        <td><a href="../Agent/AddAgent.aspx" style="color:white; text-decoration: none;">Manage Agents</a> </td>
                    </tr>
                </tbody>
            </table>
     
            <!-- Modal --> 
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <div class="modal fade" id="EditAgentModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h5 class="modal-title text-center" id="exampleModalLabel">Edit ticket</h5>
                                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                                </div>
                                <div class="modal-body">
                                    <div class="row text-center">
                                         <asp:Label ID="LabelTicketNo" CssClass="text-center" runat="server" Text=""></asp:Label>
                                    </div>
                                   
                                    <div class="row mb-1">
                                        <div class="col-6"> <label> Name:</label> </div>
                                          <div class="col-6"> <asp:TextBox ID="TextBoxEditName" CssClass="form-control form-control-sm" runat="server"></asp:TextBox></div>
                                    </div>
                                       <div class="row mb-1">
                                        <div class="col-6"><label> Phone Number:</label></div>
                                          <div class="col-6"><asp:TextBox ID="TextBoxEditPhone" CssClass="form-control form-control-sm" runat="server"></asp:TextBox></div>
                                    </div>                    
                                </div>
                                <div class="modal-footer">
                                    <button type="button" class="btn btn-secondary btn-sm" data-bs-dismiss="modal">Close</button>
                                    <asp:Button ID="ButtonSave" runat="server" class="btn btn-success btn-sm" Text="Save changes" OnClick="ButtonSave_Click" />
                                   
                                </div>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
         <div class="container">
        <div class="row text-center p-0">
            <div class="col-6 p-0">
                <asp:Button ID="ButtonTicketDashboard" runat="server" Text="Ticket Dashboard" CssClass="form-control text-light form-control-sm" style="outline: none;background-color:#5C9933;border-radius: 2px;color:black; width=100%" OnClick="ButtonTicketDashboard_Click" />
            </div>
            <div class="col-6 p-0">
                  <asp:Button ID="ButtonresetTicket" runat="server" Text="Reset Ticket sales" CssClass="form-control form-control-sm text-light" style="outline: none;background-color:#EE6C4D;border-radius: 5px;color:black;" OnClick="ButtonresetTicket_Click" OnClientClick="if ( !confirm('Are you sure you want to Reset all tickets ? ')) return false;"/>
            </div>
            </div>
            <div class="card mt-1" style="background:#98C1D9">
            <div class="card-body">
                <div class="row"><asp:TextBox ID="TextBoxsearchTicket"  CssClass=" form-control form-control-sm" runat="server" placeholder="search ticket to edit"></asp:TextBox></div>
                <div class="row"><asp:Button ID="ButtonsearchTicket" CssClass="form-control form-control-sm text-light" runat="server" Text="Search by ticket number" style="background:#4a678e" OnClientClick="searchbyTicket();return false;"/></div>
                <div class="row"><asp:Button ID="ButtonSearchCustomer" CssClass="form-control form-control-sm text-light" runat="server" Text="search by customer name" style="background:#4a678e" OnClientClick="searchbyName();return false;" /></div>     
             <div class="row"><asp:Button ID="ButtonShowAll" CssClass="form-control form-control-sm text-light" runat="server" Text="show all" style="background:#EE6C4D;display:none;" OnClientClick="showAll();return false;" /></div>     
            </div>
        </div>       
        </div>
        <div class="container">
             <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="GridViewBooking" AutoGenerateColumns="false" CssClass="table table-small text-center table-primary mt-2" runat="server" OnRowCommand="GridViewAgents_RowCommand" OnRowDataBound="GridViewBooking_RowDataBound">
                        <Columns>
                            <asp:BoundField DataField="TicketNo" HeaderText="Tk.No" HeaderStyle-Font-Size="12px" ItemStyle-Font-Size="13px" ItemStyle-Width="150px" />
                            <asp:BoundField DataField="CustomerNames" HeaderText="Name" HeaderStyle-Font-Size="12px" ItemStyle-Font-Size="13px" ItemStyle-Width="150px" />
                            <asp:BoundField DataField="CustomerPhoneNumber" HeaderText="Phone Number" HeaderStyle-Font-Size="12px" ItemStyle-Font-Size="13px" ItemStyle-Width="150px" />                          
                         
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImageButtonEdit" runat="server" ImageUrl="~/Content/images/btn_edit.png" CommandName="EditTicket" CommandArgument="<%# Container.DataItemIndex %>" />
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button ID="ImageButtonDelete" runat="server" Text="Un-sell" CssClass="btn btn-warning btn-sm" CommandName="CancelTicket" CommandArgument="<%# Container.DataItemIndex %>" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
