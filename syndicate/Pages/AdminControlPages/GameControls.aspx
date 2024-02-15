<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GameControls.aspx.cs" Inherits="syndicate.Pages.AdminControlPages.GameControls" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <link href="../../Content/bootstrap.css" rel="stylesheet" />
       <link href="../../lib/font-awesome/css/all.min.css" rel="stylesheet" />
    <script src="../../Scripts/bootstrap.js"></script>
    <title></title>
</head>
<body class="bg-dark">
    <form id="form1" runat="server">
        <div>
            <div class="container py-2 ">
                  <a href="../../admin">
                                <i class="fas fa-arrow-left mt-3"></i></a>
                       <h6 class="text-center text-light fw-bold">ReSchedule Game </h6>
                       <div class="card mb-4 bg-dark text-light border border-1">
                        <div class="card-body ">
                            <div class="row">
                                 <div class="col-6 text-warning bg-gradient" style="font-size:12px">Total Tickets: <asp:Label ID="LabelTT" runat="server"></asp:Label></div>
                                  <div class="col-6 text-warning bg-gradient" style="font-size:12px"> Sold:  <asp:Label ID="LabelTS" runat="server"></asp:Label></div>
                            </div>
                            <div class="row">
                                <div class="col-5">
                                    <label>Scheduled at :</label>
                                </div>
                                <div class="col-7">
                                    <asp:Label ID="LabelCurrentGameDate" class="text-warning" runat="server"></asp:Label>
                                </div>
                            </div>
                             <div class="row">
                                <div class="col-5">
                                    <label>Reschedule :</label>
                                </div>
                                <div class="col-7">
                                    <asp:TextBox ID="TextBoxRescheduleCalander" CssClass="form-control form-control-sm" TextMode="DateTimeLocal" runat="server" ></asp:TextBox>
                                </div>
                            </div>
                            <div class="row mt-1">
                                <div class="col-12 text-end">
                                    <asp:Button ID="ButtonReSchedule"  CssClass="btn btn-primary btn-sm" runat="server" Text="save" OnClick="ButtonReSchedule_Click" AutoPostBack="true"/>
                                </div>          
                            </div>
                        </div>
                    </div>
                <div class="card ">
                    <div class="card-header text-bold">Game Controls</div>
                    <div class="card-body">
                        <table class="table table-small table-dark table-borderless text-center">
                            <thead>
                                <tr><td colspan="3" class="table-active">Cancel Ticket</td></tr>
                                <tr>
                                    <td  style="font-size: 13px;">Ticket Number:</td>
                                    <td> <asp:TextBox ID="TextBoxTicketNo" TextMode="Number" placeholder="no. eg:1" CssClass="form-control form-control-sm" runat="server"></asp:TextBox></td>
                                    <td>
                                        <asp:Button ID="ButtonCancelTicket" runat="server"  CssClass="btn btn-sm btn-danger" Text="Cancel" OnClick="ButtonCancelTicket_Click" /></td>
                                </tr>
                                <tr><td colspan="3" class="table-active">Close Booking for Agents</td></tr>
                                  <tr>
                                    <td colspan="2">Close Ticket Booking</td>
                                    <td > <asp:Button ID="ButtonCloseBooking" runat="server" CssClass="btn btn-sm btn-primary" Text="close " OnClick="ButtonCloseBooking_Click" /></td>
                                   
                                </tr>
                                  <tr>
                                     <td colspan="3" class="table-active">Clear and restart the Game in 5 min</td>
                                </tr>
                                <tr>
                                    <td>Restart:</td>
                                    <td colspan="2">
                                        <asp:Button ID="ButtonReset" runat="server" Text="Restart Game" OnClick="ButtonRestart_Click" /></td>
                                    
                                </tr>
                                <tr>
                                     <td colspan="3" class="table-active">Reset the Game and start in 5 min</td>
                                </tr>
                                <tr>
                                    <td>Reset:</td>
                                    <td colspan="2">
                                        <asp:Button ID="ButtonRestart" runat="server" Text="Reset Game" OnClick="ButtonReset_Click" /></td>
                                </tr>
                            </thead>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
