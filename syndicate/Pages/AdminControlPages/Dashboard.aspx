<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GameDetails.aspx.cs" Inherits="syndicate.Pages.AdminControlPages.GameDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="../../Content/bootstrap.css" rel="stylesheet" />
    <link href="../../lib/font-awesome/css/all.min.css" rel="stylesheet" />
    <script src="../../Scripts/bootstrap.js"></script>
    <script type="text/javascript">
        function loadAlert() {
            alert("Booking Closed");
        }
    </script>
    <title>Dashboard</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

            <asp:UpdatePanel ID="UpdatePanelHome" Visible="true" runat="server">
                <ContentTemplate>
                    <div class="container-fluid">

                        <div class="container">
                            <!-- Title -->
                            <a href="../../admin">
                                <i class="fas fa-arrow-left mt-3"></i></a>
                            <h2 class="text-center py-3">Dashboard</h2>
             
                            <!-- Main content -->
                            <div class="row mt-4">
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
                                                        <td>Ticket Price</td>
                                                        <td class="text-end">
                                                            <asp:Label ID="LabelTicketPrice" runat="server"></asp:Label></td>
                                                    </tr>
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
                                                    <tr class="fw-bold">
                                                        <td>Total Tickets</td>
                                                        <td class="text-end">
                                                            <asp:Label ID="LabelTotalTickets" runat="server"></asp:Label></td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                    <!-- Price distribution -->
                                      <div class="col-lg-4">
                                    <!-- FullHouse prices -->
                                    <div class="card mb-4">
                                        <div class="card-body">
                                            <h3 class="h6 text-center fw-bold text-success">Full House Price Distribution</h3>
                                            <table class="table table-sm table-borderless">
                                                <tbody>
                                                    <tr>
                                                        <asp:Panel ID="F1" Visible="false" runat="server">
                                                            <td colspan="2">First Full House</td>
                                                            <td class="text-end">
                                                                <asp:Label ID="Labelf1" runat="server" Text="340"></asp:Label></td>
                                                        </asp:Panel>
                                                    </tr>
                                                    <tr>
                                                        <asp:Panel ID="F2" Visible="false" runat="server">
                                                            <td colspan="2">Second Full House</td>
                                                            <td class="text-end">
                                                                <asp:Label ID="Labelf2" runat="server" Text="340"></asp:Label></td>
                                                        </asp:Panel>
                                                    </tr>
                                                    <tr>
                                                        <asp:Panel ID="F3" Visible="false" runat="server">
                                                            <td colspan="2">Third Full House</td>
                                                            <td class="text-end">
                                                                <asp:Label ID="Labelf3" runat="server" Text="$40"></asp:Label></td>
                                                        </asp:Panel>
                                                    </tr>
                                                    <tr>
                                                        <asp:Panel ID="F4" Visible="false" runat="server">
                                                            <td colspan="2">Fourth Full House</td>
                                                            <td class="text-end">
                                                                <asp:Label ID="Labelf4" runat="server" Text="12/22/22"></asp:Label></td>
                                                        </asp:Panel>
                                                    </tr>
                                                    <tr>
                                                        <asp:Panel ID="F5" Visible="false" runat="server">
                                                            <td colspan="2">Fifth Full House</td>
                                                            <td class="text-end">
                                                                <asp:Label ID="Labelf5" runat="server" Text="04:30 pm"></asp:Label></td>
                                                        </asp:Panel>
                                                    </tr>
                                                    <tr>
                                                        <asp:Panel ID="F6" Visible="false" runat="server">
                                                            <td colspan="2">Sixth Full House</td>
                                                            <td class="text-end">
                                                                <asp:Label ID="Labelf6" runat="server" Text="340"></asp:Label></td>
                                                        </asp:Panel>
                                                    </tr>
                                                    <tr>
                                                        <asp:Panel ID="F7" Visible="false" runat="server">

                                                            <td colspan="2">Seventh Full House</td>
                                                            <td class="text-end">
                                                                <asp:Label ID="Labelf7" runat="server" Text="340"></asp:Label></td>
                                                        </asp:Panel>
                                                    </tr>
                                                    <tr>
                                                        <asp:Panel ID="F8" Visible="false" runat="server">
                                                            <td colspan="2">Eighth Full House</td>
                                                            <td class="text-end">
                                                                <asp:Label ID="Labelf8" runat="server" Text="12/22/22"></asp:Label></td>
                                                        </asp:Panel>
                                                    </tr>
                                                    <tr>
                                                        <asp:Panel ID="F9" Visible="false" runat="server">
                                                            <td colspan="2">Ninth House</td>
                                                            <td class="text-end">
                                                                <asp:Label ID="Labelf9" runat="server" Text="04:30 pm"></asp:Label></td>
                                                        </asp:Panel>

                                                    </tr>
                                                    <tr>
                                                        <asp:Panel ID="F10" Visible="false" runat="server">
                                                            <td colspan="2">Tenth House</td>
                                                            <td class="text-end">
                                                                <asp:Label ID="Labelf10" runat="server" Text="340"></asp:Label></td>
                                                        </asp:Panel>
                                                    </tr>
                                                    <tr>
                                                        <asp:Panel ID="F11" Visible="false" runat="server">
                                                            <td colspan="2">Eleventh House</td>
                                                            <td class="text-end">
                                                                <asp:Label ID="Labelf11" runat="server" Text="340"></asp:Label></td>
                                                        </asp:Panel>
                                                    </tr>
                                                    <tr>
                                                        <asp:Panel ID="F12" Visible="false" runat="server">
                                                            <td colspan="2">Twelfth Full House</td>
                                                            <td class="text-end">
                                                                <asp:Label ID="Labelf12" runat="server" Text="340"></asp:Label></td>
                                                        </asp:Panel>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                                    <div class="card mb-4">
                                        <div class="card-body">
                                            <div class="row">
                                                <div class="col-lg-6">
                                                    <h3 class="h6 text-center text-success fw-bold"> Other Bonus Price Distribution</h3>
                                                </div>
                                                <table class="table table-sm table-borderless">
                                                    <tbody>
                                                        <tr>
                                                            <td>Full Sheet</td>
                                                            <td class="text-end">
                                                                <asp:Label ID="LabelFulls" runat="server" Text="340"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td>Half Sheet</td>
                                                            <td class="text-end">
                                                                <asp:Label ID="LabelHalfs" runat="server" Text="340"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td>Quick Five</td>
                                                            <td class="text-end">
                                                                <asp:Label ID="Labelfive" runat="server" Text="$40"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td>Quick Seven</td>
                                                            <td class="text-end">
                                                                <asp:Label ID="Labelseven" runat="server" Text="12/22/22"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td>Top Line</td>
                                                            <td class="text-end">
                                                                <asp:Label ID="LabelTop" runat="server" Text="04:30 pm"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td>Middle Line</td>
                                                            <td class="text-end">
                                                                <asp:Label ID="LabelMiddle" runat="server" Text="340"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td>Bottom Line Line</td>
                                                            <td class="text-end">
                                                                <asp:Label ID="LabelBottom" runat="server" Text="340"></asp:Label></td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
    </form>
</body>
</html>
