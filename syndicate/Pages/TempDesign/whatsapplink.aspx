<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="whatsapplink.aspx.cs" Inherits="syndicate.Pages.TempDesign.whatsapplink" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> Add whatsapp link</title>
</head>
<body>
    <form id="form1" runat="server">
                <div class="titleDiv header-site" id="websiteTitle" style="display: none;">
        </div>

<!---check out div-->
<div id="checkOutOverlayDiv" style="background-color:#4A678E">
<br>
<br>
<br>
<div id="checkOutDiv" name="themeColorEl">
<button class="inp" id="selectedTicketIdBtn"  style="background:rgba(0,0,0,0);font-weight: bold;">Set whatsapp group link</button>
    <asp:TextBox ID="TextBoxlink" runat="server"  class="inp" placeholder="whatsapp link"></asp:TextBox>
    <asp:Button ID="Buttonsave" runat="server" Text="Save" class="inp" style="background: yellow;" OnClick="Buttonsave_Click" />
</br>
</br>
<center><a href="admin">Back</a></center>
</div>
    </form>
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
