<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AllTickets.aspx.cs" Inherits="syndicate.Pages.AllTickets" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <script src="../Scripts/jquery-3.4.1.js"></script>
    <link href="../Content/Custom/tables.css" rel="stylesheet" />

    <title>Tickets</title>
</head>
<body class="background-lime" onload="get();">
    <form id="form1" runat="server">
        <div>


            <h2 class="center-item" style="color: #ffeb3b">Tickets</h2>
            <div class="row">
                <div class="column" style="background-color: #8bc34a;">
                    <h5 style="margin: 0px" class="center-item">Available</h5>
                </div>
                <div class="column" style="background-color: #ffeb3b;">
                    <h5 style="margin: 0px" class="center-item">Booked</h5>
                </div>

            </div>
            <div id="TicketTable"></div>
            <table id="tableticket" class="center-item">
                <tr>
                </tr>
            </table>
        </div>
    </form>
</body>
<script src="../Scripts/allTickets/Alltickets.js"></script>
</html>
