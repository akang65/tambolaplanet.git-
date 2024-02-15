<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgentEditProfile.aspx.cs" Inherits="syndicate.Pages.Agent.AgentEditProfile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <link href="../../Content/bootstrap.css" rel="stylesheet" />
    <script src="../../Scripts/bootstrap.js"></script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="container">
                <div class="card">
                    <div class="text-center">
                    <div class="card-header">
                        <div class="card-body">
                            <p> Upload Image</p>
                            <asp:Label ID="LabelStatus" runat="server"></asp:Label>
                            <asp:FileUpload ID="FileUpload1" runat="server" />
                            <asp:Button ID="ButtonUpload" runat="server" Text="Upload" OnClick="ButtonUpload_Click" />
                        </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </form>
</body>
</html>
