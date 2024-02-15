<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateTicket.aspx.cs" Inherits="syndicate.Pages.TempDesign.CreateTicket" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="../../Scripts/jquery-3.4.1.js"></script>
    <title>create ticket</title>
</head>
<body>

    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
       <div id="checkOutOverlayDiv" style="background-color:#49668D">
 
<br>
<div id="checkOutDiv" name="themeColorEl">
<button class="inp" id="selectedTicketIdBtn"  style="background:rgba(0,0,0,0);font-weight: bold;">Create Ticket Dashboard</button>
<br>
    <asp:Label class="inp" ID="LabelTFull" runat="server" Text="Total full sheet" style="background:rgba(0,0,0,0);font-weight: bold;"></asp:Label>
     <asp:Label class="inp" ID="LabelThalf" runat="server" Text="Total half hseet" style="background:rgba(0,0,0,0);font-weight: bold;"></asp:Label>
<br>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
             <asp:TextBox ID="TextBoxtotalTickets" runat="server" placeholder="Total Ticket" class="inp" TextMode="Number"></asp:TextBox>
    <asp:Button ID="ButtonCreateTicket" OnClick="ButtonCreateTicket_Click" runat="server" Text="Create Ticket" style="background: yellow;" class="inp" />
        </ContentTemplate>
    </asp:UpdatePanel>
<br>
<button class="infoBtn" id="infoBtn" style="display:none">Success full</button>
    <center><a href="admin">Back</a></center>
</div>
</div>
    </form>

    <script type="text/javascript">
        (function () {
            var oldVal;

            $('#TextBoxtotalTickets').on('change textInput input', function () {
                var val = this.value;
                if (val !== oldVal) {
                    oldVal = val;
                    dividesheets(val);
                }
            });
        }());
        function dividesheets() {
            var Totalticket = document.getElementById("TextBoxtotalTickets").value;
            var fullsheet = Math.floor(Totalticket / 6);
            var halfsheet = Math.floor(Totalticket / 3);
            document.getElementById("LabelTFull").innerText ="Total full Sheet:"+ fullsheet;
            document.getElementById("LabelThalf").innerText = "Total half Sheet:" +halfsheet;
        }
    </script> 

        <style>
       #body{
        background: rgb(52, 157, 255);
        background-image: linear-gradient(rgb(4, 153, 163), rgb(3, 58, 68));
    }
    #mainDiv{
        width:50%;
        margin-left:25%;
        border:0px solid red;
        overflow: hidden;
    }
    .titleImg{
width:100%;
    }
    #checkOutOverlayDiv{
    width: 100%;
    height:100%;
    background: rgba(0, 0, 0, 0);
    position: fixed;
    margin-top: -1%;
    margin-left: -1%;
    display: block;
}

#checkOutDiv{
    width:50%;
    height:300px;
    background: #98C1D9;
    border-radius: 20px;
    margin-left: 25%;
    margin-top: 10px;
}
.inp{
    font-size: 20px;
    padding:5px;
    border-radius: 10px;
    width:80%;
    margin-left: 10%;
    border:0px solid grey;
    outline: none;
    margin-top: 5px;
}
#closeBtn{
    width:50px;
    height:50px;
    font-size:30px;
    border:0px solid grey;
    background: rgba(0,0,0,0);
    position: absolute;
    margin-left:45%;
    outline:none;
}
.infoBtn{
    font-size:30px;
    width:505;
    border:0px solid grey;
    background: rgba(0,0,0,0);
    position: absolute;
    margin-left:6%;
    margin-top: 50px;
    outline:none;
    color:green;
    display:none;
}
a {
  font-size: 20px;
}


        @media only screen and (max-width: 1000px) {
            #body {
                background: rgb(52, 157, 255);
                background-image: linear-gradient(rgb(4, 153, 163), rgb(3, 58, 68));
            }

            #mainDiv {
                width: 90%;
                margin-left: 5%;
                border: 0px solid red;
            }

            .titleImg {
                width: 100%;
            }

            #checkOutDiv {
                width: 90%;
                height: 600px;
                background: #98C1D9;
                border-radius: 20px;
                margin-left: 5%;
                margin-top: 50px;
            }

            .inp {
                font-size: 40px;
                padding: 10px;
                border-radius: 10px;
                width: 80%;
                margin-left: 10%;
                border: 0px solid grey;
                outline: none;
                margin-top: 20px;
            }

            #closeBtn {
                width: 50px;
                height: 50px;
                font-size: 50px;
                border: 0px solid grey;
                background: rgba(0,0,0,0);
                position: absolute;
                margin-left: 83%;
                outline: none;
            }

            .infoBtn {
                font-size: 60px;
                width: 50%;
                border: 0px solid grey;
                background: rgba(0,0,0,0);
                position: absolute;
                margin-left: 20%;
                margin-top: 50px;
                outline: none;
                color: green;
            }

            a {
                font-size: 40px;
            }
        }
</style>
</body>
</html>
