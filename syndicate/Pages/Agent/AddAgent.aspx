<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddAgent.aspx.cs" Inherits="syndicate.Pages.Agent.Agent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="../../Content/bootstrap.css" rel="stylesheet" />
    <script src="../../Scripts/jquery-3.4.1.min.js"></script>
    <script src="../../Scripts/bootstrap.js"></script>
    <link href="../../lib/font-awesome/css/all.css" rel="stylesheet" />
    <script src="../../Scripts/AgentPanelScripts/AddAgent.js"></script>
    <title></title>
</head>
<body style="background-color:#4A678E">
    <form id="form1" runat="server">
        <div>
             <h2 class="text-center text-light p-1 header-site" style="background-color:#432F6A"></h2>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <table class="table table-sm bg-success">
                <tbody class="text-center text-light">
                    <tr>
                        <td><a href="/admin" style="color:white; text-decoration: none;">Home</a> </td>
                        <td><a href="../TempDesign/ManageTickets.aspx" style="color:white; text-decoration: none;">Manage Tickets</a> </td>
                        <td><a href="AddAgent.aspx" style="color:white; text-decoration: none;">Manage Agents</a> </td>
                    </tr>
                </tbody>
            </table>
        <div class="container">
        
            <!-- Modal -->
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <div class="modal fade" id="EditAgentModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h5 class="modal-title text-center" id="exampleModalLabel">Edit Agent</h5>
                                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                                </div>
                                <div class="modal-body">
                                    <div class="row mb-1">
                                        <div class="col-6"> <label> Name:</label> </div>
                                          <div class="col-6"> <asp:TextBox ID="TextBoxEditAgentName" CssClass="form-control form-control-sm" runat="server"></asp:TextBox></div>
                                    </div>
                                       <div class="row mb-1">
                                        <div class="col-6"><label> Password:</label></div>
                                          <div class="col-6"><asp:TextBox ID="TextBoxEditAgentPassword" CssClass="form-control form-control-sm" runat="server"></asp:TextBox></div>
                                    </div>                    
                                </div>
                                <div class="modal-footer">
                                    <button type="button" class="btn btn-secondary btn-sm" data-bs-dismiss="modal">Close</button>
                                    <asp:Button ID="Button1" runat="server" class="btn btn-success btn-sm" Text="Save changes" OnClick="Button1_Click" />
                                   
                                </div>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <%--     sdsd--%>
               <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>                              
            <div class="card" style="background-color:#CFE2FF">
                <div class="card-body">
                    <h6 class="text-center text-dark">Add Agents</h6>
                    <div class="row">
                        <div class="col-6">
                            <asp:TextBox ID="TextBoxName" placeholder="Name" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-6">
                            <asp:TextBox ID="TextBoxPhone" placeholder="Phone Number"  TextMode="Number" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                        </div>

                    </div>
                    <div class="row mt-1">
                        <div class="col-6">
                            <asp:TextBox ID="TextBoxPassword" placeholder="Password" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-6 ">
                            <asp:Button ID="ButtonAddAgent" CssClass="btn btn-sm text-light" style="background:#ee6c4d" runat="server" Text="Create New Agent" OnClick="ButtonAddAgent_Click" />
                        </div>

                    </div>
                </div>
            </div>
                 </ContentTemplate>
            </asp:UpdatePanel>

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="GridViewAgents" AutoGenerateColumns="false" CssClass="table table-small text-center table-primary mt-2" runat="server" OnRowCommand="GridViewAgents_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="AgentName" HeaderText="Name" HeaderStyle-Font-Size="12px" ItemStyle-Font-Size="13px" ItemStyle-Width="150px" />
                            <asp:BoundField DataField="AgentPhoneNumber" HeaderText="Phone Number" HeaderStyle-Font-Size="12px" ItemStyle-Font-Size="13px" ItemStyle-Width="150px" />
                            <asp:BoundField DataField="AgentPassword" HeaderText="Password" HeaderStyle-Font-Size="12px" ItemStyle-Font-Size="12px" ItemStyle-Width="150px" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImageButtonEdit" runat="server" ImageUrl="~/Content/images/btn_edit.png" CommandName="editAgent" CommandArgument="<%# Container.DataItemIndex %>" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImageButtonDelete" runat="server" ImageUrl='~/Content/images/btn_delete.png' CommandName="deleteAgent" CommandArgument="<%# Container.DataItemIndex %>" />
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
            <%--search--%>
            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                <ContentTemplate>
                    <div class="row">
                        <div class="col-12"><asp:TextBox ID="TextBoxsearch" CssClass="form-control form-control-sm" placeholder="Agent Name" runat="server"></asp:TextBox></div>
                           <div class="col-12">
                               <asp:Button ID="Buttonsearch" runat="server" style="background:#2d3147" CssClass="form-control text-light form-control-sm" Text="Search" /></div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                <ContentTemplate>
                            <asp:GridView ID="GridViewAgentsTicketLists" CssClass="mt-1 table table-sm text-center table-primary" AutoGenerateColumns="false" runat="server" OnRowCommand="GridViewAgentsTicketLists_RowCommand">
                                  <Columns>
                            <asp:BoundField DataField="AgentName" HeaderText="Agents Name" HeaderStyle-Font-Size="12px" ItemStyle-Font-Size="13px" ItemStyle-Width="150px" />
                            <asp:BoundField DataField="TotalTicketsSold" HeaderText="Ticket sold" HeaderStyle-Font-Size="12px" ItemStyle-Font-Size="13px" ItemStyle-Width="150px" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button  ID="ButtonViewTickets" CssClass="btn btn-sm text-dark btn-warning" runat="server" Text="View Ticket"  CommandName="ViewTicket" CommandArgument="<%# Container.DataItemIndex %>" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                            </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        </div>
    </form>

</body>
</html>
