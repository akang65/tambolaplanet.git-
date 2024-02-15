<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgentPanel.aspx.cs" Inherits="syndicate.Pages.Agent.AgentPanel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="../../Content/bootstrap.css" rel="stylesheet" asp-append-version="true" />
    <script src="../../Scripts/bootstrap.js"></script>
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Caveat-Bold" />
    <%--<link href="../../Content/Custom/Navbar.css" rel="stylesheet" />--%>
    <script src="../../Scripts/jquery-3.4.1.min.js"></script>
    <script src="../../Scripts/jquery.signalR-2.2.2.js"></script>
     <script src="/signalR/hubs"></script>
    <link href="../../lib/font-awesome/css/all.css" rel="stylesheet" />
    <script src="../../Scripts/AgentPanelScripts/AddAgent.js"></script>
    <script src="../../Scripts/AgentPanelScripts/tables.js"></script>
    <script src="../../Scripts/AgentPanelScripts/refreshtabs.js"></script>
  <%--      <script src="../../Scripts/AgentPanelScripts/CustomCountDownTimer.js"></script>--%>
    <script src="../../Content/Custom/navbar.js"></script>
    <script type="text/javascript">
        function loadModal() {
            $('#PhoneNumberModal').modal('show');
        }
        function loadModalAlert() {
            alert("Please enter Customer Name");
        }
        function closeModal() {
            $('body').removeClass('modal-open');
            $('.modal-backdrop').remove();
            $('body').css('overflow', 'auto');
        }
        function alertBoughtAlready() {
            alert("Too Slow! Another Agent bought it 1 sec ago");
        }
    </script>
    <title></title>

