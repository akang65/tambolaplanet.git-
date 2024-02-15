<%@ Page Language="C#" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeBehind="HomeBeforeGame.aspx.cs" Inherits="syndicate.Pages.HomeBeforeGame" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="../Content/bootstrap.css" rel="stylesheet" />
    <link href="../lib/font-awesome/css/all.css" rel="stylesheet" />
    <script src="../Scripts/jquery-3.4.1.js"></script>
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Caveat-Bold" />
    <link href="../Content/Custom/UserSideNav.css" rel="stylesheet" />
    <script src="../Scripts/CustomCountDownTimer.js"></script>
    <script src="../Scripts/UserSideNav.js"></script>
    <script src="../Scripts/HomeBeforegameScripts/beforegameScript.js"></script>
    <title>Home</title>
</head>
<body class="gradient-syndicate">
    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager2" ScriptMode="Release" runat="server"></asp:ScriptManager>
        <script type="text/javascript">
            var prm = Sys.WebForms.PageRequestManager.getInstance();
            prm.add_beginRequest(beginRequest);

            function beginRequest() {
                prm._scrollPosition = null;
            }
        </script>

        <asp:SqlDataSource ID="SqlDataSourcefullhouse" runat="server" ConnectionString="<%$ ConnectionStrings:tambolastars %>" SelectCommand="SELECT [FullHouse], [SecondFullHouse], [ThirdFullHouse], [FourthFullHouse], [TwelveFullHouse], [ElevenFullHouse], [TenFullHouse], [NineFullHouse], [EightFullHouse], [SeventhFullHouse], [SixthFullhouse], [FifthFullHouse] FROM [PriceMoney]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSourceGameDetails" runat="server" ConnectionString="<%$ ConnectionStrings:tambolastars %>" SelectCommand="SELECT [Date], [GameNo], [FullHouseNo], [CostOfTicket], [NoOfTickets] FROM [GameDetails]"></asp:SqlDataSource>
        <!--navagation Items-->

        <%--     <div id="mySidenav" class="sidenav">
            <a href="javascript:void(0)" class="closebtn" onclick="closeNav()">&times;</a>
            <a href="pageDetails/About.aspx">About us</a>
            <a href="pageDetails/contact.aspx">Contact us</a>
            <a href="pageDetails/refund.aspx">Refund</a>
            <a href="pageDetails/privacypolicy.aspx">Privacy Policy</a>
            <a href="pageDetails/TermsandServices.aspx">TermsandServices</a>
        </div>--%>


        <!--end Of Nav-->

        <div>
            <%--<h1 class="text-center text-light">Vip Tambola</h1>--%>
            <img src="../Content/images/logo-no-background.png" style="width:30%; height:40%" class=" rounded mx-auto d-block" />
            <d class="container">

                <%--  <h6 class="text-center text-light">Game Starts in:</h6>
                    <p id="Timer" class="text-light text-center"></p>--%>
                <table class="text-light table table-sm table-borderless" style="font-size: 13px">
                    <tbody class="text-center">
                        <tr>
                            <td id="days" class="bg-white text-dark border border-1 border-dark">0</td>
                            <td id="hours" class="bg-white text-dark border-1 border-dark">0</td>
                            <td id="min" class="bg-white text-dark border-1 border-dark">0</td>
                            <td id="sec" class="bg-white text-dark border-1 border-dark">0</td>
                        </tr>
                        <tr>
                            <td>Days</td>
                            <td>Hours</td>
                            <td>Minutes</td>
                            <td>Seconds</td>
                        </tr>
                    </tbody>
                </table>
                <table class=" text-center text-light table table-sm table-bordered table-dark">
                    <tbody>
                        <tr>
                            <td style="font-size: 12px">Date :
                                <asp:Label ID="Labeldate" runat="server" Text="Label"></asp:Label></td>
                            <td style="font-size: 12px">Time :<asp:Label ID="Labeltime" runat="server" Text="Label"></asp:Label></td>
                            <td style="font-size: 12px">Game No :<asp:Label ID="Labelgameno" runat="server" Text="Label"></asp:Label></td>
                        </tr>
                    </tbody>
                </table>
                <div class="container">
                        <div class="row">
                    <div class="col-6">
                        <div class="text-center">
                            <asp:Button ID="ButtonWhatsapp" class="mt-2 text-light form-control form-control-sm bg-success border-gradient" runat="server" Style="font-size: 12px" Text="Join Whats app Group" Font-Size="Small"  OnClick="ButtonWhatsapp_Click" />
                        </div>
                    </div>
                    <div class="col-6">
                        <div class="text-center">
                            <asp:Button ID="ButtonAgentLists" class="mt-2 text-light form-control form-control-sm bg-dark border-gradient" runat="server" Style="font-size: 12px" Text="Agents list" Font-Size="Small" OnClick="ButtonAgentLists_Click" />
                        </div>
                    </div>
                </div>
                </div>
                <asp:Panel ID="PanelFullHouse" runat="server">
                    <%--full house price table--%>
                    <div class="container mt-2">
                        <div class="container-body">
                            <div class="card card-Trans">
                                <div class="row mt-3">
                                    <div class="col-4 text-center">
                                        <asp:Button ID="ButtonCheckAllTicket" CssClass="btn btn-warning border border-warning btn-sm" runat="server" Text=" View Tickets" OnClick="ButtonCheckAllTicket_Click" />
                                    </div>
                                    <div class="col-6">
                                        <input type="search" id="searchbox" class="form-control form-control-sm " placeholder="Search" />
                                    </div>
                                    <div class="col-2">
                                        <div class="align-item-start">
                                            <button type="button" id="btn-search" onclick="searchTable();" class="btn btn-warning btn-sm">
                                                <i class="fas fa-search"></i>
                                            </button>
                                        </div>
                                    </div>
                                </div>
                                <div class="container">
                                    <div class="container-body">
                                        <div class="row">
                                            <div class="col-12 text-end mt-2">
                                                <button type="button" id="btn-clear" onclick="removeSearchTable();" class="btn transparentBg text-light btn-sm" style="display: none;">
                                                    <i class="fas fa-regular fa-xmark"></i>
                                                </button>
                                            </div>
                                        </div>
                                        <div class="mt-1" id="Searchedtable"></div>
                                    </div>
                                </div>

                                <div class="mt-2" id="grid1" runat="server"></div>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
        </div>
    </form>

</body>
</html>