</head>
<body onload="removesession();">

    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <!-- Modal -->
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <div class="container">
                    <div class="modal fade" id="PhoneNumberModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                        <div class="modal-dialog modal-dialog-centered">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <%-- <h5 class="modal-title" id="exampleModalLabel">Modal title</h5>--%>
                                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                                </div>
                                <div class="modal-body text-center">
                                    <asp:Label ID="LabelMStatus" runat="server"></asp:Label>
                                    <div class="row" style="font-size: 13px">
                                        <div class="col-6">Sheet Number: </div>
                                        <div class="col-6">
                                            <asp:Label ID="LabelMSheetNumber" class="badge bg-secondary" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="row" style="font-size: 13px">
                                        <div class="col-6">Ticket Range</div>
                                        <%-- sheet Range--%>
                                        <div class="col-6">
                                            <asp:Label ID="LabelMSheetRange1" class="badge rounded-pill bg-success" runat="server"></asp:Label>
                                            <asp:Label ID="LabelMSheetRange2" class="badge rounded-pill bg-success" runat="server"></asp:Label>
                                            <asp:Label ID="LabelMSheetRange3" class="badge rounded-pill bg-success" runat="server"></asp:Label>
                                            <asp:Label ID="LabelMSheetRange4" class="badge rounded-pill bg-success" runat="server"></asp:Label>
                                            <asp:Label ID="LabelMSheetRange5" class="badge rounded-pill bg-success" runat="server"></asp:Label>
                                            <asp:Label ID="LabelMSheetRange6" class="badge rounded-pill bg-success" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="row" style="font-size: 13px">
                                        <div class="col-6">Customer Name: </div>
                                        <%--Name--%>
                                        <div class="col-6">
                                            <asp:Label ID="LabelMCustomerName" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="row" style="font-size: 13px">
                                        <div class="col-6">Customer Number:</div>
                                        <%--Phone--%>
                                        <div class="col-6">
                                            <asp:TextBox ID="TextBoxMCustomerPhoneNumber" CssClass="form-control form-control-sm" TextMode="Number" placeholder="Enter Number" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="modal-footer">
                                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancel</button>
                                   
                                    <asp:Button ID="ButtonMConfirm" CssClass="btn btn-success" runat="server" Text="Confirm" OnClick="ButtonMConfirm_Click" />
                               
                                    </div> 
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
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

        <!--end Of Nav-->
         <%-- <asp:Timer ID="Timer1" runat="server" Interval="10000" OnTick="Timer1_Tick"></asp:Timer> <%--timer PageRefresh----%>
        <div class="UserGradient">
            <div class="row">
                <div class="col-12 text-center">
                    <h1 class="h_Gradient header-site"> </h1>
                </div>
            </div>

            <%--  whats app and audio setting--%>
            <nav>
                <div class="nav nav-tabs" id="nav-tab" role="tablist">
                    <button class="nav-link  text-warning" id="nav-home-tab" data-bs-toggle="tab" data-bs-target="#nav-home" type="button" role="tab" aria-controls="nav-home" aria-selected="false"><i class="fa-solid fa-dice-five"></i></button>
                    <button class="nav-link active text-warning" id="nav-t-tab" data-bs-toggle="tab" data-bs-target="#nav-t" type="button" role="tab" aria-controls="nav-t" aria-selected="true"><i class="fa-solid fa-ticket"></i></button>
                    <button class="nav-link text-warning" id="nav-Full-tab" data-bs-toggle="tab" data-bs-target="#nav-Full" type="button" role="tab" aria-controls="nav-Full" aria-selected="false">Full Sheet</button>
                    <button class="nav-link text-warning" id="nav-Half-tab" data-bs-toggle="tab" data-bs-target="#nav-Half" type="button" role="tab" aria-controls="nav-Half" aria-selected="false">Half sheet</button>
                    <button class="nav-link text-warning" id="nav-profile-tab" data-bs-toggle="tab" data-bs-target="#nav-profile" type="button" role="tab" aria-controls="nav-profile" aria-selected="false"><i class="fa-regular fa-user"></i></button>
                   
                </div>
            </nav>
        </div>
        <div class="tab-content" id="nav-tabContent">
            <div class="tab-pane fade " id="nav-home" role="tabpanel" aria-labelledby="nav-home-tab">
                <%--Home--%>
                <asp:UpdatePanel ID="UpdatePanelHome" Visible="true" runat="server">
                    <ContentTemplate>
                        <div class="container-fluid">

                            <div class="container">
                                <!-- Title -->
                                <h2 class="text-center py-3">Game Details</h2>
                                <!-- Main content -->
                                <div class="row">
                                    <div class="col-lg-8">
                                        <!-- Details -->
                                        <div class="card mb-4">
                                            <div class="card-body">
                                                <div class="mb-3 d-flex justify-content-between">
                                                    <div>
                                                        <span class="me-3">Game Number:</span>
                                                        <asp:Label ID="LabelGameNumber" CssClass="me-3 badge rounded-pill bg-info" runat="server" Text="Label"></asp:Label>
                                                    </div>
                                                </div>
                                                <table class="table table-sm table-borderless">
                                                    <tbody>                               
                                                        <tr>
                                                            <td>Game Date</td>
                                                            <td class="text-end">
                                                                <asp:Label ID="LabelDate" runat="server"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td>Game Time</td>
                                                            <td class="text-end">
                                                                <asp:Label ID="LabelTime" runat="server"></asp:Label></td>
                                                        </tr>
                                                         <tr>
                                                            <td>Tickets Sold</td>
                                                            <td class="text-end">
                                                                <asp:Label ID="Labelsold" runat="server"></asp:Label></td>
                                                        </tr>
                                                         <tr>
                                                            <td>Tickets Left</td>
                                                            <td class="text-end">
                                                                <asp:Label ID="Labelleft" runat="server"></asp:Label></td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
             <div class="tab-pane fade show active  " id="nav-t" role="tabpanel" aria-labelledby="nav-t-tab">
                 <asp:UpdatePanel ID="UpdatePanelT" runat="server">
                     <ContentTemplate>
                 <div class="container">
                     <div class="container-body">
                              <input type="button" id="stickyButton" value="sell" class="mb-4 btn btn-sm btn-primary m-4 fixed-bottom" data-bs-toggle="modal" data-bs-target="#exampleModal" onclick="setArray();" style="width:10%;" />
                         <div class="text-center">
                              <table id="WholeTable" class="mt-3 table fw-bold text-dark text-center table-sm table-bordered border-2 border-primary mb-4" style="width:80%;margin-left:auto;margin-right:auto;">
                         </table>
                         </div>
                     </div>
                 </div>    
                    </ContentTemplate>
                 </asp:UpdatePanel>
             </div>
            
            <div class="tab-pane fade" id="nav-Full" role="tabpanel" aria-labelledby="nav-Full-tab">
                <asp:UpdatePanel ID="UpdatePanelFull" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="PanelFull" Visible="true" style="display:none;" runat="server">
                            <div class="text-center py-5 h-100">
                                <asp:Image ID="Image3" Visible="true" runat="server" ImageUrl="~/Content/images/Sold_out.png" ImageAlign="AbsMiddle" Height="40%" Width="40%" />
                            </div>
                        </asp:Panel>
                        <div class="card" id="card-full">
                            <div class="card-body">
                                <asp:GridView ID="GridViewFullsheet" runat="server" AutoGenerateColumns="false" CssClass="table table-sm table-dark" OnRowCommand="GridViewFullsheet_RowCommand" Visible="False" OnRowDataBound="GridViewFullsheet_RowDataBound">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Name" HeaderStyle-CssClass="text-center" ItemStyle-Width="110px" HeaderStyle-Font-Size="14px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtName" runat="server" Text='<%# Eval("Name") %>' Width="100%" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Fullsheet" ItemStyle-CssClass="text-success" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" HeaderText="Sheet No" HeaderStyle-Font-Size="12px" />
                                        <%-- Ticket Range--%>
                                        <asp:TemplateField HeaderText="Ticket Range" ItemStyle-Font-Size="14px" HeaderStyle-Font-Size="14px">
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text="1"></asp:Label>
                                                <asp:Label ID="Label2" runat="server" Text="2"></asp:Label>
                                                <asp:Label ID="Label3" runat="server" Text="3"></asp:Label>
                                                <asp:Label ID="Label4" runat="server" Text="4"></asp:Label>
                                                <asp:Label ID="Label5" runat="server" Text="5"></asp:Label>
                                                <asp:Label ID="Label6" runat="server" Text="6"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%-- Ticket Range--%>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Button ID="btn" Text="Buy" runat="server" CssClass="bg-warning" CommandName="Select" CommandArgument="<%# Container.DataItemIndex %>" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="tab-pane fade" id="nav-Half" role="tabpanel" aria-labelledby="nav-Half-tab">
                <%--.Half..--%>
                <asp:UpdatePanel ID="UpdatePanelHalf" runat="server">
                <%--     <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
                    </Triggers>--%>
                    <ContentTemplate>
                        <asp:Panel ID="PanelHalf" Visible="true" style="display:none;" runat="server">
                            <div class="text-center py-5 h-100">
                                <asp:Image ID="Image4" Visible="true" runat="server" ImageUrl="~/Content/images/Sold_out.png" ImageAlign="AbsMiddle" Height="40%" Width="40%" />
                            </div>
                        </asp:Panel>
                        <div class="card"  id="card-half">
                            <div class="card-body">
                                <asp:GridView ID="GridViewHalfSheet" runat="server" AutoGenerateColumns="false" CssClass="table table-sm table-dark" OnRowCommand="GridViewHalfSheet_RowCommand" Visible="False" OnRowDataBound="GridViewHalfSheet_RowDataBound">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Name" HeaderStyle-CssClass="text-center" ItemStyle-Width="130px" HeaderStyle-Font-Size="14px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtName" runat="server" Text='<%# Eval("Name") %>' Width="100%" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="HalfSheet" ItemStyle-CssClass="text-success" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" HeaderText="Sheet No" HeaderStyle-Font-Size="12px" />
                                        <%-- Ticket Range--%>
                                        <asp:TemplateField HeaderText="Ticket Range" ItemStyle-Font-Size="14px" HeaderStyle-Font-Size="14px">
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text="1"></asp:Label>
                                                <asp:Label ID="Label2" runat="server" Text="2"></asp:Label>
                                                <asp:Label ID="Label3" runat="server" Text="3"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%-- Ticket Range--%>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Button Text="Buy" runat="server" CssClass="bg-warning" CommandName="Select" CommandArgument="<%# Container.DataItemIndex %>" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="tab-pane fade" id="nav-profile" role="tabpanel" aria-labelledby="nav-profile-tab">
                       <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
                <%--Agent Profile--%>
                <section class="h-100 AdminGradient">
                    <div class="container py-5 h-100">
                        <div class="text-end">
                            <asp:Button ID="ButtonLogout" CssClass="btn btn-dark" runat="server" Text="Logout" OnClick="ButtonLogout_Click"/>
                        </div>
                        <div class="row d-flex justify-content-center align-items-center h-100">
                            <div class="col col-lg-9 col-xl-7">
                                <div class="card">
                                    <div class="rounded-top text-white d-flex flex-row" style="background-color: #000; height: 200px;">
                                        <div class="ms-4 mt-5 d-flex flex-column" style="width: 150px;">
                                            <asp:Image ID="ImageProfile" runat="server" alt="Generic placeholder image" class="img-fluid img-thumbnail mt-4 mb-2"
                                                Style="width: 150px; height:150px; z-index: 1" />
                                            <asp:Button ID="Buttonupdateprofileimage" class="btn btn-outline-light" data-mdb-ripple-color="dark"
                                                Style="z-index: 1; font-size: 0.8rem;" runat="server" Text="Change Profile Picture" OnClientClick="editProfile();" />
                                        </div>
                                    
                                        <div class="ms-3" style="margin-top: 130px;">
                                            <h5>
                                                <asp:Label ID="LabelAgentProfileName" runat="server" Text="Default"></asp:Label></h5>
                                            <p>
                                                <asp:Label ID="LabelPhoneNumber" runat="server"></asp:Label>
                                            </p>
                                        </div>
                                    </div>
                                    <div class="p-4 text-black" style="background-color: #f8f9fa;">

                                        <div class="d-flex justify-content-end text-center py-1">
                                            <div class="px-3">
                                                <p class="mb-1 h5">
                                                    <asp:Label ID="LabelTotalTicketSold" runat="server" Text="0"></asp:Label>
                                                </p>
                                                <p class="small text-muted mb-0">Total Ticket Sold</p>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="container">
                                        <div class=" Text-center">
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>
                                                    <asp:GridView ID="GridViewMyTickets" CssClass="table table-sm table-dark" runat="server" OnRowDataBound="GridViewMyTickets_RowDataBound">
                                                        <HeaderStyle Font-Size="13px" />
                                                        <RowStyle Font-Size="12px" />
                                                    </asp:GridView>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </section>
                  </ContentTemplate>
            </asp:UpdatePanel>
            </div>
        </div>
    </form>
</body>
</html>
